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
            string[] elements = Console.ReadLine().Split().ToArray();
            int k = int.Parse(Console.ReadLine());

            string[] vector = new string[k];

            Gen(vector, elements, 0, 0);
        }

        public static void Gen(string[] vector, string[] elements, int index, int start)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = start; i < elements.Length; i++)
                {
                    vector[index] = elements[i];
                    Gen(vector, elements, index + 1, i);
                }
            }
              
          
        }
    }
}
