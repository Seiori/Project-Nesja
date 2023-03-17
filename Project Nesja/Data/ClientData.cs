using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoniLCU;
using Project_Nesja.Objects;
using System.Net.WebSockets;
using System.Text;
using static PoniLCU.LeagueClient;

namespace Project_Nesja.Data
{
    public static class ClientData
    {
        public static readonly LeagueClient LeagueClient = new(credentials.cmd);
        public static Summoner Summoner = new();
        
        static ClientData()
        {
            _ = ConnectToClient();
            LeagueClient.OnDisconnected += OnDisconnectHandler;
        }
        
        public static async Task<bool> ConnectToClient()
        {
            try
            {
                JObject data = JObject.Parse(await LeagueClient.Request(requestMethod.GET, "/lol-summoner/v1/current-summoner"));
                JObject region = JObject.Parse(await LeagueClient.Request(requestMethod.GET, "/riotclient/get_region_locale"));
                
                Summoner = new()
                {
                    PUUID = data!["puuid"]!.ToString(),
                    AccountID = data["accountId"]!.ToObject<long>(),
                    SummonerID = data["summonerId"]!.ToObject<int>(),
                    Name = data["displayName"]!.ToString(),
                    InternalName = data["internalName"]!.ToString(),
                    Region = region!["region"]!.ToString(),
                    Level = data["summonerLevel"]!.ToObject<int>(),
                    IconID = data["profileIconId"]!.ToObject<int>()
                };
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to find active client session. Please open the client to use the related features!", ex.ToString());
                return false;
            }
        }

        public static async Task<Summoner> SearchSummoner(string summonerName)
        {
            JObject data = JObject.Parse(await LeagueClient.Request(requestMethod.GET, "/lol-summoner/v1/summoners?name=" + summonerName));

            Summoner summoner = new()
            {
                AccountID = data["accountId"]!.ToObject<long>(),
                Name = summonerName,
                InternalName = data["internalName"]!.ToString(),
                IconID = data["profileIconId"]!.ToObject<int>(),
                PUUID = data["puuid"]!.ToString(),
                SummonerID = data["summonerId"]!.ToObject<int>(),
                Level = data["summonerLevel"]!.ToObject<int>(),
            };
            return summoner;
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
            var response = await LeagueClient.Request(requestMethod.PUT, $"/lol-item-sets/v1/item-sets/{Summoner.SummonerID}/sets", jsonString);
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
                statusMessage = statusMessage
            }); ;
            await LeagueClient.Request(requestMethod.PUT, "/lol-chat/v1/me", body);
        }

        private static void OnDisconnectHandler()
        {
            // Handle the disconnection event
            // Perform any necessary cleanup operations

            MessageBox.Show("Client disconnected. Please restart the application to use the related features!");
        }
    }
}
