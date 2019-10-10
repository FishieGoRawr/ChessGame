using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    /// <summary>
    /// Classe permettant de crée un Roi
    /// </summary>
    class King : firstMovePiece
    {
        /// <summary>
        /// Constructeur de base d'un roi.
        /// </summary>
        /// <param name="p_alive"> Si le roi est en vie. </param>
        /// <param name="p_color"> La couleur de la piece. </param>
        /// <param name="p_firstMove"> Si la pièce à déjà bougée. </param>
        public King(bool p_alive, char p_color, bool p_firstMove = false) : base(p_alive, p_color, p_firstMove)
        {
        }

        /// <summary>
        /// Sert à savoir si le roi peut se déplacer sur la case de destination.
        /// </summary>
        /// <param name="coordFrom"> Case de départ. </param>
        /// <param name="coordTo"> Case de fin. </param>
        /// <param name="isEating">Sert à savoir si la pièce tente de manger une autre pièce. </param>
        /// <returns></returns>
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
