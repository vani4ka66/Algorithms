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
       static List<char> path = new List<char>();
        private static string[,] matrix;


        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            matrix = new string[row, col];


            for (int i = 0; i < row; i++)
            {
                string list = Console.ReadLine();
                int count = 0;

                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = list[count].ToString();
                    count++;
                }
            }
            //Console.WriteLine();
            //Print();
            FindPaths(0, 0, 'S');
        }
 
        private static void FindPaths(int row, int col, char direction)
        {
            if (!IsInBounds(row, col))
            {
                return;
            }
            if (direction != 'S')
            {
                path.Add(direction);
            }

            if (IsExit(row, col))
            {
                PrintPath();
            }
            else if (!IsVisited(row, col) && IsFree(row, col))
            {
                Mark(row, col);
                FindPaths(row, col + 1, 'R');
                FindPaths(row + 1, col, 'D');
                FindPaths(row, col - 1, 'L');
                FindPaths(row - 1, col, 'U');
                Unmark(row, col);
            }
            if (path.Count != 0)
            {
                path.RemoveAt(path.Count - 1);
            }
        }

        private static void Unmark(int row, int col)
        {
            matrix[row, col] = "-";

        }

        private static void Mark(int row, int col)
        {
            matrix[row, col] = "v";
        }

        private static bool IsFree(int row, int col)
        {
            if (matrix[row, col] == "*")
            {
                return false;
            }
            return true;
        }

        private static bool IsVisited(int row, int col)
        {
            if (matrix[row, col] == "v")
            {
                return true;
            }
            return false;
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("", path));
        }

        private static bool IsExit(int row, int col)
        {
            if (matrix[row, col] == "e")
            {
                return true;
            }
            return false;
        }

        private static bool IsInBounds(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1) &&
                   matrix[row , col] != "*";
        }

        private static void Print()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
