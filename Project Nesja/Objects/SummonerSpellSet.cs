public class SummonerSpellSet
{
    public Asset FirstSpellData { get; set; }
    public Asset SecondSpellData { get; set; }
    public float Winrate { get; set; }
    public float Pickrate { get; set; }
    public int TotalGames { get; set; }

    public async Task<Image> GetImages()
    {
        if (FirstSpellData.Image == null)
            await FirstSpellData.FetchAssetImage();
        else
            return FirstSpellData.Image;
        if (SecondSpellData.Image == null)
            await SecondSpellData.FetchAssetImage();
            return SecondSpellData.Image;
    }
}