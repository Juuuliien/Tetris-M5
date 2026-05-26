namespace Tetris_M5
{
    partial class Presentation
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            GameTimer = new System.Windows.Forms.Timer(components);
            gameCanvas = new PictureBox();
            panelNextPiece = new Panel();
            lblNext = new Label();
            nextPieceCanvas = new PictureBox();
            panelScore = new Panel();
            lblLines = new Label();
            lblTitleLines = new Label();
            lblLevel = new Label();
            lblScore = new Label();
            lblTitleLevel = new Label();
            lblTitleScore = new Label();
            pictureBoxStartStop = new PictureBox();
            pictureBoxReset = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBoxTheme = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)gameCanvas).BeginInit();
            panelNextPiece.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nextPieceCanvas).BeginInit();
            panelScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStartStop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxReset).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTheme).BeginInit();
            SuspendLayout();
            // 
            // GameTimer
            // 
            GameTimer.Interval = 500;
            GameTimer.Tick += GameTimer_Tick;
            // 
            // gameCanvas
            // 
            gameCanvas.BackColor = Color.FromArgb(4, 5, 10);
            gameCanvas.Location = new Point(82, 138);
            gameCanvas.Name = "gameCanvas";
            gameCanvas.Size = new Size(300, 630);
            gameCanvas.TabIndex = 0;
            gameCanvas.TabStop = false;
            gameCanvas.Paint += GameCanvas_Paint;
            gameCanvas.MouseDown += gameCanvas_MouseDown;
            // 
            // panelNextPiece
            // 
            panelNextPiece.BackColor = Color.FromArgb(4, 5, 10);
            panelNextPiece.Controls.Add(lblNext);
            panelNextPiece.Controls.Add(nextPieceCanvas);
            panelNextPiece.Location = new Point(410, 138);
            panelNextPiece.Name = "panelNextPiece";
            panelNextPiece.Size = new Size(150, 146);
            panelNextPiece.TabIndex = 2;
            // 
            // lblNext
            // 
            lblNext.AutoSize = true;
            lblNext.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNext.ForeColor = SystemColors.ButtonFace;
            lblNext.Location = new Point(36, 5);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(76, 32);
            lblNext.TabIndex = 0;
            lblNext.Text = "NEXT";
            // 
            // nextPieceCanvas
            // 
            nextPieceCanvas.Location = new Point(24, 37);
            nextPieceCanvas.Name = "nextPieceCanvas";
            nextPieceCanvas.Size = new Size(100, 80);
            nextPieceCanvas.TabIndex = 0;
            nextPieceCanvas.TabStop = false;
            nextPieceCanvas.Paint += NextPieceCanvas_Paint;
            // 
            // panelScore
            // 
            panelScore.BackColor = Color.FromArgb(4, 5, 10);
            panelScore.Controls.Add(lblLines);
            panelScore.Controls.Add(lblTitleLines);
            panelScore.Controls.Add(lblLevel);
            panelScore.Controls.Add(lblScore);
            panelScore.Controls.Add(lblTitleLevel);
            panelScore.Controls.Add(lblTitleScore);
            panelScore.Location = new Point(410, 312);
            panelScore.Name = "panelScore";
            panelScore.Size = new Size(150, 391);
            panelScore.TabIndex = 3;
            // 
            // lblLines
            // 
            lblLines.AutoSize = true;
            lblLines.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLines.ForeColor = Color.White;
            lblLines.Location = new Point(22, 190);
            lblLines.Name = "lblLines";
            lblLines.Size = new Size(23, 21);
            lblLines.TabIndex = 6;
            lblLines.Text = "7 ";
            // 
            // lblTitleLines
            // 
            lblTitleLines.AutoSize = true;
            lblTitleLines.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleLines.ForeColor = SystemColors.ButtonFace;
            lblTitleLines.Location = new Point(17, 158);
            lblTitleLines.Name = "lblTitleLines";
            lblTitleLines.Size = new Size(72, 32);
            lblTitleLines.TabIndex = 5;
            lblTitleLines.Text = "Lines";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLevel.ForeColor = Color.White;
            lblLevel.Location = new Point(22, 118);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(19, 21);
            lblLevel.TabIndex = 4;
            lblLevel.Text = "2";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(20, 45);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(70, 21);
            lblScore.TabIndex = 3;
            lblScore.Text = "1500 pts";
            // 
            // lblTitleLevel
            // 
            lblTitleLevel.AutoSize = true;
            lblTitleLevel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleLevel.ForeColor = SystemColors.ButtonFace;
            lblTitleLevel.Location = new Point(18, 86);
            lblTitleLevel.Name = "lblTitleLevel";
            lblTitleLevel.Size = new Size(72, 32);
            lblTitleLevel.TabIndex = 2;
            lblTitleLevel.Text = "Level";
            // 
            // lblTitleScore
            // 
            lblTitleScore.AutoSize = true;
            lblTitleScore.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleScore.ForeColor = SystemColors.ButtonFace;
            lblTitleScore.Location = new Point(17, 11);
            lblTitleScore.Name = "lblTitleScore";
            lblTitleScore.Size = new Size(77, 32);
            lblTitleScore.TabIndex = 1;
            lblTitleScore.Text = "Score";
            // 
            // pictureBoxStartStop
            // 
            pictureBoxStartStop.BackColor = Color.FromArgb(4, 5, 10);
            pictureBoxStartStop.Image = Properties.Resources.play_white;
            pictureBoxStartStop.Location = new Point(406, 723);
            pictureBoxStartStop.Name = "pictureBoxStartStop";
            pictureBoxStartStop.Size = new Size(45, 45);
            pictureBoxStartStop.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxStartStop.TabIndex = 0;
            pictureBoxStartStop.TabStop = false;
            pictureBoxStartStop.Click += pictureBoxStartStop_Click;
            pictureBoxStartStop.MouseEnter += CustomControl_MouseEnter;
            pictureBoxStartStop.MouseLeave += CustomControl_MouseLeave;
            // 
            // pictureBoxReset
            // 
            pictureBoxReset.BackColor = Color.FromArgb(4, 5, 10);
            pictureBoxReset.Image = Properties.Resources.reset_white;
            pictureBoxReset.Location = new Point(515, 723);
            pictureBoxReset.Name = "pictureBoxReset";
            pictureBoxReset.Size = new Size(45, 45);
            pictureBoxReset.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxReset.TabIndex = 7;
            pictureBoxReset.TabStop = false;
            pictureBoxReset.Click += pictureBoxReset_Click;
            pictureBoxReset.MouseEnter += CustomControl_MouseEnter;
            pictureBoxReset.MouseLeave += CustomControl_MouseLeave;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_tetris;
            pictureBox1.Location = new Point(210, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(214, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // pictureBoxTheme
            // 
            pictureBoxTheme.BackColor = Color.FromArgb(4, 5, 10);
            pictureBoxTheme.Image = Properties.Resources.sun_white;
            pictureBoxTheme.Location = new Point(459, 723);
            pictureBoxTheme.Name = "pictureBoxTheme";
            pictureBoxTheme.Size = new Size(45, 45);
            pictureBoxTheme.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxTheme.TabIndex = 9;
            pictureBoxTheme.TabStop = false;
            pictureBoxTheme.Click += pictureBoxTheme_Click;
            pictureBoxTheme.MouseEnter += CustomControl_MouseEnter;
            pictureBoxTheme.MouseLeave += CustomControl_MouseLeave;
            // 
            // Presentation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 39, 55);
            ClientSize = new Size(655, 820);
            Controls.Add(pictureBoxTheme);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBoxReset);
            Controls.Add(pictureBoxStartStop);
            Controls.Add(panelScore);
            Controls.Add(panelNextPiece);
            Controls.Add(gameCanvas);
            Margin = new Padding(2);
            Name = "Presentation";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)gameCanvas).EndInit();
            panelNextPiece.ResumeLayout(false);
            panelNextPiece.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nextPieceCanvas).EndInit();
            panelScore.ResumeLayout(false);
            panelScore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStartStop).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxReset).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTheme).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private PictureBox gameCanvas;
        private Panel panelNextPiece;
        private Panel panelScore;
        private Label lblNext;
        private Label lblTitleLevel;
        private Label lblTitleScore;
        private Label lblScore;
        private Label lblLevel;
        private PictureBox nextPieceCanvas;
        private Label lblLines;
        private Label lblTitleLines;
        private PictureBox pictureBoxStartStop;
        private PictureBox pictureBoxReset;
        private PictureBox pictureBox1;
        private PictureBox pictureBoxTheme;
    }
}
