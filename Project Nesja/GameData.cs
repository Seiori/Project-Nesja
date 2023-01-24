using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Project_Nesja
{
    public static class GameData
    {
        static JsonGrabber grabber = new JsonGrabber();
        public static string currentVersion { get; set; }
        public static object aram { get; set; }

        public static RankedQueue rankedSoloDuo { get; set; }
        public static RankedQueue rankedFlex { get; set; }

        static GameData()
        {
            currentVersion = "";
            aram = new object();
            rankedSoloDuo = new RankedQueue();
            rankedFlex = new RankedQueue();
        }
        
        public async static void FetchVersion()
        {
            currentVersion = grabber.GetJsonObject<List<string>>("https://ddragon.leagueoflegends.com/api/versions.json")[0];
        }
        
        public static void FetchRankedData()
        {
            
        }

        public async static void FetchAramData()
        {
            aram = grabber.GetJsonObject<object>("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/aram?period=month&tier=all");
        }
    }
}
