using Project_Nesja.Data;
using Project_Nesja.Objects;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Data;

namespace Project_Nesja.Forms
{
    public partial class ProfileLookup : Form
    {
        private static SummonerData? Summoner;

        public ProfileLookup()
        {
            InitializeComponent();
            Summoner = new();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            Summoner = ClientData.Summoner;

            if (ClientData.LeagueClient.IsConnected)
            {
                RegionSelector.Text = Summoner.Region!.ToUpper();

                var statusMessage = ClientData.GetStatus();
                StatusMessage.Text = statusMessage.Result;

                GetSummonerData(Summoner.Name);
            }
        }

        private async void LoadSummonerData()
        {
            if (Summoner!.Name != null)
            {
                SummonerIcon.Image = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/profileicon/" + Summoner.Icon + ".png", "Icons", Summoner.Icon!);
                SummonerName.Text = Summoner.Name;
                SummonerRegion.Text = Summoner.Region!.ToUpper();
                SummonerLevel.Text = Summoner.Level!.ToString();
                SummonerRank.Text = "Ladder Ranked: " + Summoner.SoloRank!.ToString();

                RankedSoloImage.Image = GetRankedIcon(Summoner.SoloTier!.ToLower());
                RankedSoloTier.Text = Summoner.SoloTier.ToUpper();
                RankedSoloDivision.Text = Summoner.SoloDivision;
                RankedSoloGames.Text = Summoner.SoloWins.ToString() + "W " + Summoner.SoloLosses!.ToString() + "L";
                RankedSoloLP.Text = Summoner.SoloLP.ToString() + " LP";
                RankedSoloWinrate.Text = "Winrate " + System.Math.Round((float.Parse(Summoner.SoloWins) / (float.Parse(Summoner.SoloWins) + float.Parse(Summoner.SoloLosses)) * 100), 2).ToString() + "%";

                RankedFlexImage.Image = GetRankedIcon(Summoner.FlexTier!.ToLower());
                RankedFlexTier.Text = Summoner.FlexTier.ToUpper();
                RankedFlexDivision.Text = Summoner.FlexDivision;
                RankedFlexGames.Text = Summoner.FlexWins.ToString() + "W " + Summoner.FlexLosses!.ToString() + "L";
                RankedFlexLP.Text = Summoner.FlexLP.ToString() + " LP";
                float flexWins;
                float.TryParse(Summoner.FlexWins, out flexWins);
                float flexLosses;
                float.TryParse(Summoner.FlexLosses, out flexLosses);
                RankedFlexWinrate.Text = "Winrate " + System.Math.Round((flexWins / (flexWins + flexLosses) * 100), 2).ToString() + "%";
                // Calcutate Winrate, ensure values are not null before hand
            }
        }

        private void SearchPlayerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (RegionSelector.Text == "Region")
                {
                    MessageBox.Show("Please Select a Region");
                }
                else
                {
                    GetSummonerData(SearchPlayerTextBox.Text);
                }
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            GetSummonerData(Summoner!.Name!);
        }

        private async void GetSummonerData(string name)
        {
            string apiUrl = "https://pp1.xdx.gg/summoner/1/" + RegionSelector.Text.ToLower() + "/" + name.ToLower();

            Summoner = JsonConvert.DeserializeObject<SummonerData>((await WebRequests.GetJsonObject(apiUrl)).ToString());

            LoadSummonerData();
        }

        private void StatusMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ClientData.LeagueClient.IsConnected)
            {
                ClientData.SetStatus(StatusMessage.Text);
            }
        }

        private Image GetRankedIcon(string rankedTier)
        {
            switch (rankedTier.ToLower())
            {
                case "iron":
                    return Properties.Resources.iron;
                case "bronze":
                    return Properties.Resources.bronze;
                case "silver":
                    return Properties.Resources.silver;
                case "gold":
                    return Properties.Resources.gold;
                case "platinum":
                    return Properties.Resources.platinum;
                case "emerald":
                    return Properties.Resources.emerald;
                case "diamond":
                    return Properties.Resources.diamond;
                case "master":
                    return Properties.Resources.master;
                case "grandmaster":
                    return Properties.Resources.grandmaster;
                case "challenger":
                    return Properties.Resources.challenger;
                default:
                    return Properties.Resources.unranked;
            }
        }
    }
}