using System;
using System.Collections.Generic;
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

        private static int Sum(string stringOfNumbers, string[] separators)
        {
            var numbers = ParseNumbers(stringOfNumbers, separators);

            if (numbers.HasNegatives())
                throw new Exception(BuildErrorMessageFor(numbers));

            return numbers.Where(LowerOrEqualTo1000).Sum();
        }

        private static string ExtractStringOfNumbersFrom(string inputString)
        {
            return inputString.Split('\n', 2)[1];
        }

        private static string ExtractCustomDelimiterFrom(string stringOfNumbers)
        {
            return stringOfNumbers.Split('\n', 2)[0].Substring(2);
        }

        private static string BuildErrorMessageFor(List<int> numbers)
        {
            var negativeNumbers = numbers.FindAll(IsNegative());
            var errorMessage = "negatives not allowed: " + string.Join(',', negativeNumbers);
            return errorMessage;
        }

        private static List<int> ParseNumbers(string stringOfNumbers, string[] separators)
        {
            return stringOfNumbers
                .Split(separators, StringSplitOptions.None)
                .Select(int.Parse).ToList();
        }

        private static bool HasCustomDelimiter(this string stringOfNumbers) => stringOfNumbers.StartsWith("//");

        private static bool HasNegatives(this List<int> numbers) => numbers.Exists(IsNegative());

        private static bool IsEmpty(this string aString) => string.IsNullOrWhiteSpace(aString);

        private static Predicate<int> IsNegative()
        {
            return number => number < 0;
        }

        private static bool LowerOrEqualTo1000(int number)
        {
            return number <= 1000;
        }
    }
}