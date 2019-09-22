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
        private int m_width;

        //CONSTRUCTEUR
        public Board(int p_width)
        {
            this.Width = p_width;
            this.m_tiles = new Tile[64];

            for (int i = 0; i < m_tiles.Length; i++)
            {
                m_tiles[i] = new Tile( (i % m_width), (i / m_width) );
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
                                this[x, y].CurrentPiece = new Rook(true, p_piecesColor, ressourceFolderPath + p_piecesColor + "_rook.png");
                                break;
                            case 1:
                            case 6:
                                this[x, y].CurrentPiece = new Knight(true, p_piecesColor, ressourceFolderPath + p_piecesColor +"_knight.png");
                                break;
                            case 2:
                            case 5:
                                this[x, y].CurrentPiece = new Bishop(true, p_piecesColor, ressourceFolderPath + p_piecesColor + "_bishop.png");
                                break;
                            case 3:
                            case 4:
                                if (p_piecesColor == 'W')
                                {
                                    this[3, y].CurrentPiece = new Queen(true, p_piecesColor, ressourceFolderPath + p_piecesColor + "_queen.png");
                                    this[4, y].CurrentPiece = new King(true, p_piecesColor, ressourceFolderPath + p_piecesColor + "_king.png");
                                }
                                else
                                {
                                    this[3, y].CurrentPiece = new King(true, p_piecesColor, ressourceFolderPath + p_piecesColor + "_king.png");
                                    this[4, y].CurrentPiece = new Queen(true, p_piecesColor, ressourceFolderPath + p_piecesColor + "_queen.png");
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        this[x, y].CurrentPiece = new Pawn(true, p_piecesColor, ressourceFolderPath + p_piecesColor + "_pawn.png");
                    }
                }
            }
        }
    }
}
