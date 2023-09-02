using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project_Nesja.Objects;

namespace Project_Nesja.Data
{
    static class GameData
    {
        public static string? CurrentVersion { get; set; }
        public static Dictionary<int, Champion>? ChampionList { get; set; }
        public static Dictionary<int, Asset>? Assets { get; set; }

        static GameData()
        {
            CurrentVersion = "";
            ChampionList = new Dictionary<int, Champion>();
            Assets = new Dictionary<int, Asset>();

            _ = FetchGameData();
        }

        public static async Task FetchGameData()
        {
            // Grabs Current Live Patch Version
            CurrentVersion = (await WebRequests.GetJsonObject("https://ddragon.leagueoflegends.com/api/versions.json"))!.FirstOrDefault()!.ToString();

            await Task.WhenAll(
                FetchChampionData(),
                FetchItemData(),
                FetchAllRuneData(),
                FetchSummonerSpellData()
            );
        }
        
        private static async Task FetchChampionData()
        {
            // Grabs All Champion Data
            JObject allChampions = (JObject)(await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/champion.json"))!.SelectToken("data")!;

            // Parses the Champion Data into a Easily Accessible Dictionary of Relevant Data
            foreach (var eachChampion in allChampions!)
            {
                JObject eachChampionData = (JObject)eachChampion.Value!;
                
                Champion championData = new()
                {
                    Name = eachChampionData["name"]!.ToString(),
                    Title = eachChampionData["title"]!.ToString(),
                    NameID = eachChampionData["id"]!.ToString(),
                    ID = eachChampionData["key"]!.ToObject<int>()
                };
                ChampionList!.Add(championData.ID, championData);
            }
            
            // Saves Updated ChampionList to File
            File.WriteAllText(Path.Combine("Data", "ChampionList"), JsonConvert.SerializeObject(ChampionList));
        }

        private static async Task FetchItemData()
        {
            // Grabs All Item Data
            JObject allItems = (JObject)(await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/item.json"))!.SelectToken("data")!;

            // Parses the Item Data into a Easily Accessible Dictionary of Relevant ItemData
            foreach (var eachItem in allItems!)
            {
                JObject eachItemData = (JObject)eachItem.Value!;

                Asset itemData = new()
                {
                    Name = eachItemData["name"]!.ToString(),
                    ID = int.Parse(eachItemData["image"]!["full"]!.ToString().Split('.')[0]),
                    AssetType = AssetType.Items
                };
                Assets!.Add(itemData.ID, itemData);
            }
        }

        private static async Task FetchAllRuneData()
        {
            JArray allRunePages = (JArray)(await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/runesReforged.json"))!;

            foreach (JObject eachRunePage in allRunePages!.Cast<JObject>())
            {
                Asset runeData = new()
                {
                    Name = eachRunePage["name"]!.ToString(),
                    NameID = eachRunePage["key"]!.ToString(),
                    ID = eachRunePage["id"]!.ToObject<int>(),
                    AssetType = AssetType.Runes
                };

                Assets!.Add(runeData.ID, runeData);
                
                foreach (JObject eachRuneRow in eachRunePage["slots"]!.Cast<JObject>())
                {
                    foreach (JObject eachRuneSlot in eachRuneRow["runes"]!.Cast<JObject>())
                    {
                        runeData = new()
                        {
                            Name = eachRuneSlot["name"]!.ToString(),
                            NameID = eachRuneSlot["key"]!.ToString(),
                            ID = eachRuneSlot["id"]!.ToObject<int>(),
                            AssetType = AssetType.Runes
                        };

                        Assets.Add(runeData.ID, runeData);
                    }
                }
            }
        }

        private static async Task FetchSummonerSpellData()
        {
            // Grabs All SummonerSpell Data
            JObject allSummonerSpells = ((JObject)(await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/summoner.json"))!.SelectToken("data")!);


            // Parses the Summoner Spell Data into an Easily Accessible Dictionary of Relevant SummonerSpellData
            foreach (var eachSummonerSpell in allSummonerSpells!)
            {
                JObject eachSummonerSpellData = (JObject)eachSummonerSpell.Value!;

                Asset summonerSpellData = new()
                {
                    Name = eachSummonerSpellData["name"]!.ToString(),
                    NameID = eachSummonerSpellData["id"]!.ToString(),
                    ID = eachSummonerSpellData["key"]!.ToObject<int>(),
                    AssetType = AssetType.SummonerSpells
                };
                Assets!.Add(summonerSpellData.ID, summonerSpellData);
            }
        }

        private static bool GetCurrentVersion()
        {
            if (!File.Exists("CurrentVersion"))
            {
                File.WriteAllText("CurrentVersion", JsonConvert.SerializeObject(CurrentVersion));
                Directory.CreateDirectory("Data");
                Directory.CreateDirectory("Img");
                return false;
            }
            string currentDataVersion = JsonConvert.DeserializeObject<string>(File.ReadAllText("CurrentVersion"))!;
            if (currentDataVersion == CurrentVersion)
                return true;
            else
            File.WriteAllText("CurrentVersion", JsonConvert.SerializeObject(CurrentVersion));
            return false;
        }  
    }
}