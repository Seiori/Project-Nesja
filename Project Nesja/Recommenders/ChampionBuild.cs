using Newtonsoft.Json.Linq;
using Project_Nesja;

public class ChampionBuild
{
    private readonly ChampionData championData;
    private readonly string role;
    public string Test { get; set; }
    public int[] Runes { get; set; }
    public string[] SummonerSpells { get; set; }
    public string[] Items { get; set; }
    public string[] SkillPriority { get; set; }
    public string[] SkillOrder { get; set; }
    public ChampionData[] WeakAgainst { get; set; }
    public ChampionData[] StrongAgainst { get; set; }

    public ChampionBuild(ChampionData championData, string role)
    {
        this.championData = championData;
        Runes = new int[6];
        SummonerSpells = new string[2];
        Items = new string[0];
        SkillPriority = new string[3];
        SkillOrder = new string[18];
        WeakAgainst = new ChampionData[0];
        StrongAgainst = new ChampionData[0];
    }
    
    public async Task<ChampionBuild> FetchChampionBuild()
    {
        JToken buildData = (await WebRequests.GetJsonObject("https://www.op.gg/_next/data/8R0-II0deUa4IPAQkgqQ5/champions/lux/support/build.json?")).SelectToken("pageProps").SelectToken("data");

        await Task.WhenAll(
            FetchRunes(buildData),
            FetchSummonerSpells(buildData),
            FetchItems(buildData),
            FetchSkillPriority(buildData),
            FetchSkillOrder(buildData),
            FetchWeakAgainst(buildData),
            FetchStrongAgainst(buildData)
        );
        return this;
    }
    
    private async Task FetchRunes(JToken buildData)
    {
        
    }

    private async Task FetchSummonerSpells(JToken buildData)
    {

    }

    private async Task FetchItems(JToken buildData)
    {

    }

    private async Task FetchSkillPriority(JToken buildData)
    {
        var skillPriority = buildData["skill_masteries"].Count();
        if (skillPriority != 0)
        {
            // TODO THINK OF A SYSTEM TO STORE THE SKILL ORDERS AND COMPARE THEM
            SkillPriority[0] = buildData.ElementAt(5);
            SkillPriority[1] = buildData.ElementAt(5);
            SkillPriority[2] = buildData.ElementAt(5);
        }
    }
    
    private async Task FetchSkillOrder(JToken buildData)
    {

    }

    private async Task FetchWeakAgainst(JToken buildData)
    {

    }

    private async Task FetchStrongAgainst(JToken buildData)
    {

    }
}