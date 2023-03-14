using Project_Nesja.Data;
using Project_Nesja.Objects;
using Newtonsoft.Json.Linq;

namespace Project_Nesja.Forms
{
    public partial class ProfileLookup : Form
    {
        Summoner Summoner = ClientData.Summoner;
        public ProfileLookup()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            SearchPlayerListBox.Visible = false;

            if (Summoner.Name != null)
            {
                RegionSelector.Text = Summoner.Region!.ToUpper();
                UpdateButton.PerformClick();
            }
        }

        private async void LoadSummonerData()
        {
            SummonerIcon.Image = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/profileicon/" + Summoner.IconID + ".png", "Icons", Summoner.IconID.ToString());
            SummonerName.Text = Summoner.Name;
            SummonerRegion.Text = Summoner.Region!.ToUpper();
            SummonerLevel.Text = Summoner.Level.ToString();
            SummonerRank.Text = "Ladder Ranked: " + Summoner.SoloRank.ToString();

            RankedSoloImage.Image = await WebRequests.DownloadImage("https://cdn.xdx.gg/op/img/emblems/" + Summoner.SoloTier.ToLower() + ".png", "RankedIcons", Summoner.SoloTier.ToLower());
            RankedSoloTier.Text = Summoner.SoloTier.ToUpper();
            RankedSoloDivision.Text = Summoner.SoloDivision;
            RankedSoloGames.Text = Summoner.SoloWins.ToString() + "W " + Summoner.SoloLosses.ToString() + "L";
            RankedSoloLP.Text = Summoner.SoloLP.ToString() + " LP";
            RankedSoloWinrate.Text = "Winrate " + System.Math.Round(((float)Summoner.SoloWins / ((float)Summoner.SoloWins + (float)Summoner.SoloLosses) * 100), 2).ToString() + "%";

            RankedFlexImage.Image = await WebRequests.DownloadImage("https://cdn.xdx.gg/op/img/emblems/" + Summoner.FlexTier.ToLower() + ".png", "RankedIcons", Summoner.FlexTier.ToLower());
            RankedFlexTier.Text = Summoner.FlexTier.ToUpper();
            RankedFlexDivision.Text = Summoner.FlexDivision;
            RankedFlexGames.Text = Summoner.FlexWins.ToString() + "W " + Summoner.FlexLosses.ToString() + "L";
            RankedFlexLP.Text = Summoner.FlexLP.ToString() + " LP";
            RankedFlexWinrate.Text = "Winrate " + System.Math.Round(((float)Summoner.FlexWins / ((float)Summoner.FlexWins + (float)Summoner.FlexLosses) * 100), 2).ToString() + "%";
        }
        
        private static async Task<JObject?> FetchSummonerData(string apiUrl)
        {
            return await WebRequests.GetJsonObject(apiUrl) as JObject;
        }

        private static Summoner ParseSummonerData(JObject summonerData)
        {
            Summoner summoner = new()
            {
                Name = summonerData["name"]?.ToString(),
                Region = summonerData["region"]?.ToString(),
                Level = int.TryParse(summonerData["level"]?.ToString(), out int level) ? level : 0,
                IconID = int.TryParse(summonerData["icon"]?.ToString(), out int iconID) ? iconID : 0,
                SoloRank = int.TryParse(summonerData["solo-rank"]?.ToString(), out int soloRank) ? soloRank : 0,
                SoloTier = string.IsNullOrEmpty(summonerData["solo-tier"]?.ToString()) ? "unranked" : summonerData["solo-tier"]?.ToString().ToLower(),
                SoloDivision = summonerData["solo-division"]?.ToString(),
                SoloLP = int.TryParse(summonerData["solo-lp"]?.ToString(), out int soloLP) ? soloLP : 0,
                SoloWins = int.TryParse(summonerData["solo-wins"]?.ToString(), out int soloWins) ? soloWins : 0,
                SoloLosses = int.TryParse(summonerData["solo-losses"]?.ToString(), out int soloLosses) ? soloLosses : 0,
                FlexTier = string.IsNullOrEmpty(summonerData["flex-tier"]?.ToString()) ? "unranked" : summonerData["flex-tier"]?.ToString().ToLower(),
                FlexDivision = summonerData["flex-division"]?.ToString(),
                FlexLP = int.TryParse(summonerData["flex-lp"]?.ToString(), out int flexLP) ? flexLP : 0,
                FlexWins = int.TryParse(summonerData["flex-wins"]?.ToString(), out int flexWins) ? flexWins : 0,
                FlexLosses = int.TryParse(summonerData["flex-losses"]?.ToString(), out int flexLosses) ? flexLosses : 0
            };

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