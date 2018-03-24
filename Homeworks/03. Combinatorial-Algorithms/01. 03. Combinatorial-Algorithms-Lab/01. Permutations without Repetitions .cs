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
        private static HashSet<string> set = new HashSet<string>();

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            Gen(input, 0);
        }

        public static void Gen(string[] input, int index)
        {
            if (index >= input.Length)
            {
                Console.WriteLine(string.Join(" ", input));
            }
            else
            {
                Gen(input, index + 1);
                for (int i = index + 1; i < input.Length; i++)
                {
                    if (!set.Contains(input[i]))
                    {
                        Swap(input, index, i);
                        Gen(input, index + 1);
                        Swap(input, index, i);
                    }

                }
            }

        }

        private static void Swap(string[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
