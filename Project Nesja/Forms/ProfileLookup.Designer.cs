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
            SearchPlayerTextBox = new TextBox();
            SummonerIcon = new PictureBox();
            SummonerName = new Label();
            SummonerLevel = new Label();
            SummonerRank = new Label();
            RankedSolo = new Label();
            RankedFlex = new Label();
            RankedSoloTier = new Label();
            RankedSoloLP = new Label();
            RankedSoloGames = new Label();
            RankedSoloWinrate = new Label();
            RankedFlexTier = new Label();
            RankedFlexLP = new Label();
            RankedFlexGames = new Label();
            RankedFlexWinrate = new Label();
            panel1 = new Panel();
            RegionSelector = new ComboBox();
            label1 = new Label();
            StatusMessage = new TextBox();
            SummonerRegion = new Label();
            UpdateButton = new Button();
            panel3 = new Panel();
            RankedSoloDivision = new Label();
            RankedSoloImage = new PictureBox();
            panel2 = new Panel();
            RankedFlexDivision = new Label();
            RankedFlexImage = new PictureBox();
            ThirdChampion = new PictureBox();
            FirstChampion = new PictureBox();
            SecondChampion = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)SummonerIcon).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RankedSoloImage).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)RankedFlexImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ThirdChampion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FirstChampion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SecondChampion).BeginInit();
            SuspendLayout();
            // 
            // SearchPlayerTextBox
            // 
            SearchPlayerTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SearchPlayerTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SearchPlayerTextBox.Location = new Point(916, 13);
            SearchPlayerTextBox.Name = "SearchPlayerTextBox";
            SearchPlayerTextBox.Size = new Size(250, 29);
            SearchPlayerTextBox.TabIndex = 5;
            SearchPlayerTextBox.KeyDown += SearchPlayerTextBox_KeyDown;
            // 
            // SummonerIcon
            // 
            SummonerIcon.BackColor = SystemColors.Control;
            SummonerIcon.Location = new Point(3, 3);
            SummonerIcon.Name = "SummonerIcon";
            SummonerIcon.Size = new Size(175, 155);
            SummonerIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            SummonerIcon.TabIndex = 7;
            SummonerIcon.TabStop = false;
            // 
            // SummonerName
            // 
            SummonerName.AutoSize = true;
            SummonerName.BackColor = SystemColors.Desktop;
            SummonerName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            SummonerName.ForeColor = SystemColors.Control;
            SummonerName.Location = new Point(184, 9);
            SummonerName.Name = "SummonerName";
            SummonerName.Size = new Size(154, 25);
            SummonerName.TabIndex = 8;
            SummonerName.Text = "SummonerName";
            // 
            // SummonerLevel
            // 
            SummonerLevel.AutoSize = true;
            SummonerLevel.BackColor = SystemColors.Desktop;
            SummonerLevel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SummonerLevel.ForeColor = SystemColors.Control;
            SummonerLevel.Location = new Point(3, 143);
            SummonerLevel.Name = "SummonerLevel";
            SummonerLevel.Size = new Size(124, 21);
            SummonerLevel.TabIndex = 9;
            SummonerLevel.Text = "SummonerLevel";
            SummonerLevel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SummonerRank
            // 
            SummonerRank.AutoSize = true;
            SummonerRank.BackColor = SystemColors.Desktop;
            SummonerRank.ForeColor = SystemColors.Control;
            SummonerRank.Location = new Point(186, 34);
            SummonerRank.Name = "SummonerRank";
            SummonerRank.Size = new Size(72, 15);
            SummonerRank.TabIndex = 10;
            SummonerRank.Text = "Ladder Rank";
            // 
            // RankedSolo
            // 
            RankedSolo.AutoSize = true;
            RankedSolo.BackColor = SystemColors.Desktop;
            RankedSolo.ForeColor = SystemColors.Control;
            RankedSolo.Location = new Point(3, 12);
            RankedSolo.Name = "RankedSolo";
            RankedSolo.Size = new Size(72, 15);
            RankedSolo.TabIndex = 11;
            RankedSolo.Text = "Ranked Solo";
            // 
            // RankedFlex
            // 
            RankedFlex.AutoSize = true;
            RankedFlex.BackColor = SystemColors.Desktop;
            RankedFlex.ForeColor = SystemColors.Control;
            RankedFlex.Location = new Point(3, 14);
            RankedFlex.Name = "RankedFlex";
            RankedFlex.Size = new Size(70, 15);
            RankedFlex.TabIndex = 12;
            RankedFlex.Text = "Ranked Flex";
            // 
            // RankedSoloTier
            // 
            RankedSoloTier.AutoSize = true;
            RankedSoloTier.BackColor = SystemColors.Desktop;
            RankedSoloTier.ForeColor = SystemColors.Control;
            RankedSoloTier.Location = new Point(79, 12);
            RankedSoloTier.Name = "RankedSoloTier";
            RankedSoloTier.Size = new Size(65, 15);
            RankedSoloTier.TabIndex = 13;
            RankedSoloTier.Text = "RankedTier";
            RankedSoloTier.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RankedSoloLP
            // 
            RankedSoloLP.AutoSize = true;
            RankedSoloLP.BackColor = SystemColors.Desktop;
            RankedSoloLP.ForeColor = SystemColors.Control;
            RankedSoloLP.Location = new Point(79, 45);
            RankedSoloLP.Name = "RankedSoloLP";
            RankedSoloLP.Size = new Size(20, 15);
            RankedSoloLP.TabIndex = 14;
            RankedSoloLP.Text = "LP";
            RankedSoloLP.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RankedSoloGames
            // 
            RankedSoloGames.AutoSize = true;
            RankedSoloGames.BackColor = SystemColors.Desktop;
            RankedSoloGames.ForeColor = SystemColors.Control;
            RankedSoloGames.Location = new Point(79, 60);
            RankedSoloGames.Name = "RankedSoloGames";
            RankedSoloGames.Size = new Size(29, 15);
            RankedSoloGames.TabIndex = 15;
            RankedSoloGames.Text = "W/L";
            RankedSoloGames.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RankedSoloWinrate
            // 
            RankedSoloWinrate.AutoSize = true;
            RankedSoloWinrate.BackColor = SystemColors.Desktop;
            RankedSoloWinrate.ForeColor = SystemColors.Control;
            RankedSoloWinrate.Location = new Point(79, 81);
            RankedSoloWinrate.Name = "RankedSoloWinrate";
            RankedSoloWinrate.Size = new Size(61, 15);
            RankedSoloWinrate.TabIndex = 16;
            RankedSoloWinrate.Text = "Winrate %";
            RankedSoloWinrate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RankedFlexTier
            // 
            RankedFlexTier.AutoSize = true;
            RankedFlexTier.BackColor = SystemColors.Desktop;
            RankedFlexTier.ForeColor = SystemColors.Control;
            RankedFlexTier.Location = new Point(79, 14);
            RankedFlexTier.Name = "RankedFlexTier";
            RankedFlexTier.Size = new Size(65, 15);
            RankedFlexTier.TabIndex = 17;
            RankedFlexTier.Text = "RankedTier";
            RankedFlexTier.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RankedFlexLP
            // 
            RankedFlexLP.AutoSize = true;
            RankedFlexLP.BackColor = SystemColors.Desktop;
            RankedFlexLP.ForeColor = SystemColors.Control;
            RankedFlexLP.Location = new Point(79, 47);
            RankedFlexLP.Name = "RankedFlexLP";
            RankedFlexLP.Size = new Size(20, 15);
            RankedFlexLP.TabIndex = 18;
            RankedFlexLP.Text = "LP";
            RankedFlexLP.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RankedFlexGames
            // 
            RankedFlexGames.AutoSize = true;
            RankedFlexGames.BackColor = SystemColors.Desktop;
            RankedFlexGames.ForeColor = SystemColors.Control;
            RankedFlexGames.Location = new Point(79, 62);
            RankedFlexGames.Name = "RankedFlexGames";
            RankedFlexGames.Size = new Size(29, 15);
            RankedFlexGames.TabIndex = 19;
            RankedFlexGames.Text = "W/L";
            RankedFlexGames.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RankedFlexWinrate
            // 
            RankedFlexWinrate.AutoSize = true;
            RankedFlexWinrate.BackColor = SystemColors.Desktop;
            RankedFlexWinrate.ForeColor = SystemColors.Control;
            RankedFlexWinrate.Location = new Point(79, 83);
            RankedFlexWinrate.Name = "RankedFlexWinrate";
            RankedFlexWinrate.Size = new Size(61, 15);
            RankedFlexWinrate.TabIndex = 20;
            RankedFlexWinrate.Text = "Winrate %";
            RankedFlexWinrate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.Desktop;
            panel1.Controls.Add(RegionSelector);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(StatusMessage);
            panel1.Controls.Add(SummonerRegion);
            panel1.Controls.Add(SearchPlayerTextBox);
            panel1.Controls.Add(UpdateButton);
            panel1.Controls.Add(SummonerLevel);
            panel1.Controls.Add(SummonerIcon);
            panel1.Controls.Add(SummonerRank);
            panel1.Controls.Add(SummonerName);
            panel1.Location = new Point(-1, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1182, 181);
            panel1.TabIndex = 21;
            // 
            // RegionSelector
            // 
            RegionSelector.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RegionSelector.FormattingEnabled = true;
            RegionSelector.Items.AddRange(new object[] { "BR", "EUNE", "EUW", "JP", "KR", "LAN", "LAS", "NA", "OCE", "PH", "RU", "SG", "TH", "TR", "TW", "VN" });
            RegionSelector.Location = new Point(1099, 48);
            RegionSelector.Name = "RegionSelector";
            RegionSelector.Size = new Size(67, 23);
            RegionSelector.TabIndex = 24;
            RegionSelector.Text = "Region";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(184, 77);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 28;
            label1.Text = "Status";
            // 
            // StatusMessage
            // 
            StatusMessage.ForeColor = SystemColors.ControlText;
            StatusMessage.Location = new Point(186, 100);
            StatusMessage.Name = "StatusMessage";
            StatusMessage.Size = new Size(402, 23);
            StatusMessage.TabIndex = 27;
            StatusMessage.KeyDown += StatusMessage_KeyDown;
            // 
            // SummonerRegion
            // 
            SummonerRegion.AutoSize = true;
            SummonerRegion.Location = new Point(0, 0);
            SummonerRegion.Name = "SummonerRegion";
            SummonerRegion.Size = new Size(44, 15);
            SummonerRegion.TabIndex = 26;
            SummonerRegion.Text = "Region";
            // 
            // UpdateButton
            // 
            UpdateButton.BackColor = SystemColors.Control;
            UpdateButton.FlatStyle = FlatStyle.Flat;
            UpdateButton.ForeColor = SystemColors.Desktop;
            UpdateButton.Location = new Point(184, 135);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(75, 23);
            UpdateButton.TabIndex = 25;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = false;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Desktop;
            panel3.Controls.Add(RankedSoloDivision);
            panel3.Controls.Add(RankedSoloLP);
            panel3.Controls.Add(RankedSoloImage);
            panel3.Controls.Add(RankedSoloWinrate);
            panel3.Controls.Add(RankedSolo);
            panel3.Controls.Add(RankedSoloGames);
            panel3.Controls.Add(RankedSoloTier);
            panel3.Location = new Point(0, 181);
            panel3.Name = "panel3";
            panel3.Size = new Size(178, 136);
            panel3.TabIndex = 23;
            // 
            // RankedSoloDivision
            // 
            RankedSoloDivision.AutoSize = true;
            RankedSoloDivision.BackColor = SystemColors.Desktop;
            RankedSoloDivision.ForeColor = SystemColors.Control;
            RankedSoloDivision.Location = new Point(79, 30);
            RankedSoloDivision.Name = "RankedSoloDivision";
            RankedSoloDivision.Size = new Size(88, 15);
            RankedSoloDivision.TabIndex = 25;
            RankedSoloDivision.Text = "RankedDivision";
            RankedSoloDivision.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RankedSoloImage
            // 
            RankedSoloImage.Location = new Point(3, 30);
            RankedSoloImage.Name = "RankedSoloImage";
            RankedSoloImage.Size = new Size(70, 66);
            RankedSoloImage.SizeMode = PictureBoxSizeMode.StretchImage;
            RankedSoloImage.TabIndex = 27;
            RankedSoloImage.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Desktop;
            panel2.Controls.Add(RankedFlexGames);
            panel2.Controls.Add(RankedFlexDivision);
            panel2.Controls.Add(RankedFlexImage);
            panel2.Controls.Add(RankedFlexWinrate);
            panel2.Controls.Add(RankedFlex);
            panel2.Controls.Add(RankedFlexLP);
            panel2.Controls.Add(RankedFlexTier);
            panel2.Location = new Point(0, 319);
            panel2.Name = "panel2";
            panel2.Size = new Size(178, 136);
            panel2.TabIndex = 24;
            // 
            // RankedFlexDivision
            // 
            RankedFlexDivision.AutoSize = true;
            RankedFlexDivision.BackColor = SystemColors.Desktop;
            RankedFlexDivision.ForeColor = SystemColors.Control;
            RankedFlexDivision.Location = new Point(79, 32);
            RankedFlexDivision.Name = "RankedFlexDivision";
            RankedFlexDivision.Size = new Size(88, 15);
            RankedFlexDivision.TabIndex = 26;
            RankedFlexDivision.Text = "RankedDivision";
            RankedFlexDivision.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RankedFlexImage
            // 
            RankedFlexImage.Location = new Point(3, 32);
            RankedFlexImage.Name = "RankedFlexImage";
            RankedFlexImage.Size = new Size(70, 66);
            RankedFlexImage.SizeMode = PictureBoxSizeMode.StretchImage;
            RankedFlexImage.TabIndex = 26;
            RankedFlexImage.TabStop = false;
            // 
            // ThirdChampion
            // 
            ThirdChampion.Location = new Point(593, 265);
            ThirdChampion.Name = "ThirdChampion";
            ThirdChampion.Size = new Size(144, 131);
            ThirdChampion.TabIndex = 27;
            ThirdChampion.TabStop = false;
            // 
            // FirstChampion
            // 
            FirstChampion.Location = new Point(443, 241);
            FirstChampion.Name = "FirstChampion";
            FirstChampion.Size = new Size(144, 131);
            FirstChampion.TabIndex = 28;
            FirstChampion.TabStop = false;
            // 
            // SecondChampion
            // 
            SecondChampion.Location = new Point(293, 265);
            SecondChampion.Name = "SecondChampion";
            SecondChampion.Size = new Size(144, 131);
            SecondChampion.TabIndex = 29;
            SecondChampion.TabStop = false;
            // 
            // ProfileLookup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1177, 722);
            Controls.Add(SecondChampion);
            Controls.Add(FirstChampion);
            Controls.Add(ThirdChampion);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Name = "ProfileLookup";
            Text = "Profile";
            Load += Profile_Load;
            ((System.ComponentModel.ISupportInitialize)SummonerIcon).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RankedSoloImage).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)RankedFlexImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)ThirdChampion).EndInit();
            ((System.ComponentModel.ISupportInitialize)FirstChampion).EndInit();
            ((System.ComponentModel.ISupportInitialize)SecondChampion).EndInit();
            ResumeLayout(false);
        }

        #endregion
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
        private Label label1;
        private TextBox StatusMessage;
        private PictureBox ThirdChampion;
        private PictureBox FirstChampion;
        private PictureBox SecondChampion;
    }
}