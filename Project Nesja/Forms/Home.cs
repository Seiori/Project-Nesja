using Project_Nesja.Data;
using Project_Nesja.Recommenders;
using System.Diagnostics;

namespace Project_Nesja.Forms
{
    public partial class Home : Form
    {
        private ChampionData selectedChampion;

        public Home(ChampionData chosenChampion)
        {
            InitializeComponent();
            selectedChampion = chosenChampion;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            LoadChamptionData();
        }

        private async void LoadChamptionData()
        {
            if (selectedChampion == null)
                selectedChampion = GameData.ChampionList.Values.First();
            await selectedChampion.FetchChampionImages();
            championName.Text = selectedChampion.Name;
            championTitle.Text = selectedChampion.Title;
            championImage.Image = selectedChampion.SplashImage;
            qAbilityPicture.Image = selectedChampion.QAbility;
            wAbilityPicture.Image = selectedChampion.WAbility;
            eAbilityPicture.Image = selectedChampion.EAbility;
            RankedPerformance djiwi = new RankedPerformance();
            var test = djiwi.SortRankedData(GameData.RankedQueue.All.All);
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
            // Grab the ChampionData from the Dictionary of ChampionData Values using the ChampionName
            selectedChampion = GameData.ChampionList.Where(x => x.Value.Name == searchChampionListBox.SelectedItem.ToString()).FirstOrDefault().Value;

            // Load the Selected Champions ChampionData to the UI
            LoadChamptionData();

            // Clear the Results
            searchChampionListBox.Items.Clear();

            // Clear the Search
            searchChampionTextBox.Clear();
        }
    }
}