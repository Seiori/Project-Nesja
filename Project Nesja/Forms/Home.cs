using Project_Nesja.Data;
using System.Runtime.CompilerServices;

namespace Project_Nesja.Forms
{
    public partial class Home : Form
    {
        private ChampionData? selectedChampion;

        public Home(ChampionData selectedChampion)
        {
            InitializeComponent();
            this.selectedChampion = selectedChampion;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            LoadChamptionData();
        }

        private async void LoadChamptionData()
        {
            await this.selectedChampion.FetchChampionImages();
            championName.Text = selectedChampion.Name;
            championTitle.Text = selectedChampion.Title;
            championImage.Image = selectedChampion.SplashImage;
        }

        private void searchChampionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (GameData.ChampionList != null)
            {
                // Use the GameData.ChampionList, and compare the letters in the searchChampionTextBox to the names of the champions in the list
                var filteredList = GameData.ChampionList.Where(x => x.Value.Name.ToLower().Contains(searchChampionTextBox.Text.ToLower())).ToList();

                // Clear the listbox
                searchChampionListBox.Items.Clear();

                // Add the filtered list to the listbox
                foreach (var champion in filteredList)
                {
                    searchChampionListBox.Items.Add(champion.Value.Name);
                }

                if (searchChampionTextBox.Text != "")
                {
                    searchChampionListBox.Visible = true;
                }
                else
                {
                    searchChampionListBox.Visible = false;
                }
            }
        }

        private void searchChampionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected champion from the list box
            this.selectedChampion = GameData.ChampionList.Where(x => x.Value.Name == searchChampionListBox.SelectedItem.ToString()).FirstOrDefault().Value;

            // Open the new form and pass the selected champion as a parameter
            LoadChamptionData();
        }
    }
}