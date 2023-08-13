using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Project_Nesja.Objects
{
    public class SummonerData
    {
        public string? Region;
        public string? Summoner;
        public string? PUUID;
        [JsonProperty("modified-summoner")]
        public string? ModifiedSummoner;
        [JsonProperty("modified-ranks")]
        public string? ModifiedRanks;
        [JsonProperty("modified-matches")]
        public string? ModifiedMatches;
        [JsonProperty("request-summoner")]
        public int RequestSummoner;
        [JsonProperty("request-ranks")]
        public int RequestRanks;
        [JsonProperty("request-matches")]
        public int RequestMatches;
        public string? SID;
        public string? Name;
        public string? Level;
        public string? Icon;
        [JsonProperty("solo-rank")]
        public string? SoloRank;
        [JsonProperty("solo-tier")]
        public string? SoloTier;
        [JsonProperty("solo-division")]
        public string? SoloDivision;
        [JsonProperty("solo-lp")]
        public string? SoloLP;
        [JsonProperty("solo-wins")]
        public string? SoloWins;
        [JsonProperty("solo-losses")]
        public string? SoloLosses;
        [JsonProperty("solo-series")]
        public string? SoloSeries;
        [JsonProperty("flex-rank")]
        public string? FlexRank;
        [JsonProperty("flex-tier")]
        public string? FlexTier;
        [JsonProperty("flex-division")]
        public string? FlexDivision;
        [JsonProperty("flex-lp")]
        public string? FlexLP;
        [JsonProperty("flex-wins")]
        public string? FlexWins;
        [JsonProperty("flex-losses")]
        public string? FlexLosses;
        [JsonProperty("flex-series")]
        public string? FlexSeries;
        public int Time;
        [JsonProperty("solo-20-tier")]
        public string? Solo20Tier;
        [JsonProperty("solo-20-division")]
        public string? Solo20Division;
        [JsonProperty("solo-20-wins")]
        public string? Solo20Wins;
        [JsonProperty("solo-20-losses")]
        public string? Solo20Losses;
        [JsonProperty("solo-20-lp")]
        public string? Solo20LP;
        [JsonProperty("flex-20-tier")]
        public string? Flex20Tier;
        [JsonProperty("flex-20-division")]
        public string? Flex20Division;
        [JsonProperty("flex-20-wins")]
        public string? Flex20Wins;
        [JsonProperty("flex-20-losses")]
        public string? Flex20Losses;
        [JsonProperty("flex-20-lp")]
        public string? Flex20LP;
        [JsonProperty("solo-21-tier")]
        public string? Solo21Tier;
        [JsonProperty("solo-21-division")]
        public string? Solo21Division;
        [JsonProperty("solo-21-wins")]
        public string? Solo21Wins;
        [JsonProperty("solo-21-losses")]
        public string? Solo21Losses;
        [JsonProperty("solo-21-lp")]
        public string? Solo21LP;
        [JsonProperty("flex-21-tier")]
        public string? Flex21Tier;
        [JsonProperty("flex-21-division")]
        public string? Flex21Division;
        [JsonProperty("flex-21-wins")]
        public string? Flex21Wins;
        [JsonProperty("flex-21-losses")]
        public string? Flex21Losses;
        [JsonProperty("flex-21-lp")]
        public string? Flex21LP;
        [JsonProperty("solo-22-tier")]
        public string? Solo22Tier;
        [JsonProperty("solo-22-division")]
        public string? Solo22Division;
        [JsonProperty("solo-22-wins")]
        public string? Solo22Wins;
        [JsonProperty("solo-22-losses")]
        public string? Solo22Losses;
        [JsonProperty("solo-22-lp")]
        public string? Solo22LP;
        [JsonProperty("flex-22-tier")]
        public string? Flex22Tier;
        [JsonProperty("flex-22-division")]
        public string? Flex22Division;
        [JsonProperty("flex-22-wins")]
        public string? Flex22Wins;
        [JsonProperty("flex-22-losses")]
        public string? Flex22Losses;
        [JsonProperty("flex-22-lp")]
        public string? Flex22LP;
        [JsonProperty("solo-23a-tier")]
        public string? Solo23aTier;
        [JsonProperty("solo-23a-division")]
        public string? Solo23aDivision;
        [JsonProperty("solo-23a-wins")]
        public string? Solo23aWins;
        [JsonProperty("solo-23a-losses")]
        public string? Solo23aLosses;
        [JsonProperty("solo-23a-lp")]
        public string? Solo23aLP;
        [JsonProperty("flex-23a-tier")]
        public string? Flex23aTier;
        [JsonProperty("flex-23a-division")]
        public string? Flex23aDivision;
        [JsonProperty("flex-23a-wins")]
        public string? Flex23aWins;
        [JsonProperty("flex-23a-losses")]
        public string? Flex23aLosses;
        [JsonProperty("flex-23a-lp")]
        public string? Flex23aLP;
        public JArray? Matches;
    }
}
