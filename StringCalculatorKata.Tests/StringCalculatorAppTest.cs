using System;
using System.IO;
using System.Text;
using Xunit;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorAppTest
    {
        [Fact]
        public void Print_result_to_console_when_correctly_invoked()
        {
            var consoleSpy = new StringWriter();
            Console.SetOut(consoleSpy);

            var stringCalculator =
                new StringCalculator(new DummyLog(), new DummyNotifier(), new ConsoleResultPrinter());
            var app = new StringCalculatorApp(stringCalculator);

            app.run("1,2,3");

            Assert.Equal("The result is 6\n", consoleSpy.GetStringBuilder().ToString());
        }
    }

    public class StringCalculatorApp
    {
        private readonly StringCalculator _stringCalculator;

        public StringCalculatorApp(StringCalculator stringCalculator)
        {
            _stringCalculator = stringCalculator;
        }

        public void run(string stringOfNumbers)
        {
            _stringCalculator.Add(stringOfNumbers);
        }
    }

    public class ConsoleResultPrinter : IResultPrinter
    {
        public void printResult(int result)
        {
            Console.WriteLine("The result is {0}", result);
        }
    }
}