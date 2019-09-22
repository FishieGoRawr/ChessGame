using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Piece
    {
        private char m_color;

        public bool m_alive;
        public string m_imagePath;

        public Piece(bool p_alive, char p_color, string p_imagepath)
        {
            this.m_alive = p_alive;
            this.m_color = p_color;
            this.m_imagePath = p_imagepath;
        }
    }
}
