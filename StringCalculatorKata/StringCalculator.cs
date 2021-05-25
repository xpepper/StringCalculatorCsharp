using System;
using static System.String;

namespace StringCalculatorKata
{
    public static class StringCalculator
    {
        public static int Add(string inputString)
        {
            if (inputString == Empty)
                return 0;

            if (inputString.Contains(","))
            {
                var numbers = inputString.Split(",");
                return int.Parse(numbers[0]) + int.Parse(numbers[1]);
            }

            return int.Parse(inputString);
        }
    }
}