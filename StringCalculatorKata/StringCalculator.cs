using System;

namespace StringCalculatorKata
{
    public static class StringCalculator
    {
        public static int Add(string stringOfNumbers)
        {
            if (stringOfNumbers.IsEmpty())
                return 0;

            if (stringOfNumbers.Contains(","))
            {
                var numbers = stringOfNumbers.Split(",");
                return int.Parse(numbers[0]) + int.Parse(numbers[1]);
            }
            
            return int.Parse(stringOfNumbers);
        }

        private static bool IsEmpty(this string aString)
        {
            return string.IsNullOrWhiteSpace(aString);
        }
    }
}