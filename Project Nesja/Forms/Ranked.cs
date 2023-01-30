using Project_Nesja.Data;

namespace Project_Nesja.Forms
{
    public partial class Ranked : Form
    {
        private Dictionary<int, ChampionRoleData> rankedData;
        public Ranked()
        {
            InitializeComponent();
        }

        private void Ranked_Load(object sender, EventArgs e)
        {
            LoadRankedData();
        }

        private async void LoadRankedData()
        {
            if (rankedData == null)
                rankedData = new RankedPerformance().SortRankedData(GameData.RankedQueue.All.All);
            foreach (var champion in rankedData)
            {
                await champion.Value.ChampionData.FetchChampionSprite();
                rankedDataGrid.Rows.Add(champion.Value.ChampionData.SpriteImage, champion.Value.ChampionData.Name, champion.Value.TotalGames, champion.Value.WinRate * 100, champion.Value.PickRate * 100 ,champion.Value.BanRate * 100);
            }
        }
    }
}
