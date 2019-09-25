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
        gameGUI m_gameGUI;
        List<Piece> m_whiteEaten;
        List<Piece> m_blackEaten;

        public Game()
        {
            m_board = new Board(8);

            //Creating UI and showing it 
            m_gameGUI = new gameGUI(this);
            m_gameGUI.Show();

            refreshBoard();
        }

        public void refreshBoard()
        {
            m_gameGUI.drawBoard(m_board.ToString());
        }


        public void highlightTile(int p_x, int p_y, int p_width, int p_height)
        {
            m_gameGUI.drawRectangle(p_x * p_width, p_y * p_height, p_width, p_height);
        }
    }
}
