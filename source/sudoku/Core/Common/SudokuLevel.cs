﻿using Sudoku.Core.Enums;
using Sudoku.Core.Interfaces.Sudoku;

namespace Sudoku.Core.Common
{
    public class SudokuLevel : ISudokuLevel
    {
        public ESudokuLevel Level { get; }

        public SudokuLevel(ESudokuLevel level)
        {
            Level = level;
        }

        public bool IsMatching(ISudokuResult result)
        {
            return GetLevel(result) == Level;
        }

        public bool IsMaxLimitExceeded(ISudokuResult result)
        {
            return GetLevelByBackTracks(result.BackTrackCount) > Level;
        }

        internal static ESudokuLevel GetLevel(ISudokuResult result)
        {
            return result.HasUniqueSolution ? 
                    GetLevelByBackTracks(result.BackTrackCount) : 
                    ESudokuLevel.None;
        }

        private static ESudokuLevel GetLevelByBackTracks(int backTrackCount)
        {
            var level = ESudokuLevel.None;

            if (backTrackCount >= 40 && backTrackCount < 150)
            {
                level = ESudokuLevel.Easy;
            }
            else if (backTrackCount >= 150 && backTrackCount < 500)
            {
                level = ESudokuLevel.Medium;
            }
            else if (backTrackCount >= 500 && backTrackCount < 1500)
            {
                level = ESudokuLevel.Hard;
            }
            else if (backTrackCount >= 1500 && backTrackCount < 2500)
            {
                level = ESudokuLevel.Samurai;
            }
            else if (backTrackCount >= 2500)
            {
                level = ESudokuLevel.Unbelievable;
            }
            return level;
        }
    }
}