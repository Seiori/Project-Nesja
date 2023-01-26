using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;

namespace Project_Nesja
{
    public class WebRequests
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

        public static Image DownloadImage(string url)
        {
            using (var client = new HttpClient())
            {
                var imageBytes = client.GetByteArrayAsync(url).Result;
                using (var ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
        }
    }

}
