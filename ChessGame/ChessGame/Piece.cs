using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Piece
    {

        public char m_color;
        public bool m_alive;

        public Piece(bool p_alive, char p_color)
        {
            this.m_alive = p_alive;
            this.m_color = p_color;
        }

        public override string ToString()
        {
            string serializedPiece = "";

            serializedPiece = this.m_color + "_" + this.GetType().Name;

            serializedPiece = serializedPiece.ToLower();

            return serializedPiece;
        }
    }
}
