using Project_Nesja.Data;
using Project_Nesja;

public class Asset
{
    public string? Name { get; set; }
    public string? NameID { get; set; }
    public int ID { get; set; }
    public string? AssetType { get; set; }
    public Image? Image { get; set; }

    private async Task<Asset> DownloadImage(string Url, string subFolder, string fileName)
    {
        Image = await WebRequests.DownloadImage(Url, subFolder, fileName);
        return this;
    }
    
    public async Task<Asset>FetchAssetImage()
    {
        switch (AssetType)
        {
            case "Items":
                return await DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/item/" + ID + ".png", "Items", ID.ToString());
            case "Runes":
                return await DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perk/" + ID + ".png", "Runes", NameID);
            case "RunePages":
                return await DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perkStyle/" + ID + ".png", "RunePages", ID.ToString());
            case "StatMods":
                return await DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perkShard/" + ID + ".png", "StatMods", ID.ToString());
            case "SummonerSpells":
                return await DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + NameID + ".png", "SummonerSpells", NameID);
            default:
                return this;
        }
    }
}