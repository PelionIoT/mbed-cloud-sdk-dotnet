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

namespace iam.Model
{
    /// <summary>
    /// This object represents an API key in requests towards mbed Cloud.
    /// </summary>
    [DataContract]
    public partial class ApiKeyInfoReq :  IEquatable<ApiKeyInfoReq>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiKeyInfoReq" /> class.
        /// Initializes a new instance of the <see cref="ApiKeyInfoReq" />class.
        /// </summary>
        /// <param name="Owner">The owner of this API key, who is the creator by default..</param>
        /// <param name="Name">The display name for the API key. (required).</param>
        /// <param name="Groups">A list of group IDs this API key belongs to..</param>

        public ApiKeyInfoReq(string Owner = null, string Name = null, List<string> Groups = null)
        {
            // to ensure "Name" is required (not null)
            if (Name == null)
            {
                throw new InvalidDataException("Name is a required property for ApiKeyInfoReq and cannot be null");
            }
            else
            {
                this.Name = Name;
            }
            this.Owner = Owner;
            this.Groups = Groups;
            
        }
        
    
        /// <summary>
        /// The owner of this API key, who is the creator by default.
        /// </summary>
        /// <value>The owner of this API key, who is the creator by default.</value>
        [DataMember(Name="owner", EmitDefaultValue=false)]
        public string Owner { get; set; }
    
        /// <summary>
        /// The display name for the API key.
        /// </summary>
        /// <value>The display name for the API key.</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
    
        /// <summary>
        /// A list of group IDs this API key belongs to.
        /// </summary>
        /// <value>A list of group IDs this API key belongs to.</value>
        [DataMember(Name="groups", EmitDefaultValue=false)]
        public List<string> Groups { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiKeyInfoReq {\n");
            sb.Append("  Owner: ").Append(Owner).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
            
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
            return this.Equals(obj as ApiKeyInfoReq);
        }

        /// <summary>
        /// Returns true if ApiKeyInfoReq instances are equal
        /// </summary>
        /// <param name="other">Instance of ApiKeyInfoReq to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiKeyInfoReq other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Owner == other.Owner ||
                    this.Owner != null &&
                    this.Owner.Equals(other.Owner)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.Groups == other.Groups ||
                    this.Groups != null &&
                    this.Groups.SequenceEqual(other.Groups)
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
                
                if (this.Owner != null)
                    hash = hash * 59 + this.Owner.GetHashCode();
                
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                
                if (this.Groups != null)
                    hash = hash * 59 + this.Groups.GetHashCode();
                
                return hash;
            }
        }

    }
}
