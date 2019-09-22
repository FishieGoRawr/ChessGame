using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class King : firstMovePiece
    {
        public King(bool p_alive, char p_color, string p_imagePath, bool p_firstMove = false) : base(p_alive, p_color, p_imagePath, p_firstMove)
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
