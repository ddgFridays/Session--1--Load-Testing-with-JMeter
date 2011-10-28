namespace JMeterLogParser
{
    public class Assertion
    {
        public string Name { get; set; }
        public bool Failure { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}