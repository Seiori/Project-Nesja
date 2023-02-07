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
            this.firstAbility = new System.Windows.Forms.PictureBox();
            this.thirdAbility = new System.Windows.Forms.PictureBox();
            this.secondAbility = new System.Windows.Forms.PictureBox();
            this.summonerSpell1 = new System.Windows.Forms.PictureBox();
            this.summonerSpell2 = new System.Windows.Forms.PictureBox();
            this.firstStartItem = new System.Windows.Forms.PictureBox();
            this.secondStartItem = new System.Windows.Forms.PictureBox();
            this.firstCoreItem = new System.Windows.Forms.PictureBox();
            this.secondCoreItem = new System.Windows.Forms.PictureBox();
            this.thirdCoreItem = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.banrateValue = new System.Windows.Forms.Label();
            this.totalgamesValue = new System.Windows.Forms.Label();
            this.pickrateValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.winrateValue = new System.Windows.Forms.Label();
            this.supportSelection = new System.Windows.Forms.PictureBox();
            this.topSelection = new System.Windows.Forms.PictureBox();
            this.jungleSelection = new System.Windows.Forms.PictureBox();
            this.midSelection = new System.Windows.Forms.PictureBox();
            this.bottomSelection = new System.Windows.Forms.PictureBox();
            this.sixthItem = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.summonerSpellsTitle = new System.Windows.Forms.Label();
            this.summonerSpellsData = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ItemTitle = new System.Windows.Forms.Label();
            this.itemData = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.skillTitle = new System.Windows.Forms.Label();
            this.skillData = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.championImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstAbility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdAbility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondAbility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.summonerSpell1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.summonerSpell2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstStartItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondStartItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstCoreItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondCoreItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdCoreItem)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supportSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jungleSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.midSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sixthItem)).BeginInit();
            this.SuspendLayout();
            // 
            // championImage
            // 
            this.championImage.Location = new System.Drawing.Point(12, 90);
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
            // firstAbility
            // 
            this.firstAbility.Location = new System.Drawing.Point(12, 389);
            this.firstAbility.Name = "firstAbility";
            this.firstAbility.Size = new System.Drawing.Size(47, 50);
            this.firstAbility.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.firstAbility.TabIndex = 5;
            this.firstAbility.TabStop = false;
            // 
            // thirdAbility
            // 
            this.thirdAbility.Location = new System.Drawing.Point(139, 389);
            this.thirdAbility.Name = "thirdAbility";
            this.thirdAbility.Size = new System.Drawing.Size(47, 50);
            this.thirdAbility.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.thirdAbility.TabIndex = 6;
            this.thirdAbility.TabStop = false;
            // 
            // secondAbility
            // 
            this.secondAbility.Location = new System.Drawing.Point(74, 389);
            this.secondAbility.Name = "secondAbility";
            this.secondAbility.Size = new System.Drawing.Size(47, 50);
            this.secondAbility.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.secondAbility.TabIndex = 7;
            this.secondAbility.TabStop = false;
            // 
            // summonerSpell1
            // 
            this.summonerSpell1.Location = new System.Drawing.Point(193, 210);
            this.summonerSpell1.Name = "summonerSpell1";
            this.summonerSpell1.Size = new System.Drawing.Size(41, 38);
            this.summonerSpell1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.summonerSpell1.TabIndex = 8;
            this.summonerSpell1.TabStop = false;
            // 
            // summonerSpell2
            // 
            this.summonerSpell2.Location = new System.Drawing.Point(240, 210);
            this.summonerSpell2.Name = "summonerSpell2";
            this.summonerSpell2.Size = new System.Drawing.Size(41, 38);
            this.summonerSpell2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.summonerSpell2.TabIndex = 9;
            this.summonerSpell2.TabStop = false;
            // 
            // firstStartItem
            // 
            this.firstStartItem.Location = new System.Drawing.Point(193, 296);
            this.firstStartItem.Name = "firstStartItem";
            this.firstStartItem.Size = new System.Drawing.Size(41, 39);
            this.firstStartItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.firstStartItem.TabIndex = 10;
            this.firstStartItem.TabStop = false;
            // 
            // secondStartItem
            // 
            this.secondStartItem.Location = new System.Drawing.Point(240, 296);
            this.secondStartItem.Name = "secondStartItem";
            this.secondStartItem.Size = new System.Drawing.Size(41, 39);
            this.secondStartItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.secondStartItem.TabIndex = 11;
            this.secondStartItem.TabStop = false;
            // 
            // firstCoreItem
            // 
            this.firstCoreItem.Location = new System.Drawing.Point(287, 296);
            this.firstCoreItem.Name = "firstCoreItem";
            this.firstCoreItem.Size = new System.Drawing.Size(43, 39);
            this.firstCoreItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.firstCoreItem.TabIndex = 12;
            this.firstCoreItem.TabStop = false;
            // 
            // secondCoreItem
            // 
            this.secondCoreItem.Location = new System.Drawing.Point(336, 296);
            this.secondCoreItem.Name = "secondCoreItem";
            this.secondCoreItem.Size = new System.Drawing.Size(43, 39);
            this.secondCoreItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.secondCoreItem.TabIndex = 13;
            this.secondCoreItem.TabStop = false;
            // 
            // thirdCoreItem
            // 
            this.thirdCoreItem.Location = new System.Drawing.Point(385, 296);
            this.thirdCoreItem.Name = "thirdCoreItem";
            this.thirdCoreItem.Size = new System.Drawing.Size(43, 39);
            this.thirdCoreItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.thirdCoreItem.TabIndex = 14;
            this.thirdCoreItem.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.banrateValue);
            this.panel1.Controls.Add(this.totalgamesValue);
            this.panel1.Controls.Add(this.pickrateValue);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.winrateValue);
            this.panel1.Location = new System.Drawing.Point(12, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 77);
            this.panel1.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(598, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Total Games";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(481, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Ban Rate";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(337, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Pick Rate";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // banrateValue
            // 
            this.banrateValue.AutoSize = true;
            this.banrateValue.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.banrateValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.banrateValue.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.banrateValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.banrateValue.Location = new System.Drawing.Point(481, 16);
            this.banrateValue.Name = "banrateValue";
            this.banrateValue.Size = new System.Drawing.Size(126, 27);
            this.banrateValue.TabIndex = 31;
            this.banrateValue.Text = "banrateValue";
            this.banrateValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // totalgamesValue
            // 
            this.totalgamesValue.AutoSize = true;
            this.totalgamesValue.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.totalgamesValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalgamesValue.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.totalgamesValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.totalgamesValue.Location = new System.Drawing.Point(598, 16);
            this.totalgamesValue.Name = "totalgamesValue";
            this.totalgamesValue.Size = new System.Drawing.Size(154, 27);
            this.totalgamesValue.TabIndex = 32;
            this.totalgamesValue.Text = "totalgamesValue";
            this.totalgamesValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pickrateValue
            // 
            this.pickrateValue.AutoSize = true;
            this.pickrateValue.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pickrateValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pickrateValue.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pickrateValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pickrateValue.Location = new System.Drawing.Point(337, 16);
            this.pickrateValue.Name = "pickrateValue";
            this.pickrateValue.Size = new System.Drawing.Size(128, 27);
            this.pickrateValue.TabIndex = 35;
            this.pickrateValue.Text = "pickrateValue";
            this.pickrateValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(202, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Win Rate";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // winrateValue
            // 
            this.winrateValue.AutoSize = true;
            this.winrateValue.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.winrateValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.winrateValue.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.winrateValue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.winrateValue.Location = new System.Drawing.Point(202, 16);
            this.winrateValue.Name = "winrateValue";
            this.winrateValue.Size = new System.Drawing.Size(124, 27);
            this.winrateValue.TabIndex = 16;
            this.winrateValue.Text = "winrateValue";
            this.winrateValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // supportSelection
            // 
            this.supportSelection.Image = global::Project_Nesja.Properties.Resources.Position_Master_Support;
            this.supportSelection.Location = new System.Drawing.Point(156, 61);
            this.supportSelection.Name = "supportSelection";
            this.supportSelection.Size = new System.Drawing.Size(30, 29);
            this.supportSelection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.supportSelection.TabIndex = 25;
            this.supportSelection.TabStop = false;
            this.supportSelection.Click += new System.EventHandler(this.supportSelection_Click);
            // 
            // topSelection
            // 
            this.topSelection.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.topSelection.Image = global::Project_Nesja.Properties.Resources.Position_Master_Top;
            this.topSelection.Location = new System.Drawing.Point(12, 61);
            this.topSelection.Name = "topSelection";
            this.topSelection.Size = new System.Drawing.Size(30, 29);
            this.topSelection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.topSelection.TabIndex = 26;
            this.topSelection.TabStop = false;
            this.topSelection.Click += new System.EventHandler(this.topSelection_Click);
            // 
            // jungleSelection
            // 
            this.jungleSelection.Image = global::Project_Nesja.Properties.Resources.Position_Master_Jungle;
            this.jungleSelection.Location = new System.Drawing.Point(48, 61);
            this.jungleSelection.Name = "jungleSelection";
            this.jungleSelection.Size = new System.Drawing.Size(30, 29);
            this.jungleSelection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.jungleSelection.TabIndex = 27;
            this.jungleSelection.TabStop = false;
            this.jungleSelection.Click += new System.EventHandler(this.jungleSelection_Click);
            // 
            // midSelection
            // 
            this.midSelection.Image = global::Project_Nesja.Properties.Resources.Position_Master_Mid;
            this.midSelection.Location = new System.Drawing.Point(84, 61);
            this.midSelection.Name = "midSelection";
            this.midSelection.Size = new System.Drawing.Size(30, 29);
            this.midSelection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.midSelection.TabIndex = 28;
            this.midSelection.TabStop = false;
            this.midSelection.Click += new System.EventHandler(this.midSelection_Click);
            // 
            // bottomSelection
            // 
            this.bottomSelection.Image = global::Project_Nesja.Properties.Resources.Position_Master_Bot;
            this.bottomSelection.Location = new System.Drawing.Point(120, 61);
            this.bottomSelection.Name = "bottomSelection";
            this.bottomSelection.Size = new System.Drawing.Size(30, 29);
            this.bottomSelection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bottomSelection.TabIndex = 29;
            this.bottomSelection.TabStop = false;
            this.bottomSelection.Click += new System.EventHandler(this.bottomSelection_Click);
            // 
            // sixthItem
            // 
            this.sixthItem.Location = new System.Drawing.Point(434, 296);
            this.sixthItem.Name = "sixthItem";
            this.sixthItem.Size = new System.Drawing.Size(43, 39);
            this.sixthItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sixthItem.TabIndex = 30;
            this.sixthItem.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(193, 173);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(11, 16);
            this.panel2.TabIndex = 31;
            // 
            // summonerSpellsTitle
            // 
            this.summonerSpellsTitle.AutoSize = true;
            this.summonerSpellsTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.summonerSpellsTitle.Location = new System.Drawing.Point(209, 174);
            this.summonerSpellsTitle.Name = "summonerSpellsTitle";
            this.summonerSpellsTitle.Size = new System.Drawing.Size(99, 15);
            this.summonerSpellsTitle.TabIndex = 32;
            this.summonerSpellsTitle.Text = "Summoner Spells";
            // 
            // summonerSpellsData
            // 
            this.summonerSpellsData.AutoSize = true;
            this.summonerSpellsData.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.summonerSpellsData.Location = new System.Drawing.Point(193, 192);
            this.summonerSpellsData.Name = "summonerSpellsData";
            this.summonerSpellsData.Size = new System.Drawing.Size(139, 15);
            this.summonerSpellsData.TabIndex = 33;
            this.summonerSpellsData.Text = "40.30% (323414) Matches";
            this.summonerSpellsData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(193, 259);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(11, 16);
            this.panel3.TabIndex = 34;
            // 
            // ItemTitle
            // 
            this.ItemTitle.AutoSize = true;
            this.ItemTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ItemTitle.Location = new System.Drawing.Point(209, 259);
            this.ItemTitle.Name = "ItemTitle";
            this.ItemTitle.Size = new System.Drawing.Size(36, 15);
            this.ItemTitle.TabIndex = 35;
            this.ItemTitle.Text = "Items\r\n";
            // 
            // itemData
            // 
            this.itemData.AutoSize = true;
            this.itemData.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.itemData.Location = new System.Drawing.Point(193, 278);
            this.itemData.Name = "itemData";
            this.itemData.Size = new System.Drawing.Size(139, 15);
            this.itemData.TabIndex = 36;
            this.itemData.Text = "40.30% (323414) Matches";
            this.itemData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Location = new System.Drawing.Point(12, 352);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(11, 16);
            this.panel4.TabIndex = 37;
            // 
            // skillTitle
            // 
            this.skillTitle.AutoSize = true;
            this.skillTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.skillTitle.Location = new System.Drawing.Point(29, 353);
            this.skillTitle.Name = "skillTitle";
            this.skillTitle.Size = new System.Drawing.Size(69, 15);
            this.skillTitle.TabIndex = 38;
            this.skillTitle.Text = "Skill Priority";
            // 
            // skillData
            // 
            this.skillData.AutoSize = true;
            this.skillData.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.skillData.Location = new System.Drawing.Point(11, 371);
            this.skillData.Name = "skillData";
            this.skillData.Size = new System.Drawing.Size(139, 15);
            this.skillData.TabIndex = 39;
            this.skillData.Text = "40.30% (323414) Matches";
            this.skillData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 472);
            this.Controls.Add(this.skillData);
            this.Controls.Add(this.skillTitle);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.itemData);
            this.Controls.Add(this.ItemTitle);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.summonerSpellsData);
            this.Controls.Add(this.summonerSpellsTitle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.sixthItem);
            this.Controls.Add(this.bottomSelection);
            this.Controls.Add(this.midSelection);
            this.Controls.Add(this.jungleSelection);
            this.Controls.Add(this.topSelection);
            this.Controls.Add(this.supportSelection);
            this.Controls.Add(this.thirdCoreItem);
            this.Controls.Add(this.secondCoreItem);
            this.Controls.Add(this.firstCoreItem);
            this.Controls.Add(this.secondStartItem);
            this.Controls.Add(this.firstStartItem);
            this.Controls.Add(this.summonerSpell2);
            this.Controls.Add(this.summonerSpell1);
            this.Controls.Add(this.secondAbility);
            this.Controls.Add(this.thirdAbility);
            this.Controls.Add(this.firstAbility);
            this.Controls.Add(this.searchChampionListBox);
            this.Controls.Add(this.searchChampionTextBox);
            this.Controls.Add(this.championTitle);
            this.Controls.Add(this.championName);
            this.Controls.Add(this.championImage);
            this.Controls.Add(this.panel1);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.championImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstAbility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdAbility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondAbility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.summonerSpell1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.summonerSpell2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstStartItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondStartItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstCoreItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondCoreItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdCoreItem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supportSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jungleSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.midSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sixthItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox championImage;
        private Label championName;
        private Label championTitle;
        private TextBox searchChampionTextBox;
        private ListBox searchChampionListBox;
        private PictureBox firstAbility;
        private PictureBox thirdAbility;
        private PictureBox secondAbility;
        private PictureBox summonerSpell1;
        private PictureBox summonerSpell2;
        private PictureBox firstStartItem;
        private PictureBox secondStartItem;
        private PictureBox firstCoreItem;
        private PictureBox secondCoreItem;
        private PictureBox thirdCoreItem;
        private Panel panel1;
        private Label winrateValue;
        private PictureBox supportSelection;
        private PictureBox topSelection;
        private PictureBox jungleSelection;
        private PictureBox midSelection;
        private PictureBox bottomSelection;
        private PictureBox sixthItem;
        private Label banrateValue;
        private Label totalgamesValue;
        private Label pickrateValue;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label1;
        private Panel panel2;
        private Label summonerSpellsTitle;
        private Label summonerSpellsData;
        private Panel panel3;
        private Label ItemTitle;
        private Label itemData;
        private Panel panel4;
        private Label skillTitle;
        private Label skillData;
    }
}