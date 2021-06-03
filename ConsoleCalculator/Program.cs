using StringCalculatorKata;
using System;

namespace ConsoleCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = new Logger();
            var webServ = new WebService();

            StringCalculator calc = new StringCalculator(logger, webServ);
            int result = calc.Add(args[0]);

            Console.Write($"The result is {result}");
        }


    }

    internal class WebService:IWebService
    {
        public WebService()
        {
        }

        public void Send(string exceptionMessage)
        {
           
        }
    }

    internal class Logger:ILogger
    {
        public Logger()
        {
        }

        public void Write(string logMessage)
        {
            
        }
    }
}
