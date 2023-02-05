using Newtonsoft.Json.Linq;
using Project_Nesja;
using Project_Nesja.Data;
using System.Linq;
using System.Runtime.ExceptionServices;

public class ChampionBuild
{
    private readonly ChampionData championData;
    private readonly string role;
    public int[] Runes { get; set; }
    public SummonerSpellSet SummonerSpells { get; set; }
    public Items Items { get; set; }
    public SkillPriority SkillPriority { get; set; }
    public SkillOrder SkillOrder { get; set; }
    public List<ChampionRoleData> Matchups { get; set; }

    public ChampionBuild(ChampionData championData, string role = "default")
    {
        this.championData = championData;
        Runes = new int[6];
        SummonerSpells = new SummonerSpellSet();
        Items = new Items();
        SkillPriority = new SkillPriority();
        SkillOrder = new SkillOrder();
        Matchups = new List<ChampionRoleData>();
    }
    
    public async Task<ChampionBuild> FetchChampionBuild()
    {
        JToken buildData = await WebRequests.GetJsonObject("https://axe.lolalytics.com/mega/?ep=champion&p=d&v=1&patch=" + GameData.CurrentVersion + "&cid=" + championData.ID + "&lane=" + role + "&tier=platinum_plus&queue=420&region=all");
        JToken buildDataExtra = await WebRequests.GetJsonObject("https://axe.lolalytics.com/mega/?ep=champion2&p=d&v=1&patch=" + GameData.CurrentVersion + "&cid=" + championData.ID + "&lane=" + role + "&tier=platinum_plus&queue=420&region=all");

        await Task.WhenAll(
            FetchRunes(buildData),
            FetchSummonerSpells(buildData),
            FetchItems(buildData, buildDataExtra),
            FetchSkillOrder(buildData, buildDataExtra),
            FetchMatchups(buildData)
        );

        await Task.WhenAll(
            Items.FirstItem.FetchAssetImage(),
            Items.SecondItem.FetchAssetImage(),
            Items.ThirdItem.FetchAssetImage(),
            Items.FourthItem.FetchAssetImage(),
            Items.FifthItem.FetchAssetImage(),
            SummonerSpells.GetImages()
        );
        return this;
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
        List<Items> itemSets = new List<Items>();

        var itemData = buildDataExtra.SelectToken("itemSets").SelectToken("itemBootSet5");

        int TotalGames = 0;
        
        foreach (var item in itemData)
        {
            Items itemSet = new Items();
            string[] parts = item.ToString().Split(new string[] { "\": [" }, StringSplitOptions.None);
            string itemName = parts[0].TrimStart('\"').TrimEnd('\"');
            parts = itemName.Split('_');

            itemSet.FirstItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[0])).Value;
            itemSet.SecondItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[1])).Value;
            itemSet.ThirdItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[2])).Value;
            itemSet.FourthItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[3])).Value;
            itemSet.FifthItem = GameData.Assets.FirstOrDefault(x => x.Value.ID == int.Parse(parts[4])).Value;
            itemSet.Winrate = item.First().Last().ToObject<float>() / item.First().First().ToObject<float>();
            itemSet.Pickrate = item.First().First().ToObject<float>() / buildData.SelectToken("header").SelectToken("n").ToObject<float>() * 100;
            itemSet.TotalGames = item.First().First().ToObject<int>();

            itemSets.Add(itemSet);
        }

        float winRateWeight = 0.4f;
        float pickRateWeight = 0.6f;

        Items = itemSets.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).First();
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
            ChampionRoleData matchupData = new ChampionRoleData();
            matchupData.ChampionData = GameData.ChampionList.FirstOrDefault(x => x.Value.ID == int.Parse((string)matchup.First())).Value;
            matchupData.Winrate = matchup.ElementAt(3).ToObject<float>();
            matchupData.TotalGames = matchup.ElementAt(1).ToObject<int>();
            matchupData.Pickrate = matchup.ElementAt(1).ToObject<float>() / buildData.SelectToken("header").SelectToken("n").ToObject<float>() * 100;

            Matchups.Add(matchupData);
        }

        float winRateWeight = 0.4f;
        float pickRateWeight = 0.6f;

        Matchups = Matchups.OrderByDescending(x => x.Winrate * winRateWeight + x.Pickrate * pickRateWeight).ToList();
    }
}