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
    }

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            return 0;
        }
    }
}