using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_M5.Piece
{
    internal class PieceI : Piece
    {
        /// <summary>
        /// Assigns the starting values for the piece
        /// </summary>
        public override void assignStartingValues()
        {
            // Axe Y
            squaresOfThePiece[0].Y = 0;
            squaresOfThePiece[1].Y = 0;
            squaresOfThePiece[2].Y = 0;
            squaresOfThePiece[3].Y = 0;

            // Axe X
            squaresOfThePiece[0].X = 3;
            squaresOfThePiece[1].X = 4;
            squaresOfThePiece[2].X = 5;
            squaresOfThePiece[3].X = 6;

            pieceColor = Color.Cyan;
            pieceTilt = 0;
        }

        /// <summary>
        /// Rotates the piece 90 degrees clockwise
        /// </summary>
        public override void rotation90()
        {
            //      actual          future
            //                         1
            //                         2 
            //     1 2 3 4             3 
            //  

            squaresOfThePiece[0].Y = squaresOfThePiece[0].Y - 2;
            squaresOfThePiece[0].X = squaresOfThePiece[0].X + 2;

            squaresOfThePiece[1].Y = squaresOfThePiece[1].Y - 1;
            squaresOfThePiece[1].X = squaresOfThePiece[1].X + 1;

            squaresOfThePiece[3].Y = squaresOfThePiece[3].Y + 1;
            squaresOfThePiece[3].X = squaresOfThePiece[3].X - 1;

            pieceTilt = 90;
        }
        


    }
}
