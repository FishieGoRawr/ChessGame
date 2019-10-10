using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    /// <summary>
    /// Classe permettant de créer une reine.
    /// </summary>
    class Queen : Piece
    {
        /// <summary>
        /// Constructeur par défaut d'une reine.
        /// </summary>
        /// <param name="p_alive">Sert a savoir si la reine est en vie. </param>
        /// <param name="p_color">Couleur de la reine. </param>
        public Queen(bool p_alive, char p_color) : base( p_alive,  p_color)
        {
        }

        /// <summary>
        /// Sert à déterminé si la reine peut bougé vers la direction donnée.
        /// </summary>
        /// <param name="coordFrom">Coordonnée de départ. </param>
        /// <param name="coordTo">Coordonnée de fin. </param>
        /// <param name="isEating">Sert à savoir si la riene tente de manger une pièce. </param>
        /// <returns>Vrai si la pièce peut bouger. Sinon, retourne faux.</returns>
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
