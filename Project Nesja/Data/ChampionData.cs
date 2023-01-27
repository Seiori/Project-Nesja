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

    public async Task<ChampionData> FetchChampionImages()
    {
        SplashImage = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/img/champion/loading/" + NameID + "_0.jpg");
        SpriteImage = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/champion/" + NameID + ".png");

        return this;
    }
}