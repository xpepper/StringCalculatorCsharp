using System;
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

        [Fact]
        public void Return_the_value_of_the_number_when_the_string_contains_just_that_number()
        {
            CheckAdd("1", 1);
            CheckAdd("2", 2);
        }

        private static void CheckAdd(string stringOfNumbers, int expectedSum)
        {
            StringCalculator.Add(stringOfNumbers).Should().Be(expectedSum);
        }
    }
}