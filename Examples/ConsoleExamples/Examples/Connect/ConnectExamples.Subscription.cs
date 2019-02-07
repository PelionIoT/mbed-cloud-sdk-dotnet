// <copyright file="ConnectExamples.Subscription.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.Connect
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MbedCloudSDK.Connect.Model.ConnectedDevice;
    using MbedCloudSDK.Connect.Model.Resource;

    /// <summary>
    /// Connect examples
    /// </summary>
    public partial class ConnectExamples
    {
        /// <summary>
        /// Subscribe Resources.
        /// </summary>
        /// <returns>Task with resource</returns>
        public async Task<Resource> SubscribeAsync()
        {
            // Resource path
            const string buttonResource = "/5002/0/1";

            // List all connected endpoints
            var devices = api.ListConnectedDevices().All();
            if (devices == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }

            // Subscribe to the resource
            Console.WriteLine($"subscribing to {buttonResource} on device {devices[0].Id}");
            var resource = await api.AddResourceSubscription(devices[0].Id, buttonResource);
            var counter = 0;
            while (true)
            {
                // Get the value of the resource and print it
                var t = await resource.NotificationQueue.Take();
                Console.WriteLine(t);
                counter++;
                if (counter >= 20)
                {
                    break;
                }
            }

            api.DeleteDeviceSubscriptions(devices[0].Id);
            await api.StopNotificationsAsync();
            return resource;
        }

        /// <summary>
        /// Callback
        /// </summary>
        public async Task SubscribeCallbackAsync()
        {
            // Resource path
            const string buttonResource = "/5002/0/1";

            // List all connected endpoints
            var endpoints = api.ListConnectedDevices().All();
            if (endpoints == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }

            // Subscribe to the resource
            Console.WriteLine($"subscribing to {buttonResource} on device {endpoints[0].Id}");

            Action<string> notificationCallback = (res) => { Console.WriteLine("Got value " + res); };

            var resource = await api.AddResourceSubscription(endpoints[0].Id, buttonResource);

            resource.NotificationHandler = notificationCallback;
        }

        /// <summary>
        /// Subscribe to multiple resources
        /// </summary>
        public async void SubscribeToMultipleResourcesAsync()
        {
            // Define resources to subscribe to
            const string incrementalResource = "/5002/0/1";
            const string voltageResource = "/3316/0/5700";
            const string currentResource = "/3317/0/5700";
            const string powerResource = "/3328/0/5700";

            var incrementSubscription = default(Resource);
            var voltageSubscription = default(Resource);
            var currentSubscription = default(Resource);
            var powerSubscription = default(Resource);

            var devices = api.ListConnectedDevices();

            var deviceId = devices.FirstOrDefault().Id;

            api.DeleteDeviceSubscriptions(deviceId);

            var resources = api.ListResources(deviceId);

            // add subscription if resource is subscribed to
            if (resources.Any(r => r.Path == incrementalResource))
            {
                incrementSubscription = await api.AddResourceSubscription(deviceId, incrementalResource);
            }

            if (resources.Any(r => r.Path == voltageResource))
            {
                voltageSubscription = await api.AddResourceSubscription(deviceId, voltageResource);
            }

            if (resources.Any(r => r.Path == currentResource))
            {
                currentSubscription = await api.AddResourceSubscription(deviceId, currentResource);
            }

            if (resources.Any(r => r.Path == powerResource))
            {
                powerSubscription = await api.AddResourceSubscription(deviceId, powerResource);
            }

            while (true)
            {
                // print values when resources change
                if (incrementSubscription != null)
                {
                    var i = await incrementSubscription?.NotificationQueue?.Take();
                    Console.WriteLine($"Current value of increment - {i}");
                }

                if (voltageSubscription != null)
                {
                    var v = await voltageSubscription?.NotificationQueue?.Take();
                    Console.WriteLine($"Current value of voltage - {v}");
                }

                if (currentSubscription != null)
                {
                    var c = await currentSubscription?.NotificationQueue?.Take();
                    Console.WriteLine($"Current value of current - {c}");
                }

                if (powerSubscription != null)
                {
                    var p = await powerSubscription?.NotificationQueue?.Take();
                    Console.WriteLine($"Current value of power - {p}");
                }
            }
        }
    }
}
