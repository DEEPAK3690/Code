using DSA.Patterns;

namespace DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pattern_Enum pattern = Pattern_Enum.InvertedPyramid;
            switch (pattern)
            {
                case Pattern_Enum.square:
                    Patterns_Problems.PrintSquarePattern(5);
                    break;
                case Pattern_Enum.pyramid:
                    Patterns_Problems.PrintPyramidPattern(5);
                    break;
                case Pattern_Enum.InvertedPyramid:
                    Patterns_Problems.PrintInvertedPyramidPattern(5);
                    break;
                default:
                    break;
            }
        }
    }
}
