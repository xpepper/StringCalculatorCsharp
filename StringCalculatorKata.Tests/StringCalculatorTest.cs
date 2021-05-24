using System;
using System.Runtime.InteropServices;
using FluentAssertions;
using Xunit;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorTest
    {
        [Fact]
        public void Return_0_when_the_string_is_empty()
        {
            CheckAdd("", 0);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("42", 42)]
        [InlineData("-42", -42)]
        public void Return_the_value_of_the_number_when_the_string_contains_just_that_number(string stringOfNumbers, int expectedSum)
        {
            CheckAdd(stringOfNumbers, expectedSum);
        }

        private static void CheckAdd(string stringOfNumbers, int expectedSum)
        {
            StringCalculator.Add(stringOfNumbers).Should().Be(expectedSum);
        }
    }
}