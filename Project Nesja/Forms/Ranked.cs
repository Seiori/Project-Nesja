using Newtonsoft.Json.Linq;
using Project_Nesja.Data;
using System.Diagnostics;

namespace Project_Nesja.Forms
{
    public partial class Ranked : Form
    {
        private readonly MainMenu mainForm;
        private Dictionary<int, ChampionRole> rankedQueueData;
        private Dictionary<int, JObject> rankedQueue;
        private string currentRole;
        private float minLanerate = 2f;
        private float minGamesPlayed = 100;
        private float minPickrate = 2;

        public Ranked(MainMenu mainMenu)
        {
            InitializeComponent();
            this.mainForm = mainMenu;
            rankedQueueData = new Dictionary<int, ChampionRole>(GameData.ChampionList.Count);
            rankedQueue = new Dictionary<int, JObject>();
            currentRole = "default";
        }

        private void Ranked_Load(object sender, EventArgs e)
        {
            RankLevelSelection.SelectedIndex = 10;
        }

        private async void GetRankedData()
        {
            rankedQueue.Clear();

            string apiUrl = "";

            if (RankLevelSelection.SelectedIndex == 9)
            {
                apiUrl = $"https://ax.lolalytics.com/patch/1/?patch=" + GameData.CurrentVersion + "&tier=platinum_plus&queue=420&region=all";

                this.rankedQueue.Add(0, await WebRequests.GetJsonObject(apiUrl) as JObject);
            }
            else if (RankLevelSelection.SelectedIndex == 10)
            {
                apiUrl = $"https://ax.lolalytics.com/patch/1/?patch=" + GameData.CurrentVersion + "&tier=iron&queue=420&region=all";

                this.rankedQueue.Add(0, await WebRequests.GetJsonObject(apiUrl) as JObject);

                apiUrl = $"https://ax.lolalytics.com/patch/1/?patch=" + GameData.CurrentVersion + "&tier=bronze&queue=420&region=all";

                this.rankedQueue.Add(1, await WebRequests.GetJsonObject(apiUrl) as JObject);

                apiUrl = $"https://ax.lolalytics.com/patch/1/?patch=" + GameData.CurrentVersion + "&tier=silver&queue=420&region=all";

                this.rankedQueue.Add(2, await WebRequests.GetJsonObject(apiUrl) as JObject);

                apiUrl = $"https://ax.lolalytics.com/patch/1/?patch=" + GameData.CurrentVersion + "&tier=gold&queue=420&region=all";

                this.rankedQueue.Add(3, await WebRequests.GetJsonObject(apiUrl) as JObject);
            }
            else
            {
                apiUrl = $"https://ax.lolalytics.com/patch/1/?patch=" + GameData.CurrentVersion + "&tier=" + RankLevelSelection.SelectedItem.ToString().ToLower() + "&queue=420&region=all";

                this.rankedQueue.Add(0, await WebRequests.GetJsonObject(apiUrl) as JObject);
            }
            ParseRankedData();
        }

        private void ParseRankedData()
        {
            rankedQueueData.Clear();

            int totalRoleGames = 0;

            if (RankLevelSelection.SelectedIndex == 10)
            {
                for (int i = 0; i < 4; i++)
                {
                    foreach (var champion in rankedQueue[i].SelectToken("current")!.SelectToken("lane")!.SelectToken(currentRole)!.SelectToken("cid")!)
                    {
                        ChampionRole championRoleData = new()
                        {
                            ChampionData = GameData.ChampionList.First(x => x.Value.ID == int.Parse(champion.ToString().Split(new char[] { '"' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim().Split(" ").Last())).Value,
                            Role = (int)champion.First().ElementAt(1),
                            RolePercentage = (float)champion.First().ElementAt(4) / (float)champion.First().ElementAt(5),
                            TotalGames = (int)champion.First().ElementAt(4)
                        };

                        championRoleData.Winrate = (float)champion.First().ElementAt(3) / championRoleData.TotalGames;

                        switch (championRoleData.Role)
                        {
                            case 1:
                                totalRoleGames = (int)rankedQueue[i].SelectToken("current")!.SelectToken("totals")!.ElementAt(1);
                                break;
                            case 2:
                                totalRoleGames = (int)rankedQueue[i].SelectToken("current")!.SelectToken("totals")!.ElementAt(2);
                                break;
                            case 3:
                                totalRoleGames = (int)rankedQueue[i].SelectToken("current")!.SelectToken("totals")!.ElementAt(3);
                                break;
                            case 4:
                                totalRoleGames = (int)rankedQueue[i].SelectToken("current")!.SelectToken("totals")!.ElementAt(4);
                                break;
                            case 5:
                                totalRoleGames = (int)rankedQueue[i].SelectToken("current")!.SelectToken("totals")!.ElementAt(5);
                                break;
                        }
                        championRoleData.Pickrate = ((float)championRoleData.TotalGames / (float)totalRoleGames) * 2;
                        championRoleData.Banrate = (float)champion.First().Last();

                        if (!rankedQueueData.ContainsKey((int)championRoleData.ChampionData.ID))
                        {
                            rankedQueueData.Add((int)championRoleData.ChampionData.ID, championRoleData);
                        }
                        else
                        {
                            rankedQueueData[(int)championRoleData.ChampionData.ID].TotalGames += championRoleData.TotalGames;
                            rankedQueueData[(int)championRoleData.ChampionData.ID].RolePercentage = (rankedQueueData[(int)championRoleData.ChampionData.ID].RolePercentage + championRoleData.RolePercentage) / 2;
                            rankedQueueData[(int)championRoleData.ChampionData.ID].Pickrate = (rankedQueueData[(int)championRoleData.ChampionData.ID].Pickrate + championRoleData.Pickrate) / 2;
                            rankedQueueData[(int)championRoleData.ChampionData.ID].Banrate = (rankedQueueData[(int)championRoleData.ChampionData.ID].Banrate + championRoleData.Banrate) / 2;
                        }
                    }
                }
            }
            else
            {
                foreach (var champion in rankedQueue[0].SelectToken("current")!.SelectToken("lane")!.SelectToken(currentRole)!.SelectToken("cid")!)
                {
                    ChampionRole championRoleData = new()
                    {
                        ChampionData = GameData.ChampionList.First(x => x.Value.ID == int.Parse(champion.ToString().Split(new char[] { '"' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim().Split(" ").Last())).Value,
                        Role = (int)champion.First().ElementAt(1),
                        RolePercentage = (float)champion.First().ElementAt(4) / (float)champion.First().ElementAt(5),
                        TotalGames = (int)champion.First().ElementAt(4)
                    };

                    championRoleData.Winrate = (float)champion.First().ElementAt(3) / championRoleData.TotalGames;

                    switch (championRoleData.Role)
                    {
                        case 1:
                            totalRoleGames = (int)rankedQueue[0].SelectToken("current")!.SelectToken("totals")!.ElementAt(1);
                            break;
                        case 2:
                            totalRoleGames = (int)rankedQueue[0].SelectToken("current")!.SelectToken("totals")!.ElementAt(2);
                            break;
                        case 3:
                            totalRoleGames = (int)rankedQueue[0].SelectToken("current")!.SelectToken("totals")!.ElementAt(3);
                            break;
                        case 4:
                            totalRoleGames = (int)rankedQueue[0].SelectToken("current")!.SelectToken("totals")!.ElementAt(4);
                            break;
                        case 5:
                            totalRoleGames = (int)rankedQueue[0].SelectToken("current")!.SelectToken("totals")!.ElementAt(5);
                            break;
                    }
                    championRoleData.Pickrate = ((float)championRoleData.TotalGames / (float)totalRoleGames) * 2;
                    championRoleData.Banrate = (float)champion.First().Last();

                    rankedQueueData.Add((int)championRoleData.ChampionData.ID, championRoleData);
                }
            }
            LoadRankedData();
        }

        private async void LoadRankedData()
        {
            rankedDataGrid.Rows.Clear();

            string role = "";
            float PBI = 0;

            rankedQueueData = rankedQueueData.Where(x => x.Value.RolePercentage * 100 >= minLanerate && x.Value.TotalGames * 100 >= minGamesPlayed && x.Value.Pickrate * 100 >= minPickrate)
                .OrderByDescending(x => x.Value.Winrate * 0.7f + (float)x.Value.TotalGames / rankedQueueData.Sum(x => x.Value.TotalGames) * 0.3f)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            await Task.WhenAll(rankedQueueData.Values.Select(x => x.ChampionData!.FetchSprite()));

            foreach (var champion in rankedQueueData)
            {
                PBI = (champion.Value.Winrate - (rankedQueueData.Sum(x => x.Value.Winrate) / rankedQueueData.Count)) * 100 * champion.Value.Pickrate / (100 - champion.Value.Banrate);

                switch (champion.Value.Role)
                {
                    case 1:
                        role = "Top";
                        break;
                    case 2:
                        role = "Jungle";
                        break;
                    case 3:
                        role = "Middle";
                        break;
                    case 4:
                        role = "Bottom";
                        break;
                    case 5:
                        role = "Support";
                        break;
                }
                rankedDataGrid.Rows.Add(champion.Value.ChampionData!.Sprite, champion.Value.ChampionData.Name, role, System.Math.Round(champion.Value.RolePercentage * 100, 2) + "%", System.Math.Round(champion.Value.Winrate * 100, 2) + "%", System.Math.Round(champion.Value.Pickrate * 100, 2) + "%", System.Math.Round(champion.Value.Banrate, 2) + "%", System.Math.Round(PBI * 10000, 0), champion.Value.TotalGames);
            }
        }

        private void RoleSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (roleSelection.SelectedIndex)
            {
                case 0:
                    if (currentRole != null)
                        currentRole = "default"!;
                    break;
                case 1:
                    if (currentRole != "top")
                        currentRole = "top";
                    break;
                case 2:
                    if (currentRole != "jungle")
                        currentRole = "jungle";
                    break;
                case 3:
                    if (currentRole != "middle")
                        currentRole = "middle";
                    break;
                case 4:
                    if (currentRole != "bottom")
                        currentRole = "bottom";
                    break;
                case 5:
                    if (currentRole != "support")
                        currentRole = "support";
                    break;
            }
            ParseRankedData();
        }

        private void MinLanePercentage_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(minLanePercentage.Text, out float result))
            {
                minLanerate = result;
                LoadRankedData();
            }
            else if (minLanePercentage.Text == "")
            {
                minLanerate = 0;
                LoadRankedData();
            }
            else
            {
                MessageBox.Show("Invalid Input! Please enter a valid float value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MinLanePercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void MinGameCount_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(minGameCount.Text, out float result))
            {
                minGamesPlayed = result;
                LoadRankedData();
            }
            else if (minLanePercentage.Text == "")
            {
                minGamesPlayed = 0;
                LoadRankedData();
            }
            else
            {
                MessageBox.Show("Invalid Input! Please enter a valid float value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MinGameCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void MinPickPercentage_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(minPickPercentage.Text, out float result))
            {
                minPickrate = result;
                LoadRankedData();
            }
            else if (minLanePercentage.Text == "")
            {
                minPickrate = 0;
                LoadRankedData();
            }
            else
            {
                MessageBox.Show("Invalid Input! Please enter a valid float value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MinPickPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void RankedDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = rankedDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value is Image)
                {
                    Champion champion = GameData.ChampionList.Where(x => x.Value.Name == rankedDataGrid.Rows[e.RowIndex].Cells[1].Value.ToString()).FirstOrDefault().Value;
                    this.mainForm.OpenChildForm(new ChampionLookup(champion, currentRole));
                }
            }
        }

        private void RankLevelSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRankedData();
        }
    }
}
