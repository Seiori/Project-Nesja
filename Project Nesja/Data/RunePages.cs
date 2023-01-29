using Project_Nesja;

public class RunePages
{
    public string Name { get; set; }
    public int ID { get; set; }
    public Image Image { get; set; }

    public async Task<RunePages> FetchRunePageImages()
    {
        Image = await WebRequests.DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perkStyle/" + ID + ".png", "RunePages", ID.ToString());

        return this;
    }
}