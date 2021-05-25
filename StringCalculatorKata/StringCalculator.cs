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

            if (inputString.StartsWith("//"))
            {
                string delimiter = inputString.Substring(2, 1);
                string numbers = inputString.Substring(4);
                return numbers
                    .Split(delimiter)
                    .Sum(int.Parse);
            }

            return inputString
                .Split(',', '\n')
                .Sum(int.Parse);
        }
    }
}