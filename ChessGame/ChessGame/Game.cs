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

        public Game(List<Player> playerList, string p1Name, string p2Name)
        {
            this.m_board = new Board(8);
            this.m_turn = 'W';

            //Creating UI and showing it 
            this.m_gameGUI = new gameGUI(this);
            this.m_gameGUI.Show();

            //Getting player object from name
            for (int i = 0; i < playerList.Count; i++)
            {
                if (p1Name == playerList[i].Name)
                    m_pWhite = playerList[i];

                if (p2Name == playerList[i].Name)
                    m_pBlack = playerList[i];
            }

            Console.WriteLine("\n" + m_pWhite.Name);
            Console.WriteLine(m_pBlack.Name);
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
                            if (!this.m_board.isCheckState)
                            {
                                move(m_move.getCoordFrom(), m_move.getCoordTo());
                                switchTurns();
                                if (m_board.detectCheck(m_turn))
                                {
                                    Console.WriteLine(m_turn + "check Detected !");
                                    if (askBoardCheckMat())
                                    {
                                        Console.WriteLine(m_turn + "checkMat Detected !");
                                    }
                                }
                            }
                            else
                            {
                                if (askBoardCheckPat())
                                {
                                    Console.WriteLine(m_turn + "checkPat Detected !");
                                }
                            }


                            this.m_board.isCheckState = m_board.detectCheck(this.m_turn);
                            //}
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

        public bool askBoardCheck()
        {
            //trying move on temp board
            Board tempBoard = new Board(m_board.ToString());
            tempBoard.movePiece(m_move.getCoordFrom(), m_move.getCoordTo());
            if (m_turn == 'W')
            {
                return tempBoard.detectCheck(m_turn);
            }
            else
            {
                return tempBoard.detectCheck(m_turn);
            }
            //Does the move puts us in check position on the temp board

        }

        public bool askBoardCheckPat()
        {
            //trying move on temp board
            Board tempBoard = new Board(m_board.ToString());
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x != 0 || y != 0)
                    {
                        int[] direction = new int[] { x, y };
                        int[] start = m_board.getKingCoord(m_turn);
                        int[] end = new int[] { start[0], start[1] };
                        if ((end[0] + direction[0] > 0 && end[0] + direction[0] < 8) && (end[1] + direction[1] > 0 && end[1] + direction[1] < 8))
                        {
                            end[0] += direction[0];
                            end[1] += direction[1];
                            if (!m_board[end[0], end[1]].isOccupied())
                            {
                                tempBoard.movePiece(start, end);

                                //Does the move puts us in check position on the temp board
                                if (!tempBoard.detectCheck(m_turn))
                                {
                                    return false;
                                }
                                tempBoard.movePiece(end, start);
                            }
                        }

                    }
                }
            }


            return true;
        }

        public bool askBoardCheckMat()
        {
            //trying move on temp board
            Board tempBoard = new Board(m_board.ToString());
            for (int tileX = 0; tileX < tempBoard.Width; tileX++)
            {
                for (int tileY = 0; tileY < tempBoard.Width; tileY++)
                {
                    if (tempBoard[tileX, tileY].isOccupied() && tempBoard[tileX, tileY].getPieceColor() == m_turn)
                    {
                        for (int x = -1; x <= 1; x++)
                        {
                            for (int y = -1; y <= 1; y++)
                            {
                                if (x != 0 || y != 0)
                                {

                                    int[] direction = new int[] { x, y };
                                    int[] start = new int[] { tempBoard[tileX, tileY].X, tempBoard[tileX, tileY].Y };
                                    int[] end = new int[] { start[0], start[1] };
                                    Move tempMove = new Move(null, tempBoard[start[0], start[1]]);

                                    bool isOutOfIndex = true;
                                    bool isPossible = false;
                                    do
                                    {
                                        isOutOfIndex = !((end[0] + direction[0] > 0 && end[0] + direction[0] < 8) && (end[1] + direction[1] > 0 && end[1] + direction[1] < 8));
                                        if (!isOutOfIndex)
                                        {
                                            end[0] += direction[0];
                                            end[1] += direction[1];
                                            tempMove.End = tempBoard[end[0], end[1]];
                                            isPossible = (tempMove.isValidMovement() && !tempBoard.isCollisionning(tempMove.getCoordFrom(), tempMove.getCoordTo()) && tempBoard[tempMove.getCoordTo()[0], tempMove.getCoordTo()[1]].getPieceColor() != m_turn);
                                            if (isPossible)
                                            {
                                                tempBoard.movePiece(start, end);

                                                //Does the move puts us in check position on the temp board
                                                if (!tempBoard.detectCheck(m_turn))
                                                {
                                                    return false;
                                                }
                                                tempBoard.movePiece(end, start);
                                            }
                                        }
                                    } while (!isOutOfIndex && isPossible);

                                }
                            }
                        }
                    }
                }
            }
            return true;
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
