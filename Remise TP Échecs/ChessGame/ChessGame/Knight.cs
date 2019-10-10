using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    /// <summary>
    /// Classe permettant la création d'une pièce de type "Cavalier".
    /// </summary>
    class Knight :Piece
    {
        /// <summary>
        /// Constructeur de base d'un cavalier.
        /// </summary>
        /// <param name="p_alive">Sert à savoir si la pièce est en vie.</param>
        /// <param name="p_color">Sert à savoir la couleur de la pièce.</param>
        public Knight(bool p_alive, char p_color) : base(p_alive, p_color)
        {
        }

        /// <summary>
        /// Permet de savoir si la pièce peut se déplacer vers la destination passée en paramètre.
        /// </summary>
        /// <param name="coordFrom"></param>
        /// <param name="coordTo"></param>
        /// <param name="isEating"></param>
        /// <returns></returns>
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
