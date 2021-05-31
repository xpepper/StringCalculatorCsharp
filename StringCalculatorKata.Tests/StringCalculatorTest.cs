using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorTest
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData(null, 0)]
        [InlineData("   ", 0)]
        public void Return_0_when_the_string_is_empty(string stringOfNumbers, int expectedSum)
        {
            CheckAdd(stringOfNumbers, expectedSum);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("42", 42)]
        public void Return_the_value_of_the_number_when_the_string_contains_just_that_number(string stringOfNumbers,
            int expectedSum)
        {
            CheckAdd(stringOfNumbers, expectedSum);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("1,1", 2)]
        [InlineData("42,2", 44)]
        public void Return_the_sum_of_the_two_comma_separated_numbers_in_the_string(string stringOfNumbers,
            int expectedSum)
        {
            CheckAdd(stringOfNumbers, expectedSum);
        }

        [Fact]
        public void Handle_an_unknown_amount_of_numbers()
        {
            CheckAdd("1,2,3", 6);
        }

        [Fact]
        public void Handle_new_lines_between_numbers_instead_of_commas()
        {
            CheckAdd("1\n2,3", 6);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//|\n1|2|3", 6)]
        [InlineData("//$\n1$2$3$4", 10)]
        [InlineData("//$$\n1$$2$$3$$4", 10)]
        public void Support_a_custom_delimiter_specified_in_a_prefix_section(string stringOfNumbers, int expectedSum)
        {
            CheckAdd(stringOfNumbers, expectedSum);
        }

        [Fact]
        public void Negative_numbers_are_not_allowed()
        {
            var exception = Assert.Throws<Exception>(() => new StringCalculator(new DummyLog(), new DummyNotifier(), new DummyResultPrinter()).Add(("-1,1,-4")));
            exception.Message.Should().Be("negatives not allowed: -1,-4");
        }

        [Fact]
        public void Ignore_numbers_greater_than_1000()
        {
            CheckAdd("1,2, 1000, 1001", 1003);
        }

        [Fact]
        public void Log_add_result()
        {
            var logger = new Mock<ILogger>();
            new StringCalculator(logger.Object, null, new DummyResultPrinter()).Add("1,2");

            logger.Verify(l => l.Write("Add result is 3"));
        }

        [Fact]
        public void Notify_service_when_logging_fails()
        {
            var logger = new Mock<ILogger>();
            var loggerErrorNotifier = new Mock<ILoggerErrorNotifier>();

            logger
                .Setup(x => x.Write(It.IsAny<string>()))
                .Throws(new Exception("an error message"));

            new StringCalculator(logger.Object, loggerErrorNotifier.Object, new DummyResultPrinter()).Add("1,2");

            loggerErrorNotifier.Verify(l => l.Notify("an error message"));
        }

        [Fact]
        public void Output_the_result_to_a_result_printer()
        {
            var logger = new Mock<ILogger>();
            var resultPrinter = new Mock<IResultPrinter>();
            
            new StringCalculator(logger.Object, null, resultPrinter.Object).Add("1,2,3");
            
            resultPrinter.Verify(x => x.printResult(6));
        }

        private static void CheckAdd(string stringOfNumbers, int expectedSum)
        {
            new StringCalculator(new DummyLog(), new DummyNotifier(), new DummyResultPrinter()).Add(stringOfNumbers).Should().Be(expectedSum);
        }
    }

    public class DummyResultPrinter : IResultPrinter
    {
        public void printResult(int result)
        {
        }
    }
}