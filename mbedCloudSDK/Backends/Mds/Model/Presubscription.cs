/* 
 * Connect API
 *
 * mbed Cloud Connect API allows web applications to communicate with devices. You can subscribe to device resources and read/write values to them. mbed Cloud Connect makes connectivity to devices easy by queuing requests and caching resource values.
 *
 * OpenAPI spec version: 2
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

namespace mds.Model
{
    /// <summary>
    /// Presubscription
    /// </summary>
    [DataContract]
    public partial class Presubscription :  IEquatable<Presubscription>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Presubscription" /> class.
        /// </summary>
        /// <param name="EndpointName">EndpointName.</param>
        /// <param name="EndpointType">EndpointType.</param>
        /// <param name="ResourcePath">ResourcePath.</param>
        public Presubscription(string EndpointName = default(string), string EndpointType = default(string), List<ResourcePath> ResourcePath = default(List<ResourcePath>))
        {
            this.EndpointName = EndpointName;
            this.EndpointType = EndpointType;
            this.ResourcePath = ResourcePath;
        }
        
        /// <summary>
        /// Gets or Sets EndpointName
        /// </summary>
        [DataMember(Name="endpoint-name", EmitDefaultValue=false)]
        public string EndpointName { get; set; }
        /// <summary>
        /// Gets or Sets EndpointType
        /// </summary>
        [DataMember(Name="endpoint-type", EmitDefaultValue=false)]
        public string EndpointType { get; set; }
        /// <summary>
        /// Gets or Sets ResourcePath
        /// </summary>
        [DataMember(Name="resource-path", EmitDefaultValue=false)]
        public List<ResourcePath> ResourcePath { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Presubscription {\n");
            sb.Append("  EndpointName: ").Append(EndpointName).Append("\n");
            sb.Append("  EndpointType: ").Append(EndpointType).Append("\n");
            sb.Append("  ResourcePath: ").Append(ResourcePath).Append("\n");
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
            return this.Equals(obj as Presubscription);
        }

        /// <summary>
        /// Returns true if Presubscription instances are equal
        /// </summary>
        /// <param name="other">Instance of Presubscription to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Presubscription other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.EndpointName == other.EndpointName ||
                    this.EndpointName != null &&
                    this.EndpointName.Equals(other.EndpointName)
                ) && 
                (
                    this.EndpointType == other.EndpointType ||
                    this.EndpointType != null &&
                    this.EndpointType.Equals(other.EndpointType)
                ) && 
                (
                    this.ResourcePath == other.ResourcePath ||
                    this.ResourcePath != null &&
                    this.ResourcePath.SequenceEqual(other.ResourcePath)
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
                if (this.EndpointName != null)
                    hash = hash * 59 + this.EndpointName.GetHashCode();
                if (this.EndpointType != null)
                    hash = hash * 59 + this.EndpointType.GetHashCode();
                if (this.ResourcePath != null)
                    hash = hash * 59 + this.ResourcePath.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
