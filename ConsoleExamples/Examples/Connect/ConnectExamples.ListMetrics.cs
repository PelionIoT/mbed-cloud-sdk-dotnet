using System;
using System.Collections.Generic;
using MbedCloudSDK.Connect.Model.Metric;

namespace ConsoleExamples.Examples.Connect
{
    public partial class ConnectExamples
    {
        public List<Metric> ListLast30Days()
        {
            var options = new MetricQueryOptions()
            {
                Interval = "1d",
                Period = "30d"
            };
            var metrics = api.ListMetrics(options);
            foreach (var item in metrics)
            {
                Console.WriteLine(item);
            }
            return metrics;
        }

        public List<Metric> ListLast2Days()
        {
            var options = new MetricQueryOptions()
            {
                Interval = "3h",
                Period = "2d"
            };
            var metrics = api.ListMetrics(options);
            foreach (var item in metrics)
            {
                Console.WriteLine(item);
            }
            return metrics;
        }

        public List<Metric> ListMonth()
        {
            var options = new MetricQueryOptions()
            {
                Interval = "1d",
                Start = new DateTime(2017, 3, 1),
                End = new DateTime(2017, 4, 1)
            };
            var metrics = api.ListMetrics(options);
            foreach (var item in metrics)
            {
                Console.WriteLine(item);
            }
            return metrics;
        }
    }
}