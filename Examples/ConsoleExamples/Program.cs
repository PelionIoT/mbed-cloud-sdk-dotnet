using ConsoleExamples.Examples.AccountManagement;
using ConsoleExamples.Examples.Certificates;
using ConsoleExamples.Examples.Connect;
using ConsoleExamples.Examples.DeviceDirectory;
using ConsoleExamples.Examples.Subscribe;
using ConsoleExamples.Examples.Update;
using MbedCloudSDK.Common;
using System;

namespace ConsoleExamples
{
    class Program
    {
        private static AccountManagementExamples accountManagementExamples;
        private static CertificateExamples certificateExamples;
        private static ConnectExamples connectExamples;
        private static DeviceDirectoryExamples deviceDirectoryExamples;
        private static UpdateExamples updateExamples;
        private static SubscribeExamples subscribeExamples;

        public static void Main(string[] args)
        {
            var apiKey = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            if (string.IsNullOrEmpty(apiKey))
            {
                Console.Error.WriteLine("API key is required!!!");
                Console.ReadKey();
                return;
            }

            var host = Environment.GetEnvironmentVariable("MBED_CLOUD_API_HOST");
            if (string.IsNullOrEmpty(host))
            {
                host = "https://api.us-east-1.mbedcloud.com";
            }

            var config = new Config(apiKey: apiKey, host: host, forceClear: true, autostartNotifications: true);

            accountManagementExamples = new AccountManagementExamples(config);
            certificateExamples = new CertificateExamples(config);
            connectExamples = new ConnectExamples(config);
            deviceDirectoryExamples = new DeviceDirectoryExamples(config);
            updateExamples = new UpdateExamples(config);
            subscribeExamples = new SubscribeExamples(config);

            string example;
            while (true)
            {
                example = ShowMenu();
                if (int.TryParse(example, out int exampleNumber) && exampleNumber >= 1 && exampleNumber <= 400)
                {
                    RunExampleAsync(config, Convert.ToInt32(exampleNumber));
                }
                else
                {
                    break;
                }
            }

            connectExamples.api.StopNotifications();
            Console.WriteLine(" Closing application");
        }

        private static string ShowMenu()
        {
            var i = 1;
            Console.WriteLine("Select Example");
            Console.WriteLine("---Account management---");
            Console.WriteLine($"{i++}. Get account details");
            Console.WriteLine($"{i++}. Get account details async");
            Console.WriteLine($"{i++}. Update account details");
            Console.WriteLine($"{i++}. Update account details async");
            Console.WriteLine($"{i++}. List Api keys");
            Console.WriteLine($"{i++}. List Api keys asynchronously");
            Console.WriteLine($"{i++}. Get Api Key");
            Console.WriteLine($"{i++}. Get Api Key asynchronously");
            Console.WriteLine($"{i++}. Add Api key");
            Console.WriteLine($"{i++}. Add Api key async");
            Console.WriteLine($"{i++}. List Groups");
            Console.WriteLine($"{i++}. List Users");
            Console.WriteLine($"{i++}. Add User");
            Console.WriteLine($"{i++}. Add User async");
            Console.WriteLine("---Certificates---");
            Console.WriteLine($"{i++}. Create Certificate");
            Console.WriteLine($"{i++}. List Certificates");
            Console.WriteLine("---Connect---");
            Console.WriteLine($"{i++}. List Connected Devices");
            Console.WriteLine($"{i++}. List filtered connected devices");
            Console.WriteLine($"{i++}. List metrics from last 30 days");
            Console.WriteLine($"{i++}. List metrics from last 2 days in 3 hour intervals");
            Console.WriteLine($"{i++}. List metrics from 1 March 2017 to 1 April 2017");
            Console.WriteLine($"{i++}. Create presubscription");
            Console.WriteLine($"{i++}. Get resource value");
            Console.WriteLine($"{i++}. Set resource value example");
            Console.WriteLine($"{i++}. Subscribe to a resource");
            Console.WriteLine($"{i++}. Subscribe to a resource with a callback");
            Console.WriteLine($"{i++}. Create a webhook for a resource");
            Console.WriteLine("---Device Directory---");
            Console.WriteLine($"{i++}. Create Devices");
            Console.WriteLine($"{i++}. List Devices");
            Console.WriteLine($"{i++}. Add device query");
            Console.WriteLine($"{i++}. List device logs");
            Console.WriteLine($"{i++}. List device events");
            Console.WriteLine("---Update---");
            Console.WriteLine($"{i++}. Create update campaign");
            Console.WriteLine($"{i++}. List firmware images");
            Console.WriteLine($"{i++}. List firmware manifests");
            Console.WriteLine($"{i++}. List update campaigns");
            Console.WriteLine($"{i++}. Add firmware image");
            Console.WriteLine($"{i++}. Add firmware manifest");
            Console.WriteLine("---Subscribe---");
            Console.WriteLine($"{i++}. Subscribe to all events");
            Console.WriteLine($"{i++}. Subscribe to a device event");
            Console.WriteLine($"{i++}. Subscribe to all events from a specific device by Id");
            Console.WriteLine($"{i++}. Subscribe specific event from a specific device by Id");
            Console.WriteLine($"{i++}. Subscribe with multiple observers");
            Console.WriteLine("---Press any other key to exit---");
            Console.WriteLine();
            return Console.ReadLine();
        }

        private static async void RunExampleAsync(Config config, int example)
        {
            switch (example)
            {
                case 1:
                    accountManagementExamples.GetAccountDetails();
                    break;
                case 2:
                    await accountManagementExamples.GetAccountDetailsAsync();
                    break;
                case 3:
                    accountManagementExamples.UpdateAccount();
                    break;
                case 4:
                    await accountManagementExamples.UpdateAccountAsync();
                    break;
                case 5:
                    accountManagementExamples.ListApiKeys();
                    break;
                case 6:
                    await accountManagementExamples.ListApiKeysAsync();
                    break;
                case 7:
                    accountManagementExamples.GetApiKey();
                    break;
                case 8:
                    await accountManagementExamples.GetApiKeyAsync();
                    break;
                case 9:
                    accountManagementExamples.AddApiKey();
                    break;
                case 10:
                    await accountManagementExamples.AddApiKeyAsync();
                    break;
                case 11:
                    accountManagementExamples.ListAllGroups();
                    break;
                case 12:
                    accountManagementExamples.ListActiveUsers();
                    break;
                case 13:
                    accountManagementExamples.AddUser();
                    break;
                case 14:
                    await accountManagementExamples.AddUserAsync();
                    break;
                case 15:
                    certificateExamples.CreateCertificate();
                    break;
                case 16:
                    certificateExamples.ListAllCertificates();
                    break;
                case 17:
                    connectExamples.ListConnectedDevices();
                    break;
                case 18:
                    connectExamples.ListConnectedDevicesWithFilter();
                    break;
                case 19:
                    connectExamples.ListLast30Days();
                    break;
                case 20:
                    connectExamples.ListLast2Days();
                    break;
                case 21:
                    connectExamples.ListMonth();
                    break;
                case 22:
                    connectExamples.CreatePreSubscription();
                    break;
                case 23:
                    connectExamples.GetResourceValue();
                    break;
                case 24:
                    connectExamples.SetResourceValue();
                    break;
                case 25:
                    await connectExamples.SubscribeAsync();
                    break;
                case 26:
                    connectExamples.SubscribeCallback();
                    break;
                case 27:
                    connectExamples.RegisterWebhook();
                    break;
                case 28:
                    deviceDirectoryExamples.CreateDevice();
                    break;
                case 29:
                    deviceDirectoryExamples.ListAllDevices();
                    break;
                case 30:
                    deviceDirectoryExamples.AddQuery();
                    break;
                case 31:
                    deviceDirectoryExamples.ListDevicesLogs();
                    break;
                case 32:
                    deviceDirectoryExamples.ListDeviceEvents();
                    break;
                case 33:
                    updateExamples.CreateCampaign();
                    break;
                case 34:
                    updateExamples.ListImages();
                    break;
                case 35:
                    updateExamples.ListManifests();
                    break;
                case 36:
                    updateExamples.ListCampaigns();
                    break;
                case 37:
                    updateExamples.AddFirmwareImage();
                    break;
                case 38:
                    updateExamples.AddFirmwareManifest();
                    break;
                case 39:
                    subscribeExamples.SubscribeToAll().Wait();
                    break;
                case 40:
                    subscribeExamples.SubscribeToDeviceEvent().Wait();
                    break;
                case 41:
                    subscribeExamples.SubscribeToDeviceId().Wait();
                    break;
                case 42:
                    subscribeExamples.SubscribeToDeviceIdAndDeviceEvent().Wait();
                    break;
                case 43:
                    subscribeExamples.SubscribeWithMultipleObservers();
                    break;
                default:
                    break;
            }
        }
    }
}
