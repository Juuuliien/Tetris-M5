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
        public void FallOneSquare()
        {
            for (int arrayIndex = 0; arrayIndex < squaresOfThePiece.Length; arrayIndex++)
            {
                squaresOfThePiece[arrayIndex].Y++;
            }           
        }

        /// <summary>
        /// Method to move the piece left one square
        /// </summary>
        public void MoveLeft()
        {
            for (int arrayIndex = 0; arrayIndex < squaresOfThePiece.Length; arrayIndex++)
            {
                squaresOfThePiece[arrayIndex].X--;
            } 
        }

        /// <summary>
        /// Method to move the piece right one square
        /// </summary>
        public void MoveRight()
        {
            for (int arrayIndex = 0; arrayIndex < squaresOfThePiece.Length; arrayIndex++)
            {
                squaresOfThePiece[arrayIndex].X++;
            }
        }

        /// <summary>
        /// Clones the piece, creating a new instance with the same properties and values.
        /// </summary>
        /// <returns>Clone of the piece</returns>
        public Piece Clone()
        {
            // Create a shallow copy of the current piece
            Piece clone = (Piece)this.MemberwiseClone();

            // Create a new array for the squares and copy each Point to ensure a deep copy
            clone.squaresOfThePiece = new Point[this.squaresOfThePiece.Length];
            for (int i = 0; i < this.squaresOfThePiece.Length; i++)
            {
                clone.squaresOfThePiece[i] = this.squaresOfThePiece[i];
            }

            return clone;
        }

        /// <summary>
        /// Rotates the piece 90 degrees clockwise
        /// </summary>
        public virtual void Rotation90() { }

        /// <summary>
        /// Rotates the piece 180 degrees clockwise
        /// </summary>
        public virtual void Rotation180() { }

        /// <summary>
        /// Rotates the piece 270 degrees clockwise
        /// </summary>
        public virtual void Rotation270() { }

        /// <summary>
        /// Rotates the piece 360 degrees clockwise
        /// </summary>
        public virtual void Rotation360() { }

    }
}
