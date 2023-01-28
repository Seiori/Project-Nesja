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

        public static async void FetchGameData()
        {
            // Grabs Current Live Patch Version
            CurrentVersion = (await WebRequests.GetJsonObject("https://ddragon.leagueoflegends.com/api/versions.json")).First.ToString();
            
            if (false)
            {
                LoadGameData();
            }
            else
            {
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

            // Grabs Last 7 Days of Ranked Data
            //ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all"), RankedQueue.All.All);
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=top"), RankedQueue.All.Top);
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=jungle"), RankedQueue.All.Jungle);
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=mid"), RankedQueue.All.Mid);
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=adc"), RankedQueue.All.ADC);
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=support"), RankedQueue.All.Support);

            // Grabs Last Month of Aram Games Data, Global
            ParseChampRoleData((JObject?)await WebRequests.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/aram?period=month&tier=all"), Aram);
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
                if (champion.Value != null && champion.Value.SplashImage != null)
                {
                    if (Directory.Exists(Path.Combine(rootFolder, "Splash")))
                    {
                        using (var image = (Image)champion.Value.SplashImage.Clone())
                        {
                            if (image != null) // check if the image is not null
                            {
                                using (var filestream = new FileStream(Path.Combine(rootFolder, "Splash", champion.Value.NameID + ".jpg"), FileMode.Create))
                                {
                                    image.Save(filestream, ImageFormat.Jpeg);
                                }
                            }
                        }
                    }
                }





                if (champion.Value.SpriteImage != null)
                {
                    using (var filestream = new FileStream(Path.Combine(rootFolder, "Sprite", champion.Value.NameID + ".jpg"), FileMode.Create))
                    {
                        champion.Value.SpriteImage.Save(filestream, ImageFormat.Jpeg);
                    }
                }

                if (champion.Value.QAbility != null)
                {
                    using (var filestream = new FileStream(Path.Combine(rootFolder, "Abilities", champion.Value.NameID + "Q.jpg"), FileMode.Create))
                    {
                        champion.Value.QAbility.Save(filestream, ImageFormat.Jpeg);
                    }
                }

                if (champion.Value.WAbility != null)
                {
                    using (var filestream = new FileStream(Path.Combine(rootFolder, "Abilities", champion.Value.NameID + "W.jpg"), FileMode.Create))
                    {
                        champion.Value.WAbility.Save(filestream, ImageFormat.Jpeg);
                    }
                }

                if (champion.Value.EAbility != null)
                {
                    using (var filestream = new FileStream(Path.Combine(rootFolder, "Abilities", champion.Value.NameID + "E.jpg"), FileMode.Create))
                    {
                        champion.Value.EAbility.Save(filestream, ImageFormat.Jpeg);
                    }
                }

                if (champion.Value.RAbility != null)
                {
                    using (var filestream = new FileStream(Path.Combine(rootFolder, "Abilities", champion.Value.NameID + "R.jpg"), FileMode.Create))
                    {
                        champion.Value.RAbility.Save(filestream, ImageFormat.Jpeg);
                    }
                }

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
                if (item.Value.Image != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(rootFolder, "Items", item.Value.ID + ".jpg"), FileMode.Create))
                    {
                        item.Value.Image.Save(fileStream, ImageFormat.Jpeg);
                    }
                    item.Value.Image = null;
                }
            }

            json = JsonConvert.SerializeObject(ItemsList);
            File.WriteAllText("ItemsList", json);

            foreach (var rune in RunesList)
            {
                if (rune.Value.Image != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(rootFolder, "Runes", rune.Value.ID + ".jpg"), FileMode.Create))
                    {
                        rune.Value.Image.Save(fileStream, ImageFormat.Jpeg);
                    }
                    rune.Value.Image = null;
                }
            }

            json = JsonConvert.SerializeObject(RunesList);
            File.WriteAllText("RunesList", json);

            foreach (var runePage in RunePagesList)
            {
                if (runePage.Value.Image != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(rootFolder, "RunePages", runePage.Value.ID + ".jpg"), FileMode.Create))
                    {
                        runePage.Value.Image.Save(fileStream, ImageFormat.Jpeg);
                    }
                    runePage.Value.Image = null;
                }
            }

            json = JsonConvert.SerializeObject(RunePagesList);
            File.WriteAllText("RunePagesList", json);

            foreach (var statMod in StatModsList)
            {
                if (statMod.Value.Image != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(rootFolder, "StatMods", statMod.Value.ID + ".jpg"), FileMode.Create))
                    {
                        statMod.Value.Image.Save(fileStream, ImageFormat.Jpeg);
                    }
                    statMod.Value.Image = null;
                }
            }

            json = JsonConvert.SerializeObject(StatModsList);
            File.WriteAllText("StatModsList", json);

            foreach (var summonerSpell in SummonerSpellsList)
            {
                if (summonerSpell.Value.Image != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(rootFolder, "SummonerSpells", summonerSpell.Value.ID + ".jpg"), FileMode.Create))
                    {
                        summonerSpell.Value.Image.Save(fileStream, ImageFormat.Jpeg);
                    }
                    summonerSpell.Value.Image = null;
                }
            }

            json = JsonConvert.SerializeObject(SummonerSpellsList);
            File.WriteAllText("SummonerSpellsList", json);
        }

        private static bool GetCurrentVersion()
        {
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

            ItemsList = JsonConvert.DeserializeObject<Dictionary<int, Item>>(File.ReadAllText("ItemsList"));

            foreach (var item in ItemsList)
            {
                if (File.Exists(Path.Combine(rootFolder, "Items", item.Value.ID + ".jpg")))
                    item.Value.Image = Image.FromFile(Path.Combine(rootFolder, "Items", item.Value.ID + ".jpg"));
            }
            
            RunesList = JsonConvert.DeserializeObject<Dictionary<int, Runes>>(File.ReadAllText("RunesList"));

            foreach (var rune in RunesList)
            {
                if (File.Exists(Path.Combine(rootFolder, "Runes", rune.Value.ID + ".jpg")))
                    rune.Value.Image = Image.FromFile(Path.Combine(rootFolder, "Runes", rune.Value.ID + ".jpg"));
            }
            
            RunePagesList = JsonConvert.DeserializeObject<Dictionary<int, RunePages>>(File.ReadAllText("RunePagesList"));

            foreach (var runePage in RunePagesList)
            {
                if (File.Exists(Path.Combine(rootFolder, "RunePages", runePage.Value.ID + ".jpg")))
                    runePage.Value.Image = Image.FromFile(Path.Combine(rootFolder, "RunePages", runePage.Value.ID + ".jpg"));
            }
            
            StatModsList = JsonConvert.DeserializeObject<Dictionary<int, StatMods>>(File.ReadAllText("StatModsList"));

            foreach (var statMod in StatModsList)
            {
                if (File.Exists(Path.Combine(rootFolder, "StatMods", statMod.Value.ID + ".jpg")))
                    statMod.Value.Image = Image.FromFile(Path.Combine(rootFolder, "StatMods", statMod.Value.ID + ".jpg"));
            }
            
            SummonerSpellsList = JsonConvert.DeserializeObject<Dictionary<int, SummonerSpells>>(File.ReadAllText("SummonerSpellsList"));

            foreach (var summonerSpell in SummonerSpellsList)
            {
                if (File.Exists(Path.Combine(rootFolder, "SummonerSpells", summonerSpell.Value.ID + ".jpg")))
                    summonerSpell.Value.Image = Image.FromFile(Path.Combine(rootFolder, "SummonerSpells", summonerSpell.Value.ID + ".jpg"));
            }
        }
    }
}