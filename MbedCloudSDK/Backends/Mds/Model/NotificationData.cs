/* 
 * <auto-generated>
 * Connect API
 *
 * Mbed Cloud Connect API allows web applications to communicate with devices. You can subscribe to device resources and read/write values to them. Mbed Cloud Connect makes connectivity to devices easy by queuing requests and caching resource values.
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
    /// NotificationData
    /// </summary>
    [DataContract]
    public partial class NotificationData :  IEquatable<NotificationData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationData" /> class.
        /// </summary>
        /// <param name="Ct">Content type..</param>
        /// <param name="Ep">Mbed Cloud Device ID..</param>
        /// <param name="MaxAge">Max age value is an integer number of seconds between 0 and 2^32-1 but the actual maximum cache time is limited to 3 days. A default value of 60 seconds is assumed in the absence of the option. .</param>
        /// <param name="Path">URI path..</param>
        /// <param name="Payload">Base64 encoded payload..</param>
        public NotificationData(string Ct = default(string), string Ep = default(string), string MaxAge = default(string), string Path = default(string), string Payload = default(string))
        {
            this.Ct = Ct;
            this.Ep = Ep;
            this.MaxAge = MaxAge;
            this.Path = Path;
            this.Payload = Payload;
        }
        
        /// <summary>
        /// Content type.
        /// </summary>
        /// <value>Content type.</value>
        [DataMember(Name="ct", EmitDefaultValue=false)]
        public string Ct { get; set; }

        /// <summary>
        /// Mbed Cloud Device ID.
        /// </summary>
        /// <value>Mbed Cloud Device ID.</value>
        [DataMember(Name="ep", EmitDefaultValue=false)]
        public string Ep { get; set; }

        /// <summary>
        /// Max age value is an integer number of seconds between 0 and 2^32-1 but the actual maximum cache time is limited to 3 days. A default value of 60 seconds is assumed in the absence of the option. 
        /// </summary>
        /// <value>Max age value is an integer number of seconds between 0 and 2^32-1 but the actual maximum cache time is limited to 3 days. A default value of 60 seconds is assumed in the absence of the option. </value>
        [DataMember(Name="max-age", EmitDefaultValue=false)]
        public string MaxAge { get; set; }

        /// <summary>
        /// URI path.
        /// </summary>
        /// <value>URI path.</value>
        [DataMember(Name="path", EmitDefaultValue=false)]
        public string Path { get; set; }

        /// <summary>
        /// Base64 encoded payload.
        /// </summary>
        /// <value>Base64 encoded payload.</value>
        [DataMember(Name="payload", EmitDefaultValue=false)]
        public string Payload { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NotificationData {\n");
            sb.Append("  Ct: ").Append(Ct).Append("\n");
            sb.Append("  Ep: ").Append(Ep).Append("\n");
            sb.Append("  MaxAge: ").Append(MaxAge).Append("\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
            sb.Append("  Payload: ").Append(Payload).Append("\n");
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
            return this.Equals(input as NotificationData);
        }

        /// <summary>
        /// Returns true if NotificationData instances are equal
        /// </summary>
        /// <param name="input">Instance of NotificationData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NotificationData input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Ct == input.Ct ||
                    (this.Ct != null &&
                    this.Ct.Equals(input.Ct))
                ) && 
                (
                    this.Ep == input.Ep ||
                    (this.Ep != null &&
                    this.Ep.Equals(input.Ep))
                ) && 
                (
                    this.MaxAge == input.MaxAge ||
                    (this.MaxAge != null &&
                    this.MaxAge.Equals(input.MaxAge))
                ) && 
                (
                    this.Path == input.Path ||
                    (this.Path != null &&
                    this.Path.Equals(input.Path))
                ) && 
                (
                    this.Payload == input.Payload ||
                    (this.Payload != null &&
                    this.Payload.Equals(input.Payload))
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
                if (this.Ct != null)
                    hashCode = hashCode * 59 + this.Ct.GetHashCode();
                if (this.Ep != null)
                    hashCode = hashCode * 59 + this.Ep.GetHashCode();
                if (this.MaxAge != null)
                    hashCode = hashCode * 59 + this.MaxAge.GetHashCode();
                if (this.Path != null)
                    hashCode = hashCode * 59 + this.Path.GetHashCode();
                if (this.Payload != null)
                    hashCode = hashCode * 59 + this.Payload.GetHashCode();
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
