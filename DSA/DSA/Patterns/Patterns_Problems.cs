using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.Patterns
{
    internal class Patterns_Problems
    {
        public static void PrintSquarePattern(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
        public static void PrintPyramidPattern(int n)
        {
            for (int i = 0; i < n; i++)
            {
                int space = n - i - 1;
                int stars = 2 * i + 1;

                for (int j = 0; j < space; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < stars; j++)
                {
                    Console.Write("*");
                }

                for (int j = 0; j < space; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }


    }
}
