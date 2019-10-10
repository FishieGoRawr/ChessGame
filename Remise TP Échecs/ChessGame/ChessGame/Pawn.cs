using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    /// <summary>
    /// Classe permettant de créer un pion.
    /// </summary>
    class Pawn : firstMovePiece
    {
        /// <summary>
        /// Constructeur de base d'un pion.
        /// </summary>
        /// <param name="p_alive"> Si le pion est en vie.</param>
        /// <param name="p_color">La couleur du pion. </param>
        /// <param name="p_firstMove">Si le pion à déjà bougé. </param>
        public Pawn(bool p_alive, char p_color, bool p_firstMove = false) : base(p_alive, p_color, p_firstMove)
        {            
        }

        /// <summary>
        /// Sert à savoir si le pion peut se déplacer a des coordonnées données.
        /// </summary>
        /// <param name="coordFrom">Point de départ de la pièce. </param>
        /// <param name="coordTo">Point de fin de la pièce. </param>
        /// <param name="isEating">Si la pièce tente de manger. </param>
        /// <returns></returns>
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
