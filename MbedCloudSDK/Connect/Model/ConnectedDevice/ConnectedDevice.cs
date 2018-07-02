// <copyright file="ConnectedDevice.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.ConnectedDevice
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.DeviceDirectory.Model.Device;
    using mds.Model;

    /// <summary>
    /// Connected Device
    /// </summary>
    public class ConnectedDevice : DeviceDirectory.Model.Device.Device
    {
        private Connect.Api.ConnectApi api;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectedDevice" /> class.
        /// </summary>
        /// <param name="options">Dictionary containing properties.</param>
        /// <param name="api">Connect Api.</param>
        public ConnectedDevice(IDictionary<string, object> options = null, Api.ConnectApi api = null)
        {
            this.api = api;
            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    var property = GetType().GetProperty(item.Key);
                    if (property != null)
                    {
                        property.SetValue(this, item.Value, null);
                    }
                }
            }
        }

        /// <summary>
        /// Map to Device object.
        /// </summary>\
        /// <param name="deviceData">Device response object.</param>
        /// <param name="api">optional DeviceDirectoryApi.</param>
        /// <returns>Connected device</returns>
        public static ConnectedDevice Map(device_directory.Model.DeviceData deviceData, Connect.Api.ConnectApi api = null)
        {
            var device = Device.Map(deviceData);
            var @props = device.GetProperties();
            var connectedDevice = new ConnectedDevice(@props, api);
            return connectedDevice;
        }

        /// <summary>
        /// List resources for this device.
        /// </summary>
        /// <returns>List of resources</returns>
        public List<Model.Resource.Resource> ListResources()
        {
            return api.ListResources(Id);
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}
