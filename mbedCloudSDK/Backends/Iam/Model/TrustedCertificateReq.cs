/* 
 * IAM Identities REST API
 *
 * REST API to manage accounts, groups, users and API keys
 *
 * OpenAPI spec version: v3
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

namespace iam.Model
{
    /// <summary>
    /// This object represents a trusted certificate in requests.
    /// </summary>
    [DataContract]
    public partial class TrustedCertificateReq :  IEquatable<TrustedCertificateReq>, IValidatableObject
    {
        /// <summary>
        /// Service name where the certificate must be used.
        /// </summary>
        /// <value>Service name where the certificate must be used.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ServiceEnum
        {
            
            /// <summary>
            /// Enum Lwm2m for "lwm2m"
            /// </summary>
            [EnumMember(Value = "lwm2m")]
            Lwm2m,
            
            /// <summary>
            /// Enum Bootstrap for "bootstrap"
            /// </summary>
            [EnumMember(Value = "bootstrap")]
            Bootstrap
        }

        /// <summary>
        /// Service name where the certificate must be used.
        /// </summary>
        /// <value>Service name where the certificate must be used.</value>
        [DataMember(Name="service", EmitDefaultValue=false)]
        public ServiceEnum? Service { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TrustedCertificateReq" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TrustedCertificateReq() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TrustedCertificateReq" /> class.
        /// </summary>
        /// <param name="Signature">Base64 encoded signature of the account ID signed by the certificate to be uploaded. Signature must be hashed with SHA256. (required).</param>
        /// <param name="CertData">X509.v3 trusted certificate in PEM or base64 encoded DER format. (required).</param>
        /// <param name="Name">Certificate name. (required).</param>
        /// <param name="Service">Service name where the certificate must be used. (required).</param>
        /// <param name="Description">Human readable description of this certificate..</param>
        public TrustedCertificateReq(string Signature = default(string), string CertData = default(string), string Name = default(string), ServiceEnum? Service = default(ServiceEnum?), string Description = default(string))
        {
            // to ensure "Signature" is required (not null)
            if (Signature == null)
            {
                throw new InvalidDataException("Signature is a required property for TrustedCertificateReq and cannot be null");
            }
            else
            {
                this.Signature = Signature;
            }
            // to ensure "CertData" is required (not null)
            if (CertData == null)
            {
                throw new InvalidDataException("CertData is a required property for TrustedCertificateReq and cannot be null");
            }
            else
            {
                this.CertData = CertData;
            }
            // to ensure "Name" is required (not null)
            if (Name == null)
            {
                throw new InvalidDataException("Name is a required property for TrustedCertificateReq and cannot be null");
            }
            else
            {
                this.Name = Name;
            }
            // to ensure "Service" is required (not null)
            if (Service == null)
            {
                throw new InvalidDataException("Service is a required property for TrustedCertificateReq and cannot be null");
            }
            else
            {
                this.Service = Service;
            }
            this.Description = Description;
        }
        
        /// <summary>
        /// Base64 encoded signature of the account ID signed by the certificate to be uploaded. Signature must be hashed with SHA256.
        /// </summary>
        /// <value>Base64 encoded signature of the account ID signed by the certificate to be uploaded. Signature must be hashed with SHA256.</value>
        [DataMember(Name="signature", EmitDefaultValue=false)]
        public string Signature { get; set; }
        /// <summary>
        /// X509.v3 trusted certificate in PEM or base64 encoded DER format.
        /// </summary>
        /// <value>X509.v3 trusted certificate in PEM or base64 encoded DER format.</value>
        [DataMember(Name="cert_data", EmitDefaultValue=false)]
        public string CertData { get; set; }
        /// <summary>
        /// Certificate name.
        /// </summary>
        /// <value>Certificate name.</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// Human readable description of this certificate.
        /// </summary>
        /// <value>Human readable description of this certificate.</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TrustedCertificateReq {\n");
            sb.Append("  Signature: ").Append(Signature).Append("\n");
            sb.Append("  CertData: ").Append(CertData).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Service: ").Append(Service).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return this.Equals(obj as TrustedCertificateReq);
        }

        /// <summary>
        /// Returns true if TrustedCertificateReq instances are equal
        /// </summary>
        /// <param name="other">Instance of TrustedCertificateReq to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TrustedCertificateReq other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Signature == other.Signature ||
                    this.Signature != null &&
                    this.Signature.Equals(other.Signature)
                ) && 
                (
                    this.CertData == other.CertData ||
                    this.CertData != null &&
                    this.CertData.Equals(other.CertData)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.Service == other.Service ||
                    this.Service != null &&
                    this.Service.Equals(other.Service)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
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
                if (this.Signature != null)
                    hash = hash * 59 + this.Signature.GetHashCode();
                if (this.CertData != null)
                    hash = hash * 59 + this.CertData.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.Service != null)
                    hash = hash * 59 + this.Service.GetHashCode();
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
