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
    public partial class WriteDeviceQuerySerializer :  IEquatable<WriteDeviceQuerySerializer>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="WriteDeviceQuerySerializer" /> class.
        /// Initializes a new instance of the <see cref="WriteDeviceQuerySerializer" />class.
        /// </summary>
        /// <param name="Query">The device query (required).</param>
        /// <param name="_Object">The API resource entity.</param>
        /// <param name="QueryId">DEPRECATED: The ID of the query.</param>
        /// <param name="Description">The description of the object.</param>
        /// <param name="Name">The name of the query (required).</param>

        public WriteDeviceQuerySerializer(string Query = null, string _Object = null, string QueryId = null, string Description = null, string Name = null)
        {
            // to ensure "Query" is required (not null)
            if (Query == null)
            {
                throw new InvalidDataException("Query is a required property for WriteDeviceQuerySerializer and cannot be null");
            }
            else
            {
                this.Query = Query;
            }
            // to ensure "Name" is required (not null)
            if (Name == null)
            {
                throw new InvalidDataException("Name is a required property for WriteDeviceQuerySerializer and cannot be null");
            }
            else
            {
                this.Name = Name;
            }
            this._Object = _Object;
            this.QueryId = QueryId;
            this.Description = Description;
            
        }
        
    
        /// <summary>
        /// The device query
        /// </summary>
        /// <value>The device query</value>
        [DataMember(Name="query", EmitDefaultValue=false)]
        public string Query { get; set; }
    
        /// <summary>
        /// The API resource entity
        /// </summary>
        /// <value>The API resource entity</value>
        [DataMember(Name="object", EmitDefaultValue=false)]
        public string _Object { get; set; }
    
        /// <summary>
        /// DEPRECATED: The ID of the query
        /// </summary>
        /// <value>DEPRECATED: The ID of the query</value>
        [DataMember(Name="query_id", EmitDefaultValue=false)]
        public string QueryId { get; set; }
    
        /// <summary>
        /// The description of the object
        /// </summary>
        /// <value>The description of the object</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
    
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
            sb.Append("class WriteDeviceQuerySerializer {\n");
            sb.Append("  Query: ").Append(Query).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  QueryId: ").Append(QueryId).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return this.Equals(obj as WriteDeviceQuerySerializer);
        }

        /// <summary>
        /// Returns true if WriteDeviceQuerySerializer instances are equal
        /// </summary>
        /// <param name="other">Instance of WriteDeviceQuerySerializer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WriteDeviceQuerySerializer other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Query == other.Query ||
                    this.Query != null &&
                    this.Query.Equals(other.Query)
                ) && 
                (
                    this._Object == other._Object ||
                    this._Object != null &&
                    this._Object.Equals(other._Object)
                ) && 
                (
                    this.QueryId == other.QueryId ||
                    this.QueryId != null &&
                    this.QueryId.Equals(other.QueryId)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
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
                
                if (this.Query != null)
                    hash = hash * 59 + this.Query.GetHashCode();
                
                if (this._Object != null)
                    hash = hash * 59 + this._Object.GetHashCode();
                
                if (this.QueryId != null)
                    hash = hash * 59 + this.QueryId.GetHashCode();
                
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                
                return hash;
            }
        }

    }
}
