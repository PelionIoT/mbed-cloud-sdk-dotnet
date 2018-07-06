/* 
 * <auto-generated>
 * billing REST API documentation
 *
 * This document contains the public REST API definitions of the mbed-billing service.
 *
 * OpenAPI spec version: 1.4.4
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
using SwaggerDateConverter = billing.Client.SwaggerDateConverter;

namespace billing.Model
{
    /// <summary>
    /// Contains service package information for currently active service package, currently pending service package and all previous service packages this account has had.
    /// </summary>
    [DataContract]
    public partial class ServicePackagesResponse :  IEquatable<ServicePackagesResponse>, IValidatableObject
    {
        /// <summary>
        /// Always set to &#39;service-packages&#39;.
        /// </summary>
        /// <value>Always set to &#39;service-packages&#39;.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ObjectEnum
        {
            
            /// <summary>
            /// Enum Packages for "service-packages"
            /// </summary>
            [EnumMember(Value = "service-packages")]
            Packages
        }

        /// <summary>
        /// Always set to &#39;service-packages&#39;.
        /// </summary>
        /// <value>Always set to &#39;service-packages&#39;.</value>
        [DataMember(Name="object", EmitDefaultValue=false)]
        public ObjectEnum? _Object { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicePackagesResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ServicePackagesResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicePackagesResponse" /> class.
        /// </summary>
        /// <param name="Active">Currently active service package. Can be null..</param>
        /// <param name="_Object">Always set to &#39;service-packages&#39;. (required).</param>
        /// <param name="Pending">Current pending service package. Can be null..</param>
        /// <param name="Previous">List of previous service packages. (required).</param>
        public ServicePackagesResponse(ActiveServicePackage Active = default(ActiveServicePackage), ObjectEnum? _Object = default(ObjectEnum?), PendingServicePackage Pending = default(PendingServicePackage), List<PreviousServicePackage> Previous = default(List<PreviousServicePackage>))
        {
            // to ensure "_Object" is required (not null)
            if (_Object == null)
            {
                throw new InvalidDataException("_Object is a required property for ServicePackagesResponse and cannot be null");
            }
            else
            {
                this._Object = _Object;
            }
            // to ensure "Previous" is required (not null)
            if (Previous == null)
            {
                throw new InvalidDataException("Previous is a required property for ServicePackagesResponse and cannot be null");
            }
            else
            {
                this.Previous = Previous;
            }
            this.Active = Active;
            this.Pending = Pending;
        }
        
        /// <summary>
        /// Currently active service package. Can be null.
        /// </summary>
        /// <value>Currently active service package. Can be null.</value>
        [DataMember(Name="active", EmitDefaultValue=false)]
        public ActiveServicePackage Active { get; set; }


        /// <summary>
        /// Current pending service package. Can be null.
        /// </summary>
        /// <value>Current pending service package. Can be null.</value>
        [DataMember(Name="pending", EmitDefaultValue=false)]
        public PendingServicePackage Pending { get; set; }

        /// <summary>
        /// List of previous service packages.
        /// </summary>
        /// <value>List of previous service packages.</value>
        [DataMember(Name="previous", EmitDefaultValue=false)]
        public List<PreviousServicePackage> Previous { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ServicePackagesResponse {\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  _Object: ").Append(_Object).Append("\n");
            sb.Append("  Pending: ").Append(Pending).Append("\n");
            sb.Append("  Previous: ").Append(Previous).Append("\n");
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
            return this.Equals(input as ServicePackagesResponse);
        }

        /// <summary>
        /// Returns true if ServicePackagesResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of ServicePackagesResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ServicePackagesResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Active == input.Active ||
                    (this.Active != null &&
                    this.Active.Equals(input.Active))
                ) && 
                (
                    this._Object == input._Object ||
                    (this._Object != null &&
                    this._Object.Equals(input._Object))
                ) && 
                (
                    this.Pending == input.Pending ||
                    (this.Pending != null &&
                    this.Pending.Equals(input.Pending))
                ) && 
                (
                    this.Previous == input.Previous ||
                    this.Previous != null &&
                    this.Previous.SequenceEqual(input.Previous)
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
                if (this.Active != null)
                    hashCode = hashCode * 59 + this.Active.GetHashCode();
                if (this._Object != null)
                    hashCode = hashCode * 59 + this._Object.GetHashCode();
                if (this.Pending != null)
                    hashCode = hashCode * 59 + this.Pending.GetHashCode();
                if (this.Previous != null)
                    hashCode = hashCode * 59 + this.Previous.GetHashCode();
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