using Newtonsoft.Json;
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
        
        public static async Task FetchGameData()
        {
            // Grabs Current Live Patch Version
            CurrentVersion = (await WebRequests.GetJsonObject("https://ddragon.leagueoflegends.com/api/versions.json")).FirstOrDefault().ToString();

            if (GetCurrentVersion())
            {
                await LoadGameData();
                await FetchChampModeData();
            }
            else
            {
                await Task.WhenAll(
                    FetchChampModeData(),
                    FetchChampionData(),
                    FetchItemData(),
                    FetchAllRuneData(),
                    FetchSummonerSpellData()
                );
            }
        }
        
        private static async Task FetchChampModeData()
        {
            await Task.WhenAll(
                FetchAllRankedData(),
                FetchTopRankedData(),
                FetchJungleRankedData(),
                FetchMidRankedData(),
                FetchAdcRankedData(),
                FetchSupportRankedData(),
                FetchAramData()
            );
        }
        
        private static async Task FetchAllRankedData()
        {
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all"), RankedQueue.All.All);
        }
        
        private static async Task FetchTopRankedData() {
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=top"), RankedQueue.All.Top);
        }

        private static async Task FetchJungleRankedData() {
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=jungle"), RankedQueue.All.Jungle);
        }

        private static async Task FetchMidRankedData() {
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=mid"), RankedQueue.All.Mid);
        }

        private static async Task FetchAdcRankedData() {
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=adc"), RankedQueue.All.ADC);
        }

        private static async Task FetchSupportRankedData() {
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=support"), RankedQueue.All.Support);
        }

        private static async Task FetchAramData() {
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/aram?period=month&tier=all"), Aram);
        }

        private static void ParseChampRoleData(JObject rankedData, Dictionary<int, ChampionRoleData> ChampRoleDataList)
        {
            foreach (var champion in rankedData.SelectToken("data"))
            {
                // Parses the relevant Data into the ChampionRoleData object and adds it to a Dictionary for that Role
                ChampionRoleData championRoleData = new()
                {
                    ChampionData = ChampionList.First(x => x.Key == champion.SelectToken("champion_id").ToObject<int>()).Value,
                    TotalGames = champion.SelectToken("play").ToObject<int>(),
                    GamesWon = champion.SelectToken("win").ToObject<int>(),
                    GamesLost = champion.SelectToken("lose").ToObject<int>(),
                    TotalKills = champion.SelectToken("kill").ToObject<int>(),
                    TotalDeaths = champion.SelectToken("death").ToObject<int>(),
                    TotalAssists = champion.SelectToken("assist").ToObject<int>(),
                    TotalCS = champion.SelectToken("cs").ToObject<int>(),
                    PickRate = champion.SelectToken("pick_rate").ToObject<float>()
                };
                // Calculates the Winrate
                championRoleData.WinRate = (float)championRoleData.GamesWon / (float)championRoleData.TotalGames;
                // Checks for Null value. This value is Null when looking at Aram Data
                int.TryParse(champion.SelectToken("neutral_cs")?.ToString(), out int neutralCS);
                championRoleData.TotalNeutralCS = neutralCS;

                // Checks for Null value. This value is Null when looking at Aram Data
                float.TryParse(champion.SelectToken("ban_rate")?.ToString(), out float banRate);
                championRoleData.BanRate = banRate;

                ChampRoleDataList.Add(championRoleData.ChampionData.ID, championRoleData);
            }
        }

        private static async Task FetchChampionData()
        {
            // Grabs All Champion Data
            var champions = (await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/champion.json")).SelectToken("data");

            // Parses the Champion Data into a Easily Accessible Dictionary of Relevant Data
            foreach (var champion in champions.Children())
            {
                ChampionData championData = new()
                {
                    Name = champion.First.SelectToken("name").ToString(),
                    Title = champion.First.SelectToken("title").ToString(),
                    NameID = champion.First.SelectToken("id").ToString(),
                    ID = (int)champion.First.SelectToken("key"),
                    Difficulty = (int)champion.First.SelectToken("info").Last()
                };
                ChampionList.Add(championData.ID, championData);
            }
            File.WriteAllText(Path.Combine("Data", "ChampionList"), JsonConvert.SerializeObject(ChampionList));
        }

        private static async Task FetchItemData()
        {
            // Grabs All Item Data
            var Items = (await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/item.json")).SelectToken("data");

            // Parses the Item Data into a Easily Accessible Dictionary of Relevant ItemData
            foreach (var item in Items.Children())
            {
                Item ItemData = new()
                {
                    Name = item.First.ToString(),
                    ID = int.Parse(item.First.SelectToken("image").SelectToken("full").ToString().Split('.')[0])
                };
                ItemsList.Add(ItemData.ID, ItemData);
            }

            File.WriteAllText(Path.Combine("Data", "Items"), JsonConvert.SerializeObject(ItemsList));
        }

        private static async Task FetchAllRuneData()
        {
            var allRuneData = await WebRequests.GetJsonObject("https://www.op.gg/_next/data/8R0-II0deUa4IPAQkgqQ5/champions/aatrox/top/runes.json?region=global&tier=platinum_plus&champion=aatrox&position=top");

            var runeData = allRuneData.SelectToken("pageProps")?.SelectToken("data")?.SelectToken("meta")?.SelectToken("runes");
            var runePageData = allRuneData.SelectToken("pageProps")?.SelectToken("data")?.SelectToken("meta")?.SelectToken("runePages");
            var statModData = allRuneData.SelectToken("pageProps")?.SelectToken("data")?.SelectToken("meta")?.SelectToken("statMods");

            // Parses the Rune Data into an Easily Accessible Dictionary of Relevant RuneData
            foreach (var rune in runeData.Children())
            {
                Runes runes = new()
                {
                    Name = (string)rune.ElementAt(5),
                    NameID = (string)rune.ElementAt(4),
                    ID = (int)rune.First
                };
                RunesList.Add(runes.ID, runes);
            }

            // Parses the Rune Page Data into an Easily Accessible Dictionary of Relevant RunePageData
            foreach (var runePage in runePageData.Children())
            {
                RunePages runePages = new()
                {
                    Name = (string)runePage.ElementAt(1),
                    ID = (int)runePage.First
                };
                RunePagesList.Add(runePages.ID, runePages);
            }

            // Parses the Stat Mod Data into an Easily Accessible Dictionart of Relevant StatModData
            foreach (var statMod in statModData)
            {
                StatMods statMods = new()
                {
                    Name = (string)statMod.ElementAt(1),
                    ID = (int)statMod.First
                };
                StatModsList.Add(statMods.ID, statMods);
            }

            File.WriteAllText(Path.Combine("Data", "Runes"), JsonConvert.SerializeObject(RunesList));
            File.WriteAllText(Path.Combine("Data", "RunePages"), JsonConvert.SerializeObject(RunePagesList));
            File.WriteAllText(Path.Combine("Data", "StatMods"), JsonConvert.SerializeObject(StatModsList));
        }

        private static async Task FetchSummonerSpellData()
        {
            // Grabs All SummonerSpell Data
            var summonerSpellData = (await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/summoner.json")).SelectToken("data");

            // Parses the Summoner Spell Data into an Easily Accessible Dictionary of Relevant SummonerSpellData
            foreach (var summonerSpell in summonerSpellData.Children())
            {
                SummonerSpells summonerSpells = new()
                {
                    Name = (string)summonerSpell.First.ElementAt(1),
                    NameID = (string)summonerSpell.First.First,
                    ID = (int)summonerSpell.First.ElementAt(13)
                };
                SummonerSpellsList.Add(summonerSpells.ID, summonerSpells);
            }
            File.WriteAllText(Path.Combine("Data", "SummonerSpells"), JsonConvert.SerializeObject(SummonerSpellsList));
        }

        private static bool GetCurrentVersion()
        {
            if (!File.Exists("CurrentVersion"))
            {
                File.WriteAllText("CurrentVersion", JsonConvert.SerializeObject(CurrentVersion));
                return false;
            }
            string currentDataVersion = JsonConvert.DeserializeObject<string>(File.ReadAllText("CurrentVersion"));
            if (currentDataVersion == CurrentVersion)
                return true;
            else
                CurrentVersion = currentDataVersion;
            return false;
        }
        
        private static Task LoadGameData()
        {
            string rootFolder = "Img";

            ChampionList = JsonConvert.DeserializeObject<Dictionary<int, ChampionData>>(File.ReadAllText(Path.Combine("Data", "ChampionList")));

            foreach (var champion in ChampionList)
            {
                var splashPath = Path.Combine(rootFolder, "Splash", champion.Value.NameID + ".jpg");
                if (File.Exists(splashPath))
                {
                    using FileStream stream = new(splashPath, FileMode.Open, FileAccess.Read);
                    champion.Value.SplashImage = Image.FromStream(stream);
                }

                var spritePath = Path.Combine(rootFolder, "Sprite", champion.Value.NameID + ".jpg");
                if (File.Exists(spritePath))
                {
                    using FileStream stream = new(spritePath, FileMode.Open, FileAccess.Read);
                    champion.Value.SpriteImage = Image.FromStream(stream);
                }

                var qAbilityPath = Path.Combine(rootFolder, "Abilities", champion.Value.NameID + "Q.jpg");
                if (File.Exists(qAbilityPath))
                {
                    using FileStream stream = new(qAbilityPath, FileMode.Open, FileAccess.Read);
                    champion.Value.QAbility = Image.FromStream(stream);
                }

                var wAbilityPath = Path.Combine(rootFolder, "Abilities", champion.Value.NameID + "W.jpg");
                if (File.Exists(wAbilityPath))
                {
                    using FileStream stream = new(wAbilityPath, FileMode.Open, FileAccess.Read);
                    champion.Value.WAbility = Image.FromStream(stream);
                }

                var eAbilityPath = Path.Combine(rootFolder, "Abilities", champion.Value.NameID + "E.jpg");
                if (File.Exists(eAbilityPath))
                {
                    using FileStream stream = new(eAbilityPath, FileMode.Open, FileAccess.Read);
                    champion.Value.EAbility = Image.FromStream(stream);
                }
            }

            ItemsList = JsonConvert.DeserializeObject<Dictionary<int, Item>>(File.ReadAllText(Path.Combine("Data", "Items")));

            foreach (var item in ItemsList)
            {
                if (File.Exists(Path.Combine(rootFolder, "Items", item.Value.ID + ".jpg")))
                    item.Value.Image = Image.FromFile(Path.Combine(rootFolder, "Items", item.Value.ID + ".jpg"));
            }
            
            RunesList = JsonConvert.DeserializeObject<Dictionary<int, Runes>>(File.ReadAllText(Path.Combine("Data", "Runes")));

            foreach (var rune in RunesList)
            {
                if (File.Exists(Path.Combine(rootFolder, "Runes", rune.Value.ID + ".jpg")))
                    rune.Value.Image = Image.FromFile(Path.Combine(rootFolder, "Runes", rune.Value.ID + ".jpg"));
            }
            
            RunePagesList = JsonConvert.DeserializeObject<Dictionary<int, RunePages>>(File.ReadAllText(Path.Combine("Data", "RunePages")));

            foreach (var runePage in RunePagesList)
            {
                if (File.Exists(Path.Combine(rootFolder, "RunePages", runePage.Value.ID + ".jpg")))
                    runePage.Value.Image = Image.FromFile(Path.Combine(rootFolder, "RunePages", runePage.Value.ID + ".jpg"));
            }
            
            StatModsList = JsonConvert.DeserializeObject<Dictionary<int, StatMods>>(File.ReadAllText(Path.Combine("Data", "StatMods")));

            foreach (var statMod in StatModsList)
            {
                if (File.Exists(Path.Combine(rootFolder, "StatMods", statMod.Value.ID + ".jpg")))
                    statMod.Value.Image = Image.FromFile(Path.Combine(rootFolder, "StatMods", statMod.Value.ID + ".jpg"));
            }
            
            SummonerSpellsList = JsonConvert.DeserializeObject<Dictionary<int, SummonerSpells>>(File.ReadAllText(Path.Combine("Data", "SummonerSpells")));

            foreach (var summonerSpell in SummonerSpellsList)
            {
                if (File.Exists(Path.Combine(rootFolder, "SummonerSpells", summonerSpell.Value.ID + ".jpg")))
                    summonerSpell.Value.Image = Image.FromFile(Path.Combine(rootFolder, "SummonerSpells", summonerSpell.Value.ID + ".jpg"));
            }

            return Task.CompletedTask;
        }
    }
}