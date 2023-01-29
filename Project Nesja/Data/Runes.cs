using Project_Nesja;

public class Runes
{
    public string Name { get; set; }
    public string NameID { get; set; }
    public int ID { get; set; }
    public Image? Image { get; set; }
    
    public async Task<Runes> FetchRuneImages()
    {
        Image = await WebRequests.DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perk/" + ID + ".png", "Runes", NameID);

        return this;
    }
}