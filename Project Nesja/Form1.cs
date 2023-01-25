using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;
using FontAwesome.Sharp;
using Newtonsoft.Json.Linq;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            GameData.FetchGameData();
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

        private void HomeButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new Home());
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new Profile());
        }

        private void RankedButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new Ranked());
        }

        private void AramButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new Aram());
        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new Game());
        }

        private void MiscButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new Misc());
        }

        private void IconCurrentForm_Click(object sender, EventArgs e)
        {
            
        }

        private void LabelFormTitle_Click(object sender, EventArgs e)
        {

        }

        private void PanelDesktop_Paint(object sender, PaintEventArgs e)
        {
            
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

        private void MaximiseButton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void MinimiseButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        
        private void OpenChildForm(Form childForm)
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
            string selectedChampion = searchChampionListBox.SelectedItem.ToString();

            // Open the new form and pass the selected champion as a parameter
            OpenChildForm(new Home(selectedChampion));
        }
    }
}