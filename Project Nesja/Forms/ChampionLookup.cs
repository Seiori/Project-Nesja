using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project_Nesja.Data;
using System.Configuration;

namespace Project_Nesja.Forms
{
    public partial class ChampionLookup : Form
    {
        private Champion selectedChampion;
        private ChampionBuild championBuild;
        private string role;
        private bool runePageImport = false;
        private bool itemSetImport = false;
        private bool summonerSpellImport = false;

        public ChampionLookup(Champion selectedChampion, string role)
        {
            InitializeComponent();

            this.selectedChampion = selectedChampion;
            this.selectedChampion ??= GameData.ChampionList!.Values.First();
            this.role = role;

            LoadChamptionData();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            searchChampionListBox.Visible = false;

            if (ClientData.LeagueClient.IsConnected!)
                ImportButton.Visible = true;
        }

        private async void LoadChamptionData()
        {
            // Gather the Champion Data
            championBuild = new ChampionBuild(selectedChampion, role);

            // Adds Matchup Data
            championMatchupData.Rows.Clear();

            // Combine these Await calls
            await selectedChampion.FetchAll();
            await championBuild.FetchChampionBuild();

            // Applies the Role Selection
            SelectRole();

            var fetchTasks = championBuild.Matchups.Select(async champion =>
            {
                await champion.ChampionData!.FetchSprite();
                championMatchupData.Rows.Add(champion.ChampionData.Sprite, champion.Winrate.ToString());
            });

            await Task.WhenAll(fetchTasks);

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
            runePageData.Text = System.Math.Round(championBuild.RunePageChoice.Winrate, 2).ToString() + "% WR (" + championBuild.RunePageChoice.TotalGames + ")";
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
            coreItemWinrate.Text = System.Math.Round(championBuild.CoreItems.Winrate * 100, 2).ToString() + "% WR";
            coreItemMatches.Text = championBuild.TotalGames.ToString() + " Matches";

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

            role = "";

            // Load the Selected Champions ChampionData to the UI
            LoadChamptionData();

            // Clear the Results
            searchChampionListBox.Items.Clear();

            // Clear the Search
            searchChampionTextBox.Clear();
        }

        private async void ImportButton_Click(object sender, EventArgs e)
        {
            if (runePageImport)
            {
                var jsonString = "{\"name\":\"" + selectedChampion.Name + " " + championBuild.role + " Runes\", \"selectedPerkIds\": " + JArray.FromObject(this.championBuild.RunePageChoice.GetRunePageIDs()).ToString() + ", \"primaryStyleId\":" + this.championBuild.RunePageChoice.GetStyleID(this.championBuild.RunePageChoice.Keystone!.RuneTree) + ", \"subStyleId\":" + this.championBuild.RunePageChoice.GetStyleID(this.championBuild.RunePageChoice.SecTreeFirstOption!.RuneTree) + ", \"current\": true}";
                await ClientData.SetRunePage(jsonString);
            }

            if (itemSetImport)
            {
                Block startingItemsBlock = new()
                {
                    type = "Starting Items",
                };

                ItemInfo startingFirst = new ItemInfo { id = championBuild.StartingItems.FirstItem!.ID.ToString(), count = 1 };
                string startingSecondItemId = championBuild.StartingItems.SecondItem?.ID!.ToString() ?? "defaultItemId";
                ItemInfo startingSecond = new ItemInfo { id = startingSecondItemId, count = 1 };
                startingItemsBlock.items = new List<ItemInfo> { startingFirst, startingSecond };


                Block coreItemsBlock = new()
                {
                    type = "Core Items",
                };

                ItemInfo coreFirst = new ItemInfo { id = championBuild.CoreItems.FirstItem!.ID.ToString(), count = 1 };
                ItemInfo coreSecond = new ItemInfo { id = championBuild.CoreItems.SecondItem!.ID.ToString(), count = 1 };
                ItemInfo coreThird = new ItemInfo { id = championBuild.CoreItems.ThirdItem!.ID.ToString(), count = 1 };
                coreItemsBlock.items = new List<ItemInfo> { coreFirst, coreSecond, coreThird };

                Block fourthItemsBlock = new()
                {
                    type = "Fourth Item Choices",
                };

                ItemInfo fourthFirst = new ItemInfo { id = championBuild.FourthItemChoice.FirstOrDefault()!.ItemAsset!.ID.ToString(), count = 1 };
                ItemInfo fourthSecond = new ItemInfo { id = championBuild.FourthItemChoice.ElementAt(1)!.ItemAsset!.ID.ToString(), count = 1 };
                ItemInfo fourthThird = new ItemInfo { id = championBuild.FourthItemChoice.LastOrDefault()!.ItemAsset!.ID.ToString(), count = 1 };
                fourthItemsBlock.items = new List<ItemInfo> { fourthFirst, fourthSecond, fourthThird };

                Block fifthItemsBlock = new()
                {
                    type = "Fifth Item Choices",
                };

                ItemInfo fifthFirst = new ItemInfo { id = championBuild.FifthItemChoice.FirstOrDefault()!.ItemAsset!.ID.ToString(), count = 1 };
                ItemInfo fifthSecond = new ItemInfo { id = championBuild.FifthItemChoice.ElementAt(1)!.ItemAsset!.ID.ToString(), count = 1 };
                ItemInfo fifthThird = new ItemInfo { id = championBuild.FifthItemChoice.LastOrDefault()!.ItemAsset!.ID.ToString(), count = 1 };
                fifthItemsBlock.items = new List<ItemInfo> { fifthFirst, fifthSecond, fifthThird };

                Block sixthItemsBlock = new()
                {
                    type = "Sixth Item Choices",
                };

                ItemInfo sixthFirst = new ItemInfo { id = championBuild.SixthItemChoice.FirstOrDefault()!.ItemAsset!.ID.ToString(), count = 1 };
                ItemInfo sixthSecond = new ItemInfo { id = championBuild.SixthItemChoice.ElementAt(1)!.ItemAsset!.ID.ToString(), count = 1 };
                ItemInfo sixthThird = new ItemInfo { id = championBuild.SixthItemChoice.LastOrDefault()!.ItemAsset!.ID.ToString(), count = 1 };
                sixthItemsBlock.items = new List<ItemInfo> { sixthFirst, sixthSecond, sixthThird };

                ItemSet itemSet = new ItemSet()
                {
                    associatedChampions = new List<int> { selectedChampion.ID },
                    associatedMaps = new List<int> { 11, 12 },
                    blocks = new List<Block> { startingItemsBlock, coreItemsBlock, fourthItemsBlock, fifthItemsBlock, sixthItemsBlock },
                    map = "SR",
                    mode = "any",
                    preferredItemSlots = new List<int>(),
                    sortrank = 9999,
                    title = selectedChampion.Name + " " + championBuild.role.ToUpper() + " Item Set",
                    type = "custom",
                    uid = Guid.NewGuid().ToString()
                };

                List<ItemSet> itemSets = new();
                itemSets.Add(itemSet);

                Dictionary<string, object> requestBody = new();

                //requestBody.Add("accountId", ClientData.Summoner.AccountID);
                requestBody.Add("itemSets", itemSets);
                requestBody.Add("timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

                string jsonString = JsonConvert.SerializeObject(requestBody);
                await ClientData.SetItemSet(jsonString);
            }

            if (summonerSpellImport)
            {
                Dictionary<string, object> requestBody = new();

                requestBody.Add("spell1Id", championBuild.SummonerSpells.FirstSpellData!.ID);
                requestBody.Add("spell2Id", championBuild.SummonerSpells.SecondSpellData!.ID);

                string jsonString = JsonConvert.SerializeObject(requestBody);
                await ClientData.SetSummonerSpells(jsonString);
            }
        }

        private void SelectRole()
        {
            topSelection.BackColor = SystemColors.Control;
            jungleSelection.BackColor = SystemColors.Control;
            midSelection.BackColor = SystemColors.Control;
            bottomSelection.BackColor = SystemColors.Control;
            supportSelection.BackColor = SystemColors.Control;

            switch (role)
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
        }

        private void TopSelection_Click(object sender, EventArgs e)
        {
            role = "top";
            LoadChamptionData();
        }

        private void JungleSelection_Click(object sender, EventArgs e)
        {
            role = "jungle";
            LoadChamptionData();
        }

        private void MidSelection_Click(object sender, EventArgs e)
        {
            role = "middle";
            LoadChamptionData();
        }

        private void BottomSelection_Click(object sender, EventArgs e)
        {
            role = "bottom";
            LoadChamptionData();
        }

        private void SupportSelection_Click(object sender, EventArgs e)
        {
            role = "support";
            LoadChamptionData();
        }

        private void SummonersImport_CheckedChanged(object sender, EventArgs e)
        {
            summonerSpellImport = !summonerSpellImport;
        }

        private void RunesImport_CheckedChanged(object sender, EventArgs e)
        {
            runePageImport = !runePageImport;
        }

        private void ItemsImport_CheckedChanged(object sender, EventArgs e)
        {
            itemSetImport = !itemSetImport;
        }
    }
}