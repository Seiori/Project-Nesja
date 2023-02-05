public class RankedPerformance
{
    private readonly float totalGamesWeight = 0.6f;
    private readonly float winRateWeight = 0.4f;

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
            sum += x.Value.Winrate * winRateWeight;

            return sum;
        }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        return sortedChampions;
    }
}
