using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ChessGame
{
    public class ChessGame
    {
        //DONNÉE MEMBRE
        private Game m_game;
        private mainMenu m_menu;
        private List<Player> m_listPlayer;

        //ACCESSEUR
        public List<Player> PlayerList
        {
            get { return m_listPlayer; }
        }

        //CONSTRUCTEUR
        public ChessGame()
        {
            m_listPlayer = new List<Player>();
            m_menu = new mainMenu(this);
            Application.Run(m_menu);
        }

        //MÉTHODES
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ChessGame game = new ChessGame();
        }

        public void createNewPlayer(string playerName) //Crée un nouveau joueur
        {
            m_listPlayer.Add(new Player(playerName));
        }

        public void createPlayerFromFile() //Remplie la liste de joueur à partir du fichier sauvegardé sur disque
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

        public string serializePlayerList() //Sérialize la liste de joueur pour facilité l'écriture sur disque
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

        public void savePlayerList() //Sauvegarde la liste de joueurs sur disque
        {
            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "playerList.txt");
            sw.WriteLine(serializePlayerList());
            sw.Flush();
            sw.Close();
        }

        public void createGame()
        {
            //Creating a new chess game with the 2 selected players
            m_game = new Game();
        }
    }
}
