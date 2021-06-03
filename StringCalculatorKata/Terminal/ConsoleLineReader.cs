using System;

namespace StringCalculatorKata.Terminal
{
    public class ConsoleLineReader : ILineReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}