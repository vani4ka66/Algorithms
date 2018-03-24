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
            int k = int.Parse(Console.ReadLine());

            string[] arr = new string[k];
            Gen(input, arr, 0, 0);
        }

        public static void Gen(string[] input, string[] arr, int index, int border)
        {
            if (index > arr.Length - 1)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = border; i < input.Length; i++)
                {
                    arr[index] = input[i];
                    Gen(input, arr, index + 1, i + 1); 
                }
            }
           
        }
    }
}
