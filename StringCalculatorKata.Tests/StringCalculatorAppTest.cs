using Moq;
using Xunit;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorAppTest
    {
        [Fact]
        public void Output_the_result_to_a_result_printer()
        {
            var resultPrinter = new Mock<IResultPrinter>();

            var app = new StringCalculatorApp(
                new StringCalculator(new DummyLog(), new DummyNotifier()),
                resultPrinter.Object, new StubLineReader("1,2,3", 1));
            app.run();

            resultPrinter.Verify(printer => printer.printResult(6));
        }
    }
}