using Project_Nesja;

public class StatMods
{
    public string Name { get; set; }
    public int ID { get; set; }
    public Image Image { get; set; }
    
    public async Task<StatMods> FetchChampionStatMods()
    {
        Image = await WebRequests.DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perkShard/" + ID + ".png", "StatMods", ID.ToString());

        return this;
    }
}