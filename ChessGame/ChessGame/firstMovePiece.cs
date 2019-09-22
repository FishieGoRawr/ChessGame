using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class firstMovePiece : Piece
    {
        bool m_firstMove;

        public firstMovePiece(bool p_alive, char p_color, string p_imagePath, bool p_firstMove = false) : base(p_alive, p_color, p_imagePath)
        {
            this.m_firstMove = p_firstMove;

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
