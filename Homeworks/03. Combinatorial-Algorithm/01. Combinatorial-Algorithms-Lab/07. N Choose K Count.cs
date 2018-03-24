using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        private static long[,] matrix;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            matrix = new long[n + 1, k + 1];

            long m = Binom(n, k);
            Console.WriteLine(m);
        }

        public static long Binom(int n, int k)
        {
            if (matrix[n, k] != 0)
            {
                return matrix[n, k];
            }
            if (k > n)
            {
                return 0;
            }

            if (k == 0 || k == n)
            {
                return 1;
            }
            matrix[n, k] = Binom(n - 1, k - 1) + Binom(n - 1, k);
            return matrix[n, k];
        }
    }

}
