using System.Reflection.Metadata.Ecma335;

public class StartingItems
{
    public Asset FirstItem { get; set; }
    public Asset SecondItem { get; set; }
    public float Winrate { get; set; }
    public float Pickrate { get; set; }
    public int TotalGames { get; set; }

    public async Task<StartingItems> FetchAssetImages()
    {
        await Task.WhenAll(
            FirstItem.FetchAssetImage(),
            SecondItem.FetchAssetImage()
            );

        return this;
    }
}