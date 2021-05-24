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
    }

    public static class StringCalculator
    {
        public static int Add(string stringOfNumbers)
        {
            return 0;
        }
    }
}