using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		private static void runDevicesExample(Config config)
		{
			Devices devices = new Devices(config);
			foreach (var device in devices.ListDevices())
			{
				Console.WriteLine(device.ToString());
			}
		}

    }
}
