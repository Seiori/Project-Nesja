namespace Project_Nesja.Forms
{
    partial class Home
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
            this.championImage = new System.Windows.Forms.PictureBox();
            this.championName = new System.Windows.Forms.Label();
            this.championTitle = new System.Windows.Forms.Label();
            this.searchChampionTextBox = new System.Windows.Forms.TextBox();
            this.searchChampionListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.championImage)).BeginInit();
            this.SuspendLayout();
            // 
            // championImage
            // 
            this.championImage.Location = new System.Drawing.Point(12, 54);
            this.championImage.Name = "championImage";
            this.championImage.Size = new System.Drawing.Size(175, 256);
            this.championImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.championImage.TabIndex = 0;
            this.championImage.TabStop = false;
            // 
            // championName
            // 
            this.championName.AutoSize = true;
            this.championName.BackColor = System.Drawing.SystemColors.Control;
            this.championName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.championName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.championName.Location = new System.Drawing.Point(12, 9);
            this.championName.Name = "championName";
            this.championName.Size = new System.Drawing.Size(146, 25);
            this.championName.TabIndex = 1;
            this.championName.Text = "championName";
            // 
            // championTitle
            // 
            this.championTitle.AutoSize = true;
            this.championTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.championTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.championTitle.Location = new System.Drawing.Point(12, 34);
            this.championTitle.Name = "championTitle";
            this.championTitle.Size = new System.Drawing.Size(89, 17);
            this.championTitle.TabIndex = 2;
            this.championTitle.Text = "championTitle";
            // 
            // searchChampionTextBox
            // 
            this.searchChampionTextBox.Location = new System.Drawing.Point(308, 9);
            this.searchChampionTextBox.Name = "searchChampionTextBox";
            this.searchChampionTextBox.Size = new System.Drawing.Size(249, 23);
            this.searchChampionTextBox.TabIndex = 3;
            this.searchChampionTextBox.TextChanged += new System.EventHandler(this.searchChampionTextBox_TextChanged);
            // 
            // searchChampionListBox
            // 
            this.searchChampionListBox.FormattingEnabled = true;
            this.searchChampionListBox.ItemHeight = 15;
            this.searchChampionListBox.Location = new System.Drawing.Point(308, 34);
            this.searchChampionListBox.Name = "searchChampionListBox";
            this.searchChampionListBox.Size = new System.Drawing.Size(249, 94);
            this.searchChampionListBox.TabIndex = 4;
            this.searchChampionListBox.SelectedIndexChanged += new System.EventHandler(this.searchChampionListBox_SelectedIndexChanged);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 472);
            this.Controls.Add(this.searchChampionListBox);
            this.Controls.Add(this.searchChampionTextBox);
            this.Controls.Add(this.championTitle);
            this.Controls.Add(this.championName);
            this.Controls.Add(this.championImage);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.championImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox championImage;
        private Label championName;
        private Label championTitle;
        private TextBox searchChampionTextBox;
        private ListBox searchChampionListBox;
    }
}