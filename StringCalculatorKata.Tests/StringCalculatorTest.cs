using System;
using System.Runtime.InteropServices;
using FluentAssertions;
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
        [InlineData("-42", -42)]
        public void Return_the_value_of_the_number_when_the_string_contains_just_that_number(string stringOfNumbers,
            int expectedSum)
        {
            CheckAdd(stringOfNumbers, expectedSum);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("-1,1", 0)]
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
        [InlineData("//$\n-1$-2$-3$-4", -10)]
        [InlineData("//$$\n-1$$-2$$-3$$-4", -10)]
        public void Support_a_custom_delimiter_specified_in_a_prefix_section(string stringOfNumbers, int expectedSum)
        {
            CheckAdd(stringOfNumbers, expectedSum);
        }

        private static void CheckAdd(string stringOfNumbers, int expectedSum)
        {
            StringCalculator.Add(stringOfNumbers).Should().Be(expectedSum);
        }
    }
}