namespace StringCalculatorKata
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers.Length == 0)
                return 0;
            return int.Parse(numbers);
        }
    }
}