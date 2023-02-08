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
        return AssetType switch
        {
            "Items" => await DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/item/" + ID + ".png", "Items", ID.ToString()),
            "Runes" => await DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perk/" + ID + ".png", "Runes", NameID),
            "RunePages" => await DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perkStyle/" + ID + ".png", "RunePages", ID.ToString()),
            "StatMods" => await DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perkShard/" + ID + ".png", "StatMods", ID.ToString()),
            "SummonerSpells" => await DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + NameID + ".png", "SummonerSpells", NameID),
            _ => this,
        };
    }
}