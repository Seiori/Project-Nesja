using Project_Nesja;
using Project_Nesja.Data;

public class ChampionData
{
    public string? Name { get; set; }
    public string? Title { get; set; }
    public string? NameID { get; set; }
    public int? ID { get; set; }
    public int? difficulty { get; set; }
    public Image? splashImage { get; set; }
    public Image? spriteImage { get; set; }
    
    public ChampionData FetchChampionData(string championName)
    {
        var champions = GameData.Champions.Children().ToList();
        var championData = champions.Where(x => x.First.ElementAt(3).Last().ToString().ToLower() == championName.ToLower()).First();

        Name = championData.First.ElementAt(3).Last().ToString();
        Title = championData.First.ElementAt(4).Last().ToString();
        NameID = championData.First.ElementAt(1).Last().ToString();
        ID = championData.First.ElementAt(2).Last().ToObject<int>();
        difficulty = championData.First.ElementAt(6).Last().Last().ToObject<int>();
        splashImage = WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/img/champion/loading/" + NameID + "_0.jpg");
        spriteImage = WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/champion/" + NameID + ".png");

        return this;
    }
}