using TetrisDomain;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris_M5
{
    public partial class Presentation : Form
    {
        private Game tetrisGame;
        private const int cellSize = 30; // Set cell size for drawing the grid and pieces 

        // State variables to manage game flow and UI
        private bool isGameStarted = false;
        private bool isPaused = false;
        private bool isDarkMode = true;

        /// <summary>
        /// Initializes the Presentation form, configures double buffering, and sets up the initial UI state.
        /// </summary>
        public Presentation()
        {
            InitializeComponent();

            // Prevent UI flickering by enabling double buffering on the form
            this.DoubleBuffered = true;
            this.KeyPreview = true;

            // Initialisation of the game logic
            tetrisGame = new Game();  
            ApplyTheme();
            UpdateScoreDisplay();
        }

        /// <summary>
        /// Applies the selected UI theme (Dark or Light) by updating the background, foreground, and control colors.
        /// </summary>
        private void ApplyTheme()
        {
            if (isDarkMode)
            {
                // Dark Mode Colors
                this.BackColor = Color.FromArgb(27, 39, 55);
                this.gameCanvas.BackColor = Color.FromArgb(10, 14, 25);
                this.panelScore.BackColor = Color.FromArgb(10, 14, 25);
                this.panelNextPiece.BackColor = Color.FromArgb(10, 14, 25);
                this.pictureBoxStartStop.BackColor = Color.FromArgb(10, 14, 25);
                this.pictureBoxTheme.BackColor = Color.FromArgb(10, 14, 25);
                this.pictureBoxReset.BackColor = Color.FromArgb(10, 14, 25);
                this.nextPieceCanvas.BackColor = Color.FromArgb(10, 14, 25);

                this.lblNext.ForeColor = Color.White;
                this.lblTitleScore.ForeColor = Color.White;
                this.lblScore.ForeColor = Color.White;
                this.lblTitleLevel.ForeColor = Color.White;
                this.lblLevel.ForeColor = Color.White;
                this.lblTitleLines.ForeColor = Color.White;
                this.lblLines.ForeColor = Color.White;
                this.ForeColor = Color.White;

                this.pictureBoxStartStop.Image = Properties.Resources.play_white;
                this.pictureBoxTheme.Image = Properties.Resources.sun_white;
                this.pictureBoxReset.Image = Properties.Resources.reset_white;

            }
            else
            {
                // Light Mode Colors
                this.BackColor = Color.FromArgb(255, 255, 255);
                this.gameCanvas.BackColor = Color.FromArgb(197, 200, 205);
                this.panelScore.BackColor = Color.FromArgb(197, 200, 205);
                this.panelNextPiece.BackColor = Color.FromArgb(197, 200, 205);
                this.pictureBoxStartStop.BackColor = Color.FromArgb(197, 200, 205);
                this.pictureBoxTheme.BackColor = Color.FromArgb(197, 200, 205);
                this.pictureBoxReset.BackColor = Color.FromArgb(197, 200, 205);
                this.nextPieceCanvas.BackColor = Color.FromArgb(197, 200, 205);

                this.lblNext.ForeColor = Color.Black;
                this.lblTitleScore.ForeColor = Color.Black;
                this.lblScore.ForeColor = Color.Black;
                this.lblTitleLevel.ForeColor = Color.Black;
                this.lblLevel.ForeColor = Color.Black;
                this.lblTitleLines.ForeColor = Color.Black;
                this.lblLines.ForeColor = Color.Black;
                this.ForeColor = Color.Black;

                this.pictureBoxStartStop.Image = Properties.Resources.play_black;
                this.pictureBoxTheme.Image = Properties.Resources.moon_black;
                this.pictureBoxReset.Image = Properties.Resources.reset_black;
            }            
        }

        /// <summary>
        /// Updates the Play/Pause icon based on the current game state and active theme.
        /// </summary>
        private void UpdateStartStopImage()
        {
            // Display 'Play' icon if the game is stopped or paused
            bool showPlayIcon = (!isGameStarted || isPaused);
                        
            if (isDarkMode)
            {
                pictureBoxStartStop.Image = showPlayIcon
                    ? Properties.Resources.play_white
                    : Properties.Resources.pause_white;
            }
            else
            {
                pictureBoxStartStop.Image = showPlayIcon
                    ? Properties.Resources.play_black
                    : Properties.Resources.pause_black;
            }
        }

        /// <summary>
        /// Refreshes the score labels and calculates the dynamic game speed based on the current level.
        /// </summary>
        private void UpdateScoreDisplay()
        {
            // Update score, level, and lines cleared labels
            lblScore.Text = tetrisGame.PlayerScore.CurrentScore.ToString() + " pts";
            lblLevel.Text = tetrisGame.PlayerScore.Level.ToString();
            lblLines.Text = tetrisGame.PlayerScore.TotalLinesCleared.ToString();

            // Dynamic speed calculation
            int baseSpeed = 600; 
            int speedDecreasePerLevel = 50; 
            int newInterval = baseSpeed - ((tetrisGame.PlayerScore.Level - 1) * speedDecreasePerLevel);

            // Ensure the game doesn't become impossibly fast (cap at 100ms)
            GameTimer.Interval = Math.Max(100, newInterval);
        }

        /// <summary>
        /// Main game loop triggered by the timer. Handles gravity and checks for game over conditions.
        /// </summary>
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (!tetrisGame.isGameOver)
            {
                tetrisGame.UpdateGame("down");

                // Only invalidate specific areas to optimize performance
                gameCanvas.Invalidate();
                nextPieceCanvas.Invalidate();
                UpdateScoreDisplay();
            }
            else
            {
                GameTimer.Stop();
                gameCanvas.Invalidate();
            }
        }

        /// <summary>
        /// Intercepts keyboard input to control the Tetris piece.
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            // Ignore inputs if the game is not active
            if (!isGameStarted || isPaused || tetrisGame.isGameOver)
            {
                return;
            }

            // Handle movement and rotation based on arrow keys
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
            
            gameCanvas.Invalidate();
            UpdateScoreDisplay();
        }

        /// <summary>
        /// Renders the main game board and the currently moving piece.
        /// </summary>
        private void GameCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw the locked pieces on the board
            for (int height = 0; height < tetrisGame.height; height++)
            {
                for (int width = 0; width < tetrisGame.width; width++)
                {
                    Color cellColor = tetrisGame.myGameBoard.board[height, width];

                    if (cellColor != Color.White)
                    {
                        DrawSquare(g, width, height, cellColor);
                    }
                }
            }

            // Draw the active, moving piece
            if (tetrisGame.movingPiece != null && !tetrisGame.isPieceLocked)
            {
                foreach (Point p in tetrisGame.movingPiece.squaresOfThePiece)
                {
                    DrawSquare(g, p.X, p.Y, tetrisGame.movingPiece.pieceColor);
                }
            }

            // If the game is over, draw a semi-transparent overlay and display the "Game Over" message with the final score
            if (tetrisGame.isGameOver)
            {
                // Draw a semi-transparent black overlay to dim the game board
                using (Brush overlayBrush = new SolidBrush(Color.FromArgb(200, 0, 0, 0)))
                {
                    g.FillRectangle(overlayBrush, 0, 0, gameCanvas.Width, gameCanvas.Height);
                }

                // Prepare the "Game Over" text and final score to be displayed
                string gameOverText = "GAME OVER";
                string scoreText = "Final score : " + tetrisGame.PlayerScore.CurrentScore;

                // Use larger font for the "Game Over" message and a smaller font for the score, both centered on the canvas
                using (Font titleFont = new Font("Segoe UI", 24, FontStyle.Bold))
                using (Font scoreFont = new Font("Segoe UI", 12, FontStyle.Regular))
                using (Brush textBrush = new SolidBrush(Color.White)) 
                {                    
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;  
                    format.LineAlignment = StringAlignment.Center;
                    
                    float centerX = gameCanvas.Width / 2f;
                    float centerY = gameCanvas.Height / 2f;
                    
                    g.DrawString(gameOverText, titleFont, textBrush, centerX, centerY - 20, format);
                    g.DrawString(scoreText, scoreFont, textBrush, centerX, centerY + 25, format);
                }
            }
        }

        /// <summary>
        /// Renders the upcoming piece in the preview box, calculating an offset to center it perfectly.
        /// </summary>
        private void NextPieceCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // If there is no next piece, we can't draw anything
            if (tetrisGame.nextPiece == null) return;

            // Define the size of each cell in the preview and the size of the preview box
            int previewCellSize = 20;
            int boxSize = 100;

            // Find the bounding box of the piece to calculate its true dimensions
            int minX = int.MaxValue, maxX = int.MinValue;
            int minY = int.MaxValue, maxY = int.MinValue;

            // Loop through the piece's squares to find the min and max X and Y coordinates
            foreach (Point p in tetrisGame.nextPiece.squaresOfThePiece)
            {
                if (p.X < minX) minX = p.X;
                if (p.X > maxX) maxX = p.X;
                if (p.Y < minY) minY = p.Y;
                if (p.Y > maxY) maxY = p.Y;
            }

            // Find the actual width and height of the piece in pixels
            int pieceWidthPixels = (maxX - minX + 1) * previewCellSize;
            int pieceHeightPixels = (maxY - minY + 1) * previewCellSize;

            // Calculate dynamic offsets to center the piece inside the 100x100 box
            int offsetX = (boxSize - pieceWidthPixels) / 2;
            int offsetY = (boxSize - pieceHeightPixels) / 2;

            // Draw the piece squares with the calculated offsets
            foreach (Point p in tetrisGame.nextPiece.squaresOfThePiece)
            {                
                int drawX = offsetX + (p.X - minX) * previewCellSize;
                int drawY = offsetY + (p.Y - minY) * previewCellSize;

                // Draw each square of the piece in the preview box using its color
                using (Brush b = new SolidBrush(tetrisGame.nextPiece.pieceColor))
                {
                    g.FillRectangle(b, drawX, drawY, previewCellSize, previewCellSize);
                    g.DrawRectangle(Pens.Black, drawX, drawY, previewCellSize, previewCellSize);
                }
            }
        }

        /// <summary>
        /// Helper method to draw a single square block on the graphics context.
        /// </summary>
        private void DrawSquare(Graphics g, int x, int y, Color color)
        {
            // Draw a filled rectangle with a black border to represent a single cell of the Tetris piece
            using (Brush b = new SolidBrush(color))
            {
                g.FillRectangle(b, x * cellSize, y * cellSize, cellSize, cellSize);
                g.DrawRectangle(Pens.Black, x * cellSize, y * cellSize, cellSize, cellSize);
            }
        }

        /// <summary>
        /// Handles the click event for the Play/Pause button.
        /// </summary>
        private void pictureBoxStartStop_Click(object sender, EventArgs e)
        {
            // If the game hasn't started yet, start it. Otherwise, toggle pause/play.
            if (!isGameStarted)
            {               
                isGameStarted = true;
                pictureBoxReset.Enabled = true;
                GameTimer.Start();
            }
            else if (!tetrisGame.isGameOver)
            {                
                isPaused = !isPaused;
                if (isPaused) GameTimer.Stop();
                else GameTimer.Start();
            }

            UpdateStartStopImage();

            // Return focus to the form so keyboard inputs are registered
            this.Focus();
        }

        /// <summary>
        /// Handles the click event for the Theme toggle button.
        /// </summary>
        private void pictureBoxTheme_Click(object sender, EventArgs e)
        {
            // Toggle the theme mode and apply the new theme settings
            isDarkMode = !isDarkMode;
            ApplyTheme();
            UpdateStartStopImage();

            // Return focus to the form so keyboard inputs are registered
            this.Focus();
        }

        /// <summary>
        /// Handles the click event for the Reset button, reinitializing the game state.
        /// </summary>
        private void pictureBoxReset_Click(object sender, EventArgs e)
        {
            
            if (!pictureBoxReset.Enabled) return;

            // Reinitialize the game state and UI elements to start fresh
            tetrisGame = new Game();
            isPaused = false;
            isGameStarted = false;
            GameTimer.Stop();
            UpdateScoreDisplay();
            gameCanvas.Invalidate();
            nextPieceCanvas.Invalidate();         
            UpdateStartStopImage();

            // Return focus to the form so keyboard inputs are registered
            this.Focus();
        }

        /// <summary>
        /// Provides visual feedback (highlight) when the mouse hovers over a custom control.
        /// </summary>
        private void CustomControl_MouseEnter(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl != null && ctrl.Enabled)
            {                
                ctrl.BackColor = isDarkMode
                    ? Color.FromArgb(30, 40, 60)
                    : Color.FromArgb(220, 225, 230); 
            }
        }

        /// <summary>
        /// Removes visual feedback when the mouse leaves a custom control.
        /// </summary>
        private void CustomControl_MouseLeave(object sender, EventArgs e)
        {
            // Reset the background color to the default based on the current theme
            Control ctrl = sender as Control;
            if (ctrl != null && ctrl.Enabled)
            {                
                ctrl.BackColor = isDarkMode
                    ? Color.FromArgb(10, 14, 25)
                    : Color.FromArgb(197, 200, 205);
            }
        }
    }
}