using Project_Nesja.Data;
using System.Diagnostics;

namespace Project_Nesja.Forms
{
    public partial class Ranked : Form
    {
        private MainMenu mainForm;
        public Dictionary<int, ChampionRoleData> rankedData;
        
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
            if (rankedData == null)
                rankedData = GameData.RankedQueue.All.All;
            rankedData = new RankedPerformance().SortRankedData(rankedData);
            foreach (var champion in rankedData)
            {
                await champion.Value.ChampionData.FetchChampionSprite();
                rankedDataGrid.Rows.Add(champion.Value.ChampionData.SpriteImage, champion.Value.ChampionData.Name, champion.Value.TotalGames, champion.Value.Winrate * 100, champion.Value.Pickrate * 100 ,champion.Value.Banrate * 100);
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
                    this.mainForm.OpenChildForm(new Home(champion));
                }
            }
        }

        private void roleSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (roleSelection.SelectedIndex)
            {
                case 0:
                    rankedData = new RankedPerformance().SortRankedData(GameData.RankedQueue.All.All);
                    break;
                case 1:
                    rankedData = new RankedPerformance().SortRankedData(GameData.RankedQueue.All.Top);
                    break;
                case 2:
                    rankedData = new RankedPerformance().SortRankedData(GameData.RankedQueue.All.Jungle);
                    break;
                case 3:
                    rankedData = new RankedPerformance().SortRankedData(GameData.RankedQueue.All.Mid);
                    break;
                case 4:
                    rankedData = new RankedPerformance().SortRankedData(GameData.RankedQueue.All.ADC);
                    break;
                case 5:
                    rankedData = new RankedPerformance().SortRankedData(GameData.RankedQueue.All.Support);
                    break;
            }
            rankedDataGrid.Rows.Clear();
            LoadRankedData();
        }
    }
}
