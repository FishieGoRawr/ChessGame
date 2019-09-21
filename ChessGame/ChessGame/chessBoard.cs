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
    public partial class chessBoard : Form
    {
        Game m_game;

        public chessBoard(Game p_game)
        {
            InitializeComponent();
            m_game = p_game;
        }

        private void ChessBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
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
    }
}
