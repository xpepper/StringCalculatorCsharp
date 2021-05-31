using System;

namespace StringCalculatorKata
{
    public class ConsoleResultPrinter : IResultPrinter
    {
        public void printResult(int result)
        {
            Console.WriteLine("The result is {0}", result);
        }
    }
}