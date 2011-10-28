using System.Collections.Generic;

namespace JMeterLogParser
{
    public class Visit
    {
        public string ThreadName { get; set; }
        public List<Response> Responses { get; set; } 
    }
}