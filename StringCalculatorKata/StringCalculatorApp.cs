namespace StringCalculatorKata
{
    public class StringCalculatorApp
    {
        private readonly StringCalculator _stringCalculator;
        private readonly IResultPrinter _resultPrinter;

        public StringCalculatorApp(StringCalculator stringCalculator, IResultPrinter resultPrinter)
        {
            _stringCalculator = stringCalculator;
            _resultPrinter = resultPrinter;
        }

        public void run(string stringOfNumbers)
        {
            var sum = _stringCalculator.Add(stringOfNumbers);
            _resultPrinter.printResult(sum);
        }
    }
}