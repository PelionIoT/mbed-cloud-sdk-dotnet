/* 
 * <auto-generated>
 * Connect API
 *
 * mbed Cloud Connect API allows web applications to communicate with devices. You can subscribe to device resources and read/write values to them. mbed Cloud Connect makes connectivity to devices easy by queuing requests and caching resource values.
 *
 * OpenAPI spec version: 2
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

namespace mds.Model
{
    /// <summary>
    /// ResourcesData
    /// </summary>
    [DataContract]
    public partial class ResourcesData :  IEquatable<ResourcesData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcesData" /> class.
        /// </summary>
        /// <param name="Path">Resource&#39;s URI path..</param>
        /// <param name="Rf">Resource type [created by Client side application](/docs/v1.2/device-dev/connecting-devices-to-the-cloud-with-mbed-cloud-client.html#the-create-operation). For example \&quot;speed_sensor\&quot;.</param>
        /// <param name="Ct">Content type..</param>
        /// <param name="Obs">Whether the resource is observable or not (true/false)..</param>
        /// <param name="_If">Interface description..</param>
        public ResourcesData(string Path = default(string), string Rf = default(string), string Ct = default(string), bool? Obs = default(bool?), string _If = default(string))
        {
            this.Path = Path;
            this.Rf = Rf;
            this.Ct = Ct;
            this.Obs = Obs;
            this._If = _If;
        }
        
        /// <summary>
        /// Resource&#39;s URI path.
        /// </summary>
        /// <value>Resource&#39;s URI path.</value>
        [DataMember(Name="path", EmitDefaultValue=false)]
        public string Path { get; set; }
        /// <summary>
        /// Resource type [created by Client side application](/docs/v1.2/device-dev/connecting-devices-to-the-cloud-with-mbed-cloud-client.html#the-create-operation). For example \&quot;speed_sensor\&quot;
        /// </summary>
        /// <value>Resource type [created by Client side application](/docs/v1.2/device-dev/connecting-devices-to-the-cloud-with-mbed-cloud-client.html#the-create-operation). For example \&quot;speed_sensor\&quot;</value>
        [DataMember(Name="rf", EmitDefaultValue=false)]
        public string Rf { get; set; }
        /// <summary>
        /// Content type.
        /// </summary>
        /// <value>Content type.</value>
        [DataMember(Name="ct", EmitDefaultValue=false)]
        public string Ct { get; set; }
        /// <summary>
        /// Whether the resource is observable or not (true/false).
        /// </summary>
        /// <value>Whether the resource is observable or not (true/false).</value>
        [DataMember(Name="obs", EmitDefaultValue=false)]
        public bool? Obs { get; set; }
        /// <summary>
        /// Interface description.
        /// </summary>
        /// <value>Interface description.</value>
        [DataMember(Name="if", EmitDefaultValue=false)]
        public string _If { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ResourcesData {\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
            sb.Append("  Rf: ").Append(Rf).Append("\n");
            sb.Append("  Ct: ").Append(Ct).Append("\n");
            sb.Append("  Obs: ").Append(Obs).Append("\n");
            sb.Append("  _If: ").Append(_If).Append("\n");
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
            return this.Equals(obj as ResourcesData);
        }

        /// <summary>
        /// Returns true if ResourcesData instances are equal
        /// </summary>
        /// <param name="other">Instance of ResourcesData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ResourcesData other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Path == other.Path ||
                    this.Path != null &&
                    this.Path.Equals(other.Path)
                ) && 
                (
                    this.Rf == other.Rf ||
                    this.Rf != null &&
                    this.Rf.Equals(other.Rf)
                ) && 
                (
                    this.Ct == other.Ct ||
                    this.Ct != null &&
                    this.Ct.Equals(other.Ct)
                ) && 
                (
                    this.Obs == other.Obs ||
                    this.Obs != null &&
                    this.Obs.Equals(other.Obs)
                ) && 
                (
                    this._If == other._If ||
                    this._If != null &&
                    this._If.Equals(other._If)
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
                if (this.Path != null)
                    hash = hash * 59 + this.Path.GetHashCode();
                if (this.Rf != null)
                    hash = hash * 59 + this.Rf.GetHashCode();
                if (this.Ct != null)
                    hash = hash * 59 + this.Ct.GetHashCode();
                if (this.Obs != null)
                    hash = hash * 59 + this.Obs.GetHashCode();
                if (this._If != null)
                    hash = hash * 59 + this._If.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
