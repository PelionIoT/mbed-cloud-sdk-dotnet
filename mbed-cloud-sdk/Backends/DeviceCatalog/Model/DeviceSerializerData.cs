using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace device_catalog.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class DeviceSerializerData :  IEquatable<DeviceSerializerData>
    { 
    
        /// <summary>
        /// The current state of the device
        /// </summary>
        /// <value>The current state of the device</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StateEnum {
            
            [EnumMember(Value = "unenrolled")]
            Unenrolled,
            
            [EnumMember(Value = "cloud_enrolling")]
            CloudEnrolling,
            
            [EnumMember(Value = "bootstrapped")]
            Bootstrapped,
            
            [EnumMember(Value = "registered")]
            Registered
        }

    
        /// <summary>
        /// The ID of the channel used to communicate with the device
        /// </summary>
        /// <value>The ID of the channel used to communicate with the device</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MechanismEnum {
            
            [EnumMember(Value = "connector")]
            Connector,
            
            [EnumMember(Value = "direct")]
            Direct
        }

    
        /// <summary>
        /// The state of the device's deployment
        /// </summary>
        /// <value>The state of the device's deployment</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum DeployedStateEnum {
            
            [EnumMember(Value = "development")]
            Development,
            
            [EnumMember(Value = "production")]
            Production
        }

    
        /// <summary>
        /// The current state of the device
        /// </summary>
        /// <value>The current state of the device</value>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public StateEnum? State { get; set; }
    
        /// <summary>
        /// The ID of the channel used to communicate with the device
        /// </summary>
        /// <value>The ID of the channel used to communicate with the device</value>
        [DataMember(Name="mechanism", EmitDefaultValue=false)]
        public MechanismEnum? Mechanism { get; set; }
    
        /// <summary>
        /// The state of the device's deployment
        /// </summary>
        /// <value>The state of the device's deployment</value>
        [DataMember(Name="deployed_state", EmitDefaultValue=false)]
        public DeployedStateEnum? DeployedState { get; set; }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceSerializerData" /> class.
        /// Initializes a new instance of the <see cref="DeviceSerializerData" />class.
        /// </summary>
        /// <param name="DeviceId">DEPRECATED: The ID of the device.</param>
        /// <param name="MechanismUrl">The address of the connector to use.</param>
        /// <param name="Manifest">URL for the current device manifest.</param>
        /// <param name="ProvisionKey">The key used to provision the device (required).</param>
        /// <param name="Description">The description of the object.</param>
        /// <param name="TrustClass">The device trust class.</param>
        /// <param name="TrustLevel">The device trust level.</param>
        /// <param name="CreatedAt">The time the object was created.</param>
        /// <param name="SerialNumber">The serial number of the device.</param>
        /// <param name="CustomAttributes">Up to 5 custom JSON attributes.</param>
        /// <param name="AccountId">The owning IAM account ID (required).</param>
        /// <param name="UpdatedAt">The time the object was updated.</param>
        /// <param name="AutoUpdate">Mark this device for auto firmware update.</param>
        /// <param name="BootstrappedTimestamp">BootstrappedTimestamp.</param>
        /// <param name="VendorId">The device vendor ID.</param>
        /// <param name="Name">The name of the object.</param>
        /// <param name="DeviceClass">The device class.</param>
        /// <param name="Etag">The entity instance signature.</param>
        /// <param name="Id">The ID of the device.</param>
        /// <param name="State">The current state of the device.</param>
        /// <param name="Mechanism">The ID of the channel used to communicate with the device (required).</param>
        /// <param name="DeployedState">The state of the device&#39;s deployment.</param>
        /// <param name="_Object">The API resource entity.</param>
        /// <param name="Deployment">The last deployment used on the device.</param>

        public DeviceSerializerData(string DeviceId = null, string MechanismUrl = null, string Manifest = null, string ProvisionKey = null, string Description = null, long? TrustClass = null, long? TrustLevel = null, DateTime? CreatedAt = null, string SerialNumber = null, string CustomAttributes = null, string AccountId = null, DateTime? UpdatedAt = null, bool? AutoUpdate = null, string BootstrappedTimestamp = null, string VendorId = null, string Name = null, string DeviceClass = null, DateTime? Etag = null, string Id = null, StateEnum? State = null, MechanismEnum? Mechanism = null, DeployedStateEnum? DeployedState = null, string _Object = null, string Deployment = null)
        {
            // to ensure "ProvisionKey" is required (not null)
            if (ProvisionKey == null)
            {
                throw new InvalidDataException("ProvisionKey is a required property for DeviceSerializerData and cannot be null");
            }
            else
            {
                this.ProvisionKey = ProvisionKey;
            }
            // to ensure "AccountId" is required (not null)
            if (AccountId == null)
            {
                throw new InvalidDataException("AccountId is a required property for DeviceSerializerData and cannot be null");
            }
            else
            {
                this.AccountId = AccountId;
            }
            // to ensure "Mechanism" is required (not null)
            if (Mechanism == null)
            {
                throw new InvalidDataException("Mechanism is a required property for DeviceSerializerData and cannot be null");
            }
            else
            {
                this.Mechanism = Mechanism;
            }
            this.DeviceId = DeviceId;
            this.MechanismUrl = MechanismUrl;
            this.Manifest = Manifest;
            this.Description = Description;
            this.TrustClass = TrustClass;
            this.TrustLevel = TrustLevel;
            this.CreatedAt = CreatedAt;
            this.SerialNumber = SerialNumber;
            this.CustomAttributes = CustomAttributes;
            this.UpdatedAt = UpdatedAt;
            this.AutoUpdate = AutoUpdate;
            this.BootstrappedTimestamp = BootstrappedTimestamp;
            this.VendorId = VendorId;
            this.Name = Name;
            this.DeviceClass = DeviceClass;
            this.Etag = Etag;
            this.Id = Id;
            this.State = State;
            this.DeployedState = DeployedState;
            this._Object = _Object;
            this.Deployment = Deployment;
            
        }
        
    
        /// <summary>
        /// DEPRECATED: The ID of the device
        /// </summary>
        /// <value>DEPRECATED: The ID of the device</value>
        [DataMember(Name="device_id", EmitDefaultValue=false)]
        public string DeviceId { get; set; }
    
        /// <summary>
        /// The address of the connector to use
        /// </summary>
        /// <value>The address of the connector to use</value>
        [DataMember(Name="mechanism_url", EmitDefaultValue=false)]
        public string MechanismUrl { get; set; }
    
        /// <summary>
        /// URL for the current device manifest
        /// </summary>
        /// <value>URL for the current device manifest</value>
        [DataMember(Name="manifest", EmitDefaultValue=false)]
        public string Manifest { get; set; }
    
        /// <summary>
        /// The key used to provision the device
        /// </summary>
        /// <value>The key used to provision the device</value>
        [DataMember(Name="provision_key", EmitDefaultValue=false)]
        public string ProvisionKey { get; set; }
    
        /// <summary>
        /// The description of the object
        /// </summary>
        /// <value>The description of the object</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
    
        /// <summary>
        /// The device trust class
        /// </summary>
        /// <value>The device trust class</value>
        [DataMember(Name="trust_class", EmitDefaultValue=false)]
        public long? TrustClass { get; set; }
    
        /// <summary>
        /// The device trust level
        /// </summary>
        /// <value>The device trust level</value>
        [DataMember(Name="trust_level", EmitDefaultValue=false)]
        public long? TrustLevel { get; set; }
    
        /// <summary>
        /// The time the object was created
        /// </summary>
        /// <value>The time the object was created</value>
        [DataMember(Name="created_at", EmitDefaultValue=false)]
        public DateTime? CreatedAt { get; set; }
    
        /// <summary>
        /// The serial number of the device
        /// </summary>
        /// <value>The serial number of the device</value>
        [DataMember(Name="serial_number", EmitDefaultValue=false)]
        public string SerialNumber { get; set; }
    
        /// <summary>
        /// Up to 5 custom JSON attributes
        /// </summary>
        /// <value>Up to 5 custom JSON attributes</value>
        [DataMember(Name="custom_attributes", EmitDefaultValue=false)]
        public string CustomAttributes { get; set; }
    
        /// <summary>
        /// The owning IAM account ID
        /// </summary>
        /// <value>The owning IAM account ID</value>
        [DataMember(Name="account_id", EmitDefaultValue=false)]
        public string AccountId { get; set; }
    
        /// <summary>
        /// The time the object was updated
        /// </summary>
        /// <value>The time the object was updated</value>
        [DataMember(Name="updated_at", EmitDefaultValue=false)]
        public DateTime? UpdatedAt { get; set; }
    
        /// <summary>
        /// Mark this device for auto firmware update
        /// </summary>
        /// <value>Mark this device for auto firmware update</value>
        [DataMember(Name="auto_update", EmitDefaultValue=false)]
        public bool? AutoUpdate { get; set; }
    
        /// <summary>
        /// Gets or Sets BootstrappedTimestamp
        /// </summary>
        [DataMember(Name="bootstrapped_timestamp", EmitDefaultValue=false)]
        public string BootstrappedTimestamp { get; set; }
    
        /// <summary>
        /// The device vendor ID
        /// </summary>
        /// <value>The device vendor ID</value>
        [DataMember(Name="vendor_id", EmitDefaultValue=false)]
        public string VendorId { get; set; }
    
        /// <summary>
        /// The name of the object
        /// </summary>
        /// <value>The name of the object</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
    
        /// <summary>
        /// The device class
        /// </summary>
        /// <value>The device class</value>
        [DataMember(Name="device_class", EmitDefaultValue=false)]
        public string DeviceClass { get; set; }
    
        /// <summary>
        /// The entity instance signature
        /// </summary>
        /// <value>The entity instance signature</value>
        [DataMember(Name="etag", EmitDefaultValue=false)]
        public DateTime? Etag { get; set; }
    
        /// <summary>
        /// The ID of the device
        /// </summary>
        /// <value>The ID of the device</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
    
        /// <summary>
        /// The API resource entity
        /// </summary>
        /// <value>The API resource entity</value>
        [DataMember(Name="object", EmitDefaultValue=false)]
        public string _Object { get; set; }
    
        /// <summary>
        /// The last deployment used on the device
        /// </summary>
        /// <value>The last deployment used on the device</value>
        [DataMember(Name="deployment", EmitDefaultValue=false)]
        public string Deployment { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeviceSerializerData {\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
            sb.Append("  MechanismUrl: ").Append(MechanismUrl).Append("\n");
            sb.Append("  Manifest: ").Append(Manifest).Append("\n");
            sb.Append("  ProvisionKey: ").Append(ProvisionKey).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  TrustClass: ").Append(TrustClass).Append("\n");
            sb.Append("  TrustLevel: ").Append(TrustLevel).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  SerialNumber: ").Append(SerialNumber).Append("\n");
            sb.Append("  CustomAttributes: ").Append(CustomAttributes).Append("\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  AutoUpdate: ").Append(AutoUpdate).Append("\n");
            sb.Append("  BootstrappedTimestamp: ").Append(BootstrappedTimestamp).Append("\n");
            sb.Append("  VendorId: ").Append(VendorId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  DeviceClass: ").Append(DeviceClass).Append("\n");
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Mechanism: ").Append(Mechanism).Append("\n");
            sb.Append("  DeployedState: ").Append(DeployedState).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  Deployment: ").Append(Deployment).Append("\n");
            
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as DeviceSerializerData);
        }

        /// <summary>
        /// Returns true if DeviceSerializerData instances are equal
        /// </summary>
        /// <param name="other">Instance of DeviceSerializerData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeviceSerializerData other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.DeviceId == other.DeviceId ||
                    this.DeviceId != null &&
                    this.DeviceId.Equals(other.DeviceId)
                ) && 
                (
                    this.MechanismUrl == other.MechanismUrl ||
                    this.MechanismUrl != null &&
                    this.MechanismUrl.Equals(other.MechanismUrl)
                ) && 
                (
                    this.Manifest == other.Manifest ||
                    this.Manifest != null &&
                    this.Manifest.Equals(other.Manifest)
                ) && 
                (
                    this.ProvisionKey == other.ProvisionKey ||
                    this.ProvisionKey != null &&
                    this.ProvisionKey.Equals(other.ProvisionKey)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.TrustClass == other.TrustClass ||
                    this.TrustClass != null &&
                    this.TrustClass.Equals(other.TrustClass)
                ) && 
                (
                    this.TrustLevel == other.TrustLevel ||
                    this.TrustLevel != null &&
                    this.TrustLevel.Equals(other.TrustLevel)
                ) && 
                (
                    this.CreatedAt == other.CreatedAt ||
                    this.CreatedAt != null &&
                    this.CreatedAt.Equals(other.CreatedAt)
                ) && 
                (
                    this.SerialNumber == other.SerialNumber ||
                    this.SerialNumber != null &&
                    this.SerialNumber.Equals(other.SerialNumber)
                ) && 
                (
                    this.CustomAttributes == other.CustomAttributes ||
                    this.CustomAttributes != null &&
                    this.CustomAttributes.Equals(other.CustomAttributes)
                ) && 
                (
                    this.AccountId == other.AccountId ||
                    this.AccountId != null &&
                    this.AccountId.Equals(other.AccountId)
                ) && 
                (
                    this.UpdatedAt == other.UpdatedAt ||
                    this.UpdatedAt != null &&
                    this.UpdatedAt.Equals(other.UpdatedAt)
                ) && 
                (
                    this.AutoUpdate == other.AutoUpdate ||
                    this.AutoUpdate != null &&
                    this.AutoUpdate.Equals(other.AutoUpdate)
                ) && 
                (
                    this.BootstrappedTimestamp == other.BootstrappedTimestamp ||
                    this.BootstrappedTimestamp != null &&
                    this.BootstrappedTimestamp.Equals(other.BootstrappedTimestamp)
                ) && 
                (
                    this.VendorId == other.VendorId ||
                    this.VendorId != null &&
                    this.VendorId.Equals(other.VendorId)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.DeviceClass == other.DeviceClass ||
                    this.DeviceClass != null &&
                    this.DeviceClass.Equals(other.DeviceClass)
                ) && 
                (
                    this.Etag == other.Etag ||
                    this.Etag != null &&
                    this.Etag.Equals(other.Etag)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.State == other.State ||
                    this.State != null &&
                    this.State.Equals(other.State)
                ) && 
                (
                    this.Mechanism == other.Mechanism ||
                    this.Mechanism != null &&
                    this.Mechanism.Equals(other.Mechanism)
                ) && 
                (
                    this.DeployedState == other.DeployedState ||
                    this.DeployedState != null &&
                    this.DeployedState.Equals(other.DeployedState)
                ) && 
                (
                    this._Object == other._Object ||
                    this._Object != null &&
                    this._Object.Equals(other._Object)
                ) && 
                (
                    this.Deployment == other.Deployment ||
                    this.Deployment != null &&
                    this.Deployment.Equals(other.Deployment)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                
                if (this.DeviceId != null)
                    hash = hash * 59 + this.DeviceId.GetHashCode();
                
                if (this.MechanismUrl != null)
                    hash = hash * 59 + this.MechanismUrl.GetHashCode();
                
                if (this.Manifest != null)
                    hash = hash * 59 + this.Manifest.GetHashCode();
                
                if (this.ProvisionKey != null)
                    hash = hash * 59 + this.ProvisionKey.GetHashCode();
                
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                
                if (this.TrustClass != null)
                    hash = hash * 59 + this.TrustClass.GetHashCode();
                
                if (this.TrustLevel != null)
                    hash = hash * 59 + this.TrustLevel.GetHashCode();
                
                if (this.CreatedAt != null)
                    hash = hash * 59 + this.CreatedAt.GetHashCode();
                
                if (this.SerialNumber != null)
                    hash = hash * 59 + this.SerialNumber.GetHashCode();
                
                if (this.CustomAttributes != null)
                    hash = hash * 59 + this.CustomAttributes.GetHashCode();
                
                if (this.AccountId != null)
                    hash = hash * 59 + this.AccountId.GetHashCode();
                
                if (this.UpdatedAt != null)
                    hash = hash * 59 + this.UpdatedAt.GetHashCode();
                
                if (this.AutoUpdate != null)
                    hash = hash * 59 + this.AutoUpdate.GetHashCode();
                
                if (this.BootstrappedTimestamp != null)
                    hash = hash * 59 + this.BootstrappedTimestamp.GetHashCode();
                
                if (this.VendorId != null)
                    hash = hash * 59 + this.VendorId.GetHashCode();
                
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                
                if (this.DeviceClass != null)
                    hash = hash * 59 + this.DeviceClass.GetHashCode();
                
                if (this.Etag != null)
                    hash = hash * 59 + this.Etag.GetHashCode();
                
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                
                if (this.State != null)
                    hash = hash * 59 + this.State.GetHashCode();
                
                if (this.Mechanism != null)
                    hash = hash * 59 + this.Mechanism.GetHashCode();
                
                if (this.DeployedState != null)
                    hash = hash * 59 + this.DeployedState.GetHashCode();
                
                if (this._Object != null)
                    hash = hash * 59 + this._Object.GetHashCode();
                
                if (this.Deployment != null)
                    hash = hash * 59 + this.Deployment.GetHashCode();
                
                return hash;
            }
        }

    }
}
