﻿using Project_Nesja.Data;
using Project_Nesja.Objects;
using Newtonsoft.Json;

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
            if (ClientData.LeagueClient.IsConnected)
            {
                RegionSelector.Text = ClientData.Summoner.Region;

                GetSummonerData(ClientData.Summoner.Name!);
            }
        }

        private async void LoadSummonerData()
        {
            // Display Summoner Data
            SummonerIcon.Image = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/profileicon/" + Summoner.Icon + ".png", "Icons", Summoner.Icon!);
            SummonerName.Text = Summoner.Name;
            SummonerRegion.Text = Summoner.Region!.ToUpper();
            SummonerLevel.Text = Summoner.Level!.ToString();
            SummonerRank.Text = "Ladder Ranked: " + Summoner.SoloRank!.ToString();

            // Display Solo Data
            RankedSoloImage.Image = GetRankedIcon(Summoner.SoloTier!.ToLower());
            RankedSoloTier.Text = Summoner.SoloTier.ToUpper();
            RankedSoloDivision.Text = Summoner.SoloDivision;
            RankedSoloGames.Text = Summoner.SoloWins!.ToString() + "W " + Summoner.SoloLosses!.ToString() + "L";
            RankedSoloLP.Text = Summoner.SoloLP!.ToString() + " LP";

            float.TryParse(Summoner.SoloWins, out float soloWins);
            float.TryParse(Summoner.SoloLosses, out float soloLosses);
            RankedSoloWinrate.Text = "Winrate " + System.Math.Round((soloWins / (soloWins + soloLosses) * 100), 2).ToString() + "%";

            // Display Flex Data
            RankedFlexImage.Image = GetRankedIcon(Summoner.FlexTier!.ToLower());
            RankedFlexTier.Text = Summoner.FlexTier.ToUpper();
            RankedFlexDivision.Text = Summoner.FlexDivision;
            RankedFlexGames.Text = Summoner.FlexWins!.ToString() + "W " + Summoner.FlexLosses!.ToString() + "L";
            RankedFlexLP.Text = Summoner.FlexLP!.ToString() + " LP";

            float.TryParse(Summoner.FlexWins, out float flexWins);
            float.TryParse(Summoner.FlexLosses, out float flexLosses);
            RankedFlexWinrate.Text = "Winrate " + System.Math.Round((flexWins / (flexWins + flexLosses) * 100), 2).ToString() + "%";
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

            var summonderData = await WebRequests.GetJsonObject(apiUrl);

            if (summonderData != null)
            {
                Summoner = JsonConvert.DeserializeObject<SummonerData>((string)summonderData!);

                LoadSummonerData();
            }
            else
            {
                MessageBox.Show("Incorrect Summoner Name, Please Check the Summoner Name or Region");
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