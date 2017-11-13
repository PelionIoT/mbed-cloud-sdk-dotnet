using System;
using System.Text;
using MbedCloudSDK.Common;
using ConsoleExamples.Examples.AccountManagement;
using ConsoleExamples.Examples.Update;
using ConsoleExamples.Examples.Connect;
using ConsoleExamples.Examples.DeviceDirectory;
using System.Reflection;

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

            //Change default host
            config.Host = "https://lab-api.mbedcloudintegration.net";
            string example;
            while(true)
            {
                example = ShowMenu();
                int exampleNumber = 0;
                if (Int32.TryParse(example, out exampleNumber) && exampleNumber >=1 && exampleNumber<=15)
                    RunExampleAsync(config, Convert.ToInt32(exampleNumber));
                else
                    break;
            }
            Console.WriteLine(" Closing application");
        }

        private static string ShowMenu()
        {
            Console.WriteLine("Select Example");
            Console.WriteLine("1. List Api keys");
            Console.WriteLine("2. List Devices");
            Console.WriteLine("3. List Connected Devices");
            Console.WriteLine("4. Subscribe to the resource");
            Console.WriteLine("5. Create a webhook for a resource");
            Console.WriteLine("6. Run device query");
            Console.WriteLine("7. List Api keys asynchronously");
            Console.WriteLine("8. Run device logs example");
            Console.WriteLine("9. List update campaigns");
            Console.WriteLine("10. List firmware images");
            Console.WriteLine("11. List firmware manifests");
            Console.WriteLine("12. Run update campaign example");
            Console.WriteLine("13. Get resource value example");
            Console.WriteLine("14. Set resource value example");
            Console.WriteLine("15. Get account details");
            Console.WriteLine("---Press any other key to exit---");
            Console.WriteLine();
            return Console.ReadLine();
        }
        
        private static async void RunExampleAsync(Config config, int example)
        {
            switch (example)
            {
                case 1:
                    ListApiKeys lApiKeys = new ListApiKeys(config);
                    lApiKeys.GetApiKeys();
                    break;
                case 2:
                    ListDevices lDevices = new ListDevices(config);
                    lDevices.ListAllDevices();
                    break;
                case 3:
                    ListDevices lConnectedDevices = new ListDevices(config);
                    lConnectedDevices.ListConnectedDevices();
                    break;
                case 4:
                    Subscription sub = new Subscription(config);
                    sub.Subscribe();
                    break;
                case 5:
                    Webhook webhook = new Webhook(config);
                    webhook.RegisterWebhook();
                    break;
                case 6:
                    DeviceQuery query = new DeviceQuery(config);
                    query.AddQuery();
                    break;
                case 7:
                    ListApiKeys lAsyncApiKeys = new ListApiKeys(config);
                    await lAsyncApiKeys.ListApiKeysAsync();
                    break;
                case 8:
                    ListLogs lLogs = new ListLogs(config);
                    lLogs.ListDevicesLogs();
                    break;
                case 9:
                    ListUpdateCampaigns lUpdateCampaigns = new ListUpdateCampaigns(config);
                    lUpdateCampaigns.listCampaigns();
                    break;
                case 10:
                    ListFirmwareImages lImages = new ListFirmwareImages(config);
                    lImages.ListImages();
                    break;
                case 11:
                    ListFirmwareManifests lManifests = new ListFirmwareManifests(config);
                    lManifests.ListManifests();
                    break;
                case 12:
                    CreateUpdateCampaign cCampaign = new CreateUpdateCampaign(config);
                    cCampaign.CreateCampaign(true);
                    break;
                case 13:
                    Resource getRes = new Resource(config);
                    getRes.GetResourceValue();
                    break;
                case 14:
                    Resource setRes = new Resource(config);
                    setRes.SetResourceValue();
                    break;
                case 15:
                    GetAccount acc = new GetAccount(config);
                    acc.GetAccountDetails();
                    break;
            }
        }
    }
}
