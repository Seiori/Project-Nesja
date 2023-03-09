using Newtonsoft.Json.Linq;
using Project_Nesja.Data;
using Project_Nesja.Objects;

namespace Project_Nesja.Forms
{
    public partial class Profile : Form
    {
        private SummonerData Summoner;
        public Profile()
        {
            InitializeComponent();
            this.Summoner = new SummonerData();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            SearchPlayerListBox.Visible = false;
        }

        private async void LoadSummonerData()
        {
            SummonerIcon.Image = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/profileicon/" + Summoner.IconID + ".png", "Icons", Summoner.IconID.ToString());
            SummonerName.Text = Summoner.Name;
            SummonerRegion.Text = Summoner.Region.ToUpper();
            SummonerLevel.Text = Summoner.Level.ToString();
            SummonerRank.Text = "Ladder Ranked: " + Summoner.SoloRank.ToString();

            RankedSoloImage.Image = await WebRequests.DownloadImage("https://cdn.xdx.gg/op/img/emblems/" + Summoner.SoloTier.ToLower() + ".png", "RankedIcons", Summoner.SoloTier.ToLower());
            RankedSoloTier.Text = Summoner.SoloTier;
            RankedSoloDivision.Text = Summoner.SoloDivision;
            RankedSoloGames.Text = Summoner.SoloWins.ToString() + "W " + Summoner.SoloLosses.ToString() + "L";
            RankedSoloLP.Text = Summoner.SoloLP.ToString() + " LP";
            RankedSoloWinrate.Text = "Winrate " + System.Math.Round(((float)Summoner.SoloWins / ((float)Summoner.SoloWins + (float)Summoner.SoloLosses) * 100), 2).ToString() + "%";

            RankedFlexImage.Image = await WebRequests.DownloadImage("https://cdn.xdx.gg/op/img/emblems/" + Summoner.FlexTier.ToLower() + ".png", "RankedIcons", Summoner.FlexTier.ToLower());
            RankedFlexTier.Text = Summoner.FlexTier;
            RankedFlexDivision.Text = Summoner.FlexDivision;
            RankedFlexGames.Text = Summoner.FlexWins.ToString() + "W " + Summoner.FlexLosses.ToString() + "L";
            RankedFlexLP.Text = Summoner.FlexLP.ToString() + " LP";
            RankedFlexWinrate.Text = "Winrate " + System.Math.Round(((float)Summoner.FlexWins / ((float)Summoner.FlexWins + (float)Summoner.FlexLosses) * 100), 2).ToString() + "%";
        }

        private async Task<JObject> FetchSummonerData(string apiUrl)
        {
            return (JObject)await WebRequests.GetJsonObject(apiUrl);
        }

        private SummonerData ParseSummonerData(JObject summonerData)
        {
            SummonerData summoner = new SummonerData();

            summoner.Name = summonerData["name"]?.ToString();
            summoner.Region = summonerData["region"]?.ToString();
            summoner.Level = int.TryParse(summonerData["level"]?.ToString(), out int level) ? level : 0;
            summoner.IconID = int.TryParse(summonerData["icon"]?.ToString(), out int iconID) ? iconID : 0;
            summoner.SoloRank = int.TryParse(summonerData["solo-rank"]?.ToString(), out int soloRank) ? soloRank : 0;
            summoner.SoloTier = string.IsNullOrEmpty(summonerData["solo-tier"]?.ToString()) ? "unranked" : summonerData["solo-tier"].ToString().ToLower();
            summoner.SoloDivision = summonerData["solo-division"]?.ToString();
            summoner.SoloLP = int.TryParse(summonerData["solo-lp"]?.ToString(), out int soloLP) ? soloLP : 0;
            summoner.SoloWins = int.TryParse(summonerData["solo-wins"]?.ToString(), out int soloWins) ? soloWins : 0;
            summoner.SoloLosses = int.TryParse(summonerData["solo-losses"]?.ToString(), out int soloLosses) ? soloLosses : 0;
            summoner.FlexTier = string.IsNullOrEmpty(summonerData["flex-tier"]?.ToString()) ? "unranked" : summonerData["flex-tier"].ToString().ToLower();
            summoner.FlexDivision = summonerData["flex-division"]?.ToString();
            summoner.FlexLP = int.TryParse(summonerData["flex-lp"]?.ToString(), out int flexLP) ? flexLP : 0;
            summoner.FlexWins = int.TryParse(summonerData["flex-wins"]?.ToString(), out int flexWins) ? flexWins : 0;
            summoner.FlexLosses = int.TryParse(summonerData["flex-losses"]?.ToString(), out int flexLosses) ? flexLosses : 0;

            return summoner;
        }
        
        private async void SearchPlayerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string apiUrl = "https://api.xdx.gg/summoner/1/" + RegionSelector.Text.ToLower() + "/" + SearchPlayerTextBox.Text + "/?cache_bust=" + DateTime.UtcNow.Ticks;

                Summoner = ParseSummonerData(await FetchSummonerData(apiUrl));
                
                LoadSummonerData();
            }
        }
        
        private void SearchPlayerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            string apiUrl = "https://api.xdx.gg/summoner/1/" + RegionSelector.Text.ToLower() + "/" + Summoner.Name + "/?cache_bust=" + DateTime.UtcNow.Ticks;

            Summoner = ParseSummonerData(await FetchSummonerData(apiUrl));

            LoadSummonerData();
        }
    }
}
