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
            this.rankedDataGrid = new System.Windows.Forms.DataGridView();
            this.ChampionImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Champion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalGames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Winrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pickrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Banrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleSelection = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.rankedDataGrid)).BeginInit();
            this.SuspendLayout();
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
            this.TotalGames,
            this.Winrate,
            this.Pickrate,
            this.Banrate});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rankedDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.rankedDataGrid.Location = new System.Drawing.Point(26, 39);
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
            this.rankedDataGrid.TabIndex = 0;
            this.rankedDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rankedDataGrid_CellClick);
            // 
            // ChampionImage
            // 
            this.ChampionImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChampionImage.FillWeight = 40F;
            this.ChampionImage.HeaderText = "Image";
            this.ChampionImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.ChampionImage.Name = "ChampionImage";
            this.ChampionImage.ReadOnly = true;
            // 
            // Champion
            // 
            this.Champion.HeaderText = "Champion";
            this.Champion.Name = "Champion";
            // 
            // TotalGames
            // 
            this.TotalGames.HeaderText = "Games Played";
            this.TotalGames.Name = "TotalGames";
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
            this.Banrate.HeaderText = "Banrate";
            this.Banrate.Name = "Banrate";
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
            this.roleSelection.Location = new System.Drawing.Point(26, 10);
            this.roleSelection.Name = "roleSelection";
            this.roleSelection.Size = new System.Drawing.Size(121, 23);
            this.roleSelection.TabIndex = 1;
            this.roleSelection.SelectedIndexChanged += new System.EventHandler(this.roleSelection_SelectedIndexChanged);
            // 
            // Ranked
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 472);
            this.Controls.Add(this.roleSelection);
            this.Controls.Add(this.rankedDataGrid);
            this.Name = "Ranked";
            this.Text = "Ranked";
            this.Load += new System.EventHandler(this.Ranked_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rankedDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView rankedDataGrid;
        private DataGridViewImageColumn ChampionImage;
        private DataGridViewTextBoxColumn Champion;
        private DataGridViewTextBoxColumn TotalGames;
        private DataGridViewTextBoxColumn Winrate;
        private DataGridViewTextBoxColumn Pickrate;
        private DataGridViewTextBoxColumn Banrate;
        private ComboBox roleSelection;
    }
}