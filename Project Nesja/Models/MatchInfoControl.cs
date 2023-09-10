using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Nesja.Models
{
    public class MatchInfoControl : UserControl
    {
        public MatchInfoControl(string result, Image championImage, string kda)
        {
            InitializeComponent();

            Result.Text = result;
            ChampionImage.Image = championImage;
            KDAValue.Text = kda;
        }

        private void InitializeComponent()
        {
            GameMode = new Label();
            TimeSinceGame = new Label();
            GameLength = new Label();
            Result = new Label();
            ChampionImage = new PictureBox();
            Level = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            KDA = new Label();
            KDAValue = new Label();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox8 = new PictureBox();
            pictureBox9 = new PictureBox();
            pictureBox10 = new PictureBox();
            BestMultiKill = new Label();
            pictureBox11 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)ChampionImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            SuspendLayout();
            // 
            // GameMode
            // 
            GameMode.AutoSize = true;
            GameMode.BackColor = SystemColors.Control;
            GameMode.ForeColor = Color.Black;
            GameMode.Location = new Point(3, 0);
            GameMode.Name = "GameMode";
            GameMode.Size = new Size(69, 15);
            GameMode.TabIndex = 0;
            GameMode.Text = "GameMode";
            // 
            // TimeSinceGame
            // 
            TimeSinceGame.AutoSize = true;
            TimeSinceGame.BackColor = SystemColors.Control;
            TimeSinceGame.ForeColor = Color.Black;
            TimeSinceGame.Location = new Point(3, 15);
            TimeSinceGame.Name = "TimeSinceGame";
            TimeSinceGame.Size = new Size(92, 15);
            TimeSinceGame.TabIndex = 1;
            TimeSinceGame.Text = "TimeSinceGame";
            // 
            // GameLength
            // 
            GameLength.AutoSize = true;
            GameLength.BackColor = SystemColors.Control;
            GameLength.ForeColor = Color.Black;
            GameLength.Location = new Point(3, 85);
            GameLength.Name = "GameLength";
            GameLength.Size = new Size(75, 15);
            GameLength.TabIndex = 2;
            GameLength.Text = "GameLength";
            // 
            // Result
            // 
            Result.AutoSize = true;
            Result.BackColor = SystemColors.Control;
            Result.ForeColor = Color.Black;
            Result.Location = new Point(3, 70);
            Result.Name = "Result";
            Result.Size = new Size(39, 15);
            Result.TabIndex = 3;
            Result.Text = "Result";
            // 
            // ChampionImage
            // 
            ChampionImage.Location = new Point(101, 3);
            ChampionImage.Name = "ChampionImage";
            ChampionImage.Size = new Size(100, 64);
            ChampionImage.SizeMode = PictureBoxSizeMode.StretchImage;
            ChampionImage.TabIndex = 4;
            ChampionImage.TabStop = false;
            // 
            // Level
            // 
            Level.AutoSize = true;
            Level.BackColor = SystemColors.Control;
            Level.ForeColor = Color.Black;
            Level.Location = new Point(167, 52);
            Level.Name = "Level";
            Level.Size = new Size(34, 15);
            Level.TabIndex = 5;
            Level.Text = "Level";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(203, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 31);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(203, 36);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(45, 31);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(254, 36);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(45, 31);
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(254, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(45, 31);
            pictureBox4.TabIndex = 8;
            pictureBox4.TabStop = false;
            // 
            // KDA
            // 
            KDA.AutoSize = true;
            KDA.BackColor = SystemColors.Control;
            KDA.ForeColor = Color.Black;
            KDA.Location = new Point(305, 15);
            KDA.Name = "KDA";
            KDA.Size = new Size(30, 15);
            KDA.TabIndex = 10;
            KDA.Text = "KDA";
            // 
            // KDAValue
            // 
            KDAValue.AutoSize = true;
            KDAValue.BackColor = SystemColors.Control;
            KDAValue.ForeColor = Color.Black;
            KDAValue.Location = new Point(305, 36);
            KDAValue.Name = "KDAValue";
            KDAValue.Size = new Size(61, 15);
            KDAValue.TabIndex = 11;
            KDAValue.Text = "KDA Value";
            // 
            // pictureBox5
            // 
            pictureBox5.Location = new Point(101, 70);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(31, 30);
            pictureBox5.TabIndex = 12;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Location = new Point(138, 70);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(31, 30);
            pictureBox6.TabIndex = 13;
            pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.Location = new Point(175, 70);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(31, 30);
            pictureBox7.TabIndex = 14;
            pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.Location = new Point(212, 70);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(31, 30);
            pictureBox8.TabIndex = 15;
            pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.Location = new Point(249, 70);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(31, 30);
            pictureBox9.TabIndex = 16;
            pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            pictureBox10.Location = new Point(286, 70);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(31, 30);
            pictureBox10.TabIndex = 17;
            pictureBox10.TabStop = false;
            // 
            // BestMultiKill
            // 
            BestMultiKill.AutoSize = true;
            BestMultiKill.BackColor = SystemColors.Control;
            BestMultiKill.ForeColor = Color.Black;
            BestMultiKill.Location = new Point(369, 70);
            BestMultiKill.Name = "BestMultiKill";
            BestMultiKill.Size = new Size(73, 15);
            BestMultiKill.TabIndex = 18;
            BestMultiKill.Text = "BestMultiKill";
            // 
            // pictureBox11
            // 
            pictureBox11.Location = new Point(323, 70);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(31, 30);
            pictureBox11.TabIndex = 19;
            pictureBox11.TabStop = false;
            // 
            // MatchInfoControl
            // 
            Controls.Add(pictureBox11);
            Controls.Add(BestMultiKill);
            Controls.Add(pictureBox10);
            Controls.Add(pictureBox9);
            Controls.Add(pictureBox8);
            Controls.Add(pictureBox7);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(KDAValue);
            Controls.Add(KDA);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(Level);
            Controls.Add(ChampionImage);
            Controls.Add(Result);
            Controls.Add(GameLength);
            Controls.Add(TimeSinceGame);
            Controls.Add(GameMode);
            Name = "MatchInfoControl";
            Size = new Size(1000, 100);
            Load += MatchInfoControl_Load;
            ((System.ComponentModel.ISupportInitialize)ChampionImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void MatchInfoControl_Load(object sender, EventArgs e)
        {

        }

        private Label GameMode;
        private Label TimeSinceGame;
        private Label GameLength;
        private Label Result;
        private PictureBox ChampionImage;
        private Label Level;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label KDA;
        private Label KDAValue;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private PictureBox pictureBox10;
        private Label BestMultiKill;
        private PictureBox pictureBox11;
        private PictureBox pictureBox2;
    }
}
