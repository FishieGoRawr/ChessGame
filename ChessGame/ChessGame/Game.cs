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
            bool isMove = m_board.isMoving(coordFrom, m_turn);

            //If the player is trying to select a piece
            if (!isMove)
            {
                bool isValidTile = m_board.trySelectTile(coordFrom, m_turn);
                if (isValidTile)
                {
                    m_board.markPossible(coordFrom, coordFrom);
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
            }
            //If the player is trying to move
            else
            {
                m_move.End = m_board[coordFrom[0], coordFrom[1]];
                bool destValid = this.m_board.isDestinationValid(m_move.Start, m_move.End, this.m_turn);
                if (destValid)
                {
                    bool validMovement = this.m_move.isValidMovement();
                    if (validMovement)
                    {
                        bool isCollisionning = this.m_board.isCollisionning(m_move.getCoordFrom(), m_move.getCoordTo());
                        if (!isCollisionning)
                        {
                            //If the board is in a check state
                            if (m_board.isCheckState)
                            {
                                //trying move on temp board
                                Board tempBoard = new Board(m_board.ToString());
                                tempBoard.movePiece(m_move.getCoordFrom(), m_move.getCoordTo());
                                //Does the move puts us in check position on the temp board
                                if (!tempBoard.detectCheck(m_turn))
                                {
                                    this.m_board.isCheckState = false;
                                    move(m_move.getCoordFrom(), m_move.getCoordTo());
                                    switchTurns();
                                }

                            }
                            else
                            {
                                move(m_move.getCoordFrom(), m_move.getCoordTo());
                                switchTurns();
                                this.m_board.isCheckState = m_board.detectCheck(this.m_turn);
                            }
                            refreshBoard();
                        }
                        else
                        {
                        }
                    }
                }

            }


            //}
        }


        public void move(int[] coordFrom, int[] coordTo)
        {
            m_board.movePiece(coordFrom, coordTo);
        }

        public void revertMove()
        {
            m_board.movePiece(m_move.getCoordTo(), m_move.getCoordFrom());
        }
        //public bool isSelectedPieceValid(int[] coordFrom)
        //{
        //    return this.m_board.isSameColorPiece(coordFrom, m_turn);
        //}

        public void switchTurns()
        {
            if (this.m_turn == 'W')
            {
                this.m_turn = 'B';
            }
            else
            {
                this.m_turn = 'W';
            }
        }
    }
}
