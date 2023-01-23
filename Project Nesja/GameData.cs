using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Nesja
{
    public static class GameData
    {
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
    }
}
