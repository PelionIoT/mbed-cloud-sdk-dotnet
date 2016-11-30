using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace mds.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class NotificationData :  IEquatable<NotificationData>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationData" /> class.
        /// Initializes a new instance of the <see cref="NotificationData" />class.
        /// </summary>
        /// <param name="Timestamp">Timestamp.</param>
        /// <param name="Payload">Base64 encoded payload.</param>
        /// <param name="Path">URI path.</param>
        /// <param name="MaxAge">Max age.</param>
        /// <param name="Ep">Endpoint name.</param>
        /// <param name="Ct">Content type.</param>

        public NotificationData(string Timestamp = null, string Payload = null, string Path = null, string MaxAge = null, string Ep = null, string Ct = null)
        {
            this.Timestamp = Timestamp;
            this.Payload = Payload;
            this.Path = Path;
            this.MaxAge = MaxAge;
            this.Ep = Ep;
            this.Ct = Ct;
            
        }
        
    
        /// <summary>
        /// Timestamp
        /// </summary>
        /// <value>Timestamp</value>
        [DataMember(Name="timestamp", EmitDefaultValue=false)]
        public string Timestamp { get; set; }
    
        /// <summary>
        /// Base64 encoded payload
        /// </summary>
        /// <value>Base64 encoded payload</value>
        [DataMember(Name="payload", EmitDefaultValue=false)]
        public string Payload { get; set; }
    
        /// <summary>
        /// URI path
        /// </summary>
        /// <value>URI path</value>
        [DataMember(Name="path", EmitDefaultValue=false)]
        public string Path { get; set; }
    
        /// <summary>
        /// Max age
        /// </summary>
        /// <value>Max age</value>
        [DataMember(Name="max-age", EmitDefaultValue=false)]
        public string MaxAge { get; set; }
    
        /// <summary>
        /// Endpoint name
        /// </summary>
        /// <value>Endpoint name</value>
        [DataMember(Name="ep", EmitDefaultValue=false)]
        public string Ep { get; set; }
    
        /// <summary>
        /// Content type
        /// </summary>
        /// <value>Content type</value>
        [DataMember(Name="ct", EmitDefaultValue=false)]
        public string Ct { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NotificationData {\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  Payload: ").Append(Payload).Append("\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
            sb.Append("  MaxAge: ").Append(MaxAge).Append("\n");
            sb.Append("  Ep: ").Append(Ep).Append("\n");
            sb.Append("  Ct: ").Append(Ct).Append("\n");
            
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
            return this.Equals(obj as NotificationData);
        }

        /// <summary>
        /// Returns true if NotificationData instances are equal
        /// </summary>
        /// <param name="other">Instance of NotificationData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NotificationData other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Timestamp == other.Timestamp ||
                    this.Timestamp != null &&
                    this.Timestamp.Equals(other.Timestamp)
                ) && 
                (
                    this.Payload == other.Payload ||
                    this.Payload != null &&
                    this.Payload.Equals(other.Payload)
                ) && 
                (
                    this.Path == other.Path ||
                    this.Path != null &&
                    this.Path.Equals(other.Path)
                ) && 
                (
                    this.MaxAge == other.MaxAge ||
                    this.MaxAge != null &&
                    this.MaxAge.Equals(other.MaxAge)
                ) && 
                (
                    this.Ep == other.Ep ||
                    this.Ep != null &&
                    this.Ep.Equals(other.Ep)
                ) && 
                (
                    this.Ct == other.Ct ||
                    this.Ct != null &&
                    this.Ct.Equals(other.Ct)
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
                
                if (this.Timestamp != null)
                    hash = hash * 59 + this.Timestamp.GetHashCode();
                
                if (this.Payload != null)
                    hash = hash * 59 + this.Payload.GetHashCode();
                
                if (this.Path != null)
                    hash = hash * 59 + this.Path.GetHashCode();
                
                if (this.MaxAge != null)
                    hash = hash * 59 + this.MaxAge.GetHashCode();
                
                if (this.Ep != null)
                    hash = hash * 59 + this.Ep.GetHashCode();
                
                if (this.Ct != null)
                    hash = hash * 59 + this.Ct.GetHashCode();
                
                return hash;
            }
        }

    }
}
