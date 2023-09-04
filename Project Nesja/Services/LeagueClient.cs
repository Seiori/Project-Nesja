using System.Security.Authentication;
using System.Diagnostics;
using System.Net;
using System.Management;
using System.Text.RegularExpressions;
using System.Text;
using WebSocketSharp;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace Project_Nesja.Services
{
    public class LeagueClient
    {
        public enum requestMethod
        {
            GET,
            POST, 
            PATCH, 
            DELETE, 
            PUT
        }

        public static HttpClient? Client;

        private WebSocket? socketConnection;

        private Tuple<Process, string, string>? ProcessInfo;

        public bool IsConnected;

        private static Regex AUTH_TOKEN_REGEX = new Regex("\"--remoting-auth-token=(.+?)\"");

        private static Regex PORT_REGEX = new Regex("\"--app-port=(\\d+?)\"");

        public LeagueClient()
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
        public Task<string> Request(requestMethod method, string url, object? body = null)
        {
            if (!IsConnected) 
                throw new InvalidOperationException("Not connected to LCU");

            string RequestMethod;

            switch (method)
            {
                case requestMethod.GET:
                    RequestMethod = "GET";
                    body = null;
                    break;
                case requestMethod.POST:
                    RequestMethod = "POST";
                    break;
                case requestMethod.PATCH:
                    RequestMethod = "PATCH";
                    break;
                case requestMethod.DELETE:
                    RequestMethod = "DELETE";
                    break;
                case requestMethod.PUT:
                    RequestMethod = "PUT";
                    break;
                default:
                    RequestMethod = "post";
                    break;
            }
            // to give the user the ability to write the uri with or without the '/' in start
            if (url[0] != '/')
            {
                url = "/" + url;
            }

            return Client!.SendAsync(new HttpRequestMessage(new HttpMethod(RequestMethod), "https://127.0.0.1:" + ProcessInfo!.Item3 + url)
            {
                Content = body == null ? null : new StringContent(body.ToString()!, Encoding.UTF8, "application/json")
            }).Result.Content.ReadAsStringAsync();
        }

        public async Task<dynamic?> getStringJsoned(string url)
        {
            if (!IsConnected) throw new InvalidOperationException("Not connected to LCU");

            var res = await Client!.GetAsync("https://127.0.0.1:" + ProcessInfo!.Item3 + url);
            var stringContent = await res.Content.ReadAsStringAsync();

            if (res.StatusCode == HttpStatusCode.NotFound) 
                return null;
            return JsonConvert.DeserializeObject(stringContent)!;
        }

        private void TryConnect()
        {
            try
            {
                if (IsConnected) return;

                var status = GetLeagueStatus();
                if (status == null) return;

                ProcessInfo = status;
                var byteArray = Encoding.ASCII.GetBytes("riot:" + status.Item2);
                Client!.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                socketConnection = new WebSocket("wss://127.0.0.1:" + status.Item3 + "/", "wamp");
                socketConnection.SetCredentials("riot", status.Item2, true);

                socketConnection.SslConfiguration.EnabledSslProtocols = SslProtocols.Tls12;
                socketConnection.SslConfiguration.ServerCertificateValidationCallback = (a, b, c, d) => true;
                socketConnection.Connect();

                ProcessInfo = status;
                IsConnected = true;
            }
            catch (Exception e)
            {
                ProcessInfo = null;
                IsConnected = false;
                if (!IsConnected) throw new InvalidOperationException($"Exception occurred trying to connect to League of Legends: {e.ToString()}");
            }
        }

        private void TryConnectOrRetry()
        {
            if (IsConnected) return;
            TryConnect();

            Task.Delay(2000).ContinueWith(a => TryConnectOrRetry());
        }

        private Tuple<Process, string, string>? GetLeagueStatus()
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

                            return new Tuple<Process, string, string>(p, authToken, port);
                        }
                        catch (Exception e)
                        {
                            throw new InvalidOperationException($"Error while trying to get the status for LeagueClientUx: {e.ToString()}\n\n(CommandLine = {commandLine})");

                        }
                    }
                }
            }
            return null;
        }
    }
}