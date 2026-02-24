using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_M5.Piece
{
    internal class Piece
    {
        // Set parameters for the piece
        public Color pieceColor;
        public int pieceTilt;
        public Point[] squaresOfThePiece;

        /// <summary>
        /// Constructor for the piece class
        /// </summary>
        public Piece()
        {
            squaresOfThePiece = new Point[] { new Point(), new Point(), new Point(), new Point() };
        }

        /// <summary>
        /// Method to move the piece down one square
        /// </summary>
        public void fallOneSquare()
        {
            for (int arrayIndex = 0; arrayIndex < squaresOfThePiece.Length; arrayIndex++)
            {
                squaresOfThePiece[arrayIndex].Y++;
            }           
        }

        /// <summary>
        /// Method to move the piece left one square
        /// </summary>
        public void moveLeft()
        {
            for (int arrayIndex = 0; arrayIndex < squaresOfThePiece.Length; arrayIndex++)
            {
                squaresOfThePiece[arrayIndex].X--;
            }
        }

        /// <summary>
        /// Method to move the piece right one square
        /// </summary>
        public void moveRight()
        {
            for (int arrayIndex = 0; arrayIndex < squaresOfThePiece.Length; arrayIndex++)
            {
                squaresOfThePiece[arrayIndex].X++;
            }
        }
    }
}
