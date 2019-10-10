using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    /// <summary>
    /// Classe qui sert à contenir le plateau de jeu.
    /// </summary>
    class Board
    {
        /// <value name="m_tiles">Tableau de tuiles. Contient toute les tuiles d'un jeu d'échec. </value>
        private Tile[] m_tiles;
        /// <value name="m_selectedTile">Tuile présentement sélectionnée par le joueur. </value>
        private Tile m_selectedTile;
        /// <value name="m_width">Largeur et hauteur du board en nombre de cases. </value>
        private int m_width;
        /// <value name="m_background">Nom du fichier sur disque pour le fond du jeu. </value>
        public string m_background;
        /// <value name="m_possibleTiles">Liste les tuiles possibles pour le déplacement sous forme de String. </value>
        public string m_possibleTiles;
        /// <value name="isCheckState">Vérifie si il y à un échec sur le plateau. </value>
        public bool isCheckState;

        //CONSTRUCTEUR
        /// <summary>
        /// Constructeur de base d'un (nouveau) plateau d'échec.
        /// </summary>
        /// <param name="p_width">Largeur et hauteur du plateau en tuiles. </param>
        public Board(int p_width)
        {
            this.Width = p_width;
            this.isCheckState = false;
            this.m_tiles = new Tile[64];
            this.m_background = "board";
            this.m_selectedTile = null;
            this.m_possibleTiles = "";

            for (int i = 0; i < m_tiles.Length; i++)
            {
                m_tiles[i] = new Tile((i % m_width), (i / m_width));
            }

            //Disposing pieces
            disposePieces('W');
            disposePieces('B');
        }

        //Reprendre une partie en cours avec un board serialisé
        /// <summary>
        /// Constructeur permettant de reprendre une partie à partir d'un board sérialisé.
        /// </summary>
        /// <param name="p_serializedBoard">Plateau sérialisé sous forme de String. </param>
        public Board(string p_serializedBoard)
        {
            string[] boardTiles = p_serializedBoard.Split('|');
            this.m_background = boardTiles[0];

            this.m_selectedTile = null;

            this.isCheckState = false;

            this.m_possibleTiles = "";

            this.m_tiles = new Tile[64];

            this.m_width = (int) Math.Sqrt(Convert.ToDouble(this.m_tiles.Length));
            for (int i = 0; i < m_tiles.Length; i++)
            {
                m_tiles[i] = new Tile((i % m_width), (i / m_width));
            }

            //Adding possible tiles
            int index = 2;
            bool endOfPossibleTiles = true;
            while (endOfPossibleTiles)
            {
                string[] temp = boardTiles[index].Split(',');
                string name = temp[1];
                if (name != "null")
                {
                    int x = ((temp[0])[0]) - 48;
                    int y = ((temp[0])[1]) - 48;
                    if (name.EndsWith("H"))
                    {
                        m_possibleTiles += "|" + this[x, y].ToString() + "H";
                    }
                    else if (name.EndsWith("E"))
                    {
                        m_possibleTiles += "|" + this[x, y].ToString() + "E";
                    }
                    else
                    {
                        endOfPossibleTiles = false;
                    }
                    index++;
                }
            }

            for (int i = index - 1; i < boardTiles.Length; i++)
            {
                string[] temp = boardTiles[i].Split(',');
                string name = temp[1];
                if (name != "null")
                {
                    int x = ((temp[0])[0]) - 48;
                    int y = ((temp[0])[1]) - 48;
                    char color = Char.ToUpper(temp[1][0]);
                    if (temp.Length == 3)
                    {
                        this[x, y].addPiece(name, color, temp[2]);
                    }
                    else
                    {
                        this[x, y].addPiece(name, color);
                    }
                }
            }


                //Getting the selected case
                string[] selTemp = boardTiles[1].Split(',');
            string selName = selTemp[1];
            if (selName != "none")
            {
                int x = ((selTemp[0])[0]) - 48;
                int y = ((selTemp[0])[1]) - 48;

                this.m_selectedTile = this[x, y];
            }
            else
            {
                this.m_selectedTile = null;
            }


        }

        //ACCESSEUR
        /// <summary>
        /// Retourne/attribue la valeur de la largeur/hauteur du plateau.
        /// </summary>
        public int Width { get => m_width; set => m_width = value; }

        /// <summary>
        /// Retourne/attribue la tuile sélectionnée.
        /// </summary>
        public Tile SelectedTile { get => m_selectedTile; set => m_selectedTile = value; }

        /// <summary>
        /// Indexeur permettant de retournée la tuile au coordonnée passée en paramètres.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>Retourne une des tuiles du plateau. </returns>
        public Tile this[int x, int y]
        {
            get { return m_tiles[x + Width * y]; }
        }

        //METHODES
        /// <summary>
        /// Place les pièces au positions initiales sur le tableau.
        /// </summary>
        /// <param name="p_piecesColor">Couleur de la pièce à placer. </param>
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
                                    this[4, y].CurrentPiece = new King(true, p_piecesColor, true);
                                    this[3, y].CurrentPiece = new Queen(true, p_piecesColor);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coord">Tente de sélectionner la tuile au coordonnées données. </param>
        /// <param name="currentColor">Couleur du joueur qui tente de sélectionner. </param>
        /// <returns></returns>
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

        /// <summary>
        /// Permet de savoir si la destionation (2e clic) est valide.
        /// </summary>
        /// <param name="tileFrom">La tuile d'ou la pièce part. </param>
        /// <param name="tileTo">La tuile vers ou la pièce s'en va. </param>
        /// <param name="p_turn">À qui est le tour. </param>
        /// <returns></returns>
        public bool isDestinationValid(Tile tileFrom, Tile tileTo, char p_turn)
        {
            bool isValid = false;
            char colorWeCanEat;
            if (p_turn == 'W')
            {
                colorWeCanEat = 'B';
            }
            else
            {
                colorWeCanEat = 'W';
            }

            if (!tileTo.isOccupied())
            {
                isValid = true;
            }
            else if (tileTo.isOccupied() && tileTo.getPieceColor() == colorWeCanEat)
            {
                isValid = true;
            }

            return isValid;
        }

        /// <summary>
        /// Fonction pour évaluer les tuiles possibles pour le déplacement (Jouer un tour)
        /// </summary>
        /// <param name="coordFrom"></param>
        /// <param name="coordTo"></param>
        public void markPossible(int[] coordFrom, int[] coordTo)
        {
            this.m_possibleTiles = "";
            string pieceType = this[coordFrom[0], coordFrom[1]].CurrentPiece.GetType().Name;

            int Xmovement = coordFrom[0] - coordTo[0];
            int Ymovement = coordFrom[1] - coordTo[1];
            Tile startTile = this[coordFrom[0], coordFrom[1]];
            Tile endTile = this[coordTo[0], coordTo[1]];

            detect(pieceType, Xmovement, Ymovement, startTile, endTile, true);
        }

        /// <summary>
        /// Détecte si la pièce qu'on tente de bougé à une collision avec une autre pièce.
        /// </summary>
        /// <param name="coordFrom">Coordonnée de départ. </param>
        /// <param name="coordTo">Coordonnée de fin. </param>
        /// <returns>Vrai si la pièce subit une collision, faux si le chemin est libre. </returns>
        public bool isCollisionning(int[] coordFrom, int[] coordTo)
        {
            string pieceType = this[coordFrom[0], coordFrom[1]].CurrentPiece.GetType().Name;

            int Xmovement = coordFrom[0] - coordTo[0];
            int Ymovement = coordFrom[1] - coordTo[1];
            Tile startTile = this[coordFrom[0], coordFrom[1]];
            Tile endTile = this[coordTo[0], coordTo[1]];

            return detect(pieceType, Xmovement, Ymovement, startTile, endTile);
        }

        /// <summary>
        /// Détecter les cases possible, soit pour les collisions, soit pour l'affichage des cases possible. Mix des deux méthodes plus haut.
        /// </summary>
        /// <param name="p_pieceName">Nom de la pièce.</param>
        /// <param name="Xmovement">Mouvement en X.</param>
        /// <param name="Ymovement">Mouvement en Y.</param>
        /// <param name="p_startTile">Tuile de départ de la pièce.</param>
        /// <param name="p_endTile">Tuile de fin de la pièce.</param>
        /// <param name="forPossibleTiles">Si vrai, fait juste détecter les cases possibles. </param>
        /// <returns>Vrai si la pièce entre en collision, faux si le chemin est libre. </returns>
        public bool detect(String p_pieceName, int Xmovement, int Ymovement, Tile p_startTile, Tile p_endTile, bool forPossibleTiles = false)
        {
            if (forPossibleTiles)
            {
                if (p_startTile.CurrentPiece.GetType().Name != "Knight")
                {
                    detectPossible(p_startTile, new int[] { -1, 0 }, p_startTile);   //Left
                    detectPossible(p_startTile, new int[] { 1, 0 }, p_startTile);    //Right
                    detectPossible(p_startTile, new int[] { 0, -1 }, p_startTile);   //Up
                    detectPossible(p_startTile, new int[] { 0, 1 }, p_startTile);    //Down
                    detectPossible(p_startTile, new int[] { -1, -1 }, p_startTile);  //Left - Up
                    detectPossible(p_startTile, new int[] { 1, -1 }, p_startTile);   //Right - Up
                    detectPossible(p_startTile, new int[] { -1, 1 }, p_startTile);   //Left - Down
                    detectPossible(p_startTile, new int[] { 1, 1 }, p_startTile);    //Right - Down
                }
                else
                {
                    detectPossible(p_startTile, new int[] { -1, -2 }, p_startTile);  //Up - Left
                    detectPossible(p_startTile, new int[] { 1, -2 }, p_startTile);   //Up - Right
                    detectPossible(p_startTile, new int[] { -1, 2 }, p_startTile);  //Down - Left
                    detectPossible(p_startTile, new int[] { 1, 2 }, p_startTile);    //Down - Right
                    detectPossible(p_startTile, new int[] { -2, -1 }, p_startTile);  //Left - Up
                    detectPossible(p_startTile, new int[] { 2, -1 }, p_startTile);   //Right - Up
                    detectPossible(p_startTile, new int[] { -2, 1 }, p_startTile);   //Left - Down
                    detectPossible(p_startTile, new int[] { 2, 1 }, p_startTile);    //Right - Down
                }

            }
            else
            {
                //If the movement direction is only in Y
                if (Xmovement == 0)
                {
                    //If the movement direction is up
                    if (Ymovement > 0)
                    {
                        return detectCollision(p_startTile, new int[] { 0, -1 }, p_endTile);
                    }
                    //If the movement direction is down
                    else
                    {
                        return detectCollision(p_startTile, new int[] { 0, 1 }, p_endTile);
                    }

                }
                //If the movement direction is only in X
                else if (Ymovement == 0)
                {
                    //If the movement direction is left
                    if (Xmovement > 0)
                    {
                        return detectCollision(p_startTile, new int[] { -1, 0 }, p_endTile);
                    }
                    else
                    //If the movement direction is right
                    {
                        return detectCollision(p_startTile, new int[] { 1, 0 }, p_endTile);
                    }
                }
                //If the movement direction is up but diagonal
                else if (Ymovement > 0 && Xmovement != 0)
                {
                    //If the movement direction is left-up
                    if (Xmovement > 0)
                    {
                        return detectCollision(p_startTile, new int[] { -1, -1 }, p_endTile);
                    }
                    //If the movement direction is right-up
                    else
                    {
                        return detectCollision(p_startTile, new int[] { 1, -1 }, p_endTile);
                    }

                }
                //If the movement direction is down but diagonal
                else if (Ymovement < 0 && Xmovement != 0)
                {
                    //If the movement direction is left-down
                    if (Xmovement > 0)
                    {
                        return detectCollision(p_startTile, new int[] { -1, 1 }, p_endTile);
                    }
                    //If the movement direction is right-down
                    else
                    {
                        return detectCollision(p_startTile, new int[] { 1, 1 }, p_endTile);
                    }
                }

            }
            return false;
        }

        /// <summary>
        /// Fonction récursive pour savoir si la tuile est une tuile possible.
        /// </summary>
        /// <param name="p_startTile">Tuile de départ. </param>
        /// <param name="direction">Direction du mouvement. </param>
        /// <param name="p_currentTile">Tuile ou on est rendu.</param>
        public void detectPossible(Tile p_startTile, int[] direction, Tile p_currentTile)
        {
            if ((p_currentTile.X + direction[0] >= 0 && p_currentTile.X + direction[0] < m_width) && (p_currentTile.Y + direction[1] >= 0 && p_currentTile.Y + direction[1] < m_width))
            {
                Tile nextTile = this[p_currentTile.X + direction[0], p_currentTile.Y + direction[1]];

                int[] coordFrom = { p_startTile.X, p_startTile.Y };
                int[] coordTo = { nextTile.X, nextTile.Y };
                if (p_startTile.CurrentPiece.canMove(coordFrom, coordTo) && !nextTile.isOccupied())
                {
                    m_possibleTiles += "|" + nextTile.ToString() + "H";
                    detectPossible(p_startTile, direction, nextTile);
                }
                else if (p_startTile.CurrentPiece.canMove(coordFrom, coordTo, true) && nextTile.isOccupied() && nextTile.getPieceColor() != p_startTile.getPieceColor())
                {
                    //If the next case is an eatable piece
                    m_possibleTiles += "|" + nextTile.ToString() + "E";
                }

            }
        }

        /// <summary>
        /// Retourne les coordonnées du roi de la couleur passée en paramètres.
        /// </summary>
        /// <param name="p_color">Couleur qui sert à déterminer quel roi on cherche. </param>
        /// <returns>Tableau de "int" avec les positions X, Y du roi cherché.</returns>
        public int[] getKingCoord(char p_color)
        {
            string serializedBoard = this.ToString();

            string[] boardTiles = serializedBoard.Split('|');

            int[] kingCoord = new int[2];
            for (int i = 2; i < boardTiles.Length; i++)
            {
                string[] temp = boardTiles[i].Split(',');
                string name = temp[1];
                if (name != "null" && name.EndsWith("king"))
                {
                    char color = temp[1][0];
                    if (Char.ToUpper(color) == p_color)
                    {
                        kingCoord[0] = ((temp[0])[0]) - 48;
                        kingCoord[1] = ((temp[0])[1]) - 48;
                    }
                }
            }
            return kingCoord;
        }

        /// <summary>
        /// Sert à détecter les échecs des deux cotés, selon le tour passé en parametres.
        /// </summary>
        /// <param name="p_turn">À qui est le tour</param>
        /// <returns>Vrai si le roi adverse est en échec, faux s'il est OK. </returns>
        public bool detectCheck(char p_turn)
        {
            string serializedBoard = this.ToString();

            string[] boardTiles = serializedBoard.Split('|');

            int kingX = 0;
            int kingY = 0;
            for (int i = 2; i < boardTiles.Length; i++)
            {
                string[] temp = boardTiles[i].Split(',');
                string name = temp[1];
                if (name != "null" && name.EndsWith("king"))
                {
                    char color = temp[1][0];
                    if (Char.ToUpper(color) == p_turn)
                    {
                        kingX = ((temp[0])[0]) - 48;
                        kingY = ((temp[0])[1]) - 48;
                    }
                }
            }

            for (int i = 2; i < boardTiles.Length; i++)
            {
                string[] temp = boardTiles[i].Split(',');
                string name = temp[1];
                if (name != "null")
                {
                    int x = ((temp[0])[0]) - 48;
                    int y = ((temp[0])[1]) - 48;
                    char color = temp[1][0];
                    if (!name.EndsWith("H") && !name.EndsWith("E") && Char.ToUpper(color) != p_turn)
                    {
                        //If the currentPiece can eat the ennemy's King
                        if (this[x, y].CurrentPiece.canMove(new int[] { x, y }, new int[] { kingX, kingY }, true))
                        {
                            if (this[x, y].getPieceColor() != p_turn && !isCollisionning(new int[] { x, y }, new int[] { kingX, kingY }))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Fonction récursive pour savoir si la tuile est une tuile possible.
        /// </summary>
        /// <param name="p_currentTile">Tuile de départ.</param>
        /// <param name="direction">Direction du mouvement.</param>
        /// <param name="p_endTile">Tuile de fin. </param>
        /// <returns></returns>
        public bool detectCollision(Tile p_currentTile, int[] direction, Tile p_endTile)
        {
            if ((p_currentTile.X + direction[0] >= 0 && p_currentTile.X + direction[0] < m_width) && (p_currentTile.Y + direction[1] >= 0 && p_currentTile.Y + direction[1] < m_width))
            {
                Tile nextTile = this[p_currentTile.X + direction[0], p_currentTile.Y + direction[1]];
                if (p_currentTile == p_endTile)
                {
                    return false;
                }
                else if (nextTile.isOccupied() && nextTile == p_endTile)
                {
                    return false;
                }
                else if (!nextTile.isOccupied())
                {
                    return detectCollision(nextTile, direction, p_endTile);
                }
                else if (nextTile.isOccupied())
                {
                    return true;
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

        /// <summary>
        /// Permet de finalement déplacer la pièce sur le plateau.
        /// </summary>
        /// <param name="coordFrom">Position de départ de la pièce. </param>
        /// <param name="coordTo">Position de fin de la pièce. </param>
        public void movePiece(int[] coordFrom, int[] coordTo)
        {
            if (this[coordFrom[0], coordFrom[1]].CurrentPiece.GetType().BaseType.Name == "firstMovePiece")
            {
                ((firstMovePiece)this[coordFrom[0], coordFrom[1]].CurrentPiece).m_firstMove = false;
            }

            this[coordTo[0], coordTo[1]].CurrentPiece = this[coordFrom[0], coordFrom[1]].CurrentPiece;
            this[coordFrom[0], coordFrom[1]].CurrentPiece = null;
            this.m_selectedTile = null;
        }

        /// <summary>
        /// Demande au board si le joueur tente de faire un mouvement ou s'il tente de trouver les tuiles possibles.
        /// </summary>
        /// <param name="coordFrom">Coordonnées de départ du mouvement. </param>
        /// <param name="p_turn">À qui est le tour. </param>
        /// <returns></returns>
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

        /// <summary>
        /// Sérialise le plateau pour la sauvegarde ou autre.
        /// </summary>
        /// <returns>String contenant le plateau sérialisé. </returns>
        public override string ToString()
        {
            string serializedBoard = "";

            serializedBoard += m_background;

            if (this.m_selectedTile != null)
            {
                serializedBoard += "|" + this.m_selectedTile.ToString();
                if (this.m_possibleTiles != "")
                {
                    serializedBoard += this.m_possibleTiles;
                }
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
