namespace Project_Nesja.Forms
{
    partial class Aram
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
            aramDataGrid = new DataGridView();
            ChampionImage = new DataGridViewImageColumn();
            Champion = new DataGridViewTextBoxColumn();
            TotalGames = new DataGridViewTextBoxColumn();
            Winrate = new DataGridViewTextBoxColumn();
            Pickrate = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)aramDataGrid).BeginInit();
            SuspendLayout();
            // 
            // aramDataGrid
            // 
            dataGridViewCellStyle1.ForeColor = Color.Black;
            aramDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            aramDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            aramDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            aramDataGrid.BackgroundColor = SystemColors.ActiveCaptionText;
            aramDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            aramDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            aramDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            aramDataGrid.Columns.AddRange(new DataGridViewColumn[] { ChampionImage, Champion, TotalGames, Winrate, Pickrate });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            aramDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            aramDataGrid.Location = new Point(36, 35);
            aramDataGrid.Name = "aramDataGrid";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            aramDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            aramDataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle5.ForeColor = Color.Black;
            aramDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            aramDataGrid.RowTemplate.Height = 60;
            aramDataGrid.Size = new Size(1106, 652);
            aramDataGrid.TabIndex = 1;
            aramDataGrid.CellClick += aramDataGrid_CellClick;
            // 
            // ChampionImage
            // 
            ChampionImage.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ChampionImage.FillWeight = 40F;
            ChampionImage.HeaderText = "Image";
            ChampionImage.ImageLayout = DataGridViewImageCellLayout.Stretch;
            ChampionImage.Name = "ChampionImage";
            ChampionImage.ReadOnly = true;
            // 
            // Champion
            // 
            Champion.HeaderText = "Champion";
            Champion.Name = "Champion";
            // 
            // TotalGames
            // 
            TotalGames.HeaderText = "Games Played";
            TotalGames.Name = "TotalGames";
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
            // Aram
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1177, 722);
            Controls.Add(aramDataGrid);
            Name = "Aram";
            Text = "Aram";
            Load += Aram_Load;
            ((System.ComponentModel.ISupportInitialize)aramDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView aramDataGrid;
        private DataGridViewImageColumn ChampionImage;
        private DataGridViewTextBoxColumn Champion;
        private DataGridViewTextBoxColumn TotalGames;
        private DataGridViewTextBoxColumn Winrate;
        private DataGridViewTextBoxColumn Pickrate;
    }
}