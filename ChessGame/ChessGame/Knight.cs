using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Knight :Piece
    {
        public Knight(bool p_alive, char p_color) : base(p_alive, p_color)
        {
        }

        public override bool canMove(int[] coordFrom, int[] coordTo, bool isEating = false)
        {
            int Xmovement = coordFrom[0] - coordTo[0];
            int Ymovement = coordFrom[1] - coordTo[1];
            bool validMovement = false;

            validMovement = ( (Math.Abs(Ymovement) == 2) && (Math.Abs(Xmovement) == 1) || (Math.Abs(Xmovement) == 2) && (Math.Abs(Ymovement) == 1) );

            return validMovement;
        }
    }
}
