using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project_Nesja.Models;
using Project_Nesja.Services;
using Project_Nesja.Web;

public class ChampionBuild
{
    private readonly Champion championData;
    private ChampionRankedData championRankedData;
    public string role;
    public int TotalGames;
    public double Winrate;
    public double Pickrate;
    public double Banrate;
    public RunePage RunePageChoice;
    public ItemGroup StartingItems;
    public ItemGroup CoreItems;
    public List<Item> FourthItemChoice;
    public List<Item>  FifthItemChoice;
    public List<Item> SixthItemChoice;
    public SkillPriority SkillPriority;
    public SummonerSpells SummonerSpells;
    public List<ChampionRole> Matchups;
    private float winrateWeight;
    private float pickrateWeight;

    public ChampionBuild(Champion championData, string role = "")
    {
        this.championData = championData;
        championRankedData = new();
        this.role = role;
        RunePageChoice = new();
        StartingItems = new();
        CoreItems = new();
        FourthItemChoice = new(3);
        FifthItemChoice = new(3);
        SixthItemChoice = new(3);
        SkillPriority = new();
        SummonerSpells = new();
        Matchups = new();
        winrateWeight = 0.6f;
        pickrateWeight = 1 - winrateWeight;
    }

    public async Task<ChampionBuild> FetchChampionBuild()
    {
        // Fetches all Relevant Champion Statistics in a Specific Role
        string apiUrl = $"https://ax.lolalytics.com/mega/?ep=champion&p=d&v=1&patch={GameData.CurrentVersion}&cid={championData.ID}&lane={role}&tier=platinum_plus&queue=420&region=all";

        championRankedData = JsonConvert.DeserializeObject<ChampionRankedData>((await WebRequests.GetJsonObject(apiUrl))!.ToString())!;

        // Grabs the Specific Role from the JSON
        role = championRankedData.Header!.Values().ElementAt(2).ToString();
        
        // Parses all Relevant Data into Specific Categories for Comparison
        await Task.WhenAll(
            FetchChampionStats(),
            FetchRunes(),
            FetchSummonerSpells(),
            FetchStartingItems(),
            FetchCoreItems(),
            FetchFourthItemChoices(),
            FetchFifthItemChoices(),
            FetchSixthItemChoices(),
            FetchSkillOrder(),
            FetchMatchups()
        );

        // Fetches Image Information for All Relevant Build Assets
        _ = FetchImageAssetsAsync();

        return this;
    }

    private async Task FetchImageAssetsAsync()
    {
        // Grabs All Images in Parallel for Assets
        var tasks = new List<Task>();

        // Checks if Champion only Starts with One Item
        if (StartingItems.SecondItem != null)
            tasks.Add(StartingItems.SecondItem.FetchAssetImage());
        
        tasks.AddRange(new Task[]
        {
            RunePageChoice.Keystone!.RuneAsset!.FetchAssetImage(),
            RunePageChoice.PrimTreeFirstRow!.RuneAsset!.FetchAssetImage(),
            RunePageChoice.PrimTreeSecondRow!.RuneAsset!.FetchAssetImage(),
            RunePageChoice.PrimTreeThirdRow!.RuneAsset!.FetchAssetImage(),
            RunePageChoice.SecTreeFirstOption!.RuneAsset!.FetchAssetImage(),
            RunePageChoice.SecTreeSecondOption!.RuneAsset!.FetchAssetImage(),
            RunePageChoice.firstRowOption!.StatModAsset!.FetchAssetImage(),
            RunePageChoice.secondRowOption!.StatModAsset!.FetchAssetImage(),
            RunePageChoice.thirdRowOption!.StatModAsset!.FetchAssetImage(),
            StartingItems.FirstItem!.FetchAssetImage(),
            CoreItems.FirstItem!.FetchAssetImage(),
            CoreItems.SecondItem!.FetchAssetImage(),
            CoreItems.ThirdItem!.FetchAssetImage(),
            SummonerSpells.FirstSpellData!.FetchAssetImage(),
            SummonerSpells.SecondSpellData!.FetchAssetImage()

        });

        tasks.AddRange(FourthItemChoice.Select(c => c.ItemAsset!.FetchAssetImage()));
        tasks.AddRange(FifthItemChoice.Select(c => c.ItemAsset!.FetchAssetImage()));
        tasks.AddRange(SixthItemChoice.Select(c => c.ItemAsset!.FetchAssetImage()));

        await Task.WhenAll(tasks);
    }
    
    private Task FetchChampionStats()
    {
        JObject statData = championRankedData.Header!;
        
        Winrate = statData["wr"]!.ToObject<double>();
        Pickrate = statData["pr"]!.ToObject<double>();
        Banrate = statData["br"]!.ToObject<double>();
        TotalGames = statData["n"]!.ToObject<int>();

        return Task.CompletedTask;
    }

    private Task FetchRunes()
    {
        JObject allRuneData = (JObject)championRankedData.Runes!.Values().First();

        List<Rune> primaryRunes = new();
        List<Rune> secondaryRunes = new();
        List<StatMod> firstRowStatMod = new(3);
        List<StatMod> secondRowStatMod = new(3);
        List<StatMod> thirdRowStatMod = new(3);
        int runeTreeIndex = 0;
        int runeRowIndex = 0;
        RuneTree runeTree = RuneTree.Precision;

        foreach (var eachRuneData in allRuneData)
        {
            int id;

            // REMOVE THE LETTER F FROM ID
            if (eachRuneData.Key.EndsWith("f"))
                id = int.Parse(eachRuneData.Key.Replace("f", ""));
            else
                id = int.Parse(eachRuneData.Key);

            // CHECKS TO MAKE SURE RUNE IS VALID AND NOT A STATMOD VALUE
            if (GameData.Assets!.ContainsKey(id) && GameData.Assets.FirstOrDefault(x => x.Key == id).Value.AssetType == AssetType.Runes)
            {
                Rune primaryRuneData = new()
                {
                    RuneAsset = GameData.Assets.GetValueOrDefault(int.Parse(eachRuneData.Key))!,
                    Winrate = eachRuneData.Value![0]![1]!.ToObject<float>(),
                    Pickrate = eachRuneData.Value![0]![0]!.ToObject<float>(),
                    TotalGames = eachRuneData.Value![0]![2]!.ToObject<int>()
                };

                if (eachRuneData.Value!.Count() > 1)
                {
                    runeRowIndex++;

                    Rune secondaryRuneData = new()
                    {
                        RuneAsset = GameData.Assets.GetValueOrDefault(int.Parse(eachRuneData.Key))!,
                        Winrate = eachRuneData.Value![1]![1]!.ToObject<float>(),
                        Pickrate = eachRuneData.Value![1]![0]!.ToObject<float>(),
                        TotalGames = eachRuneData.Value![1]![2]!.ToObject<int>()
                    };

                    switch (runeTreeIndex)
                    {
                        case 0:
                            primaryRuneData.RuneTree = RuneTree.Precision;
                            secondaryRuneData.RuneTree = RuneTree.Precision;
                            switch (runeRowIndex)
                            {
                                case >= 1 and <= 3:
                                    primaryRuneData.RuneType = RuneType.FirstRow;
                                    secondaryRuneData.RuneType = RuneType.FirstRow;
                                    break;
                                case >= 4 and <= 6:
                                    primaryRuneData.RuneType = RuneType.SecondRow;
                                    secondaryRuneData.RuneType = RuneType.SecondRow;
                                    break;
                                case >= 7 and <= 8:
                                    primaryRuneData.RuneType = RuneType.ThirdRow;
                                    secondaryRuneData.RuneType = RuneType.ThirdRow;
                                    break;
                                case 9:
                                    primaryRuneData.RuneType = RuneType.ThirdRow;
                                    secondaryRuneData.RuneType = RuneType.ThirdRow;
                                    runeRowIndex = 0;
                                    runeTreeIndex++;
                                    runeTree++;
                                    break;
                            }

                            break;
                        case 1:
                            primaryRuneData.RuneTree = RuneTree.Domination;
                            secondaryRuneData.RuneTree = RuneTree.Domination;
                            switch (runeRowIndex)
                            {
                                case >= 1 and <= 3:
                                    primaryRuneData.RuneType = RuneType.FirstRow;
                                    secondaryRuneData.RuneType = RuneType.FirstRow;
                                    break;
                                case >= 4 and <= 6:
                                    primaryRuneData.RuneType = RuneType.SecondRow;
                                    secondaryRuneData.RuneType = RuneType.SecondRow;
                                    break;
                                case >= 7 and <= 9:
                                    primaryRuneData.RuneType = RuneType.ThirdRow;
                                    secondaryRuneData.RuneType = RuneType.ThirdRow;
                                    break;
                                case 10:
                                    primaryRuneData.RuneType = RuneType.ThirdRow;
                                    secondaryRuneData.RuneType = RuneType.ThirdRow;
                                    runeRowIndex = 0;
                                    runeTreeIndex++;
                                    runeTree++;
                                    break;
                            }
                            break;
                        case 2:
                            primaryRuneData.RuneTree = RuneTree.Sorcery;
                            secondaryRuneData.RuneTree = RuneTree.Sorcery;
                            switch (runeRowIndex)
                            {
                                case >= 1 and <= 3:
                                    primaryRuneData.RuneType = RuneType.FirstRow;
                                    secondaryRuneData.RuneType = RuneType.FirstRow;
                                    break;
                                case >= 4 and <= 6:
                                    primaryRuneData.RuneType = RuneType.SecondRow;
                                    secondaryRuneData.RuneType = RuneType.SecondRow;
                                    break;
                                case >= 7 and <= 8:
                                    primaryRuneData.RuneType = RuneType.ThirdRow;
                                    secondaryRuneData.RuneType = RuneType.ThirdRow;
                                    break;
                                case 9:
                                    primaryRuneData.RuneType = RuneType.ThirdRow;
                                    secondaryRuneData.RuneType = RuneType.ThirdRow;
                                    runeRowIndex = 0;
                                    runeTreeIndex++;
                                    runeTree++;
                                    break;
                            }
                            break;
                        case 3:
                            primaryRuneData.RuneTree = RuneTree.Resolve;
                            secondaryRuneData.RuneTree = RuneTree.Resolve;
                            switch (runeRowIndex)
                            {
                                case >= 1 and <= 3:
                                    primaryRuneData.RuneType = RuneType.FirstRow;
                                    secondaryRuneData.RuneType = RuneType.FirstRow;
                                    break;
                                case >= 4 and <= 6:
                                    primaryRuneData.RuneType = RuneType.SecondRow;
                                    secondaryRuneData.RuneType = RuneType.SecondRow;
                                    break;
                                case >= 7 and <= 8:
                                    primaryRuneData.RuneType = RuneType.ThirdRow;
                                    secondaryRuneData.RuneType = RuneType.ThirdRow;
                                    break;
                                case 9:
                                    primaryRuneData.RuneType = RuneType.ThirdRow;
                                    secondaryRuneData.RuneType = RuneType.ThirdRow;
                                    runeRowIndex = 0;
                                    runeTreeIndex++;
                                    runeTree++;
                                    break;
                            }
                            break;
                        case 4:
                            primaryRuneData.RuneTree = RuneTree.Inspiration;
                            secondaryRuneData.RuneTree = RuneTree.Inspiration;
                            switch (runeRowIndex)
                            {
                                case >= 1 and <= 3:
                                    primaryRuneData.RuneType = RuneType.FirstRow;
                                    secondaryRuneData.RuneType = RuneType.FirstRow;
                                    break;
                                case >= 4 and <= 6:
                                    primaryRuneData.RuneType = RuneType.SecondRow;
                                    secondaryRuneData.RuneType = RuneType.SecondRow;
                                    break;
                                case >= 7 and <= 8:
                                    primaryRuneData.RuneType = RuneType.ThirdRow;
                                    secondaryRuneData.RuneType = RuneType.ThirdRow;
                                    break;
                                case 9:
                                    primaryRuneData.RuneType = RuneType.ThirdRow;
                                    secondaryRuneData.RuneType = RuneType.ThirdRow;
                                    runeRowIndex = 0;
                                    runeTreeIndex++;
                                    break;
                            }
                            break;
                    }

                    secondaryRunes.Add(secondaryRuneData);
                }
                else
                    primaryRuneData.RuneTree = runeTree;
                primaryRunes.Add(primaryRuneData); 
            }
            else
            {  
                if (!GameData.Assets.ContainsKey(id))
                {
                    GameData.Assets.Add(id, new Asset());
                    GameData.Assets[id].ID = id;
                    GameData.Assets[id].AssetType = AssetType.StatMods;
                }

                StatMod statModData = new()
                {
                    StatModAsset = GameData.Assets[id],
                    Winrate = eachRuneData.Value![0]![1]!.ToObject<float>(),
                    Pickrate = eachRuneData.Value![0]![0]!.ToObject<float>(),
                    TotalGames = eachRuneData.Value![0]![2]!.ToObject<int>()
                };

                switch (eachRuneData.Key)
                {
                    case "5001":
                        statModData.StatModType = StatModType.Health;
                        thirdRowStatMod.Add(statModData);
                        break;
                    case "5002":
                        statModData.StatModType = StatModType.Armor;
                        thirdRowStatMod.Add(statModData);
                        break;
                    case "5003":
                        statModData.StatModType = StatModType.MagicResistance;
                        thirdRowStatMod.Add(statModData);
                        break;
                    case "5002f":
                        statModData.StatModType = StatModType.Armor;
                        secondRowStatMod.Add(statModData);
                        break;
                    case "5003f":
                        statModData.StatModType = StatModType.MagicResistance;
                        secondRowStatMod.Add(statModData);
                        break;
                    case "5008f":
                        statModData.StatModType = StatModType.AdaptiveForce;
                        secondRowStatMod.Add(statModData);
                        break;
                    case "5005":
                        statModData.StatModType = StatModType.AttackSpeed;
                        firstRowStatMod.Add(statModData);
                        break;
                    case "5007":
                        statModData.StatModType = StatModType.AbilityHaste;
                        firstRowStatMod.Add(statModData);
                        break;
                    case "5008":
                        statModData.StatModType = StatModType.AdaptiveForce;
                        firstRowStatMod.Add(statModData);
                        break;
                }
            }
        }
        primaryRunes = primaryRunes.Where(x => x.Pickrate > 0.3).OrderByDescending(x => x.Winrate * winrateWeight + x.Pickrate * pickrateWeight).ToList();
        secondaryRunes = secondaryRunes.Where(x => x.Pickrate > 0.3).OrderByDescending(x => x.Winrate * winrateWeight + x.Pickrate * pickrateWeight).ToList();

        RunePageChoice.Keystone = primaryRunes.First(x => x.RuneType == RuneType.Keystone);
        RunePageChoice.PrimTreeFirstRow = primaryRunes.First(x => x.RuneType == RuneType.FirstRow && x.RuneTree == RunePageChoice.Keystone.RuneTree);
        RunePageChoice.PrimTreeSecondRow = primaryRunes.First(x => x.RuneType == RuneType.SecondRow && x.RuneTree == RunePageChoice.Keystone.RuneTree);
        RunePageChoice.PrimTreeThirdRow = primaryRunes.First(x => x.RuneType == RuneType.ThirdRow && x.RuneTree == RunePageChoice.Keystone.RuneTree);
        RunePageChoice.SecTreeFirstOption = secondaryRunes.First(x => x.RuneTree != RunePageChoice.Keystone.RuneTree);
        RunePageChoice.SecTreeSecondOption = secondaryRunes.First(x => x.RuneTree == RunePageChoice.SecTreeFirstOption.RuneTree && x.RuneType != RunePageChoice.SecTreeFirstOption.RuneType);
        RunePageChoice.firstRowOption = firstRowStatMod.OrderByDescending(x => x.TotalGames).First();
        RunePageChoice.secondRowOption = secondRowStatMod.OrderByDescending(x => x.TotalGames).First();
        RunePageChoice.thirdRowOption = thirdRowStatMod.OrderByDescending(x => x.TotalGames).First();
        RunePageChoice.Winrate = (RunePageChoice.Keystone.Winrate + RunePageChoice.PrimTreeFirstRow.Winrate + RunePageChoice.Winrate + RunePageChoice.PrimTreeSecondRow.Winrate + RunePageChoice.PrimTreeThirdRow.Winrate + RunePageChoice.SecTreeFirstOption.Winrate + RunePageChoice.SecTreeSecondOption.Winrate) / 6;
        RunePageChoice.TotalGames = (RunePageChoice.Keystone.TotalGames + RunePageChoice.PrimTreeFirstRow.TotalGames + RunePageChoice.PrimTreeSecondRow.TotalGames + RunePageChoice.PrimTreeThirdRow.TotalGames + RunePageChoice.SecTreeFirstOption.TotalGames + RunePageChoice.SecTreeSecondOption.TotalGames) / 6;
        return Task.CompletedTask;
    }

    private Task FetchSummonerSpells()
    {
        List<SummonerSpells> summonerSpells = new ();

        var allSpellSets = championRankedData.Spells;

        foreach (var eachSpellSet in allSpellSets!)
        {
            string[] spellIds = eachSpellSet[0]!.ToString().Split('_');
            
            SummonerSpells spellSet = new()
            {
                FirstSpellData = GameData.Assets.GetValueOrDefault(int.Parse(spellIds[0]))!,
                SecondSpellData = GameData.Assets.GetValueOrDefault(int.Parse(spellIds[1]))!,
                Winrate = eachSpellSet[1]!.ToObject<float>(),
                Pickrate = eachSpellSet[2]!.ToObject<float>(),
                TotalGames = eachSpellSet[3]!.ToObject<int>()
            };
            summonerSpells.Add(spellSet);
        }
        SummonerSpells = summonerSpells.Where(x => x.Pickrate > 0.3).ToList()
            .OrderByDescending(x => x.Winrate * winrateWeight + (x.TotalGames / summonerSpells.Sum(x => x.TotalGames)) * pickrateWeight)
            .First();
        
        return Task.CompletedTask;
    }

    private Task FetchStartingItems()
    {
        List<ItemGroup> startSets = new();
        
        var startItemData = championRankedData.StartSet;

        foreach (var startItem in startItemData!)
        {
            ItemGroup startSet = new();
            string[] parts = startItem.First().ToString().Split(new string[] { "\": [" }, StringSplitOptions.None);
            string itemName = parts[0].TrimStart('\"').TrimEnd('\"');
            parts = itemName.Split('_');

            if (!string.IsNullOrEmpty(parts[0]))
                startSet.FirstItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
            if (parts.Length > 1)
                startSet.SecondItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[1])).Value;
            startSet.Winrate = startItem.ElementAt(1).ToObject<float>() / 100;
            startSet.Pickrate = startItem.ElementAt(2).ToObject<float>() / 100;
            startSet.TotalGames = startItem.Last().ToObject<int>();

            startSets.Add(startSet);
        }
        StartingItems = startSets.Where(x => (x.TotalGames / startSets.Sum(x => x.TotalGames)) > 0.03).ToList()
            .OrderByDescending(x => x.Winrate * winrateWeight).ToList()
            .First();

        return Task.CompletedTask;
    }

    private Task FetchCoreItems()
    {
        List<ItemGroup> coreSets = new();
        
        var coreItemData = championRankedData.ItemSets!.Values().Last();

        foreach (var coreItem in coreItemData ?? 0)
        {
            ItemGroup coreSet = new();
            string[] parts = coreItem.ToString().Split(new string[] { "\": [" }, StringSplitOptions.None);
            string itemName = parts[0].TrimStart('\"').TrimEnd('\"');
            parts = itemName.Split('_');

            coreSet.FirstItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
            coreSet.SecondItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[1])).Value;
            coreSet.ThirdItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[2])).Value;
            coreSet.Winrate = coreItem.First().Last().ToObject<float>() / coreItem.First().First().ToObject<float>();
            coreSet.Pickrate = coreItem.First().First().ToObject<float>() / championRankedData.N * 100;
            coreSet.TotalGames = coreItem.First().First().ToObject<int>();

            coreSets.Add(coreSet);
        }
        CoreItems = coreSets.Where(x => (x.TotalGames / coreSets.Sum(x => x.TotalGames)) > 0.02).ToList()
            .OrderByDescending(x => (x.TotalGames / coreSets.Sum(x => x.TotalGames) * pickrateWeight + x.Winrate * winrateWeight)).ToList()
            .First();

        return Task.CompletedTask;
    }
    
    private Task FetchFourthItemChoices()
    {
        List<Item> fourthItemSets = new();

        var fourthItemData = championRankedData.Item3;

        foreach (var fourthItem in fourthItemData!)
        {
            Item fourthItemSet = new();
            string[] parts = fourthItem.First().ToString().Split('_');

            fourthItemSet.ItemAsset = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
            fourthItemSet.Winrate = fourthItem.ElementAt(1).ToObject<float>() / 100;
            fourthItemSet.Pickrate = fourthItem.ElementAt(2).ToObject<float>() / 100;
            fourthItemSet.TotalGames = fourthItem.ElementAt(3).ToObject<int>();

            fourthItemSets.Add(fourthItemSet);
        }
        FourthItemChoice.AddRange(fourthItemSets.OrderByDescending(x => x.TotalGames / fourthItemSets.Sum(x => x.TotalGames)).Take(3));

        return Task.CompletedTask;
    }
    
    private Task FetchFifthItemChoices()
    {
        List<Item> fifthItemSets = new();

        var fifthItemData = championRankedData.Item4;

        foreach (var fifthItem in fifthItemData!)
        {
            Item fifthItemSet = new();
            string[] parts = fifthItem.First().ToString().Split('_');

            fifthItemSet.ItemAsset = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
            fifthItemSet.Winrate = fifthItem.ElementAt(1).ToObject<float>() / 100;
            fifthItemSet.Pickrate = fifthItem.ElementAt(2).ToObject<float>() / 100;
            fifthItemSet.TotalGames = fifthItem.ElementAt(3).ToObject<int>();

            fifthItemSets.Add(fifthItemSet);
        }
        FifthItemChoice.AddRange(fifthItemSets.OrderByDescending(x => x.TotalGames / fifthItemSets.Sum(x => x.TotalGames)).Take(3));

        return Task.CompletedTask;
    }

    private Task FetchSixthItemChoices()
    {
        List<Item> sixthItemSets = new();

        var sixthItemData = championRankedData.Item5;

        if (sixthItemData == null)
            return Task.CompletedTask;

        foreach (var sixthItem in sixthItemData!)
        {
            Item sixthItemSet = new();
            string[] parts = sixthItem.First().ToString().Split('_');

            sixthItemSet.ItemAsset = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
            sixthItemSet.Winrate = sixthItem.ElementAt(1).ToObject<float>() / 100;
            sixthItemSet.Pickrate = sixthItem.ElementAt(2).ToObject<float>() / 100;
            sixthItemSet.TotalGames = sixthItem.ElementAt(3).ToObject<int>();

            sixthItemSets.Add(sixthItemSet);
        }
        SixthItemChoice.AddRange(sixthItemSets.OrderByDescending(x => x.TotalGames / sixthItemSets.Sum(x => x.TotalGames)).Take(3));

        return Task.CompletedTask;
    }

    private Task FetchSkillOrder()
    {
        List<SkillPriority> skillPrioritySets = new();

        var skillPriorityData = championRankedData.Skills!.Values().Last();

        foreach (var skillPrioritySet in skillPriorityData!)
        {
            SkillPriority skillPrioritySetData = new()
            {
                Priority = skillPrioritySet.First().ToString(),
                Winrate = skillPrioritySet.ElementAt(2).ToObject<float>() / skillPrioritySet.ElementAt(1).ToObject<float>() * 100,
                Pickrate = skillPrioritySet.ElementAt(1).ToObject<float>() / championRankedData.N * 100,
                TotalGames = skillPrioritySet.ElementAt(1).ToObject<int>()
            };

            skillPrioritySets.Add(skillPrioritySetData);
        }
        SkillPriority = skillPrioritySets.OrderByDescending(x => x.Winrate * winrateWeight + (x.TotalGames / skillPrioritySets.Sum(x => x.TotalGames)) * pickrateWeight).First();

        return Task.CompletedTask;
    }

    private Task FetchMatchups()
    {
        // Grabs the Relevant Matchup Data, and Parses it into a List of ChampionRole Objects
        var allMatchupData = championRankedData.GetOppositeRole(role)!;

        foreach (var matchup in allMatchupData)
        {
            ChampionRole matchupData = new()
            {
                ChampionData = GameData.ChampionList.FirstOrDefault(x => x.Value.ID == int.Parse((string)matchup.First()!)).Value,
                Winrate = 100 - matchup.ElementAt(3).ToObject<float>(),
                TotalGames = matchup.ElementAt(1).ToObject<int>(),
                Pickrate = matchup.ElementAt(1).ToObject<float>() / championRankedData.N * 100
            };

            Matchups.Add(matchupData);
        }

        // Filters out the Matchups of Pickrate < 0.2%, and then Orders by Winrate Weight and Pickrate Weight
        Matchups = Matchups.Where(x => x.Pickrate > 0.2)
            .OrderByDescending(x => x.Winrate * winrateWeight + (x.TotalGames / Matchups.Sum(x => x.TotalGames)) * pickrateWeight).ToList();

        return Task.CompletedTask;
    }
}