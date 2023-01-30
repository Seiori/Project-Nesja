using Newtonsoft.Json.Linq;
using System.Net;

namespace Project_Nesja.Recommenders
{
    public class Champion
    {
        private readonly ChampionData championData;
        public Champion(ChampionData championData)
        {
            this.championData = championData;
            GetRecommendations();
        }

        private async Task GetRecommendations()
        {
            var championInformation = await WebRequests.GetJsonObject("https://www.op.gg/champions/lux/support/runes?region=global&tier=platinum_plus");
        }

        private async Task GetAbilityOrder()
        {
            
        }

        private async Task GetItemBuild()
        {
            
        }

        private async Task GetRuneSetup()
        {
            
        }

        private async Task GetMatchupData()
        {
            
        }
    }
}