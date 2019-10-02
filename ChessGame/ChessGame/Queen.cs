using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Queen : Piece
    {
        public Queen(bool p_alive, char p_color) : base( p_alive,  p_color)
        {

        }

        public override bool canMove(int[] coordFrom, int[] coordTo, bool isEating = false)
        {
            int Xmovement = coordFrom[0] - coordTo[0];
            int Ymovement = coordFrom[1] - coordTo[1];
            bool validMovement = false;

            validMovement = (Math.Abs(Ymovement) > 0 && Xmovement == 0) || (Math.Abs(Xmovement) > 0 && Ymovement == 0) || (Math.Abs(Ymovement) == Math.Abs(Xmovement));

            return validMovement;
        }
    }
}
