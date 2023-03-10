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
    public int[] Runes { get; set; }
    public ItemSet StartingItems { get; set; }
    public ItemSet CoreItems { get; set; }
    public List<Item> FourthItemChoice { get; set; }
    public List<Item>  FifthItemChoice { get; set; }
    public List<Item> SixthItemChoice { get; set; }
    public SkillPriority SkillPriority { get; set; }
    public SkillOrder SkillOrder { get; set; }
    public SummonerSpells SummonerSpells { get; set; }
    public List<ChampionRole> Matchups { get; set; }
    private readonly Dictionary<int, Asset> _assets;

    public ChampionBuild(ChampionData championData, string role)
    {
        this.championData = championData;
        this.role = role;
        Runes = new int[6];
        StartingItems = new ItemSet();
        CoreItems = new ItemSet();
        FourthItemChoice = new List<Item>(3);
        FifthItemChoice = new List<Item>(3);
        SixthItemChoice = new List<Item>(3);
        SkillPriority = new SkillPriority();
        SkillOrder = new SkillOrder();
        SummonerSpells = new SummonerSpells();
        Matchups = new List<ChampionRole>();
        _assets = GameData.Assets;
    }

    public async Task<ChampionBuild> FetchChampionBuild()
    {
        string apiUrl = "https://axe.lolalytics.com/mega/?ep=champion&p=d&v=1&patch=" + GameData.CurrentVersion + "&cid=" + championData.ID + "&lane=" + role + "&tier=platinum_plus&queue=420&region=all";
        string apiExtraUrl = "https://axe.lolalytics.com/mega/?ep=champion2&p=d&v=1&patch=" + GameData.CurrentVersion + "&cid=" + championData.ID + "&lane=" + role + "&tier=platinum_plus&queue=420&region=all";

        JToken buildData = await WebRequests.GetJsonObject(apiUrl);
        JToken buildDataExtra = await WebRequests.GetJsonObject(apiExtraUrl);

        this.role = buildData.SelectToken("header").SelectToken("lane").ToString();
        
        FetchChampionStats(buildData);
        FetchRunes(buildData);
        FetchSummonerSpells(buildData);
        FetchItems(buildData, buildDataExtra);
        FetchSkillOrder(buildData, buildDataExtra);
        FetchMatchups(buildData);

        await FetchImageAssetsAsync();

        return this;
    }

    private async Task FetchImageAssetsAsync()
    {
        var tasks = new List<Task>
        {
            StartingItems.FirstItem.FetchAssetImage(),
            CoreItems.FirstItem.FetchAssetImage(),
            CoreItems.SecondItem.FetchAssetImage(),
            CoreItems.ThirdItem.FetchAssetImage(),
            SummonerSpells.FirstSpellData.FetchAssetImage(),
            SummonerSpells.SecondSpellData.FetchAssetImage()
        };
        
        tasks.AddRange(FourthItemChoice.Select(c => c.ItemAsset.FetchAssetImage()));
        tasks.AddRange(FifthItemChoice.Select(c => c.ItemAsset.FetchAssetImage()));
        tasks.AddRange(SixthItemChoice.Select(c => c.ItemAsset.FetchAssetImage()));

        await Task.WhenAll(tasks).ConfigureAwait(false);
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
        List<SummonerSpells> summonerSpells = new ();

        JArray spellData = (JArray)buildData.SelectToken("spells");

        float winRateWeight = 0.46f;
        float pickRateWeight = 1 - winRateWeight;

        for (int i = 0; i < spellData.Count; i++)
        {
            JToken summonerSpellSet = spellData[i];

            int firstSpellId;
            int secondSpellId;
            string[] spellIds = summonerSpellSet[0].ToString().Split('_');
            if (spellIds.Length == 2 && int.TryParse(spellIds[0], out firstSpellId) && int.TryParse(spellIds[1], out secondSpellId))
            {
                SummonerSpells summonerSpell = new()
                {
                    FirstSpellData = _assets.GetValueOrDefault(firstSpellId),
                    SecondSpellData = _assets.GetValueOrDefault(secondSpellId),
                    Winrate = (float)summonerSpellSet[1],
                    Pickrate = (float)summonerSpellSet[2],
                    TotalGames = (int)summonerSpellSet[3]
                };

                summonerSpells.Add(summonerSpell);
            }
        }
        SummonerSpells = summonerSpells.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).First();
    }

    private void FetchItems(JToken buildData, JToken buildDataExtra)
    {
        List<ItemSet> startSets = new ();

        var startItemData = buildDataExtra.SelectToken("startSet");

        foreach (var startItem in startItemData)
        {
            ItemSet startSet = new ();
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

        List<ItemSet> coreSets = new ();

        var coreItemData = buildDataExtra.SelectToken("itemSets").SelectToken("itemBootSet3");

        foreach (var coreItem in coreItemData)
        {
            ItemSet coreSet = new ();
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

        List<Item> fourthItemSets = new();

        var fourthItemData = buildData.SelectToken("item3");
        
        List<Item> fifthItemSets = new();

        var fifthItemData = buildData.SelectToken("item4");
        
        List<Item> sixthItemSets = new();

        var sixthItemData = buildData.SelectToken("item5");
        try
        {
            foreach (var fourthItem in fourthItemData)
            {
                Item fourthItemSet = new();
                string[] parts = fourthItem.First().ToString().Split('_');

                fourthItemSet.ItemAsset = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
                fourthItemSet.Winrate = fourthItem.ElementAt(1).ToObject<float>() / 100;
                fourthItemSet.Pickrate = fourthItem.ElementAt(2).ToObject<float>() / 100;
                fourthItemSet.TotalGames = fourthItem.ElementAt(3).ToObject<int>();

                fourthItemSets.Add(fourthItemSet);
            }

            foreach (var fifthItem in fifthItemData)
            {
                Item fifthItemSet = new();
                string[] parts = fifthItem.First().ToString().Split('_');

                fifthItemSet.ItemAsset = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
                fifthItemSet.Winrate = fifthItem.ElementAt(1).ToObject<float>() / 100;
                fifthItemSet.Pickrate = fifthItem.ElementAt(2).ToObject<float>() / 100;
                fifthItemSet.TotalGames = fifthItem.ElementAt(3).ToObject<int>();

                fifthItemSets.Add(fifthItemSet);
            }

            foreach (var sixthItem in sixthItemData)
            {
                Item sixthItemSet = new();
                string[] parts = sixthItem.First().ToString().Split('_');

                sixthItemSet.ItemAsset = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
                sixthItemSet.Winrate = sixthItem.ElementAt(1).ToObject<float>() / 100;
                sixthItemSet.Pickrate = sixthItem.ElementAt(2).ToObject<float>() / 100;
                sixthItemSet.TotalGames = sixthItem.ElementAt(3).ToObject<int>();

                sixthItemSets.Add(sixthItemSet);
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Not enough data!");
        }

        StartingItems = startSets.OrderByDescending(x => x.TotalGames / (fifthItemSets.Sum(x => x.TotalGames))).First();
        CoreItems = coreSets.OrderByDescending(x => x.TotalGames / (fifthItemSets.Sum(x => x.TotalGames))).First();
        FourthItemChoice.AddRange(fourthItemSets.OrderByDescending(x => x.TotalGames / (fourthItemSets.Sum(x => x.TotalGames))).Take(3));
        FifthItemChoice.AddRange(fifthItemSets.OrderByDescending(x => x.TotalGames / (fifthItemSets.Sum(x => x.TotalGames))).Take(3));
        SixthItemChoice.AddRange(sixthItemSets.OrderByDescending(x => x.TotalGames / (sixthItemSets.Sum(x => x.TotalGames))).Take(3));
    }

    private void FetchSkillOrder(JToken buildData, JToken buildDataExtra)
    {
        List<SkillPriority> skillPrioritySets = new ();

        var skillPriorityData = buildDataExtra.SelectToken("skills").SelectToken("skillOrder");

        foreach (var skillPrioritySet in skillPriorityData)
        {
            SkillPriority skillPrioritySetData = new ();
            skillPrioritySetData.Priority = skillPrioritySet.First().ToString();
            skillPrioritySetData.Winrate = skillPrioritySet.ElementAt(2).ToObject<float>() / skillPrioritySet.ElementAt(1).ToObject<float>() * 100;
            skillPrioritySetData.Pickrate = skillPrioritySet.ElementAt(1).ToObject<float>() / buildData.SelectToken("header").SelectToken("n").ToObject<float>() * 100;
            skillPrioritySetData.TotalGames = skillPrioritySet.ElementAt(1).ToObject<int>();

            skillPrioritySets.Add(skillPrioritySetData);
        }

        List<SkillOrder> skillOrderSets = new ();

        var skillOrderData = buildDataExtra.SelectToken("skills").SelectToken("skill15");

        foreach (var skillOrderSet in skillOrderData)
        {
            SkillOrder skillOrderSetData = new ();
            skillOrderSetData.Order = skillOrderSet.First().ToString();
            skillOrderSetData.Winrate = skillOrderSet.ElementAt(2).ToObject<float>() / skillOrderSet.ElementAt(1).ToObject<float>() * 100;
            skillOrderSetData.Pickrate = skillOrderSet.ElementAt(1).ToObject<float>() / buildData.SelectToken("n").ToObject<float>() * 100;
            skillOrderSetData.TotalGames = skillOrderSet.ElementAt(1).ToObject<int>();

            skillOrderSets.Add(skillOrderSetData);
        }

        float winRateWeight = 0.4f;
        float pickRateWeight = 0.6f;

        SkillPriority = skillPrioritySets.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).First();
        SkillOrder = skillOrderSets.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).First();
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
        float pickRateWeight = 1 - winRateWeight;

        Matchups = Matchups.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).ToList();
    }
}