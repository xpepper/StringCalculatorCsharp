using System;

namespace StringCalculatorKata.Terminal
{
    public class ConsoleLogger : ILogger
    {
        public void Write(string text)
        {
            WithGreyColor(() => Console.Out.WriteLine("[logger] {0}", text));
        }

        private static void WithGreyColor(Action consoleAction)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;
            consoleAction.Invoke();
            Console.ForegroundColor = previousColor;
        }
    }
}