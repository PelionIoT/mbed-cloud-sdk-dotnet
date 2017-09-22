// <copyright file="ConnectedDevice.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.ConnectedDevice
{
    using System.Collections.Generic;
    using System.Text;
    using MbedCloudSDK.Common;
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
        /// </summary>
        /// <param name="deviceData">Device response object.</param>
        /// <param name="api">optional DeviceDirectoryApi.</param>
        /// <returns>Connected device</returns>
        public static ConnectedDevice Map(device_directory.Model.DeviceData deviceData, Connect.Api.ConnectApi api = null)
        {
            var device = new ConnectedDevice(null, api)
            {
                BootstrappedTimestamp = deviceData.BootstrappedTimestamp,
                UpdatedAt = deviceData.UpdatedAt,
                CustomAttributes = deviceData.CustomAttributes,
                DeviceClass = deviceData.DeviceClass,
                Description = deviceData.Description,
                AutoUpdate = deviceData.AutoUpdate,
                Mechanism = Utils.ParseEnum<Mechanism>(deviceData.Mechanism),
                State = Utils.ParseEnum<State>(deviceData.State),
                ProvisionKey = deviceData.DeviceKey,
                SerialNumber = deviceData.SerialNumber,
                VendorId = deviceData.VendorId,
                AccountId = deviceData.AccountId,
                DeployedState = Utils.ParseEnum<DeployedState>(deviceData.DeployedState),
                Deployment = deviceData.Deployment,
                MechanismUrl = deviceData.MechanismUrl,
                TrustLevel = deviceData.TrustLevel,
                Id = deviceData.Id,
                Name = deviceData.Name,
                CreatedAt = deviceData.CreatedAt,
                Manifest = deviceData.Manifest,
                CertificateFingerprint = deviceData.DeviceKey,
                CertificateIssuerId = deviceData.CaId,
                BootstrapExpirationDate = deviceData.BootstrapExpirationDate,
                ConnectorExpirationDate = deviceData.ConnectorExpirationDate,
                EndpointName = deviceData.EndpointName,
                HostGateway = deviceData.HostGateway,
                DeviceExecutionMode = deviceData.DeviceExecutionMode,
                FirmwareChecksum = deviceData.FirmwareChecksum,
                EndpointType = deviceData.EndpointType
            };
            return device;
        }

        /// <summary>
        /// List resources for this device.
        /// </summary>
        /// <returns>List of resources</returns>
        public List<Model.Resource.Resource> ListResources()
        {
            return api.GetResources(Id);
        }

        /// <summary>
        /// Delete Resource.
        /// </summary>
        /// <param name="resourcePath">Path to the resource.</param>
        /// <param name="noResponse">no response</param>
        public void DeleteResource(string resourcePath, bool? noResponse = null)
        {
            api.DeleteResource(Id, resourcePath, noResponse);
        }
    }
}
