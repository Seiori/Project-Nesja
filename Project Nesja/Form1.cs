using System.Text.Json.Nodes;

namespace Project_Nesja
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetData();
        }

        async static void GetData()
        {
            JsonGrabber grabber = new JsonGrabber();
            GameData.currentVersion = grabber.GetJsonObject<List<string>>("https://ddragon.leagueoflegends.com/api/versions.json")[0];
            GameData.aram = grabber.GetJsonObject<object>("https://op.gg/api/v1.0/internal/bypass/statistics/global/champions/aram?period=week&tier=all");
        } 
    }
}