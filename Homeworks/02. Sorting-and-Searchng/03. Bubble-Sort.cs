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
        static void Main(string[] args)
        {
            int[] collection = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int index = 0; index < collection.Length; index++)
            {
                int min = index;
                for (int curr = index + 1; curr < collection.Length; curr++)
                {
                    if (collection[curr].CompareTo(collection[min]) < 0)
                    {
                        min = curr;
                    }
                }
                Swap(collection, index, min);
            }

            Console.WriteLine(string.Join(" ", collection));
        }

        private static void Swap<T>(T[] arr, int start, int end)
        {
            T temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
        }

    }

   
}
