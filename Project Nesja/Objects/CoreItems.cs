using System.Reflection.Metadata.Ecma335;

public class CoreItems
{
    public Asset FirstItem { get; set; }
    public Asset SecondItem { get; set; }
    public Asset ThirdItem { get; set; }
    public float Winrate { get; set; }
    public float Pickrate { get; set; }
    public float TotalGames { get; set; }

    public async Task<CoreItems> FetchAssetImages()
    {
        await Task.WhenAll(
            FirstItem.FetchAssetImage(),
            SecondItem.FetchAssetImage(),
            ThirdItem.FetchAssetImage()
            );

        return this;
    }
}