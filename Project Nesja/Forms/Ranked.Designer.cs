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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.roleSelection = new System.Windows.Forms.ComboBox();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rankedDataGrid = new System.Windows.Forms.DataGridView();
            this.ChampionImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Champion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RolePercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Winrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pickrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PBI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalGames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minPickPercentage = new System.Windows.Forms.TextBox();
            this.minGameCount = new System.Windows.Forms.TextBox();
            this.minLanePercentage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rankedDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // roleSelection
            // 
            this.roleSelection.FormattingEnabled = true;
            this.roleSelection.Items.AddRange(new object[] {
            "All",
            "Top",
            "Jungle",
            "Mid",
            "Adc",
            "Support"});
            this.roleSelection.Location = new System.Drawing.Point(26, 19);
            this.roleSelection.Name = "roleSelection";
            this.roleSelection.Size = new System.Drawing.Size(121, 23);
            this.roleSelection.TabIndex = 1;
            this.roleSelection.SelectedIndexChanged += new System.EventHandler(this.roleSelection_SelectedIndexChanged);
            // 
            // Role
            // 
            this.Role.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Role.FillWeight = 52.34498F;
            this.Role.HeaderText = "Role";
            this.Role.Name = "Role";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // rankedDataGrid
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.rankedDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.rankedDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rankedDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rankedDataGrid.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rankedDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rankedDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.rankedDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rankedDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChampionImage,
            this.Champion,
            this.dataGridViewTextBoxColumn3,
            this.RolePercentage,
            this.Winrate,
            this.Pickrate,
            this.Banrate,
            this.PBI,
            this.TotalGames});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rankedDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.rankedDataGrid.Location = new System.Drawing.Point(26, 48);
            this.rankedDataGrid.Name = "rankedDataGrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rankedDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.rankedDataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.rankedDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.rankedDataGrid.RowTemplate.Height = 60;
            this.rankedDataGrid.Size = new System.Drawing.Size(783, 402);
            this.rankedDataGrid.TabIndex = 2;
            // 
            // ChampionImage
            // 
            this.ChampionImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ChampionImage.FillWeight = 40F;
            this.ChampionImage.HeaderText = "Image";
            this.ChampionImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.ChampionImage.Name = "ChampionImage";
            this.ChampionImage.ReadOnly = true;
            this.ChampionImage.Width = 46;
            // 
            // Champion
            // 
            this.Champion.HeaderText = "Champion";
            this.Champion.Name = "Champion";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.HeaderText = "Role";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // RolePercentage
            // 
            this.RolePercentage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RolePercentage.HeaderText = "Role Percent";
            this.RolePercentage.Name = "RolePercentage";
            // 
            // Winrate
            // 
            this.Winrate.HeaderText = "Winrate";
            this.Winrate.Name = "Winrate";
            // 
            // Pickrate
            // 
            this.Pickrate.HeaderText = "Pickrate";
            this.Pickrate.Name = "Pickrate";
            // 
            // Banrate
            // 
            this.Banrate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Banrate.HeaderText = "Banrate";
            this.Banrate.Name = "Banrate";
            // 
            // PBI
            // 
            this.PBI.HeaderText = "PBI";
            this.PBI.Name = "PBI";
            // 
            // TotalGames
            // 
            this.TotalGames.HeaderText = "Games Played";
            this.TotalGames.Name = "TotalGames";
            // 
            // minPickPercentage
            // 
            this.minPickPercentage.Location = new System.Drawing.Point(709, 19);
            this.minPickPercentage.Name = "minPickPercentage";
            this.minPickPercentage.Size = new System.Drawing.Size(100, 23);
            this.minPickPercentage.TabIndex = 3;
            this.minPickPercentage.TextChanged += new System.EventHandler(this.minPickPercentage_TextChanged);
            this.minPickPercentage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.minPickPercentage_KeyPress);
            // 
            // minGameCount
            // 
            this.minGameCount.Location = new System.Drawing.Point(603, 19);
            this.minGameCount.Name = "minGameCount";
            this.minGameCount.Size = new System.Drawing.Size(100, 23);
            this.minGameCount.TabIndex = 4;
            this.minGameCount.TextChanged += new System.EventHandler(this.minGameCount_TextChanged);
            this.minGameCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.minGameCount_KeyPress);
            // 
            // minLanePercentage
            // 
            this.minLanePercentage.Location = new System.Drawing.Point(497, 19);
            this.minLanePercentage.Name = "minLanePercentage";
            this.minLanePercentage.Size = new System.Drawing.Size(100, 23);
            this.minLanePercentage.TabIndex = 5;
            this.minLanePercentage.TextChanged += new System.EventHandler(this.minLanePercentage_TextChanged);
            this.minLanePercentage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.minLanePercentage_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(497, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Min Lane %";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(603, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Min Games";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(709, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Min Pick %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(26, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Role Selection";
            // 
            // Ranked
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 472);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minLanePercentage);
            this.Controls.Add(this.minGameCount);
            this.Controls.Add(this.minPickPercentage);
            this.Controls.Add(this.rankedDataGrid);
            this.Controls.Add(this.roleSelection);
            this.Name = "Ranked";
            this.Text = "Ranked";
            this.Load += new System.EventHandler(this.Ranked_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rankedDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}