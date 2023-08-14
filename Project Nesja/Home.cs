using System.Diagnostics;
using System.Runtime.InteropServices;
using FontAwesome.Sharp;
using PoniLCU;
using Project_Nesja.Data;
using Project_Nesja.Forms;

namespace Project_Nesja
{
    public partial class MainMenu : Form
    {
        private IconButton? currentButton;
        private readonly Panel leftBorderButton;
        private Form? currentChildForm;

        public MainMenu()
        {
            InitializeComponent();

            // Defines a new Panel and Button for the Navigation Menus Selection Highlight
            leftBorderButton = new Panel
            {
                Size = new Size(7, 60)
            };
            PanelMenu.Controls.Add(leftBorderButton);

            // Removes Application Title At the Top
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Fetches Data from the API sources
            await GameData.FetchGameData();

            if (ClientData.LeagueClient.IsConnected)
            {
                ActiveSummoner.Text = "Current Summoner: ";
                ActiveSummonerName.Text = ClientData.Summoner.Name;
                ClientData.GetClashLobby();
            }
            else
            {
                ActiveSummoner.Text = "Client Not Connected";
                ActiveSummonerName.Text = "N/A";
            }

            CurrentPatch.Text = "v" + GameData.CurrentVersion;
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            // Opens GitHub Associated with Project
            var psi = new ProcessStartInfo
            {
                FileName = "https://github.com/Seiori/Project-Nesja",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void ChampionButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new ChampionLookup(null!, null!));
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new ProfileLookup());
        }

        private void RankedButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new Ranked(this));
        }

        private void AramButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new Aram(this));
        }

        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void MainMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void MinimiseButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelDesktop.Controls.Add(childForm);
            PanelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            LabelFormTitle.Text = childForm.Text;
        }

        private void ActiveButton(object senderButton, Color customColor)
        {
            if (senderButton != null)
            {
                // Disables Previous Button
                DisableButton();

                // Applies Effects to Currently Selected Button on the Side Bar
                currentButton = (IconButton)senderButton;
                currentButton.BackColor = Color.Gray;
                currentButton.ForeColor = customColor;
                currentButton.IconColor = customColor;
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.ImageAlign = ContentAlignment.MiddleRight;
                currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;

                // Applies Different Look to the Left Border of the Side Bar to show Selected Button
                leftBorderButton.BackColor = customColor;
                leftBorderButton.Location = new Point(0, currentButton.Location.Y);
                leftBorderButton.Visible = true;
                leftBorderButton.BringToFront();

                // Sets the Icon of the Current Form
                IconCurrentForm.IconChar = currentButton.IconChar;
                IconCurrentForm.IconColor = customColor;

                // Sets the Text of the Current Form
                LabelFormTitle.Text = currentButton.Text;
            }
        }

        private void DisableButton()
        {
            if (currentButton != null)
            {
                // Returns the Previously Selected Button to its Original State
                currentButton.BackColor = Color.Black;
                currentButton.ForeColor = Color.Gainsboro;
                currentButton.IconColor = Color.Gainsboro;
                currentButton.TextAlign = ContentAlignment.MiddleLeft;
                currentButton.ImageAlign = ContentAlignment.MiddleLeft;
                currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            }
        }

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]

        private static extern bool ReleaseCapture();

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SearchChampionTextBox_TextChanged(object sender, EventArgs e)
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

        private void SearchChampionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected champion from the list box
            string selectedChampion = searchChampionListBox.SelectedItem.ToString()!;

            // Open the new form and pass the selected champion as a parameter
            OpenChildForm(new ChampionLookup(GameData.ChampionList.Where(x => x.Value.Name == selectedChampion).FirstOrDefault().Value, null!));
        }

        private async void ClientConnectButton_Click(object sender, EventArgs e)
        {
            if (await ClientData.ConnectToClient())
            {
                ActiveSummoner.Text = "Current Summoner: ";
                ActiveSummonerName.Text = ClientData.Summoner.Name;
            }
            else
            {
                ActiveSummoner.Text = "Client Not Connected";
                ActiveSummonerName.Text = "N/A";
            }
        }
    }
}