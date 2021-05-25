using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static System.String;

namespace StringCalculatorKata
{
    public static class StringCalculator
    {
        public static int Add(string inputString)
        {
            if (inputString == Empty)
                return 0;

            if (inputString.Contains(","))
            {
                return inputString
                    .Split(",")
                    .Sum(int.Parse);
            }

            return int.Parse(inputString);
        }
    }
}