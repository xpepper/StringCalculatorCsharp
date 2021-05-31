using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private readonly ILogger _logger;
        private readonly ILoggerErrorNotifier _loggerErrorNotifier;
        private readonly IResultPrinter _resultPrinter;
        private static readonly string[] Separators = {",", "\n"};

        public StringCalculator(ILogger logger, ILoggerErrorNotifier loggerErrorNotifier,
            IResultPrinter resultPrinter)
        {
            _logger = logger;
            _loggerErrorNotifier = loggerErrorNotifier;
            _resultPrinter = resultPrinter;
        }

        public int Add(string inputString)
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

        private int Sum(string stringOfNumbers, string[] separators)
        {
            var numbers = ParseNumbers(stringOfNumbers, separators);

            if (numbers.HasNegatives())
                throw new Exception(BuildErrorMessageFor(numbers));

            var sum = numbers.Where(LowerOrEqualTo1000).Sum();
            try
            {
                _logger.Write("Add result is " + sum);
            }
            catch (Exception e)
            {
                _loggerErrorNotifier.Notify(e.Message);
            }

            _resultPrinter.printResult(sum);
            
            return sum;
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
            return "negatives not allowed: " + string.Join(',', negativeNumbers);
        }

        private static List<int> ParseNumbers(string stringOfNumbers, string[] separators)
        {
            return stringOfNumbers
                .Split(separators, StringSplitOptions.None)
                .Select(int.Parse).ToList();
        }

        private static Predicate<int> IsNegative()
        {
            return number => number < 0;
        }

        private static bool LowerOrEqualTo1000(int number)
        {
            return number <= 1000;
        }
    }

    internal static class Extensions
    {
        internal static bool HasCustomDelimiter(this string stringOfNumbers) => stringOfNumbers.StartsWith("//");

        internal static bool HasNegatives(this List<int> numbers) => numbers.Exists(IsNegative);

        internal static bool IsEmpty(this string aString) => string.IsNullOrWhiteSpace(aString);

        private static bool IsNegative(this int number) => number < 0;
    }
}