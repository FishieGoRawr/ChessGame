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
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.BackgroundImage = global::ChessGame.Properties.Resources.Board;
            this.board.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.board.Location = new System.Drawing.Point(11, 11);
            this.board.Margin = new System.Windows.Forms.Padding(2);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(504, 504);
            this.board.TabIndex = 0;
            this.board.Paint += new System.Windows.Forms.PaintEventHandler(this.board_Paint);
            this.board.MouseUp += new System.Windows.Forms.MouseEventHandler(this.board_MouseUP);
            // 
            // gameGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(533, 523);
            this.Controls.Add(this.board);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "gameGUI";
            this.Padding = new System.Windows.Forms.Padding(11);
            this.Text = "chessBoard";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.board_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel board;
    }
}