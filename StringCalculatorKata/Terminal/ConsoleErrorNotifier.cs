namespace StringCalculatorKata.Terminal
{
    public class ConsoleErrorNotifier : ILoggerErrorNotifier
    {
        public void Notify(string message) => System.Console.Error.WriteLine(message);
    }
}