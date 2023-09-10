using Microsoft.Extensions.Configuration;

namespace Project_Nesja.Services
{
    // Generate ENUM for all regions

    #region Regions ENUMS
    public enum Regions
    {
        BR1,
        EUN1,
        EUW1,
        JP1,
        KR,
        LA1,
        LA2,
        NA1,
        OC1,
        PH2,
        RU,
        SG2,
        TH2,
        TR1,
        TW2,
        VN2,
        AMERICAS,
        ASIA,
        EUROPE,
        SEA
    }

    #endregion

    #region RiotAPIKeyManager

    class RiotAPIKeyManager
    {
        public static string APIKey { get; set; }
        static RiotAPIKeyManager()
        {
            // Create a Configuration Builder
            var builder = new ConfigurationBuilder().AddUserSecrets<RiotAPIKeyManager>();

            // Build the configuration
            var config = builder.Build();

            // Retrieve the API Key from User Secrets
            APIKey = config["API_Key"];
        }
    }

    #endregion

    static class RiotAPI
    {
        private static HttpClient? Client;
        private static string APIKey => RiotAPIKeyManager.APIKey;

        static RiotAPI() => Client = new HttpClient();

        #region Request Method

        public static Task<string> Request(string APIUrl)
        {
            return Client!.GetStringAsync(APIUrl + APIKey);
        }

        #endregion

        #region RegionConverter

        public static Regions RegionConvert(Regions region)
        {
            switch (region)
            {
                case Regions.BR1:
                    return Regions.AMERICAS;
                case Regions.EUN1:
                    return Regions.EUROPE;
                case Regions.EUW1:
                    return Regions.EUROPE;
                case Regions.JP1:
                    return Regions.ASIA;
                case Regions.KR:
                    return Regions.ASIA;
                case Regions.LA1:
                    return Regions.AMERICAS;
                case Regions.LA2:
                    return Regions.AMERICAS;
                case Regions.NA1:
                    return Regions.AMERICAS;
                case Regions.OC1:
                    return Regions.SEA;
                case Regions.PH2:
                    return Regions.SEA;
                case Regions.RU:
                    return Regions.EUROPE;
                case Regions.SG2:
                    return Regions.SEA;
                case Regions.TH2:
                    return Regions.SEA;
                case Regions.TR1:
                    return Regions.EUROPE;
                case Regions.TW2:
                    return Regions.SEA;
                case Regions.VN2:
                    return Regions.SEA;
                default:
                    return Regions.EUROPE;
            }
        }

        #endregion

        #region Account-V1

        // Not Needed

        #endregion

        #region Champion-Mastery-V4

        public static string GetChampionMasteryByPUUID(Regions region, string PUUID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-puuid/{PUUID}?api_key=").Result;
        }

        public static string GetChampionMasteryByPUUIDForChampion(Regions region, string PUUID, string CID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-puuid/{PUUID}/by-champion/{CID}?api_key=").Result;
        }

        public static string GetChampionMasteryByPUUIDTop(Regions region, string PUUID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-puuid/{PUUID}/top?api_key=").Result;
        }

        public static string GetChampionMasteryBySummonerID(Regions region, string SID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/{SID}?api_key=").Result;
        }

        public static string GetChampionMasteryBySummonerIDForChampion(Regions region, string SID, string CID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/{SID}/by-champion/{CID}?api_key=").Result;
        }

        public static string GetChampionMasteryBySummonerIDTop(Regions region, string SID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/{SID}/top&api_key=").Result;
        }

        public static string GetChampionMasteryScoreByPUUID(Regions region, string PUUID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/scores/by-puuid/{PUUID}?api_key=").Result;
        }

        public static string GetChampionMasteryScoreBySummonerID(Regions region, string SID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/scores/by-summoner/{SID}?api_key=").Result;
        }

        #endregion

        #region Champion-V3

        public static string GetChampionRotation(Regions region)
        {
            return Request($"https://{region}.api.riotgames.com/lol/platform/v3/champion-rotations?api_key=").Result;
        }

        #endregion

        #region Clash-V1

        public static string GetClashPlayersByPUUID(Regions region, string PUUID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/clash/v1/players/by-puuid/{PUUID}?api_key=").Result;
        }

        public static string GetClashPlayersBySummonerID(Regions region, string SID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/clash/v1/players/by-summoner/{SID}?api_key=").Result;
        }

        public static string GetClashTeamByTeamID(Regions region, string teamID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/clash/v1/teams/{teamID}?api_key=").Result;
        }

        public static string GetClashTournaments(Regions region)
        {
            return Request($"https://{region}.api.riotgames.com/lol/clash/v1/tournaments?api_key=").Result;
        }

        public static string GetClashTournamentsByTeamID(Regions region, string teamID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/clash/v1/tournaments/{teamID}?api_key=").Result;
        }

        public static string GetClashTournamentsByTournamentID(Regions region, string tournamentID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/clash/v1/tournaments/{tournamentID}?api_key=").Result;
        }   

        #endregion

        #region League-Exp-V4

        public static string GetLeaguePlayersByQueueTierDivision(Regions region, string queue, string tier, string division)
        {
            return Request($"https://{region}.api.riotgames.com/lol/league-exp/v4/entries/{queue}/{tier}/{division}?api_key=").Result;
        }

        #endregion

        #region League-V4

        public static string GetChallengerLeagueByQueue(Regions region, string queue)
        {
            return Request($"https://{region}.api.riotgames.com/lol/league/v4/challengerleagues/by-queue/{queue}?api_key=").Result;
        }

        public static string GetLeagueEntriesInAllQueuesBySummonerID(Regions region, string SID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/league/v4/entries/by-summoner/{SID}?api_key=").Result;
        }

        public static string GetLeagueEntriesByQueueTierDivision(Regions region, string queue, string tier, string division)
        {
            return Request($"https://{region}.api.riotgames.com/lol/league/v4/entries/{queue}/{tier}/{division}?api_key=").Result;
        }

        public static string GetGrandmasterLeagueByQueue(Regions region, string queue)
        {
            return Request($"https://{region}.api.riotgames.com/lol/league/v4/grandmasterleagues/by-queue/{queue}?api_key=").Result;
        }

        public static string GetLeagueByLeagueID(Regions region, string leagueID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/league/v4/leagues/{leagueID}?api_key=").Result;
        }

        public static string GetMasterLeagueByQueue(Regions region, string queue)
        {
            return Request($"https://{region}.api.riotgames.com/lol/league/v4/masterleagues/by-queue/{queue}?api_key=").Result;
        }

        #endregion

        #region LOL-CHALLENGES-V1

        public static string GetChallengesConfig(Regions region)
        {
            return Request($"https://{region}.api.riotgames.com/lol/challenges/v1/challenges/config?api_key=").Result;
        }

        public static string GetChallengesPercentiles(Regions region)
        {
            return Request($"https://{region}.api.riotgames.com/lol/challenges/v1/challenges/percentiles?api_key=").Result;
        }

        public static string GetSpecificChallengeConfig(Regions region, string challengeID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/challenges/v1/challenges/{challengeID}/config?api_key=").Result;
        }

        public static string GetChallengesTopPlayersByLevel(Regions region, string challengeID, string level)
        {
            return Request($"https://{region}.api.riotgames.com/lol/challenges/v1/challenges/{challengeID}/top/{level}?api_key=").Result;
        }

        public static string GetSpecificChallengePercentiles(Regions region, string challengeID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/challenges/v1/challenges/{challengeID}/percentiles?api_key=").Result;
        }

        public static string GetPlayerChallengesData(Regions region, string PUUID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/challenges/v1/player-data/{PUUID}?api_key=").Result;
        }

        #endregion

        #region LOL-STATUS-V4

        public static string GetLeagueStatus(Regions region)
        {
            return Request($"https://{region}.api.riotgames.com/lol/status/v4/platform-data?api_key=").Result;
        }

        #endregion

        #region MATCH-V5

        public static string GetMatchesbyPUUID(Regions region, string PUUID, long startTime, long endTime, int queue, string? type, int startingPoint, int numOfGames)
        {
            region = RegionConvert(region);

            var APIUrl = $"https://{region}.api.riotgames.com/lol/match/v5/matches/by-puuid/{PUUID}/ids?";

            if (startTime != 0)
                APIUrl += $"startTime={startTime}&";
            if (endTime != 0)
                APIUrl += $"endTime={endTime}&";
            if (queue != 0)
                APIUrl += $"queue={queue}&";
            if (type != null)
                APIUrl += $"type={type}&";

            return Request(APIUrl + "&api_key=").Result;
        }

        public static string GetMatchesbyMatchID(Regions region, string matchID)
        {
            region = RegionConvert(region);
            return Request($"https://{region}.api.riotgames.com/lol/match/v5/matches/{matchID}?api_key=").Result;
        }

        public static string GetMatchTimelinebyMatchID(Regions region, string matchID)
        {
            region = RegionConvert(region);
            return Request($"https://{region}.api.riotgames.com/lol/match/v5/matches/{matchID}/timeline?api_key=").Result;
        }

        #endregion

        #region SPECTATOR-V4

        public static string GetCurrentGameInfoBySummonerID(Regions region, string SID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/{SID}?api_key=").Result;
        }

        public static string GetFeaturedGames(Regions region)
        {
            return Request($"https://{region}.api.riotgames.com/lol/spectator/v4/featured-games?api_key=").Result;
        }

        #endregion

        #region SUMMONER-V4

        public static string GetSummonerByAccountID(Regions region, string accountID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-account/{accountID}?api_key=").Result;
        }

        public static string GetSummonerBySummonerName(Regions region, string summonerName)
        {
            return Request($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{summonerName}?api_key=").Result;
        }

        public static string GetSummonerByPUUID(Regions region, string PUUID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-puuid/{PUUID}?api_key=").Result;
        }

        public static string GetSummonerBySummonerID(Regions region, string summonerID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/{summonerID}?api_key=").Result;
        }

        #endregion
    }
}
