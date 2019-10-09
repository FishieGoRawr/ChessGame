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

        public gameGUI(Game p_game, Player m_pWhite, Player m_pBlack)
        {
            InitializeComponent();
            m_game = p_game;
            m_selectedX = -1;
            m_selectedY = -1;
            m_ressourceFolderPath = @"..\..\Resources\Pieces\";

            //Setting labels
            lblP1Name.Text = m_pWhite.Name;
            lblP1Win.Text = m_pWhite.WinCount.ToString();
            lblP1Lost.Text = m_pWhite.LossCount.ToString();
            lblP1Elo.Text = "N/A";

            lblP2Name.Text = m_pBlack.Name;
            lblP2Win.Text = m_pBlack.WinCount.ToString();
            lblP2Lost.Text = m_pBlack.LossCount.ToString();
            lblP2Elo.Text = "N/A";
        }

        private void board_MouseUP(object sender, MouseEventArgs e)
        {
            Panel boardPanel = (Panel)sender;
            if (e.X < 504 && e.Y < 504)
            {
                int tileWidth = boardPanel.Width / 8;
                int tileHeight = boardPanel.Height / 8;
                int[] clickedCoord = { (e.X / tileWidth), (e.Y / tileHeight) };

                m_game.highlightTile(clickedCoord);
            }
        }

        public void writeEvent(String p_message)
        {
            lsbGameEvents.Items.Add(p_message);
        }

        public void drawPiece(int p_x, int p_y, char p_color, string p_name, Graphics g)
        {
            int tileWidth = board.Width / 8;
            int tileHeight = board.Height / 8;
            //Getting the image path corresponding to the piece
            string imagePath = m_ressourceFolderPath + p_name.ToLower() + ".png";


            Bitmap bitmap = new Bitmap(@imagePath);
            g.DrawImage(bitmap, p_x * tileWidth, p_y * tileHeight, tileWidth, tileHeight);
            bitmap.Dispose();
        }

        public void highLightCase(int p_x, int p_y, Graphics g, char p_color)
        {
            int tileWidth = board.Width / 8;
            int tileHeight = board.Height / 8;
            SolidBrush semiTransBrush;
            switch (p_color)
            {
                case 'G':
                    semiTransBrush = new SolidBrush(Color.FromArgb(128, 0, 255, 0));
                    break;
                case 'R':
                    semiTransBrush = new SolidBrush(Color.FromArgb(128, 255, 0, 0));
                    break;
                default:
                    semiTransBrush = new SolidBrush(Color.FromArgb(128, 0, 255, 0));
                    break;
            }
            //g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.GammaCorrected;
            g.FillRectangle(semiTransBrush, p_x * tileWidth, p_y * tileHeight, tileWidth, tileHeight);
            semiTransBrush.Dispose();
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

            backGround.Dispose();
            //Highlighting the tile that is currently selected
            string[] selTemp = boardTiles[1].Split(',');
            string selName = selTemp[1];
            if (selName != "none")
            {
                int x = ((selTemp[0])[0]) - 48;
                int y = ((selTemp[0])[1]) - 48;
                drawRectangle(x, y, myBuffer.Graphics);
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
                    if (name.EndsWith("H"))
                    {
                        highLightCase(x, y, myBuffer.Graphics, 'G');
                    }
                    else if (name.EndsWith("E"))
                    {
                        highLightCase(x, y, myBuffer.Graphics, 'R');
                    }
                    else
                    {
                        drawPiece(x, y, color, name, myBuffer.Graphics);
                    }
                }
            }
            myBuffer.Render();

            myBuffer.Dispose();
        }

        //Draws a blue rectangle outline at the specified coordinates
        public void drawRectangle(int p_x, int p_y, Graphics g)
        {
            int tileWidth = board.Width / 8;
            int tileHeight = board.Height / 8;
            System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.CadetBlue);
            myPen.Width = 5;
            g.DrawRectangle(myPen, new Rectangle(p_x * tileWidth, p_y * tileHeight, tileWidth, tileHeight));
            myPen.Dispose();
            //g.Dispose();
        }

        private void Board_Paint(object sender, PaintEventArgs e)
        {
            m_game.refreshBoard();
        }
    }
}
