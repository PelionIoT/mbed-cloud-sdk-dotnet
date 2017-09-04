/* 
 * Update Service API
 *
 * This is the API documentation for the Mbed deployment service, which is part of the update service.
 *
 * OpenAPI spec version: 3
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace update_service.Model
{
    /// <summary>
    /// CampaignDeviceMetadata
    /// </summary>
    [DataContract]
    public partial class CampaignDeviceMetadata :  IEquatable<CampaignDeviceMetadata>, IValidatableObject
    {
        /// <summary>
        /// The state of the update campaign on the device
        /// </summary>
        /// <value>The state of the update campaign on the device</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum DeploymentStateEnum
        {
            
            /// <summary>
            /// Enum Pending for "pending"
            /// </summary>
            [EnumMember(Value = "pending")]
            Pending,
            
            /// <summary>
            /// Enum Updatedconnectorchannel for "updated_connector_channel"
            /// </summary>
            [EnumMember(Value = "updated_connector_channel")]
            Updatedconnectorchannel,
            
            /// <summary>
            /// Enum Failedconnectorchannelupdate for "failed_connector_channel_update"
            /// </summary>
            [EnumMember(Value = "failed_connector_channel_update")]
            Failedconnectorchannelupdate,
            
            /// <summary>
            /// Enum Deployed for "deployed"
            /// </summary>
            [EnumMember(Value = "deployed")]
            Deployed,
            
            /// <summary>
            /// Enum Manifestremoved for "manifestremoved"
            /// </summary>
            [EnumMember(Value = "manifestremoved")]
            Manifestremoved
        }

        /// <summary>
        /// The state of the update campaign on the device
        /// </summary>
        /// <value>The state of the update campaign on the device</value>
        [DataMember(Name="deployment_state", EmitDefaultValue=false)]
        public DeploymentStateEnum? DeploymentState { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignDeviceMetadata" /> class.
        /// </summary>
        /// <param name="Description">Description.</param>
        /// <param name="Campaign">The device&#39;s campaign ID.</param>
        /// <param name="CreatedAt">The time the campaign was created.</param>
        /// <param name="_Object">Entity name: always &#39;update-campaign-device-metadata&#39;.</param>
        /// <param name="UpdatedAt">This time this record was modified in the database format: date-time.</param>
        /// <param name="Mechanism">How the firmware is delivered (connector or direct).</param>
        /// <param name="Name">The record name.</param>
        /// <param name="Etag">API resource entity version.</param>
        /// <param name="MechanismUrl">The Cloud Connect URL.</param>
        /// <param name="DeploymentState">The state of the update campaign on the device.</param>
        /// <param name="Id">The metadata record ID.</param>
        /// <param name="DeviceId">The device ID.</param>
        public CampaignDeviceMetadata(string Description = default(string), string Campaign = default(string), DateTime? CreatedAt = default(DateTime?), string _Object = default(string), DateTime? UpdatedAt = default(DateTime?), string Mechanism = default(string), string Name = default(string), string Etag = default(string), string MechanismUrl = default(string), DeploymentStateEnum? DeploymentState = default(DeploymentStateEnum?), string Id = default(string), string DeviceId = default(string))
        {
            this.Description = Description;
            this.Campaign = Campaign;
            this.CreatedAt = CreatedAt;
            this._Object = _Object;
            this.UpdatedAt = UpdatedAt;
            this.Mechanism = Mechanism;
            this.Name = Name;
            this.Etag = Etag;
            this.MechanismUrl = MechanismUrl;
            this.DeploymentState = DeploymentState;
            this.Id = Id;
            this.DeviceId = DeviceId;
        }
        
        /// <summary>
        /// Description
        /// </summary>
        /// <value>Description</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        /// The device&#39;s campaign ID
        /// </summary>
        /// <value>The device&#39;s campaign ID</value>
        [DataMember(Name="campaign", EmitDefaultValue=false)]
        public string Campaign { get; set; }
        /// <summary>
        /// The time the campaign was created
        /// </summary>
        /// <value>The time the campaign was created</value>
        [DataMember(Name="created_at", EmitDefaultValue=false)]
        public DateTime? CreatedAt { get; set; }
        /// <summary>
        /// Entity name: always &#39;update-campaign-device-metadata&#39;
        /// </summary>
        /// <value>Entity name: always &#39;update-campaign-device-metadata&#39;</value>
        [DataMember(Name="object", EmitDefaultValue=false)]
        public string _Object { get; set; }
        /// <summary>
        /// This time this record was modified in the database format: date-time
        /// </summary>
        /// <value>This time this record was modified in the database format: date-time</value>
        [DataMember(Name="updated_at", EmitDefaultValue=false)]
        public DateTime? UpdatedAt { get; set; }
        /// <summary>
        /// How the firmware is delivered (connector or direct)
        /// </summary>
        /// <value>How the firmware is delivered (connector or direct)</value>
        [DataMember(Name="mechanism", EmitDefaultValue=false)]
        public string Mechanism { get; set; }
        /// <summary>
        /// The record name
        /// </summary>
        /// <value>The record name</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// API resource entity version
        /// </summary>
        /// <value>API resource entity version</value>
        [DataMember(Name="etag", EmitDefaultValue=false)]
        public string Etag { get; set; }
        /// <summary>
        /// The Cloud Connect URL
        /// </summary>
        /// <value>The Cloud Connect URL</value>
        [DataMember(Name="mechanism_url", EmitDefaultValue=false)]
        public string MechanismUrl { get; set; }
        /// <summary>
        /// The metadata record ID
        /// </summary>
        /// <value>The metadata record ID</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        /// The device ID
        /// </summary>
        /// <value>The device ID</value>
        [DataMember(Name="device_id", EmitDefaultValue=false)]
        public string DeviceId { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CampaignDeviceMetadata {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Campaign: ").Append(Campaign).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Mechanism: ").Append(Mechanism).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("  MechanismUrl: ").Append(MechanismUrl).Append("\n");
            sb.Append("  DeploymentState: ").Append(DeploymentState).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
            return this.Equals(obj as CampaignDeviceMetadata);
        }

        /// <summary>
        /// Returns true if CampaignDeviceMetadata instances are equal
        /// </summary>
        /// <param name="other">Instance of CampaignDeviceMetadata to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CampaignDeviceMetadata other)
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
                    this.CreatedAt == other.CreatedAt ||
                    this.CreatedAt != null &&
                    this.CreatedAt.Equals(other.CreatedAt)
                ) && 
                (
                    this._Object == other._Object ||
                    this._Object != null &&
                    this._Object.Equals(other._Object)
                ) && 
                (
                    this.UpdatedAt == other.UpdatedAt ||
                    this.UpdatedAt != null &&
                    this.UpdatedAt.Equals(other.UpdatedAt)
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
                    this.Etag == other.Etag ||
                    this.Etag != null &&
                    this.Etag.Equals(other.Etag)
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
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
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
                if (this.CreatedAt != null)
                    hash = hash * 59 + this.CreatedAt.GetHashCode();
                if (this._Object != null)
                    hash = hash * 59 + this._Object.GetHashCode();
                if (this.UpdatedAt != null)
                    hash = hash * 59 + this.UpdatedAt.GetHashCode();
                if (this.Mechanism != null)
                    hash = hash * 59 + this.Mechanism.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.Etag != null)
                    hash = hash * 59 + this.Etag.GetHashCode();
                if (this.MechanismUrl != null)
                    hash = hash * 59 + this.MechanismUrl.GetHashCode();
                if (this.DeploymentState != null)
                    hash = hash * 59 + this.DeploymentState.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.DeviceId != null)
                    hash = hash * 59 + this.DeviceId.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
