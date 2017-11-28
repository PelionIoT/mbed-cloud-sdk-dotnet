// <copyright file="Program.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples
{
    using System;
    using ConsoleExamples.Examples.AccountManagement;
    using ConsoleExamples.Examples.Certificates;
    using ConsoleExamples.Examples.Connect;
    using ConsoleExamples.Examples.DeviceDirectory;
    using ConsoleExamples.Examples.Update;
    using MbedCloudSDK.Common;

    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args">args</param>
        [STAThread]
        public static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.Error.WriteLine("API key is required!!!");
                Console.ReadKey();
                return;
            }

            var apiKey = args[0];
            var config = new Config(apiKey)
            {
                // Change default host
                Host = "https://lab-api.mbedcloudintegration.net",
            };
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

            Console.WriteLine(" Closing application");
        }

        private static string ShowMenu()
        {
            var i = 1;
            Console.WriteLine("Select Example");
            Console.WriteLine("---Account management---");
            Console.WriteLine($"{i++}. Get account details");
            Console.WriteLine($"{i++}. Get account details async");
            Console.WriteLine($"{i++}. List Api keys");
            Console.WriteLine($"{i++}. List Api keys asynchronously");
            Console.WriteLine($"{i++}. List Groups");
            Console.WriteLine($"{i++}. List Users");
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
            Console.WriteLine($"{i++}. Subscribe to the resource");
            Console.WriteLine($"{i++}. Subscribe to multiple resources");
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
            Console.WriteLine("---Press any other key to exit---");
            Console.WriteLine();
            return Console.ReadLine();
        }

        private static async void RunExampleAsync(Config config, int example)
        {
            var accountManagementExamples = new AccountManagementExamples(config);
            var certificateExamples = new CertificateExamples(config);
            var connectExamples = new ConnectExamples(config);
            var deviceDirectoryExamples = new DeviceDirectoryExamples(config);
            var updateExamples = new UpdateExamples(config);
            switch (example)
            {
                case 1:
                    accountManagementExamples.GetAccountDetails();
                    break;
                case 2:
                    await accountManagementExamples.GetAccountDetailsAsync();
                    break;
                case 3:
                    accountManagementExamples.ListApiKeys();
                    break;
                case 4:
                    await accountManagementExamples.ListApiKeysAsync();
                    break;
                case 5:
                    accountManagementExamples.ListAllGroups();
                    break;
                case 6:
                    accountManagementExamples.ListActiveUsers();
                    break;
                case 7:
                    certificateExamples.CreateCertificate();
                    break;
                case 8:
                    certificateExamples.ListAllCertificates();
                    break;
                case 9:
                    connectExamples.ListConnectedDevices();
                    break;
                case 10:
                    connectExamples.ListConnectedDevicesWithFilter();
                    break;
                case 11:
                    connectExamples.ListLast30Days();
                    break;
                case 12:
                    connectExamples.ListLast2Days();
                    break;
                case 13:
                    connectExamples.ListMonth();
                    break;
                case 14:
                    connectExamples.CreatePreSubscription();
                    break;
                case 15:
                    connectExamples.GetResourceValue();
                    break;
                case 16:
                    connectExamples.SetResourceValue();
                    break;
                case 17:
                    connectExamples.Subscribe();
                    break;
                case 18:
                    connectExamples.SubscribeToMultipleResources();
                    break;
                case 19:
                    connectExamples.RegisterWebhook();
                    break;
                case 20:
                    deviceDirectoryExamples.CreateDevice();
                    break;
                case 21:
                    deviceDirectoryExamples.ListAllDevices();
                    break;
                case 22:
                    deviceDirectoryExamples.AddQuery();
                    break;
                case 23:
                    deviceDirectoryExamples.ListDevicesLogs();
                    break;
                case 24:
                    deviceDirectoryExamples.ListDeviceEvents();
                    break;
                case 25:
                    updateExamples.CreateCampaign(false);
                    break;
                case 26:
                    updateExamples.ListImages();
                    break;
                case 27:
                    updateExamples.ListManifests();
                    break;
                case 28:
                    updateExamples.ListCampaigns();
                    break;
                default:
                    break;
            }
        }
    }
}