using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Pawn : firstMovePiece
    {
        public Pawn(bool p_alive, char p_color, bool p_firstMove = false) : base(p_alive, p_color, p_firstMove)
        {
            
        }

        public override bool canMove(int[]coordFrom, int[] coordTo, bool isEating = false)
        {
            int Xmovement = coordFrom[0] - coordTo[0];
            int Ymovement = coordFrom[1] - coordTo[1];
            bool validMovement = false;

            //If its the piece first movement
            if (m_firstMove && !isEating)
            {
                if (this.m_color == 'W')
                {
                    validMovement = ((Ymovement <= 2 && Ymovement > 0) && (Xmovement == 0));
                }
                else if (this.m_color == 'B')
                {
                    validMovement = ((Ymovement >= -2 && Ymovement < 0) && (Xmovement == 0));
                }
            }
            else
            {
                //If we are eating another piece
                if (isEating)
                {
                    if (this.m_color == 'W')
                    {
                        validMovement = (Ymovement == 1) && ((Xmovement == 1) || (Xmovement == -1));
                    }
                    else if (this.m_color == 'B')
                    {
                        validMovement = (Ymovement == -1) && ((Xmovement == 1) || (Xmovement == -1));
                    }
                }
                else
                {
                    if (this.m_color == 'W')
                    {
                        validMovement = ((Ymovement == 1) && (Xmovement == 0));
                    }
                    else if (this.m_color == 'B')
                    {
                        validMovement = ((Ymovement == -1) && (Xmovement == 0));
                    }
                }
            }
            return validMovement;
        }
    }
}
