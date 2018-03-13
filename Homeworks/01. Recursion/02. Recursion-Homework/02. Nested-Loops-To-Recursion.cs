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
            int k = int.Parse(Console.ReadLine());

            int[] arr = new int[k];

            GenCombs(arr, 0);
        }

        public static void GenCombs(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = 1; i <= arr.Length; i++)
                {
                    arr[index] = i;
                    GenCombs(arr, index + 1);
                }
            }
        }
    }
}
