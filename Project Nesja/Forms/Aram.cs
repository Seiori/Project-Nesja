using Project_Nesja.Data;
using System.Data;
using System.Diagnostics;

namespace Project_Nesja.Forms
{
    public partial class Aram : Form
    {
        private MainMenu mainForm;
        
        public Aram(MainMenu mainMenu)
        {
            mainForm = mainMenu;
            InitializeComponent();
        }

        private void Aram_Load(object sender, EventArgs e)
        {
            LoadAramData();
        }

        private async void LoadAramData()
        {
            int TotalGames = GameData.Aram.Sum(x => x.Value.TotalGames);
            GameData.Aram = GameData.Aram.OrderByDescending(x => x.Value.Winrate * 0.45f + (float)x.Value.TotalGames / TotalGames * 0.55f).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            
            foreach (var champion in GameData.Aram)
            {
                await champion.Value.ChampionData.FetchChampionSprite();
                aramDataGrid.Rows.Add(champion.Value.ChampionData.SpriteImage, champion.Value.ChampionData.Name, champion.Value.TotalGames, System.Math.Round(champion.Value.Winrate * 100, 2) + "%", System.Math.Round(champion.Value.Pickrate * 100, 2) + "%");
            }
        }

        private void aramDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = aramDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value is Image)
                {
                    Debug.WriteLine("Image Clicked");
                    ChampionData champion = GameData.ChampionList.Where(x => x.Value.Name == aramDataGrid.Rows[e.RowIndex].Cells[1].Value.ToString()).FirstOrDefault().Value;
                    this.mainForm.OpenChildForm(new Home(champion, null));
                }
            }
        }
    }
}