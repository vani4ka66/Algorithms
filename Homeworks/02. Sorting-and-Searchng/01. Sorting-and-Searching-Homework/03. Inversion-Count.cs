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

            int n = Test.MergeSort(arr, arr.Length);
            Console.WriteLine(n);
        }
    }

    // inversion using merge sort

    public class Test
    {

        /* This method sorts the input array and returns the
           number of inversions in the array */

        public static int MergeSort(int[] arr, int arraySize)
        {
            int[] temp = new int[arraySize];
            return _mergeSort(arr, temp, 0, arraySize - 1);
        }

        /* An auxiliary recursive method that sorts the input array and
          returns the number of inversions in the array. */

        static int _mergeSort(int[] arr, int[] temp, int left, int right)
        {
            int mid, inv_count = 0;
            if (right > left)
            {
                mid = (right + left)/2;

                /* Inversion count will be sum of inversions in left-part, right-part
                  and number of inversions in merging */

                inv_count = _mergeSort(arr, temp, left, mid);
                inv_count += _mergeSort(arr, temp, mid + 1, right);

                /*Merge the two parts*/
                inv_count += merge(arr, temp, left, mid + 1, right);
            }
            return inv_count;
        }

        /* This method merges two sorted arrays and returns inversion count in
           the arrays.*/

        static int merge(int[] arr, int[] temp, int left, int mid, int right)
        {
            int i, j, k;
            int inv_count = 0;

            i = left; /* i is index for left subarray*/
            j = mid; /* j is index for right subarray*/
            k = left; /* k is index for resultant merged subarray*/
            while ((i <= mid - 1) && (j <= right))
            {
                if (arr[i] <= arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];

                    /* -- see above explanation/diagram for merge()*/
                    inv_count = inv_count + (mid - i);
                }
            }

            /* Copy the remaining elements of left subarray
             (if there are any) to temp*/
            while (i <= mid - 1)
                temp[k++] = arr[i++];

            /* Copy the remaining elements of right subarray
             (if there are any) to temp*/
            while (j <= right)
                temp[k++] = arr[j++];

            /*Copy back the merged elements to original array*/
            for (i = left; i <= right; i++)
                arr[i] = temp[i];

            return inv_count;
        }





    }
}
               
