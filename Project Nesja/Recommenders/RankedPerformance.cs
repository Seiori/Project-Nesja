public class RankedPerformance
{
    private readonly float totalGamesWeight = 0.46f;
    private readonly float winRateWeight = 0.52f;
    private readonly float banRateWeight = -0.02f;

    public Dictionary<int, ChampionRoleData> SortRankedData(Dictionary<int, ChampionRoleData> champions)
    {
        int TotalGames = 0;
        
        foreach (var champion in champions)
        {
            TotalGames += champion.Value.TotalGames;
        }    
        
        var sortedChampions = champions.OrderByDescending(x =>
        {
            float sum = 0;
            sum += (float)x.Value.TotalGames / TotalGames * totalGamesWeight;
            sum += x.Value.WinRate * winRateWeight;
            sum += x.Value.BanRate * banRateWeight;

            return sum;
        }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        return sortedChampions;
    }
}
