using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    /// <summary>
    /// Classe qui hérite de "Piece". Permet de voir si les pieces qui sont limitée au premier mouvement ont effectué ce premier mouvement.
    /// </summary>
    class firstMovePiece : Piece
    {
        /// <value name="m_firstMove">Sert à savoir si la pièce c'est deja déplacée. </value>
        public bool m_firstMove;

        /// <summary>
        /// Constructeur de base. Initie le firstMove de la pièce.
        /// </summary>
        /// <param name="p_alive">Sert à savoir si la pièce est en vie. </param>
        /// <param name="p_color">Sert à savoir la couleur de la pièce. </param>
        /// <param name="p_firstMove">Sert à savoir quand le premier mouvement à été fait. </param>
        public firstMovePiece(bool p_alive, char p_color, bool p_firstMove = false) : base(p_alive, p_color)
        {
            this.m_firstMove = p_firstMove;
        }

        /// <summary>
        /// Override de ToString pour sérialisée la pièce.
        /// </summary>
        /// <returns>String sérialisée de la pièce. </returns>
        public override string ToString()
        {
            string serializedPiece = "";

            serializedPiece = this.m_color + "_" + this.GetType().Name + "," + this.m_firstMove.ToString();

            serializedPiece = serializedPiece.ToLower();

            return serializedPiece;
        }
    }
}
