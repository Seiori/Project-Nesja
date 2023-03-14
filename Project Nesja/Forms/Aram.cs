using Newtonsoft.Json.Linq;
using Project_Nesja.Data;
using System.Data;
using System.Diagnostics;

namespace Project_Nesja.Forms
{
    public partial class Aram : Form
    {
        private readonly MainMenu mainForm;
        private Dictionary<int, ChampionRole> aramQueue;
        
        public Aram(MainMenu mainMenu)
        {
            InitializeComponent();
            this.mainForm = mainMenu;
            aramQueue = new Dictionary<int, ChampionRole>();
        }

        private void Aram_Load(object sender, EventArgs e)
        {
            FetchAramData();
        }

        private async void FetchAramData()
        {
            string apiUrl = $"https://axe.lolalytics.com/tierlist/2/?lane=middle&patch=" + GameData.CurrentVersion + "&tier=platinum_plus&queue=450&region=all";

            JObject aramData = (JObject)await WebRequests.GetJsonObject(apiUrl);

            foreach (var champion in aramData.SelectToken("cid"))
            {
                ChampionRole championRoleData = new();
                championRoleData.ChampionData = GameData.ChampionList.FirstOrDefault(x => x.Value.ID == int.Parse(champion.ToString().Split(new char[] { '"' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim().Split(" ").Last())).Value;
                championRoleData.TotalGames = (int)champion.First().ElementAt(4);
                championRoleData.Winrate = (float)champion.First().ElementAt(3) / championRoleData.TotalGames;
                championRoleData.Pickrate = championRoleData.TotalGames / (float)aramData.SelectToken("totals")!.First();

                aramQueue.Add((int)championRoleData.ChampionData.ID, championRoleData);
            }
            LoadAramData();
        }
        
        private async void LoadAramData()
        {
            int TotalGames = aramQueue.Sum(x => x.Value.TotalGames);
            aramQueue = aramQueue.OrderByDescending(x => x.Value.Winrate * 0.45f + (float)x.Value.TotalGames / TotalGames * 0.55f).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            await Task.WhenAll(aramQueue.Values.Select(x => x.ChampionData!.FetchSprite()));

            foreach (var champion in aramQueue)
            {
                aramDataGrid.Rows.Add(champion.Value.ChampionData!.Sprite, (object?)champion.Value.ChampionData.Name, champion.Value.TotalGames, System.Math.Round(champion.Value.Winrate * 100, 2) + "%", System.Math.Round(champion.Value.Pickrate * 100, 2) + "%");
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
                    Champion champion = GameData.ChampionList.Where(x => x.Value.Name == aramDataGrid.Rows[e.RowIndex].Cells[1].Value.ToString()).FirstOrDefault().Value;
                    this.mainForm.OpenChildForm(new ChampionLookup(champion, null!));
                }
            }
        }
    }
}