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
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string result = Reverse(input, input.Length - 1);
            char[] final = result.ToCharArray();
            Console.WriteLine(final);
        }

        public static string Reverse(int[] arr, int index)
        {
            if (index == 0)
            {
                return arr[0].ToString();
            }
            string result = arr[index] + " " + Reverse(arr, index - 1);
            return result;
        }
    }
}

