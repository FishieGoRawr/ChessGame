using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Board
    {
        private Tile[] m_tiles;
        private Tile m_selectedTile;
        private int m_width;
        public string m_background;

        //CONSTRUCTEUR
        public Board(int p_width)
        {
            this.Width = p_width;
            this.m_tiles = new Tile[64];
            this.m_background = "board";
            this.m_selectedTile = null;

            for (int i = 0; i < m_tiles.Length; i++)
            {
                m_tiles[i] = new Tile((i % m_width), (i / m_width));
            }

            //Disposing pieces
            disposePieces('W');
            disposePieces('B');
        }

        public Board(string serializedBoard)
        {
            //Reprendre une partie en cours avec un board serialisé
        }

        //ACCESSEUR

        public int Width { get => m_width; set => m_width = value; }
        public Tile SelectedTile { get => m_selectedTile; set => m_selectedTile = value; }

        public Tile this[int x, int y]
        {
            get { return m_tiles[x + Width * y]; }
        }

        //METHODES

        public void disposePieces(char p_piecesColor)
        {
            int startingY = 0;
            int endingY = 2;

            string ressourceFolderPath = @"..\..\Resources\Pieces\";

            if (p_piecesColor == 'W')
            {
                startingY = m_width - 2;
                endingY = m_width;
            }


            for (int y = startingY; y < endingY; y++)
            {
                for (int x = 0; x < m_width; x++)
                {
                    if (y == 0 || y == m_width - 1)
                    {
                        switch (x)
                        {
                            case 0:
                            case 7:
                                this[x, y].CurrentPiece = new Rook(true, p_piecesColor, true);
                                break;
                            case 1:
                            case 6:
                                this[x, y].CurrentPiece = new Knight(true, p_piecesColor);
                                break;
                            case 2:
                            case 5:
                                this[x, y].CurrentPiece = new Bishop(true, p_piecesColor);
                                break;
                            case 3:
                            case 4:
                                if (p_piecesColor == 'W')
                                {
                                    this[3, y].CurrentPiece = new Queen(true, p_piecesColor);
                                    this[4, y].CurrentPiece = new King(true, p_piecesColor, true);
                                }
                                else
                                {
                                    this[3, y].CurrentPiece = new King(true, p_piecesColor, true);
                                    this[4, y].CurrentPiece = new Queen(true, p_piecesColor);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        this[x, y].CurrentPiece = new Pawn(true, p_piecesColor, true);
                    }
                }
            }
        }

        public bool trySelectTile(int[] coord, char currentColor)
        {
            char pieceColor = this[coord[0], coord[1]].getPieceColor();

            if (pieceColor == currentColor)
            {
                this.m_selectedTile = this[coord[0], coord[1]];
                return true;
            }

            return false;
        }

        //public void selectTile(int[] coord)
        //{
        //    this.m_selectedTile = this[coord[0], coord[1]];
        //}

        public bool isDestinationValid(Tile tileFrom, Tile tileTo)
        {
            bool isValid = false;

            if (!tileTo.isOccupied())
            {
                isValid = true;
            }

            return isValid;
        }

        public bool isCollisionning(int[] coordFrom, int[] coordTo)
        {
            string pieceType = this[coordFrom[0], coordFrom[1]].CurrentPiece.GetType().Name;

            int Xmovement = coordFrom[0] - coordTo[0];
            int Ymovement = coordFrom[1] - coordTo[1];

            switch (pieceType)
            {
                case "Pawn":
                    //If the movement direction is up
                    if (Ymovement > 0)
                    {
                        return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { 0, -1 }, this[coordTo[0], coordTo[1]]);
                    }
                    //If the movement direction is down
                    else
                    {
                        return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { 0, 1 }, this[coordTo[0], coordTo[1]]);
                    }
                    break;
                case "Bishop":
                    //If the movement direction is up
                    if (Ymovement > 0)
                    {
                        //If the movement direction is left-up
                        if (Xmovement > 0)
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { -1, -1 }, this[coordTo[0], coordTo[1]]);
                        }
                        //If the movement direction is right-up
                        else
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { 1, -1 }, this[coordTo[0], coordTo[1]]);
                        }

                    }
                    //If the movement direction is down
                    else
                    {
                        //If the movement direction is left-down
                        if (Xmovement > 0)
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { -1, 1 }, this[coordTo[0], coordTo[1]]);
                        }
                        //If the movement direction is right-down
                        else
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { 1, 1 }, this[coordTo[0], coordTo[1]]);
                        }
                    }
                    break;
                case "Rook":
                    //If the movement direction is in Y
                    if (Xmovement == 0)
                    {
                        if (Ymovement > 0)
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[]{ 0, -1 }, this[coordTo[0], coordTo[1]]);
                        }
                        else
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { 0, 1 }, this[coordTo[0], coordTo[1]]);
                        }

                    }
                    else
                    {
                        //int offSet = 0;
                        ////If the movement direction is in Y
                        //if (Xmovement == 0)
                        //{
                        //    while (Math.Abs(offSet) != Math.Abs(Ymovement))
                        //    {
                        //        if (offSet != 0 && this[coordFrom[0], coordFrom[1] + offSet].isOccupied())
                        //        {
                        //            return true;
                        //        }
                        //        if (Ymovement > 0)
                        //        {
                        //            offSet--; //upward movement
                        //        }
                        //        else
                        //        {
                        //            offSet++; //downward movement
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    while (Math.Abs(offSet) != Math.Abs(Xmovement))
                        //    {
                        //        if (offSet != 0 && this[coordFrom[0] + offSet, coordFrom[1]].isOccupied())
                        //        {
                        //            return true;
                        //        }
                        //        if (Xmovement > 0)
                        //        {
                        //            offSet--; //left movement
                        //        }
                        //        else
                        //        {
                        //            offSet++; //right movement
                        //        }
                        //    }

                        //}
                        if (Xmovement > 0)
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { -1, 0 }, this[coordTo[0], coordTo[1]]);
                        }
                        else
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { 1, 0 }, this[coordTo[0], coordTo[1]]);
                        }
                    }


                    break;
                case "King":
                    if (this[coordFrom[0] + Xmovement, coordTo[1] + Ymovement].isOccupied())
                    {
                        return false;
                    }
                    break;
                case "Queen":
                    //If the movement direction is in Y
                    if (Xmovement == 0)
                    {
                        if (Ymovement > 0)
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { 0, -1 }, this[coordTo[0], coordTo[1]]);
                        }
                        else
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { 0, 1 }, this[coordTo[0], coordTo[1]]);
                        }

                    }
                    else if (Ymovement == 0)
                    {
                        if (Xmovement > 0)
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { -1, 0 }, this[coordTo[0], coordTo[1]]);
                        }
                        else
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { 1, 0 }, this[coordTo[0], coordTo[1]]);
                        }
                    }
                    //If the movement direction is up but diagonal
                    else if (Ymovement > 0 && Xmovement != 0)
                    {
                        //If the movement direction is left-up
                        if (Xmovement > 0)
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { -1, -1 }, this[coordTo[0], coordTo[1]]);
                        }
                        //If the movement direction is right-up
                        else
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { 1, -1 }, this[coordTo[0], coordTo[1]]);
                        }

                    }
                    //If the movement direction is down but diagonal
                    else if (Ymovement < 0 && Xmovement != 0)
                    {
                        //If the movement direction is left-down
                        if (Xmovement > 0)
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { -1, 1 }, this[coordTo[0], coordTo[1]]);
                        }
                        //If the movement direction is right-down
                        else
                        {
                            return detectCollision(this[coordFrom[0], coordFrom[1]], new int[] { 1, 1 }, this[coordTo[0], coordTo[1]]);
                        }
                    }

                    break;
                default:
                    break;
            }
            return false;
        }

        //recursive algorithm to detect collision
        public bool detectCollision(Tile p_currentTile,int[] direction, Tile p_endTile)
        {
            if ((p_currentTile.X + direction[0] > 0 && p_currentTile.X + direction[0] < m_width) && (p_currentTile.Y + direction[1] > 0 && p_currentTile.Y + direction[1] < m_width))
            {
                Tile nextTile = this[p_currentTile.X + direction[0], p_currentTile.Y + direction[1]];
                if (p_currentTile == p_endTile)
                {
                    return false;
                }
                else if (!nextTile.isOccupied())
                {
                    return detectCollision(nextTile, direction, p_endTile);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public void movePiece(int[] coordFrom, int[] coordTo)
        {
            if (this[coordFrom[0], coordFrom[1]].GetType().BaseType.Name == "firstMovePiece")
            {
                ((firstMovePiece)this[coordFrom[0], coordFrom[1]].CurrentPiece).m_firstMove = false;
            }
            this[coordTo[0], coordTo[1]].CurrentPiece = this[coordFrom[0], coordFrom[1]].CurrentPiece;
            this[coordFrom[0], coordFrom[1]].CurrentPiece = null;
            this.m_selectedTile = null;
        }

        //Are we trying to move
        public bool isMoving(int[] coordFrom, char p_turn)
        {
            if (this.m_selectedTile != null)
            {
                if (this.SelectedTile.getPieceColor() == this[coordFrom[0], coordFrom[1]].getPieceColor())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string serializedBoard = "";

            serializedBoard += m_background;

            if (this.m_selectedTile != null)
            {
                serializedBoard += "|" + this.m_selectedTile.ToString();
            }
            else
            {
                serializedBoard += "|00,none";
            }


            for (int i = 0; i < m_tiles.Length; i++)
            {
                serializedBoard += "|" + m_tiles[i].ToString();
            }

            return serializedBoard;
        }
    }
}
