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

            InsertionSort.Sort(collection);

            Console.WriteLine(string.Join(" ", collection));
        }

    }

    public class InsertionSort
    {
        public static void Sort<T>(T[] arr)
       where T : IComparable
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = i;

                for (int k = i + 1; k < arr.Length; k++)
                {
                    if (IsLess(arr[k], arr[min]))
                    {
                        min = k;
                    }

                }

                Swap(arr, min, i);
            }
        }
        public static void Swap<T>(T[] arr, int start, int end)
        {
            T temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
        }

        public static bool IsLess(IComparable first, IComparable second)
        {
            return first.CompareTo(second) < 0;
        }
    }

}
