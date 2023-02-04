using Project_Nesja.Data;
using Project_Nesja;

public class Asset
{
    public string? Name { get; set; }
    public string? NameID { get; set; }
    public int ID { get; set; }
    public string? AssetType { get; set; }
    public Image? Image { get; set; }

    public async Task<Asset> FetchItemImages()
    {
        Image = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/item/" + ID + ".png", "Items", ID.ToString());

        return this;
    }

    private async Task<Asset> FetchRuneImages()
    {
        Image = await WebRequests.DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perk/" + ID + ".png", "Runes", NameID);

        return this;
    }

    private async Task<Asset> FetchRunePageImages()
    {
        Image = await WebRequests.DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perkStyle/" + ID + ".png", "RunePages", ID.ToString());

        return this;
    }

    private async Task<Asset> FetchChampionStatMods()
    {
        Image = await WebRequests.DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perkShard/" + ID + ".png", "StatMods", ID.ToString());

        return this;
    }

    public async Task<Asset>FetchAssetImage()
    {
        switch (AssetType)
        {
            case "Items":
                return await FetchItemImages();
            case "Runes":
                return await FetchRuneImages();
            case "RunePages":
                return await FetchRunePageImages();
            case "StatMods":
                return await FetchChampionStatMods();
            default:
                return this;
        }
        return this;
    }
}