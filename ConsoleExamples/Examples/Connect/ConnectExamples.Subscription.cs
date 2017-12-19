// <copyright file="ConnectExamples.Subscription.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.Connect
{
    using System;
    using System.Linq;
    using MbedCloudSDK.Connect.Model.ConnectedDevice;

    /// <summary>
    /// Connect examples
    /// </summary>
    public partial class ConnectExamples
    {
        /// <summary>
        /// Subscribe Resources.
        /// </summary>
        /// <returns>Async consumer</returns>
        public AsyncConsumer<string> Subscribe()
        {
            // Resource path
            const string buttonResource = "/5002/0/1";

            // List all connected endpoints
            var endpointsResp = api.ListConnectedDevices();
            if (endpointsResp == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }

            var endpoints = endpointsResp.ToList();
            var device = endpoints[0];
            api.StartNotifications();
            var resources = device.ListResources();

            // Subscribe to the resource
            var consumer = api.AddResourceSubscription(endpoints[0].Id, buttonResource);
            var counter = 0;
            while (true)
            {
                // Get the value of the resource and print it
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

        /// <summary>
        /// Subscribe to multiple resources
        /// </summary>
        public void SubscribeToMultipleResources()
        {
            // Define resources to subscribe to
            const string incrementalResource = "/5002/0/1";
            const string voltageResource = "/3316/0/5700";
            const string currentResource = "/3317/0/5700";
            const string powerResource = "/3328/0/5700";

            var incrementSubscription = default(AsyncConsumer<string>);
            var voltageSubscription = default(AsyncConsumer<string>);
            var currentSubscription = default(AsyncConsumer<string>);
            var powerSubscription = default(AsyncConsumer<string>);

            var devices = api.ListConnectedDevices().Data;

            var deviceId = devices.FirstOrDefault().Id;

            api.DeleteDeviceSubscriptions(deviceId);

            var resources = api.ListResources(deviceId);

            api.StartNotifications();

            // add subscription if resource is subscribed to
            if (resources.Any(r => r.Path == incrementalResource))
            {
                incrementSubscription = api.AddResourceSubscription(deviceId, incrementalResource);
            }

            if (resources.Any(r => r.Path == voltageResource))
            {
                voltageSubscription = api.AddResourceSubscription(deviceId, voltageResource);
            }

            if (resources.Any(r => r.Path == currentResource))
            {
                currentSubscription = api.AddResourceSubscription(deviceId, currentResource);
            }

            if (resources.Any(r => r.Path == powerResource))
            {
                powerSubscription = api.AddResourceSubscription(deviceId, powerResource);
            }

            while (true)
            {
                // print values when resources change
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
