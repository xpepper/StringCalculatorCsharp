using System;

namespace StringCalculatorKata.Terminal
{
    public class ConsoleLogger : ILogger
    {
        public void Write(string text) => Console.Out.WriteLine("[logger] {0}", text);
    }
}