using System;
using System.IO;
using StringCalculatorKata.Terminal;
using Xunit;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorAppAcceptanceTest
    {
        [Fact]
        public void Print_result_to_console_when_correctly_invoked()
        {
            var consoleSpy = new StringWriter();
            Console.SetOut(consoleSpy);
            Console.SetIn(new StringReader("1,2,3\n"));

            var stringCalculator = new StringCalculator(new DummyLog(), new DummyNotifier());
            var app = new StringCalculatorApp(stringCalculator, new ConsoleResultPrinter(),
                new ConsoleLineReader());

            app.run();

            Assert.Equal("The result is 6\n" +
                         "another input please\n", consoleSpy.GetStringBuilder().ToString());
        }
    }
}