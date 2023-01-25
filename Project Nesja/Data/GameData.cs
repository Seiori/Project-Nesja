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
        static JsonGrabber grabber = new JsonGrabber();
        public static string currentVersion { get; set; }
        public static object aram { get; set; }
        public static Ranks rankedQueue { get; set; }
        public static Champions champions { get; set; }

        static GameData()
        {
            currentVersion = "";
            aram = new object();
            rankedQueue = new Ranks();
            champions = new Champions();
        }

        public async static void FetchData()
        {
            // Grabs Current Live Patch Version
            currentVersion = grabber.GetJsonObject<List<string>>("https://ddragon.leagueoflegends.com/api/versions.json")[0];

            // Grabs Last Month of Aram Games Data, Global
            aram = grabber.GetJsonObject<object>("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/aram?period=month&tier=all");

            // Grabs Last 7 Days of Ranked Solo/Duo Games
            rankedQueue.All.All = grabber.GetJsonObject<object>("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/ranked?period=week&tier=all");
            rankedQueue.All.Top = grabber.GetJsonObject<object>("https://op.gg/api/v1.0/internal/bypass/statistics/th/champions/ranked?period=week&tier=all&position=top");
            rankedQueue.All.Jungle = grabber.GetJsonObject<object>("https://op.gg/api/v1.0/internal/bypass/statistics/th/champions/ranked?period=week&tier=all&position=jungle");
            rankedQueue.All.Mid = grabber.GetJsonObject<object>("https://op.gg/api/v1.0/internal/bypass/statistics/th/champions/ranked?period=week&tier=all&position=mid");
            rankedQueue.All.ADC = grabber.GetJsonObject<object>("https://op.gg/api/v1.0/internal/bypass/statistics/th/champions/ranked?period=week&tier=all&position=adc");
            rankedQueue.All.Support = grabber.GetJsonObject<object>("https://op.gg/api/v1.0/internal/bypass/statistics/th/champions/ranked?period=week&tier=all&position=support");

            // Grabs All Champion Data
            champions.championData = grabber.GetJsonObject<object>("http://ddragon.leagueoflegends.com/cdn/" + currentVersion + "/data/en_US/champion.json");
        }
    }
}
