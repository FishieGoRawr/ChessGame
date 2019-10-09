using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    /// <summary>
    /// Classe permettant de créer un Joueur
    /// </summary>
    public class Player
    {
        /// <value name="">Stock le nom du joueur. </value>
        private string m_playerName;
        /// <value name="">Si le joueur est blanc, vrai. </value>
        private bool m_isWhite;
        /// <value name="">Stock les victoires/défaites du joueur </value>
        private int[] m_winLossCount;

        //CONSTRUCTEURS
        /// <summary>
        /// Constructeur par défaut d'un joueur.
        /// </summary>
        /// <param name="name">Nom du joueur. </param>
        public Player(string name) //New player constructor
        {
            this.m_winLossCount = new int[2];
            this.m_playerName = name;
            this.m_isWhite = false;
        }

        /// <summary>
        /// Constructeur d'un joueur déjà existant.
        /// </summary>
        /// <param name="name">Nom du joueur.</param>
        /// <param name="winCount">Nombre de victoires du joueur. </param>
        /// <param name="lossCount">Nombre de défaites du joueur. </param>
        public Player(string name, int winCount, int lossCount)
        {
            this.m_winLossCount = new int[2];
            this.m_playerName = name;
            this.m_winLossCount[0] = winCount;
            this.m_winLossCount[1] = lossCount;
        }

        /// <summary>
        /// Accesseur pour le nom du joueur.
        /// </summary>
        public string Name
        {
            get { return m_playerName; }
        }

        /// <summary>
        /// Accesseur pour le nombre de victoires du joueur.
        /// </summary>
        public int WinCount
        {
            get { return m_winLossCount[0]; }
            set { m_winLossCount[0] = value; }
        }

        /// <summary>
        /// Accesseur pour le nombre de défaites du joueur.
        /// </summary>
        public int LossCount
        {
            get { return m_winLossCount[1]; }
            set { m_winLossCount[1] = value; }
        }

    }
}
