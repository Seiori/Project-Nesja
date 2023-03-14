namespace Project_Nesja.Forms
{
    partial class ProfileLookup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchPlayerListBox = new System.Windows.Forms.ListBox();
            this.SearchPlayerTextBox = new System.Windows.Forms.TextBox();
            this.SummonerIcon = new System.Windows.Forms.PictureBox();
            this.SummonerName = new System.Windows.Forms.Label();
            this.SummonerLevel = new System.Windows.Forms.Label();
            this.SummonerRank = new System.Windows.Forms.Label();
            this.RankedSolo = new System.Windows.Forms.Label();
            this.RankedFlex = new System.Windows.Forms.Label();
            this.RankedSoloTier = new System.Windows.Forms.Label();
            this.RankedSoloLP = new System.Windows.Forms.Label();
            this.RankedSoloGames = new System.Windows.Forms.Label();
            this.RankedSoloWinrate = new System.Windows.Forms.Label();
            this.RankedFlexTier = new System.Windows.Forms.Label();
            this.RankedFlexLP = new System.Windows.Forms.Label();
            this.RankedFlexGames = new System.Windows.Forms.Label();
            this.RankedFlexWinrate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SummonerRegion = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.RegionSelector = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.RankedSoloDivision = new System.Windows.Forms.Label();
            this.RankedSoloImage = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RankedFlexDivision = new System.Windows.Forms.Label();
            this.RankedFlexImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SummonerIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RankedSoloImage)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RankedFlexImage)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchPlayerListBox
            // 
            this.SearchPlayerListBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SearchPlayerListBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SearchPlayerListBox.FormattingEnabled = true;
            this.SearchPlayerListBox.ItemHeight = 20;
            this.SearchPlayerListBox.Location = new System.Drawing.Point(593, 37);
            this.SearchPlayerListBox.Name = "SearchPlayerListBox";
            this.SearchPlayerListBox.Size = new System.Drawing.Size(249, 84);
            this.SearchPlayerListBox.TabIndex = 6;
            this.SearchPlayerListBox.SelectedIndexChanged += new System.EventHandler(this.SearchPlayerListBox_SelectedIndexChanged);
            // 
            // SearchPlayerTextBox
            // 
            this.SearchPlayerTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SearchPlayerTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SearchPlayerTextBox.Location = new System.Drawing.Point(593, 12);
            this.SearchPlayerTextBox.Name = "SearchPlayerTextBox";
            this.SearchPlayerTextBox.Size = new System.Drawing.Size(249, 29);
            this.SearchPlayerTextBox.TabIndex = 5;
            this.SearchPlayerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchPlayerTextBox_KeyDown);
            // 
            // SummonerIcon
            // 
            this.SummonerIcon.BackColor = System.Drawing.SystemColors.Control;
            this.SummonerIcon.Location = new System.Drawing.Point(3, 3);
            this.SummonerIcon.Name = "SummonerIcon";
            this.SummonerIcon.Size = new System.Drawing.Size(175, 155);
            this.SummonerIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SummonerIcon.TabIndex = 7;
            this.SummonerIcon.TabStop = false;
            // 
            // SummonerName
            // 
            this.SummonerName.AutoSize = true;
            this.SummonerName.BackColor = System.Drawing.SystemColors.Desktop;
            this.SummonerName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SummonerName.ForeColor = System.Drawing.SystemColors.Control;
            this.SummonerName.Location = new System.Drawing.Point(184, 9);
            this.SummonerName.Name = "SummonerName";
            this.SummonerName.Size = new System.Drawing.Size(154, 25);
            this.SummonerName.TabIndex = 8;
            this.SummonerName.Text = "SummonerName";
            // 
            // SummonerLevel
            // 
            this.SummonerLevel.AutoSize = true;
            this.SummonerLevel.BackColor = System.Drawing.SystemColors.Desktop;
            this.SummonerLevel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SummonerLevel.ForeColor = System.Drawing.SystemColors.Control;
            this.SummonerLevel.Location = new System.Drawing.Point(3, 143);
            this.SummonerLevel.Name = "SummonerLevel";
            this.SummonerLevel.Size = new System.Drawing.Size(124, 21);
            this.SummonerLevel.TabIndex = 9;
            this.SummonerLevel.Text = "SummonerLevel";
            this.SummonerLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SummonerRank
            // 
            this.SummonerRank.AutoSize = true;
            this.SummonerRank.BackColor = System.Drawing.SystemColors.Desktop;
            this.SummonerRank.ForeColor = System.Drawing.SystemColors.Control;
            this.SummonerRank.Location = new System.Drawing.Point(186, 34);
            this.SummonerRank.Name = "SummonerRank";
            this.SummonerRank.Size = new System.Drawing.Size(72, 15);
            this.SummonerRank.TabIndex = 10;
            this.SummonerRank.Text = "Ladder Rank";
            // 
            // RankedSolo
            // 
            this.RankedSolo.AutoSize = true;
            this.RankedSolo.BackColor = System.Drawing.SystemColors.Desktop;
            this.RankedSolo.ForeColor = System.Drawing.SystemColors.Control;
            this.RankedSolo.Location = new System.Drawing.Point(3, 12);
            this.RankedSolo.Name = "RankedSolo";
            this.RankedSolo.Size = new System.Drawing.Size(72, 15);
            this.RankedSolo.TabIndex = 11;
            this.RankedSolo.Text = "Ranked Solo";
            // 
            // RankedFlex
            // 
            this.RankedFlex.AutoSize = true;
            this.RankedFlex.BackColor = System.Drawing.SystemColors.Desktop;
            this.RankedFlex.ForeColor = System.Drawing.SystemColors.Control;
            this.RankedFlex.Location = new System.Drawing.Point(3, 14);
            this.RankedFlex.Name = "RankedFlex";
            this.RankedFlex.Size = new System.Drawing.Size(70, 15);
            this.RankedFlex.TabIndex = 12;
            this.RankedFlex.Text = "Ranked Flex";
            // 
            // RankedSoloTier
            // 
            this.RankedSoloTier.AutoSize = true;
            this.RankedSoloTier.BackColor = System.Drawing.SystemColors.Desktop;
            this.RankedSoloTier.ForeColor = System.Drawing.SystemColors.Control;
            this.RankedSoloTier.Location = new System.Drawing.Point(79, 12);
            this.RankedSoloTier.Name = "RankedSoloTier";
            this.RankedSoloTier.Size = new System.Drawing.Size(65, 15);
            this.RankedSoloTier.TabIndex = 13;
            this.RankedSoloTier.Text = "RankedTier";
            this.RankedSoloTier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RankedSoloLP
            // 
            this.RankedSoloLP.AutoSize = true;
            this.RankedSoloLP.BackColor = System.Drawing.SystemColors.Desktop;
            this.RankedSoloLP.ForeColor = System.Drawing.SystemColors.Control;
            this.RankedSoloLP.Location = new System.Drawing.Point(79, 45);
            this.RankedSoloLP.Name = "RankedSoloLP";
            this.RankedSoloLP.Size = new System.Drawing.Size(20, 15);
            this.RankedSoloLP.TabIndex = 14;
            this.RankedSoloLP.Text = "LP";
            this.RankedSoloLP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RankedSoloGames
            // 
            this.RankedSoloGames.AutoSize = true;
            this.RankedSoloGames.BackColor = System.Drawing.SystemColors.Desktop;
            this.RankedSoloGames.ForeColor = System.Drawing.SystemColors.Control;
            this.RankedSoloGames.Location = new System.Drawing.Point(79, 60);
            this.RankedSoloGames.Name = "RankedSoloGames";
            this.RankedSoloGames.Size = new System.Drawing.Size(29, 15);
            this.RankedSoloGames.TabIndex = 15;
            this.RankedSoloGames.Text = "W/L";
            this.RankedSoloGames.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RankedSoloWinrate
            // 
            this.RankedSoloWinrate.AutoSize = true;
            this.RankedSoloWinrate.BackColor = System.Drawing.SystemColors.Desktop;
            this.RankedSoloWinrate.ForeColor = System.Drawing.SystemColors.Control;
            this.RankedSoloWinrate.Location = new System.Drawing.Point(79, 81);
            this.RankedSoloWinrate.Name = "RankedSoloWinrate";
            this.RankedSoloWinrate.Size = new System.Drawing.Size(61, 15);
            this.RankedSoloWinrate.TabIndex = 16;
            this.RankedSoloWinrate.Text = "Winrate %";
            this.RankedSoloWinrate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RankedFlexTier
            // 
            this.RankedFlexTier.AutoSize = true;
            this.RankedFlexTier.BackColor = System.Drawing.SystemColors.Desktop;
            this.RankedFlexTier.ForeColor = System.Drawing.SystemColors.Control;
            this.RankedFlexTier.Location = new System.Drawing.Point(79, 14);
            this.RankedFlexTier.Name = "RankedFlexTier";
            this.RankedFlexTier.Size = new System.Drawing.Size(65, 15);
            this.RankedFlexTier.TabIndex = 17;
            this.RankedFlexTier.Text = "RankedTier";
            this.RankedFlexTier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RankedFlexLP
            // 
            this.RankedFlexLP.AutoSize = true;
            this.RankedFlexLP.BackColor = System.Drawing.SystemColors.Desktop;
            this.RankedFlexLP.ForeColor = System.Drawing.SystemColors.Control;
            this.RankedFlexLP.Location = new System.Drawing.Point(79, 47);
            this.RankedFlexLP.Name = "RankedFlexLP";
            this.RankedFlexLP.Size = new System.Drawing.Size(20, 15);
            this.RankedFlexLP.TabIndex = 18;
            this.RankedFlexLP.Text = "LP";
            this.RankedFlexLP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RankedFlexGames
            // 
            this.RankedFlexGames.AutoSize = true;
            this.RankedFlexGames.BackColor = System.Drawing.SystemColors.Desktop;
            this.RankedFlexGames.ForeColor = System.Drawing.SystemColors.Control;
            this.RankedFlexGames.Location = new System.Drawing.Point(79, 62);
            this.RankedFlexGames.Name = "RankedFlexGames";
            this.RankedFlexGames.Size = new System.Drawing.Size(29, 15);
            this.RankedFlexGames.TabIndex = 19;
            this.RankedFlexGames.Text = "W/L";
            this.RankedFlexGames.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RankedFlexWinrate
            // 
            this.RankedFlexWinrate.AutoSize = true;
            this.RankedFlexWinrate.BackColor = System.Drawing.SystemColors.Desktop;
            this.RankedFlexWinrate.ForeColor = System.Drawing.SystemColors.Control;
            this.RankedFlexWinrate.Location = new System.Drawing.Point(79, 83);
            this.RankedFlexWinrate.Name = "RankedFlexWinrate";
            this.RankedFlexWinrate.Size = new System.Drawing.Size(61, 15);
            this.RankedFlexWinrate.TabIndex = 20;
            this.RankedFlexWinrate.Text = "Winrate %";
            this.RankedFlexWinrate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.SummonerRegion);
            this.panel1.Controls.Add(this.UpdateButton);
            this.panel1.Controls.Add(this.RegionSelector);
            this.panel1.Controls.Add(this.SummonerLevel);
            this.panel1.Controls.Add(this.SummonerIcon);
            this.panel1.Controls.Add(this.SummonerRank);
            this.panel1.Controls.Add(this.SummonerName);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 181);
            this.panel1.TabIndex = 21;
            // 
            // SummonerRegion
            // 
            this.SummonerRegion.AutoSize = true;
            this.SummonerRegion.Location = new System.Drawing.Point(0, 0);
            this.SummonerRegion.Name = "SummonerRegion";
            this.SummonerRegion.Size = new System.Drawing.Size(44, 15);
            this.SummonerRegion.TabIndex = 26;
            this.SummonerRegion.Text = "Region";
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.SystemColors.Control;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.UpdateButton.Location = new System.Drawing.Point(184, 135);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 25;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // RegionSelector
            // 
            this.RegionSelector.FormattingEnabled = true;
            this.RegionSelector.Items.AddRange(new object[] {
            "BR",
            "EUNE",
            "EUW",
            "JP",
            "KR",
            "LAN",
            "LAS",
            "NA",
            "OCE",
            "PH",
            "RU",
            "SG",
            "TH",
            "TR",
            "TW",
            "VN"});
            this.RegionSelector.Location = new System.Drawing.Point(467, 14);
            this.RegionSelector.Name = "RegionSelector";
            this.RegionSelector.Size = new System.Drawing.Size(121, 23);
            this.RegionSelector.TabIndex = 24;
            this.RegionSelector.Text = "Region";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel3.Controls.Add(this.RankedSoloDivision);
            this.panel3.Controls.Add(this.RankedSoloLP);
            this.panel3.Controls.Add(this.RankedSoloImage);
            this.panel3.Controls.Add(this.RankedSoloWinrate);
            this.panel3.Controls.Add(this.RankedSolo);
            this.panel3.Controls.Add(this.RankedSoloGames);
            this.panel3.Controls.Add(this.RankedSoloTier);
            this.panel3.Location = new System.Drawing.Point(0, 181);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(178, 136);
            this.panel3.TabIndex = 23;
            // 
            // RankedSoloDivision
            // 
            this.RankedSoloDivision.AutoSize = true;
            this.RankedSoloDivision.BackColor = System.Drawing.SystemColors.Desktop;
            this.RankedSoloDivision.ForeColor = System.Drawing.SystemColors.Control;
            this.RankedSoloDivision.Location = new System.Drawing.Point(79, 30);
            this.RankedSoloDivision.Name = "RankedSoloDivision";
            this.RankedSoloDivision.Size = new System.Drawing.Size(88, 15);
            this.RankedSoloDivision.TabIndex = 25;
            this.RankedSoloDivision.Text = "RankedDivision";
            this.RankedSoloDivision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RankedSoloImage
            // 
            this.RankedSoloImage.Location = new System.Drawing.Point(3, 30);
            this.RankedSoloImage.Name = "RankedSoloImage";
            this.RankedSoloImage.Size = new System.Drawing.Size(70, 66);
            this.RankedSoloImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RankedSoloImage.TabIndex = 27;
            this.RankedSoloImage.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel2.Controls.Add(this.RankedFlexGames);
            this.panel2.Controls.Add(this.RankedFlexDivision);
            this.panel2.Controls.Add(this.RankedFlexImage);
            this.panel2.Controls.Add(this.RankedFlexWinrate);
            this.panel2.Controls.Add(this.RankedFlex);
            this.panel2.Controls.Add(this.RankedFlexLP);
            this.panel2.Controls.Add(this.RankedFlexTier);
            this.panel2.Location = new System.Drawing.Point(0, 319);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(178, 136);
            this.panel2.TabIndex = 24;
            // 
            // RankedFlexDivision
            // 
            this.RankedFlexDivision.AutoSize = true;
            this.RankedFlexDivision.BackColor = System.Drawing.SystemColors.Desktop;
            this.RankedFlexDivision.ForeColor = System.Drawing.SystemColors.Control;
            this.RankedFlexDivision.Location = new System.Drawing.Point(79, 32);
            this.RankedFlexDivision.Name = "RankedFlexDivision";
            this.RankedFlexDivision.Size = new System.Drawing.Size(88, 15);
            this.RankedFlexDivision.TabIndex = 26;
            this.RankedFlexDivision.Text = "RankedDivision";
            this.RankedFlexDivision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RankedFlexImage
            // 
            this.RankedFlexImage.Location = new System.Drawing.Point(3, 32);
            this.RankedFlexImage.Name = "RankedFlexImage";
            this.RankedFlexImage.Size = new System.Drawing.Size(70, 66);
            this.RankedFlexImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RankedFlexImage.TabIndex = 26;
            this.RankedFlexImage.TabStop = false;
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 472);
            this.Controls.Add(this.SearchPlayerListBox);
            this.Controls.Add(this.SearchPlayerTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "Profile";
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.Profile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SummonerIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RankedSoloImage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RankedFlexImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox SearchPlayerListBox;
        private TextBox SearchPlayerTextBox;
        private PictureBox SummonerIcon;
        private Label SummonerName;
        private Label SummonerLevel;
        private Label SummonerRank;
        private Label RankedSolo;
        private Label RankedFlex;
        private Label RankedSoloTier;
        private Label RankedSoloLP;
        private Label RankedSoloGames;
        private Label RankedSoloWinrate;
        private Label RankedFlexTier;
        private Label RankedFlexLP;
        private Label RankedFlexGames;
        private Label RankedFlexWinrate;
        private Panel panel1;
        private ComboBox RegionSelector;
        private Button UpdateButton;
        private Panel panel3;
        private Panel panel2;
        private PictureBox RankedFlexImage;
        private PictureBox RankedSoloImage;
        private Label RankedSoloDivision;
        private Label RankedFlexDivision;
        private Label SummonerRegion;
    }
}