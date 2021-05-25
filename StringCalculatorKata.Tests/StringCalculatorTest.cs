using System;
using FluentAssertions;
using Xunit;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorTest
    {
        [Fact]
        public void Return_0_when_the_input_string_is_empty()
        {
            new StringCalculator().Add("").Should().Be(0);
        }

        [Fact]
        public void Return_number_value_when_the_input_string_contains_one_number()
        {
            new StringCalculator().Add("3").Should().Be(3);
            new StringCalculator().Add("1").Should().Be(1);
            new StringCalculator().Add("42").Should().Be(42);
        }
    }

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers.Length == 0)
                return 0;
            return int.Parse(numbers);
        }
    }
}