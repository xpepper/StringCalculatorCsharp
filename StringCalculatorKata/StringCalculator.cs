using System;
using System.Linq;

namespace StringCalculatorKata
{
    public static class StringCalculator
    {
        private static readonly string[] Separators = {",", "\n"};

        public static int Add(string inputString)
        {
            if (inputString.IsEmpty())
                return 0;

            if (inputString.HasCustomDelimiter())
            {
                var delimiter = ExtractCustomDelimiterFrom(inputString);
                var stringOfNumbers = ExtractStringOfNumbersFrom(inputString);

                return Sum(stringOfNumbers, new[] {delimiter});
            }

            return Sum(inputString, Separators);
        }

        private static string ExtractStringOfNumbersFrom(string inputString)
        {
            return inputString.Split('\n', 2)[1];
        }

        private static string ExtractCustomDelimiterFrom(string stringOfNumbers)
        {
            return stringOfNumbers.Split('\n', 2)[0].Substring(2);
        }

        private static bool HasCustomDelimiter(this string stringOfNumbers)
        {
            return stringOfNumbers.StartsWith("//");
        }

        private static int Sum(string stringOfNumbers, string[] separators)
        {
            var numbers = stringOfNumbers
                .Split(separators, StringSplitOptions.None)
                .Select(int.Parse).ToList();

            if (numbers.Exists(n => n < 0))
                throw new Exception();

            return numbers.Sum();
        }

        private static bool IsEmpty(this string aString)
        {
            return string.IsNullOrWhiteSpace(aString);
        }
    }
}