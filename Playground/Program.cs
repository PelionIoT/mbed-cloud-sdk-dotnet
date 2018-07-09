using System;
using MbedCloudSDK.Billing.Api;
using MbedCloudSDK.Common;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiKey = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_API_HOST");

            var config = new Config(apiKey, host);

            var billing = new BillingApi(config);

            
        }
    }
}
