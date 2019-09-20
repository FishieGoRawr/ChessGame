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
        public chessBoard()
        {
            InitializeComponent();
        }

        private void ChessBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen blackpen = new Pen(Color.Black, 3);

            Graphics g = e.Graphics;

            for (int y = 0; y < 8; ++y)
            {
                g.DrawLine(blackpen, 0, y * 150, 8 * 150, y * 150);
            }

            for (int x = 0; x < 8; ++x)
            {
                g.DrawLine(blackpen, x * 150, 0, x * 150, 8 * 150);
            }

            g.DrawLine(blackpen, 0, 0, 200, 200);

            g.Dispose();
        }
    }
}
