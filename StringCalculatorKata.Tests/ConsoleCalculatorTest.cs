using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace StringCalculatorKata.Tests
{
    
    public class ConsoleCalculatorTest
    {
        [Fact]
        public void LaunchCalculatorBy123Returns6()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);
            
            ConsoleCalculator.Program.Main(new string[] { "1,2,3" });

            Assert.Equal("The result is 6", sw.ToString());
        }
    }
}
