
using System;
using Newtonsoft.Json;
using MbedCloudSDK.Common.Extensions;
using System.Linq;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Common;
using System.Collections.Generic;
using Mbed.Cloud.Foundation.Common;

namespace Playground
{
    class Program
    {
        private const string Url = "wss://api-ns-websocket.mbedcloudintegration.net/v2/notification/websocket-connect";
        private const string ApiKey = "ak_1MDE2ODVjNzVjOTdjMjJjMTFjMDQ0ZDUzMDAwMDAwMDA0168b97683d6f65f42b0f3e100000000lt4PeToNqJ3ZvguwsxoxH7tadJci8qYv";
        private const string Host = "https://api-ns-websocket.mbedcloudintegration.net";

        static async Task Main(string[] args)
        {
            try
            {
                var connect = new ConnectApi(new Config(ApiKey, Host));

                await connect.StartNotificationsAsync();

                await connect.StopNotificationsAsync();

                // var myDevice = connect.ListConnectedDevices().FirstOrDefault();

                // connect.Subscribe.ResourceValues(myDevice.Id, new List<string> { "/3200/0/5501" });

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception...");
                Console.WriteLine(e);
            }
        }
    }
}
