using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Tile
    {
        //Donnees membres

        private int m_X;
        private int m_Y;
        private Piece m_currentPiece;

        //Accesseurs

        public int X { get => m_X; set => m_X = value; }

        public int Y { get => m_Y; set => m_Y = value; }

        public Piece CurrentPiece { get => m_currentPiece; set => m_currentPiece = value; }

        //Constructeurs

        public Tile(int p_X, int p_Y, Piece p_currentPiece = null)
        {
            this.X = p_X;
            this.Y = p_Y;
        }

        //Methodes
        public bool isOccupied()
        {
            return m_currentPiece != null;
        }

        public char getPieceColor()
        {
            if (this.m_currentPiece != null)
            {
                return m_currentPiece.m_color;
            }
            return 'N';
        }

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
