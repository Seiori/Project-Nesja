using Newtonsoft.Json.Linq;
using Project_Nesja.Services;
using Project_Nesja.Web;

public class Champion
{
    public string? Name;
    public string? Title;
    public string? NameID;
    public int ID;
    public JArray? ChampionJson;
    public Image? Splash;
    public Image? Sprite;
    public Image? Q;
    public Image? W;
    public Image? E;
    public Image? R;

    public async Task<Champion> FetchAll()
    {
        await FetchJson();
        await Task.WhenAll(
            FetchSplash(),
            FetchSprite(),
            FetchQImage(),
            FetchWImage(),
            FetchEImage(),
            FetchRImage()
        );

        return this;
    }
    
    public async Task<Champion> FetchJson()
    {
        ChampionJson = (JArray)(await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/data/en_US/champion/" + NameID + ".json"))!.SelectToken("data")!.SelectToken(NameID!)!.SelectToken("spells")!;
        return this;
    }

    public async Task<Champion> FetchSplash()
    {
        Splash = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/img/champion/loading/" + NameID + "_0.jpg");
        return this;
    }

    public async Task<Champion> FetchSprite()
    {
        Sprite = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/champion/" + NameID + ".png");
        return this;
    }

    public Image AbilityImageFromString(string abilityString)
    {
        return abilityString switch
        {
            "Q" => Q!,
            "W" => W!,
            "E" => E!,
            "R" => R!,
            _ => null!
        };
    }

    public async Task<Champion> FetchQImage()
    {
        string abilityUrl = (string)ChampionJson!.ElementAt(0)!.SelectToken("image")!.First!;
        Q = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + abilityUrl);
        return this;
    }

    public async Task<Champion> FetchWImage()
    {
        string abilityUrl = (string)ChampionJson!.ElementAt(1)!.SelectToken("image")!.First!;
        W = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + abilityUrl);
        return this;
    }

    public async Task<Champion> FetchEImage()
    {
        string abilityUrl = (string)ChampionJson!.ElementAt(2)!.SelectToken("image")!.First!;
        E = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + abilityUrl);
        return this;
    }

    public async Task<Champion> FetchRImage()
    {
        string abilityUrl = (string)ChampionJson!.ElementAt(3)!.SelectToken("image")!.First!;
        R = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + abilityUrl);
        return this;
    }
}