/* 
 * <auto-generated>
 * Bootstrap API
 *
 * Mbed Cloud Bootstrap API allows web applications to control the device bootstrapping process.
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
using SwaggerDateConverter = connector_bootstrap.Client.SwaggerDateConverter;

namespace connector_bootstrap.Model
{
    /// <summary>
    /// PreSharedKey
    /// </summary>
    [DataContract]
    public partial class PreSharedKey :  IEquatable<PreSharedKey>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreSharedKey" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PreSharedKey() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PreSharedKey" /> class.
        /// </summary>
        /// <param name="EndpointName">The unique endpoint identifier that this pre-shared key applies to. 16-64 [printable](https://en.wikipedia.org/wiki/ASCII#Printable_characters) (non-control) ASCII characters. (required).</param>
        /// <param name="SecretHex">The secret of the pre-shared key in hexadecimal. It is not case sensitive; 4a is same as 4A, and it is allowed with or without 0x in the beginning. The minimum length of the secret is 128 bits and maximum 256 bits. (required).</param>
        public PreSharedKey(string EndpointName = default(string), string SecretHex = default(string))
        {
            // to ensure "EndpointName" is required (not null)
            if (EndpointName == null)
            {
                throw new InvalidDataException("EndpointName is a required property for PreSharedKey and cannot be null");
            }
            else
            {
                this.EndpointName = EndpointName;
            }
            // to ensure "SecretHex" is required (not null)
            if (SecretHex == null)
            {
                throw new InvalidDataException("SecretHex is a required property for PreSharedKey and cannot be null");
            }
            else
            {
                this.SecretHex = SecretHex;
            }
        }
        
        /// <summary>
        /// The unique endpoint identifier that this pre-shared key applies to. 16-64 [printable](https://en.wikipedia.org/wiki/ASCII#Printable_characters) (non-control) ASCII characters.
        /// </summary>
        /// <value>The unique endpoint identifier that this pre-shared key applies to. 16-64 [printable](https://en.wikipedia.org/wiki/ASCII#Printable_characters) (non-control) ASCII characters.</value>
        [DataMember(Name="endpoint_name", EmitDefaultValue=false)]
        public string EndpointName { get; set; }

        /// <summary>
        /// The secret of the pre-shared key in hexadecimal. It is not case sensitive; 4a is same as 4A, and it is allowed with or without 0x in the beginning. The minimum length of the secret is 128 bits and maximum 256 bits.
        /// </summary>
        /// <value>The secret of the pre-shared key in hexadecimal. It is not case sensitive; 4a is same as 4A, and it is allowed with or without 0x in the beginning. The minimum length of the secret is 128 bits and maximum 256 bits.</value>
        [DataMember(Name="secret_hex", EmitDefaultValue=false)]
        public string SecretHex { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PreSharedKey {\n");
            sb.Append("  EndpointName: ").Append(EndpointName).Append("\n");
            sb.Append("  SecretHex: ").Append(SecretHex).Append("\n");
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
            return this.Equals(input as PreSharedKey);
        }

        /// <summary>
        /// Returns true if PreSharedKey instances are equal
        /// </summary>
        /// <param name="input">Instance of PreSharedKey to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PreSharedKey input)
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
                    this.SecretHex == input.SecretHex ||
                    (this.SecretHex != null &&
                    this.SecretHex.Equals(input.SecretHex))
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
                if (this.SecretHex != null)
                    hashCode = hashCode * 59 + this.SecretHex.GetHashCode();
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
            // EndpointName (string) pattern
            Regex regexEndpointName = new Regex(@"^[ -~]{16,64}$", RegexOptions.CultureInvariant);
            if (false == regexEndpointName.Match(this.EndpointName).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for EndpointName, must match a pattern of " + regexEndpointName, new [] { "EndpointName" });
            }

            // SecretHex (string) pattern
            Regex regexSecretHex = new Regex(@"^(0[xX])?[0-9a-fA-F]{32,64}$", RegexOptions.CultureInvariant);
            if (false == regexSecretHex.Match(this.SecretHex).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SecretHex, must match a pattern of " + regexSecretHex, new [] { "SecretHex" });
            }

            yield break;
        }
    }

}
