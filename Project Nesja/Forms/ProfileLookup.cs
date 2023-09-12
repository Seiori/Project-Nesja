using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project_Nesja.Services;
using Project_Nesja.Web;
using System.Collections.Concurrent;
using System.Windows.Forms;
using System.Windows.Documents;
using Project_Nesja.Models;

namespace Project_Nesja.Forms
{
    public partial class ProfileLookup : Form
    {
        ConcurrentBag<JObject> Matches = new ConcurrentBag<JObject>();

        public ProfileLookup()
        {
            InitializeComponent();

            if (LeagueClient.IsConnected)
            {
                RegionSelector.Text = JObject.Parse(LeagueClient.Default.RegionLocale())["locale"]!.ToString();
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {

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
            GetSummonerData(SearchPlayerTextBox.Text);
        }

        private async void GetSummonerData(string summonerName)
        {
            JObject summonerData = JObject.Parse(RiotAPI.GetSummonerBySummonerName(RiotAPI.Platform.EUW1, summonerName));
            JArray rankedData = JArray.Parse(RiotAPI.GetLeagueEntriesInAllQueuesBySummonerID(RiotAPI.Platform.EUW1, summonerData["id"]!.ToString()));

            SummonerIcon.Image = await WebRequests.DownloadImage("http://ddragon.leagueoflegends.com/cdn/" + GameData.CurrentVersion + "/img/profileicon/" + summonerData["profileIconId"]!.ToString() + ".png");
            SummonerName.Text = summonerData["name"]!.ToString();
            SummonerRegion.Text = RegionSelector.Text;
            SummonerLevel.Text = summonerData["summonerLevel"]!.ToString();
            //SummonerRank.Text = "Ladder Ranked: " + Summoner.SoloRank!.ToString();

            // Reset Ranked Form Data
            RankedSoloImage.Image = GetRankedIcon("unranked");
            RankedSoloTier.Text = "N/A";
            RankedSoloDivision.Text = "N/A";
            RankedSoloGames.Text = "N/A";
            RankedSoloLP.Text = "N/A";

            RankedFlexImage.Image = GetRankedIcon("unranked");
            RankedFlexTier.Text = "N/A";
            RankedFlexDivision.Text = "N/A";
            RankedFlexGames.Text = "N/A";
            RankedFlexLP.Text = "N/A";

            // Assign New Summoner Data
            foreach (var rankedQueue in rankedData)
            {
                if (rankedQueue["queueType"]!.ToString() == "RANKED_SOLO_5x5")
                {
                    RankedSoloImage.Image = GetRankedIcon(rankedQueue["tier"]!.ToString().ToLower());
                    RankedSoloTier.Text = rankedQueue["tier"]!.ToString();
                    RankedSoloDivision.Text = rankedQueue["rank"]!.ToString();
                    RankedSoloGames.Text = rankedQueue["wins"] + "W " + rankedQueue["losses"] + "L";
                    RankedSoloLP.Text = rankedQueue["leaguePoints"] + " LP";

                    float.TryParse((string?)rankedQueue["wins"]!, out float soloWins);
                    float.TryParse((string?)rankedQueue["losses"]!, out float soloLosses);
                    RankedSoloWinrate.Text = "Winrate " + System.Math.Round((soloWins / (soloWins + soloLosses) * 100), 2).ToString() + "%";
                }
                else
                {
                    RankedFlexImage.Image = GetRankedIcon(rankedQueue["tier"]!.ToString().ToLower());
                    RankedFlexTier.Text = rankedQueue["tier"]!.ToString();
                    RankedFlexDivision.Text = rankedQueue["rank"]!.ToString();
                    RankedFlexGames.Text = rankedQueue["wins"] + "W " + rankedQueue["losses"] + "L";
                    RankedFlexLP.Text = rankedQueue["leaguePoints"] + " LP";

                    float.TryParse((string?)rankedQueue["wins"], out float flexWins);
                    float.TryParse((string?)rankedQueue["losses"], out float flexLosses);
                    RankedFlexWinrate.Text = "Winrate " + System.Math.Round((flexWins / (flexWins + flexLosses) * 100), 2).ToString() + "%";
                }
            }

            JArray matchHistory = JArray.Parse(RiotAPI.GetMatchesbyPUUID(RiotAPI.Region.EUROPE, summonerData["puuid"]!.ToString(), 0, 0, 0, null, 0, 20));

            Parallel.ForEach(matchHistory, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, matchID => ProcessMatch(matchID.ToString()).Wait());

            string result = "";
            int championID = 0;
            int kills = 0;
            int deaths = 0;
            int assists = 0;

            // Order Matches
            Matches = new ConcurrentBag<JObject>(Matches.OrderBy(x => x["info"]!["gameCreation"]!.ToObject<long>()));

            MatchInfoControl matchInfoControl;

            foreach (var matchInfo in Matches)
            {
                foreach (var participant in matchInfo["info"]!["participants"]!)
                {
                    if (participant["puuid"]!.ToString() == summonerData["puuid"]!.ToString())
                    {
                        result = participant["win"]!.ToString();
                        championID = int.Parse(participant["championId"]!.ToString());
                        kills = int.Parse(participant["kills"]!.ToString());
                        deaths = int.Parse(participant["deaths"]!.ToString());
                        assists = int.Parse(participant["assists"]!.ToString());

                        matchInfoControl = new MatchInfoControl(result, GameData.ChampionList!.First(x => x.Key == championID).Value.Sprite!, kills + "/" + deaths + "/" + assists);

                        flowLayoutPanel.Controls.Add(matchInfoControl);
                        break;
                    }
                }
            }
        }

        private Task ProcessMatch(string matchID)
        {
            try
            {
                JObject match = JObject.Parse(RiotAPI.GetMatchesbyMatchID(RiotAPI.Region.EUROPE, matchID.ToString()));

                Matches.Add(match);

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                MessageBox.Show($"Error processing match {matchID}: {ex.Message}");

                return Task.CompletedTask;
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