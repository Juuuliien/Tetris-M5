using TetrisDomain;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris_M5
{
    public partial class Presentation : Form
    {
        private Game tetrisGame;
        private const int cellSize = 40;

        public Presentation()
        {
            InitializeComponent();

            
            this.DoubleBuffered = true;

            
            this.KeyPreview = true;

           
            tetrisGame = new Game();



            
            GameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (!tetrisGame.isGameOver)
            {
                
                tetrisGame.UpdateGame("down");

                
                this.Invalidate();

                
            }
            else
            {
                GameTimer.Stop();
                MessageBox.Show("GAME OVER ! Ton score : " + tetrisGame.PlayerScore.CurrentScore);
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (tetrisGame.isGameOver) return;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    tetrisGame.UpdateGame("left");
                    break;
                case Keys.Right:
                    tetrisGame.UpdateGame("right");
                    break;
                case Keys.Up:
                    tetrisGame.UpdateGame("rotation");
                    break;
                case Keys.Down:
                    tetrisGame.UpdateGame("down");
                    break;
            }

            
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            
            for (int y = 0; y < tetrisGame.height; y++)
            {
                for (int x = 0; x < tetrisGame.width; x++)
                {
                    // Si la case n'est pas blanche (donc occupée)
                    if (tetrisGame.myGameBoard.board[y, x] != Color.White)
                    {
                        Brush brush = new SolidBrush(tetrisGame.myGameBoard.board[y, x]);
                        // Dessine le carré
                        g.FillRectangle(brush, x * cellSize, y * cellSize, cellSize, cellSize);
                        // Dessine une petite bordure noire autour du carré pour faire joli
                        g.DrawRectangle(Pens.Black, x * cellSize, y * cellSize, cellSize, cellSize);
                    }
                }
            }

            
            if (tetrisGame.movingPiece != null && !tetrisGame.isPieceLocked)
            {
                Brush movingBrush = new SolidBrush(tetrisGame.movingPiece.pieceColor);
                foreach (Point p in tetrisGame.movingPiece.squaresOfThePiece)
                {
                    g.FillRectangle(movingBrush, p.X * cellSize, p.Y * cellSize, cellSize, cellSize);
                    g.DrawRectangle(Pens.Black, p.X * cellSize, p.Y * cellSize, cellSize, cellSize);
                }
            }
        }
    }
}
