using Newtonsoft.Json.Linq;
using System.Data;
using System.Text.RegularExpressions;

namespace Project_Nesja.Data
{
    public static class GameData
    {
        public static string? CurrentVersion { get; set; }
        public static Dictionary<int, ChampionData> ChampionList { get; set; }
        public static Ranks RankedQueue { get; set; }
        public static Dictionary<int, ChampionRoleData> Aram { get; set; }
        public static Dictionary<int, Item> ItemsList { get; set; }
        public static JArray? Runes { get; set; }
        public static JObject? SummonerSpells { get; set; }
        //public static JObject? Abilities { get; set; }



        static GameData()
        {
            CurrentVersion = "";
            ChampionList = new Dictionary<int, ChampionData>();
            RankedQueue = new Ranks();
            Aram = new Dictionary<int, ChampionRoleData>();
            ItemsList = new Dictionary<int, Item>();
            Runes = new JArray();
            SummonerSpells = new JObject();
            RankedQueue.All.All = new Dictionary<int, ChampionRoleData>();
            RankedQueue.All.Top = new Dictionary<int, ChampionRoleData>();
            RankedQueue.All.Jungle = new Dictionary<int, ChampionRoleData>();
            RankedQueue.All.Mid = new Dictionary<int, ChampionRoleData>();
            RankedQueue.All.ADC = new Dictionary<int, ChampionRoleData>();
            RankedQueue.All.Support = new Dictionary<int, ChampionRoleData>();
        }

        public static async void FetchGameData()
        {
            // Grabs Current Live Patch Version
            CurrentVersion = (await WebRequests.GetJsonObject("https://ddragon.leagueoflegends.com/api/versions.json")).First.ToString();

            // Grabs All Champion Data
            var Champions = (JObject?)(await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/champion.json")).SelectToken("data");

            // Parses the Champion Data into a Easily Accessible Dictionary of Relevant Data
            foreach (var champion in Champions.Children())
            {
                ChampionData championData = new ChampionData();
                championData.Name = champion.First.SelectToken("name").ToString();
                championData.Title = champion.First.SelectToken("title").ToString();
                championData.NameID = champion.First.SelectToken("id").ToString();
                championData.ID = ((int)champion.First.SelectToken("key"));
                championData.Difficulty = ((int)champion.First.SelectToken("info").Last());

                ChampionList.Add(championData.ID, championData);
            }

            // Grabs Last 7 Days of Ranked Data
            FetchChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all"), RankedQueue.All.All);
            FetchChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=top"), RankedQueue.All.Top);
            FetchChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=jungle"), RankedQueue.All.Jungle);
            FetchChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=mid"), RankedQueue.All.Mid);
            FetchChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=adc"), RankedQueue.All.ADC);
            FetchChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=support"), RankedQueue.All.Support);

            // Grabs Last Month of Aram Games Data, Global
            FetchChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/aram?period=month&tier=all"), Aram);

            // Grabs All Item Data
            var Items = (JObject?)(await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/item.json")).SelectToken("data");

            // Parses the Item Data into a Easily Accessible Dictionary of Relevant Data
            foreach (var item in Items.Children())
            {
                Item ItemData = new Item();
                ItemData.Name = item.First.ToString();
                ItemData.ID = int.Parse(item.First.SelectToken("image").SelectToken("full").ToString().Split('.')[0]);

                ItemsList.Add(ItemData.ID, ItemData);
            }

            // Grabs All Rune Data
            var RuneData = (JArray?)(await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/runesReforged.json"));
            
            // NEED TO ADD A WAY OF TURNING THE RUNEDATA INTO RUNE OBJECT

            
            // Grabs All SummonerSpell Data
            SummonerSpells = (JObject?)(await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/summoner.json")).SelectToken("data");
        }

        private static void FetchChampRoleData(JObject rankedData, Dictionary<int, ChampionRoleData> ChampRoleDataList)
        {
            foreach (var champion in rankedData.SelectToken("data"))
            {
                // Parses the relevant Data into the ChampionRoleData object and adds it to a Dictionary for that Role
                ChampionRoleData championRoleData = new ChampionRoleData();
                championRoleData.ChampionData = ChampionList.Where(x => x.Key == champion.SelectToken("champion_id").ToObject<int>()).First().Value;
                championRoleData.TotalGames = champion.SelectToken("play").ToObject<int>();
                championRoleData.GamesWon = champion.SelectToken("win").ToObject<int>();
                championRoleData.GamesLost = championRoleData.TotalGames - championRoleData.GamesWon;
                championRoleData.TotalKills = champion.SelectToken("kill").ToObject<int>();
                championRoleData.TotalDeaths = champion.SelectToken("death").ToObject<int>();
                championRoleData.TotalAssists = champion.SelectToken("assist").ToObject<int>();
                championRoleData.TotalCS = champion.SelectToken("cs").ToObject<int>();

                // Checks for Null value. This value is Null when looking at Aram Data
                int neutralCS;
                int.TryParse(champion.SelectToken("neutral_cs")?.ToString(), out neutralCS);
                championRoleData.TotalNeutralCS = neutralCS;

                championRoleData.PickRate = champion.SelectToken("pick_rate").ToObject<float>();

                // Checks for Null value. This value is Null when looking at Aram Data
                float banRate;
                float.TryParse(champion.SelectToken("ban_rate")?.ToString(), out banRate);
                championRoleData.BanRate = banRate;

                ChampRoleDataList.Add(championRoleData.ChampionData.ID, championRoleData);
            }
        }
    }
}