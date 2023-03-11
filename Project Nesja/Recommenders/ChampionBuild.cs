using Newtonsoft.Json.Linq;
using Project_Nesja;
using Project_Nesja.Data;
using System.Text.Json;

public class ChampionBuild
{
    private readonly ChampionData championData;
    public string role;
    public int TotalGames;
    public double Winrate;
    public double Pickrate;
    public double Banrate;
    public RunePage RunePageChoice;
    public ItemSet StartingItems;
    public ItemSet CoreItems;
    public List<Item> FourthItemChoice;
    public List<Item>  FifthItemChoice;
    public List<Item> SixthItemChoice;
    public SkillPriority SkillPriority;
    public SkillOrder SkillOrder;
    public SummonerSpells SummonerSpells;
    public List<ChampionRole> Matchups;

    public ChampionBuild(ChampionData championData, string role)
    {
        this.championData = championData;
        this.role = role;
        StartingItems = new ItemSet();
        CoreItems = new ItemSet();
        FourthItemChoice = new List<Item>(3);
        FifthItemChoice = new List<Item>(3);
        SixthItemChoice = new List<Item>(3);
        SkillPriority = new SkillPriority();
        SkillOrder = new SkillOrder();
        SummonerSpells = new SummonerSpells();
        Matchups = new List<ChampionRole>();
    }

    public async Task<ChampionBuild> FetchChampionBuild()
    {
        // Fetches all Relevant Champion Statistics in a Specific Role
        string apiUrl = $"https://axe.lolalytics.com/mega/?ep=champion&p=d&v=1&patch={GameData.CurrentVersion}&cid={championData.ID}&lane={role}&tier=platinum_plus&queue=420&region=all";
        string apiExtraUrl = $"https://axe.lolalytics.com/mega/?ep=champion2&p=d&v=1&patch={GameData.CurrentVersion}&cid={championData.ID}&lane={role}&tier=platinum_plus&queue=420&region=all";

        var tasks = new Task<JToken>[] {
            WebRequests.GetJsonObject(apiUrl)!,
            WebRequests.GetJsonObject(apiExtraUrl)!
        };

        JToken[] results = await Task.WhenAll(tasks);

        // Grabs the Specific Role from the JSON
        this.role = results[0].SelectToken("header")!.SelectToken("lane")!.ToString();
        
        // Parses all Relevant Data into Specific Categories for Comparison
        await Task.WhenAll(
            FetchChampionStats(results[0]),
            FetchRunes(results[0]),
            FetchSummonerSpells(results[0]),
            FetchStartingItems(results[1]),
            FetchCoreItems(results[1], results[0]),
            FetchFourthItemChoices(results[0]),
            FetchFifthItemChoices(results[0]),
            FetchSixthItemChoices(results[0]),
            FetchSkillOrder(results[0], results[1]),
            FetchMatchups(results[0])
        );

        // Fetches Image Information for All Relevant Build Assets
        await FetchImageAssetsAsync();

        return this;
    }

    private async Task FetchImageAssetsAsync()
    {
        // Grabs All Images in Parallel for Assets
        var tasks = new List<Task>();

        // Checks if Champion only Starts with One Item
        if (StartingItems.SecondItem != null)
        {
            tasks.Add(StartingItems.SecondItem.FetchAssetImage());
        }
        
        tasks.AddRange(new Task[]
        {
            StartingItems.FirstItem.FetchAssetImage(),
            CoreItems.FirstItem.FetchAssetImage(),
            CoreItems.SecondItem.FetchAssetImage(),
            CoreItems.ThirdItem.FetchAssetImage(),
            SummonerSpells.FirstSpellData.FetchAssetImage(),
            SummonerSpells.SecondSpellData.FetchAssetImage()
        });
        
        tasks.AddRange(FourthItemChoice.Select(c => c.ItemAsset.FetchAssetImage()));
        tasks.AddRange(FifthItemChoice.Select(c => c.ItemAsset.FetchAssetImage()));
        tasks.AddRange(SixthItemChoice.Select(c => c.ItemAsset.FetchAssetImage()));

        await Task.WhenAll(tasks).ConfigureAwait(false);
    }
    
    private Task FetchChampionStats(JToken buildData)
    {
        JObject statData = (JObject)buildData.SelectToken("header")!;
        
        Winrate = statData["wr"]!.ToObject<double>();
        Pickrate = statData["pr"]!.ToObject<double>();
        Banrate = statData["br"]!.ToObject<double>();

        return Task.CompletedTask;
    }

    private Task FetchRunes(JToken buildData)
    {
        JObject allRuneData = (JObject)buildData.SelectToken("runes")!.SelectToken("stats")!;

        List<Rune> primaryRunes = new();
        List<Rune> secondaryRunes = new();
        List<StatMod> firstRowStatMod = new(3);
        List<StatMod> secondRowStatMod = new(3);
        List<StatMod> thirdRowStatMod = new(3);
        
        Dictionary<string, double> runeWeights = new();

        int count = 0;

        foreach (var eachRuneData in allRuneData)
        {
            int id;

            if (eachRuneData.Key.EndsWith("f"))
                id = int.Parse(eachRuneData.Key.Replace("f", ""));
            else
                id = int.Parse(eachRuneData.Key);

            if (GameData.Assets.ContainsKey(id) && GameData.Assets.FirstOrDefault(x => x.Key == id).Value.AssetType == AssetType.Runes)
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
                    count += 1;
                    
                    Rune secondaryRuneData = new()
                    {
                        RuneAsset = GameData.Assets.GetValueOrDefault(int.Parse(eachRuneData.Key))!,
                        Winrate = eachRuneData.Value![1]![1]!.ToObject<float>(),
                        Pickrate = eachRuneData.Value![1]![0]!.ToObject<float>(),
                        TotalGames = eachRuneData.Value![1]![2]!.ToObject<int>()
                    };

                    switch (count)
                    {
                        case < 4:
                            primaryRuneData.RuneType = RuneType.FirstRow;
                            secondaryRuneData.RuneType = RuneType.FirstRow;
                            break;
                        case < 7:
                            primaryRuneData.RuneType = RuneType.SecondRow;
                            secondaryRuneData.RuneType = RuneType.SecondRow;
                            break;
                        case < 10:
                            primaryRuneData.RuneType = RuneType.ThirdRow;
                            secondaryRuneData.RuneType = RuneType.ThirdRow;
                            break;
                    }
                    secondaryRunes.Add(secondaryRuneData);
                }
                else
                {
                    primaryRuneData.RuneType = RuneType.Keystone;
                    count = 0;
                }

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
                    case "5002":
                    case "5003":
                        thirdRowStatMod.Add(statModData);
                        break;
                    case "5002f":
                    case "5003f":
                    case "5008f":
                        secondRowStatMod.Add(statModData);
                        break;
                    case "5005":
                    case "5007":
                    case "5008":
                        firstRowStatMod.Add(statModData);
                        break;
                }
            }
        }

        foreach (Rune runeData in primaryRunes.Concat(secondaryRunes))
        {
            double weight = runeData.Winrate * runeData.Pickrate;
            runeWeights[runeData.RuneAsset.Name] = weight;
        }

        primaryRunes.OrderByDescending(rune => runeWeights[rune.RuneAsset.Name]);
        secondaryRunes.OrderByDescending(rune => runeWeights[rune.RuneAsset.Name]);

        RunePageChoice.Keystone = primaryRunes.First(x => x.RuneType == RuneType.Keystone);
        RunePageChoice.PrimTreeFirstRow = primaryRunes.First(x => x.RuneType == RuneType.FirstRow);
        RunePageChoice.PrimTreeSecondRow = primaryRunes.First(x => x.RuneType == RuneType.SecondRow);
        RunePageChoice.PrimTreeThirdRow = primaryRunes.First(x => x.RuneType == RuneType.ThirdRow);
        RunePageChoice.SecTreeFirstOption = secondaryRunes.First();
        RunePageChoice.SecTreeSecondOption = secondaryRunes.First(x => x.RuneType != secondaryRunes.First().RuneType);

        return Task.CompletedTask;
    }

    private Task FetchSummonerSpells(JToken buildData)
    {
        List<SummonerSpells> summonerSpells = new ();

        JArray allSpellSets = (JArray)buildData.SelectToken("spells")!;

        foreach (JArray eachSpellSet in allSpellSets)
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
        float winRateWeight = 0.46f;
        float pickRateWeight = 1 - winRateWeight;
        
        SummonerSpells = summonerSpells.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).First();
        
        return Task.CompletedTask;
    }

    private Task FetchStartingItems(JToken buildDataExtra)
    {
        List<ItemSet> startSets = new();
        
        var startItemData = buildDataExtra.SelectToken("startSet");

        foreach (var startItem in startItemData ?? 0)
        {
            ItemSet startSet = new();
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
        StartingItems = startSets.OrderByDescending(x => x.TotalGames / (startSets.Sum(x => x.TotalGames))).First();
        
        return Task.CompletedTask;
    }

    private Task FetchCoreItems(JToken buildDataExtra, JToken buildData)
    {
        List<ItemSet> coreSets = new();
        
        var coreItemData = buildDataExtra.SelectToken("itemSets")!.SelectToken("itemBootSet3");

        foreach (var coreItem in coreItemData ?? 0)
        {
            ItemSet coreSet = new();
            string[] parts = coreItem.ToString().Split(new string[] { "\": [" }, StringSplitOptions.None);
            string itemName = parts[0].TrimStart('\"').TrimEnd('\"');
            parts = itemName.Split('_');

            coreSet.FirstItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
            coreSet.SecondItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[1])).Value;
            coreSet.ThirdItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[2])).Value;
            coreSet.Winrate = coreItem.First().Last().ToObject<float>() / coreItem.First().First().ToObject<float>();
            coreSet.Pickrate = coreItem.First().First().ToObject<float>() / buildData.SelectToken("header")!.SelectToken("n")!.ToObject<float>() * 100;
            coreSet.TotalGames = coreItem.First().First().ToObject<int>();

            coreSets.Add(coreSet);
        }
        CoreItems = coreSets.OrderByDescending(x => x.TotalGames / (coreSets.Sum(x => x.TotalGames))).First();

        return Task.CompletedTask;
    }
    
    private Task FetchFourthItemChoices(JToken buildData)
    {
        List<Item> fourthItemSets = new();

        var fourthItemData = buildData.SelectToken("item3");

        foreach (var fourthItem in fourthItemData ?? 0)
        {
            Item fourthItemSet = new();
            string[] parts = fourthItem.First().ToString().Split('_');

            fourthItemSet.ItemAsset = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
            fourthItemSet.Winrate = fourthItem.ElementAt(1).ToObject<float>() / 100;
            fourthItemSet.Pickrate = fourthItem.ElementAt(2).ToObject<float>() / 100;
            fourthItemSet.TotalGames = fourthItem.ElementAt(3).ToObject<int>();

            fourthItemSets.Add(fourthItemSet);
        }
        FourthItemChoice.AddRange(fourthItemSets.OrderByDescending(x => x.TotalGames / (fourthItemSets.Sum(x => x.TotalGames))).Take(3));

        return Task.CompletedTask;
    }
    
    private Task FetchFifthItemChoices(JToken buildData)
    {
        List<Item> fifthItemSets = new();

        var fifthItemData = buildData.SelectToken("item4");

        foreach (var fifthItem in fifthItemData ?? 0)
        {
            Item fifthItemSet = new();
            string[] parts = fifthItem.First().ToString().Split('_');

            fifthItemSet.ItemAsset = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
            fifthItemSet.Winrate = fifthItem.ElementAt(1).ToObject<float>() / 100;
            fifthItemSet.Pickrate = fifthItem.ElementAt(2).ToObject<float>() / 100;
            fifthItemSet.TotalGames = fifthItem.ElementAt(3).ToObject<int>();

            fifthItemSets.Add(fifthItemSet);
        }
        FifthItemChoice.AddRange(fifthItemSets.OrderByDescending(x => x.TotalGames / (fifthItemSets.Sum(x => x.TotalGames))).Take(3));

        return Task.CompletedTask;
    }

    private Task FetchSixthItemChoices(JToken buildData)
    {
        List<Item> sixthItemSets = new();

        var sixthItemData = buildData.SelectToken("item5");

        foreach (var sixthItem in sixthItemData ?? 0)
        {
            Item sixthItemSet = new();
            string[] parts = sixthItem.First().ToString().Split('_');

            sixthItemSet.ItemAsset = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
            sixthItemSet.Winrate = sixthItem.ElementAt(1).ToObject<float>() / 100;
            sixthItemSet.Pickrate = sixthItem.ElementAt(2).ToObject<float>() / 100;
            sixthItemSet.TotalGames = sixthItem.ElementAt(3).ToObject<int>();

            sixthItemSets.Add(sixthItemSet);
        }
        SixthItemChoice.AddRange(sixthItemSets.OrderByDescending(x => x.TotalGames / (sixthItemSets.Sum(x => x.TotalGames))).Take(3));

        return Task.CompletedTask;
    }

    private Task FetchSkillOrder(JToken buildData, JToken buildDataExtra)
    {
        List<SkillPriority> skillPrioritySets = new();

        var skillPriorityData = buildDataExtra.SelectToken("skills")!.SelectToken("skillOrder");

        foreach (var skillPrioritySet in skillPriorityData!)
        {
            SkillPriority skillPrioritySetData = new();
            skillPrioritySetData.Priority = skillPrioritySet.First().ToString();
            skillPrioritySetData.Winrate = skillPrioritySet.ElementAt(2).ToObject<float>() / skillPrioritySet.ElementAt(1).ToObject<float>() * 100;
            skillPrioritySetData.Pickrate = skillPrioritySet.ElementAt(1).ToObject<float>() / buildData.SelectToken("header")!.SelectToken("n")!.ToObject<float>() * 100;
            skillPrioritySetData.TotalGames = skillPrioritySet.ElementAt(1).ToObject<int>();

            skillPrioritySets.Add(skillPrioritySetData);
        }

        List<SkillOrder> skillOrderSets = new();

        var skillOrderData = buildDataExtra.SelectToken("skills")!.SelectToken("skill15");

        foreach (var skillOrderSet in skillOrderData!)
        {
            SkillOrder skillOrderSetData = new();
            skillOrderSetData.Order = skillOrderSet.First().ToString();
            skillOrderSetData.Winrate = skillOrderSet.ElementAt(2).ToObject<float>() / skillOrderSet.ElementAt(1).ToObject<float>() * 100;
            skillOrderSetData.Pickrate = skillOrderSet.ElementAt(1).ToObject<float>() / buildData.SelectToken("n")!.ToObject<float>() * 100;
            skillOrderSetData.TotalGames = skillOrderSet.ElementAt(1).ToObject<int>();

            skillOrderSets.Add(skillOrderSetData);
        }

        float winRateWeight = 0.4f;
        float pickRateWeight = 1 - winRateWeight;

        SkillPriority = skillPrioritySets.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).First();
        SkillOrder = skillOrderSets.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).First();

        return Task.CompletedTask;
    }

    private Task FetchMatchups(JToken buildData)
    {
        var allMatchupData = buildData.SelectToken("enemy_" + buildData.SelectToken("header")!.SelectToken("lane")!.ToString());

        foreach (var matchup in allMatchupData!)
        {
            ChampionRole matchupData = new()
            {
                ChampionData = GameData.ChampionList.FirstOrDefault(x => x.Value.ID == int.Parse((string)matchup.First()!)).Value,
                Winrate = matchup.ElementAt(3).ToObject<float>(),
                TotalGames = matchup.ElementAt(1).ToObject<int>(),
                Pickrate = matchup.ElementAt(1).ToObject<float>() / buildData.SelectToken("header")!.SelectToken("n")!.ToObject<float>() * 100
            };

            Matchups.Add(matchupData);
        }

        float winRateWeight = 0.4f;
        float pickRateWeight = 1 - winRateWeight;

        Matchups = Matchups.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).ToList();

        return Task.CompletedTask;
    }
}