using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;

namespace Project_Nesja
{
    public class JsonGrabber
    {
        public static JToken? GetJsonObject(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = client.GetStringAsync(url).Result;
                    return JToken.Parse(json);
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.NameResolutionFailure)
                {
                    Console.WriteLine("Error: Internet Connection not available.");
                    return default;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
