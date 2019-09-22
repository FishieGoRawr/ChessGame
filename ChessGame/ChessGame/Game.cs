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
            for (int y = 0; y < m_board.Width; y++)
            {
                for (int x = 0; x < m_board.Width; x++)
                {
                    if (m_board[x, y].CurrentPiece != null)
                    {
                        Piece pieceToAdd = m_board[x, y].CurrentPiece;
                        Type typeToAdd = pieceToAdd.GetType();
                        m_gameGUI.addPiece(x, y,  typeToAdd.Name, pieceToAdd.m_imagePath);
                    }
                }
            }
        }
    }
}
