using System;
using System.Linq;

namespace StringCalculatorKata
{
    public static class StringCalculator
    {
        private static readonly char[] Separators = {',', '\n'};

        public static int Add(string stringOfNumbers)
        {
            if (stringOfNumbers.IsEmpty())
                return 0;

            return stringOfNumbers
                .Split(Separators)
                .Select(int.Parse)
                .Sum();
        }

        private static bool IsEmpty(this string aString)
        {
            return string.IsNullOrWhiteSpace(aString);
        }
    }
}