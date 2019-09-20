using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public class ChessGame
    {
        Game m_game;
        mainMenu m_menu;

        public ChessGame()
        {
            m_menu = new mainMenu(this);
            Application.Run(m_menu);
        }

        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ChessGame game = new ChessGame();
        }
    }
}
