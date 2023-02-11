using Project_Nesja.Data;

namespace Project_Nesja.Forms
{
    public partial class Home : Form
    {
        private ChampionData selectedChampion;
        private ChampionBuild championBuild;
        private string role;
        
        public Home(ChampionData chosenChampion, string role)
        {
            InitializeComponent();
            this.selectedChampion = chosenChampion;
            this.role = role;

            if (selectedChampion == null)
                selectedChampion = GameData.ChampionList.Values.First();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            searchChampionListBox.Visible = false;
            SelectRole(role);
        }

        private void LoadChamptionData()
        {   
            // Display Selected Champion Information
            championName.Text = selectedChampion.Name;
            championTitle.Text = selectedChampion.Title;
            championImage.Image = selectedChampion.SplashImage;

            // Display Selected Champion Data
            totalgamesValue.Text = championBuild.TotalGames.ToString();
            winrateValue.Text = championBuild.Winrate.ToString() + "%";
            pickrateValue.Text = championBuild.Pickrate.ToString() + "%";
            banrateValue.Text = championBuild.Banrate.ToString() + "%";

            // Adds the Images of the Abilities to the Form
            skillData.Text = System.Math.Round(championBuild.SkillPriority.Winrate,2 ).ToString() + "% WR (" + championBuild.SkillPriority.TotalGames + ")";
            firstAbilityValue.Text = championBuild.SkillPriority.Priority[0].ToString();
            firstAbility.Image = selectedChampion.FetchChampionAbility(championBuild.SkillPriority.Priority[0].ToString());
            secondAbilityValue.Text = championBuild.SkillPriority.Priority[1].ToString();
            secondAbility.Image = selectedChampion.FetchChampionAbility(championBuild.SkillPriority.Priority[1].ToString());
            thirdAbilityValue.Text = championBuild.SkillPriority.Priority[2].ToString();
            thirdAbility.Image = selectedChampion.FetchChampionAbility(championBuild.SkillPriority.Priority[2].ToString());


            // Adds the Images of the Summoner Spells to the Form
            summonerSpellsData.Text = System.Math.Round(championBuild.SummonerSpells.Winrate, 2).ToString() + "% WR (" + championBuild.SummonerSpells.TotalGames + ")";
            summonerSpell1.Image = championBuild.SummonerSpells.FirstSpellData.Image;
            summonerSpell2.Image = championBuild.SummonerSpells.SecondSpellData.Image;

            // Adds the Images/Data of the Starting Items to the Form
            startItemData.Text = System.Math.Round(championBuild.StartingItems.Winrate * 100, 2).ToString() + "% WR (" + championBuild.StartingItems.TotalGames + ")";
            firstStartItem.Image = championBuild.StartingItems.FirstItem.Image;
            if (championBuild.StartingItems.SecondItem != null)
                secondStartItem.Image = championBuild.StartingItems.SecondItem.Image;
            else
                secondStartItem.Image = null;

            // Adds the Images/Data of the Core Items to the Form
            firstCoreItem.Image = championBuild.CoreItems.FirstItem.Image;
            secondCoreItem.Image = championBuild.CoreItems.SecondItem.Image;
            thirdCoreItem.Image = championBuild.CoreItems.ThirdItem.Image;

            // Adds the Images/Data of the Fourth Item choices to the Form
            firstFourthChoice.Image = championBuild.FourthItemChoice.First().ItemAsset.Image;
            firstFourthWinrate.Text = System.Math.Round((championBuild.FourthItemChoice.First().Winrate * 100), 2).ToString() + "% WR";
            firstFourthMatches.Text = championBuild.FourthItemChoice.First().TotalGames.ToString() + " Matches";
            secondFourthChoice.Image = championBuild.FourthItemChoice.ElementAt(1).ItemAsset.Image;
            secondFourthWinrate.Text = System.Math.Round((championBuild.FourthItemChoice.ElementAt(1).Winrate * 100), 2).ToString() + "% WR";
            secondFourthMatches.Text = championBuild.FourthItemChoice.ElementAt(1).TotalGames.ToString() + " Matches";
            thirdFourthChoice.Image = championBuild.FourthItemChoice.Last().ItemAsset.Image;
            thirdFourthWinrate.Text = System.Math.Round((championBuild.FourthItemChoice.Last().Winrate * 100), 2).ToString() + "% WR";
            thirdFourthMatches.Text = championBuild.FourthItemChoice.Last().TotalGames.ToString() + " Matches";

            // Adds the Images/Data of the Fifth Item choices to the Form
            firstFifthChoice.Image = championBuild.FifthItemChoice.First().ItemAsset.Image;
            firstFifthWinrate.Text = System.Math.Round((championBuild.FifthItemChoice.First().Winrate * 100), 2).ToString() + "% WR";
            firstFifthMatches.Text = championBuild.FifthItemChoice.First().TotalGames.ToString() + " Matches";
            secondFifthChoice.Image = championBuild.FifthItemChoice.ElementAt(1).ItemAsset.Image;
            secondFifthWinrate.Text = System.Math.Round((championBuild.FifthItemChoice.ElementAt(1).Winrate * 100), 2).ToString() + "% WR";
            secondFifthMatches.Text = championBuild.FifthItemChoice.ElementAt(1).TotalGames.ToString() + " Matches";
            thirdFifthChoice.Image = championBuild.FifthItemChoice.Last().ItemAsset.Image;
            thirdFifthWinrate.Text = System.Math.Round((championBuild.FifthItemChoice.Last().Winrate * 100), 2).ToString() + "% WR";
            thirdFifthMatches.Text = championBuild.FifthItemChoice.Last().TotalGames.ToString() + " Matches";

            // Adds the Images/Data of the Sixth Item choices to the Form
            firstSixthChoice.Image = championBuild.SixthItemChoice.First().ItemAsset.Image;
            firstSixthWinrate.Text = System.Math.Round((championBuild.SixthItemChoice.First().Winrate * 100), 2).ToString() + "% WR";
            firstSixthMatches.Text = championBuild.SixthItemChoice.First().TotalGames.ToString() + " Matches";
            secondSixthChoice.Image = championBuild.SixthItemChoice.ElementAt(1).ItemAsset.Image;
            secondSixthWinrate.Text = System.Math.Round((championBuild.SixthItemChoice.ElementAt(1).Winrate * 100), 2).ToString() + "% WR";
            secondSixthMatches.Text = championBuild.SixthItemChoice.ElementAt(1).TotalGames.ToString() + " Matches";
            thirdSixthChoice.Image = championBuild.SixthItemChoice.Last().ItemAsset.Image;
            thirdSixthWinrate.Text = System.Math.Round((championBuild.SixthItemChoice.Last().Winrate * 100), 2).ToString() + "% WR";
            thirdSixthMatches.Text = championBuild.SixthItemChoice.Last().TotalGames.ToString() + " Matches";
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
            SelectRole(null);

            // Clear the Results
            searchChampionListBox.Items.Clear();

            // Clear the Search
            searchChampionTextBox.Clear();
        }

        private async void SelectRole(string role)
        {
            championBuild = new ChampionBuild(selectedChampion, role);

            await selectedChampion.FetchChampionData();
            await championBuild.FetchChampionBuild();

            topSelection.BackColor = SystemColors.Control;
            jungleSelection.BackColor = SystemColors.Control;
            midSelection.BackColor = SystemColors.Control;
            bottomSelection.BackColor = SystemColors.Control;
            supportSelection.BackColor = SystemColors.Control;
            
            switch(championBuild.role)
            {
                case "top":
                    topSelection.BackColor = Color.Black;
                    break;
                case "jungle":
                    jungleSelection.BackColor = Color.Black;
                    break;
                case "middle":
                    midSelection.BackColor = Color.Black;
                    break;
                case "bottom":
                    bottomSelection.BackColor = Color.Black;
                    break;
                case "support":
                    supportSelection.BackColor = Color.Black;
                    break;
            }
            LoadChamptionData();
        }
        
        private void topSelection_Click(object sender, EventArgs e)
        {
            SelectRole("top");
        }

        private void jungleSelection_Click(object sender, EventArgs e)
        {
            SelectRole("jungle");
        }

        private void midSelection_Click(object sender, EventArgs e)
        {
            SelectRole("middle");
        }

        private void bottomSelection_Click(object sender, EventArgs e)
        {
            SelectRole("bottom");
        }

        private void supportSelection_Click(object sender, EventArgs e)
        {
            SelectRole("support");
        }
    }
}