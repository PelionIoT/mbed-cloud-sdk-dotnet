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
    /// FieldMessageEntry
    /// </summary>
    [DataContract]
    public partial class FieldMessageEntry :  IEquatable<FieldMessageEntry>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldMessageEntry" /> class.
        /// </summary>
        /// <param name="Field">Field name..</param>
        /// <param name="Message">Error message related to the field..</param>
        public FieldMessageEntry(string Field = default(string), string Message = default(string))
        {
            this.Field = Field;
            this.Message = Message;
        }
        
        /// <summary>
        /// Field name.
        /// </summary>
        /// <value>Field name.</value>
        [DataMember(Name="field", EmitDefaultValue=false)]
        public string Field { get; set; }

        /// <summary>
        /// Error message related to the field.
        /// </summary>
        /// <value>Error message related to the field.</value>
        [DataMember(Name="message", EmitDefaultValue=false)]
        public string Message { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FieldMessageEntry {\n");
            sb.Append("  Field: ").Append(Field).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
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
            return this.Equals(input as FieldMessageEntry);
        }

        /// <summary>
        /// Returns true if FieldMessageEntry instances are equal
        /// </summary>
        /// <param name="input">Instance of FieldMessageEntry to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FieldMessageEntry input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Field == input.Field ||
                    (this.Field != null &&
                    this.Field.Equals(input.Field))
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
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
                if (this.Field != null)
                    hashCode = hashCode * 59 + this.Field.GetHashCode();
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
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