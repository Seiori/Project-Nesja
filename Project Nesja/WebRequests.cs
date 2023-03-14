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

        public static async Task<JToken?> GetJsonObject(string url, string subFolder = null!, string fileName = null!)
        {
            if (subFolder == null && fileName == null)
            {
                var json = await client.GetStringAsync(url);
                return JToken.Parse(json);
            }

            var filePath = Path.Combine("Data", subFolder!, fileName + ".json");

            if (File.Exists(filePath))
            {
                var json = await File.ReadAllTextAsync(filePath);
                return JToken.Parse(json);
            }

            var downloadedJson = await client.GetStringAsync(url);
            await File.WriteAllTextAsync(filePath, downloadedJson);
            return JToken.Parse(downloadedJson);
        }

        public static async Task<Image?> DownloadImage(string url, string subFolder, string fileName)
        {
            var filePath = Path.Combine("Img", subFolder, fileName + ".jpg");

            if (File.Exists(filePath))
            {
                using var fileStream = File.OpenRead(filePath);
                var img = Image.FromStream(fileStream);
                return img;
            }
            else
            {
                var imageBytes = await client.GetByteArrayAsync(url);
                using var ms = new MemoryStream(imageBytes);
                var img = Image.FromStream(ms);
                ms.Seek(0, SeekOrigin.Begin);
                File.WriteAllBytes(filePath, imageBytes);
                return img;
            }
        }
    }
}
