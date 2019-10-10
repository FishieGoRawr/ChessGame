using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    /// <summary>
    /// Classe parent de tout les types de pièces.
    /// </summary>
    public class Piece
    {
        /// <value name="m_color"> Couleur de la pièce. </value>
        public char m_color;
        /// <value name = "m_alive" > État de la pièce (Morte/vivante). </value>
        public bool m_alive; 

        /// <summary>
        /// Constructeur de base d'une pièce avec la couleur et son état.
        /// </summary>
        /// <param name="p_alive"></param>
        /// <param name="p_color"></param>
        public Piece(bool p_alive, char p_color)
        {
            this.m_alive = p_alive;
            this.m_color = p_color;
        }

        /// <summary>
        /// Cette méthode permet de sérialiser une pièce pour permettre la sérialisation du plateau.
        /// </summary>
        /// <returns>Pièce sous format String</returns>
        public override string ToString()
        {
            string serializedPiece = "";

            serializedPiece = this.m_color + "_" + this.GetType().Name;

            serializedPiece = serializedPiece.ToLower();

            return serializedPiece;
        }

        /// <summary>
        /// Overrided par tout les autres classes enfant. Permet de savoir si la pièce peut bouger vers une coordonnée donnée.
        /// </summary>
        /// <param name="coordFrom"></param>
        /// <param name="coordTo"></param>
        /// <param name="isEating"></param>
        /// <returns>Retourne toujours faux. Un problème est survenue si on obtient faux de pièce.</returns>
        public virtual bool canMove(int[] coordFrom, int[] coordTo, bool isEating = false)
        {
            return false;
        }
    }
}
