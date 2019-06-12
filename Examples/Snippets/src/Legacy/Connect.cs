using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mbed.Cloud.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Connect.Api.Subscribe.Models;

namespace Snippets.src
{
    public class Connect
    {
        public async Task SubscribeToDeviceStateChanges()
        {
            // an example: subscribing to device state changes
            var config = new Config();

            using (var connect = new ConnectApi(config))
            {
                var observer = (await connect.Subscribe.DeviceEventsAsync()).Filter(d => d.Event == DeviceEvent.Registration);

                observer.OnNotify += (res) => Console.WriteLine(res);

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(await observer.NextAsync());
                }
            }
            // end of example
        }

        public async Task SubscribeToResourceVslueChanges()
        {
            // an example: subscribing to resource value changes
            var config = new Config();

            using (var connect = new ConnectApi(config))
            {
                var observer = await connect.Subscribe.ResourceValuesAsync("016*", "/3/0/*");

                observer.OnNotify += (res) => Console.WriteLine(res);

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(await observer.NextAsync());
                }
            }
            // end of example
        }

        public void GetAndSetResourceValues()
        {
            // an example: resource values
            var config = new Config
            {
                AutostartNotifications = true,
            };

            using (var connect = new ConnectApi(config))
            {
                var resource = connect.ListConnectedDevices()
                                    .FirstOrDefault()
                                    .ListResources()
                                    .FirstOrDefault(r => r.Observable == true);

                connect.SetResourceValue(resource.DeviceId, resource.Path, DateTime.Now.ToString());

                var newValue = connect.GetResourceValue(resource.DeviceId, resource.Path);
            }
            // end of example
        }
    }
}