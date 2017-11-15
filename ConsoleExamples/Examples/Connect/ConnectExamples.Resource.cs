using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.DeviceDirectory.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleExamples.Examples.Connect
{
    /// @example
    public partial class ConnectExamples
    {
        /// <summary>
        /// Get the value of the resource.
        /// </summary>
        public string GetResourceValue()
        {
            var resourcePath = "/5001/0/1";
            //List all connected endpoints
            var connectedDevices = api.ListConnectedDevices().Data;
            if (connectedDevices == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            var device = connectedDevices.FirstOrDefault();
            var resources = device.ListResources();
            api.StartNotifications();

            var resp = api.GetResourceValue(device.Id, resourcePath);
            Console.WriteLine(resp);
            api.StopNotifications();
            return resp;
        }

        /// <summary>
        /// Set the value on the resource.
        /// </summary>
        public string SetResourceValue()
        {
            //List all connected endpoints
            var connectedDevices = api.ListConnectedDevices().Data;

            if (connectedDevices == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }

            //Start long polling thread

            var device = connectedDevices.FirstOrDefault();

            var resources = device.ListResources();

            var resourceUri = resources.Where(r => r.Type == "writable_resource").FirstOrDefault()?.Path;

            api.StartNotifications();
            var resp = api.SetResourceValue(device.Id, resourceUri, "test-value");

            var newValue = api.GetResourceValue(device.Id, resourceUri);

            Console.WriteLine($"Resource value set to {newValue}");
            api.StopNotifications();
            return newValue;
        }
    }
}
