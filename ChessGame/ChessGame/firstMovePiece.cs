using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class firstMovePiece : Piece
    {
        public bool m_firstMove;

        public firstMovePiece(bool p_alive, char p_color, bool p_firstMove = false) : base(p_alive, p_color)
        {
            this.m_firstMove = p_firstMove;
        }

        public override string ToString()
        {
            string serializedPiece = "";

            serializedPiece = this.m_color + "_" + this.GetType().Name + "," + this.m_firstMove.ToString();

            serializedPiece = serializedPiece.ToLower();

            return serializedPiece;
        }
    }
}
