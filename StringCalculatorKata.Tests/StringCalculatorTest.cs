using FluentAssertions;
using Xunit;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorTest
    {
        [Fact]
        public void Return_0_when_the_input_string_is_empty()
        {
            AssertInputSumsTo("", 0);
        }

        [Fact]
        public void Return_number_value_when_the_input_string_contains_one_number()
        {
            AssertInputSumsTo("1", 1);
            AssertInputSumsTo("3", 3);
            AssertInputSumsTo("42", 42);
        }

        [Fact]
        public void Return_the_sum_of_two_comma_separated_numbers()
        {
            AssertInputSumsTo("1,2", 3);
            AssertInputSumsTo("40,2", 42);
        }

        [Fact]
        public void Return_the_sum_of_any_amount_of_comma_separated_numbers()
        {
            AssertInputSumsTo("1,2,42,18", 63);
        }

        [Fact]
        public void Handle_new_lines_between_numbers_instead_of_commas()
        {
            AssertInputSumsTo("1\n2,3", 6);
        }

        [Fact]
        public void Support_a_custom_delimiter()
        {
            AssertInputSumsTo("//;\n1;2", 3);
        }

        private static void AssertInputSumsTo(string inputString, int expected)
        {
            StringCalculator.Add(inputString).Should().Be(expected);
        }
    }
}