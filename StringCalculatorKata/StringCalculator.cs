namespace StringCalculatorKata
{
    public static class StringCalculator
    {
        public static int Add(string stringOfNumbers)
        {
            if (stringOfNumbers.IsEmpty())
                return 0;
            
            return int.Parse(stringOfNumbers);
        }

        private static bool IsEmpty(this string aString)
        {
            return aString.Equals("");
        }
    }
}