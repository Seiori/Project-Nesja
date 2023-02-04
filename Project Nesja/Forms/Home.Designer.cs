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
            this.qAbilityPicture = new System.Windows.Forms.PictureBox();
            this.eAbilityPicture = new System.Windows.Forms.PictureBox();
            this.wAbilityPicture = new System.Windows.Forms.PictureBox();
            this.itemTest1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.championImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qAbilityPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eAbilityPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wAbilityPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemTest1)).BeginInit();
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
            this.searchChampionTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.searchChampionTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchChampionTextBox.Location = new System.Drawing.Point(308, 9);
            this.searchChampionTextBox.Name = "searchChampionTextBox";
            this.searchChampionTextBox.Size = new System.Drawing.Size(249, 29);
            this.searchChampionTextBox.TabIndex = 3;
            this.searchChampionTextBox.TextChanged += new System.EventHandler(this.searchChampionTextBox_TextChanged);
            // 
            // searchChampionListBox
            // 
            this.searchChampionListBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.searchChampionListBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchChampionListBox.FormattingEnabled = true;
            this.searchChampionListBox.ItemHeight = 20;
            this.searchChampionListBox.Location = new System.Drawing.Point(308, 34);
            this.searchChampionListBox.Name = "searchChampionListBox";
            this.searchChampionListBox.Size = new System.Drawing.Size(249, 84);
            this.searchChampionListBox.TabIndex = 4;
            this.searchChampionListBox.SelectedIndexChanged += new System.EventHandler(this.searchChampionListBox_SelectedIndexChanged);
            // 
            // qAbilityPicture
            // 
            this.qAbilityPicture.Location = new System.Drawing.Point(12, 326);
            this.qAbilityPicture.Name = "qAbilityPicture";
            this.qAbilityPicture.Size = new System.Drawing.Size(47, 50);
            this.qAbilityPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.qAbilityPicture.TabIndex = 5;
            this.qAbilityPicture.TabStop = false;
            // 
            // eAbilityPicture
            // 
            this.eAbilityPicture.Location = new System.Drawing.Point(140, 326);
            this.eAbilityPicture.Name = "eAbilityPicture";
            this.eAbilityPicture.Size = new System.Drawing.Size(47, 50);
            this.eAbilityPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.eAbilityPicture.TabIndex = 6;
            this.eAbilityPicture.TabStop = false;
            // 
            // wAbilityPicture
            // 
            this.wAbilityPicture.Location = new System.Drawing.Point(75, 326);
            this.wAbilityPicture.Name = "wAbilityPicture";
            this.wAbilityPicture.Size = new System.Drawing.Size(47, 50);
            this.wAbilityPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.wAbilityPicture.TabIndex = 7;
            this.wAbilityPicture.TabStop = false;
            // 
            // itemTest1
            // 
            this.itemTest1.Location = new System.Drawing.Point(558, 229);
            this.itemTest1.Name = "itemTest1";
            this.itemTest1.Size = new System.Drawing.Size(100, 50);
            this.itemTest1.TabIndex = 8;
            this.itemTest1.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 472);
            this.Controls.Add(this.itemTest1);
            this.Controls.Add(this.wAbilityPicture);
            this.Controls.Add(this.eAbilityPicture);
            this.Controls.Add(this.qAbilityPicture);
            this.Controls.Add(this.searchChampionListBox);
            this.Controls.Add(this.searchChampionTextBox);
            this.Controls.Add(this.championTitle);
            this.Controls.Add(this.championName);
            this.Controls.Add(this.championImage);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.championImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qAbilityPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eAbilityPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wAbilityPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemTest1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox championImage;
        private Label championName;
        private Label championTitle;
        private TextBox searchChampionTextBox;
        private ListBox searchChampionListBox;
        private PictureBox qAbilityPicture;
        private PictureBox eAbilityPicture;
        private PictureBox wAbilityPicture;
        private PictureBox itemTest1;
    }
}