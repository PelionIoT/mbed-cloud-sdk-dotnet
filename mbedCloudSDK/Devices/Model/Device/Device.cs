using System;
using System.Collections.Generic;
using mbedCloudSDK.Devices.Model.Resource;
using System.Text;
using static device_catalog.Model.DeviceDetail;
using mbedCloudSDK.Devices.Api;
using mbedCloudSDK.Exceptions;
using device_catalog.Model;
using mds.Model;

namespace mbedCloudSDK.Devices.Model.Device
{
	/// <summary>
	/// Endpoint.
	/// </summary>
	public class Device
	{
        private DevicesApi api;

        /// <summary>
        /// The ID of the channel used to communicate with the device
        /// </summary>
        /// <value>The ID of the channel used to communicate with the device</value>
        public Mechanism? Mechanism { get; set; }

        /// <summary>
        /// The current state of the device
        /// </summary>
        /// <value>The current state of the device</value>
        public State? State { get; set; }

        /// <summary>
        /// The state of the device's deployment
        /// </summary>
        /// <value>The state of the device's deployment</value>
        public DeployedState? DeployedState { get; set; }

        /// <summary>
        /// Gets or Sets BootstrappedTimestamp
        /// </summary>
        public string BootstrappedTimestamp { get; set; }

        /// <summary>
        /// The time the object was updated
        /// </summary>
        /// <value>The time the object was updated</value>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Up to 5 custom JSON attributes
        /// </summary>
        /// <value>Up to 5 custom JSON attributes</value>
        public Object CustomAttributes { get; set; }

        /// <summary>
        /// The device class
        /// </summary>
        /// <value>The device class</value>
        public string DeviceClass { get; set; }

        /// <summary>
        /// The ID of the device
        /// </summary>
        /// <value>The ID of the device</value>
        public string Id { get; set; }

        /// <summary>
        /// The description of the object
        /// </summary>
        /// <value>The description of the object</value>
        public string Description { get; set; }

        /// <summary>
        /// Mark this device for auto firmware update
        /// </summary>
        /// <value>Mark this device for auto firmware update</value>
        public bool? AutoUpdate { get; set; }

        /// <summary>
        /// The entity instance signature
        /// </summary>
        /// <value>The entity instance signature</value>
        public DateTime? Etag { get; set; }

        /// <summary>
        /// The key used to provision the device
        /// </summary>
        /// <value>The key used to provision the device</value>
        public string ProvisionKey { get; set; }

        /// <summary>
        /// The serial number of the device
        /// </summary>
        /// <value>The serial number of the device</value>
        public string SerialNumber { get; set; }

        /// <summary>
        /// The device vendor ID
        /// </summary>
        /// <value>The device vendor ID</value>
        public string VendorId { get; set; }

        /// <summary>
        /// The owning IAM account ID
        /// </summary>
        /// <value>The owning IAM account ID</value>
        public string AccountId { get; set; }

        /// <summary>
        /// The device trust class
        /// </summary>
        /// <value>The device trust class</value>
        public long? TrustClass { get; set; }

        /// <summary>
        /// The last deployment used on the device
        /// </summary>
        /// <value>The last deployment used on the device</value>
        public string Deployment { get; set; }

        /// <summary>
        /// The address of the connector to use
        /// </summary>
        /// <value>The address of the connector to use</value>
        public string MechanismUrl { get; set; }

        /// <summary>
        /// The device trust level
        /// </summary>
        /// <value>The device trust level</value>
        public long? TrustLevel { get; set; }

        /// <summary>
        /// DEPRECATED: The ID of the device
        /// </summary>
        /// <value>DEPRECATED: The ID of the device</value>
        public string DeviceId { get; set; }

        /// <summary>
        /// The name of the object
        /// </summary>
        /// <value>The name of the object</value>
        public string Name { get; set; }

        /// <summary>
        /// The time the object was created
        /// </summary>
        /// <value>The time the object was created</value>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// URL for the current device manifest
        /// </summary>
        /// <value>URL for the current device manifest</value>
        public string Manifest { get; set; }

        /// <summary>
        /// Possible values ACTIVE, STALE.
        /// </summary>
        /// <value>Possible values ACTIVE, STALE.</value>
        public string Status { get; set; }

        /// <summary>
        /// Determines whether the device is in queue mode. &lt;br/&gt;&lt;br/&gt;&lt;b&gt;Queue mode&lt;/b&gt;&lt;br/&gt; When an endpoint is in queue mode, messages sent to the endpoint do not wake up the physical device. The messages are queued and delivered when the device wakes up and connects to mbed Cloud Connect itself. You can also use the Queue mode when the device is behind a NAT and cannot be reached directly by mbed Cloud Connect. 
        /// </summary>
        /// <value>Determines whether the device is in queue mode. &lt;br/&gt;&lt;br/&gt;&lt;b&gt;Queue mode&lt;/b&gt;&lt;br/&gt; When an endpoint is in queue mode, messages sent to the endpoint do not wake up the physical device. The messages are queued and delivered when the device wakes up and connects to mbed Cloud Connect itself. You can also use the Queue mode when the device is behind a NAT and cannot be reached directly by mbed Cloud Connect. </value>
        public bool? QueueMode { get; set; }
        /// <summary>
        /// Type of endpoint. (Free text)
        /// </summary>
        /// <value>Type of endpoint. (Free text)</value>
        public string Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Device" /> class.
        /// </summary>
        /// <param name="options">Dictionary containing properties.</param>
        /// <param name="api">Devices Api.</param>
        public Device(IDictionary<string, object> options = null, DevicesApi api = null)
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

        public static Device Map(Endpoint endpoint, DevicesApi api)
        {
            var device = new Device(null, api);
            device.Id = endpoint.Name;
            device.Status = endpoint.Status;
            device.QueueMode = endpoint.Q;
            device.Type = endpoint.Type;
            return device;
        }

        public static Device Map(DeviceDetail deviceDetail, DevicesApi api)
        {
            var device = new Device(null, api);
            device.BootstrappedTimestamp = deviceDetail.BootstrappedTimestamp;
            device.UpdatedAt = deviceDetail.UpdatedAt;
            device.CustomAttributes = deviceDetail.CustomAttributes;
            device.DeviceClass = deviceDetail.DeviceClass;
            device.Id = deviceDetail.Id;
            device.Description = deviceDetail.Description;
            device.AutoUpdate = deviceDetail.AutoUpdate;
            if (deviceDetail.Mechanism != null)
            {
                device.Mechanism = (Mechanism)Enum.Parse(typeof(Mechanism), deviceDetail.Mechanism.ToString());
            }
            if (deviceDetail.State != null)
            {
                device.State = (State)Enum.Parse(typeof(State), deviceDetail.State.ToString());
            }
            device.Etag = deviceDetail.Etag;
            device.ProvisionKey = deviceDetail.ProvisionKey;
            device.SerialNumber = deviceDetail.SerialNumber;
            device.VendorId = deviceDetail.VendorId;
            device.AccountId = deviceDetail.AccountId;
            if (deviceDetail.DeployedState != null)
            {
                device.DeployedState = (DeployedState)Enum.Parse(typeof(DeployedState), deviceDetail.DeployedState.ToString());
            }
            device.TrustClass = deviceDetail.TrustClass;
            device.Deployment = deviceDetail.Deployment;
            device.MechanismUrl = deviceDetail.MechanismUrl;
            device.TrustLevel = deviceDetail.TrustLevel;
            device.DeviceId = deviceDetail.DeviceId;
            device.Name = deviceDetail.Name;
            device.CreatedAt = deviceDetail.CreatedAt;
            device.Manifest = deviceDetail.Manifest;
            return device;
        }

        /// <summary>
        /// List resources for this device.
        /// </summary>
        /// <returns></returns>
        public List<Resource.Resource> ListResources()
        {
            return this.api.ListResources(this.Id);
        }

        /// <summary>
        /// Delete Resource.
        /// </summary>
        /// <param name="resourcePath">Path to the resource.</param>
        /// <param name="noResponse"></param>
        public void DeleteResource(string resourcePath, bool? noResponse = null)
        {
            this.api.DeleteResource(this.Id, resourcePath, noResponse);
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
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("  ProvisionKey: ").Append(ProvisionKey).Append("\n");
            sb.Append("  SerialNumber: ").Append(SerialNumber).Append("\n");
            sb.Append("  VendorId: ").Append(VendorId).Append("\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  DeployedState: ").Append(DeployedState).Append("\n");
            sb.Append("  TrustClass: ").Append(TrustClass).Append("\n");
            sb.Append("  Deployment: ").Append(Deployment).Append("\n");
            sb.Append("  MechanismUrl: ").Append(MechanismUrl).Append("\n");
            sb.Append("  TrustLevel: ").Append(TrustLevel).Append("\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Manifest: ").Append(Manifest).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  QueueMode: ").Append(QueueMode).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
