using System;
using System.Collections.Generic;
using System.Text;
using mbedCloudSDK.DeviceDirectory.Api;
using mbedCloudSDK.Exceptions;
using device_directory.Model;
using mds.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using mbedCloudSDK.Common;

namespace mbedCloudSDK.DeviceDirectory.Model.Device
{
	/// <summary>
	/// Endpoint.
	/// </summary>
	public class Device
	{
        private DeviceDirectoryApi api;

        /// <summary>
        /// The ID of the channel used to communicate with the device
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Mechanism? Mechanism { get; set; }

        /// <summary>
        /// The current state of the device
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public State? State { get; set; }

        /// <summary>
        /// The state of the device's deployment
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DeployedState? DeployedState { get; set; }

        /// <summary>
        /// Gets or Sets BootstrappedTimestamp
        /// </summary>
        public DateTime? BootstrappedTimestamp { get; set; }

        /// <summary>
        /// The time the object was updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Up to 5 custom JSON attributes
        /// </summary>
        public Object CustomAttributes { get; set; }

        /// <summary>
        /// The device class
        /// </summary>
        public string DeviceClass { get; set; }

        [NameOverride(Name="DeviceId")]
        /// <summary>
        /// The ID of the device
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The description of the object
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Mark this device for auto firmware update
        /// </summary>
        public bool? AutoUpdate { get; set; }

        /// <summary>
        /// The key used to provision the device
        /// </summary>
        public string ProvisionKey { get; set; }

        /// <summary>
        /// The serial number of the device
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// The device vendor ID
        /// </summary>
        public string VendorId { get; set; }

        /// <summary>
        /// The owning IAM account ID
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// The last deployment used on the device
        /// </summary>
        public string Deployment { get; set; }

        /// <summary>
        /// The address of the connector to use
        /// </summary>
        public string MechanismUrl { get; set; }

        /// <summary>
        /// The device trust level
        /// </summary>
        public int? TrustLevel { get; set; }

        /// <summary>
        /// DEPRECATED: The ID of the device
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// The name of the object
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The time the object was created
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// URL for the current device manifest
        /// </summary>
        public string Manifest { get; set; }
        /// <summary>
        /// Fingerprint of the device certificate
        /// </summary>
        public string CertificateFingerprint { get; set; }
        /// <summary>
        /// ID of the issuer of the certificate
        /// </summary>
        public string CertificateIssuerId { get; set; }
        /// <summary>
        /// Expiration date of the certificate used to connect to bootstrap server
        /// </summary>
        public DateTime? BootstrapExpirationDate { get; set; }
        /// <summary>
        /// Expiration date of the certificate used to connect to connector server
        /// </summary>
        public DateTime? ConnectorExpirationDate { get; set; }
        /// <summary>
        /// The endpoint name given to the device
        /// </summary>
        public string EndpointName { get; set; }
        /// <summary>
        /// The endpoint_name of the host gateway, if appropriate
        /// </summary>
        public string HostGateway { get; set; }
        /// <summary>
        /// Defines the type of certificate used
        /// </summary>
        public int? DeviceExecutionMode { get; set; }
        /// <summary>
        /// The SHA256 checksum of the current firmware image
        /// </summary>
        public string FirmwareChecksum { get; set; }
        /// <summary>
        /// The endpoint type of the device - e.g. if the device is a gateway
        /// </summary>
        public string EndpointType { get; set; }
        /// <summary>
        /// The API resource entity
        /// </summary>
        public string _Object { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Device() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Device" /> class.
        /// </summary>
        /// <param name="options">Dictionary containing properties.</param>
        /// <param name="api">DeviceDirectory Api.</param>
        public Device(IDictionary<string, object> options = null, DeviceDirectoryApi api = null)
        {
            this.api = api;
            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    var property = this.GetType().GetProperty(item.Key);
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
        /// <param name="deviceData">DeviceDetal response object.</param>
        /// <param name="api">optional DeviceDirectoryApi</param>
        /// <returns></returns>
        public static Device Map(DeviceData deviceData, DeviceDirectoryApi api = null)
        {
            var device = new Device(null, api);
            device.BootstrappedTimestamp = deviceData.BootstrappedTimestamp;
            device.UpdatedAt = deviceData.UpdatedAt;
            device.CustomAttributes = deviceData.CustomAttributes;
            device.DeviceClass = deviceData.DeviceClass;
            device.Id = deviceData.Id;
            device.Description = deviceData.Description;
            device.AutoUpdate = deviceData.AutoUpdate;
            if (deviceData.Mechanism != null)
            {
                device.Mechanism = (Mechanism)Enum.Parse(typeof(Mechanism), deviceData.Mechanism.ToString());
            }
            if (deviceData.State != null)
            {
                device.State = (State)Enum.Parse(typeof(State), deviceData.State.ToString());
            }
            device.ProvisionKey = deviceData.DeviceKey;
            device.SerialNumber = deviceData.SerialNumber;
            device.VendorId = deviceData.VendorId;
            device.AccountId = deviceData.AccountId;
            if (deviceData.DeployedState != null)
            {
                device.DeployedState = (DeployedState)Enum.Parse(typeof(DeployedState), deviceData.DeployedState.ToString());
            }
            device.Deployment = deviceData.Deployment;
            device.MechanismUrl = deviceData.MechanismUrl;
            device.TrustLevel = deviceData.TrustLevel;
            device.DeviceId = deviceData.Id;
            device.Name = deviceData.Name;
            device.CreatedAt = deviceData.CreatedAt;
            device.Manifest = deviceData.Manifest;
            device.CertificateFingerprint = deviceData.DeviceKey;
            device.CertificateIssuerId = deviceData.CaId;
            device.BootstrapExpirationDate = deviceData.BootstrapExpirationDate;
            device.ConnectorExpirationDate = deviceData.ConnectorExpirationDate;
            device.EndpointName = deviceData.EndpointName;
            device.HostGateway = deviceData.HostGateway;
            device.DeviceExecutionMode = deviceData.DeviceExecutionMode;
            device.FirmwareChecksum = deviceData.FirmwareChecksum;
            device.EndpointType = deviceData.EndpointType;
            return device;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeviceDetail {\n");
            sb.Append("  BootstrappedTimestamp: ").Append(BootstrappedTimestamp).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  CustomAttributes: ").Append(CustomAttributes).Append("\n");
            sb.Append("  DeviceClass: ").Append(DeviceClass).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  AutoUpdate: ").Append(AutoUpdate).Append("\n");
            sb.Append("  Mechanism: ").Append(Mechanism).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  ProvisionKey: ").Append(ProvisionKey).Append("\n");
            sb.Append("  SerialNumber: ").Append(SerialNumber).Append("\n");
            sb.Append("  VendorId: ").Append(VendorId).Append("\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  DeployedState: ").Append(DeployedState).Append("\n");
            sb.Append("  Deployment: ").Append(Deployment).Append("\n");
            sb.Append("  MechanismUrl: ").Append(MechanismUrl).Append("\n");
            sb.Append("  TrustLevel: ").Append(TrustLevel).Append("\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Manifest: ").Append(Manifest).Append("\n");
            sb.Append("  Fingerprint: ").Append(CertificateFingerprint).Append("\n");
            sb.Append("  IssuerId: ").Append(CertificateIssuerId).Append("\n");
            sb.Append("  BootstrapExpirationDate: ").Append(BootstrapExpirationDate).Append("\n");
            sb.Append("  ConnectorExpirationDate: ").Append(ConnectorExpirationDate).Append("\n");
            sb.Append("  EndpointName: ").Append(EndpointName).Append("\n");
            sb.Append("  HostGateway: ").Append(HostGateway).Append("\n");
            sb.Append("  DeviceExecutionMode: ").Append(DeviceExecutionMode).Append("\n");
            sb.Append("  FirmwareChecksum: ").Append(FirmwareChecksum).Append("\n");
            sb.Append("  EndpointType: ").Append(EndpointType).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
