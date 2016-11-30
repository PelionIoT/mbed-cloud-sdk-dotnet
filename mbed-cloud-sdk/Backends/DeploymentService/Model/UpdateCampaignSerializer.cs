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
    public partial class UpdateCampaignSerializer :  IEquatable<UpdateCampaignSerializer>
    { 
    
        /// <summary>
        /// The state of the campaign
        /// </summary>
        /// <value>The state of the campaign</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StateEnum {
            
            [EnumMember(Value = "draft")]
            Draft,
            
            [EnumMember(Value = "scheduled")]
            Scheduled,
            
            [EnumMember(Value = "devicefetch")]
            Devicefetch,
            
            [EnumMember(Value = "devicecopy")]
            Devicecopy,
            
            [EnumMember(Value = "devicecopycomplete")]
            Devicecopycomplete,
            
            [EnumMember(Value = "publishing")]
            Publishing,
            
            [EnumMember(Value = "deploying")]
            Deploying,
            
            [EnumMember(Value = "deployed")]
            Deployed,
            
            [EnumMember(Value = "manifestremoved")]
            Manifestremoved,
            
            [EnumMember(Value = "expired")]
            Expired
        }

    
        /// <summary>
        /// The state of the campaign
        /// </summary>
        /// <value>The state of the campaign</value>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public StateEnum? State { get; set; }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCampaignSerializer" /> class.
        /// Initializes a new instance of the <see cref="UpdateCampaignSerializer" />class.
        /// </summary>
        /// <param name="Description">An optional description of the campaign (required).</param>
        /// <param name="State">The state of the campaign (required).</param>
        /// <param name="UpdatingUserId">The updating IAM user ID (required).</param>
        /// <param name="CreatedAt">The time the object was created (required).</param>
        /// <param name="_Object">The API resource entity (required).</param>
        /// <param name="RootManifestId">RootManifestId (required).</param>
        /// <param name="CampaignId">DEPRECATED: The ID of the campaign (required).</param>
        /// <param name="UpdatingAccountId">The updating account ID (required).</param>
        /// <param name="UpdatedAt">The time the object was updated (required).</param>
        /// <param name="When">The timestamp at which update campaign scheduled to start (required).</param>
        /// <param name="Finished">The timestamp when the update campaign finished (required).</param>
        /// <param name="Etag">The entity instance signature (required).</param>
        /// <param name="RootManifestUrl">RootManifestUrl (required).</param>
        /// <param name="UpdatingApiKey">The gateway client API key (required).</param>
        /// <param name="Id">The ID of the campaign (required).</param>
        /// <param name="DeviceFilter">The filter for the devices the campaign will target (required).</param>
        /// <param name="Name">A name for this campaign (required).</param>

        public UpdateCampaignSerializer(string Description = null, StateEnum? State = null, string UpdatingUserId = null, DateTime? CreatedAt = null, string _Object = null, string RootManifestId = null, string CampaignId = null, string UpdatingAccountId = null, DateTime? UpdatedAt = null, DateTime? When = null, DateTime? Finished = null, DateTime? Etag = null, string RootManifestUrl = null, string UpdatingApiKey = null, string Id = null, string DeviceFilter = null, string Name = null)
        {
            // to ensure "Description" is required (not null)
            if (Description == null)
            {
                throw new InvalidDataException("Description is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.Description = Description;
            }
            // to ensure "State" is required (not null)
            if (State == null)
            {
                throw new InvalidDataException("State is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.State = State;
            }
            // to ensure "UpdatingUserId" is required (not null)
            if (UpdatingUserId == null)
            {
                throw new InvalidDataException("UpdatingUserId is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.UpdatingUserId = UpdatingUserId;
            }
            // to ensure "CreatedAt" is required (not null)
            if (CreatedAt == null)
            {
                throw new InvalidDataException("CreatedAt is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.CreatedAt = CreatedAt;
            }
            // to ensure "_Object" is required (not null)
            if (_Object == null)
            {
                throw new InvalidDataException("_Object is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this._Object = _Object;
            }
            // to ensure "RootManifestId" is required (not null)
            if (RootManifestId == null)
            {
                throw new InvalidDataException("RootManifestId is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.RootManifestId = RootManifestId;
            }
            // to ensure "CampaignId" is required (not null)
            if (CampaignId == null)
            {
                throw new InvalidDataException("CampaignId is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.CampaignId = CampaignId;
            }
            // to ensure "UpdatingAccountId" is required (not null)
            if (UpdatingAccountId == null)
            {
                throw new InvalidDataException("UpdatingAccountId is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.UpdatingAccountId = UpdatingAccountId;
            }
            // to ensure "UpdatedAt" is required (not null)
            if (UpdatedAt == null)
            {
                throw new InvalidDataException("UpdatedAt is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.UpdatedAt = UpdatedAt;
            }
            // to ensure "When" is required (not null)
            if (When == null)
            {
                throw new InvalidDataException("When is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.When = When;
            }
            // to ensure "Finished" is required (not null)
            if (Finished == null)
            {
                throw new InvalidDataException("Finished is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.Finished = Finished;
            }
            // to ensure "Etag" is required (not null)
            if (Etag == null)
            {
                throw new InvalidDataException("Etag is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.Etag = Etag;
            }
            // to ensure "RootManifestUrl" is required (not null)
            if (RootManifestUrl == null)
            {
                throw new InvalidDataException("RootManifestUrl is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.RootManifestUrl = RootManifestUrl;
            }
            // to ensure "UpdatingApiKey" is required (not null)
            if (UpdatingApiKey == null)
            {
                throw new InvalidDataException("UpdatingApiKey is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.UpdatingApiKey = UpdatingApiKey;
            }
            // to ensure "Id" is required (not null)
            if (Id == null)
            {
                throw new InvalidDataException("Id is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.Id = Id;
            }
            // to ensure "DeviceFilter" is required (not null)
            if (DeviceFilter == null)
            {
                throw new InvalidDataException("DeviceFilter is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.DeviceFilter = DeviceFilter;
            }
            // to ensure "Name" is required (not null)
            if (Name == null)
            {
                throw new InvalidDataException("Name is a required property for UpdateCampaignSerializer and cannot be null");
            }
            else
            {
                this.Name = Name;
            }
            
        }
        
    
        /// <summary>
        /// An optional description of the campaign
        /// </summary>
        /// <value>An optional description of the campaign</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
    
        /// <summary>
        /// The updating IAM user ID
        /// </summary>
        /// <value>The updating IAM user ID</value>
        [DataMember(Name="updating_user_id", EmitDefaultValue=false)]
        public string UpdatingUserId { get; set; }
    
        /// <summary>
        /// The time the object was created
        /// </summary>
        /// <value>The time the object was created</value>
        [DataMember(Name="created_at", EmitDefaultValue=false)]
        public DateTime? CreatedAt { get; set; }
    
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
        /// DEPRECATED: The ID of the campaign
        /// </summary>
        /// <value>DEPRECATED: The ID of the campaign</value>
        [DataMember(Name="campaign_id", EmitDefaultValue=false)]
        public string CampaignId { get; set; }
    
        /// <summary>
        /// The updating account ID
        /// </summary>
        /// <value>The updating account ID</value>
        [DataMember(Name="updating_account_id", EmitDefaultValue=false)]
        public string UpdatingAccountId { get; set; }
    
        /// <summary>
        /// The time the object was updated
        /// </summary>
        /// <value>The time the object was updated</value>
        [DataMember(Name="updated_at", EmitDefaultValue=false)]
        public DateTime? UpdatedAt { get; set; }
    
        /// <summary>
        /// The timestamp at which update campaign scheduled to start
        /// </summary>
        /// <value>The timestamp at which update campaign scheduled to start</value>
        [DataMember(Name="when", EmitDefaultValue=false)]
        public DateTime? When { get; set; }
    
        /// <summary>
        /// The timestamp when the update campaign finished
        /// </summary>
        /// <value>The timestamp when the update campaign finished</value>
        [DataMember(Name="finished", EmitDefaultValue=false)]
        public DateTime? Finished { get; set; }
    
        /// <summary>
        /// The entity instance signature
        /// </summary>
        /// <value>The entity instance signature</value>
        [DataMember(Name="etag", EmitDefaultValue=false)]
        public DateTime? Etag { get; set; }
    
        /// <summary>
        /// Gets or Sets RootManifestUrl
        /// </summary>
        [DataMember(Name="root_manifest_url", EmitDefaultValue=false)]
        public string RootManifestUrl { get; set; }
    
        /// <summary>
        /// The gateway client API key
        /// </summary>
        /// <value>The gateway client API key</value>
        [DataMember(Name="updating_api_key", EmitDefaultValue=false)]
        public string UpdatingApiKey { get; set; }
    
        /// <summary>
        /// The ID of the campaign
        /// </summary>
        /// <value>The ID of the campaign</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
    
        /// <summary>
        /// The filter for the devices the campaign will target
        /// </summary>
        /// <value>The filter for the devices the campaign will target</value>
        [DataMember(Name="device_filter", EmitDefaultValue=false)]
        public string DeviceFilter { get; set; }
    
        /// <summary>
        /// A name for this campaign
        /// </summary>
        /// <value>A name for this campaign</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpdateCampaignSerializer {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  UpdatingUserId: ").Append(UpdatingUserId).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  RootManifestId: ").Append(RootManifestId).Append("\n");
            sb.Append("  CampaignId: ").Append(CampaignId).Append("\n");
            sb.Append("  UpdatingAccountId: ").Append(UpdatingAccountId).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  When: ").Append(When).Append("\n");
            sb.Append("  Finished: ").Append(Finished).Append("\n");
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("  RootManifestUrl: ").Append(RootManifestUrl).Append("\n");
            sb.Append("  UpdatingApiKey: ").Append(UpdatingApiKey).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DeviceFilter: ").Append(DeviceFilter).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            
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
            return this.Equals(obj as UpdateCampaignSerializer);
        }

        /// <summary>
        /// Returns true if UpdateCampaignSerializer instances are equal
        /// </summary>
        /// <param name="other">Instance of UpdateCampaignSerializer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateCampaignSerializer other)
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
                    this.State == other.State ||
                    this.State != null &&
                    this.State.Equals(other.State)
                ) && 
                (
                    this.UpdatingUserId == other.UpdatingUserId ||
                    this.UpdatingUserId != null &&
                    this.UpdatingUserId.Equals(other.UpdatingUserId)
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
                    this.RootManifestId == other.RootManifestId ||
                    this.RootManifestId != null &&
                    this.RootManifestId.Equals(other.RootManifestId)
                ) && 
                (
                    this.CampaignId == other.CampaignId ||
                    this.CampaignId != null &&
                    this.CampaignId.Equals(other.CampaignId)
                ) && 
                (
                    this.UpdatingAccountId == other.UpdatingAccountId ||
                    this.UpdatingAccountId != null &&
                    this.UpdatingAccountId.Equals(other.UpdatingAccountId)
                ) && 
                (
                    this.UpdatedAt == other.UpdatedAt ||
                    this.UpdatedAt != null &&
                    this.UpdatedAt.Equals(other.UpdatedAt)
                ) && 
                (
                    this.When == other.When ||
                    this.When != null &&
                    this.When.Equals(other.When)
                ) && 
                (
                    this.Finished == other.Finished ||
                    this.Finished != null &&
                    this.Finished.Equals(other.Finished)
                ) && 
                (
                    this.Etag == other.Etag ||
                    this.Etag != null &&
                    this.Etag.Equals(other.Etag)
                ) && 
                (
                    this.RootManifestUrl == other.RootManifestUrl ||
                    this.RootManifestUrl != null &&
                    this.RootManifestUrl.Equals(other.RootManifestUrl)
                ) && 
                (
                    this.UpdatingApiKey == other.UpdatingApiKey ||
                    this.UpdatingApiKey != null &&
                    this.UpdatingApiKey.Equals(other.UpdatingApiKey)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.DeviceFilter == other.DeviceFilter ||
                    this.DeviceFilter != null &&
                    this.DeviceFilter.Equals(other.DeviceFilter)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
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
                
                if (this.State != null)
                    hash = hash * 59 + this.State.GetHashCode();
                
                if (this.UpdatingUserId != null)
                    hash = hash * 59 + this.UpdatingUserId.GetHashCode();
                
                if (this.CreatedAt != null)
                    hash = hash * 59 + this.CreatedAt.GetHashCode();
                
                if (this._Object != null)
                    hash = hash * 59 + this._Object.GetHashCode();
                
                if (this.RootManifestId != null)
                    hash = hash * 59 + this.RootManifestId.GetHashCode();
                
                if (this.CampaignId != null)
                    hash = hash * 59 + this.CampaignId.GetHashCode();
                
                if (this.UpdatingAccountId != null)
                    hash = hash * 59 + this.UpdatingAccountId.GetHashCode();
                
                if (this.UpdatedAt != null)
                    hash = hash * 59 + this.UpdatedAt.GetHashCode();
                
                if (this.When != null)
                    hash = hash * 59 + this.When.GetHashCode();
                
                if (this.Finished != null)
                    hash = hash * 59 + this.Finished.GetHashCode();
                
                if (this.Etag != null)
                    hash = hash * 59 + this.Etag.GetHashCode();
                
                if (this.RootManifestUrl != null)
                    hash = hash * 59 + this.RootManifestUrl.GetHashCode();
                
                if (this.UpdatingApiKey != null)
                    hash = hash * 59 + this.UpdatingApiKey.GetHashCode();
                
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                
                if (this.DeviceFilter != null)
                    hash = hash * 59 + this.DeviceFilter.GetHashCode();
                
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                
                return hash;
            }
        }

    }
}
