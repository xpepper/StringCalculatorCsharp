using System;

namespace StringCalculatorKata.Terminal
{
    public class ConsoleResultPrinter : IResultPrinter
    {
        public void printResult(int result) => Console.WriteLine("The result is {0}\nanother input please", result);
    }
}