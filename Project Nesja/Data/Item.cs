using Project_Nesja.Data;
using Project_Nesja;

public class Item
{
    public string Name { get; set; }
    public int ID { get; set; }
    public Image Image { get; set; }
    
    public async Task<Item> FetchItemImages()
    {
        Image = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/item/" + ID + ".png");

        return this;
    }
}