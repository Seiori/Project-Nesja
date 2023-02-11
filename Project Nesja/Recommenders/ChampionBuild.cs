using Newtonsoft.Json.Linq;
using Project_Nesja;
using Project_Nesja.Data;

public class ChampionBuild
{
    private readonly ChampionData championData;
    public string role;
    public int TotalGames;
    public double Winrate;
    public double Pickrate;
    public double Banrate;
    public int[] Runes { get; set; }
    public StartingItems StartingItems { get; set; }
    public CoreItems CoreItems { get; set; }
    public List<Item> FourthItemChoice { get; set; }
    public List<Item>  FifthItemChoice { get; set; }
    public List<Item> SixthItemChoice { get; set; }
    public SkillPriority SkillPriority { get; set; }
    public SkillOrder SkillOrder { get; set; }
    public SummonerSpells SummonerSpells { get; set; }
    public List<ChampionRole> Matchups { get; set; }

    public ChampionBuild(ChampionData championData, string role)
    {
        this.championData = championData;
        this.role = role;
        Runes = new int[6];
        StartingItems = new StartingItems();
        CoreItems = new CoreItems();
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
        JToken buildData = await WebRequests.GetJsonObject("https://axe.lolalytics.com/mega/?ep=champion&p=d&v=1&patch=" + GameData.CurrentVersion + "&cid=" + championData.ID + "&lane=" + role + "&tier=platinum_plus&queue=420&region=all");
        JToken buildDataExtra = await WebRequests.GetJsonObject("https://axe.lolalytics.com/mega/?ep=champion2&p=d&v=1&patch=" + GameData.CurrentVersion + "&cid=" + championData.ID + "&lane=" + role + "&tier=platinum_plus&queue=420&region=all");

        role = buildData.SelectToken("header").SelectToken("lane").ToString();
        FetchChampionStats(buildData);
        FetchRunes(buildData);
        FetchSummonerSpells(buildData);
        FetchItems(buildData, buildDataExtra);
        FetchSkillOrder(buildData, buildDataExtra);
        FetchMatchups(buildData);
        

        StartingItems.FirstItem.FetchAssetImage();
        if (StartingItems.SecondItem != null)
            StartingItems.SecondItem.FetchAssetImage();
        CoreItems.FirstItem.FetchAssetImage();
        CoreItems.SecondItem.FetchAssetImage();
        CoreItems.ThirdItem.FetchAssetImage();
        SummonerSpells.FirstSpellData.FetchAssetImage();
        SummonerSpells.SecondSpellData.FetchAssetImage();
        FourthItemChoice.First().ItemAsset.FetchAssetImage();
        FourthItemChoice.ElementAt(1).ItemAsset.FetchAssetImage();
        FourthItemChoice.Last().ItemAsset.FetchAssetImage();
        FifthItemChoice.First().ItemAsset.FetchAssetImage();
        FifthItemChoice.ElementAt(1).ItemAsset.FetchAssetImage();
        FifthItemChoice.Last().ItemAsset.FetchAssetImage();
        SixthItemChoice.First().ItemAsset.FetchAssetImage();
        SixthItemChoice.ElementAt(1).ItemAsset.FetchAssetImage();
        SixthItemChoice.Last().ItemAsset.FetchAssetImage();
        return this;
    }
    
    private void FetchChampionStats(JToken buildData)
    {
        var statData = buildData.SelectToken("header");
        
        TotalGames = statData.First().ToObject<int>();
        Winrate = statData.SelectToken("wr").ToObject<double>();
        Pickrate = statData.SelectToken("pr").ToObject<double>();
        Banrate = statData.SelectToken("br").ToObject<double>();
    }
    
    private void FetchRunes(JToken buildData)
    {
        var runeData = buildData.SelectToken("runes").SelectToken("stats");
    }

    private void FetchSummonerSpells(JToken buildData)
    {
        List<SummonerSpells> summonerSpells = new List<SummonerSpells>();
        
        var spellData = buildData.SelectToken("spells");

        foreach (var summonerSpellSet in spellData)
        {
            SummonerSpells tempSet = new SummonerSpells();
            int[] parts = summonerSpellSet.First().ToString().Split('_').Select(x => int.Parse(x)).ToArray();

            tempSet.FirstSpellData = GameData.Assets.FirstOrDefault(x => x.Value.ID == parts[0]).Value;
            tempSet.SecondSpellData = GameData.Assets.FirstOrDefault(x => x.Value.ID == parts[1]).Value;
            tempSet.Winrate = summonerSpellSet.ElementAt(1).ToObject<float>();
            tempSet.Pickrate = summonerSpellSet.ElementAt(2).ToObject<float>();
            tempSet.TotalGames = summonerSpellSet.ElementAt(3).ToObject<int>();

            summonerSpells.Add(tempSet);
        }
        float winRateWeight = 0.46f;
        float pickRateWeight = 0.54f;
        
        SummonerSpells = summonerSpells.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).First();
    }
    
    private void FetchItems(JToken buildData, JToken buildDataExtra)
    {
        List<StartingItems> startSets = new List<StartingItems>();

        var startItemData = buildDataExtra.SelectToken("startSet");

        foreach (var startItem in startItemData)
        {
            StartingItems startSet = new StartingItems();
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

        List<CoreItems> coreSets = new List<CoreItems>();

        var coreItemData = buildDataExtra.SelectToken("itemSets").SelectToken("itemBootSet3");

        foreach (var coreItem in coreItemData)
        {
            CoreItems coreSet = new CoreItems();
            string[] parts = coreItem.ToString().Split(new string[] { "\": [" }, StringSplitOptions.None);
            string itemName = parts[0].TrimStart('\"').TrimEnd('\"');
            parts = itemName.Split('_');

            coreSet.FirstItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
            coreSet.SecondItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[1])).Value;
            coreSet.ThirdItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[2])).Value;
            coreSet.Winrate = coreItem.First().Last().ToObject<float>() / coreItem.First().First().ToObject<float>();
            coreSet.Pickrate = coreItem.First().First().ToObject<float>() / buildData.SelectToken("header").SelectToken("n").ToObject<float>() * 100;
            coreSet.TotalGames = coreItem.First().First().ToObject<int>();

            coreSets.Add(coreSet);
        }
        
        List<Item> fourthItemSets = new List<Item>();

        var fourthItemData = buildData.SelectToken("item3");

        foreach (var fourthItem in fourthItemData)
        {
            Item fourthItemSet = new Item();
            string[] parts = fourthItem.First().ToString().Split('_');

            fourthItemSet.ItemAsset = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
            fourthItemSet.Winrate = fourthItem.ElementAt(1).ToObject<float>() / 100;
            fourthItemSet.Pickrate = fourthItem.ElementAt(2).ToObject<float>() / 100;
            fourthItemSet.TotalGames = fourthItem.ElementAt(3).ToObject<int>();

            fourthItemSets.Add(fourthItemSet);
        }

        List<Item> fifthItemSets = new List<Item>();

        var fifthItemData = buildData.SelectToken("item4");

        foreach (var fifthItem in fifthItemData)
        {
            Item fifthItemSet = new Item();
            string[] parts = fifthItem.First().ToString().Split('_');

            fifthItemSet.ItemAsset = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
            fifthItemSet.Winrate = fifthItem.ElementAt(1).ToObject<float>() / 100;
            fifthItemSet.Pickrate = fifthItem.ElementAt(2).ToObject<float>() / 100;
            fifthItemSet.TotalGames = fifthItem.ElementAt(3).ToObject<int>();

            fifthItemSets.Add(fifthItemSet);
        }

        List<Item> sixthItemSets = new List<Item>();

        var sixthItemData = buildData.SelectToken("item5");

        foreach (var sixthItem in sixthItemData)
        {
            Item sixthItemSet = new Item();
            string[] parts = sixthItem.First().ToString().Split('_');

            sixthItemSet.ItemAsset = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
            sixthItemSet.Winrate = sixthItem.ElementAt(1).ToObject<float>() / 100;
            sixthItemSet.Pickrate = sixthItem.ElementAt(2).ToObject<float>() / 100;
            sixthItemSet.TotalGames = sixthItem.ElementAt(3).ToObject<int>();

            sixthItemSets.Add(sixthItemSet);
        }
        
        float winRateWeight = 0.7f;
        float pickRateWeight = 0.3f;

        StartingItems = startSets.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).First();
        CoreItems = coreSets.OrderByDescending(x => x.Winrate * winRateWeight).First();
        FourthItemChoice.AddRange(fourthItemSets.OrderByDescending(x => x.TotalGames / (fourthItemSets.Sum(x => x.TotalGames))).Take(3));
        FifthItemChoice.AddRange(fifthItemSets.OrderByDescending(x => x.TotalGames / (fifthItemSets.Sum(x => x.TotalGames))).Take(3));
        SixthItemChoice.AddRange(sixthItemSets.OrderByDescending(x => x.TotalGames / (sixthItemSets.Sum(x => x.TotalGames))).Take(3));
    }

    private void FetchSkillOrder(JToken buildData, JToken buildDataExtra)
    {
        List<SkillPriority> skillPrioritySets = new List<SkillPriority>();

        var skillPriorityData = buildDataExtra.SelectToken("skills").SelectToken("skillOrder");

        foreach (var skillPrioritySet in skillPriorityData)
        {
            SkillPriority skillPrioritySetData = new SkillPriority();
            skillPrioritySetData.Priority = skillPrioritySet.First().ToString();
            skillPrioritySetData.Winrate = skillPrioritySet.ElementAt(2).ToObject<float>() / skillPrioritySet.ElementAt(1).ToObject<float>() * 100;
            skillPrioritySetData.Pickrate = skillPrioritySet.ElementAt(1).ToObject<float>() / buildData.SelectToken("header").SelectToken("n").ToObject<float>() * 100;
            skillPrioritySetData.TotalGames = skillPrioritySet.ElementAt(1).ToObject<int>();

            skillPrioritySets.Add(skillPrioritySetData);
        }

        List<SkillOrder> skillOrderSets = new List<SkillOrder>();

        var skillOrderData = buildDataExtra.SelectToken("skills").SelectToken("skill15");

        foreach (var skillOrderSet in skillOrderData)
        {
            SkillOrder skillOrderSetData = new SkillOrder();
            skillOrderSetData.Order = skillOrderSet.First().ToString();
            skillOrderSetData.Winrate = skillOrderSet.ElementAt(2).ToObject<float>() / skillOrderSet.ElementAt(1).ToObject<float>() * 100;
            skillOrderSetData.Pickrate = skillOrderSet.ElementAt(1).ToObject<float>() / buildData.SelectToken("n").ToObject<float>() * 100;
            skillOrderSetData.TotalGames = skillOrderSet.ElementAt(1).ToObject<int>();

            skillOrderSets.Add(skillOrderSetData);
        }

        float winRateWeight = 0.4f;
        float pickRateWeight = 0.6f;

        SkillPriority = skillPrioritySets.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).FirstOrDefault();
        SkillOrder = skillOrderSets.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).FirstOrDefault();
    }

    private void FetchMatchups(JToken buildData)
    {
        var allMatchupData = buildData.SelectToken("enemy_" + buildData.SelectToken("header").SelectToken("lane").ToString());

        foreach (var matchup in allMatchupData)
        {
            ChampionRole matchupData = new()
            {
                ChampionData = GameData.ChampionList.FirstOrDefault(x => x.Value.ID == int.Parse((string)matchup.First())).Value,
                Winrate = matchup.ElementAt(3).ToObject<float>(),
                TotalGames = matchup.ElementAt(1).ToObject<int>(),
                Pickrate = matchup.ElementAt(1).ToObject<float>() / buildData.SelectToken("header").SelectToken("n").ToObject<float>() * 100
            };

            Matchups.Add(matchupData);
        }

        float winRateWeight = 0.4f;
        float pickRateWeight = 0.6f;

        Matchups = Matchups.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).ToList();
    }
}