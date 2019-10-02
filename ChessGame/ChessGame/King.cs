using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class King : firstMovePiece
    {
        public King(bool p_alive, char p_color, bool p_firstMove = false) : base(p_alive, p_color, p_firstMove)
        {
        }

        public override bool canMove(int[] coordFrom, int[] coordTo, bool isEating = false)
        {
            int Xmovement = coordFrom[0] - coordTo[0];
            int Ymovement = coordFrom[1] - coordTo[1];
            bool validMovement = false;

            validMovement = ((Ymovement >= -1  && Ymovement <= 1) && (Xmovement >= -1 && Xmovement <= 1));

            //If its the piece first movement
            if (m_firstMove)
            {
                
            }
            else
            {
            }
            return validMovement;
        }
    }
}
