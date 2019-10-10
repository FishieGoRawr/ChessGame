namespace ChessGame
{
    partial class gameGUI
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
            this.board = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbGameEvents = new System.Windows.Forms.ListBox();
            this.lblP1Name = new System.Windows.Forms.Label();
            this.lblP2Name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblP1Win = new System.Windows.Forms.Label();
            this.lblP2Win = new System.Windows.Forms.Label();
            this.lblP1Lost = new System.Windows.Forms.Label();
            this.lblP2Lost = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblP2Elo = new System.Windows.Forms.Label();
            this.lblP1Elo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.BackgroundImage = global::ChessGame.Properties.Resources.board;
            this.board.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.board.Location = new System.Drawing.Point(40, 36);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(756, 756);
            this.board.TabIndex = 0;
            this.board.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_Paint);
            this.board.MouseUp += new System.Windows.Forms.MouseEventHandler(this.board_MouseUP);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 795);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Évenements:";
            // 
            // lsbGameEvents
            // 
            this.lsbGameEvents.FormattingEnabled = true;
            this.lsbGameEvents.ItemHeight = 20;
            this.lsbGameEvents.Location = new System.Drawing.Point(46, 818);
            this.lsbGameEvents.Name = "lsbGameEvents";
            this.lsbGameEvents.Size = new System.Drawing.Size(749, 204);
            this.lsbGameEvents.TabIndex = 2;
            // 
            // lblP1Name
            // 
            this.lblP1Name.AutoSize = true;
            this.lblP1Name.Location = new System.Drawing.Point(907, 69);
            this.lblP1Name.Name = "lblP1Name";
            this.lblP1Name.Size = new System.Drawing.Size(71, 20);
            this.lblP1Name.TabIndex = 3;
            this.lblP1Name.Text = "Joueur 1";
            // 
            // lblP2Name
            // 
            this.lblP2Name.AutoSize = true;
            this.lblP2Name.Location = new System.Drawing.Point(1002, 69);
            this.lblP2Name.Name = "lblP2Name";
            this.lblP2Name.Size = new System.Drawing.Size(71, 20);
            this.lblP2Name.TabIndex = 4;
            this.lblP2Name.Text = "Joueur 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(823, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Victoires:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(824, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Défaites:";
            // 
            // lblP1Win
            // 
            this.lblP1Win.AutoSize = true;
            this.lblP1Win.Location = new System.Drawing.Point(929, 110);
            this.lblP1Win.Name = "lblP1Win";
            this.lblP1Win.Size = new System.Drawing.Size(18, 20);
            this.lblP1Win.TabIndex = 7;
            this.lblP1Win.Text = "0";
            // 
            // lblP2Win
            // 
            this.lblP2Win.AutoSize = true;
            this.lblP2Win.Location = new System.Drawing.Point(1023, 110);
            this.lblP2Win.Name = "lblP2Win";
            this.lblP2Win.Size = new System.Drawing.Size(18, 20);
            this.lblP2Win.TabIndex = 8;
            this.lblP2Win.Text = "0";
            // 
            // lblP1Lost
            // 
            this.lblP1Lost.AutoSize = true;
            this.lblP1Lost.Location = new System.Drawing.Point(929, 160);
            this.lblP1Lost.Name = "lblP1Lost";
            this.lblP1Lost.Size = new System.Drawing.Size(18, 20);
            this.lblP1Lost.TabIndex = 9;
            this.lblP1Lost.Text = "0";
            // 
            // lblP2Lost
            // 
            this.lblP2Lost.AutoSize = true;
            this.lblP2Lost.Location = new System.Drawing.Point(1023, 160);
            this.lblP2Lost.Name = "lblP2Lost";
            this.lblP2Lost.Size = new System.Drawing.Size(18, 20);
            this.lblP2Lost.TabIndex = 10;
            this.lblP2Lost.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(852, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "ÉLO:";
            // 
            // lblP2Elo
            // 
            this.lblP2Elo.AutoSize = true;
            this.lblP2Elo.Location = new System.Drawing.Point(1023, 207);
            this.lblP2Elo.Name = "lblP2Elo";
            this.lblP2Elo.Size = new System.Drawing.Size(18, 20);
            this.lblP2Elo.TabIndex = 13;
            this.lblP2Elo.Text = "0";
            // 
            // lblP1Elo
            // 
            this.lblP1Elo.AutoSize = true;
            this.lblP1Elo.Location = new System.Drawing.Point(929, 207);
            this.lblP1Elo.Name = "lblP1Elo";
            this.lblP1Elo.Size = new System.Drawing.Size(18, 20);
            this.lblP1Elo.TabIndex = 12;
            this.lblP1Elo.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(817, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 210);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistiques";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "4";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 453);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "5";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 549);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "6";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 640);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "7";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 738);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 20);
            this.label12.TabIndex = 22;
            this.label12.Text = "8";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(76, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 20);
            this.label13.TabIndex = 23;
            this.label13.Text = "1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(174, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 20);
            this.label14.TabIndex = 24;
            this.label14.Text = "2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(267, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 20);
            this.label15.TabIndex = 25;
            this.label15.Text = "3";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(360, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(18, 20);
            this.label16.TabIndex = 26;
            this.label16.Text = "4";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(457, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(18, 20);
            this.label17.TabIndex = 27;
            this.label17.Text = "5";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(550, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 20);
            this.label18.TabIndex = 28;
            this.label18.Text = "6";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(647, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(18, 20);
            this.label19.TabIndex = 29;
            this.label19.Text = "7";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(741, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(18, 20);
            this.label20.TabIndex = 30;
            this.label20.Text = "8";
            // 
            // gameGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1110, 1037);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblP2Elo);
            this.Controls.Add(this.lblP1Elo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblP2Lost);
            this.Controls.Add(this.lblP1Lost);
            this.Controls.Add(this.lblP2Win);
            this.Controls.Add(this.lblP1Win);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblP2Name);
            this.Controls.Add(this.lblP1Name);
            this.Controls.Add(this.lsbGameEvents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.board);
            this.Controls.Add(this.groupBox1);
            this.Name = "gameGUI";
            this.Padding = new System.Windows.Forms.Padding(16);
            this.Text = "chessBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel board;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbGameEvents;
        private System.Windows.Forms.Label lblP1Name;
        private System.Windows.Forms.Label lblP2Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblP1Win;
        private System.Windows.Forms.Label lblP2Win;
        private System.Windows.Forms.Label lblP1Lost;
        private System.Windows.Forms.Label lblP2Lost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblP2Elo;
        private System.Windows.Forms.Label lblP1Elo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
    }
}