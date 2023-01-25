using Newtonsoft.Json.Linq;
using Project_Nesja.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Nesja.Forms
{
    public partial class Home : Form
    {
        private string? selectedChampion;

        public Home()
        {
            InitializeComponent();
        }
        
        public Home(string selectedChampion)
        {
            this.selectedChampion = selectedChampion.ToString();
            ChampionData championData = new ChampionData().FetchChampionData(selectedChampion);
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
