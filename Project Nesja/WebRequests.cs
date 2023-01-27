using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;

namespace Project_Nesja
{
    public class WebRequests
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<JToken?> GetJsonObject(string url)
        {
            try
            {
                var json = await client.GetStringAsync(url);
                return JToken.Parse(json);
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

        public static async Task<Image?> DownloadImage(string url)
        {
            var imageBytes = await client.GetByteArrayAsync(url);
            using (var ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }
    }
}