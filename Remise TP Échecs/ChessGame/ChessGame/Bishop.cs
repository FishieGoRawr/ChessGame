using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessGame
{
    /// <summary>
    /// Classe enfant de "Pièce", sert à set un mouvement valide au "Fou".
    /// </summary>
    class Bishop : Piece
    {
        /// <summary>
        /// Constructeur de base d'un "Fou", hérite de "Piece"
        /// </summary>
        /// <param name="p_alive">Sert à savoir si la pièce est en vie.</param>
        /// <param name="p_color">Sert à savoir la couleur de la pièce.</param>
        public Bishop(bool p_alive, char p_color) : base(p_alive, p_color)
        {
        }

        /// <summary>
        /// Indique la façon dont un "Fou" peut se déplacer.
        /// </summary>
        /// <param name="coordFrom">Coordonnée initiale de la pièce</param>
        /// <param name="coordTo">Coordonnée finale de la pièce</param>
        /// <param name="isEating">Sert à savoir si la pièce tente de manger en se déplacant.</param>
        /// <returns>"True" si la pièce peut bouger, "False" si elle ne peut pas.</returns>
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
