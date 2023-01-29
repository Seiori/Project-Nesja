using Newtonsoft.Json.Linq;
using Project_Nesja;
using Project_Nesja.Data;
using System.Reflection.Metadata.Ecma335;

public class ChampionData
{
    public string? Name { get; set; }
    public string? Title { get; set; }
    public string? NameID { get; set; }
    public int ID { get; set; }
    public int? Difficulty { get; set; }
    public Image? SplashImage { get; set; }
    public Image? SpriteImage { get; set; }
    public Image? QAbility { get; set; }
    public Image? WAbility { get; set; }
    public Image? EAbility { get; set; }
    public Image? RAbility { get; set; }

    public async Task<ChampionData> FetchChampionImages()
    {
        var task1 = FetchChampionSplash();
        var task2 = FetchChampionSprite();
        var task3 = FetchChampionJson();

        await Task.WhenAll(task1, task2, task3);

        return this;
    }
    private async Task FetchChampionSplash()
    {
        SplashImage = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/img/champion/loading/" + NameID + "_0.jpg", "Splash", NameID);
    }

    private async Task FetchChampionSprite()
    {
        SpriteImage = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/champion/" + NameID + ".png", "Sprite", NameID);
    }

    private async Task FetchChampionJson()
    {
        var championJson = (await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/data/en_US/champion/" + NameID + ".json", Path.Combine("Data", "ChampionJson", NameID + ".json"))).SelectToken("data").SelectToken(NameID).SelectToken("spells");
        JArray championJsonObject = JArray.Parse(championJson.ToString());
        
        var task1 = FetchChampionQImage(championJsonObject);
        var task2 = FetchChampionWImage(championJsonObject);
        var task3 = FetchChampionEImage(championJsonObject);
        var task4 = FetchChampionRImage(championJsonObject);

        await Task.WhenAll(task1, task2, task3, task4);
    }

    private async Task FetchChampionQImage(JArray championJsonObject)
    {
        string QAbilityUrl = (string)championJsonObject.ElementAt(0).SelectToken("image").First;
        QAbility = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + QAbilityUrl, "Abilities", NameID + "Q");
    }

    private async Task FetchChampionWImage(JArray championJsonObject)
    {
        string WAbilityUrl = (string)championJsonObject.ElementAt(1).SelectToken("image").First;
        WAbility = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + WAbilityUrl, "Abilities", NameID + "W");
    }

    private async Task FetchChampionEImage(JArray championJsonObject)
    {
        string EAbilityUrl = (string)championJsonObject.ElementAt(2).SelectToken("image").First;
        EAbility = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + EAbilityUrl, "Abilities", NameID + "E");
    }
    
    private async Task FetchChampionRImage(JArray championJsonObject)
    {
        string RAbilityUrl = (string)championJsonObject.ElementAt(3).SelectToken("image").First;
        RAbility = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + RAbilityUrl, "Abilities", NameID + "R");
    }
}