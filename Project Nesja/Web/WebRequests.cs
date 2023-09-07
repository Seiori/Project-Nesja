using Newtonsoft.Json.Linq;

namespace Project_Nesja.Web
{
    public class WebRequests
    {
        private static readonly HttpClient Client;

        static WebRequests()
        {
            Client = new HttpClient();
        }
        public static async Task<JToken?> GetJsonObject(string Url)
        {
            try
            {
                var response = await Client.GetStringAsync(Url);
                return JToken.Parse(response);
            }
            catch
            {
                return null;
            }
        }

        public static async Task<Image?> DownloadImage(string Url)
        {
            try
            {
                var response = await Client.GetAsync(Url);
                using var stream = await response.Content.ReadAsStreamAsync();
                var img = Image.FromStream(stream);
                return img;
            }
            catch
            {
                return null;
            }
        }
    }
}
