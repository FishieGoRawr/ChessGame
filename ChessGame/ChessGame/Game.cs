using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Game
    {
        Player m_pWhite, m_pBlack;
        bool m_turn;
        Board m_board;
        chessBoard m_gameGUI;
        List<Piece> m_whiteEaten;
        List<Piece> m_blackEaten;

        public Game()
        {
            m_gameGUI = new chessBoard(this);
            m_gameGUI.Show();
        }
    }
}
