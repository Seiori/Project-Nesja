using Project_Nesja;
using Newtonsoft.Json;
using Project_Nesja.Models;

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
    [JsonProperty("name")]
    public string? Name;
    [JsonProperty("key")]
    public string? NameID;
    [JsonProperty("id")]
    public int ID;
    [JsonIgnore]
    public AssetType AssetType;
    [JsonIgnore]
    public Image? Image;

    private async Task<Asset> DownloadImage(string Url)
    {
        Image = await WebRequests.DownloadImage(Url);
        return this;
    }
    
    public async Task<Asset>FetchAssetImage()
    {
        return AssetType switch
        {
            AssetType.Items => await DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/item/" + ID + ".png"),
            AssetType.Runes => await DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perk/" + ID + ".png"),
            AssetType.RunePages => await DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perkStyle/" + ID + ".png"),
            AssetType.StatMods => await DownloadImage("https://opgg-static.akamaized.net/meta/images/lol/perkShard/" + ID + ".png"),
            AssetType.SummonerSpells => await DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + NameID + ".png"),
            _ => this,
        };
    }
}