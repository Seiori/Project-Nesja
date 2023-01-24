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
        public static Region rankedSoloDuo { get; set; }
        public static Region rankedFlex { get; set; }

        static GameData()
        {
            currentVersion = "";
            aram = new object();
            rankedSoloDuo = new Region();
            rankedFlex = new Region();
        }

        public async static void FetchVersion()
        {
            currentVersion = grabber.GetJsonObject<List<string>>("https://ddragon.leagueoflegends.com/api/versions.json")[0];
        }

        public static void FetchRanked()
        {
            rankedSoloDuo.All.All.All = grabber.GetJsonObject<object>("https://op.gg/api/v1.0/internal/bypass/statistics/NA/champions/ranked?period=week&tier=all");
        }

        public async static void FetchAramData()
        {
            aram = grabber.GetJsonObject<object>("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/aram?period=month&tier=all");
        }
    }
}
