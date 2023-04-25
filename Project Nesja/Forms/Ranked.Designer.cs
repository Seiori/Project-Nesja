namespace Project_Nesja.Forms
{
    partial class Ranked
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            roleSelection = new ComboBox();
            Role = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            rankedDataGrid = new DataGridView();
            ChampionImage = new DataGridViewImageColumn();
            Champion = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            RolePercentage = new DataGridViewTextBoxColumn();
            Winrate = new DataGridViewTextBoxColumn();
            Pickrate = new DataGridViewTextBoxColumn();
            Banrate = new DataGridViewTextBoxColumn();
            PBI = new DataGridViewTextBoxColumn();
            TotalGames = new DataGridViewTextBoxColumn();
            minPickPercentage = new TextBox();
            minGameCount = new TextBox();
            minLanePercentage = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            RankLevelSelection = new ComboBox();
            RankLevelLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)rankedDataGrid).BeginInit();
            SuspendLayout();
            // 
            // roleSelection
            // 
            roleSelection.FormattingEnabled = true;
            roleSelection.Items.AddRange(new object[] { "All", "Top", "Jungle", "Mid", "Adc", "Support" });
            roleSelection.Location = new Point(26, 19);
            roleSelection.Name = "roleSelection";
            roleSelection.Size = new Size(121, 23);
            roleSelection.TabIndex = 1;
            roleSelection.Text = "All";
            roleSelection.SelectedIndexChanged += RoleSelection_SelectedIndexChanged;
            // 
            // Role
            // 
            Role.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Role.FillWeight = 52.34498F;
            Role.HeaderText = "Role";
            Role.Name = "Role";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // rankedDataGrid
            // 
            dataGridViewCellStyle1.ForeColor = Color.Black;
            rankedDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            rankedDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rankedDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            rankedDataGrid.BackgroundColor = SystemColors.ActiveCaptionText;
            rankedDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            rankedDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            rankedDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            rankedDataGrid.Columns.AddRange(new DataGridViewColumn[] { ChampionImage, Champion, dataGridViewTextBoxColumn3, RolePercentage, Winrate, Pickrate, Banrate, PBI, TotalGames });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            rankedDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            rankedDataGrid.Location = new Point(26, 48);
            rankedDataGrid.Name = "rankedDataGrid";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            rankedDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            rankedDataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle5.ForeColor = Color.Black;
            rankedDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            rankedDataGrid.RowTemplate.Height = 60;
            rankedDataGrid.Size = new Size(783, 402);
            rankedDataGrid.TabIndex = 2;
            rankedDataGrid.CellClick += RankedDataGrid_CellClick;
            // 
            // ChampionImage
            // 
            ChampionImage.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ChampionImage.FillWeight = 40F;
            ChampionImage.HeaderText = "Image";
            ChampionImage.ImageLayout = DataGridViewImageCellLayout.Stretch;
            ChampionImage.Name = "ChampionImage";
            ChampionImage.ReadOnly = true;
            ChampionImage.Width = 46;
            // 
            // Champion
            // 
            Champion.HeaderText = "Champion";
            Champion.Name = "Champion";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewTextBoxColumn3.HeaderText = "Role";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // RolePercentage
            // 
            RolePercentage.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            RolePercentage.HeaderText = "Role Percent";
            RolePercentage.Name = "RolePercentage";
            // 
            // Winrate
            // 
            Winrate.HeaderText = "Winrate";
            Winrate.Name = "Winrate";
            // 
            // Pickrate
            // 
            Pickrate.HeaderText = "Pickrate";
            Pickrate.Name = "Pickrate";
            // 
            // Banrate
            // 
            Banrate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Banrate.HeaderText = "Banrate";
            Banrate.Name = "Banrate";
            // 
            // PBI
            // 
            PBI.HeaderText = "PBI";
            PBI.Name = "PBI";
            // 
            // TotalGames
            // 
            TotalGames.HeaderText = "Games Played";
            TotalGames.Name = "TotalGames";
            // 
            // minPickPercentage
            // 
            minPickPercentage.Location = new Point(709, 19);
            minPickPercentage.Name = "minPickPercentage";
            minPickPercentage.Size = new Size(100, 23);
            minPickPercentage.TabIndex = 3;
            minPickPercentage.Text = "2";
            minPickPercentage.TextChanged += MinPickPercentage_TextChanged;
            minPickPercentage.KeyPress += MinPickPercentage_KeyPress;
            // 
            // minGameCount
            // 
            minGameCount.Location = new Point(603, 19);
            minGameCount.Name = "minGameCount";
            minGameCount.Size = new Size(100, 23);
            minGameCount.TabIndex = 4;
            minGameCount.Text = "100";
            minGameCount.TextChanged += MinGameCount_TextChanged;
            minGameCount.KeyPress += MinGameCount_KeyPress;
            // 
            // minLanePercentage
            // 
            minLanePercentage.Location = new Point(497, 19);
            minLanePercentage.Name = "minLanePercentage";
            minLanePercentage.Size = new Size(100, 23);
            minLanePercentage.TabIndex = 5;
            minLanePercentage.Text = "2";
            minLanePercentage.TextChanged += MinLanePercentage_TextChanged;
            minLanePercentage.KeyPress += MinLanePercentage_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Desktop;
            label1.Location = new Point(497, 1);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 6;
            label1.Text = "Min Lane %";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Desktop;
            label2.Location = new Point(603, 1);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 7;
            label2.Text = "Min Games";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Desktop;
            label3.Location = new Point(709, 1);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 8;
            label3.Text = "Min Pick %";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Desktop;
            label4.Location = new Point(26, 1);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 9;
            label4.Text = "Role Selection";
            // 
            // RankLevelSelection
            // 
            RankLevelSelection.FormattingEnabled = true;
            RankLevelSelection.Items.AddRange(new object[] { "Challenger", "Grandmaster", "Master", "Diamond", "Platinum", "Gold", "Silver", "Bronze", "Iron", "Platinum-Challenger", "Iron-Gold" });
            RankLevelSelection.Location = new Point(153, 19);
            RankLevelSelection.Name = "RankLevelSelection";
            RankLevelSelection.Size = new Size(121, 23);
            RankLevelSelection.TabIndex = 13;
            RankLevelSelection.Text = "All";
            RankLevelSelection.SelectedIndexChanged += RankLevelSelection_SelectedIndexChanged;
            // 
            // RankLevelLabel
            // 
            RankLevelLabel.AutoSize = true;
            RankLevelLabel.ForeColor = SystemColors.Desktop;
            RankLevelLabel.Location = new Point(153, 1);
            RankLevelLabel.Name = "RankLevelLabel";
            RankLevelLabel.Size = new Size(63, 15);
            RankLevelLabel.TabIndex = 14;
            RankLevelLabel.Text = "Rank Level";
            // 
            // Ranked
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(854, 472);
            Controls.Add(RankLevelLabel);
            Controls.Add(RankLevelSelection);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(minLanePercentage);
            Controls.Add(minGameCount);
            Controls.Add(minPickPercentage);
            Controls.Add(rankedDataGrid);
            Controls.Add(roleSelection);
            Name = "Ranked";
            Text = "Ranked";
            Load += Ranked_Load;
            ((System.ComponentModel.ISupportInitialize)rankedDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox roleSelection;
        private DataGridViewTextBoxColumn Role;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridView rankedDataGrid;
        private DataGridViewImageColumn ChampionImage;
        private DataGridViewTextBoxColumn Champion;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn RolePercentage;
        private DataGridViewTextBoxColumn Winrate;
        private DataGridViewTextBoxColumn Pickrate;
        private DataGridViewTextBoxColumn Banrate;
        private DataGridViewTextBoxColumn PBI;
        private DataGridViewTextBoxColumn TotalGames;
        private TextBox minPickPercentage;
        private TextBox minGameCount;
        private TextBox minLanePercentage;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox RankLevelSelection;
        private Label RankLevelLabel;
    }
}