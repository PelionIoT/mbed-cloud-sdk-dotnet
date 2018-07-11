using System;
using MbedCloudSDK.Billing.Api;
using MbedCloudSDK.Common;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiKey = Environment.GetEnvironmentVariable("MBED_CLOUD_SDK_API_KEY");
            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_SDK_HOST");

            var config = new Config();

            var billing = new BillingApi(config);
        }
    }
}
