namespace StringCalculatorKata
{
    public class StringCalculatorApp
    {
        private readonly StringCalculator _stringCalculator;

        public StringCalculatorApp(StringCalculator stringCalculator)
        {
            _stringCalculator = stringCalculator;
        }

        public void run(string stringOfNumbers)
        {
            _stringCalculator.Add(stringOfNumbers);
        }
    }
}