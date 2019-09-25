using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Game
    {
        Player m_pWhite, m_pBlack;      //Both players currently playing the game 
        char m_turn;                    //Represent who's player turn it is to play (true = white player | false = black player)
        Board m_board;
        gameGUI m_gameGUI;
        Move m_move;
        List<Piece> m_whiteEaten;
        List<Piece> m_blackEaten;

        public Game()
        {
            this.m_board = new Board(8);
            this.m_turn = 'W';

            //Creating UI and showing it 
            this.m_gameGUI = new gameGUI(this);
            this.m_gameGUI.Show();

            refreshBoard();
        }

        public void refreshBoard()
        {
            this.m_gameGUI.drawBoard(m_board.ToString());
        }


        public void highlightTile(int[] coordFrom)
        {
            //if (m_board[p_x,p_y].CurrentPiece != null)
            //{
            bool isValidTile = m_board.trySelectTile(coordFrom, m_turn);

            if (isValidTile)
            {
                refreshBoard();
                if (this.m_turn == 'W')
                {
                    this.m_move = new Move(this.m_pWhite, m_board.SelectedTile);
                }
                else
                {
                    this.m_move = new Move(this.m_pBlack, m_board.SelectedTile);
                }
            }
            //}
        }

        //public bool isSelectedPieceValid(int[] coordFrom)
        //{
        //    return this.m_board.isSameColorPiece(coordFrom, m_turn);
        //}
    }
}
