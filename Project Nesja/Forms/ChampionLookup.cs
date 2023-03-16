using Newtonsoft.Json.Linq;
using Project_Nesja.Data;
using static PoniLCU.LeagueClient;

namespace Project_Nesja.Forms
{
    public partial class ChampionLookup : Form
    {
        private Champion selectedChampion;
        private ChampionBuild championBuild;
        private string role;

        public ChampionLookup(Champion chosenChampion, string role)
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

            if (ClientData.LeagueClient.IsConnected!)
                ImportButton.Visible = true;
        }

        private async void LoadChamptionData()
        {

            // Adds Matchup Data
            championMatchupData.Rows.Clear();

            foreach (var champion in championBuild.Matchups)
            {
                await champion.ChampionData!.FetchSprite();
                championMatchupData.Rows.Add(champion.ChampionData.Sprite, champion.Winrate.ToString());
            }

            // Display Selected Champion Information
            championName.Text = selectedChampion.Name;
            championTitle.Text = selectedChampion.Title;
            championImage.Image = selectedChampion.Splash;

            // Display Selected Champion Data
            totalgamesValue.Text = championBuild.TotalGames.ToString();
            winrateValue.Text = championBuild.Winrate.ToString() + "%";
            pickrateValue.Text = championBuild.Pickrate.ToString() + "%";
            banrateValue.Text = championBuild.Banrate.ToString() + "%";

            // Adds the Images of the Summoner Spells to the Form
            summonerSpellsData.Text = System.Math.Round(championBuild.SummonerSpells.Winrate, 2).ToString() + "% WR (" + championBuild.SummonerSpells.TotalGames + ")";
            summonerSpell1.Image = championBuild.SummonerSpells.FirstSpellData?.Image ?? null;
            summonerSpell2.Image = championBuild.SummonerSpells.SecondSpellData?.Image ?? null;

            // Adds the Images of the Rune Page to the Form
            KeystoneImage.Image = championBuild.RunePageChoice.Keystone!.RuneAsset!.Image;
            PrimRuneFirstRowImage.Image = championBuild.RunePageChoice.PrimTreeFirstRow!.RuneAsset!.Image;
            PrimRuneSecRowImage.Image = championBuild.RunePageChoice.PrimTreeSecondRow!.RuneAsset!.Image;
            PrimRuneThirdRowImage.Image = championBuild.RunePageChoice.PrimTreeThirdRow!.RuneAsset!.Image;
            SecRuneFirstOptionImage.Image = championBuild.RunePageChoice.SecTreeFirstOption!.RuneAsset!.Image;
            SecRuneSecOptionImage.Image = championBuild.RunePageChoice.SecTreeSecondOption!.RuneAsset!.Image;
            StatModFirstRowImage.Image = championBuild.RunePageChoice.firstRowOption!.StatModAsset!.Image;
            StatModSecRowImage.Image = championBuild.RunePageChoice.secondRowOption!.StatModAsset!.Image;
            StatModThirdRowImage.Image = championBuild.RunePageChoice.thirdRowOption!.StatModAsset!.Image;

            // Adds the Images of the Abilities to the Form
            skillData.Text = System.Math.Round(championBuild.SkillPriority.Winrate, 2).ToString() + "% WR (" + championBuild.SkillPriority.TotalGames + ")";
            firstAbilityValue.Text = championBuild.SkillPriority.Priority![0].ToString();
            firstAbility.Image = selectedChampion.AbilityImageFromString(championBuild.SkillPriority.Priority[0].ToString());
            secondAbilityValue.Text = championBuild.SkillPriority.Priority[1].ToString();
            secondAbility.Image = selectedChampion.AbilityImageFromString(championBuild.SkillPriority.Priority[1].ToString());
            thirdAbilityValue.Text = championBuild.SkillPriority.Priority[2].ToString();
            thirdAbility.Image = selectedChampion.AbilityImageFromString(championBuild.SkillPriority.Priority[2].ToString());

            // Adds the Images/Data of the Starting Items to the Form
            startItemData.Text = System.Math.Round(championBuild.StartingItems.Winrate * 100, 2).ToString() + "% WR (" + championBuild.StartingItems.TotalGames + ")";
            firstStartItem.Image = championBuild.StartingItems.FirstItem?.Image ?? null;

            if (championBuild.StartingItems.SecondItem != null)
                secondStartItem.Image = championBuild.StartingItems.SecondItem.Image;
            else
                secondStartItem.Image = null;

            // Adds the Images/Data of the Core Items to the Form
            firstCoreItem.Image = championBuild.CoreItems.FirstItem?.Image ?? null;
            secondCoreItem.Image = championBuild.CoreItems.SecondItem?.Image ?? null;
            thirdCoreItem.Image = championBuild.CoreItems.ThirdItem?.Image ?? null;
            coreItemData.Text = System.Math.Round(championBuild.CoreItems.Winrate * 100, 2).ToString() + "% WR (" + championBuild.CoreItems.TotalGames + ")";

            // Adds the Images/Data of the Fourth Item choices to the Form
            firstFourthChoice.Image = championBuild.FourthItemChoice.FirstOrDefault()?.ItemAsset!.Image ?? null;
            firstFourthWinrate.Text = championBuild.FourthItemChoice.FirstOrDefault()?.Winrate.ToString("P2") + " WR" ?? "N/A";
            firstFourthMatches.Text = (championBuild.FourthItemChoice.FirstOrDefault()?.TotalGames ?? 0).ToString() + " Matches";

            secondFourthChoice.Image = championBuild.FourthItemChoice.ElementAtOrDefault(1)?.ItemAsset!.Image ?? null;
            secondFourthWinrate.Text = championBuild.FourthItemChoice.ElementAtOrDefault(1)?.Winrate.ToString("P2") + " WR" ?? "N/A";
            secondFourthMatches.Text = (championBuild.FourthItemChoice.ElementAtOrDefault(1)?.TotalGames ?? 0).ToString() + " Matches";

            thirdFourthChoice.Image = championBuild.FourthItemChoice.LastOrDefault()?.ItemAsset!.Image ?? null;
            thirdFourthWinrate.Text = championBuild.FourthItemChoice.LastOrDefault()?.Winrate.ToString("P2") + " WR" ?? "N/A";
            thirdFourthMatches.Text = (championBuild.FourthItemChoice.LastOrDefault()?.TotalGames ?? 0).ToString() + " Matches";

            // Adds the Images/Data of the Fifth Item choices to the Form
            firstFifthChoice.Image = championBuild.FifthItemChoice.FirstOrDefault()?.ItemAsset!.Image ?? null;
            firstFifthWinrate.Text = championBuild.FifthItemChoice.FirstOrDefault()?.Winrate.ToString("P2") + " WR" ?? "N/A";
            firstFifthMatches.Text = (championBuild.FifthItemChoice.FirstOrDefault()?.TotalGames ?? 0).ToString() + " Matches";

            secondFifthChoice.Image = championBuild.FifthItemChoice.ElementAtOrDefault(1)?.ItemAsset!.Image ?? null;
            secondFifthWinrate.Text = championBuild.FifthItemChoice.ElementAtOrDefault(1)?.Winrate.ToString("P2") + " WR" ?? "N/A";
            secondFifthMatches.Text = (championBuild.FifthItemChoice.ElementAtOrDefault(1)?.TotalGames ?? 0).ToString() + " Matches";

            thirdFifthChoice.Image = championBuild.FifthItemChoice.LastOrDefault()?.ItemAsset!.Image ?? null;
            thirdFifthWinrate.Text = championBuild.FifthItemChoice.LastOrDefault()?.Winrate.ToString("P2") + " WR" ?? "N/A";
            thirdFifthMatches.Text = (championBuild.FifthItemChoice.LastOrDefault()?.TotalGames ?? 0).ToString() + " Matches";

            // Adds the Images/Data of the Sixth Item choices to the Form
            firstSixthChoice.Image = championBuild.SixthItemChoice.FirstOrDefault()?.ItemAsset!.Image ?? null;
            firstSixthWinrate.Text = championBuild.SixthItemChoice.FirstOrDefault()?.Winrate.ToString("P2") + " WR" ?? "N/A";
            firstSixthMatches.Text = (championBuild.SixthItemChoice.FirstOrDefault()?.TotalGames ?? 0).ToString() + " Matches";

            secondSixthChoice.Image = championBuild.SixthItemChoice.ElementAtOrDefault(1)?.ItemAsset!.Image ?? null;
            secondSixthWinrate.Text = championBuild.SixthItemChoice.ElementAtOrDefault(1)?.Winrate.ToString("P2") + " WR" ?? "N/A";
            secondSixthMatches.Text = (championBuild.SixthItemChoice.ElementAtOrDefault(1)?.TotalGames ?? 0).ToString() + " Matches";

            thirdSixthChoice.Image = championBuild.SixthItemChoice.LastOrDefault()?.ItemAsset!.Image ?? null;
            thirdSixthWinrate.Text = championBuild.SixthItemChoice.LastOrDefault()?.Winrate.ToString("P2") + " WR" ?? "N/A";
            thirdSixthMatches.Text = (championBuild.SixthItemChoice.LastOrDefault()?.TotalGames ?? 0).ToString() + " Matches";
        }

        private void SearchChampionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (GameData.ChampionList != null)
            {
                // Use the GameData.ChampionList, and compare the letters in the searchChampionTextBox to the names of the champions in the list
                var filteredList = GameData.ChampionList.Where(x => x.Value.Name!.ToLower().Contains(searchChampionTextBox.Text.ToLower())).ToList();

                // Clear the listbox
                searchChampionListBox.Items.Clear();

                // Add the filtered list to the listbox
                foreach (var champion in filteredList)
                {
                    searchChampionListBox.Items.Add(champion.Value.Name!);
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

        private void SearchChampionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchChampionListBox.SelectedItem == null)
                return;

            // Grab the ChampionData from the Dictionary of ChampionData Values using the ChampionName
            selectedChampion = GameData.ChampionList.Where(x => x.Value.Name == searchChampionListBox.SelectedItem.ToString()).FirstOrDefault().Value;

            // Load the Selected Champions ChampionData to the UI
            SelectRole(null);

            // Clear the Results
            searchChampionListBox.Items.Clear();

            // Clear the Search
            searchChampionTextBox.Clear();
        }

        private async void SelectRole(string? role)
        {
            championBuild = new ChampionBuild(selectedChampion, role!);

            await selectedChampion.FetchAll();
            await championBuild.FetchChampionBuild();

            topSelection.BackColor = SystemColors.Control;
            jungleSelection.BackColor = SystemColors.Control;
            midSelection.BackColor = SystemColors.Control;
            bottomSelection.BackColor = SystemColors.Control;
            supportSelection.BackColor = SystemColors.Control;

            switch (championBuild.role)
            {
                case "top":
                    this.role = "Top";
                    topSelection.BackColor = Color.Black;
                    break;
                case "jungle":
                    this.role = "Jungle";
                    jungleSelection.BackColor = Color.Black;
                    break;
                case "middle":
                    this.role = "Mid";
                    midSelection.BackColor = Color.Black;
                    break;
                case "bottom":
                    this.role = "Adc";
                    bottomSelection.BackColor = Color.Black;
                    break;
                case "support":
                    this.role = "Supp";
                    supportSelection.BackColor = Color.Black;
                    break;
            }
            LoadChamptionData();
        }

        private async void ImportButton_Click(object sender, EventArgs e)
        {
            var postBody = "{\"name\":\"" + selectedChampion.Name + " " + role + " Runes\", \"selectedPerkIds\": " + JArray.FromObject(this.championBuild.RunePageChoice.GetRunePageIDs()).ToString() + ", \"primaryStyleId\":" + this.championBuild.RunePageChoice.GetStyleID(this.championBuild.RunePageChoice.Keystone!.RuneTree) + ", \"subStyleId\":" + this.championBuild.RunePageChoice.GetStyleID(this.championBuild.RunePageChoice.SecTreeFirstOption!.RuneTree) + ", \"current\": true}";
            await ClientData.SetSummonerRunes(postBody);
        }

        private void TopSelection_Click(object sender, EventArgs e)
        {
            SelectRole("top");
        }

        private void JungleSelection_Click(object sender, EventArgs e)
        {
            SelectRole("jungle");
        }

        private void MidSelection_Click(object sender, EventArgs e)
        {
            SelectRole("middle");
        }

        private void BottomSelection_Click(object sender, EventArgs e)
        {
            SelectRole("bottom");
        }

        private void SupportSelection_Click(object sender, EventArgs e)
        {
            SelectRole("support");
        }
    }
}