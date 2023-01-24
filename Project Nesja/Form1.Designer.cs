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
            this.Logo = new System.Windows.Forms.PictureBox();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.MiscButton = new FontAwesome.Sharp.IconButton();
            this.GameButton = new FontAwesome.Sharp.IconButton();
            this.AramButton = new FontAwesome.Sharp.IconButton();
            this.ProfileButton = new FontAwesome.Sharp.IconButton();
            this.RankedButton = new FontAwesome.Sharp.IconButton();
            this.HomeButton = new FontAwesome.Sharp.IconButton();
            this.PanelTitleBar = new System.Windows.Forms.Panel();
            this.LabelFormTitle = new System.Windows.Forms.Label();
            this.IconCurrentForm = new FontAwesome.Sharp.IconPictureBox();
            this.PanelDesktop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.PanelMenu.SuspendLayout();
            this.PanelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconCurrentForm)).BeginInit();
            this.SuspendLayout();
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.InitialImage = null;
            this.Logo.Location = new System.Drawing.Point(1, 12);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(185, 72);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            this.Logo.Click += new System.EventHandler(this.Logo_Click);
            // 
            // PanelMenu
            // 
            this.PanelMenu.AutoSize = true;
            this.PanelMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelMenu.BackColor = System.Drawing.SystemColors.ControlText;
            this.PanelMenu.Controls.Add(this.MiscButton);
            this.PanelMenu.Controls.Add(this.GameButton);
            this.PanelMenu.Controls.Add(this.AramButton);
            this.PanelMenu.Controls.Add(this.ProfileButton);
            this.PanelMenu.Controls.Add(this.RankedButton);
            this.PanelMenu.Controls.Add(this.HomeButton);
            this.PanelMenu.Controls.Add(this.Logo);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.ForeColor = System.Drawing.SystemColors.Control;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(189, 586);
            this.PanelMenu.TabIndex = 2;
            this.PanelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // MiscButton
            // 
            this.MiscButton.BackColor = System.Drawing.Color.Black;
            this.MiscButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MiscButton.FlatAppearance.BorderSize = 0;
            this.MiscButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MiscButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MiscButton.IconChar = FontAwesome.Sharp.IconChar.Infinity;
            this.MiscButton.IconColor = System.Drawing.Color.White;
            this.MiscButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MiscButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MiscButton.Location = new System.Drawing.Point(0, 440);
            this.MiscButton.Name = "MiscButton";
            this.MiscButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.MiscButton.Size = new System.Drawing.Size(186, 56);
            this.MiscButton.TabIndex = 6;
            this.MiscButton.Text = "Misc";
            this.MiscButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MiscButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MiscButton.UseVisualStyleBackColor = false;
            this.MiscButton.Click += new System.EventHandler(this.MiscButton_Click);
            // 
            // GameButton
            // 
            this.GameButton.BackColor = System.Drawing.Color.Black;
            this.GameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GameButton.FlatAppearance.BorderSize = 0;
            this.GameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GameButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GameButton.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            this.GameButton.IconColor = System.Drawing.Color.White;
            this.GameButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.GameButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GameButton.Location = new System.Drawing.Point(0, 378);
            this.GameButton.Name = "GameButton";
            this.GameButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.GameButton.Size = new System.Drawing.Size(186, 56);
            this.GameButton.TabIndex = 5;
            this.GameButton.Text = "Game";
            this.GameButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GameButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.GameButton.UseVisualStyleBackColor = false;
            this.GameButton.Click += new System.EventHandler(this.GameButton_Click);
            // 
            // AramButton
            // 
            this.AramButton.BackColor = System.Drawing.Color.Black;
            this.AramButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AramButton.FlatAppearance.BorderSize = 0;
            this.AramButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AramButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AramButton.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            this.AramButton.IconColor = System.Drawing.Color.White;
            this.AramButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.AramButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AramButton.Location = new System.Drawing.Point(0, 316);
            this.AramButton.Name = "AramButton";
            this.AramButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.AramButton.Size = new System.Drawing.Size(186, 56);
            this.AramButton.TabIndex = 4;
            this.AramButton.Text = "Aram";
            this.AramButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AramButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AramButton.UseVisualStyleBackColor = false;
            this.AramButton.Click += new System.EventHandler(this.AramButton_Click);
            // 
            // ProfileButton
            // 
            this.ProfileButton.BackColor = System.Drawing.Color.Black;
            this.ProfileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ProfileButton.FlatAppearance.BorderSize = 0;
            this.ProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfileButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProfileButton.IconChar = FontAwesome.Sharp.IconChar.HomeUser;
            this.ProfileButton.IconColor = System.Drawing.Color.White;
            this.ProfileButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ProfileButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProfileButton.Location = new System.Drawing.Point(0, 192);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ProfileButton.Size = new System.Drawing.Size(186, 56);
            this.ProfileButton.TabIndex = 3;
            this.ProfileButton.Text = "Profile";
            this.ProfileButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProfileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ProfileButton.UseVisualStyleBackColor = false;
            this.ProfileButton.Click += new System.EventHandler(this.ProfileButton_Click);
            // 
            // RankedButton
            // 
            this.RankedButton.BackColor = System.Drawing.Color.Black;
            this.RankedButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RankedButton.FlatAppearance.BorderSize = 0;
            this.RankedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RankedButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RankedButton.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            this.RankedButton.IconColor = System.Drawing.Color.White;
            this.RankedButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.RankedButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RankedButton.Location = new System.Drawing.Point(0, 254);
            this.RankedButton.Name = "RankedButton";
            this.RankedButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.RankedButton.Size = new System.Drawing.Size(186, 56);
            this.RankedButton.TabIndex = 2;
            this.RankedButton.Text = "Ranked";
            this.RankedButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RankedButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RankedButton.UseVisualStyleBackColor = false;
            this.RankedButton.Click += new System.EventHandler(this.RankedButton_Click);
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.Black;
            this.HomeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.HomeButton.FlatAppearance.BorderSize = 0;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.HomeButton.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.HomeButton.IconColor = System.Drawing.Color.White;
            this.HomeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.HomeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HomeButton.Location = new System.Drawing.Point(0, 130);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.HomeButton.Size = new System.Drawing.Size(186, 56);
            this.HomeButton.TabIndex = 1;
            this.HomeButton.Text = "Home";
            this.HomeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HomeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // PanelTitleBar
            // 
            this.PanelTitleBar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PanelTitleBar.Controls.Add(this.LabelFormTitle);
            this.PanelTitleBar.Controls.Add(this.IconCurrentForm);
            this.PanelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitleBar.Location = new System.Drawing.Point(189, 0);
            this.PanelTitleBar.Name = "PanelTitleBar";
            this.PanelTitleBar.Size = new System.Drawing.Size(870, 75);
            this.PanelTitleBar.TabIndex = 3;
            this.PanelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitleBar_MouseDown);
            // 
            // LabelFormTitle
            // 
            this.LabelFormTitle.AutoSize = true;
            this.LabelFormTitle.Location = new System.Drawing.Point(58, 18);
            this.LabelFormTitle.Name = "LabelFormTitle";
            this.LabelFormTitle.Size = new System.Drawing.Size(40, 15);
            this.LabelFormTitle.TabIndex = 1;
            this.LabelFormTitle.Text = "Home";
            this.LabelFormTitle.Click += new System.EventHandler(this.LabelFormTitle_Click);
            // 
            // IconCurrentForm
            // 
            this.IconCurrentForm.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.IconCurrentForm.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.IconCurrentForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.IconCurrentForm.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.IconCurrentForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IconCurrentForm.Location = new System.Drawing.Point(20, 9);
            this.IconCurrentForm.Name = "IconCurrentForm";
            this.IconCurrentForm.Size = new System.Drawing.Size(32, 32);
            this.IconCurrentForm.TabIndex = 0;
            this.IconCurrentForm.TabStop = false;
            this.IconCurrentForm.Click += new System.EventHandler(this.IconCurrentForm_Click);
            // 
            // PanelDesktop
            // 
            this.PanelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDesktop.Location = new System.Drawing.Point(189, 75);
            this.PanelDesktop.Name = "PanelDesktop";
            this.PanelDesktop.Size = new System.Drawing.Size(870, 511);
            this.PanelDesktop.TabIndex = 4;
            this.PanelDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDesktop_Paint);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1059, 586);
            this.Controls.Add(this.PanelDesktop);
            this.Controls.Add(this.PanelTitleBar);
            this.Controls.Add(this.PanelMenu);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "MainMenu";
            this.Text = "Project Nesja";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.PanelMenu.ResumeLayout(false);
            this.PanelTitleBar.ResumeLayout(false);
            this.PanelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconCurrentForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox Logo;
        private Panel PanelMenu;
        private FontAwesome.Sharp.IconButton HomeButton;
        private FontAwesome.Sharp.IconButton MiscButton;
        private FontAwesome.Sharp.IconButton GameButton;
        private FontAwesome.Sharp.IconButton AramButton;
        private FontAwesome.Sharp.IconButton ProfileButton;
        private FontAwesome.Sharp.IconButton RankedButton;
        private Panel PanelTitleBar;
        private Label LabelFormTitle;
        private FontAwesome.Sharp.IconPictureBox IconCurrentForm;
        private Panel PanelDesktop;
    }
}