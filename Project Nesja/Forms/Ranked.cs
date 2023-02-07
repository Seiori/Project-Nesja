using Project_Nesja.Data;
using System.Diagnostics;

namespace Project_Nesja.Forms
{
    public partial class Ranked : Form
    {
        private MainMenu mainForm;
        public Dictionary<int, ChampionRoleData> rankedData;
        private string currentRole;
        
        public Ranked(MainMenu mainMenu)
        {
            mainForm = mainMenu;
            InitializeComponent();
        }

        private void Ranked_Load(object sender, EventArgs e)
        {
            roleSelection.SelectedIndex = 0;
            LoadRankedData();
        }

        private async void LoadRankedData()
        {
            rankedDataGrid.Rows.Clear();
            
            if (rankedData == null)
                rankedData = GameData.RankedQueue.All.All;

            int TotalGames = rankedData.Sum(x => x.Value.TotalGames);
            rankedData = rankedData.OrderByDescending(x => x.Value.Winrate * 0.55f + (float)x.Value.TotalGames / TotalGames * 0.45f).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            
            foreach (var champion in rankedData)
            {
                await champion.Value.ChampionData.FetchChampionSprite();
                rankedDataGrid.Rows.Add(champion.Value.ChampionData.SpriteImage, champion.Value.ChampionData.Name, champion.Value.TotalGames, System.Math.Round(champion.Value.Winrate * 100, 2) + "%", System.Math.Round(champion.Value.Pickrate * 100, 2) + "%", System.Math.Round(champion.Value.Banrate * 100, 2) + "%");
            }
        }

        private void rankedDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = rankedDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value is Image)
                {
                    Debug.WriteLine("Image Clicked");
                    ChampionData champion = GameData.ChampionList.Where(x => x.Value.Name == rankedDataGrid.Rows[e.RowIndex].Cells[1].Value.ToString()).FirstOrDefault().Value;
                    this.mainForm.OpenChildForm(new Home(champion, currentRole));
                }
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
    }
}
