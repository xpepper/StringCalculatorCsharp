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
            IResultPrinter resultPrinter = new ConsoleResultPrinter();
            var stringCalculator = new StringCalculator(new DummyLog(), new DummyNotifier(), resultPrinter);
            var app = new StringCalculatorApp(stringCalculator);

            app.run("1,2,3");

            Assert.Equal("The result is 6", consoleSpy.GetStringBuilder().ToString());
        }
    }

    public class StringCalculatorApp
    {
        public StringCalculatorApp(StringCalculator stringCalculator)
        {
            throw new System.NotImplementedException();
        }

        public void run(string s)
        {
            throw new System.NotImplementedException();
        }
    }

    public class ConsoleResultPrinter : IResultPrinter
    {
        public void printResult(int result)
        {
            throw new System.NotImplementedException();
        }
    }
}