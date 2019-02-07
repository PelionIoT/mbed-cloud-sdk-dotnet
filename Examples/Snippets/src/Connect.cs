using System;
using System.Threading;
using System.Threading.Tasks;
using Mbed.Cloud.Foundation.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Connect.Api.Subscribe.Models;

namespace Snippets.src
{
    public class Connect
    {
        public async System.Threading.Tasks.Task SubscribeToDeviceStateChangesAsync()
        {
            // an example: subscribing to device state changes
            var config = new Config("An MbedCloud Api  Key", "custom host url");

            using (var connect = new ConnectApi(config))
            {
                var observer = (await connect.Subscribe.DeviceEventsAsync()).Where(d => d.Event == DeviceEventEnum.Registration);

                observer.OnNotify += (res) => Console.WriteLine(res);

                Thread.Sleep(120000);
            }
            // end of example
        }

        public async Task SubscribeToResourceVslueChangesAsync()
        {
            // an example: subscribing to resource value changes
            var config = new Config("An MbedCloud Api  Key", "custom host url");

            using (var connect = new ConnectApi(config))
            {
                var observer = await connect.Subscribe.ResourceValuesAsync("016*", "/3/0/*");

                observer.OnNotify += (res) => Console.WriteLine(res);

                Thread.Sleep(120000);
            }
            // end of example
        }
    }
}