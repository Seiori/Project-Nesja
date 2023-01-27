public class ChampionRoleData
{ 
    public ChampionData ChampionData { get; set; }
    public int TotalGames { get; set; }
    public int GamesWon { get; set; }
    public int GamesLost { get; set; }
    public int TotalKills { get; set; }
    public int TotalDeaths { get; set; }
    public int TotalAssists { get; set; }
    public int TotalCS { get; set; }
    public int TotalNeutralCS { get; set; }
    public float PickRate { get; set; }
    public float BanRate { get; set; }
}