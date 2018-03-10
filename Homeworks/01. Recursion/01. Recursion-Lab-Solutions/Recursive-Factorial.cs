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
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int result = Factorial(n);
            Console.WriteLine(result);
        }

        public static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            int result = n * Factorial(n - 1);
            return result;
        }
    }
}
