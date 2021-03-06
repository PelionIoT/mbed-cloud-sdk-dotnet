/* 
 * <auto-generated>
 * Connect API
 *
 * Pelion Device Management Connect API allows web applications to communicate with devices. You can subscribe to device resources and read/write values to them. Device Management Connect allows connectivity to devices by queueing requests and caching resource values.
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
using SwaggerDateConverter = mds.Client.SwaggerDateConverter;

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
        /// <param name="EndpointName">The device ID..</param>
        /// <param name="EndpointType">EndpointType.</param>
        /// <param name="ResourcePath">ResourcePath.</param>
        public Presubscription(string EndpointName = default(string), string EndpointType = default(string), List<string> ResourcePath = default(List<string>))
        {
            this.EndpointName = EndpointName;
            this.EndpointType = EndpointType;
            this.ResourcePath = ResourcePath;
        }
        
        /// <summary>
        /// The device ID.
        /// </summary>
        /// <value>The device ID.</value>
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
        public List<string> ResourcePath { get; set; }

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
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Presubscription);
        }

        /// <summary>
        /// Returns true if Presubscription instances are equal
        /// </summary>
        /// <param name="input">Instance of Presubscription to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Presubscription input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.EndpointName == input.EndpointName ||
                    (this.EndpointName != null &&
                    this.EndpointName.Equals(input.EndpointName))
                ) && 
                (
                    this.EndpointType == input.EndpointType ||
                    (this.EndpointType != null &&
                    this.EndpointType.Equals(input.EndpointType))
                ) && 
                (
                    this.ResourcePath == input.ResourcePath ||
                    this.ResourcePath != null &&
                    this.ResourcePath.SequenceEqual(input.ResourcePath)
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
                if (this.EndpointName != null)
                    hashCode = hashCode * 59 + this.EndpointName.GetHashCode();
                if (this.EndpointType != null)
                    hashCode = hashCode * 59 + this.EndpointType.GetHashCode();
                if (this.ResourcePath != null)
                    hashCode = hashCode * 59 + this.ResourcePath.GetHashCode();
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
            yield break;
        }
    }

}
