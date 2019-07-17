using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mbed.Cloud;
using Mbed.Cloud.Common;
using Mbed.Cloud.Foundation;
using Mbed.Cloud.Foundation.Enums;
using MbedCloudSDK.Connect.Api;

namespace Snippets.src
{
    public class Connect
    {
        public async Task SubscribeToResourceVslueChanges()
        {
            // an example: subscribe to resource values
            // cloak
            /*
            // uncloak
            using Mbed.Cloud.Common;
            using MbedCloudSDK.Connect.Api;
            // cloak
            */
            // uncloak

            var config = new Config
            {
                AutostartNotifications = true,
            };

            using (var connect = new ConnectApi(config))
            {
                var observer = await connect.Subscribe.ResourceValuesAsync("*");

                while(true) {
                    Console.WriteLine(await observer.NextAsync());
                }
            }
            // end of example
        }

        public void GetAndSetResourceValues()
        {
            var sdk = new SDK();
            // an example: get and set a resource value
            // cloak
            /*
            // uncloak
            using Mbed.Cloud;
            using Mbed.Cloud.Common;
            using Mbed.Cloud.Foundation;
            using Mbed.Cloud.Foundation.Enums;
            using MbedCloudSDK.Connect.Api;
            // cloak
            */
            // uncloak

            // Use the Foundation interface to find a connected device.
            var device = sdk
                            .Foundation()
                            .DeviceRepository()
                            .List(new DeviceListOptions().StateEqualTo(DeviceState.REGISTERED))
                            .FirstOrDefault();

            // Use the Legacy interface for find resources
            var config = new Config
            {
                AutostartNotifications = true,
            };

            using (var connect = new ConnectApi(config))
            {
                // Find an observable resource
                var resource = connect
                                    .ListResources(device.Id)
                                    .FirstOrDefault(r => r.Observable == true);

                // Set a resource value
                connect.SetResourceValue(resource.DeviceId, resource.Path, "12");

                // Get a resource value
                var value = connect.GetResourceValue(resource.DeviceId, resource.Path);

                Console.WriteLine($"Device {device.Id}, path {resource.Path}, current value: {value}");
            }
            // end of example
        }
    }
}