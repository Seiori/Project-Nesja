using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Project_Nesja.Data
{
    public static class GameData
    {
        public static string? CurrentVersion { get; set; }
        public static JObject? Champions { get; set; }
        public static List<string> ChampionList { get; set; }
        public static JObject? Aram { get; set; }
        public static Ranks RankedQueue { get; set; }

        static GameData()
        {
            CurrentVersion = "";
            Champions = new JObject();
            ChampionList = new List<string>();
            Aram = new JObject();
            RankedQueue = new Ranks();
        }

        public static void FetchGameData()
        {
            // Grabs Current Live Patch Version
            CurrentVersion = JsonGrabber.GetJsonObject("https://ddragon.leagueoflegends.com/api/versions.json").First.ToString();

            // Grabs All Champion Data
            Champions = (JObject?)JsonGrabber.GetJsonObject("http://ddragon.leagueoflegends.com/cdn/" + CurrentVersion + "/data/en_US/champion.json").SelectToken("data");

            // Grabs a List of Champions
            // Grabs Last Month of Aram Games Data, Global
            Aram = (JObject?)JsonGrabber.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/aram?period=month&tier=all");

            // Grabs Last 7 Days of Ranked Solo/Duo Games
            RankedQueue.All.All = (JObject?)JsonGrabber.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all");
            RankedQueue.All.Top = (JObject?)JsonGrabber.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=top");
            RankedQueue.All.Jungle = (JObject?)JsonGrabber.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=jungle");
            RankedQueue.All.Mid = (JObject?)JsonGrabber.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=mid");
            RankedQueue.All.ADC = (JObject?)JsonGrabber.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=adc");
            RankedQueue.All.Support = (JObject?)JsonGrabber.GetJsonObject("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all&position=support");
        }

    }
}
