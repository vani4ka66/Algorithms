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
        private static int count;
        private static char[] symbols;
        private static HashSet<int> hash = new HashSet<int>();


        static void Main(string[] args)
        {
             symbols = Console.ReadLine().ToCharArray();

            bool areAllElementsUniqe = Optimisation();

            if (areAllElementsUniqe)
            {
                count = Factorial(symbols.Length);
            }
            else
            {
                GeneratePermutations(0);
            }
            Console.WriteLine(count);

        }

        private static int Factorial(int n)
        {
            if (n < 2)
            {
                return 1;
            }

            return n * (Factorial(n-1));
        }

        private static bool Optimisation()
        {

            for (int i = 0; i < symbols.Length; i++)
            {
                hash.Add(symbols[i]);
            }

            if (hash.Count == symbols.Length)
            {
                return true;
            }
            return false;
        }

        private static void GeneratePermutations(int index)
        {
            if (index ==  symbols.Length)
            {
                bool isValid = true;
                for (int i = 0; i < symbols.Length - 1; i++)
                {
                    if (symbols[i] == symbols[i+1])
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    count++;
                }
                return;
            }

            var swapped = new HashSet<char>();

            for (int i = index; i < symbols.Length; i++)
            {
                if (!swapped.Contains(symbols[i]))
                {
                    char current = symbols[index];
                    symbols[index] = symbols[i];
                    symbols[i] = current;

                    GeneratePermutations(index + 1);

                    swapped.Add(symbols[index]);
                    symbols[i] = symbols[index];
                    symbols[index] = current;
                }
            }
        }
    }
}
