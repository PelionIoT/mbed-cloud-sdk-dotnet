using System;
using System.Text;
using mbedCloudSDK.Common;

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
            string example;
            Examples examples = new Examples(config);
            while(true)
            {
                example = ShowMenu();
                int exampleNumber = 0;
                if (Int32.TryParse(example, out exampleNumber) && exampleNumber >=1 && exampleNumber<=6)
                    RunExample(examples, Convert.ToInt32(exampleNumber));
                else
                    break;
            }
            Console.WriteLine(" Closing application");
        }

        private static string ShowMenu()
        {
            Console.WriteLine("Select Example");
            Console.WriteLine("1. List api keys");
            Console.WriteLine("2. List Devices");
            Console.WriteLine("3. List Endpoints");
            Console.WriteLine("4. Subscribe to the resource");
            Console.WriteLine("5. Create a webhook for a resource");
            Console.WriteLine("6. Run device query");
            Console.WriteLine("---Press any other key to exit---");
            Console.WriteLine();
            return Console.ReadLine();
        }
        
        private static void RunExample(Examples examples, int example)
        {
            switch (example)
            {
                case 1:
                    examples.runIAMExample();    
                    break;
                case 2:
                    examples.runDevicesExample();    
                    break;
                case 3:
                    examples.runEndpointsExample();    
                    break;
                case 4:
                    examples.runSubscriptionExample();    
                    break;
                case 5:
                    examples.runWebhookExample();    
                    break;
                case 6:
                    examples.runDeviceQueryExample();    
                    break;
            }
        }
    }
}
