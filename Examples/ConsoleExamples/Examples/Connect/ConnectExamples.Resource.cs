// <copyright file="ConnectExamples.Resource.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.Connect
{
    using System;
    using System.Linq;

    /// <summary>
    /// Connect examples
    /// </summary>
    public partial class ConnectExamples
    {
        /// <summary>
        /// Get the value of the resource.
        /// </summary>
        /// <returns>Resource value</returns>
        public string GetResourceValue()
        {
            // resource path to get value from
            const string resourcePath = "/5002/0/1";
            var connectedDevices = api.ListConnectedDevices().Data;
            if (connectedDevices == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }

            var device = connectedDevices.FirstOrDefault();
            var resp = api.GetResourceValue(device.Id, resourcePath);
            Console.WriteLine($"The value of the resource is {resp}");
            return resp;
        }

        /// <summary>
        /// Set the value on the resource.
        /// </summary>
        /// <returns>Resource value</returns>
        public string SetResourceValue()
        {
            var connectedDevices = api.ListConnectedDevices().Data;

            if (connectedDevices == null)
            {
                throw new Exception("No endpoints registered. Aborting.");
            }

            var device = connectedDevices.FirstOrDefault();

            var resources = device.ListResources();

            var resourceUri = resources.FirstOrDefault(r => r.Type == "writable_resource")?.Path;

            var resp = api.SetResourceValue(device.Id, resourceUri, "test-value");

            var newValue = api.GetResourceValue(device.Id, resourceUri);

            Console.WriteLine($"Resource value set to {newValue}");
            return newValue;
        }
    }
}
