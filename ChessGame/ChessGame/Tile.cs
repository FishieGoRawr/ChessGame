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
