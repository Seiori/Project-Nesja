using Project_Nesja.Data;

public class ChampionData
{
    public string Name { get; set; }
    public int id { get; set; }
    public int difficulty { get; set; }
    public Image splashImage { get; set; }
    public Image spriteImage { get; set; }
    
    public ChampionData FetchChampionData(string championName)
    {
        var champions = GameData.Champions.Children().ToList();
        var championData = champions.Where(x => x.First.ElementAt(3).Last().ToString().ToLower() == championName.ToLower()).First();

        Name = championData.First.ElementAt(3).Last().ToString();
        id = championData.First.ElementAt(2).Last().ToObject<int>();
        difficulty = championData.First.ElementAt(6).Last().Last().ToObject<int>();
        splashImage = championData.First.ElementAt(7).First().Last().ToObject<Image>();
        spriteImage = championData.First.ElementAt(7).ElementAt(1).Last().ToObject<Image>();

        return this;
    }
}