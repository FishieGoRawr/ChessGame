using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Queen : Piece
    {
        public Queen(bool p_alive, char p_color, string p_imagePath) : base( p_alive,  p_color,  p_imagePath)
        {
            if (p_color == 'W')
            {
                p_imagePath = "";
            }
            else
            {
                p_imagePath = "";
            }
        }
    }
}
