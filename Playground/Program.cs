
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
using MbedCloudSDK.Connect.Api.Subscribe.Observers;

namespace Playground
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                using (var connect = new ConnectApi(new Config()
                {
                    ForceClear = true,
                    LogLevel = LogLevel.ALL,
                }))
                {

                    // Console.WriteLine("----------------- start -----------------------");

                    // await connect.StartNotificationsAsync();

                    // Console.WriteLine("------------------ start ----------------------");

                    // await connect.StartNotificationsAsync();

                    // Console.WriteLine("------------------ start ----------------------");

                    // await connect.StartNotificationsAsync();

                    // Console.WriteLine("------------------ stop ----------------------");

                    // await connect.StopNotificationsAsync();

                    // Console.WriteLine("------------------- stop ---------------------");

                    // await connect.StopNotificationsAsync();

                    // Console.WriteLine("-------------------- start --------------------");

                    // await connect.StartNotificationsAsync();

                    // Console.WriteLine("-------------------- start --------------------");

                    // await connect.StartNotificationsAsync();

                    Console.WriteLine("-------------------- subscribe --------------------");

                    var myDevice = connect.ListConnectedDevices().FirstOrDefault();

                    var obs = await connect.Subscribe.ResourceValuesAsync(myDevice.Id, new List<string> { "/3202/0/5600" });

                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("looping...");
                        Console.WriteLine(await obs.NextAsync());
                        Console.WriteLine(i);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception...");
                Console.WriteLine(e);
            }
        }
    }

    public class TestObserver<T, F> : Observer<T, F>
    {
    }
}
