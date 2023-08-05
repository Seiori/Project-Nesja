namespace Project_Nesja
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            Logo = new PictureBox();
            PanelMenu = new Panel();
            ActiveSummonerName = new Label();
            ClientConnectButton = new Button();
            ActiveSummoner = new Label();
            CurrentPatch = new Label();
            AramButton = new FontAwesome.Sharp.IconButton();
            ProfileButton = new FontAwesome.Sharp.IconButton();
            RankedButton = new FontAwesome.Sharp.IconButton();
            ChampionButton = new FontAwesome.Sharp.IconButton();
            PanelTitleBar = new Panel();
            MinimiseButton = new FontAwesome.Sharp.IconButton();
            ExitButton = new FontAwesome.Sharp.IconButton();
            LabelFormTitle = new Label();
            IconCurrentForm = new FontAwesome.Sharp.IconPictureBox();
            PanelDesktop = new Panel();
            Title = new Label();
            searchChampionListBox = new ListBox();
            searchChampionTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)Logo).BeginInit();
            PanelMenu.SuspendLayout();
            PanelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IconCurrentForm).BeginInit();
            PanelDesktop.SuspendLayout();
            SuspendLayout();
            // 
            // Logo
            // 
            Logo.Image = (Image)resources.GetObject("Logo.Image");
            Logo.InitialImage = null;
            Logo.Location = new Point(1, 12);
            Logo.Name = "Logo";
            Logo.Size = new Size(185, 72);
            Logo.SizeMode = PictureBoxSizeMode.StretchImage;
            Logo.TabIndex = 0;
            Logo.TabStop = false;
            Logo.Click += Logo_Click;
            // 
            // PanelMenu
            // 
            PanelMenu.AutoSize = true;
            PanelMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelMenu.BackColor = SystemColors.ControlText;
            PanelMenu.Controls.Add(ActiveSummonerName);
            PanelMenu.Controls.Add(ClientConnectButton);
            PanelMenu.Controls.Add(ActiveSummoner);
            PanelMenu.Controls.Add(CurrentPatch);
            PanelMenu.Controls.Add(AramButton);
            PanelMenu.Controls.Add(ProfileButton);
            PanelMenu.Controls.Add(RankedButton);
            PanelMenu.Controls.Add(ChampionButton);
            PanelMenu.Controls.Add(Logo);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.ForeColor = SystemColors.Control;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(189, 836);
            PanelMenu.TabIndex = 2;
            // 
            // ActiveSummonerName
            // 
            ActiveSummonerName.AutoSize = true;
            ActiveSummonerName.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ActiveSummonerName.Location = new Point(3, 744);
            ActiveSummonerName.Name = "ActiveSummonerName";
            ActiveSummonerName.Size = new Size(36, 20);
            ActiveSummonerName.TabIndex = 5;
            ActiveSummonerName.Text = "N/A";
            // 
            // ClientConnectButton
            // 
            ClientConnectButton.BackColor = SystemColors.ControlLightLight;
            ClientConnectButton.ForeColor = SystemColors.ControlText;
            ClientConnectButton.Location = new Point(3, 767);
            ClientConnectButton.Name = "ClientConnectButton";
            ClientConnectButton.Size = new Size(75, 23);
            ClientConnectButton.TabIndex = 2;
            ClientConnectButton.Text = "Retry";
            ClientConnectButton.UseVisualStyleBackColor = false;
            ClientConnectButton.Click += ClientConnectButton_Click;
            // 
            // ActiveSummoner
            // 
            ActiveSummoner.AutoSize = true;
            ActiveSummoner.BackColor = SystemColors.ControlText;
            ActiveSummoner.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ActiveSummoner.ForeColor = SystemColors.ControlLightLight;
            ActiveSummoner.Location = new Point(3, 724);
            ActiveSummoner.Name = "ActiveSummoner";
            ActiveSummoner.Size = new Size(136, 20);
            ActiveSummoner.TabIndex = 2;
            ActiveSummoner.Text = "Current Summoner:";
            // 
            // CurrentPatch
            // 
            CurrentPatch.AutoSize = true;
            CurrentPatch.BackColor = SystemColors.ControlText;
            CurrentPatch.ForeColor = SystemColors.ControlLightLight;
            CurrentPatch.Location = new Point(3, 793);
            CurrentPatch.Name = "CurrentPatch";
            CurrentPatch.Size = new Size(78, 15);
            CurrentPatch.TabIndex = 3;
            CurrentPatch.Text = "Patch Version";
            CurrentPatch.TextAlign = ContentAlignment.MiddleRight;
            // 
            // AramButton
            // 
            AramButton.BackColor = Color.Black;
            AramButton.BackgroundImageLayout = ImageLayout.None;
            AramButton.FlatAppearance.BorderSize = 0;
            AramButton.FlatStyle = FlatStyle.Flat;
            AramButton.ForeColor = SystemColors.ControlLightLight;
            AramButton.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            AramButton.IconColor = Color.White;
            AramButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            AramButton.ImageAlign = ContentAlignment.MiddleLeft;
            AramButton.Location = new Point(0, 316);
            AramButton.Name = "AramButton";
            AramButton.Padding = new Padding(10, 0, 20, 0);
            AramButton.Size = new Size(186, 56);
            AramButton.TabIndex = 4;
            AramButton.Text = "Aram";
            AramButton.TextAlign = ContentAlignment.MiddleLeft;
            AramButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            AramButton.UseVisualStyleBackColor = false;
            AramButton.Click += AramButton_Click;
            // 
            // ProfileButton
            // 
            ProfileButton.BackColor = Color.Black;
            ProfileButton.BackgroundImageLayout = ImageLayout.None;
            ProfileButton.FlatAppearance.BorderSize = 0;
            ProfileButton.FlatStyle = FlatStyle.Flat;
            ProfileButton.ForeColor = SystemColors.ControlLightLight;
            ProfileButton.IconChar = FontAwesome.Sharp.IconChar.HomeUser;
            ProfileButton.IconColor = Color.White;
            ProfileButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ProfileButton.ImageAlign = ContentAlignment.MiddleLeft;
            ProfileButton.Location = new Point(0, 192);
            ProfileButton.Name = "ProfileButton";
            ProfileButton.Padding = new Padding(10, 0, 20, 0);
            ProfileButton.Size = new Size(186, 56);
            ProfileButton.TabIndex = 3;
            ProfileButton.Text = "Profile";
            ProfileButton.TextAlign = ContentAlignment.MiddleLeft;
            ProfileButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            ProfileButton.UseVisualStyleBackColor = false;
            ProfileButton.Click += ProfileButton_Click;
            // 
            // RankedButton
            // 
            RankedButton.BackColor = Color.Black;
            RankedButton.BackgroundImageLayout = ImageLayout.None;
            RankedButton.FlatAppearance.BorderSize = 0;
            RankedButton.FlatStyle = FlatStyle.Flat;
            RankedButton.ForeColor = SystemColors.ControlLightLight;
            RankedButton.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            RankedButton.IconColor = Color.White;
            RankedButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            RankedButton.ImageAlign = ContentAlignment.MiddleLeft;
            RankedButton.Location = new Point(0, 254);
            RankedButton.Name = "RankedButton";
            RankedButton.Padding = new Padding(10, 0, 20, 0);
            RankedButton.Size = new Size(186, 56);
            RankedButton.TabIndex = 2;
            RankedButton.Text = "Ranked";
            RankedButton.TextAlign = ContentAlignment.MiddleLeft;
            RankedButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            RankedButton.UseVisualStyleBackColor = false;
            RankedButton.Click += RankedButton_Click;
            // 
            // ChampionButton
            // 
            ChampionButton.BackColor = Color.Black;
            ChampionButton.BackgroundImageLayout = ImageLayout.None;
            ChampionButton.FlatAppearance.BorderSize = 0;
            ChampionButton.FlatStyle = FlatStyle.Flat;
            ChampionButton.ForeColor = SystemColors.ControlLightLight;
            ChampionButton.IconChar = FontAwesome.Sharp.IconChar.Home;
            ChampionButton.IconColor = Color.White;
            ChampionButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ChampionButton.ImageAlign = ContentAlignment.MiddleLeft;
            ChampionButton.Location = new Point(0, 130);
            ChampionButton.Name = "ChampionButton";
            ChampionButton.Padding = new Padding(10, 0, 20, 0);
            ChampionButton.Size = new Size(186, 56);
            ChampionButton.TabIndex = 1;
            ChampionButton.Text = "Champion";
            ChampionButton.TextAlign = ContentAlignment.MiddleLeft;
            ChampionButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            ChampionButton.UseVisualStyleBackColor = false;
            ChampionButton.Click += ChampionButton_Click;
            // 
            // PanelTitleBar
            // 
            PanelTitleBar.BackColor = SystemColors.ActiveCaptionText;
            PanelTitleBar.Controls.Add(MinimiseButton);
            PanelTitleBar.Controls.Add(ExitButton);
            PanelTitleBar.Controls.Add(LabelFormTitle);
            PanelTitleBar.Controls.Add(IconCurrentForm);
            PanelTitleBar.Dock = DockStyle.Top;
            PanelTitleBar.Location = new Point(189, 0);
            PanelTitleBar.Name = "PanelTitleBar";
            PanelTitleBar.Size = new Size(1193, 75);
            PanelTitleBar.TabIndex = 3;
            PanelTitleBar.MouseDown += PanelTitleBar_MouseDown;
            // 
            // MinimiseButton
            // 
            MinimiseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MinimiseButton.FlatStyle = FlatStyle.Flat;
            MinimiseButton.ForeColor = SystemColors.ActiveCaptionText;
            MinimiseButton.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            MinimiseButton.IconColor = Color.White;
            MinimiseButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            MinimiseButton.IconSize = 15;
            MinimiseButton.Location = new Point(1127, -3);
            MinimiseButton.Name = "MinimiseButton";
            MinimiseButton.Size = new Size(35, 29);
            MinimiseButton.TabIndex = 4;
            MinimiseButton.UseVisualStyleBackColor = false;
            MinimiseButton.Click += MinimiseButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ExitButton.FlatStyle = FlatStyle.Flat;
            ExitButton.ForeColor = SystemColors.ActiveCaptionText;
            ExitButton.IconChar = FontAwesome.Sharp.IconChar.X;
            ExitButton.IconColor = Color.White;
            ExitButton.IconFont = FontAwesome.Sharp.IconFont.Solid;
            ExitButton.IconSize = 15;
            ExitButton.Location = new Point(1158, 0);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(35, 29);
            ExitButton.TabIndex = 2;
            ExitButton.UseVisualStyleBackColor = false;
            ExitButton.Click += ExitButton_Click;
            // 
            // LabelFormTitle
            // 
            LabelFormTitle.AutoSize = true;
            LabelFormTitle.Location = new Point(58, 26);
            LabelFormTitle.Name = "LabelFormTitle";
            LabelFormTitle.Size = new Size(40, 15);
            LabelFormTitle.TabIndex = 1;
            LabelFormTitle.Text = "Home";
            // 
            // IconCurrentForm
            // 
            IconCurrentForm.BackColor = SystemColors.ActiveCaptionText;
            IconCurrentForm.ForeColor = SystemColors.ControlLightLight;
            IconCurrentForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            IconCurrentForm.IconColor = SystemColors.ControlLightLight;
            IconCurrentForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            IconCurrentForm.Location = new Point(20, 18);
            IconCurrentForm.Name = "IconCurrentForm";
            IconCurrentForm.Size = new Size(32, 32);
            IconCurrentForm.TabIndex = 0;
            IconCurrentForm.TabStop = false;
            // 
            // PanelDesktop
            // 
            PanelDesktop.BorderStyle = BorderStyle.Fixed3D;
            PanelDesktop.Controls.Add(Title);
            PanelDesktop.Controls.Add(searchChampionListBox);
            PanelDesktop.Controls.Add(searchChampionTextBox);
            PanelDesktop.Dock = DockStyle.Fill;
            PanelDesktop.Location = new Point(189, 75);
            PanelDesktop.Name = "PanelDesktop";
            PanelDesktop.Size = new Size(1193, 761);
            PanelDesktop.TabIndex = 4;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            Title.ForeColor = SystemColors.ControlText;
            Title.Location = new Point(267, 86);
            Title.Name = "Title";
            Title.Size = new Size(293, 47);
            Title.TabIndex = 2;
            Title.Text = "Search Champion";
            // 
            // searchChampionListBox
            // 
            searchChampionListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            searchChampionListBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            searchChampionListBox.FormattingEnabled = true;
            searchChampionListBox.ItemHeight = 30;
            searchChampionListBox.Location = new Point(274, 171);
            searchChampionListBox.Name = "searchChampionListBox";
            searchChampionListBox.ScrollAlwaysVisible = true;
            searchChampionListBox.Size = new Size(602, 424);
            searchChampionListBox.TabIndex = 1;
            searchChampionListBox.Visible = false;
            searchChampionListBox.SelectedIndexChanged += SearchChampionListBox_SelectedIndexChanged;
            // 
            // searchChampionTextBox
            // 
            searchChampionTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            searchChampionTextBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            searchChampionTextBox.Location = new Point(274, 136);
            searchChampionTextBox.Name = "searchChampionTextBox";
            searchChampionTextBox.Size = new Size(602, 35);
            searchChampionTextBox.TabIndex = 0;
            searchChampionTextBox.TextChanged += SearchChampionTextBox_TextChanged;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1382, 836);
            Controls.Add(PanelDesktop);
            Controls.Add(PanelTitleBar);
            Controls.Add(PanelMenu);
            ForeColor = SystemColors.ControlLightLight;
            Name = "MainMenu";
            Text = "Project Nesja";
            Load += Form1_Load;
            Resize += MainMenu_Resize;
            ((System.ComponentModel.ISupportInitialize)Logo).EndInit();
            PanelMenu.ResumeLayout(false);
            PanelMenu.PerformLayout();
            PanelTitleBar.ResumeLayout(false);
            PanelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)IconCurrentForm).EndInit();
            PanelDesktop.ResumeLayout(false);
            PanelDesktop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Logo;
        private Panel PanelMenu;
        private FontAwesome.Sharp.IconButton ChampionButton;
        private FontAwesome.Sharp.IconButton AramButton;
        private FontAwesome.Sharp.IconButton ProfileButton;
        private FontAwesome.Sharp.IconButton RankedButton;
        private Panel PanelTitleBar;
        private Label LabelFormTitle;
        private FontAwesome.Sharp.IconPictureBox IconCurrentForm;
        private Panel PanelDesktop;
        private FontAwesome.Sharp.IconButton ExitButton;
        private FontAwesome.Sharp.IconButton MinimiseButton;
        private ListBox searchChampionListBox;
        private TextBox searchChampionTextBox;
        private Label CurrentPatch;
        private Label ActiveSummoner;
        private Button ClientConnectButton;
        private Label Title;
        private Label ActiveSummonerName;
    }
}