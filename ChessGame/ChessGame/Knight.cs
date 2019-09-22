using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Knight :Piece
    {
        public Knight(bool p_alive, char p_color, string p_imagePath) : base(p_alive, p_color, p_imagePath)
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
