// <copyright file="ConnectExamples.Webhook.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.Connect
{
    using System;
    using System.Linq;
    using System.Threading;

    /// <summary>
    /// Connect examples
    /// </summary>
    public partial class ConnectExamples
    {
        /// <summary>
        /// Create a webhook for the resouce.
        /// </summary>
        /// <returns>Webhook</returns>
        public MbedCloudSDK.Connect.Model.Webhook.Webhook RegisterWebhook()
        {
            // Resource path
            const string buttonResource = "/5002/0/1";

            // List all connected endpoints
            var connectedDevices = api.ListConnectedDevices();
            if (connectedDevices == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }

            var device = connectedDevices.FirstOrDefault();
            api.DeleteDeviceSubscriptions(device.Id);

            api.AddResourceSubscription(device.Id, buttonResource);

            // webhook address
            var webhook = new MbedCloudSDK.Connect.Model.Webhook.Webhook("http://mbed-cloud-dotnet.requestcatcher.com/test");
            api.UpdateWebhook(webhook);
            Thread.Sleep(2000);

            // Subscribe to the resource
            Console.WriteLine($"Webhook registered, see output on {webhook.Url}");

            // Deregister webhook after 1 minute
            Thread.Sleep(60000);
            api.DeleteWebhook();
            return webhook;
        }
    }
}