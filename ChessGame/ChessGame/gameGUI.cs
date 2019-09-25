using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ChessGame
{
    public partial class gameGUI : Form
    {
        Game m_game;
        string m_ressourceFolderPath;
        int m_selectedX;
        int m_selectedY;

        public gameGUI(Game p_game)
        {
            InitializeComponent();
            m_game = p_game;
            m_selectedX = -1;
            m_selectedY = -1;
            m_ressourceFolderPath = @"..\..\Resources\Pieces\";
        }

        private void board_MouseUP(object sender, MouseEventArgs e)
        {
            Panel boardPanel = (Panel)sender;
            int tileWidth = boardPanel.Width / 8;
            int tileHeight = boardPanel.Height / 8;

            int tileX = (e.X / tileWidth);
            int tileY = (e.Y / tileHeight);

            m_game.refreshBoard();
            m_game.highlightTile(tileX, tileY, tileWidth, tileHeight);
            Console.WriteLine(tileX + ", " + tileY);
        }


        public void drawPiece(int p_x, int p_y, char p_color, string p_name, Graphics g)
        {
            int tileWidth = board.Width / 8;
            int tileHeight = board.Height / 8;
            //Getting the image path corresponding to the piece
            string imagePath = m_ressourceFolderPath + p_name.ToLower() + ".png";


            Bitmap bitmap = new Bitmap(@imagePath);
            g.DrawImage(bitmap, p_x * tileWidth, p_y * tileHeight, tileWidth, tileHeight);
        }

        public void drawBoard(string p_serializedBoard)
        {

            string[] boardTiles = p_serializedBoard.Split('|');

            // This example assumes the existence of a form called Form1.
            BufferedGraphicsContext currentContext;
            BufferedGraphics myBuffer;
            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with Form1, and with 
            // dimensions the same size as the drawing surface of Form1.
            myBuffer = currentContext.Allocate(board.CreateGraphics(),
               board.DisplayRectangle);


            // Draws the board background to the graphics buffer.
            Bitmap backGround = new Bitmap(@"..\..\Resources\" + boardTiles[0] + ".png");

            myBuffer.Graphics.DrawImage(backGround, 0, 0, board.Width, board.Height);


            for (int i = 1; i < boardTiles.Length; i++)
            {
                string[] temp = boardTiles[i].Split(',');
                string name = temp[1];
                if (name != "null")
                {
                    int x = ((temp[0])[0]) - 48;
                    int y = ((temp[0])[1]) - 48;
                    char color = temp[1][0];
                    drawPiece(x, y, color, name, myBuffer.Graphics);
                }
            }
            myBuffer.Render();

            myBuffer.Dispose();
        }

        //Draws a blue rectangle outline at the specified coordinates
        public void drawRectangle(int p_x, int p_y, int p_width, int p_height)
        {
            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.CadetBlue);
            myPen.Width = 5;
            System.Drawing.Graphics boardGraphics;
            boardGraphics = this.board.CreateGraphics();
            boardGraphics.DrawRectangle(myPen, new Rectangle(p_x, p_y, p_width, p_height));
            myPen.Dispose();
            boardGraphics.Dispose();
        }

        private void Board_Paint(object sender, PaintEventArgs e)
        {
            m_game.refreshBoard();
        }
    }
}
