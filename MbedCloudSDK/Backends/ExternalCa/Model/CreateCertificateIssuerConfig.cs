/* 
 * <auto-generated>
 * Third party CA management API
 *
 * API for managing third party CA for creating certificates on Pelion Device Management
 *
 * OpenAPI spec version: v3
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
using SwaggerDateConverter = external_ca.Client.SwaggerDateConverter;

namespace external_ca.Model
{
    /// <summary>
    /// CreateCertificateIssuerConfig
    /// </summary>
    [DataContract]
    public partial class CreateCertificateIssuerConfig :  IEquatable<CreateCertificateIssuerConfig>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCertificateIssuerConfig" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateCertificateIssuerConfig() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCertificateIssuerConfig" /> class.
        /// </summary>
        /// <param name="CertificateIssuerId">The ID of the certificate issuer.  (required).</param>
        /// <param name="Reference">The certificate name, as created in the factory, to which the certificate issuer configuration applies. The following names are reserved and cannot be configured: LwM2M, BOOTSTRAP.  (required).</param>
        public CreateCertificateIssuerConfig(string CertificateIssuerId = default(string), string Reference = default(string))
        {
            // to ensure "CertificateIssuerId" is required (not null)
            if (CertificateIssuerId == null)
            {
                throw new InvalidDataException("CertificateIssuerId is a required property for CreateCertificateIssuerConfig and cannot be null");
            }
            else
            {
                this.CertificateIssuerId = CertificateIssuerId;
            }
            // to ensure "Reference" is required (not null)
            if (Reference == null)
            {
                throw new InvalidDataException("Reference is a required property for CreateCertificateIssuerConfig and cannot be null");
            }
            else
            {
                this.Reference = Reference;
            }
        }
        
        /// <summary>
        /// The ID of the certificate issuer. 
        /// </summary>
        /// <value>The ID of the certificate issuer. </value>
        [DataMember(Name="certificate_issuer_id", EmitDefaultValue=false)]
        public string CertificateIssuerId { get; set; }

        /// <summary>
        /// The certificate name, as created in the factory, to which the certificate issuer configuration applies. The following names are reserved and cannot be configured: LwM2M, BOOTSTRAP. 
        /// </summary>
        /// <value>The certificate name, as created in the factory, to which the certificate issuer configuration applies. The following names are reserved and cannot be configured: LwM2M, BOOTSTRAP. </value>
        [DataMember(Name="reference", EmitDefaultValue=false)]
        public string Reference { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CreateCertificateIssuerConfig {\n");
            sb.Append("  CertificateIssuerId: ").Append(CertificateIssuerId).Append("\n");
            sb.Append("  Reference: ").Append(Reference).Append("\n");
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
            return this.Equals(input as CreateCertificateIssuerConfig);
        }

        /// <summary>
        /// Returns true if CreateCertificateIssuerConfig instances are equal
        /// </summary>
        /// <param name="input">Instance of CreateCertificateIssuerConfig to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateCertificateIssuerConfig input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CertificateIssuerId == input.CertificateIssuerId ||
                    (this.CertificateIssuerId != null &&
                    this.CertificateIssuerId.Equals(input.CertificateIssuerId))
                ) && 
                (
                    this.Reference == input.Reference ||
                    (this.Reference != null &&
                    this.Reference.Equals(input.Reference))
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
                if (this.CertificateIssuerId != null)
                    hashCode = hashCode * 59 + this.CertificateIssuerId.GetHashCode();
                if (this.Reference != null)
                    hashCode = hashCode * 59 + this.Reference.GetHashCode();
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
            // CertificateIssuerId (string) maxLength
            if(this.CertificateIssuerId != null && this.CertificateIssuerId.Length > 32)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CertificateIssuerId, length must be less than 32.", new [] { "CertificateIssuerId" });
            }

            // Reference (string) maxLength
            if(this.Reference != null && this.Reference.Length > 50)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Reference, length must be less than 50.", new [] { "Reference" });
            }

            // Reference (string) pattern
            Regex regexReference = new Regex(@"(?!mbed\\.)[\\w-_.]{1,50}", RegexOptions.CultureInvariant);
            if (false == regexReference.Match(this.Reference).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Reference, must match a pattern of " + regexReference, new [] { "Reference" });
            }

            yield break;
        }
    }

}
