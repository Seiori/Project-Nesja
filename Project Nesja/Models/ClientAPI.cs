using static Project_Nesja.Services.LeagueClient;
using Newtonsoft.Json.Linq;
using Project_Nesja.Objects;
using RiotGames.LeagueOfLegends.LeagueClient;
using Project_Nesja.Services;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Project_Nesja.Models
{
    public class ClientAPI
    {
        public static readonly LeagueClient LeagueClient = new();
        public static CurrentSummoner CurrentSummoner = new();

        static ClientAPI()
        {
            if (LeagueClient.IsConnected)
                GetCurrentSummoner();
            else
                MessageBox.Show("Failed to find active client session. Please open the client to use the related features!");
        }

        public static async void GetCurrentSummoner()
        {
            JObject data = JObject.Parse(await LeagueClient.Request(requestMethod.GET, "/lol-summoner/v1/current-summoner"));

            CurrentSummoner = JsonConvert.DeserializeObject<CurrentSummoner>(data.ToString())!;
        }

        public static async Task SetRunePage(string postBody)
        {
            var currentRunePage = await LeagueClient.Request(requestMethod.GET, "/lol-perks/v1/currentpage");
            int currentPageID = (int)JObject.Parse(currentRunePage)["id"]!;
            await LeagueClient.Request(requestMethod.DELETE, $"/lol-perks/v1/pages/{currentPageID}");
            await LeagueClient.Request(requestMethod.POST, "/lol-perks/v1/pages", postBody);
        }

        public static async Task SetItemSet(string jsonString)
        {
            //var response = await LeagueClient.Request(requestMethod.PUT, $"/lol-item-sets/v1/item-sets/{Summoner.SummonerID}/sets", jsonString);
        }

        public static async Task SetSummonerSpells(string jsonString)
        {
            var response = await LeagueClient.Request(requestMethod.PATCH, $"/lol-champ-select/v1/session/my-selection", jsonString);
        }

        public static async Task<JObject> GetTopMastery(int summonerID)
        {
            var top3 = await LeagueClient.Request(requestMethod.GET, "/lol-collections/v1/inventories/" + summonerID + "/champion-mastery/top?limit=3");
            return JObject.Parse(top3);
        }

        public static async Task<string> GetStatus()
        {
            var status = await LeagueClient.Request(requestMethod.GET, "/lol-chat/v1/me");
            return JObject.Parse(status)["statusMessage"]!.ToString();
        }

        public static async Task SetStatus(string statusMessage)
        {
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                statusMessage
            }); ;
            var response = await LeagueClient.Request(requestMethod.PUT, "/lol-chat/v1/me", body);
        }

        public static async Task GetWallet()
        {
            // Gets All Currency Information on Account
            var response = await LeagueClient.Request(requestMethod.GET, "/lol-inventory/v1/wallet/0");

            // Generate Client Wallet Object to Store Data
        }

        public static async Task GetClashLobby()
        {
            var response = await LeagueClient.Request(requestMethod.GET, "/lol-clash/v1/lobby");
        }
    }
}
