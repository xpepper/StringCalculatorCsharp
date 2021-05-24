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

            if (stringOfNumbers.StartsWith("//"))
            {
                var delimiter = stringOfNumbers.Substring(2, 1);
                stringOfNumbers = stringOfNumbers.Substring(4);
                
                return stringOfNumbers
                    .Split(delimiter)
                    .Select(int.Parse)
                    .Sum();
            }

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