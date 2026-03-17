using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_M5.Pieces
{
    public class Piece
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

        /// <summary>
        /// Copies the current piece's properties to another piece.        
        /// </summary>
        /// <param name="targetPiece">The piece that will receive the copied values.</param>
        public void CopyTo(Piece targetPiece)
        {
            // Copy the color, tilt, and square positions to the target piece
            targetPiece.pieceColor = this.pieceColor;
            targetPiece.pieceTilt = this.pieceTilt;

            // Copy the positions of the squares of the piece
            for (int i = 0; i < this.squaresOfThePiece.Length; i++)
            {
                targetPiece.squaresOfThePiece[i] = this.squaresOfThePiece[i];
            }
        }

        /// <summary>
        /// Rotates the piece 90 degrees clockwise
        /// </summary>
        public virtual void rotation90() { }

        /// <summary>
        /// Rotates the piece 180 degrees clockwise
        /// </summary>
        public virtual void rotation180() { }

        /// <summary>
        /// Rotates the piece 270 degrees clockwise
        /// </summary>
        public virtual void rotation270() { }

        /// <summary>
        /// Rotates the piece 360 degrees clockwise
        /// </summary>
        public virtual void rotation360() { }

    }
}
