using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Query;
using MbedCloudSDK.Connect.Api;
using System;

namespace ConnectedDevicesTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = Environment.GetEnvironmentVariable("MBED_CLOUD_API_KEY");
            if (string.IsNullOrEmpty(key))
            {
                Console.WriteLine("No Api Key!!!");
                Console.WriteLine("Please set environment variable MBED_CLOUD_API_KEY");
            }
            else
            {
                var config = new Config(key);
                var connect = new ConnectApi(config);

                var options = new QueryOptions
                {
                    Limit = 5,
                };
                var connectedDevices = connect.ListConnectedDevices(options).Data;
                Console.WriteLine($"You have {connectedDevices.Count} connected devices!");
                Console.WriteLine();
                connectedDevices.ForEach(c => Console.WriteLine($"Device {c.Id}: name: {c.Name}, createdAt: {c.CreatedAt.ToString()} state: {c.State}"));
                Console.ReadLine();
            }
        }
    }
}
