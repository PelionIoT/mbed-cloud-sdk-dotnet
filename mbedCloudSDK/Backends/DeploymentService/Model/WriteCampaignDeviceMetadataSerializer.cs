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

namespace deployment_service.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class WriteCampaignDeviceMetadataSerializer :  IEquatable<WriteCampaignDeviceMetadataSerializer>
    { 
    
        /// <summary>
        /// The state of the deployment
        /// </summary>
        /// <value>The state of the deployment</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum DeploymentStateEnum {
            
            [EnumMember(Value = "pending")]
            Pending,
            
            [EnumMember(Value = "updated_device_catalog")]
            UpdatedDeviceCatalog,
            
            [EnumMember(Value = "updated_connector_channel")]
            UpdatedConnectorChannel,
            
            [EnumMember(Value = "deployed")]
            Deployed,
            
            [EnumMember(Value = "manifestremoved")]
            Manifestremoved
        }

    
        /// <summary>
        /// The state of the deployment
        /// </summary>
        /// <value>The state of the deployment</value>
        [DataMember(Name="deployment_state", EmitDefaultValue=false)]
        public DeploymentStateEnum? DeploymentState { get; set; }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="WriteCampaignDeviceMetadataSerializer" /> class.
        /// Initializes a new instance of the <see cref="WriteCampaignDeviceMetadataSerializer" />class.
        /// </summary>
        /// <param name="Description">The description of the object.</param>
        /// <param name="Campaign">The update campaign to which this device belongs (required).</param>
        /// <param name="_Object">The API resource entity.</param>
        /// <param name="Mechanism">The ID of the channel used to communicated with the device (required).</param>
        /// <param name="Name">The name of the object (required).</param>
        /// <param name="MechanismUrl">The address of the Connector to use.</param>
        /// <param name="DeploymentState">The state of the deployment.</param>
        /// <param name="DeviceId">The ID of the device to deploy (required).</param>

        public WriteCampaignDeviceMetadataSerializer(string Description = null, string Campaign = null, string _Object = null, string Mechanism = null, string Name = null, string MechanismUrl = null, DeploymentStateEnum? DeploymentState = null, string DeviceId = null)
        {
            // to ensure "Campaign" is required (not null)
            if (Campaign == null)
            {
                throw new InvalidDataException("Campaign is a required property for WriteCampaignDeviceMetadataSerializer and cannot be null");
            }
            else
            {
                this.Campaign = Campaign;
            }
            // to ensure "Mechanism" is required (not null)
            if (Mechanism == null)
            {
                throw new InvalidDataException("Mechanism is a required property for WriteCampaignDeviceMetadataSerializer and cannot be null");
            }
            else
            {
                this.Mechanism = Mechanism;
            }
            // to ensure "Name" is required (not null)
            if (Name == null)
            {
                throw new InvalidDataException("Name is a required property for WriteCampaignDeviceMetadataSerializer and cannot be null");
            }
            else
            {
                this.Name = Name;
            }
            // to ensure "DeviceId" is required (not null)
            if (DeviceId == null)
            {
                throw new InvalidDataException("DeviceId is a required property for WriteCampaignDeviceMetadataSerializer and cannot be null");
            }
            else
            {
                this.DeviceId = DeviceId;
            }
            this.Description = Description;
            this._Object = _Object;
            this.MechanismUrl = MechanismUrl;
            this.DeploymentState = DeploymentState;
            
        }
        
    
        /// <summary>
        /// The description of the object
        /// </summary>
        /// <value>The description of the object</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
    
        /// <summary>
        /// The update campaign to which this device belongs
        /// </summary>
        /// <value>The update campaign to which this device belongs</value>
        [DataMember(Name="campaign", EmitDefaultValue=false)]
        public string Campaign { get; set; }
    
        /// <summary>
        /// The API resource entity
        /// </summary>
        /// <value>The API resource entity</value>
        [DataMember(Name="object", EmitDefaultValue=false)]
        public string _Object { get; set; }
    
        /// <summary>
        /// The ID of the channel used to communicated with the device
        /// </summary>
        /// <value>The ID of the channel used to communicated with the device</value>
        [DataMember(Name="mechanism", EmitDefaultValue=false)]
        public string Mechanism { get; set; }
    
        /// <summary>
        /// The name of the object
        /// </summary>
        /// <value>The name of the object</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
    
        /// <summary>
        /// The address of the Connector to use
        /// </summary>
        /// <value>The address of the Connector to use</value>
        [DataMember(Name="mechanism_url", EmitDefaultValue=false)]
        public string MechanismUrl { get; set; }
    
        /// <summary>
        /// The ID of the device to deploy
        /// </summary>
        /// <value>The ID of the device to deploy</value>
        [DataMember(Name="device_id", EmitDefaultValue=false)]
        public string DeviceId { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WriteCampaignDeviceMetadataSerializer {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Campaign: ").Append(Campaign).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  Mechanism: ").Append(Mechanism).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  MechanismUrl: ").Append(MechanismUrl).Append("\n");
            sb.Append("  DeploymentState: ").Append(DeploymentState).Append("\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
            
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
            return this.Equals(obj as WriteCampaignDeviceMetadataSerializer);
        }

        /// <summary>
        /// Returns true if WriteCampaignDeviceMetadataSerializer instances are equal
        /// </summary>
        /// <param name="other">Instance of WriteCampaignDeviceMetadataSerializer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WriteCampaignDeviceMetadataSerializer other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.Campaign == other.Campaign ||
                    this.Campaign != null &&
                    this.Campaign.Equals(other.Campaign)
                ) && 
                (
                    this._Object == other._Object ||
                    this._Object != null &&
                    this._Object.Equals(other._Object)
                ) && 
                (
                    this.Mechanism == other.Mechanism ||
                    this.Mechanism != null &&
                    this.Mechanism.Equals(other.Mechanism)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.MechanismUrl == other.MechanismUrl ||
                    this.MechanismUrl != null &&
                    this.MechanismUrl.Equals(other.MechanismUrl)
                ) && 
                (
                    this.DeploymentState == other.DeploymentState ||
                    this.DeploymentState != null &&
                    this.DeploymentState.Equals(other.DeploymentState)
                ) && 
                (
                    this.DeviceId == other.DeviceId ||
                    this.DeviceId != null &&
                    this.DeviceId.Equals(other.DeviceId)
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
                
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                
                if (this.Campaign != null)
                    hash = hash * 59 + this.Campaign.GetHashCode();
                
                if (this._Object != null)
                    hash = hash * 59 + this._Object.GetHashCode();
                
                if (this.Mechanism != null)
                    hash = hash * 59 + this.Mechanism.GetHashCode();
                
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                
                if (this.MechanismUrl != null)
                    hash = hash * 59 + this.MechanismUrl.GetHashCode();
                
                if (this.DeploymentState != null)
                    hash = hash * 59 + this.DeploymentState.GetHashCode();
                
                if (this.DeviceId != null)
                    hash = hash * 59 + this.DeviceId.GetHashCode();
                
                return hash;
            }
        }

    }
}
