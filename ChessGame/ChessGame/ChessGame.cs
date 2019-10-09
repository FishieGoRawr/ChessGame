using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ChessGame
{
    /// <summary>
    /// Controleur principal de notre programme d'échec. Sert principalement à "hoster" des parties et fournir les joueurs (et leurs statistiques) au programme.
    /// </summary>
    public class ChessGame
    {
        //DONNÉE MEMBRE
        /// <value>Stock une partie d'échec avec 2 joueurs. </value>
        private Game m_game;
        /// <value>Stock le menu principal de la partie. Permet de sélectionné 2 joueurs et d'ajouter/supprimer des joueurs. </value>
        private mainMenu m_menu;
        /// <value>Liste de tout les joueurs dans le programme, ainsi que leur statistiques. </value>
        private List<Player> m_listPlayer;

        //ACCESSEUR
        /// <summary>
        /// Accesseur de la liste de joueur. Retourne un objet de type "Player"
        /// </summary>
        public List<Player> PlayerList
        {
            get { return m_listPlayer; }
        }

        //CONSTRUCTEUR
        /// <summary>
        /// Constructeur de base du controlleur.
        /// </summary>
        public ChessGame()
        {
            m_listPlayer = new List<Player>();
            m_menu = new mainMenu(this);
            Application.Run(m_menu);
        }

        //MÉTHODES
        /// <summary>
        /// Crée un nouveau controlleur au début du programme.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ChessGame game = new ChessGame();
        }

        /// <summary>
        /// Permet de créer un nouveau joueur.
        /// </summary>
        /// <param name="playerName">Nom du joueur à ajouté.</param>
        public void createNewPlayer(string playerName)
        {
            m_listPlayer.Add(new Player(playerName));
        }

        /// <summary>
        /// Remplie la liste de joueur à partir du fichier sauvegardé sur disque
        /// </summary>
        public void createPlayerFromFile()
        {
            try
            {
                List<string> playerList = new List<string>();
                string line;
                StreamReader sr = new StreamReader("playerList.txt");

                while ((line = sr.ReadLine()) != null) //Parcours le fichier et sépare le tout par joueurs
                    playerList.Add(line);

                sr.Close();

                foreach (var player in playerList) //Parcours la liste de joueurs et split en nom/win/loss
                {
                    string[] playerInfo = player.Split(',');
                    string playerName = playerInfo[0];
                    int playerWin = Convert.ToInt32(playerInfo[1]);
                    int playerLoss = Convert.ToInt32(playerInfo[2]);

                    m_listPlayer.Add(new Player(playerName, playerWin, playerLoss));
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Permet de sérialisé la liste des joueurs pour l'écriture sur disque. Stock le nom, nombre de victoires et défaites pour chaque joueurs.
        /// </summary>
        /// <returns>Retourne un string contenant la liste de joueur sérialisée. </returns>
        public string serializePlayerList()
        {
            string serializedList = "";

            foreach (var player in m_listPlayer)
            {
                if (!(player == m_listPlayer.Last()))
                    serializedList += player.Name + "," + player.WinCount + "," + player.LossCount + "\n";
                else
                    serializedList += player.Name + "," + player.WinCount + "," + player.LossCount;
            }

            return serializedList;
        }

        /// <summary>
        /// Sauvegarde la liste de joueurs sérialisé sur disque.
        /// </summary>
        public void savePlayerList() //Sauvegarde la liste de joueurs sur disque
        {
            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "playerList.txt");
            sw.WriteLine(serializePlayerList());
            sw.Flush();
            sw.Close();
        }

        /// <summary>
        /// Crée une nouvelle partie avec 2 joueurs.
        /// </summary>
        /// <param name="playerList">Liste des joueurs pour permettre la sauvegarde plus tard. </param>
        /// <param name="p_player1">Nom du joueur #1. </param>
        /// <param name="p_player2">Nom du joueur #2. </param>
        public void createGame(List<Player> playerList, string p_player1, string p_player2)
        {
            //Creating a new chess game with the 2 selected players
            m_game = new Game(playerList, p_player1, p_player2);
        }
    }
}
