using Newtonsoft.Json;
using System;
using System.Net;
using System.Security.Policy;
using System.Windows.Forms;

namespace Project_Nesja
{
    public class JsonGrabber
    {
        public T GetJsonObject<T>(string url)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var json = client.DownloadString(url);
                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.NameResolutionFailure)
                {
                    MessageBox.Show("Error: Internet Connection not available.");
                    return default(T);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}