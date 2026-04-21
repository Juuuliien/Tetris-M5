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
            label1 = new Label();
            nextPieceCanvas = new PictureBox();
            panelScore = new Panel();
            lblLines = new Label();
            label6 = new Label();
            lblLevel = new Label();
            lblScore = new Label();
            label3 = new Label();
            label2 = new Label();
            panelStartResume = new Panel();
            lblStartResume = new Label();
            label_tetris = new Label();
            pictureBoxTheme = new PictureBox();
            pictureBoxReset = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)gameCanvas).BeginInit();
            panelNextPiece.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nextPieceCanvas).BeginInit();
            panelScore.SuspendLayout();
            panelStartResume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTheme).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxReset).BeginInit();
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
            gameCanvas.Location = new Point(82, 118);
            gameCanvas.Name = "gameCanvas";
            gameCanvas.Size = new Size(300, 630);
            gameCanvas.TabIndex = 0;
            gameCanvas.TabStop = false;
            // 
            // panelNextPiece
            // 
            panelNextPiece.BackColor = Color.FromArgb(4, 5, 10);
            panelNextPiece.Controls.Add(label1);
            panelNextPiece.Controls.Add(nextPieceCanvas);
            panelNextPiece.Location = new Point(410, 118);
            panelNextPiece.Name = "panelNextPiece";
            panelNextPiece.Size = new Size(150, 146);
            panelNextPiece.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(36, 5);
            label1.Name = "label1";
            label1.Size = new Size(76, 32);
            label1.TabIndex = 0;
            label1.Text = "NEXT";
            // 
            // nextPieceCanvas
            // 
            nextPieceCanvas.Location = new Point(24, 37);
            nextPieceCanvas.Name = "nextPieceCanvas";
            nextPieceCanvas.Size = new Size(100, 80);
            nextPieceCanvas.TabIndex = 0;
            nextPieceCanvas.TabStop = false;
            // 
            // panelScore
            // 
            panelScore.BackColor = Color.FromArgb(4, 5, 10);
            panelScore.Controls.Add(lblLines);
            panelScore.Controls.Add(label6);
            panelScore.Controls.Add(lblLevel);
            panelScore.Controls.Add(lblScore);
            panelScore.Controls.Add(label3);
            panelScore.Controls.Add(label2);
            panelScore.Location = new Point(410, 292);
            panelScore.Name = "panelScore";
            panelScore.Size = new Size(150, 229);
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(17, 158);
            label6.Name = "label6";
            label6.Size = new Size(72, 32);
            label6.TabIndex = 5;
            label6.Text = "Lines";
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(18, 86);
            label3.Name = "label3";
            label3.Size = new Size(72, 32);
            label3.TabIndex = 2;
            label3.Text = "Level";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(17, 11);
            label2.Name = "label2";
            label2.Size = new Size(77, 32);
            label2.TabIndex = 1;
            label2.Text = "Score";
            // 
            // panelStartResume
            // 
            panelStartResume.BackColor = Color.FromArgb(4, 5, 10);
            panelStartResume.Controls.Add(lblStartResume);
            panelStartResume.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panelStartResume.Location = new Point(407, 591);
            panelStartResume.Name = "panelStartResume";
            panelStartResume.Size = new Size(150, 33);
            panelStartResume.TabIndex = 5;
            // 
            // lblStartResume
            // 
            lblStartResume.AutoSize = true;
            lblStartResume.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStartResume.ForeColor = Color.White;
            lblStartResume.Location = new Point(46, 4);
            lblStartResume.Name = "lblStartResume";
            lblStartResume.Size = new Size(56, 25);
            lblStartResume.TabIndex = 0;
            lblStartResume.Text = "Start";
            // 
            // label_tetris
            // 
            label_tetris.AutoSize = true;
            label_tetris.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_tetris.ForeColor = Color.White;
            label_tetris.Location = new Point(226, 27);
            label_tetris.Name = "label_tetris";
            label_tetris.Size = new Size(183, 65);
            label_tetris.TabIndex = 6;
            label_tetris.Text = "TETRIS";
            // 
            // pictureBoxTheme
            // 
            pictureBoxTheme.BackColor = Color.FromArgb(4, 5, 10);
            pictureBoxTheme.Image = Properties.Resources.reset_white;
            pictureBoxTheme.Location = new Point(407, 661);
            pictureBoxTheme.Name = "pictureBoxTheme";
            pictureBoxTheme.Size = new Size(65, 59);
            pictureBoxTheme.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxTheme.TabIndex = 0;
            pictureBoxTheme.TabStop = false;
            // 
            // pictureBoxReset
            // 
            pictureBoxReset.BackColor = Color.FromArgb(4, 5, 10);
            pictureBoxReset.Image = Properties.Resources.reset_white;
            pictureBoxReset.Location = new Point(492, 661);
            pictureBoxReset.Name = "pictureBoxReset";
            pictureBoxReset.Size = new Size(68, 59);
            pictureBoxReset.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxReset.TabIndex = 7;
            pictureBoxReset.TabStop = false;
            // 
            // Presentation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 39, 55);
            ClientSize = new Size(655, 820);
            Controls.Add(pictureBoxReset);
            Controls.Add(pictureBoxTheme);
            Controls.Add(label_tetris);
            Controls.Add(panelStartResume);
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
            panelStartResume.ResumeLayout(false);
            panelStartResume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTheme).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxReset).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private PictureBox gameCanvas;
        private Panel panelNextPiece;
        private Panel panelScore;
        private Panel panelStartResume;
        private Label label_tetris;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label lblScore;
        private Label lblLevel;
        private PictureBox nextPieceCanvas;
        private Label lblLines;
        private Label label6;
        private Label lblStartResume;
        private PictureBox pictureBoxTheme;
        private PictureBox pictureBoxReset;
    }
}
