using System.Security.Authentication;
using System.Diagnostics;
using System.Net;
using System.Management;
using System.Text.RegularExpressions;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Project_Nesja.Models;
using Newtonsoft.Json;

namespace Project_Nesja.Services
{
    public static class LeagueClient
    {
        public enum RequestMethod
        {
            GET,
            POST,
            PATCH,
            DELETE,
            PUT
        }

        public static CurrentSummoner CurrentSummoner = new();

        public static HttpClient? Client;

        private static Tuple<Process, string, string>? ProcessInfo;

        public static bool IsConnected;

        private static Regex AUTH_TOKEN_REGEX = new Regex("\"--remoting-auth-token=(.+?)\"");

        private static Regex PORT_REGEX = new Regex("\"--app-port=(\\d+?)\"");

        static LeagueClient()
        {
            //we initialize the http client
            try
            {
                Client = new HttpClient(new HttpClientHandler()
                {
                    SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls,
                    ServerCertificateCustomValidationCallback = (a, b, c, d) => true
                });
            }
            catch
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                Client = new HttpClient(new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (a, b, c, d) => true
                });
            }

            //wait before we start initializing the connections 
            Task.Delay(2000).ContinueWith(e => TryConnectOrRetry());

            var connectionAttempts = 0;

            while (!IsConnected)
            {
                if (connectionAttempts != 2)
                {
                    connectionAttempts++;
                    TryConnectOrRetry();
                }
                else
                {
                    Debug.WriteLine("Connection timed out ");
                    break;
                }
                Task.Delay(1000).GetAwaiter().GetResult();
            }
        }

        //the method to do requests based on parameters
        public static Task<string> Request(RequestMethod method, string url, object? body = null)
        {
            if (!IsConnected) throw new InvalidOperationException("Not connected to LCU");

            return Client!.SendAsync(new HttpRequestMessage(new HttpMethod(method.ToString()), "https://127.0.0.1:" + ProcessInfo!.Item3 + url)
            {
                Content = body == null ? null : new StringContent(body.ToString()!, Encoding.UTF8, "application/json")
            }).Result.Content.ReadAsStringAsync();
        }

        private static void TryConnect()
        {
            try
            {
                if (IsConnected) return;

                GetLeagueStatus();

                if (ProcessInfo == null) return;

                var byteArray = Encoding.ASCII.GetBytes("riot:" + ProcessInfo.Item2);
                Client!.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                IsConnected = true;

                CurrentSummoner = JsonConvert.DeserializeObject<CurrentSummoner>(lolSummoner.CurrentSummoner())!;
            }
            catch (Exception e)
            {
                ProcessInfo = null;
                IsConnected = false;
                if (!IsConnected) throw new InvalidOperationException($"Exception occurred trying to connect to League of Legends: {e.ToString()}");
            }
        }

        private static void TryConnectOrRetry()
        {
            if (IsConnected) return;
            TryConnect();

            Task.Delay(2000).ContinueWith(a => TryConnectOrRetry());
        }

        private static void GetLeagueStatus()
        {
            foreach (var p in Process.GetProcessesByName("LeagueClientUx"))
            {
                using (var mos = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + p.Id.ToString()))
                {
                    using (var moc = mos.Get())
                    {
                        var commandLine = (string)moc.OfType<ManagementObject>().First()["CommandLine"];

                        try
                        {
                            var authToken = AUTH_TOKEN_REGEX.Match(commandLine).Groups[1].Value;
                            var port = PORT_REGEX.Match(commandLine).Groups[1].Value;

                            ProcessInfo = new Tuple<Process, string, string>(p, authToken, port);
                            return;
                        }
                        catch (Exception e)
                        {
                            throw new InvalidOperationException($"Error while trying to get the status for LeagueClientUx: {e.ToString()}\n\n(CommandLine = {commandLine})");

                        }
                    }
                }
            }
            ProcessInfo = null;
        }
        public static class Default
        {
            public static string RegionLocale()
            {
                return Request(RequestMethod.GET, "/riotclient/get_region_locale").Result;
            }
        }

        public static class lolChampSelect
        {
            public static string GetCurrentChampion()
            {
                return Request(RequestMethod.GET, "/lol-champ-select/v1/session/my-selection").Result;
            }

            public static void SetSummonerSpells(string body)
            {
                Request(RequestMethod.PATCH, "/lol-champ-select/v1/session/my-selection", body);
            }
        }

        public static class lolChat
        {
            public static string GetStatus()
            {
                return Request(RequestMethod.GET, "/lol-chat/v1/me").Result;
            }

            public static void SetStatus(string body)
            {
                _ = Request(RequestMethod.PATCH, "/lol-chat/v1/me", body);
            }
        }

        public static class lolCollections
        {
            public static string GetTopMastery(int summonerID)
            {
                return Request(RequestMethod.GET, $"/lol-collections/v1/inventories/{summonerID}/champion-mastery/top?limit=3").Result;
            }
        }

        public static class lolClash
        {
            public static string GetClashLobby()
            {
                return Request(RequestMethod.GET, "/lol-clash/v1/lobby").Result;
            }
        }
        
        public static class lolInventory
        {
            public static string GetWallet()
            {
                return Request(RequestMethod.GET, "/lol-inventory/v1/wallet/0").Result;
            }
        }

        public static class lolItemSets
        {
            public static void SetItemSet(string body)
            {
                // Update with Summoner ID
                _ = Request(RequestMethod.PUT, $"/lol-item-sets/v1/item-sets/{CurrentSummoner.SummonerId}/sets", body);
            }
        }

        public static class lolPerks
        {
            public static string CurrentPage()
            {
                return Request(RequestMethod.GET, "/lol-perks/v1/currentpage").Result;
            }

            public static void SetCurrentPage(string body)
            {
                var currentRunePage = Request(RequestMethod.GET, "/lol-perks/v1/currentpage").Result;
                int currentPageID = (int)JObject.Parse(currentRunePage)["id"]!;
                Request(RequestMethod.DELETE, $"/lol-perks/v1/pages/{currentPageID}");
                Request(RequestMethod.POST, "/lol-perks/v1/pages", body);
            }

            public static void DeletePage(int pageID)
            {
                _ = Request(RequestMethod.DELETE, $"/lol-perks/v1/pages/{pageID}").Result;
            }

            public static void CreatePage(string body)
            {
                _ = Request(RequestMethod.POST, "/lol-perks/v1/pages", body).Result;
            }
        }

        public static class lolSummoner
        {
            public static string CurrentSummoner()
            {
                return Request(RequestMethod.GET, "/lol-summoner/v1/current-summoner").Result;
            }
        }
    }
}