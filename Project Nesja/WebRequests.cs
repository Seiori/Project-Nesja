using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;

namespace Project_Nesja
{
    public class WebRequests
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<JToken?> GetJsonObject(string url, string filePath = null, bool forceDownload = false)
        {
            if (!forceDownload && filePath != null && File.Exists(filePath))
            {
                var jsonString = File.ReadAllText(filePath);
                return JToken.Parse(jsonString);
            }
            else
            {
                try
                {
                    var json = await client.GetStringAsync(url);
                    if (filePath != null)
                    {
                        if (!File.Exists(filePath))
                        {
                            using (File.Create(filePath))
                            {
                                // the using statement will dispose the stream after it's done
                            }
                        }
                        File.WriteAllText(filePath, json);
                    }
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
        }


        public static async Task<Image?> DownloadImage(string url, string subFolder, string fileName)
        {
            var filePath = Path.Combine("Img", subFolder, fileName + ".jpg");

            if (File.Exists(filePath))
            {
                using (var fileStream = File.OpenRead(filePath))
                {
                    var img = Image.FromStream(fileStream);
                    return img;
                }
            }
            else
            {
                var imageBytes = await client.GetByteArrayAsync(url);
                using (var ms = new MemoryStream(imageBytes))
                {
                    var img = Image.FromStream(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    File.WriteAllBytes(filePath, imageBytes);
                    return img;
                }
            }
        }
    }
}