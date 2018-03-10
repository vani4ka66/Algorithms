using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static bool[,] matrix = new bool[8, 8];
        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedColumns = new HashSet<int>();
        static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        static HashSet<int> attackedRightDiagonals = new HashSet<int>();
        private static int solutionsFound = 0;

        static void Main(string[] args)
        {
            PutQueens(0);
            //Console.WriteLine(solutionsFound);
        }

        public static void PutQueens(int row)
        {
            if (row == 8)
            {
                Print();
            }
            else
            {
                for (int col = 0; col < 8; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttachedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttachedPositions(row, col);
                    }
                }
            }
        }

       

        private static bool CanPlaceQueen(int row, int col)
        {
            var positionOccured = attackedRows.Contains(row) ||
                                  attackedColumns.Contains(col) ||
                                  attackedLeftDiagonals.Contains(col - row) ||
                                  attackedRightDiagonals.Contains(row + col);

            return !positionOccured;
        }

        private static void MarkAllAttachedPositions(int row, int col)
        {
            attackedRows.Add(row);
            attackedColumns.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(row + col);
            matrix[row, col] = true;
        }

        private static void UnmarkAllAttachedPositions(int row, int col)
        {
            attackedRows.Remove(row);
            attackedColumns.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(row + col);
            matrix[row, col] = false;
        }

        private static void Print()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j > 0 && j < 8)
                    {
                        Console.Write(' ');
                    }
                    if (matrix[i, j])
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('-');

                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            solutionsFound++;
        }
    }
}
