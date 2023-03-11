using System.Reflection.Metadata.Ecma335;

public class ItemSet
{
    public Asset? FirstItem { get; set; }
    public Asset? SecondItem { get; set; }
    public Asset? ThirdItem { get; set; }
    public float Winrate { get; set; }
    public float Pickrate { get; set; }
    public float TotalGames { get; set; }
}