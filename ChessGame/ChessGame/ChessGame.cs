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
        Game m_game;
        mainMenu m_menu;
        List<Player> m_listPlayer;

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

        public void createNewPlayer(string playerName)
        {
            m_listPlayer.Add(new Player(playerName));
        }

        public string serializePlayerList()
        {
            string serializedList = "";

            foreach (var player in m_listPlayer)
            {
                serializedList += player.Name + "," + player.WinCount + "," + player.LossCount + "|";
            }

            return serializedList;
        }

        public void savePlayerList()
        {
            StreamWriter sw = new StreamWriter(@"\playerList.txt");
            sw.Write(serializePlayerList());
        }

        public void createGame()
        {
            //Creating a new chess game with the 2 selected players
        }
    }
}
