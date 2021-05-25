using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static System.String;

namespace StringCalculatorKata
{
    public static class StringCalculator
    {
        const string SEPARATOR = ",";

        public static int Add(string inputString)
        {
            if (inputString == Empty)
                return 0;

            return inputString
                .Split(SEPARATOR)
                .Sum(int.Parse);
        }
    }
}