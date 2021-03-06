﻿using System.Text;
using Sudoku.Core.Interfaces.Sudoku;

namespace Sudoku.Console
{
    public static class PrintHelper
    {
        public static string PrintMatrix(int[,] matrix)
        {
            var stringResult = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    stringResult.Append(matrix[i, j] == 0 ? "." : matrix[i, j].ToString());
                }
                stringResult.AppendLine();
            }
            return stringResult.ToString();
        }

        public static string PrintResult(ISudokuResult sudokuResult)
        {
            var stringResult = new StringBuilder();

            stringResult.Append(PrintMatrix(sudokuResult.Data));
            stringResult.AppendLine(PrintLevel(sudokuResult));

            return stringResult.ToString();
        }

        private static string PrintLevel(ISudokuResult result)
        {
            var resultString = new StringBuilder();
            resultString.AppendFormat(Resources.PrintHelper_PrintLevel_Level, (int)result.Level, result.Level);
            resultString.AppendLine();
            resultString.AppendFormat(Resources.PrintHelper_PrintLevel_Score, result.ComplexitiesScore);
            resultString.AppendLine();
            return resultString.ToString();
        }
    }
}
