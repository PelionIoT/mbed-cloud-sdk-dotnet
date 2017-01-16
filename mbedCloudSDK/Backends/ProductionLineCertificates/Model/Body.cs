/* 
 * Provisioning endpoints - production line certificates.
 *
 * A producton line certificate is used to associate a specific installation of the Factory Tool with an mbed Cloud account.  The production line certificate is generated by the Factory Tool, and needs to be uploaded using these APIs. 
 *
 * OpenAPI spec version: 0.8
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

namespace production_line_certificates.Model
{
    /// <summary>
    /// Body
    /// </summary>
    [DataContract]
    public partial class Body :  IEquatable<Body>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Body" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Body() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Body" /> class.
        /// </summary>
        /// <param name="Comment">Comment of the production line certificate (max length is 256 characters). (required).</param>
        /// <param name="ProductionLineCertificate">Production line certificate public key (from the Factory Tool, raw format - 65 bytes, Base64 encoded). (required).</param>
        public Body(string Comment = default(string), string ProductionLineCertificate = default(string))
        {
            // to ensure "Comment" is required (not null)
            if (Comment == null)
            {
                throw new InvalidDataException("Comment is a required property for Body and cannot be null");
            }
            else
            {
                this.Comment = Comment;
            }
            // to ensure "ProductionLineCertificate" is required (not null)
            if (ProductionLineCertificate == null)
            {
                throw new InvalidDataException("ProductionLineCertificate is a required property for Body and cannot be null");
            }
            else
            {
                this.ProductionLineCertificate = ProductionLineCertificate;
            }
        }
        
        /// <summary>
        /// Comment of the production line certificate (max length is 256 characters).
        /// </summary>
        /// <value>Comment of the production line certificate (max length is 256 characters).</value>
        [DataMember(Name="comment", EmitDefaultValue=false)]
        public string Comment { get; set; }
        /// <summary>
        /// Production line certificate public key (from the Factory Tool, raw format - 65 bytes, Base64 encoded).
        /// </summary>
        /// <value>Production line certificate public key (from the Factory Tool, raw format - 65 bytes, Base64 encoded).</value>
        [DataMember(Name="production-line-certificate", EmitDefaultValue=false)]
        public string ProductionLineCertificate { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Body {\n");
            sb.Append("  Comment: ").Append(Comment).Append("\n");
            sb.Append("  ProductionLineCertificate: ").Append(ProductionLineCertificate).Append("\n");
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
            return this.Equals(obj as Body);
        }

        /// <summary>
        /// Returns true if Body instances are equal
        /// </summary>
        /// <param name="other">Instance of Body to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Body other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Comment == other.Comment ||
                    this.Comment != null &&
                    this.Comment.Equals(other.Comment)
                ) && 
                (
                    this.ProductionLineCertificate == other.ProductionLineCertificate ||
                    this.ProductionLineCertificate != null &&
                    this.ProductionLineCertificate.Equals(other.ProductionLineCertificate)
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
                if (this.Comment != null)
                    hash = hash * 59 + this.Comment.GetHashCode();
                if (this.ProductionLineCertificate != null)
                    hash = hash * 59 + this.ProductionLineCertificate.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
