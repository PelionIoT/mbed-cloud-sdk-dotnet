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

namespace device_query_service.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class DeviceQuerySerializer :  IEquatable<DeviceQuerySerializer>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceQuerySerializer" /> class.
        /// Initializes a new instance of the <see cref="DeviceQuerySerializer" />class.
        /// </summary>
        /// <param name="Description">The description of the object (required).</param>
        /// <param name="CreatedAt">The time the object was created (required).</param>
        /// <param name="_Object">The API resource entity (required).</param>
        /// <param name="UpdatedAt">The time the object was updated (required).</param>
        /// <param name="Etag">The entity instance signature (required).</param>
        /// <param name="QueryId">DEPRECATED: The ID of the query (required).</param>
        /// <param name="Query">The device query (required).</param>
        /// <param name="Id">The ID of the query (required).</param>
        /// <param name="Name">The name of the query (required).</param>

        public DeviceQuerySerializer(string Description = null, DateTime? CreatedAt = null, string _Object = null, DateTime? UpdatedAt = null, DateTime? Etag = null, string QueryId = null, string Query = null, string Id = null, string Name = null)
        {
            // to ensure "Description" is required (not null)
            if (Description == null)
            {
                throw new InvalidDataException("Description is a required property for DeviceQuerySerializer and cannot be null");
            }
            else
            {
                this.Description = Description;
            }
            // to ensure "CreatedAt" is required (not null)
            if (CreatedAt == null)
            {
                throw new InvalidDataException("CreatedAt is a required property for DeviceQuerySerializer and cannot be null");
            }
            else
            {
                this.CreatedAt = CreatedAt;
            }
            // to ensure "_Object" is required (not null)
            if (_Object == null)
            {
                throw new InvalidDataException("_Object is a required property for DeviceQuerySerializer and cannot be null");
            }
            else
            {
                this._Object = _Object;
            }
            // to ensure "UpdatedAt" is required (not null)
            if (UpdatedAt == null)
            {
                throw new InvalidDataException("UpdatedAt is a required property for DeviceQuerySerializer and cannot be null");
            }
            else
            {
                this.UpdatedAt = UpdatedAt;
            }
            // to ensure "Etag" is required (not null)
            if (Etag == null)
            {
                throw new InvalidDataException("Etag is a required property for DeviceQuerySerializer and cannot be null");
            }
            else
            {
                this.Etag = Etag;
            }
            // to ensure "QueryId" is required (not null)
            if (QueryId == null)
            {
                throw new InvalidDataException("QueryId is a required property for DeviceQuerySerializer and cannot be null");
            }
            else
            {
                this.QueryId = QueryId;
            }
            // to ensure "Query" is required (not null)
            if (Query == null)
            {
                throw new InvalidDataException("Query is a required property for DeviceQuerySerializer and cannot be null");
            }
            else
            {
                this.Query = Query;
            }
            // to ensure "Id" is required (not null)
            if (Id == null)
            {
                throw new InvalidDataException("Id is a required property for DeviceQuerySerializer and cannot be null");
            }
            else
            {
                this.Id = Id;
            }
            // to ensure "Name" is required (not null)
            if (Name == null)
            {
                throw new InvalidDataException("Name is a required property for DeviceQuerySerializer and cannot be null");
            }
            else
            {
                this.Name = Name;
            }
            
        }
        
    
        /// <summary>
        /// The description of the object
        /// </summary>
        /// <value>The description of the object</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
    
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
        /// The time the object was updated
        /// </summary>
        /// <value>The time the object was updated</value>
        [DataMember(Name="updated_at", EmitDefaultValue=false)]
        public DateTime? UpdatedAt { get; set; }
    
        /// <summary>
        /// The entity instance signature
        /// </summary>
        /// <value>The entity instance signature</value>
        [DataMember(Name="etag", EmitDefaultValue=false)]
        public DateTime? Etag { get; set; }
    
        /// <summary>
        /// DEPRECATED: The ID of the query
        /// </summary>
        /// <value>DEPRECATED: The ID of the query</value>
        [DataMember(Name="query_id", EmitDefaultValue=false)]
        public string QueryId { get; set; }
    
        /// <summary>
        /// The device query
        /// </summary>
        /// <value>The device query</value>
        [DataMember(Name="query", EmitDefaultValue=false)]
        public string Query { get; set; }
    
        /// <summary>
        /// The ID of the query
        /// </summary>
        /// <value>The ID of the query</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
    
        /// <summary>
        /// The name of the query
        /// </summary>
        /// <value>The name of the query</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeviceQuerySerializer {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("  QueryId: ").Append(QueryId).Append("\n");
            sb.Append("  Query: ").Append(Query).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
            return this.Equals(obj as DeviceQuerySerializer);
        }

        /// <summary>
        /// Returns true if DeviceQuerySerializer instances are equal
        /// </summary>
        /// <param name="other">Instance of DeviceQuerySerializer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeviceQuerySerializer other)
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
                    this.Etag == other.Etag ||
                    this.Etag != null &&
                    this.Etag.Equals(other.Etag)
                ) && 
                (
                    this.QueryId == other.QueryId ||
                    this.QueryId != null &&
                    this.QueryId.Equals(other.QueryId)
                ) && 
                (
                    this.Query == other.Query ||
                    this.Query != null &&
                    this.Query.Equals(other.Query)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
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
                
                if (this.CreatedAt != null)
                    hash = hash * 59 + this.CreatedAt.GetHashCode();
                
                if (this._Object != null)
                    hash = hash * 59 + this._Object.GetHashCode();
                
                if (this.UpdatedAt != null)
                    hash = hash * 59 + this.UpdatedAt.GetHashCode();
                
                if (this.Etag != null)
                    hash = hash * 59 + this.Etag.GetHashCode();
                
                if (this.QueryId != null)
                    hash = hash * 59 + this.QueryId.GetHashCode();
                
                if (this.Query != null)
                    hash = hash * 59 + this.Query.GetHashCode();
                
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                
                return hash;
            }
        }

    }
}
