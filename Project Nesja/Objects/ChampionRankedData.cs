using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Nesja.Objects
{
    public class ChampionRankedData
    {
        public JObject? Header;
        public JObject? Summary;
        public JObject? Graph;
        public JObject? Nav;
        public int Analysed;
        public float AvgWinRate;
        public JArray? Top;
        public JArray? Depth;
        public int N;
        public JObject? Skills;
        public JObject? Time;
        public JObject? TimeWin;
        public JObject? TopStats;
        public JArray? Stats;
        public int StatsCount;
        public JObject? Runes;
        public JObject? Objective;
        public JArray? Spell;
        public JArray? Spells;
        public JObject? ItemSets;
        public JArray? StartItem;
        public JArray? StartSet;
        public JArray? EarlyItem;
        public JArray? Boots;
        public JArray? MythicItem;
        public JArray? PopularItem;
        public JArray? WinningItem;
        public JArray? Item;
        public JArray? Item1;
        public JArray? Item2;
        public JArray? Item3;
        public JArray? Item4;
        public JArray? Item5;
        public JArray? Enemy_Top;
        public JArray? Enemy_Jungle;
        public JArray? Enemy_Middle;
        public JArray? Enemy_Bottom;
        public JArray? Enemy_Support;
        public JObject? Response;

        public JArray GetOppositeRole(string role)
        {
            switch (role)
            {
                case "top":
                    return Enemy_Top!;
                case "jungle":
                    return Enemy_Jungle!;
                case "middle":
                    return Enemy_Middle!;
                case "bottom":
                    return Enemy_Bottom!;
                case "support":
                    return Enemy_Support!;
                default:
                    return new JArray();
            }
        }
    }
}
