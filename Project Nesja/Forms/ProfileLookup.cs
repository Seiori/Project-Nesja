using Project_Nesja.Data;
using Project_Nesja.Objects;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Project_Nesja.Forms
{
    public partial class ProfileLookup : Form
    {
        private static Summoner Summoner;
        public ProfileLookup()
        {
            InitializeComponent();
            Summoner = new();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            Summoner = ClientData.Summoner;
            if (Summoner.Name != null)
            {
                RegionSelector.Text = Summoner.Region!.ToUpper();

                var statusMessage = ClientData.GetStatus();
                StatusMessage.Text = statusMessage.Result;

                UpdateButton.PerformClick();
            }
            else
            {
                SummonerName.Text = "Client not Connected!";
            }
        }

        private async void LoadSummonerData()
        {
            if (Summoner.Name != null)
            {
                SummonerIcon.Image = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/profileicon/" + Summoner.IconID + ".png", "Icons", Summoner.IconID.ToString());
                SummonerName.Text = Summoner.Name;
                SummonerRegion.Text = Summoner.Region!.ToUpper();
                SummonerLevel.Text = Summoner.Level.ToString();
                SummonerRank.Text = "Ladder Ranked: " + Summoner.SoloRank.ToString();

                RankedSoloImage.Image = GetRankedIcon(Summoner.SoloTier!.ToLower());
                RankedSoloTier.Text = Summoner.SoloTier.ToUpper();
                RankedSoloDivision.Text = Summoner.SoloDivision;
                RankedSoloGames.Text = Summoner.SoloWins.ToString() + "W " + Summoner.SoloLosses.ToString() + "L";
                RankedSoloLP.Text = Summoner.SoloLP.ToString() + " LP";
                RankedSoloWinrate.Text = "Winrate " + System.Math.Round(((float)Summoner.SoloWins / ((float)Summoner.SoloWins + (float)Summoner.SoloLosses) * 100), 2).ToString() + "%";

                RankedFlexImage.Image = GetRankedIcon(Summoner.FlexTier!.ToLower());
                RankedFlexTier.Text = Summoner.FlexTier.ToUpper();
                RankedFlexDivision.Text = Summoner.FlexDivision;
                RankedFlexGames.Text = Summoner.FlexWins.ToString() + "W " + Summoner.FlexLosses.ToString() + "L";
                RankedFlexLP.Text = Summoner.FlexLP.ToString() + " LP";
                RankedFlexWinrate.Text = "Winrate " + System.Math.Round(((float)Summoner.FlexWins / ((float)Summoner.FlexWins + (float)Summoner.FlexLosses) * 100), 2).ToString() + "%";
            }

            //JObject top3Champions = ClientData.GetTopMastery(Summoner.SummonerID).Result;
            //FirstChampion.Image = GameData.ChampionList.First(x => x.Value.ID == top3Champions.First!.First!.ElementAt(0).SelectToken("championId")!.ToObject<int>()).Value.Sprite;
            //SecondChampion.Image = GameData.ChampionList.First(x => x.Value.ID == top3Champions.First!.First!.ElementAt(1).SelectToken("championId")!.ToObject<int>()).Value.Sprite;
            //ThirdChampion.Image = GameData.ChampionList.First(x => x.Value.ID == top3Champions.First!.First!.ElementAt(2).SelectToken("championId")!.ToObject<int>()).Value.Sprite;
        }

        private static async Task<JObject?> FetchSummonerData(string apiUrl)
        {
            return await WebRequests.GetJsonObject(apiUrl) as JObject;
        }

        private static Summoner ParseSummonerData(JObject summonerData)
        {
            Summoner.Name = summonerData["name"]?.ToString();
            Summoner.Region = summonerData["region"]?.ToString();
            Summoner.Level = int.TryParse(summonerData["level"]?.ToString(), out int level) ? level : 0;
            Summoner.IconID = int.TryParse(summonerData["icon"]?.ToString(), out int iconID) ? iconID : 0;
            Summoner.SoloRank = int.TryParse(summonerData["solo-rank"]?.ToString(), out int soloRank) ? soloRank : 0;
            Summoner.SoloTier = string.IsNullOrEmpty(summonerData["solo-tier"]?.ToString()) ? "unranked" : summonerData["solo-tier"]?.ToString().ToLower();
            Summoner.SoloDivision = summonerData["solo-division"]?.ToString();
            Summoner.SoloLP = int.TryParse(summonerData["solo-lp"]?.ToString(), out int soloLP) ? soloLP : 0;
            Summoner.SoloWins = int.TryParse(summonerData["solo-wins"]?.ToString(), out int soloWins) ? soloWins : 0;
            Summoner.SoloLosses = int.TryParse(summonerData["solo-losses"]?.ToString(), out int soloLosses) ? soloLosses : 0;
            Summoner.FlexTier = string.IsNullOrEmpty(summonerData["flex-tier"]?.ToString()) ? "unranked" : summonerData["flex-tier"]?.ToString().ToLower();
            Summoner.FlexDivision = summonerData["flex-division"]?.ToString();
            Summoner.FlexLP = int.TryParse(summonerData["flex-lp"]?.ToString(), out int flexLP) ? flexLP : 0;
            Summoner.FlexWins = int.TryParse(summonerData["flex-wins"]?.ToString(), out int flexWins) ? flexWins : 0;
            Summoner.FlexLosses = int.TryParse(summonerData["flex-losses"]?.ToString(), out int flexLosses) ? flexLosses : 0;
            Summoner.Matches = new List<Match>();

            foreach (var match in summonerData["matches"].Children())
            {
                Match tempMatch = new Match();

                tempMatch.GameID = match[0]!.ToObject<double>();    // First element

                if (match.Count() == 4)
                {
                    tempMatch.ChampionID = int.TryParse(match[1]!.ToString(), out int championID) ? championID : 0;   // Second element
                    tempMatch.QueueID = int.TryParse(match[2]!.ToString(), out int queueID) ? queueID : 0;      // Third element
                    tempMatch.UnixTime = int.TryParse(match[3]!.ToString(), out int unixTime) ? unixTime : 0;  // Fourth element
                }

                Summoner.Matches.Add(tempMatch);
            }

            return Summoner;
        }

        private async void SearchPlayerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (RegionSelector.Text == "Region")
                {
                    MessageBox.Show("Please Select a Region");
                }
                else
                {
                    string apiUrl = "https://pp1.xdx.gg/summoner/1/" + RegionSelector.Text.ToLower() + "/" + SearchPlayerTextBox.Text;

                    Summoner = ParseSummonerData(await FetchSummonerData(apiUrl));

                    LoadSummonerData();
                }
            }
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            string apiUrl = "https://pp1.xdx.gg/summoner/1/" + RegionSelector.Text.ToLower() + "/" + Summoner.Name.ToLower();

            Summoner = ParseSummonerData(await FetchSummonerData(apiUrl));

            LoadSummonerData();
        }

        private async void StatusMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ClientData.LeagueClient.IsConnected)
            {
                await ClientData.SetStatus(StatusMessage.Text);
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