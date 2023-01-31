using Project_Nesja.Data;

public class AramPerformance
{
    private readonly float totalGamesWeight = 0.6f;
    private readonly float winRateWeight = 0.4f;

    public Dictionary<int, ChampionRoleData> SortAramData(Dictionary<int, ChampionRoleData> champions)
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

            return sum;
        }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        return sortedChampions;
    }
}