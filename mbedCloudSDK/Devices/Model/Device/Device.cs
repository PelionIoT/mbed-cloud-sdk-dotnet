using System;
using System.Collections.Generic;
using mbedCloudSDK.Devices.Model.Resource;
using System.Text;
using static device_catalog.Model.DeviceDetail;
using mbedCloudSDK.Devices.Api;
using mbedCloudSDK.Exceptions;

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
        /// Gets or sets the resources.
        /// </summary>
        /// <value>The resources.</value>
        //public Dictionary<string, Resource.Resource> Resources { get; set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="Device" /> class.
        /// </summary>
        /// <param name="api">Devices Api.</param>
        /// <param name="BootstrappedTimestamp">BootstrappedTimestamp.</param>
        /// <param name="UpdatedAt">The time the object was updated.</param>
        /// <param name="CustomAttributes">Up to 5 custom JSON attributes.</param>
        /// <param name="DeviceClass">The device class.</param>
        /// <param name="Id">The ID of the device.</param>
        /// <param name="Description">The description of the object.</param>
        /// <param name="AutoUpdate">Mark this device for auto firmware update.</param>
        /// <param name="Mechanism">The ID of the channel used to communicate with the device.</param>
        /// <param name="State">The current state of the device.</param>
        /// <param name="Etag">The entity instance signature.</param>
        /// <param name="ProvisionKey">The key used to provision the device.</param>
        /// <param name="SerialNumber">The serial number of the device.</param>
        /// <param name="VendorId">The device vendor ID.</param>
        /// <param name="AccountId">The owning IAM account ID.</param>
        /// <param name="DeployedState">The state of the device&#39;s deployment.</param>
        /// <param name="TrustClass">The device trust class.</param>
        /// <param name="Deployment">The last deployment used on the device.</param>
        /// <param name="MechanismUrl">The address of the connector to use.</param>
        /// <param name="TrustLevel">The device trust level.</param>
        /// <param name="DeviceId">DEPRECATED: The ID of the device.</param>
        /// <param name="Name">The name of the object.</param>
        /// <param name="CreatedAt">The time the object was created.</param>
        /// <param name="Manifest">URL for the current device manifest.</param>
        /// <param name="Status">Possible values ACTIVE, STALE.</param>
        /// <param name="QueueMode">Determines whether the device is in queue mode.</param>
        /// <param name="Type">Type of endpoint.</param>
        public Device(DevicesApi api, string BootstrappedTimestamp = null, DateTime? UpdatedAt = null, Object CustomAttributes = null, string DeviceClass = null, string Id = null, string Description = null, bool? AutoUpdate = null, MechanismEnum? Mechanism = null, StateEnum? State = null, DateTime? Etag = null, string ProvisionKey = null, string SerialNumber = null, string VendorId = null, string AccountId = null, DeployedStateEnum? DeployedState = null, long? TrustClass = null, string Deployment = null, string MechanismUrl = null, long? TrustLevel = null, string DeviceId = null, string Name = null, DateTime? CreatedAt = null, string Manifest = null, string Status = null, bool? QueueMode = null, string Type = null)
        {
            this.api = api;
            this.BootstrappedTimestamp = BootstrappedTimestamp;
            this.UpdatedAt = UpdatedAt;
            this.CustomAttributes = CustomAttributes;
            this.DeviceClass = DeviceClass;
            this.Id = Id;
            this.Description = Description;
            this.AutoUpdate = AutoUpdate;
            if (Mechanism != null)
            {
                this.Mechanism = (Mechanism)Enum.Parse(typeof(Mechanism), Mechanism.ToString());
            }
            if (State != null)
            {
                this.State = (State)Enum.Parse(typeof(State), State.ToString());
            }
            this.Etag = Etag;
            this.ProvisionKey = ProvisionKey;
            this.SerialNumber = SerialNumber;
            this.VendorId = VendorId;
            this.AccountId = AccountId;
            if (DeployedState != null)
            {
                this.DeployedState = (DeployedState)Enum.Parse(typeof(DeployedState), DeployedState.ToString());
            }
            this.TrustClass = TrustClass;
            this.Deployment = Deployment;
            this.MechanismUrl = MechanismUrl;
            this.TrustLevel = TrustLevel;
            this.DeviceId = DeviceId;
            this.Name = Name;
            this.CreatedAt = CreatedAt;
            this.Manifest = Manifest;
            this.Status = Status;
            this.QueueMode = QueueMode;
            this.Type = Type;
            //this.Resources = new Dictionary<string, Resource.Resource>();
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
            //sb.Append("  Resources: ").Append(Resources).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
