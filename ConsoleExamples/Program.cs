using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mbedCloudSDK.Access;
using mbedCloudSDK.Common;
using mbedCloudSDK.Devices;

namespace ConsoleExamples
{
    class Program
    {
        static void Main(string[] args)
		{
			if (args == null || args.Length == 0)
            {
                Console.Error.WriteLine("API key is required!!!");
                Console.ReadKey();
                return;
            }
			string apiKey = args[0];
            Config config = new Config(apiKey);
            config.Host = "https://lab-api.mbedcloudintegration.net";
			runIAMExample(config);
            Console.ReadKey();
        }

        private static void runIAMExample(Config config)
        {
            Access access = new Access(config);
            var keys = access.ListApiKeys();
            foreach (var key in keys)
            {
                Console.WriteLine(key);
            }
        }

        private static void runEndpointsExample(Config config)
        {
            Devices devices = new Devices(config);
			foreach (var endpoint in devices.ListEndpoints())
            {
                Console.WriteLine(endpoint);
            }
        }

		private static void runDevicesExample(Config config)
		{
			Devices devices = new Devices(config);
			foreach (var device in devices.ListDevices())
			{
				Console.WriteLine(device.ToString());
			}
		}

		private static void runSubscriptionExample(Config config)
		{
			var buttonResource = "3200/0/5501";
			Devices devices = new Devices(config);
			var endpoints = devices.ListEndpoints();
			if (endpoints == null)
			{
				throw new Exception("No endpoints registered. Aborting.");
			}
			Console.WriteLine(endpoints);
			//devices.Subscribe(endpoints[0].Name, buttonResource);
			//var resources = devices.ListResources(endpoints[0].Name);
			devices.GetResource(endpoints[0].Name, buttonResource);
			while (true)
			{
				Thread.Sleep(1000);
			}
		}

    }
}
