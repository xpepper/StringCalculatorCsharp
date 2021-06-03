using FluentAssertions;
using Moq;
using System;
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
			var exception = Assert.Throws<Exception>(() => new StringCalculator(new DummyLogger()).Add(("-1,1,-4")));
			exception.Message.Should().Be("negatives not allowed: -1,-4");
		}

		[Fact]
		public void Ignore_numbers_greater_than_1000()
		{
			CheckAdd("1,2, 1000, 1001", 1003);
		}

		[Fact]
		public void Logging_add_results()
		{
			var logger = new Mock<ILogger>();
			StringCalculator sc = new StringCalculator(logger.Object);

			sc.Add("3,1");

			logger.Verify(l => l.Write("Add:3,1:4"), Times.Once);
		}

		private static void CheckAdd(string stringOfNumbers, int expectedSum)
		{
			ILogger dummyLogger = new DummyLogger();
			new StringCalculator(dummyLogger).Add(stringOfNumbers).Should().Be(expectedSum);
		}
	}

	internal class DummyLogger : ILogger
	{
		public void Write(string v)
		{
		}
	}
}