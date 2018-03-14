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

            MergeSort<int>.Sort(collection);

            StringBuilder sb = new StringBuilder();

            foreach (var i in collection)
            {
                sb.Append(i + " ");
            }

            Console.WriteLine(sb);
        }

    }

    public class MergeSort<T> where T : IComparable
    {
        private static T[] aux;

        public static void Sort(T[] arr)
        {
            aux = new T[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(T[] arr, int lo, int hi)
        {
            if (lo >= hi)
            {
                return;
            }

            int mid = lo + (hi - lo)/2;
            Sort(arr, lo, mid);
            Sort(arr, mid + 1, hi);
            Merge(arr, lo, mid, hi);
        }

        private static void Merge(T[] arr, int lo, int mid, int hi)
        {
            if (IsLess(arr[mid], arr[mid + 1]))
            {
                return;
            }

            for (int m = lo; m <= hi; m++)
            {
                aux[m] = arr[m];
            }

            int i = lo;
            int j = mid + 1;

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    arr[k] = aux[j++];
                }
                else if (j > hi)
                {
                    arr[k] = aux[i++];
                }
                else if (IsLess(aux[i], aux[j]))
                {
                    arr[k] = aux[i++];
                }
                else
                {
                    arr[k] = aux[j++];
                }
            }
        }

        public static bool IsLess(IComparable first, IComparable second)
        {
            return first.CompareTo(second) < 0;
        }

        private static bool IsSorted(T[] arr, int lo, int hi)
        {
            for (int i = lo + 1; i < hi; i++)
            {
                if (IsLess(arr[i], arr[i - 1]))
                {
                    return false;
                }
            }
            return false;
        }
    }

}
