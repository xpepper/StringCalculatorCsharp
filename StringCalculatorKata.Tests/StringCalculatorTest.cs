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
            StringCalculator.Add("").Should().Be(0);
        }

        [Fact]
        public void Return_the_value_of_the_number_when_the_string_contains_just_that_number()
        {
            StringCalculator.Add("1").Should().Be(1);
            StringCalculator.Add("2").Should().Be(2);
        }
    }
}