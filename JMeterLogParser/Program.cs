using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using HtmlTags;

namespace JMeterLogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var arguments = new Arguments(args);
            var input = arguments["input"];
            var output = arguments["output"];

            var results = File.ReadAllText(input);
            var visits = ParseVisits(results);

            var failureTag = CreateFailureTag(visits);
            var statsTag = CreateStatsTag(visits);

            var html = new HtmlTag("html")
                .Append(new HtmlTag("head")
                            .Append(new HtmlTag("title").Text("JMeter Load Test Report")))
                .Append(new HtmlTag("body")
                            .Append(new HtmlTag("h1").Text("JMeter Load Test Report - " + DateTime.Now.ToString()))
                            .Append(failureTag)
                            .Append(statsTag));

            File.WriteAllText(output, html.ToHtmlString());
        }

        public static List<Visit> ParseVisits(string results)
        {
            return XDocument.Parse(results)
                .Element("testResults")
                .Elements("httpSample")
                .GroupBy(element => element.Attribute("tn").Value)
                .Select(thread => new Visit
                {
                    ThreadName = thread.Key,
                    Responses = thread.Select(response => new Response
                    {
                        ElapsedTime = TimeSpan.FromMilliseconds(double.Parse(response.Attribute("t").Value)),
                        Latency = TimeSpan.FromMilliseconds(double.Parse(response.Attribute("lt").Value)),
                        Success = bool.Parse(response.Attribute("s").Value),
                        Label = response.Attribute("lb").Value,
                        ResponseCode = response.Attribute("s").Value,
                        ResponseMessage = response.Attribute("s").Value,
                        ThreadName = response.Attribute("tn").Value,
                        Bytes = int.Parse(response.Attribute("by").Value),
                        Url = response.Element("java.net.URL").Value,
                        Assertions = response.Elements("assertionResult").Select(assertion => new Assertion
                        {
                            Name = assertion.Element("name").Value,
                            Failure = bool.Parse(assertion.Element("failure").Value),
                            Error = bool.Parse(assertion.Element("error").Value),
                            Message = assertion.Elements("failureMessage").Any() ? assertion.Element("failureMessage").Value : string.Empty
                        }).ToList()
                    }).ToList()
                }).ToList();
        }

        private static HtmlTag CreateFailureTag(IEnumerable<Visit> visits)
        {
            var failureTag = new HtmlTag("h2").Text("Failures");

            var failures = visits
                .SelectMany(visit => visit.Responses)
                .Where(
                    response => !response.Success || response.Assertions.Any(assertion => assertion.Error || assertion.Failure))
                .ToList();

            if (failures.Any())
                failureTag.Append("ol")
                    .Append(failures.Select(failure => new HtmlTag("li").Text(failure.ToString())));
            else
                failureTag.Append(new HtmlTag("p").Text("no failures"));

            return failureTag;
        }

        private static HtmlTag CreateStatsTag(IEnumerable<Visit> visits)
        {
            var statsTag = new HtmlTag("h2").Text("Stats").Append("ul");
            var stats = visits
                .SelectMany(visit => visit.Responses)
                .GroupBy(response => response.Label)
                .OrderBy(group => group.Key)
                .Select(group => new
                                     {
                                         Label = group.Key,
                                         AverageTime = group.Average(g => g.ElapsedTime.TotalMilliseconds),
                                         AverageLatency = group.Average(g => g.Latency.TotalMilliseconds),
                                         AverageBytes = group.Average(g => g.Bytes)
                                     })
                .Select(stat => new HtmlTag("li").Text(
                    string.Format(
                        "{0}: Average Time: {1}ms, Average Latency: {2}ms, Average Bytes: {3}",
                        stat.Label, stat.AverageTime, stat.AverageLatency, stat.AverageBytes)));

            return statsTag.Append(stats);
        }
    }
}