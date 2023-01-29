using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms.VisualStyles;

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
                LoadGameData();
            }
            else
            {
                var task1 = FetchChampModeData();
                var task2 = FetchChampionData();
                var task3 = FetchItemData();
                var task4 = FetchAllRuneData();
                var task5 = FetchSummonerSpellData();

                await Task.WhenAll(task1, task2, task3, task4, task5);
            }
        }
        
        private static async Task FetchChampModeData()
        {
            // Grabs Last 7 Days of Ranked Data
            //ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all", forceDownload: true), RankedQueue.All.All);
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=top", forceDownload: true), RankedQueue.All.Top);
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=jungle", forceDownload: true), RankedQueue.All.Jungle);
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=mid", forceDownload: true), RankedQueue.All.Mid);
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=adc", forceDownload: true), RankedQueue.All.ADC);
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=support", forceDownload: true), RankedQueue.All.Support);

            // Grabs Last Month of Aram Games Data, Global
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/aram?period=month&tier=all", forceDownload: true), Aram);
        }
        
        private static async Task FetchChampionData()
        {
            // Grabs All Champion Data
            var champions = (await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/champion.json", Path.Combine("Data", "ChampionList"))).SelectToken("data");

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
        }

        private static async Task FetchItemData()
        {
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
        }

        private static async Task FetchAllRuneData()
        {
            var url = "https://www.op.gg/_next/data/2PwAMU3MRxsUxzv2L2VOU/champions/aatrox/top/runes.json?region=global&tier=platinum_plus&champion=aatrox&position=top";
            var jsonData = await WebRequests.GetJsonObject(url);

            var runeData = jsonData.SelectToken("pageProps").SelectToken("data").SelectToken("meta").SelectToken("runes");
            var runePageData = jsonData.SelectToken("pageProps").SelectToken("data").SelectToken("meta").SelectToken("runePages");
            var statModData = jsonData.SelectToken("pageProps").SelectToken("data").SelectToken("meta").SelectToken("statMods");

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
        }


        private static async Task FetchSummonerSpellData()
        {
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

        public static void SaveGameData()
        {
            var json = JsonConvert.SerializeObject(CurrentVersion);
            File.WriteAllText("CurrentVersion", json);

            string rootFolder = "Img";
            string[] subFolders = { "Splash", "Sprite", "Abilities", "Items", "Runes", "RunePages", "StatMods" };
            
            // Checks if Img Root Folder Exists, if not. Creates new Img Root Directory
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
            
            // Checks if Img\"SubFolders" Exists, if not. Creates new Directories Inside of the Img Root Folder
            foreach (string subFolder in subFolders)
            {
                string path = Path.Combine(rootFolder, subFolder);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }

            foreach (var champion in ChampionList)
            {
                champion.Value.SplashImage = null;
                champion.Value.SpriteImage = null;
                champion.Value.QAbility = null;
                champion.Value.WAbility = null;
                champion.Value.EAbility = null;
                champion.Value.RAbility = null;
            }
            
            json = JsonConvert.SerializeObject(ChampionList);
            File.WriteAllText("ChampionsList", json);

            foreach (var item in ItemsList)
            {
                item.Value.Image = null;
            }
            
            json = JsonConvert.SerializeObject(ItemsList);
            File.WriteAllText("Items", json);

            foreach (var rune in RunesList)
            {
                rune.Value.Image = null;
            }
            
            json = JsonConvert.SerializeObject(RunesList);
            File.WriteAllText("Runes", json);

            foreach (var runePage in RunePagesList)
            {
                runePage.Value.Image = null;
            }
            
            json = JsonConvert.SerializeObject(RunePagesList);
            File.WriteAllText("RunePages", json);

            foreach (var statMod in StatModsList)
            {
                statMod.Value.Image = null;
            }
            
            json = JsonConvert.SerializeObject(StatModsList);
            File.WriteAllText("StatMods", json);

            foreach (var summonerSpell in SummonerSpellsList)
            {
                summonerSpell.Value.Image = null;
            }

            json = JsonConvert.SerializeObject(SummonerSpellsList);
            File.WriteAllText("SummonerSpells", json);
        }

        private static bool GetCurrentVersion()
        {
            if (!File.Exists("CurrentVersion"))
                return false;
            string currentDataVersion = JsonConvert.DeserializeObject<string>(File.ReadAllText("CurrentVersion"));
            if (currentDataVersion == CurrentVersion)
                return true;
            else
                CurrentVersion = currentDataVersion;
            return false;
        }
        
        private static void LoadGameData()
        {
            string rootFolder = "Img";
            string[] subFolders = { "Splash", "Sprite", "Abilities", "Items", "Runes", "RunePages", "StatMods" };
            
            ChampionList = JsonConvert.DeserializeObject<Dictionary<int, ChampionData>>(File.ReadAllText("ChampionsList"));

            foreach (var champion in ChampionList)
            {
                var splashPath = Path.Combine(rootFolder, "Splash", champion.Value.NameID + ".jpg");
                if (File.Exists(splashPath))
                {
                    using (FileStream stream = new FileStream(splashPath, FileMode.Open, FileAccess.Read))
                    {
                        champion.Value.SplashImage = Image.FromStream(stream);
                    }
                }

                var spritePath = Path.Combine(rootFolder, "Sprite", champion.Value.NameID + ".jpg");
                if (File.Exists(spritePath))
                {
                    using (FileStream stream = new FileStream(spritePath, FileMode.Open, FileAccess.Read))
                    {
                        champion.Value.SpriteImage = Image.FromStream(stream);
                    }
                }

                var qAbilityPath = Path.Combine(rootFolder, "Abilities", champion.Value.NameID + "Q.jpg");
                if (File.Exists(qAbilityPath))
                {
                    using (FileStream stream = new FileStream(qAbilityPath, FileMode.Open, FileAccess.Read))
                    {
                        champion.Value.QAbility = Image.FromStream(stream);
                    }
                }

                var wAbilityPath = Path.Combine(rootFolder, "Abilities", champion.Value.NameID + "W.jpg");
                if (File.Exists(wAbilityPath))
                {
                    using (FileStream stream = new FileStream(wAbilityPath, FileMode.Open, FileAccess.Read))
                    {
                        champion.Value.WAbility = Image.FromStream(stream);
                    }
                }

                var eAbilityPath = Path.Combine(rootFolder, "Abilities", champion.Value.NameID + "E.jpg");
                if (File.Exists(eAbilityPath))
                {
                    using (FileStream stream = new FileStream(eAbilityPath, FileMode.Open, FileAccess.Read))
                    {
                        champion.Value.EAbility = Image.FromStream(stream);
                    }
                }
            }

            ItemsList = JsonConvert.DeserializeObject<Dictionary<int, Item>>(File.ReadAllText("Items"));

            foreach (var item in ItemsList)
            {
                if (File.Exists(Path.Combine(rootFolder, "Items", item.Value.ID + ".jpg")))
                    item.Value.Image = Image.FromFile(Path.Combine(rootFolder, "Items", item.Value.ID + ".jpg"));
            }
            
            RunesList = JsonConvert.DeserializeObject<Dictionary<int, Runes>>(File.ReadAllText("Runes"));

            foreach (var rune in RunesList)
            {
                if (File.Exists(Path.Combine(rootFolder, "Runes", rune.Value.ID + ".jpg")))
                    rune.Value.Image = Image.FromFile(Path.Combine(rootFolder, "Runes", rune.Value.ID + ".jpg"));
            }
            
            RunePagesList = JsonConvert.DeserializeObject<Dictionary<int, RunePages>>(File.ReadAllText("RunePages"));

            foreach (var runePage in RunePagesList)
            {
                if (File.Exists(Path.Combine(rootFolder, "RunePages", runePage.Value.ID + ".jpg")))
                    runePage.Value.Image = Image.FromFile(Path.Combine(rootFolder, "RunePages", runePage.Value.ID + ".jpg"));
            }
            
            StatModsList = JsonConvert.DeserializeObject<Dictionary<int, StatMods>>(File.ReadAllText("StatMods"));

            foreach (var statMod in StatModsList)
            {
                if (File.Exists(Path.Combine(rootFolder, "StatMods", statMod.Value.ID + ".jpg")))
                    statMod.Value.Image = Image.FromFile(Path.Combine(rootFolder, "StatMods", statMod.Value.ID + ".jpg"));
            }
            
            SummonerSpellsList = JsonConvert.DeserializeObject<Dictionary<int, SummonerSpells>>(File.ReadAllText("SummonerSpells"));

            foreach (var summonerSpell in SummonerSpellsList)
            {
                if (File.Exists(Path.Combine(rootFolder, "SummonerSpells", summonerSpell.Value.ID + ".jpg")))
                    summonerSpell.Value.Image = Image.FromFile(Path.Combine(rootFolder, "SummonerSpells", summonerSpell.Value.ID + ".jpg"));
            }
        }
    }
}