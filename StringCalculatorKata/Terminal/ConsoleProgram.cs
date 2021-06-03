
namespace StringCalculatorKata.Terminal
{
    public static class ConsoleProgram
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