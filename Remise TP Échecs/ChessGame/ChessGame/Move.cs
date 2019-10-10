using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    /// <summary>
    /// Classe permettant d'effectuer les déplacements/vérifications requises.
    /// </summary>
    class Move
    {
        /// <value name="m_start">Tuile de départ. </value>
        private Tile m_start;
        /// <value name="m_end">Tuile de fin. </value>
        private Tile m_end;
        /// <value name="m_movedPiece">Piece qu'on déplace. </value>
        private Piece m_movedPiece;
        /// <value name="m_killedPiece">Pièce qu'on mange. </value>
        private Piece m_killedPiece;


        /// <summary>
        /// Accesseur pour la piève qu'on bouge.
        /// </summary>
        public Piece MovedPiece { get => m_movedPiece; set => m_movedPiece = value; }
        /// <summary>
        /// Accesseur pour la piève qu'on mange.
        /// </summary>
        public Piece KilledPiece { get => m_killedPiece; set => m_killedPiece = value; }
        /// <summary>
        /// Accesseur pour la tuile de départ.
        /// </summary>
        internal Tile Start { get => m_start; set => m_start = value; }
        /// <summary>
        /// Accesseur pour la tuile de fin.
        /// </summary>
        internal Tile End { get => m_end; set => m_end = value; }

        /// <summary>
        /// Constructeur de base de la classe Move. Permet d'initier un mouvement.
        /// </summary>
        /// <param name="p_start">Tuile de départ du mouvement. </param>
        public Move(Tile p_start)
        {
            this.m_start = p_start;
            this.m_end = null;
            this.m_movedPiece = m_start.CurrentPiece;
            this.m_killedPiece = null;
        }

        //METHODES
        /// <summary>
        /// Sert à avoir les coordonnées du point de départ.
        /// </summary>
        /// <returns>Retourne les coord du poin de départ.</returns>
        public int[] getCoordFrom()
        {
            int[] coordFrom = { m_start.X, m_start.Y };
            return coordFrom;
        }

        /// <summary>
        /// Sert à avoir les coordonnées du point de fin.
        /// </summary>
        /// <returns>Retourne les coord du poin de fin.</returns>
        public int[] getCoordTo()
        {
            int[] coordTo = { m_end.X, m_end.Y };
            return coordTo;
        }

        /// <summary>
        /// Sert à savoir si le mouvement qu'on essais de faire est valide ou non.
        /// </summary>
        /// <returns>Vrai si valide, faux si invalide. s</returns>
        public bool isValidMovement()
        {
            bool validMovement = false;
            if (this.MovedPiece.GetType().Name != "Pawn")
            {
                validMovement = this.m_movedPiece.canMove(getCoordFrom(), getCoordTo());
            }
            else
            {
                //If we are eating another piece
                if (!this.m_end.isOccupied())
                {
                    validMovement = this.m_movedPiece.canMove(getCoordFrom(), getCoordTo(), false);
                }
                else
                {
                    validMovement = this.m_movedPiece.canMove(getCoordFrom(), getCoordTo(), true);
                }
            }
            return validMovement;
        }
    }
}
