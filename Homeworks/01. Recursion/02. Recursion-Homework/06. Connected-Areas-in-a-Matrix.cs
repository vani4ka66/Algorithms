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
        private static char Wall = '*';
        private static char Visited = 'v';
        private static List<Area> areas = new List<Area>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, m];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    FindConnectedArea(i, j, matrix);
                }
            }
            Console.WriteLine($"Total areas found: {areas.Count}");

            int count = 1;
            foreach (var area in areas.OrderByDescending(x=> x))
            {
                Console.WriteLine($"Area #{count} at ({area.row}, {area.col}), size: {area.size}");
                count++;

            }
        }

        private static void FindConnectedArea(int i, int j, char[,] matrix)
        {
            if (matrix[i, j] == Wall || matrix[i, j] == Visited)
            {
                return;
            }

            Area area = new Area(i, j);
            FillArea(i, j, matrix, area);
            areas.Add(area);
        }

        private static void FillArea(int row, int col, char[,] matrix, Area area)
        {
            if (!IsInBounds(matrix, row, col) || 
                matrix[row, col] == Visited ||
                matrix[row, col] == Wall)
            {
                return;
            }

            matrix[row, col] = Visited;
            area.size++;

            FillArea(row + 1, col, matrix, area);
            FillArea(row, col + 1, matrix, area);
            FillArea(row - 1, col, matrix, area);
            FillArea(row, col - 1, matrix, area);
        }

        private static bool IsInBounds(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        } 
    }

    public class Area : IComparable<Area>
    {
        public int row;
        public int col;
        public int size;

        public Area(int r, int c)
        {
            this.row = r;
            this.col = c;
            this.size = 0;
        }

        public int CompareTo(Area other)
        {
            int compare = this.size.CompareTo(other.size);

            if (compare == 0)
            {
                compare = other.row.CompareTo(this.row);
            }
            if (compare == 0)
            {
                compare = other.col.CompareTo(this.col);
            }
            return compare;
        }
    }
}
