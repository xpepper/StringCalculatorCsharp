using System;

namespace StringCalculatorKata
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var stringCalculator =
                new StringCalculator(new ConsoleLogger(), new ConsoleErrorNotifier());
            
            var stringCalculatorApp =
                new StringCalculatorApp(stringCalculator, new ConsoleResultPrinter(), new ConsoleLineReader());

            stringCalculatorApp.run();
        }
    }

    public class ConsoleLineReader : ILineReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }

    public interface ILineReader
    {
        string ReadLine();
    }

    public class ConsoleErrorNotifier : ILoggerErrorNotifier
    {
        public void Notify(string message) => Console.Error.WriteLine(message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Write(string text) => Console.Out.WriteLine("[logger] {0}", text);
    }
}