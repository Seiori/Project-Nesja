using Newtonsoft.Json.Linq;
using Project_Nesja;
using Project_Nesja.Data;

public class ChampionData
{
    public string? Name;
    public string? Title;
    public string? NameID;
    public int ID;
    public Image? SplashImage;
    public Image? SpriteImage;
    public Image? QAbility;
    public Image? WAbility;
    public Image? EAbility;
    public Image? RAbility;

    public async Task<ChampionData> FetchChampionData()
    {
        await Task.WhenAll(
            FetchChampionSplash(),
            FetchChampionSprite(),
            FetchChampionJson()
        );
        return this;
    }

    public async Task FetchChampionSplash()
    {
        SplashImage = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/img/champion/loading/" + NameID + "_0.jpg", "Splash", NameID);
    }

    public async Task FetchChampionSprite()
    {
        SpriteImage = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/champion/" + NameID + ".png", "Sprite", NameID);
    }

    public async Task FetchChampionJson()
    {
        string filePath = Path.Combine("Data", "ChampionJson", NameID + ".json");
        JToken championJson;
        if (!File.Exists(filePath))
        {
            championJson = (await WebRequests.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/data/en_US/champion/" + NameID + ".json")).SelectToken("data").SelectToken(NameID).SelectToken("spells");
            File.WriteAllText(filePath, championJson.ToString());
        }
        else
        {
            string jsonString = File.ReadAllText(filePath);
            championJson = JToken.Parse(jsonString);
        }
        JArray championJsonObject = JArray.Parse(championJson.ToString());

        await Task.WhenAll(
            FetchChampionQImage(championJsonObject),
            FetchChampionWImage(championJsonObject),
            FetchChampionEImage(championJsonObject),
            FetchChampionRImage(championJsonObject)
        );
    }
    
    public Image FetchChampionAbility(string abilityName)
    {
        return abilityName switch
        {
            "Q" => QAbility!,
            "W" => WAbility!,
            "E" => EAbility!,
            "R" => RAbility!,
            _ => null!,
        };
    }
    
    private async Task FetchChampionQImage(JArray championJsonObject)
    {
        string QAbilityUrl = (string)championJsonObject.ElementAt(0).SelectToken("image").First;
        QAbility = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + QAbilityUrl, "Abilities", NameID + "Q");
    }

    private async Task FetchChampionWImage(JArray championJsonObject)
    {
        string WAbilityUrl = (string)championJsonObject.ElementAt(1).SelectToken("image").First;
        WAbility = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + WAbilityUrl, "Abilities", NameID + "W");
    }

    private async Task FetchChampionEImage(JArray championJsonObject)
    {
        string EAbilityUrl = (string)championJsonObject.ElementAt(2).SelectToken("image").First;
        EAbility = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + EAbilityUrl, "Abilities", NameID + "E");
    }
    
    private async Task FetchChampionRImage(JArray championJsonObject)
    {
        string RAbilityUrl = (string)championJsonObject.ElementAt(3).SelectToken("image").First;
        RAbility = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/spell/" + RAbilityUrl, "Abilities", NameID + "R");
    }
}