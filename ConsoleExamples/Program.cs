using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mbed_cloud_sdk;
using mbed_cloud_sdk.Access;
using mbed_cloud_sdk.Devices;

namespace ConsoleExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add Api key
            string apiKey = "";
            if (apiKey == string.Empty)
            {
                Console.Error.WriteLine("API key is required!!!");
                Console.ReadKey();
                return;
            }
            Config config = new Config(apiKey);
            config.Host = "https://lab-api.mbedcloudintegration.net";
            runEndpointsExample(config);
            Console.ReadKey();
        }

        private static void runIAMExample(Config config)
        {
            Accounts accounts = new Accounts(config);
            var keys = accounts.ListApiKeys();
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }
        }

        private static void runEndpointsExample(Config config)
        {
            Connector connector = new Connector(config);
            foreach (var endpoint in connector.listEndpoints())
            {
                Console.WriteLine(endpoint);
            }
        }
    }
}
