namespace StringCalculatorKata
{
    public static class StringCalculator
    {
        public static int Add(string stringOfNumbers)
        {
            if (stringOfNumbers.Equals(""))
                return 0;
            
            return int.Parse(stringOfNumbers);
        }
    }
}