using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    static class ChessGame
    {
        [STAThread]
        static void Main()
        {
            Game m_game;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainMenu());
        }
    }
}
