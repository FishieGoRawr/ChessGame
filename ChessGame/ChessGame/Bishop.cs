using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Bishop : Piece
    {
        public Bishop(bool p_alive, char p_color) : base(p_alive, p_color)
        {
        }

        public override bool canMove(int[] coordFrom, int[] coordTo, bool isEating = false)
        {
            int Xmovement = coordFrom[0] - coordTo[0];
            int Ymovement = coordFrom[1] - coordTo[1];
            bool validMovement = false;

            validMovement = Math.Abs(Ymovement) == Math.Abs(Xmovement);

            return validMovement;
        }
    }
}
