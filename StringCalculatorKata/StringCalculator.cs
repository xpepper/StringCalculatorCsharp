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

            if (stringOfNumbers.Contains(","))
            {
                var numbers = stringOfNumbers.Split(",");
                return numbers.ToList().Select(int.Parse).Sum();
            }
            
            return int.Parse(stringOfNumbers);
        }

        private static bool IsEmpty(this string aString)
        {
            return string.IsNullOrWhiteSpace(aString);
        }
    }
}