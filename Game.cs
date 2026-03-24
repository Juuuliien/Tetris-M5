using System;
using System.Drawing;
using Tetris_M5;
using Tetris_M5.Pieces;


namespace TetrisDomain
{
    public class Game
    {
        // Array to represent the game board
        public Board myGameBoard;
        public int height = 21;
        public int width = 10;

        // Pieces for the game
        public Piece movingPiece;
        public Piece controlPiece;
        public Piece nextPiece;

        // Random number generator for piece generation
        private Random rand;

        // Game State Variables
        public bool isPieceLocked = true;
        public bool isGameOver = false;

        // Player Progress
        public ScoreManager PlayerScore { get; private set; }        

        /// <summary>
        /// Constructor for the Game class
        /// </summary>
        public Game()
        {
            myGameBoard = new Board(width, height);
            rand = new Random();
            PlayerScore = new ScoreManager();
        }

        /// <summary>
        /// Core game loop method. Called every tick of the timer or when a key is pressed.
        /// </summary>
        /// <param name="direction">The direction to move ("down", "left", "right", "rotation").</param>
        public void UpdateGame(string direction)
        {
            if (isGameOver) return; // Stop processing if the game is over

            // If the current piece is locked, we need a new one
            if (isPieceLocked)
            {
                // Check for Game Over condition
                if (!myGameBoard.IsTopAreaClear())
                {
                    isGameOver = true;
                    return;
                }

                // Generate pieces
                isPieceLocked = false;

                if (movingPiece == null) // First turn ever
                {
                    movingPiece = GeneratePiece();
                }
                else
                {
                    movingPiece = nextPiece; // Take the preview piece                                             
                }

                nextPiece = GeneratePiece();
               

                myGameBoard.AddPiece(movingPiece);
            }
            else // The piece is currently falling or being moved by the player
            {
                if (CanPieceMove(direction))
                {
                    MovePiece(direction);
                }
                else if (direction == "down")
                {
                    // If it can't move down anymore, lock it in place!
                    isPieceLocked = true;
                }
            }

            // If the piece just locked, check for completed lines and update score
            if (isPieceLocked)
            {
                myGameBoard.IdentifyCompleteLines(movingPiece);
                int clearedLinesCount = myGameBoard.ClearCompleteLines();

                if (clearedLinesCount > 0)
                {
                    PlayerScore.AddLinesCompleted(clearedLinesCount);
                }
            }
        }

        /// <summary>
        /// Generates a random Tetrimino piece.
        /// </summary>
        /// <returns>A newly instantiated Piece.</returns>
        public Piece GeneratePiece()
        {
            Piece piece;
            int randomNumber = rand.Next(1, 8);

            switch (randomNumber)
            {
                case 1: piece = new PieceI(); break;
                case 2: piece = new PieceT(); break;
                case 3: piece = new PieceJ(); break;
                case 4: piece = new PieceL(); break;
                case 5: piece = new PieceO(); break;
                case 6: piece = new PieceS(); break;
                case 7: piece = new PieceZ(); break;
                default: piece = new Piece(); break;
            }
            return piece;
        }

        /// <summary>
        /// Simulates the movement using a control piece to check for collisions.
        /// </summary>
        /// <param name="direction">The attempted direction.</param>
        /// <returns>True if the move is legal, false if it hits a wall or block.</returns>
        public bool CanPieceMove(string direction)
        {
            // 1. TEMPORARILY remove the current piece from the board to avoid colliding with itself
            myGameBoard.RemovePiece(movingPiece);

            // 2. Setup the control piece to simulate the move
            controlPiece = movingPiece.Clone();

            // 3. Apply the movement to the control piece
            switch (direction)
            {
                case "down": controlPiece.FallOneSquare(); break;
                case "left": controlPiece.MoveLeft(); break; // Corrigé pour correspondre à tes méthodes
                case "right": controlPiece.MoveRight(); break;
                case "rotation":
                    switch (controlPiece.pieceTilt)
                    {
                        case 0: controlPiece.Rotation90(); break;
                        case 90: controlPiece.Rotation180(); break;
                        case 180: controlPiece.Rotation270(); break;
                        case 270: controlPiece.Rotation360(); break;
                    }
                    break;
            }

            // 4. Check if the new position is completely free
            bool canMove = true;
            for (int i = 0; i < controlPiece.squaresOfThePiece.Length; i++)
            {
                if (!myGameBoard.IsCellFree(controlPiece.squaresOfThePiece[i]))
                {
                    canMove = false;
                    break; // As soon as one block hits something, the move is invalid
                }
            }

            // 5. Restore the original piece to the board before returning the result
            myGameBoard.AddPiece(movingPiece);

            return canMove;
        }

        /// <summary>
        /// Actually moves the current piece on the board.
        /// </summary>
        /// <param name="direction">The direction to move.</param>
        public void MovePiece(string direction)
        {
            myGameBoard.RemovePiece(movingPiece);

            switch (direction)
            {
                case "down": movingPiece.FallOneSquare(); break;
                case "left": movingPiece.MoveLeft(); break;
                case "right": movingPiece.MoveRight(); break;
                case "rotation":
                    switch (movingPiece.pieceTilt)
                    {
                        case 0: movingPiece.Rotation90(); break;
                        case 90: movingPiece.Rotation180(); break;
                        case 180: movingPiece.Rotation270(); break;
                        case 270: movingPiece.Rotation360(); break;
                    }
                    break;
            }
            myGameBoard.AddPiece(movingPiece);
        }
    }
}
