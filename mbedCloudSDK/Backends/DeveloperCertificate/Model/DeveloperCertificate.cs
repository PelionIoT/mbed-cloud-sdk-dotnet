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

namespace developer_certificate.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class DeveloperCertificate :  IEquatable<DeveloperCertificate>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DeveloperCertificate" /> class.
        /// Initializes a new instance of the <see cref="DeveloperCertificate" />class.
        /// </summary>
        /// <param name="CreatedAt">UTC time of the entity creation..</param>
        /// <param name="Etag">Currently not used..</param>
        /// <param name="PubKey">The developer certificate public key in raw format (65 bytes), Base64 encoded, NIST P-256 curve..</param>
        /// <param name="_Object">Currently not used..</param>
        /// <param name="Id">Entity ID..</param>

        public DeveloperCertificate(string CreatedAt = null, string Etag = null, string PubKey = null, string _Object = null, string Id = null)
        {
            this.CreatedAt = CreatedAt;
            this.Etag = Etag;
            this.PubKey = PubKey;
            this._Object = _Object;
            this.Id = Id;
            
        }
        
    
        /// <summary>
        /// UTC time of the entity creation.
        /// </summary>
        /// <value>UTC time of the entity creation.</value>
        [DataMember(Name="created_at", EmitDefaultValue=false)]
        public string CreatedAt { get; set; }
    
        /// <summary>
        /// Currently not used.
        /// </summary>
        /// <value>Currently not used.</value>
        [DataMember(Name="etag", EmitDefaultValue=false)]
        public string Etag { get; set; }
    
        /// <summary>
        /// The developer certificate public key in raw format (65 bytes), Base64 encoded, NIST P-256 curve.
        /// </summary>
        /// <value>The developer certificate public key in raw format (65 bytes), Base64 encoded, NIST P-256 curve.</value>
        [DataMember(Name="pub_key", EmitDefaultValue=false)]
        public string PubKey { get; set; }
    
        /// <summary>
        /// Currently not used.
        /// </summary>
        /// <value>Currently not used.</value>
        [DataMember(Name="object", EmitDefaultValue=false)]
        public string _Object { get; set; }
    
        /// <summary>
        /// Entity ID.
        /// </summary>
        /// <value>Entity ID.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DeveloperCertificate {\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("  PubKey: ").Append(PubKey).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            
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
            return this.Equals(obj as DeveloperCertificate);
        }

        /// <summary>
        /// Returns true if DeveloperCertificate instances are equal
        /// </summary>
        /// <param name="other">Instance of DeveloperCertificate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeveloperCertificate other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.CreatedAt == other.CreatedAt ||
                    this.CreatedAt != null &&
                    this.CreatedAt.Equals(other.CreatedAt)
                ) && 
                (
                    this.Etag == other.Etag ||
                    this.Etag != null &&
                    this.Etag.Equals(other.Etag)
                ) && 
                (
                    this.PubKey == other.PubKey ||
                    this.PubKey != null &&
                    this.PubKey.Equals(other.PubKey)
                ) && 
                (
                    this._Object == other._Object ||
                    this._Object != null &&
                    this._Object.Equals(other._Object)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
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
                
                if (this.CreatedAt != null)
                    hash = hash * 59 + this.CreatedAt.GetHashCode();
                
                if (this.Etag != null)
                    hash = hash * 59 + this.Etag.GetHashCode();
                
                if (this.PubKey != null)
                    hash = hash * 59 + this.PubKey.GetHashCode();
                
                if (this._Object != null)
                    hash = hash * 59 + this._Object.GetHashCode();
                
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                
                return hash;
            }
        }

    }
}
