/* 
 * <auto-generated>
 * Update Service API
 *
 * This is the API documentation for the Mbed deployment service, which is part of the update service.
 *
 * OpenAPI spec version: 3
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 * </auto-generated>
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
using SwaggerDateConverter = update_service.Client.SwaggerDateConverter;

namespace update_service.Model
{
    /// <summary>
    /// UpdateCampaignPutRequest
    /// </summary>
    [DataContract]
    public partial class UpdateCampaignPutRequest :  IEquatable<UpdateCampaignPutRequest>, IValidatableObject
    {
        /// <summary>
        /// The state of the campaign
        /// </summary>
        /// <value>The state of the campaign</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StateEnum
        {
            
            /// <summary>
            /// Enum Draft for "draft"
            /// </summary>
            [EnumMember(Value = "draft")]
            Draft,
            
            /// <summary>
            /// Enum Scheduled for "scheduled"
            /// </summary>
            [EnumMember(Value = "scheduled")]
            Scheduled,
            
            /// <summary>
            /// Enum Allocatingquota for "allocatingquota"
            /// </summary>
            [EnumMember(Value = "allocatingquota")]
            Allocatingquota,
            
            /// <summary>
            /// Enum Allocatedquota for "allocatedquota"
            /// </summary>
            [EnumMember(Value = "allocatedquota")]
            Allocatedquota,
            
            /// <summary>
            /// Enum Quotaallocationfailed for "quotaallocationfailed"
            /// </summary>
            [EnumMember(Value = "quotaallocationfailed")]
            Quotaallocationfailed,
            
            /// <summary>
            /// Enum Checkingmanifest for "checkingmanifest"
            /// </summary>
            [EnumMember(Value = "checkingmanifest")]
            Checkingmanifest,
            
            /// <summary>
            /// Enum Checkedmanifest for "checkedmanifest"
            /// </summary>
            [EnumMember(Value = "checkedmanifest")]
            Checkedmanifest,
            
            /// <summary>
            /// Enum Devicefetch for "devicefetch"
            /// </summary>
            [EnumMember(Value = "devicefetch")]
            Devicefetch,
            
            /// <summary>
            /// Enum Devicecopy for "devicecopy"
            /// </summary>
            [EnumMember(Value = "devicecopy")]
            Devicecopy,
            
            /// <summary>
            /// Enum Devicecheck for "devicecheck"
            /// </summary>
            [EnumMember(Value = "devicecheck")]
            Devicecheck,
            
            /// <summary>
            /// Enum Publishing for "publishing"
            /// </summary>
            [EnumMember(Value = "publishing")]
            Publishing,
            
            /// <summary>
            /// Enum Deploying for "deploying"
            /// </summary>
            [EnumMember(Value = "deploying")]
            Deploying,
            
            /// <summary>
            /// Enum Deployed for "deployed"
            /// </summary>
            [EnumMember(Value = "deployed")]
            Deployed,
            
            /// <summary>
            /// Enum Manifestremoved for "manifestremoved"
            /// </summary>
            [EnumMember(Value = "manifestremoved")]
            Manifestremoved,
            
            /// <summary>
            /// Enum Expired for "expired"
            /// </summary>
            [EnumMember(Value = "expired")]
            Expired,
            
            /// <summary>
            /// Enum Stopping for "stopping"
            /// </summary>
            [EnumMember(Value = "stopping")]
            Stopping,
            
            /// <summary>
            /// Enum Autostopped for "autostopped"
            /// </summary>
            [EnumMember(Value = "autostopped")]
            Autostopped,
            
            /// <summary>
            /// Enum Userstopped for "userstopped"
            /// </summary>
            [EnumMember(Value = "userstopped")]
            Userstopped,
            
            /// <summary>
            /// Enum Conflict for "conflict"
            /// </summary>
            [EnumMember(Value = "conflict")]
            Conflict
        }

        /// <summary>
        /// The state of the campaign
        /// </summary>
        /// <value>The state of the campaign</value>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public StateEnum? State { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCampaignPutRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected UpdateCampaignPutRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCampaignPutRequest" /> class.
        /// </summary>
        /// <param name="Description">An optional description of the campaign (required).</param>
        /// <param name="DeviceFilter">The filter for the devices the campaign will target (required).</param>
        /// <param name="Name">The campaign&#39;s name (required).</param>
        /// <param name="_Object">The API resource entity (required).</param>
        /// <param name="RootManifestId">RootManifestId (required).</param>
        /// <param name="State">The state of the campaign (required).</param>
        /// <param name="When">The scheduled start time for the update campaign (required).</param>
        public UpdateCampaignPutRequest(string Description = default(string), string DeviceFilter = default(string), string Name = default(string), string _Object = default(string), string RootManifestId = default(string), StateEnum? State = default(StateEnum?), DateTime? When = default(DateTime?))
        {
            // to ensure "Description" is required (not null)
            if (Description == null)
            {
                throw new InvalidDataException("Description is a required property for UpdateCampaignPutRequest and cannot be null");
            }
            else
            {
                this.Description = Description;
            }
            // to ensure "DeviceFilter" is required (not null)
            if (DeviceFilter == null)
            {
                throw new InvalidDataException("DeviceFilter is a required property for UpdateCampaignPutRequest and cannot be null");
            }
            else
            {
                this.DeviceFilter = DeviceFilter;
            }
            // to ensure "Name" is required (not null)
            if (Name == null)
            {
                throw new InvalidDataException("Name is a required property for UpdateCampaignPutRequest and cannot be null");
            }
            else
            {
                this.Name = Name;
            }
            // to ensure "_Object" is required (not null)
            if (_Object == null)
            {
                throw new InvalidDataException("_Object is a required property for UpdateCampaignPutRequest and cannot be null");
            }
            else
            {
                this._Object = _Object;
            }
            // to ensure "RootManifestId" is required (not null)
            if (RootManifestId == null)
            {
                throw new InvalidDataException("RootManifestId is a required property for UpdateCampaignPutRequest and cannot be null");
            }
            else
            {
                this.RootManifestId = RootManifestId;
            }
            // to ensure "State" is required (not null)
            if (State == null)
            {
                throw new InvalidDataException("State is a required property for UpdateCampaignPutRequest and cannot be null");
            }
            else
            {
                this.State = State;
            }
            // to ensure "When" is required (not null)
            if (When == null)
            {
                throw new InvalidDataException("When is a required property for UpdateCampaignPutRequest and cannot be null");
            }
            else
            {
                this.When = When;
            }
        }
        
        /// <summary>
        /// An optional description of the campaign
        /// </summary>
        /// <value>An optional description of the campaign</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// The filter for the devices the campaign will target
        /// </summary>
        /// <value>The filter for the devices the campaign will target</value>
        [DataMember(Name="device_filter", EmitDefaultValue=false)]
        public string DeviceFilter { get; set; }

        /// <summary>
        /// The campaign&#39;s name
        /// </summary>
        /// <value>The campaign&#39;s name</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// The API resource entity
        /// </summary>
        /// <value>The API resource entity</value>
        [DataMember(Name="object", EmitDefaultValue=false)]
        public string _Object { get; set; }

        /// <summary>
        /// Gets or Sets RootManifestId
        /// </summary>
        [DataMember(Name="root_manifest_id", EmitDefaultValue=false)]
        public string RootManifestId { get; set; }


        /// <summary>
        /// The scheduled start time for the update campaign
        /// </summary>
        /// <value>The scheduled start time for the update campaign</value>
        [DataMember(Name="when", EmitDefaultValue=false)]
        public DateTime? When { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpdateCampaignPutRequest {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DeviceFilter: ").Append(DeviceFilter).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  RootManifestId: ").Append(RootManifestId).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  When: ").Append(When).Append("\n");
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
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as UpdateCampaignPutRequest);
        }

        /// <summary>
        /// Returns true if UpdateCampaignPutRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdateCampaignPutRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateCampaignPutRequest input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.DeviceFilter == input.DeviceFilter ||
                    (this.DeviceFilter != null &&
                    this.DeviceFilter.Equals(input.DeviceFilter))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this._Object == input._Object ||
                    (this._Object != null &&
                    this._Object.Equals(input._Object))
                ) && 
                (
                    this.RootManifestId == input.RootManifestId ||
                    (this.RootManifestId != null &&
                    this.RootManifestId.Equals(input.RootManifestId))
                ) && 
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
                ) && 
                (
                    this.When == input.When ||
                    (this.When != null &&
                    this.When.Equals(input.When))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.DeviceFilter != null)
                    hashCode = hashCode * 59 + this.DeviceFilter.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this._Object != null)
                    hashCode = hashCode * 59 + this._Object.GetHashCode();
                if (this.RootManifestId != null)
                    hashCode = hashCode * 59 + this.RootManifestId.GetHashCode();
                if (this.State != null)
                    hashCode = hashCode * 59 + this.State.GetHashCode();
                if (this.When != null)
                    hashCode = hashCode * 59 + this.When.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            // Description (string) maxLength
            if(this.Description != null && this.Description.Length > 2000)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Description, length must be less than 2000.", new [] { "Description" });
            }

            // Name (string) maxLength
            if(this.Name != null && this.Name.Length > 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 128.", new [] { "Name" });
            }

            // RootManifestId (string) maxLength
            if(this.RootManifestId != null && this.RootManifestId.Length > 32)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for RootManifestId, length must be less than 32.", new [] { "RootManifestId" });
            }

            yield break;
        }
    }

}
