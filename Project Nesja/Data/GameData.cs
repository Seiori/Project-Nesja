using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Project_Nesja.Data
{
    public static class GameData
    {
        public static string? CurrentVersion { get; set; }
        public static Dictionary<int, ChampionData> ChampionList { get; set; }
        public static Dictionary<int, Asset> Assets { get; set; }

        static GameData()
        {
            CurrentVersion = "";
            ChampionList = new Dictionary<int, ChampionData>();
            Assets = new Dictionary<int, Asset>();
        }
        
        public static async Task FetchGameData()
        {
            // Grabs Current Live Patch Version
            CurrentVersion = (await WebRequests.GetJsonObject("https://ddragon.leagueoflegends.com/api/versions.json")).FirstOrDefault().ToString();

            if (GetCurrentVersion())
            {
                await LoadGameData();
            }
            else
            {
                await Task.WhenAll(
                    FetchChampionData(),
                    FetchItemData(),
                    FetchAllRuneData(),
                    FetchSummonerSpellData()
                );
                await SaveGameData();
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
                Asset ItemData = new()
                {
                    Name = item.First.ToString(),
                    ID = int.Parse(item.First.SelectToken("image").SelectToken("full").ToString().Split('.')[0]),
                    AssetType = "Items"
                };
                Assets.Add(ItemData.ID, ItemData);
            }
        }

        private static async Task FetchAllRuneData()
        {
            var allRuneData = await WebRequests.GetJsonObject("https://www.op.gg/_next/data/0gDq3PqZvdVUaHBVGp5wk/champions/aatrox/top/runes.json?region=global&tier=platinum_plus&champion=aatrox&position=top");

            var runeData = allRuneData.SelectToken("pageProps")?.SelectToken("data")?.SelectToken("meta")?.SelectToken("runes");
            var runePageData = allRuneData.SelectToken("pageProps")?.SelectToken("data")?.SelectToken("meta")?.SelectToken("runePages");
            var statModData = allRuneData.SelectToken("pageProps")?.SelectToken("data")?.SelectToken("meta")?.SelectToken("statMods");

            // Parses the Rune Data into an Easily Accessible Dictionary of Relevant RuneData
            foreach (var rune in runeData.Children())
            {
                Asset runes = new()
                {
                    Name = (string)rune.ElementAt(5),
                    NameID = (string)rune.ElementAt(4),
                    ID = (int)rune.First,
                    AssetType = "Runes"
                };
                Assets.Add(runes.ID, runes);
            }

            // Parses the Rune Page Data into an Easily Accessible Dictionary of Relevant RunePageData
            foreach (var runePage in runePageData.Children())
            {
                Asset runePages = new()
                {
                    Name = (string)runePage.ElementAt(1),
                    ID = (int)runePage.First,
                    AssetType = "RunePages"
                };
                Assets.Add(runePages.ID, runePages);
            }

            // Parses the Stat Mod Data into an Easily Accessible Dictionart of Relevant StatModData
            foreach (var statMod in statModData)
            {
                Asset statMods = new()
                {
                    Name = (string)statMod.ElementAt(1),
                    ID = (int)statMod.First,
                    AssetType = "StatMods"
                };
                Assets.Add(statMods.ID, statMods);
            }
        }

        private static async Task FetchSummonerSpellData()
        {
            // Grabs All SummonerSpell Data
            var summonerSpellData = (await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/summoner.json")).SelectToken("data");

            // Parses the Summoner Spell Data into an Easily Accessible Dictionary of Relevant SummonerSpellData
            foreach (var summonerSpell in summonerSpellData.Children())
            {
                Asset summonerSpells = new()
                {
                    Name = (string)summonerSpell.First.ElementAt(1),
                    NameID = (string)summonerSpell.First.First,
                    ID = (int)summonerSpell.First.ElementAt(13),
                    AssetType = "SummonerSpells"
                };
                Assets.Add(summonerSpells.ID, summonerSpells);
            }
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
            File.WriteAllText("CurrentVersion", JsonConvert.SerializeObject(CurrentVersion));
            return false;
        }
        
        private static Task SaveGameData()
        {
            foreach (var asset in Assets)
            {
                asset.Value.Image = null;
            }
            File.WriteAllText(Path.Combine("Data", "Assets"), JsonConvert.SerializeObject(Assets));

            return Task.CompletedTask;
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

            Assets = JsonConvert.DeserializeObject<Dictionary<int, Asset>>(File.ReadAllText(Path.Combine("Data", "Assets")));

            foreach (var asset in Assets)
            {
                if (File.Exists(Path.Combine(rootFolder, asset.Value.AssetType, asset.Value.ID + ".jpg")))
                    asset.Value.Image = Image.FromFile(Path.Combine(rootFolder, asset.Value.AssetType, asset.Value.ID + ".jpg"));
            }
            return Task.CompletedTask;
        }
    }
}