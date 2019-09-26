using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Rook :firstMovePiece
    {
        public Rook(bool p_alive, char p_color, bool p_firstMove = false) : base(p_alive, p_color, p_firstMove)
        {

        }

        public override bool canMove(int[] coordFrom, int[] coordTo)
        {
            int Xmovement = coordFrom[0] - coordTo[0];
            int Ymovement = coordFrom[1] - coordTo[1];
            bool validMovement = false;

            validMovement = (Math.Abs(Ymovement) > 0 && Xmovement == 0) || (Math.Abs(Xmovement) > 0 && Ymovement == 0);

            return validMovement;
        }
    }
}
