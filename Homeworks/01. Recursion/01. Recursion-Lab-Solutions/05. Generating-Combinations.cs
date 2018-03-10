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
            int[] set = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());


            int[] arr = new int[k];

            GenCombs(set, arr, 0, 0);
        }

        public static void GenCombs(int[] set, int[] arr, int index, int border)
        {
            if (index > arr.Length - 1)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    arr[index] = set[i];
                    GenCombs(set, arr, index + 1, i + 1);
                }
            }
        }

    }
}
