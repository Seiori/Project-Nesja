using Newtonsoft.Json.Linq;
using Project_Nesja.Data;
using System.Diagnostics;

namespace Project_Nesja.Forms
{
    public partial class Ranked : Form
    {
        private readonly MainMenu mainForm;
        private Dictionary<int, ChampionRole> rankedQueue;
        private JObject rankedData;
        private string currentRole;
        private float minLanerate = 2f;
        private float minGamesPlayed = 100;
        private float minPickrate = 2;
        
        public Ranked(MainMenu mainMenu)
        {
            InitializeComponent();
            this.mainForm = mainMenu;
            rankedQueue = new Dictionary<int, ChampionRole>(GameData.ChampionList.Count);
            currentRole = "default";
        }

        private void Ranked_Load(object sender, EventArgs e)
        {
            FetchRankedData();
        }

        private async void FetchRankedData()
        {
            string apiUrl = $"https://axe.lolalytics.com/patch/1/?patch=" + GameData.CurrentVersion + "&tier=platinum_plus&queue=420&region=all";

            this.rankedData = (JObject)await WebRequests.GetJsonObject(apiUrl);

            ParseRankedData();
        }
        
        private void ParseRankedData()
        {
            rankedQueue.Clear();

            int totalRoleGames = 0;

            foreach (var champion in rankedData.SelectToken("current").SelectToken("lane").SelectToken(currentRole).SelectToken("cid"))
            {
                ChampionRole championRoleData = new ChampionRole();
                championRoleData.ChampionData = GameData.ChampionList.First(x => x.Value.ID == int.Parse(champion.ToString().Split(new char[] { '"' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim().Split(" ").Last())).Value;
                championRoleData.Role = (int)champion.First().ElementAt(1);
                championRoleData.RolePercentage = (float)champion.First().ElementAt(4) / (float)champion.First().ElementAt(5);
                championRoleData.TotalGames = (int)champion.First().ElementAt(4);
                championRoleData.Winrate = (float)champion.First().ElementAt(3) / championRoleData.TotalGames;

                switch (championRoleData.Role)
                {
                    case 1:
                        totalRoleGames = (int)rankedData.SelectToken("current").SelectToken("totals").ElementAt(1);
                        break;
                    case 2:
                        totalRoleGames = (int)rankedData.SelectToken("current").SelectToken("totals").ElementAt(2);
                        break;
                    case 3:
                        totalRoleGames = (int)rankedData.SelectToken("current").SelectToken("totals").ElementAt(3);
                        break;
                    case 4:
                        totalRoleGames = (int)rankedData.SelectToken("current").SelectToken("totals").ElementAt(4);
                        break;
                    case 5:
                        totalRoleGames = (int)rankedData.SelectToken("current").SelectToken("totals").ElementAt(5);
                        break;
                }
                championRoleData.Pickrate = ((float)championRoleData.TotalGames / (float)totalRoleGames) * 2;
                championRoleData.Banrate = (float)champion.First().Last();

                rankedQueue.Add(championRoleData.ChampionData.ID, championRoleData);
            }
            LoadRankedData();
        }

        private async void LoadRankedData()
        {
            rankedDataGrid.Rows.Clear();

            string role = "";
            float PBI = 0;

            rankedQueue = rankedQueue.Where(x => x.Value.RolePercentage * 100 >= minLanerate && x.Value.TotalGames * 100 >= minGamesPlayed && x.Value.Pickrate * 100 >= minPickrate)
                .OrderByDescending(x => x.Value.Winrate * 0.7f + (float)x.Value.TotalGames / rankedQueue.Sum(x => x.Value.TotalGames) * 0.3f)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            await Task.WhenAll(rankedQueue.Values.Select(x => x.ChampionData.FetchChampionData()));

            foreach (var champion in rankedQueue)
            {
                PBI = (champion.Value.Winrate - (rankedQueue.Sum(x => x.Value.Winrate) / rankedQueue.Count)) * 100 * champion.Value.Pickrate / (100 - champion.Value.Banrate);
                
                champion.Value.ChampionData.FetchChampionData();
                
                switch(champion.Value.Role)
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
                rankedDataGrid.Rows.Add(champion.Value.ChampionData.SpriteImage, champion.Value.ChampionData.Name, role, System.Math.Round(champion.Value.RolePercentage * 100, 2) + "%", System.Math.Round(champion.Value.Winrate * 100, 2) + "%", System.Math.Round(champion.Value.Pickrate * 100, 2) + "%", System.Math.Round(champion.Value.Banrate, 2) + "%", System.Math.Round(PBI * 10000, 0), champion.Value.TotalGames);
            }
        }

        private void roleSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (roleSelection.SelectedIndex)
            {
                case 0:
                    if (currentRole != null)
                    currentRole = null;
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

        private void minLanePercentage_TextChanged(object sender, EventArgs e)
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

        private void minLanePercentage_KeyPress(object sender, KeyPressEventArgs e)
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

        private void minGameCount_TextChanged(object sender, EventArgs e)
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

        private void minGameCount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void minPickPercentage_TextChanged(object sender, EventArgs e)
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

        private void minPickPercentage_KeyPress(object sender, KeyPressEventArgs e)
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

        private void rankedDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = rankedDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value is Image)
                {
                    ChampionData champion = GameData.ChampionList.Where(x => x.Value.Name == rankedDataGrid.Rows[e.RowIndex].Cells[1].Value.ToString()).FirstOrDefault().Value;
                    this.mainForm.OpenChildForm(new Champion(champion, currentRole));
                }
            }
        }
    }
}
