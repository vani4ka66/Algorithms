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
           int[] sorted = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            Shuffle.ShuffleS(sorted);

            Console.WriteLine(string.Join(", ", sorted));
        }

    }

    public static class Shuffle
    {
        public static void ShuffleS<T>(T[] arr)
        {
            Random random =  new Random();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int randomIndex = random.Next(i + 1, arr.Length);

                Swap(arr, i, randomIndex);
            }
        }

        private static void Swap<T>(T[] arr, int start, int end)
        {
            T temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
        }
    }

   
}
