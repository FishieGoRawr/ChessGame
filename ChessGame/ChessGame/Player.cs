using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Player
    {
        private string m_playerName;
        private bool m_isWhite;
        private int[] m_winLossCount;

        //CONSTRUCTEURS
        public Player(string name) //New player constructor
        {
            this.m_winLossCount = new int[2];
            this.m_playerName = name;
            this.m_isWhite = false;
        }

        public Player(string name, int winCount, int lossCount)
        {
            this.m_winLossCount = new int[2];
            this.m_playerName = name;
            this.m_winLossCount[0] = winCount;
            this.m_winLossCount[1] = lossCount;
        }

        //ACCESSEURS
        public string Name
        {
            get { return m_playerName; }
        }

        public int WinCount
        {
            get { return m_winLossCount[0]; }
            set { m_winLossCount[0] = value; }
        }

        public int LossCount
        {
            get { return m_winLossCount[1]; }
            set { m_winLossCount[1] = value; }
        }

    }
}
