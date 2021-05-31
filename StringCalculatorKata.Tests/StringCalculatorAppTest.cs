using System;
using System.IO;
using System.Text;
using Moq;
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
                new StringCalculator(new DummyLog(), new DummyNotifier());
            var app = new StringCalculatorApp(stringCalculator, new ConsoleResultPrinter());

            app.run("1,2,3");

            Assert.Equal("The result is 6\n", consoleSpy.GetStringBuilder().ToString());
        }

        [Fact]
        public void Output_the_result_to_a_result_printer()
        {
            var resultPrinter = new Mock<IResultPrinter>();

            var app = new StringCalculatorApp(
                new StringCalculator(new DummyLog(), new DummyNotifier()),
                resultPrinter.Object);
            app.run("1,2,3");

            resultPrinter.Verify(x => x.printResult(6));
        }
    }
}