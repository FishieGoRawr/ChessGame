using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    /// <summary>
    /// Classe permettant de crée une tour.
    /// </summary>
    class Rook :firstMovePiece
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_alive">Permet de savoir si la pièce est en vie.</param>
        /// <param name="p_color">Permet de savoir la couleur de la pièce. </param>
        /// <param name="p_firstMove">Permet de savoir si la pièce à effectuer son premier déplacement.</param>
        public Rook(bool p_alive, char p_color, bool p_firstMove = false) : base(p_alive, p_color, p_firstMove)
        {
        }

        /// <summary>
        /// Permet de savoir si la tour peut bouger.
        /// </summary>
        /// <param name="coordFrom">Coordonnées de départ.</param>
        /// <param name="coordTo">Coordonnées de fin.</param>
        /// <param name="isEating">Permet de savoir si la tour tente de manger une pièce.</param>
        /// <returns></returns>
        public override bool canMove(int[] coordFrom, int[] coordTo, bool isEating = false)
        {
            int Xmovement = coordFrom[0] - coordTo[0];
            int Ymovement = coordFrom[1] - coordTo[1];
            bool validMovement = false;

            validMovement = (Math.Abs(Ymovement) > 0 && Xmovement == 0) || (Math.Abs(Xmovement) > 0 && Ymovement == 0);

            return validMovement;
        }
    }
}
