namespace StringCalculatorKata.Tests
{
    public class StubLineReader : ILineReader
    {
        private readonly string _input;
        private readonly int _repeatTimes;
        private int _times = 0;

        public StubLineReader(string input, int repeatTimes)
        {
            _input = input;
            _repeatTimes = repeatTimes;
        }

        public string ReadLine()
        {
            if (_times < _repeatTimes)
            {
                _times++;
                return _input;
            }

            return "";
        }
    }
}