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
    public SummonerSpellSet SummonerSpells { get; set; }
    public Items StartingItems { get; set; }
    public Items CoreItems { get; set; }
    public Items FourthItemChoice { get; set; }
    public Items  FifthItemChoice { get; set; }
    public Items SixthItemChoice { get; set; }
    public SkillPriority SkillPriority { get; set; }
    public SkillOrder SkillOrder { get; set; }
    public List<ChampionRoleData> Matchups { get; set; }

    public ChampionBuild(ChampionData championData, string role)
    {
        this.championData = championData;
        this.role = role;
        Runes = new int[6];
        SummonerSpells = new SummonerSpellSet();
        SkillPriority = new SkillPriority();
        SkillOrder = new SkillOrder();
        Matchups = new List<ChampionRoleData>();
    }
    
    public async Task<ChampionBuild> FetchChampionBuild()
    {
        JToken buildData = await WebRequests.GetJsonObject("https://axe.lolalytics.com/mega/?ep=champion&p=d&v=1&patch=" + GameData.CurrentVersion + "&cid=" + championData.ID + "&lane=" + role + "&tier=platinum_plus&queue=420&region=all");
        JToken buildDataExtra = await WebRequests.GetJsonObject("https://axe.lolalytics.com/mega/?ep=champion2&p=d&v=1&patch=" + GameData.CurrentVersion + "&cid=" + championData.ID + "&lane=" + role + "&tier=platinum_plus&queue=420&region=all");

        role = buildData.SelectToken("header").SelectToken("lane").ToString();
        await Task.WhenAll(
            FetchChampionStats(buildData),
            FetchRunes(buildData),
            FetchSummonerSpells(buildData),
            FetchItems(buildData, buildDataExtra),
            FetchSkillOrder(buildData, buildDataExtra),
            FetchMatchups(buildData)
        );

        await Task.WhenAll(
            StartingItems.FirstItem.FetchAssetImage(),
            StartingItems.SecondItem.FetchAssetImage(),
            CoreItems.FirstItem.FetchAssetImage(),
            CoreItems.SecondItem.FetchAssetImage(),
            CoreItems.ThirdItem.FetchAssetImage(),
            SummonerSpells.GetImages()
        );
        return this;
    }
    
    private async Task FetchChampionStats(JToken buildData)
    {
        var statData = buildData.SelectToken("header");
        
        TotalGames = statData.First().ToObject<int>();
        Winrate = statData.SelectToken("wr").ToObject<double>();
        Pickrate = statData.SelectToken("pr").ToObject<double>();
        Banrate = statData.SelectToken("br").ToObject<double>();
    }
    
    private async Task FetchRunes(JToken buildData)
    {
        var runeData = buildData.SelectToken("runes").SelectToken("stats");
    }

    private async Task FetchSummonerSpells(JToken buildData)
    {
        List<SummonerSpellSet> summonerSpells = new List<SummonerSpellSet>();
        
        var spellData = buildData.SelectToken("spells");

        foreach (var summonerSpellSet in spellData)
        {
            SummonerSpellSet tempSet = new SummonerSpellSet();
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
    
    private async Task FetchItems(JToken buildData, JToken buildDataExtra)
    {
        List<Items> startSets = new List<Items>();

        var startItemData = buildDataExtra.SelectToken("startSet");

        foreach (var startItem in startItemData)
        {
            Items startSet = new Items();
            string[] parts = startItem.First().ToString().Split(new string[] { "\": [" }, StringSplitOptions.None);
            string itemName = parts[0].TrimStart('\"').TrimEnd('\"');
            parts = itemName.Split('_');

            if (!string.IsNullOrEmpty(parts[0]))
                startSet.FirstItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
            if (parts.Length > 1)
                startSet.SecondItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[1])).Value;
            if (parts.Length > 2)
                startSet.ThirdItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[2])).Value;
            if (parts.Length > 3)
                startSet.SecondItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[3])).Value;
            if (parts.Length > 4)
                startSet.SecondItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[4])).Value;
            startSet.Winrate = startItem.ElementAt(1).ToObject<float>() / 100;
            startSet.Pickrate = startItem.ElementAt(2).ToObject<float>() / 100;
            startSet.TotalGames = startItem.Last().ToObject<int>();

            startSets.Add(startSet);
        }

        List<Items> coreSets = new List<Items>();

        var coreItemData = buildDataExtra.SelectToken("itemSets").SelectToken("itemBootSet3");

        foreach (var coreItem in coreItemData)
        {
            Items coreSet = new Items();
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
 
        float winRateWeight = 0.4f;
        float pickRateWeight = 0.6f;

        StartingItems = startSets.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).First();
        CoreItems = coreSets.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).First();
    }

    private async Task FetchSkillOrder(JToken buildData, JToken buildDataExtra)
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

    public async Task FetchMatchups(JToken buildData)
    {
        var allMatchupData = buildData.SelectToken("enemy_" + buildData.SelectToken("header").SelectToken("lane").ToString());

        foreach (var matchup in allMatchupData)
        {
            ChampionRoleData matchupData = new()
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