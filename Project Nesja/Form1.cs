using System.Diagnostics;
using System.Security.Policy;
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
            GameData.FetchVersion();
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://github.com/Seiori/Project-Nesja",
                UseShellExecute = true
            };
            Process.Start(psi);
        }
    }
}