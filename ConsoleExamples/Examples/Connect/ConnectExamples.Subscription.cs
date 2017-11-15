using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Api;
using MbedCloudSDK.Connect.Model.ConnectedDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples.Examples.Connect
{
    /// @example
    public partial class ConnectExamples
    {
        /// <summary>
        /// Subscribe Resources.
        /// </summary>
        public AsyncConsumer<String> Subscribe()
        {
            //Resource path
            var buttonResource = "/5002/0/1";
            //List all connected endpoints
            var endpointsResp = api.ListConnectedDevices();
            if (endpointsResp == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }
            var endpoints = endpointsResp.ToList();
            var device = endpoints[0];
            api.StartNotifications();
            var resources = device.ListResources();
            //Subscribe to the resource
            var consumer = api.AddResourceSubscription(endpoints[0].Id, buttonResource);
            int counter = 0;
            while (true)
            {
                //Get the value of the resource and print it
                var t = consumer.GetValue();
                Console.WriteLine(t.Result);
                counter++;
                if (counter >= 2)
                {
                    break;
                }
            }
            api.StopNotifications();
            return consumer;
        }

        public void SubscribeToMultipleResources()
        {
            var incrementalResource = "/5002/0/1";
            var voltageResource = "/3316/0/5700";
            var currentResource = "/3317/0/5700";
            var powerResource = "/3328/0/5700";

            AsyncConsumer<string> incrementSubscription = default(AsyncConsumer<string>);
            AsyncConsumer<string> voltageSubscription = default(AsyncConsumer<string>);
            AsyncConsumer<string> currentSubscription = default(AsyncConsumer<string>);
            AsyncConsumer<string> powerSubscription = default(AsyncConsumer<string>);

            var devices = api.ListConnectedDevices().Data;

            var deviceId = devices.FirstOrDefault().Id;

            api.DeleteDeviceSubscriptions(deviceId);

            var resources = api.ListResources(deviceId);

            api.StartNotifications();

            if (resources.Where(r => r.Path == incrementalResource).Any())
                incrementSubscription = api.AddResourceSubscription(deviceId, incrementalResource);
            if (resources.Where(r => r.Path == voltageResource).Any())
                voltageSubscription = api.AddResourceSubscription(deviceId, voltageResource);
            if (resources.Where(r => r.Path == currentResource).Any())
                currentSubscription = api.AddResourceSubscription(deviceId, currentResource);
            if (resources.Where(r => r.Path == powerResource).Any())
                powerSubscription = api.AddResourceSubscription(deviceId, powerResource);

            while(true)
            {
                var i = incrementSubscription?.GetValue()?.Result;
                Console.WriteLine($"Current value of increment - {i}");
                var v = voltageSubscription?.GetValue()?.Result;
                Console.WriteLine($"Current value of voltage - {v}");
                var c = currentSubscription?.GetValue()?.Result;
                Console.WriteLine($"Current value of current - {c}");
                var p = powerSubscription?.GetValue()?.Result;
                Console.WriteLine($"Current value of power - {p}");
            }
        }
    }
}