using System;
using System.Text;
using mbedCloudSDK.Common;
using mbedCloudSDK.Access.Model.ApiKey;
using mbedCloudSDK.Access.Api;
using mbedCloudSDK.Access.Model.User;

namespace ConsoleExamples
{
    class Program
    {
        [STAThread]
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
            config.Host = "https://api.mbedcloud.com";

            //config.Host = "https://lab-api.mbedcloudintegration.net";
            string example;
            Examples examples = new Examples(config);
            while(true)
            {
                example = ShowMenu();
                int exampleNumber = 0;
                if (Int32.TryParse(example, out exampleNumber) && exampleNumber >=1 && exampleNumber<=14)
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
            Console.WriteLine("7. Run async example");
            Console.WriteLine("8. Run device logs example");
            Console.WriteLine("9. Run update campaign example");
            Console.WriteLine("10. List firmware images");
            Console.WriteLine("11. List firmware manifests");
            Console.WriteLine("12. Run update campaign example");
            Console.WriteLine("13. Get resource value example");
            Console.WriteLine("14. Set resource value example");
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
                case 7:
                    examples.runAsyncExample();
                    break;
                case 8:
                    examples.runLogsExample();
                    break;
                case 9:
                    examples.runListUpdateCampaignsExample();
                    break;
                case 10:
                    examples.runListFirmwareImagesExample();
                    break;
                case 11:
                    examples.runListFirmwareManifestsExample();
                    break;
                case 12:
                    examples.runUpdateCampaignExample();
                    break;
                case 13:
                    examples.runGetValueExample();
                    break;
                case 14:
                    examples.runSetValueExample();
                    break;
            }
        }
    }
}
