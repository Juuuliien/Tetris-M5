using TetrisDomain;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris_M5
{
    public partial class Presentation : Form
    {
        private Game tetrisGame;
        private const int cellSize = 30; // Taille d'un carré (ajustable)
        private bool isGameStarted = false;
        private bool isPaused = false;
        private bool isDarkMode = true;

        public Presentation()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.KeyPreview = true;

            tetrisGame = new Game();


            gameCanvas.Paint += GameCanvas_Paint;
            nextPieceCanvas.Paint += NextPieceCanvas_Paint;

            UpdateScoreDisplay();

            

            // Abonnements aux clics
            panelStartResume.Click += PanelStartResume_Click;
            pictureBoxReset.Click += PictureBoxReset_Click;
            pictureBoxTheme.Click += PictureBoxTheme_Click;

            // Abonnements aux effets de survol (Hover)
            panelStartResume.MouseEnter += CustomControl_MouseEnter;
            panelStartResume.MouseLeave += CustomControl_MouseLeave;
            pictureBoxReset.MouseEnter += CustomControl_MouseEnter;
            pictureBoxReset.MouseLeave += CustomControl_MouseLeave;
            pictureBoxTheme.MouseEnter += CustomControl_MouseEnter;
            pictureBoxTheme.MouseLeave += CustomControl_MouseLeave;

            
        }

        private void PanelStartResume_Click(object sender, EventArgs e)
        {
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
            this.Focus();
        }

        private void PictureBoxReset_Click(object sender, EventArgs e)
        {
            if (!pictureBoxReset.Enabled) return;

            tetrisGame = new Game();
            isPaused = false;
            isGameStarted = true;

            UpdateScoreDisplay();
            gameCanvas.Invalidate();
            nextPieceCanvas.Invalidate();
            GameTimer.Start();

            this.Focus();
        }
        private void ApplyTheme()
        {
            if (isDarkMode)
            {
                this.BackColor = Color.FromArgb(40, 44, 52);
                this.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.WhiteSmoke;
                this.ForeColor = Color.Black;
            }
        }

        private void PictureBoxTheme_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme(); // Assure-toi d'avoir bien mis la méthode ApplyTheme() dans ton code !
            this.Focus();
        }
        private void CustomControl_MouseEnter(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl != null && ctrl.Enabled)
            {
                ctrl.BackColor = ControlPaint.Light(ctrl.BackColor);
            }
        }

        private void CustomControl_MouseLeave(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl != null && ctrl.Enabled)
            {
                ctrl.BackColor = ControlPaint.Dark(ctrl.BackColor);
            }
        }

        private void UpdateScoreDisplay()
        {

            lblScore.Text = tetrisGame.PlayerScore.CurrentScore.ToString() + " pts";
            lblLevel.Text = tetrisGame.PlayerScore.Level.ToString();
            lblLines.Text = tetrisGame.PlayerScore.TotalLinesCleared.ToString();

            int baseSpeed = 600; // Vitesse au Niveau 1 (600 ms)
            int speedDecreasePerLevel = 50; // On enlève 50 ms à chaque niveau

            // Calcul mathématique pour réduire le temps d'attente
            int newInterval = baseSpeed - ((tetrisGame.PlayerScore.Level - 1) * speedDecreasePerLevel);

            // Sécurité : On s'assure que le jeu ne devienne pas impossible (vitesse minimum bloquée à 100ms)
            GameTimer.Interval = Math.Max(100, newInterval);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (!tetrisGame.isGameOver)
            {
                tetrisGame.UpdateGame("down");

                // 2. On rafraîchit UNIQUEMENT la PictureBox pour des performances optimales
                gameCanvas.Invalidate();
                nextPieceCanvas.Invalidate();
                UpdateScoreDisplay();
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

            // On rafraîchit après chaque mouvement du joueur
            gameCanvas.Invalidate();

            UpdateScoreDisplay();
        }

        // 3. L'événement Paint lié à la PictureBox
        private void GameCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // DESSINER LA GRILLE
            for (int y = 0; y < tetrisGame.height; y++)
            {
                for (int x = 0; x < tetrisGame.width; x++)
                {
                    // Accès direct à ton tableau comme défini dans ton Game.cs et Board.cs
                    Color cellColor = tetrisGame.myGameBoard.board[y, x];

                    if (cellColor != Color.White)
                    {
                        DrawSquare(g, x, y, cellColor);
                    }
                }
            }

            // DESSINER LA PIÈCE EN MOUVEMENT
            if (tetrisGame.movingPiece != null && !tetrisGame.isPieceLocked)
            {
                // Accès direct à tes variables pieceColor et squaresOfThePiece
                foreach (Point p in tetrisGame.movingPiece.squaresOfThePiece)
                {
                    DrawSquare(g, p.X, p.Y, tetrisGame.movingPiece.pieceColor);
                }
            }
        }

        private void NextPieceCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (tetrisGame.nextPiece == null) return;

            int previewCellSize = 20; // Taille miniature pour que ça rentre bien
            int boxSize = 100;        // Taille de ta PictureBox (100x100)

            // 1. Trouver les limites exactes de la pièce (Min et Max)
            int minX = int.MaxValue, maxX = int.MinValue;
            int minY = int.MaxValue, maxY = int.MinValue;

            foreach (Point p in tetrisGame.nextPiece.squaresOfThePiece)
            {
                if (p.X < minX) minX = p.X;
                if (p.X > maxX) maxX = p.X;
                if (p.Y < minY) minY = p.Y;
                if (p.Y > maxY) maxY = p.Y;
            }

            // 2. Calculer la dimension réelle de la pièce en pixels
            int pieceWidthPixels = (maxX - minX + 1) * previewCellSize;
            int pieceHeightPixels = (maxY - minY + 1) * previewCellSize;

            // 3. Calculer l'OFFSET dynamique pour centrer parfaitement
            // On calcule l'espace vide restant et on le divise par 2
            int offsetX = (boxSize - pieceWidthPixels) / 2;
            int offsetY = (boxSize - pieceHeightPixels) / 2;

            // 4. Dessiner chaque carré avec cet offset
            foreach (Point p in tetrisGame.nextPiece.squaresOfThePiece)
            {
                // On ramène le point à (0,0) avec "-minX" puis on applique l'offset de centrage
                int drawX = offsetX + (p.X - minX) * previewCellSize;
                int drawY = offsetY + (p.Y - minY) * previewCellSize;

                using (Brush b = new SolidBrush(tetrisGame.nextPiece.pieceColor))
                {
                    g.FillRectangle(b, drawX, drawY, previewCellSize, previewCellSize);
                    g.DrawRectangle(Pens.Black, drawX, drawY, previewCellSize, previewCellSize);
                }
            }
        }

        // 4. Petite méthode utilitaire pour éviter de répéter le code de dessin
        private void DrawSquare(Graphics g, int x, int y, Color color)
        {
            using (Brush b = new SolidBrush(color))
            {
                g.FillRectangle(b, x * cellSize, y * cellSize, cellSize, cellSize);
                g.DrawRectangle(Pens.Black, x * cellSize, y * cellSize, cellSize, cellSize);
            }
        }

    }
}