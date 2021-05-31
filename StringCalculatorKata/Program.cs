using System;

namespace StringCalculatorKata
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var stringCalculator =
                new StringCalculator(new ConsoleLogger(), new ConsoleErrorNotifier(), new ConsoleResultPrinter());
            var stringCalculatorApp = new StringCalculatorApp(stringCalculator);

            stringCalculatorApp.run(args[0]);
        }
    }

    public class ConsoleErrorNotifier : ILoggerErrorNotifier
    {
        public void Notify(string message)
        {
            Console.Error.WriteLine(message);
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Write(string text)
        {
            Console.Out.WriteLine(text);
        }
    }
}