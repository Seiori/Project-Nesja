using Newtonsoft.Json.Linq;
using System.Data;

namespace Project_Nesja.Data
{
    public static class GameData
    {
        public static string? CurrentVersion { get; set; }
        public static Dictionary<int, ChampionData> ChampionList { get; set; }
        public static Ranks RankedQueue { get; set; }
        public static Dictionary<int, ChampionRoleData> Aram { get; set; }
        public static Dictionary<int, Item> ItemsList { get; set; }
        public static Dictionary<int, Runes> RunesList { get; set; }
        public static Dictionary<int, RunePages> RunePagesList { get; set; }
        public static Dictionary<int, StatMods> StatModsList { get; set; }
        public static Dictionary<int, SummonerSpells> SummonerSpellsList { get; set; }



        static GameData()
        {
            CurrentVersion = "";
            ChampionList = new Dictionary<int, ChampionData>();
            RankedQueue = new Ranks();
            RankedQueue.All.All = new Dictionary<int, ChampionRoleData>();
            RankedQueue.All.Top = new Dictionary<int, ChampionRoleData>();
            RankedQueue.All.Jungle = new Dictionary<int, ChampionRoleData>();
            RankedQueue.All.Mid = new Dictionary<int, ChampionRoleData>();
            RankedQueue.All.ADC = new Dictionary<int, ChampionRoleData>();
            RankedQueue.All.Support = new Dictionary<int, ChampionRoleData>();
            Aram = new Dictionary<int, ChampionRoleData>();
            ItemsList = new Dictionary<int, Item>();
            RunesList = new Dictionary<int, Runes>();
            RunePagesList = new Dictionary<int, RunePages>();
            StatModsList = new Dictionary<int, StatMods>();
            SummonerSpellsList = new Dictionary<int, SummonerSpells>();
        }

        public static async void FetchGameData()
        {
            // Grabs Current Live Patch Version
            CurrentVersion = (await WebRequests.GetJsonObject("https://ddragon.leagueoflegends.com/api/versions.json")).First.ToString();

            // Grabs All Champion Data
            var champions = (await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/champion.json")).SelectToken("data");

            // Parses the Champion Data into a Easily Accessible Dictionary of Relevant Data
            foreach (var champion in champions.Children())
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
            //ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all"), RankedQueue.All.All);
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=top"), RankedQueue.All.Top);
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=jungle"), RankedQueue.All.Jungle);
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=mid"), RankedQueue.All.Mid);
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=adc"), RankedQueue.All.ADC);
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=support"), RankedQueue.All.Support);
            
            // Grabs Last Month of Aram Games Data, Global
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/aram?period=month&tier=all"), Aram);

            // Grabs All Item Data
            var Items = (await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/item.json")).SelectToken("data");

            // Parses the Item Data into a Easily Accessible Dictionary of Relevant ItemData
            foreach (var item in Items.Children())
            {
                Item ItemData = new Item();
                ItemData.Name = item.First.ToString();
                ItemData.ID = int.Parse(item.First.SelectToken("image").SelectToken("full").ToString().Split('.')[0]);

                ItemsList.Add(ItemData.ID, ItemData);
            }

            // Grabs All Rune Data
            var runeData = (await WebRequests.GetJsonObject("https://www.op.gg/_next/data/2PwAMU3MRxsUxzv2L2VOU/champions/aatrox/top/runes.json?region=global&tier=platinum_plus&champion=aatrox&position=top")).SelectToken("pageProps").SelectToken("data").SelectToken("meta").SelectToken("runes");
            var runePageData = (await WebRequests.GetJsonObject("https://www.op.gg/_next/data/2PwAMU3MRxsUxzv2L2VOU/champions/aatrox/top/runes.json?region=global&tier=platinum_plus&champion=aatrox&position=top")).SelectToken("pageProps").SelectToken("data").SelectToken("meta").SelectToken("runePages");
            var statModData = (await WebRequests.GetJsonObject("https://www.op.gg/_next/data/2PwAMU3MRxsUxzv2L2VOU/champions/aatrox/top/runes.json?region=global&tier=platinum_plus&champion=aatrox&position=top")).SelectToken("pageProps").SelectToken("data").SelectToken("meta").SelectToken("statMods");

            // Parses the Rune Data into an Easily Accessible Dictionary of Relevant RuneData
            foreach (var rune in runeData.Children())
            {
                Runes runes = new Runes();
                runes.Name = (string)rune.ElementAt(5);
                runes.NameID = (string)rune.ElementAt(4);
                runes.ID = (int)rune.First;

                RunesList.Add(runes.ID, runes);
            }

            // Parses the Rune Page Data into an Easily Accessible Dictionary of Relevant RunePageData
            foreach (var runePage in runePageData.Children())
            {
                RunePages runePages = new RunePages();
                runePages.Name = (string)runePage.ElementAt(1);
                runePages.ID = (int)runePage.First;

                RunePagesList.Add(runePages.ID, runePages);
            }

            // Parses the Stat Mod Data into an Easily Accessible Dictionart of Relevant StatModData
            foreach (var statMod in statModData)
            {
                StatMods statMods = new StatMods();
                statMods.Name = (string)statMod.ElementAt(1);
                statMods.ID = (int)statMod.First;

                StatModsList.Add(statMods.ID, statMods);
            }
            
            // Grabs All SummonerSpell Data
            var summonerSpellData = (await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/summoner.json")).SelectToken("data");

            // Parses the Summoner Spell Data into an Easily Accessible Dictionary of Relevant SummonerSpellData
            foreach (var summonerSpell in summonerSpellData.Children())
            {
                SummonerSpells summonerSpells = new SummonerSpells();
                summonerSpells.Name = (string)summonerSpell.First.ElementAt(1);
                summonerSpells.NameID = (string)summonerSpell.First.First;
                summonerSpells.ID = (int)summonerSpell.First.ElementAt(13);

                SummonerSpellsList.Add(summonerSpells.ID, summonerSpells);
            }
        }
        
        private static void ParseChampRoleData(JObject rankedData, Dictionary<int, ChampionRoleData> ChampRoleDataList)
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