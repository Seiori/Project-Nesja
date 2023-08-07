namespace Project_Nesja.Objects
{
    public class Summoner
    {
        public string? PUUID;
        public long AccountID;
        public int SummonerID;
        public string? Name { get; set; }
        public string? InternalName;
        public string? Region;
        public int Level;
        public int IconID;
        public int SoloRank;
        public string? SoloTier;
        public string? SoloDivision;
        public int SoloLP;
        public int SoloWins;
        public int SoloLosses;
        public string? FlexTier;
        public string? FlexDivision;
        public int FlexLP;
        public int FlexWins;
        public int FlexLosses;
        public List<IMatchData>? Matches;

        public Summoner()
        {
            PUUID = null;
            AccountID = 0;
            SummonerID = 0;
            Name = "Client Not Connected";
            InternalName = null;
            Region = null;
            Level = 1;
            IconID = 0;
            SoloRank = 0;
            SoloTier = null;
            SoloDivision = null;
            SoloLP = 0;
            SoloWins = 0;
            SoloLosses = 0;
            FlexTier = null;
            FlexDivision = null;
            FlexLP = 0;
            FlexWins = 0;
            FlexLosses = 0;
            Matches = new List<IMatchData>();
        }
    }
}
