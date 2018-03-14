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
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int x = int.Parse(Console.ReadLine());

            int searchedNumber = BinarySearch(arr, x, 0, arr.Length - 1);

            Console.WriteLine(searchedNumber);

        }

        private static int BinarySearch(int[] arr, int x, int lo, int hi)
        {
            if (lo > hi)
            {
                return -1;
            }

            int mid =(hi + lo)/2;

            if (arr[mid] == x)
            {
                return mid;
            }

            if (arr[mid] > x)
            {
                return BinarySearch(arr, x, lo, mid);
            }
            else
            {
                return BinarySearch(arr, x, mid + 1, hi);

            }
        }
    }
}
