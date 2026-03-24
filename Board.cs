using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Tetris_M5.Pieces;

namespace Tetris_M5
{
    public class Board
    {

        public int Width { get; private set; }
        public int Height { get; private set; }


        // Array to store the grid colors
        public Color[,] board;

        // List to keep track of which rows need to be removed
        private List<int> linesToDelete;

        /// <summary>
        /// Constructor for the GameBoard class. Initializes the grid with empty (white) cells.
        /// </summary>
        /// <param name="width">The number of columns in the grid.</param>
        /// <param name="height">The number of rows in the grid.</param>
        public Board(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            this.board = new Color[height, width];
            this.linesToDelete = new List<int>();

            // Initialize the board with White color to represent empty space
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    this.board[h, w] = Color.White;
                }
            }
        }

        /// <summary>
        /// Adds the moving piece to the static grid once it has landed.
        /// </summary>
        /// <param name="movingPiece">The piece to lock into the board.</param>
        public void AddPiece(Piece movingPiece)
        {
            for (int index = 0; index < movingPiece.squaresOfThePiece.Length; index++)
            {
                board[movingPiece.squaresOfThePiece[index].Y, movingPiece.squaresOfThePiece[index].X] = movingPiece.pieceColor;
            }
        }

        /// <summary>
        /// Removes the moving piece from the grid.
        /// </summary>
        /// <param name="movingPiece">The piece to remove from the board.</param>
        public void RemovePiece(Piece movingPiece)
        {
            for (int i = 0; i < movingPiece.squaresOfThePiece.Length; i++)
            {
                board[movingPiece.squaresOfThePiece[i].Y, movingPiece.squaresOfThePiece[i].X] = Color.White;
            }
        }

        /// <summary>
        /// Checks if a specific cell is within the board limits and is currently empty.
        /// </summary>
        /// <param name="cell">The coordinates of the cell to check.</param>
        /// <returns>True if the cell is free and inside the grid limits, false otherwise.</returns>
        public bool IsCellFree(Point cell)
        {
            // Check if the cell is out of bounds
            if (cell.X < 0 || cell.X >= Width || cell.Y < 0 || cell.Y >= Height)
            {
                return false;
            }

            // Check if the cell is unoccupied (White)
            return board[cell.Y, cell.X] == Color.White;
        }

        /// <summary>
        /// Checks if the top limit of the board has been reached, causing a Game Over.
        /// </summary>
        /// <returns>True if the top area is clear, false if pieces have stacked to the top.</returns>
        public bool IsTopAreaClear()
        {
            // Checking the second row (index 1) to see if any block is permanently placed there
            for (int x = 0; x < Width; x++)
            {
                if (board[1, x] != Color.White)
                {
                    return false; // Game Over condition
                }
            }
            return true;
        }

        /// <summary>
        /// Scans the rows where the piece just landed to find any fully completed lines.
        /// </summary>
        /// <param name="movingPiece">The piece that was just placed.</param>
        public void IdentifyCompleteLines(Piece movingPiece)
        {
            List<int> temporaryList = new List<int>();

            // Only check the rows where the piece actually landed
            for (int i = 0; i < movingPiece.squaresOfThePiece.Length; i++)
            {
                int y = movingPiece.squaresOfThePiece[i].Y;
                bool isLineFull = true;

                for (int x = 0; x < Width; x++)
                {
                    if (board[y, x] == Color.White)
                    {
                        isLineFull = false;
                        break; // Stop checking this row as soon as we find an empty cell
                    }
                }

                if (isLineFull)
                {
                    temporaryList.Add(y);
                }
            }
            // Keep only distinct row indexes and sort them to avoid shifting bugs
            linesToDelete = temporaryList.Distinct().ToList();
            linesToDelete.Sort();
        }


        /// <summary>
        /// Deletes the completed lines identified previously and shifts the upper blocks down.
        /// </summary>
        /// <returns>The number of lines successfully cleared.</returns>
        public int ClearCompleteLines()
        {
            int clearedCount = linesToDelete.Count;

            // If no lines to delete, do nothing and return 0
            if (clearedCount == 0) return 0;

            foreach (int rowIndex in linesToDelete)
            {
                ClearLine(rowIndex);
                ShiftLinesDown(rowIndex);
            }

            // Clear the list for the next turn
            linesToDelete.Clear();

            // Return the count to the Game class so it can calculate the score!
            return clearedCount;
        }
        /// <summary>
        /// Clears a specific row by painting all its cells white.
        /// </summary>
        /// <param name="rowIndex">The index of the row to clear.</param>
        private void ClearLine(int rowIndex)
        {
            for (int x = 0; x < Width; x++)
            {
                board[rowIndex, x] = Color.White;
            }
        }

        /// <summary>
        /// Shifts all rows above the cleared row down by one position.
        /// </summary>
        /// <param name="clearedRowIndex">The index of the row that was just cleared.</param>
        private void ShiftLinesDown(int clearedRowIndex)
        {
            for (int y = clearedRowIndex; y >= 1; y--)
            {
                for (int x = 0; x < Width; x++)
                {
                    // Move the color from the cell above to the current cell
                    board[y, x] = board[y - 1, x];
                }
            }

            // Ensure the very top row is completely cleared after shifting
            for (int x = 0; x < Width; x++)
            {
                board[0, x] = Color.White;
            }
        }
    }
}