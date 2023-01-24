using System.Diagnostics;
using System.Runtime.InteropServices;
using FontAwesome.Sharp;

namespace Project_Nesja
{
    public partial class MainMenu : Form
    {
        private IconButton currentButton;
        private Panel leftBorderButton;
        private Form currentChildForm;
        
        public MainMenu()
        {
            InitializeComponent();
            leftBorderButton = new Panel();
            leftBorderButton.Size = new Size(7, 60);
            PanelMenu.Controls.Add(leftBorderButton);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameData.FetchVersion();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new Form());
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new Form());
        }

        private void RankedButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new Form());
        }

        private void AramButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new Form());
        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new Form());
        }

        private void MiscButton_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.White);
            OpenChildForm(new Form());
        }

        private void IconCurrentForm_Click(object sender, EventArgs e)
        {
            
        }

        private void LabelFormTitle_Click(object sender, EventArgs e)
        {

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

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
    }
}