using Project_Nesja;

public class Runes
{
    public string Name { get; set; }
    public int ID { get; set; }
    public string Key { get; set; }
    public Image Icon { get; set; }

    public async Task<Runes> FetchItemImages()
    {
        Icon = await WebRequests.DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perk/" + ID + ".png");

        return this;
    }
}