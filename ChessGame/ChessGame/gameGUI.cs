using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class gameGUI : Form
    {
        Game m_game;

        public gameGUI(Game p_game)
        {
            InitializeComponent();
            m_game = p_game;
        }

        private void board_Paint(object sender, PaintEventArgs e)
        {
            //Pen blackpen = new Pen(Color.Black, 3);

            //Graphics g = e.Graphics;

            //for (int y = 0; y < 8; ++y)
            //{
            //    g.DrawLine(blackpen, 0, y * 63, 8 * 63, y * 63);
            //}

            //for (int x = 0; x < 8; ++x)
            //{
            //    g.DrawLine(blackpen, x * 63, 0, x * 63, 8 * 63);
            //}

            //g.Dispose();
        }

        private void board_MouseUP(object sender, MouseEventArgs e)
        {
            Panel boardPanel = (Panel)sender;
            int tileWidth = boardPanel.Width / 8;
            int tileHeight = boardPanel.Height / 8;


            int tileX = (e.X / tileWidth);
            int tileY = (e.Y / tileHeight);

            Console.WriteLine(tileX + "," + tileY);
        }

        private void piece_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Allo");
        }

        public void addPiece(int p_x, int p_y, string p_name, string p_imagePath = "")
        {
            int tileWidth = board.Width / 8;
            int tileHeight = board.Height / 8;
            var picture = new PictureBox
            {
                Name = p_name,
                Size = new Size(tileWidth, tileHeight),
                Location = new Point( (p_x * tileWidth) , (p_y * tileHeight)),
                Image = Image.FromFile(@p_imagePath),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
        };

            picture.MouseUp += new MouseEventHandler(piece_MouseUp);

            board.Controls.Add(picture);
        }
    }
}
