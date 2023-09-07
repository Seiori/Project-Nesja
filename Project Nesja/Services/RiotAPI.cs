using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design.Behavior;

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

    public class RiotAPI
    {
        private static HttpClient? Client;
        private string APIKey = "RGAPI-7265de53-0ed6-40c8-9b69-a962585a2769";

        public RiotAPI()
        {
            Client = new HttpClient();
        }

        #region Request Method

        public async Task<string> Request(string APIUrl)
        {
            var test = new HttpRequestMessage(HttpMethod.Get, APIUrl + APIKey);
            return await Client!.SendAsync(new HttpRequestMessage(HttpMethod.Get, APIUrl + "?api_key=" + APIKey)).Result.Content.ReadAsStringAsync();
        }

        #endregion

        #region Account-V1

        // Not Needed

        #endregion

        #region Champion-Mastery-V4

        public string GetChampionMasteryByPUUID(Regions region, string PUUID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-puuid/{PUUID}").Result;
        }

        public string GetChampionMasteryByPUUIDForChampion(Regions region, string PUUID, string CID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-puuid/{PUUID}/by-champion/{CID}").Result;
        }

        public string GetChampionMasteryByPUUIDTop(Regions region, string PUUID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-puuid/{PUUID}/top").Result;
        }

        public string GetChampionMasteryBySummonerID(Regions region, string SID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/{SID}").Result;
        }

        public string GetChampionMasteryBySummonerIDForChampion(Regions region, string SID, string CID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/{SID}/by-champion/{CID}").Result;
        }

        public string GetChampionMasteryBySummonerIDTop(Regions region, string SID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/{SID}/top").Result;
        }

        public string GetChampionMasteryScoreByPUUID(Regions region, string PUUID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/scores/by-puuid/{PUUID}").Result;
        }

        public string GetChampionMasteryScoreBySummonerID(Regions region, string SID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/champion-mastery/v4/scores/by-summoner/{SID}").Result;
        }

        #endregion

        #region Champion-V3

        public string GetChampionRotation(Regions region)
        {
            return Request($"https://{region}.api.riotgames.com/lol/platform/v3/champion-rotations").Result;
        }

        #endregion

        #region Clash-V1

        public string GetClashPlayersByPUUID(Regions region, string PUUID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/clash/v1/players/by-puuid/{PUUID}").Result;
        }

        public string GetClashPlayersBySummonerID(Regions region, string SID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/clash/v1/players/by-summoner/{SID}").Result;
        }

        public string GetClashTeamByTeamID(Regions region, string teamID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/clash/v1/teams/{teamID}").Result;
        }

        public string GetClashTournaments(Regions region)
        {
            return Request($"https://{region}.api.riotgames.com/lol/clash/v1/tournaments").Result;
        }

        public string GetClashTournamentsByTeamID(Regions region, string teamID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/clash/v1/tournaments/{teamID}").Result;
        }

        public string GetClashTournamentsByTournamentID(Regions region, string tournamentID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/clash/v1/tournaments/{tournamentID}").Result;
        }

        #endregion

        #region League-Exp-V4

        public string GetLeaguePlayersByQueueTierDivision(Regions region, string queue, string tier, string division)
        {
            return Request($"https://{region}.api.riotgames.com/lol/league-exp/v4/entries/{queue}/{tier}/{division}").Result;
        }

        #endregion

        #region League-V4

        public string GetChallengerLeagueByQueue(Regions region, string queue)
        {
            return Request($"https://{region}.api.riotgames.com/lol/league/v4/challengerleagues/by-queue/{queue}").Result;
        }

        public string GetLeagueEntriesInAllQueuesBySummonerID(Regions region, string SID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/league/v4/entries/by-summoner/{SID}").Result;
        }

        public string GetLeagueEntriesByQueueTierDivision(Regions region, string queue, string tier, string division)
        {
            return Request($"https://{region}.api.riotgames.com/lol/league/v4/entries/{queue}/{tier}/{division}").Result;
        }

        public string GetGrandmasterLeagueByQueue(Regions region, string queue)
        {
            return Request($"https://{region}.api.riotgames.com/lol/league/v4/grandmasterleagues/by-queue/{queue}").Result;
        }

        public string GetLeagueByLeagueID(Regions region, string leagueID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/league/v4/leagues/{leagueID}").Result;
        }

        public string GetMasterLeagueByQueue(Regions region, string queue)
        {
            return Request($"https://{region}.api.riotgames.com/lol/league/v4/masterleagues/by-queue/{queue}").Result;
        }

        #endregion

        #region LOL-CHALLENGES-V1

        public string GetChallengesConfig(Regions region)
        {
            return Request($"https://{region}.api.riotgames.com/lol/challenges/v1/challenges/config").Result;
        }

        public string GetChallengesPercentiles(Regions region)
        {
            return Request($"https://{region}.api.riotgames.com/lol/challenges/v1/challenges/percentiles").Result;
        }

        public string GetSpecificChallengeConfig(Regions region, string challengeID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/challenges/v1/challenges/{challengeID}/config").Result;
        }

        public string GetChallengesTopPlayersByLevel(Regions region, string challengeID, string level)
        {
            return Request($"https://{region}.api.riotgames.com/lol/challenges/v1/challenges/{challengeID}/top/{level}").Result;
        }

        public string GetSpecificChallengePercentiles(Regions region, string challengeID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/challenges/v1/challenges/{challengeID}/percentiles").Result;
        }

        public string GetPlayerChallengesData(Regions region, string PUUID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/challenges/v1/player-data/{PUUID}").Result;
        }

        #endregion

        #region LOL-STATUS-V4

        public string GetLeagueStatus(Regions region)
        {
            return Request($"https://{region}.api.riotgames.com/lol/status/v4/platform-data").Result;
        }

        #endregion

        #region MATCH-V5

        public string GetMatchesbyPUUID(Regions region, string PUUID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/match/v5/matches/by-puuid/{PUUID}/ids").Result;
        }

        public string GetMatchesbyMatchID(Regions region, string matchID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/match/v5/matches/{matchID}").Result;
        }

        public string GetMatchTimelinebyMatchID(Regions region, string matchID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/match/v5/matches/{matchID}/timeline").Result;
        }

        #endregion

        #region SPECTATOR-V4

        public string GetCurrentGameInfoBySummonerID(Regions region, string SID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/{SID}").Result;
        }

        public string GetFeaturedGames(Regions region)
        {
            return Request($"https://{region}.api.riotgames.com/lol/spectator/v4/featured-games").Result;
        }

        #endregion

        #region SUMMONER-V4

        public string GetSummonerByAccountID(Regions region, string accountID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-account/{accountID}").Result;
        }

        public string GetSummonerBySummonerName(Regions region, string summonerName)
        {
            return Request($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{summonerName}").Result;
        }

        public string GetSummonerByPUUID(Regions region, string PUUID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-puuid/{PUUID}").Result;
        }

        public string GetSummonerBySummonerID(Regions region, string summonerID)
        {
            return Request($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/{summonerID}").Result;
        }

        #endregion
    }
}
