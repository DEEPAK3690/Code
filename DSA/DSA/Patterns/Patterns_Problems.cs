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
        public static void PrintInvertedPyramidPattern(int n)
        {
            for (int i = 0; i < n; i++)
            {
                int space = i;
                int stars = (2 * n) - (2 * i + 1);

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

        public static void PrintDiamondPattern(int n)
        {
            PrintPyramidPattern(n);
            PrintInvertedPyramidPattern(n);
        }

        public static void PrintHalfDiamondPattern(int n)
        {
            int rows = 9;
            int upperHalfRows = 5;
            for (int i = 1; i <= rows; i++)
            {
                int stars = i;

                if (i > upperHalfRows)
                    stars = 2 * upperHalfRows - i;

                for (int j = 1; j <= stars; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public static void PrintBinary_TrianglePattern(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                int start = 1;
                if (i % 2 == 0)
                    start = 0;
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(start + " ");
                    start = 1 - start;
                }
                Console.WriteLine();

            }
        }
    }
}
