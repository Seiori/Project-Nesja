using Project_Nesja;
using Project_Nesja.Data;

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
        SplashImage = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/img/champion/loading/" + NameID + "_0.jpg");
        SpriteImage = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/champion/" + NameID + ".png");
        var championJson = (await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/data/en_US/champion/" + NameID + ".json")).Last.Children();
        
        return this;
    }
}