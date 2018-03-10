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

            int[] arr = new int[n];
            Gen01(0, arr);
        }

        public static void Gen01(int index, int[] arr)
        {
            if (index >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    arr[index] = i;
                    Gen01(index + 1, arr);
                }
            }
        }

        private static void Print(int[] arr)
        {
            foreach (var i in arr)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
    }
}
