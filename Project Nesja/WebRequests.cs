using Newtonsoft.Json.Linq;

namespace Project_Nesja
{
    public class WebRequests
    {
        private static readonly HttpClientHandler handler = new();
        private static readonly HttpClient client;

        static WebRequests()
        {
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            client = new HttpClient(handler);
            client.DefaultRequestHeaders.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue();
        }

        public static async Task<JToken?> GetJsonObject(string url)
        {
            try
            {
                var urlWithCacheBusting = url;
                var json = await client.GetStringAsync(urlWithCacheBusting);
                return JToken.Parse(json);
            }
            catch
            {
                return null;
            }
        }

        public static async Task<Image?> DownloadImage(string url)
        {
            try
            {
                var imageBytes = await client.GetByteArrayAsync(url);
                using var ms = new MemoryStream(imageBytes);
                var img = Image.FromStream(ms);
                return img;
            }
            catch
            {
                return null;
            }
        }
    }
}
