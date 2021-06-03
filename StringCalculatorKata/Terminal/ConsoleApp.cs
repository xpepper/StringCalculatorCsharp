using StringCalculatorKata.Terminal;

namespace StringCalculatorKata
{
    public static class Program
    {
        public static void Main()
        {
            var stringCalculator = new StringCalculator(
                new ConsoleLogger(),
                new ConsoleErrorNotifier()
            );

            var stringCalculatorApp = new StringCalculatorApp(
                stringCalculator,
                new ConsoleResultPrinter(),
                new ConsoleLineReader()
            );

            stringCalculatorApp.run();
        }
    }
}