using Project_Nesja.Data;
using System.Diagnostics;

namespace Project_Nesja.Forms
{
    public partial class Ranked : Form
    {
        private readonly MainMenu mainForm;
        private Dictionary<int, ChampionRole> rankedData;
        private string currentRole;
        private float minLanerate = 2f;
        private float minGamesPlayed = 100;
        private float minPickrate = 2;
        
        public Ranked(MainMenu mainMenu)
        {
            mainForm = mainMenu;
            InitializeComponent();
        }

        private void Ranked_Load(object sender, EventArgs e)
        {
            LoadRankedData();
        }

        private async void LoadRankedData()
        {
            rankedDataGrid.Rows.Clear();
            
            if (rankedData == null)
                rankedData = GameData.RankedQueue.All.All;

            string role = "";
            float PBI = 0;

            rankedData = rankedData.Where(x => x.Value.RolePercentage * 100 >= minLanerate && x.Value.TotalGames * 100 >= minGamesPlayed && x.Value.Pickrate * 100 >= minPickrate)
                .OrderByDescending(x => x.Value.Winrate * 0.7f + (float)x.Value.TotalGames / rankedData.Sum(x => x.Value.TotalGames) * 0.3f)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);


            foreach (var champion in rankedData)
            {
                PBI = (champion.Value.Winrate - (rankedData.Sum(x => x.Value.Winrate) / rankedData.Count)) * 100 * champion.Value.Pickrate / (100 - champion.Value.Banrate);
                
                await champion.Value.ChampionData.FetchChampionData();
                
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
                        rankedData = GameData.RankedQueue.All.All;
                    currentRole = null;
                    break;
                case 1:
                    if (currentRole != "top")
                        rankedData = GameData.RankedQueue.All.Top;
                    currentRole = "top";
                    break;
                case 2:
                    if (currentRole != "jungle")
                        rankedData = GameData.RankedQueue.All.Jungle;
                    currentRole = "jungle";
                    break;
                case 3:
                    if (currentRole != "middle")
                        rankedData = GameData.RankedQueue.All.Mid;
                    currentRole = "middle";
                    break;
                case 4:
                    if (currentRole != "bottom")
                        rankedData = GameData.RankedQueue.All.ADC;
                    currentRole = "bottom";
                    break;
                case 5:
                    if (currentRole != "support")
                        rankedData = GameData.RankedQueue.All.Support;
                    currentRole = "support";
                    break;
            }
            LoadRankedData();
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
                    this.mainForm.OpenChildForm(new Home(champion, currentRole));
                }
            }
        }
    }
}
