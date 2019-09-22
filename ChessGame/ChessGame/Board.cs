using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Board
    {
        private Tile[] m_tiles;
        private int m_width;

        //CONSTRUCTEUR
        public Board()
        {
            m_tiles = new Tile[64];

        }

        public Board(string serializedBoard)
        {
            //Reprendre une partie en cours avec un board serialisé
        }

        //ACCESSEUR
        public Tile this[int x, int y]
        {
            get { return m_tiles[x + m_width * y]; }
        }
    }
}
