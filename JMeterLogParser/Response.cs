using System;
using System.Collections.Generic;
using System.Linq;

namespace JMeterLogParser
{
    public class Response
    {
        public TimeSpan ElapsedTime { get; set; }
        public TimeSpan Latency { get; set; }
        public bool Success { get; set; }
        public string Label { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ThreadName { get; set; }
        public int Bytes { get; set; }
        public string Url { get; set; }
        public List<Assertion> Assertions { get; set; }

        public override string ToString()
        {
            var value = string.Format(
                "{0}: {1}. Elapsed Time: {2}, Response: {3}.",
                Label, Url, ElapsedTime.TotalMilliseconds, ResponseCode);
            foreach(var assertion in Assertions.Where(a => a.Failure || a.Error))
            {
                value = value + " Assertion: " + assertion.Message;
            }
            return value;
        }
    }
}