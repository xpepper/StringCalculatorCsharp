namespace StringCalculatorKata
{
    public class StringCalculatorApp
    {
        private readonly StringCalculator _stringCalculator;
        private readonly IResultPrinter _resultPrinter;
        private readonly ILineReader _lineReader;

        public StringCalculatorApp(StringCalculator stringCalculator, IResultPrinter resultPrinter,
            ILineReader lineReader)
        {
            _stringCalculator = stringCalculator;
            _resultPrinter = resultPrinter;
            _lineReader = lineReader;
        }

        public void run()
        {
            var line = _lineReader.ReadLine();
            while (! string.IsNullOrEmpty(line))
            {
                var sum = _stringCalculator.Add(line);
                _resultPrinter.printResult(sum);
                line = _lineReader.ReadLine();
            }
        }
}

}