using Project_Nesja.Data;
using Project_Nesja;

public enum AssetType
{
    Items,
    Runes,
    RunePages,
    StatMods,
    SummonerSpells
}

public class Asset
{
    public string? Name;
    public string? NameID;
    public int ID;
    public AssetType AssetType;
    public Image? Image;

    private async Task<Asset> DownloadImage(string Url, string subFolder, string fileName)
    {
        Image = await WebRequests.DownloadImage(Url, subFolder, fileName);
        return this;
    }
    
    public async Task<Asset>FetchAssetImage()
    {
        return AssetType switch
        {
            AssetType.Items => await DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/item/" + ID + ".png", "Items", ID.ToString()),
            AssetType.Runes => await DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perk/" + ID + ".png", "Runes", NameID!),
            AssetType.RunePages => await DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perkStyle/" + ID + ".png", "RunePages", ID.ToString()),
            AssetType.StatMods => await DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perkShard/" + ID + ".png", "StatMods", ID.ToString()),
            AssetType.SummonerSpells => await DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + NameID + ".png", "SummonerSpells", NameID!),
            _ => this,
        };
    }
}