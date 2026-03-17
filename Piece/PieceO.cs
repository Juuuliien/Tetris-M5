using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_M5.Pieces
{
    internal class PieceO : Piece
    {
        /// <summary>
        /// Constructor for the piece class and assigns the starting values for the piece
        /// </summary>
        public PieceO()
        {
            // Set the color
            pieceColor = Color.Gold;            

            // Axe Y
            squaresOfThePiece[0].Y = 0;
            squaresOfThePiece[1].Y = 0;
            squaresOfThePiece[2].Y = 1;
            squaresOfThePiece[3].Y = 1;

            // Axe X
            squaresOfThePiece[0].X = 4;
            squaresOfThePiece[1].X = 5;
            squaresOfThePiece[2].X = 4;
            squaresOfThePiece[3].X = 5;            
        }
    }
}
