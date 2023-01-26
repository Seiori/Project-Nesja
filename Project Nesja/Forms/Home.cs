using Project_Nesja.Data;
using System.Runtime.CompilerServices;

namespace Project_Nesja.Forms
{
    public partial class Home : Form
    {
        private ChampionData? selectedChampion;

        public Home(string selectedChampion)
        {
            InitializeComponent();
            this.selectedChampion = new ChampionData().FetchChampionData(selectedChampion);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            LoadChamptionData();
        }

        private void LoadChamptionData()
        {
            championName.Text = selectedChampion.Name;
            championTitle.Text = selectedChampion.Title;
            championImage.Image = selectedChampion.splashImage;
        }
        
        private void searchChampionTextBox_TextChanged(object sender, EventArgs e)
        {
            var champions = GameData.Champions.Children().ToList();
            var filteredChampions = champions.Where(x => x.First.ElementAt(3).Last().ToString().ToLower().Contains(searchChampionTextBox.Text.ToLower())).ToList();

            // Now add the Names gathered in filteredChampions to the ListBox
            searchChampionListBox.Items.Clear();
            foreach (var champion in filteredChampions)
            {
                searchChampionListBox.Items.Add(champion.First.ElementAt(3).Last().ToString());
            }
            searchChampionListBox.Visible = true;
        }

        private void searchChampionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected champion from the list box
            selectedChampion = new ChampionData().FetchChampionData(searchChampionListBox.SelectedItem.ToString());

            // Open the new form and pass the selected champion as a parameter
            LoadChamptionData();
        }
    }
}