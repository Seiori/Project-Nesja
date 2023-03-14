using Newtonsoft.Json.Linq;
using PoniLCU;
using Project_Nesja.Objects;
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
                    AccountID = data["accountId"]!.ToObject<int>(),
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

        public static async Task SetSummonerRunes(string postBody)
        {
            var currentRunePage = await LeagueClient.Request(requestMethod.GET, "/lol-perks/v1/currentpage");
            int currentPageID = (int)JObject.Parse(currentRunePage)["id"]!;
            await LeagueClient.Request(requestMethod.DELETE, $"/lol-perks/v1/pages/{currentPageID}");
            await LeagueClient.Request(requestMethod.POST, "/lol-perks/v1/pages", postBody);
        }

        private static void OnDisconnectHandler()
        {
            // Handle the disconnection event
            // Perform any necessary cleanup operations

            MessageBox.Show("Client disconnected. Please restart the application to use the related features!");
        }
    }
}
