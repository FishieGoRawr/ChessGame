using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    /// <summary>
    /// Permet de créer des tuiles.
    /// </summary>
    class Tile
    {
        /// <value>Valeur en X de la tuile. </value>
        private int m_X;
        /// <value>Valeur en Y de la tuile. </value>
        private int m_Y;
        /// <value>Piece sur la tuile. </value>
        private Piece m_currentPiece;

        /// <summary>
        /// Retourne la valeur de X de la tuile.
        /// </summary>
        public int X { get => m_X; set => m_X = value; }
        /// <summary>
        /// Retourne la valeur de Y de la tuile.
        /// </summary>
        public int Y { get => m_Y; set => m_Y = value; }
        /// <summary>
        /// Retourne la pièce qui se trouve sur la tuile.
        /// </summary>
        public Piece CurrentPiece { get => m_currentPiece; set => m_currentPiece = value; }

        //Constructeurs
        /// <summary>
        /// Constrcuteur de base d'une tuile.
        /// </summary>
        /// <param name="p_X">Valeur en X de la tuile.</param>
        /// <param name="p_Y">Valeur en Y de la tuile.</param>
        /// <param name="p_currentPiece">Pièce sur la tuile, toujours null par défaut.</param>
        public Tile(int p_X, int p_Y, Piece p_currentPiece = null)
        {
            this.X = p_X;
            this.Y = p_Y;
        }

        //Methodes
        /// <summary>
        /// Permet de savoir si la case est occupée par une pièce.
        /// </summary>
        /// <returns>Vrai si pièce présentement dans la tuile, sinon, faux.</returns>
        public bool isOccupied()
        {
            return m_currentPiece != null;
        }

        /// <summary>
        /// Permet de savoir la couleur de la pièce sur la tuile.
        /// </summary>
        /// <returns>Retourne 'W' si blanche, 'B' si noire.</returns>
        public char getPieceColor()
        {
            if (this.m_currentPiece != null)
            {
                return m_currentPiece.m_color;
            }
            return 'N';
        }

        /// <summary>
        /// Permet d'ajouter une pièce sur le plateau.
        /// </summary>
        /// <param name="p_name">Nom de la pièce.</param>
        /// <param name="p_color">Couleur de la pièce.</param>
        /// <param name="p_isFirstMove">Si la pièce à déjà bougée.</param>
        public void addPiece(string p_name, char p_color, string p_isFirstMove = "")
        {
            bool firstMove; 
            Boolean.TryParse(p_isFirstMove, out firstMove);
            p_name = Char.ToUpper(p_name[2])+ p_name.Substring(3);
            switch (p_name)
            {
                case "Bishop":
                    this.m_currentPiece = new Bishop(true, p_color);
                    break;
                case "King":
                    this.m_currentPiece = new King(true, p_color, firstMove);
                    break;
                case "Knight":
                    this.m_currentPiece = new Knight(true, p_color);
                    break;
                case "Pawn":
                    this.m_currentPiece = new Pawn(true, p_color, firstMove);
                    break;
                case "Queen":
                    this.m_currentPiece = new Queen(true, p_color);
                    break;
                case "Rook":
                    this.m_currentPiece = new Rook(true, p_color, firstMove);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Permet de sérialisé une tuile.
        /// </summary>
        /// <returns>String contenant la tuile sérialisée.</returns>
        public override string ToString()
        {
            string serializedTile = "";

            if (this.m_currentPiece != null)
            {
                serializedTile = this.m_X.ToString() + this.m_Y.ToString() + "," + this.m_currentPiece.ToString();
            }
            else
            {
                serializedTile = this.m_X.ToString() + this.m_Y.ToString() + "," + "null";
            }

            return serializedTile;
        }

    }
}
