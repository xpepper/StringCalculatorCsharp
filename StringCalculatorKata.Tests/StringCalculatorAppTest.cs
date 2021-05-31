using System;
using System.IO;
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

            var consoleLineReader = new Mock<ILineReader>();
            consoleLineReader.SetupSequence(console => console.ReadLine())
                .Returns("1,2,3")
                .Returns("");

            var stringCalculator =
                new StringCalculator(new DummyLog(), new DummyNotifier());
            var app = new StringCalculatorApp(stringCalculator, new ConsoleResultPrinter(), consoleLineReader.Object);

            app.run();

            Assert.Equal("The result is 6\n", consoleSpy.GetStringBuilder().ToString());
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

    public class StubLineReader : ILineReader
    {
        private readonly string _input;
        private readonly int _repeatTimes;
        private int _times = 0;

        public StubLineReader(string input, int repeatTimes)
        {
            _input = input;
            _repeatTimes = repeatTimes;
        }

        public string ReadLine()
        {
            if (_times < _repeatTimes)
            {
                _times++;
                return _input;
            }

            return "";
        }
    }
}