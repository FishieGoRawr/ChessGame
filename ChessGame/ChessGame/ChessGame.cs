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

        //CONSTRUCTEUR
        public ChessGame()
        {
            m_menu = new mainMenu(this);
            m_listPlayer = new List<Player>();
            Application.Run(m_menu);
        }

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
            List<string> playerList = new List<string>();
            string line;
            StreamReader sr = new StreamReader("playerList.txt");

            while ((line = sr.ReadLine()) != null)
            {
                playerList.Add(line);
                
            }
            sr.Close();


            foreach (var player in playerList)
            {
                string[] playerInfo = player.Split(',');
                m_listPlayer.Add(new Player(playerInfo[0], int.Parse(playerInfo[1]), int.Parse(playerInfo[2])));
            }

            foreach (var player in m_listPlayer)
            {
                Console.WriteLine(player.Name);
                Console.WriteLine(player.WinCount);
                Console.WriteLine(player.LossCount);
                Console.WriteLine("\n");
            }
        }

        public string serializePlayerList() //Sérialize la liste de joueur pour facilité l'écriture sur disque
        {
            string serializedList = "";

            foreach (var player in m_listPlayer)
            {
                serializedList += player.Name + "," + player.WinCount + "," + player.LossCount + "\n";
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
        }
    }
}
