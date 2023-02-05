using Project_Nesja.Data;
using Project_Nesja.Properties;

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
            searchChampionListBox.Visible = false;
        }

        private async void LoadChamptionData()
        {
            ChampionBuild championBuild = new ChampionBuild(selectedChampion);
            
            if (selectedChampion == null)
                selectedChampion = GameData.ChampionList.Values.First();
            
            await selectedChampion.FetchChampionData();
            await championBuild.FetchChampionBuild();
            
            championName.Text = selectedChampion.Name;
            championTitle.Text = selectedChampion.Title;
            championImage.Image = selectedChampion.SplashImage;
            
            // Adds the Images of the Abilities to the Form
            firstAbility.Image = selectedChampion.FetchChampionAbility(championBuild.SkillPriority.Priority[0].ToString());
            secondAbility.Image = selectedChampion.FetchChampionAbility(championBuild.SkillPriority.Priority[1].ToString());
            thirdAbility.Image = selectedChampion.FetchChampionAbility(championBuild.SkillPriority.Priority[2].ToString());

            // Adds the Images of the Summoner Spells to the Form
            summonerSpell1.Image = championBuild.SummonerSpells.FirstSpellData.Image;
            summonerSpell2.Image = championBuild.SummonerSpells.SecondSpellData.Image;

            // Adds the Images of the Items to the Form
            firstItem.Image = championBuild.Items.FirstItem.Image;
            secondItem.Image = championBuild.Items.SecondItem.Image;
            thirdItem.Image = championBuild.Items.ThirdItem.Image;
            fourthItem.Image = championBuild.Items.FourthItem.Image;
            fifthItem.Image = championBuild.Items.FifthItem.Image;
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