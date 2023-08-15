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
            try
            {
                if (subFolder != null && fileName != null)
                {
                    var directoryPath = Path.Combine("Data", subFolder);
                    Directory.CreateDirectory(directoryPath); // Create directory if it doesn't exist

                    var filePath = Path.Combine(directoryPath, fileName + ".json");

                    if (File.Exists(filePath))
                    {
                        var json = await File.ReadAllTextAsync(filePath);
                        return JToken.Parse(json);
                    }

                    var downloadedJson = await client.GetStringAsync(url);
                    await File.WriteAllTextAsync(filePath, downloadedJson);
                    return JToken.Parse(downloadedJson);
                }
                else
                {
                    var urlWithCacheBusting = url;
                    var json = await client.GetStringAsync(urlWithCacheBusting);
                    return JToken.Parse(json);
                }
            }
            catch
            {
                return null;
            }
        }

        public static async Task<Image?> DownloadImage(string url, string subFolder, string fileName)
        {
            try
            {
                var directoryPath = Path.Combine("Img", subFolder);
                Directory.CreateDirectory(directoryPath); // Create directory if it doesn't exist

                var filePath = Path.Combine(directoryPath, fileName + ".jpg");

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
            catch
            {
                return null;
            }
        }
    }
}
