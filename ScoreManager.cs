using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_M5
{
    public class ScoreManager
    {
        public int CurrentScore { get; private set; }
        public int Level { get; private set; }
        public int TotalLinesCleared { get; private set; }

        /// <summary>
        /// Constructor initializes the score and level.
        /// </summary>
        public ScoreManager()
        {
            Reset();
        }

        /// <summary>
        /// Resets the score and level for a new game.
        /// </summary>
        public void Reset()
        {
            CurrentScore = 0;
            Level = 1;
            TotalLinesCleared = 0;
        }

        /// <summary>
        /// Calculates the points earned based on the number of lines cleared and current level.
        /// </summary>
        /// <param name="linesCleared">Number of lines cleared at once (1 to 4).</param>
        public void AddLinesCompleted(int linesCleared)
        {
            if (linesCleared <= 0) return;

            TotalLinesCleared += linesCleared;

            // Classic Tetris scoring system
            int basePoints = 0;
            switch (linesCleared)
            {
                case 1: basePoints = 100; break;
                case 2: basePoints = 300; break;
                case 3: basePoints = 500; break;
                case 4: basePoints = 800; break; 
                default: basePoints = 1000; break;
            }

            // Multiply the base points by the current level to increase difficulty
            CurrentScore += basePoints * Level;

            // increase level every 5 lines cleared, up to a maximum of level 10
            Level = Math.Min(10, (TotalLinesCleared / 5) + 1);
        }
    }
}

