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
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.board.Location = new System.Drawing.Point(16, 16);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(756, 756);
            this.board.TabIndex = 0;
            this.board.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_Paint);
            this.board.MouseUp += new System.Windows.Forms.MouseEventHandler(this.board_MouseUP);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 775);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Évenements:";
            // 
            // lsbGameEvents
            // 
            this.lsbGameEvents.FormattingEnabled = true;
            this.lsbGameEvents.ItemHeight = 20;
            this.lsbGameEvents.Location = new System.Drawing.Point(23, 798);
            this.lsbGameEvents.Name = "lsbGameEvents";
            this.lsbGameEvents.Size = new System.Drawing.Size(749, 204);
            this.lsbGameEvents.TabIndex = 2;
            // 
            // lblP1Name
            // 
            this.lblP1Name.AutoSize = true;
            this.lblP1Name.Location = new System.Drawing.Point(884, 49);
            this.lblP1Name.Name = "lblP1Name";
            this.lblP1Name.Size = new System.Drawing.Size(71, 20);
            this.lblP1Name.TabIndex = 3;
            this.lblP1Name.Text = "Joueur 1";
            // 
            // lblP2Name
            // 
            this.lblP2Name.AutoSize = true;
            this.lblP2Name.Location = new System.Drawing.Point(979, 49);
            this.lblP2Name.Name = "lblP2Name";
            this.lblP2Name.Size = new System.Drawing.Size(71, 20);
            this.lblP2Name.TabIndex = 4;
            this.lblP2Name.Text = "Joueur 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(800, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Victoires:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(801, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Défaites:";
            // 
            // lblP1Win
            // 
            this.lblP1Win.AutoSize = true;
            this.lblP1Win.Location = new System.Drawing.Point(906, 90);
            this.lblP1Win.Name = "lblP1Win";
            this.lblP1Win.Size = new System.Drawing.Size(18, 20);
            this.lblP1Win.TabIndex = 7;
            this.lblP1Win.Text = "0";
            // 
            // lblP2Win
            // 
            this.lblP2Win.AutoSize = true;
            this.lblP2Win.Location = new System.Drawing.Point(1000, 90);
            this.lblP2Win.Name = "lblP2Win";
            this.lblP2Win.Size = new System.Drawing.Size(18, 20);
            this.lblP2Win.TabIndex = 8;
            this.lblP2Win.Text = "0";
            // 
            // lblP1Lost
            // 
            this.lblP1Lost.AutoSize = true;
            this.lblP1Lost.Location = new System.Drawing.Point(906, 140);
            this.lblP1Lost.Name = "lblP1Lost";
            this.lblP1Lost.Size = new System.Drawing.Size(18, 20);
            this.lblP1Lost.TabIndex = 9;
            this.lblP1Lost.Text = "0";
            // 
            // lblP2Lost
            // 
            this.lblP2Lost.AutoSize = true;
            this.lblP2Lost.Location = new System.Drawing.Point(1000, 140);
            this.lblP2Lost.Name = "lblP2Lost";
            this.lblP2Lost.Size = new System.Drawing.Size(18, 20);
            this.lblP2Lost.TabIndex = 10;
            this.lblP2Lost.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(829, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "ÉLO:";
            // 
            // lblP2Elo
            // 
            this.lblP2Elo.AutoSize = true;
            this.lblP2Elo.Location = new System.Drawing.Point(1000, 187);
            this.lblP2Elo.Name = "lblP2Elo";
            this.lblP2Elo.Size = new System.Drawing.Size(18, 20);
            this.lblP2Elo.TabIndex = 13;
            this.lblP2Elo.Text = "0";
            // 
            // lblP1Elo
            // 
            this.lblP1Elo.AutoSize = true;
            this.lblP1Elo.Location = new System.Drawing.Point(906, 187);
            this.lblP1Elo.Name = "lblP1Elo";
            this.lblP1Elo.Size = new System.Drawing.Size(18, 20);
            this.lblP1Elo.TabIndex = 12;
            this.lblP1Elo.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(794, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 210);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistiques";
            // 
            // gameGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1095, 1013);
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
    }
}