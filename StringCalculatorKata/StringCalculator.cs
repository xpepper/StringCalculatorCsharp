using System;
using System.Linq;

namespace StringCalculatorKata
{
    public static class StringCalculator
    {
        private static readonly string[] Separators = {",", "\n"};

        public static int Add(string stringOfNumbers)
        {
            if (stringOfNumbers.IsEmpty())
                return 0;

            if (stringOfNumbers.StartsWith("//"))
            {
                var strings = stringOfNumbers.Split('\n', 2);

                var delimiter = strings[0].Substring(2);
                stringOfNumbers = strings[1];

                return Sum(stringOfNumbers, new[] {delimiter});
            }

            return Sum(stringOfNumbers, Separators);
        }

        private static int Sum(string stringOfNumbers, string[] separators)
        {
            return stringOfNumbers
                .Split(separators, StringSplitOptions.None)
                .Select(int.Parse)
                .Sum();
        }

        private static bool IsEmpty(this string aString)
        {
            return string.IsNullOrWhiteSpace(aString);
        }
    }
}