using System;
using System.Linq;

namespace StringCalculatorKata
{
    public static class StringCalculator
    {
        public static int Add(string stringOfNumbers)
        {
            if (stringOfNumbers.IsEmpty())
                return 0;

            if (stringOfNumbers.Contains("\n"))
                stringOfNumbers = stringOfNumbers.Replace("\n", ",");

            return stringOfNumbers
                .Split(",")
                .Select(int.Parse)
                .Sum();
        }

        private static bool IsEmpty(this string aString)
        {
            return string.IsNullOrWhiteSpace(aString);
        }
    }
}