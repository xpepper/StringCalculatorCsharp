using System;
using System.IO;
using Moq;
using Newtonsoft.Json;
using StringCalculatorKata.Terminal;
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
            Console.SetIn(new StringReader("1,2,3\n"));

            var stringCalculator = new StringCalculator(new DummyLog(), new DummyNotifier());
            var app = new StringCalculatorApp(stringCalculator, new ConsoleResultPrinter(), new ConsoleLineReader());

            app.run();

            Assert.Equal("The result is 6\n" +
                         "another input please\n", consoleSpy.GetStringBuilder().ToString());
        }

        [Fact]
        public void Output_the_result_to_a_result_printer()
        {
            var resultPrinter = new Mock<IResultPrinter>();

            var app = new StringCalculatorApp(
                new StringCalculator(new DummyLog(), new DummyNotifier()),
                resultPrinter.Object, new StubLineReader("1,2,3", 1));
            app.run();

            resultPrinter.Verify(x => x.printResult(6));
        }
    }
}