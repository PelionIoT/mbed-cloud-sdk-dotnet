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
    public partial class Webhook :  IEquatable<Webhook>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="Webhook" /> class.
        /// Initializes a new instance of the <see cref="Webhook" />class.
        /// </summary>
        /// <param name="Url">The URL to which the notifications must be sent. We recommend that you serve this URL over HTTPS..</param>
        /// <param name="Headers">Headers (key/value) that must be sent with the request. Optional..</param>

        public Webhook(string Url = null, Object Headers = null)
        {
            this.Url = Url;
            this.Headers = Headers;
            
        }
        
    
        /// <summary>
        /// The URL to which the notifications must be sent. We recommend that you serve this URL over HTTPS.
        /// </summary>
        /// <value>The URL to which the notifications must be sent. We recommend that you serve this URL over HTTPS.</value>
        [DataMember(Name="url", EmitDefaultValue=false)]
        public string Url { get; set; }
    
        /// <summary>
        /// Headers (key/value) that must be sent with the request. Optional.
        /// </summary>
        /// <value>Headers (key/value) that must be sent with the request. Optional.</value>
        [DataMember(Name="headers", EmitDefaultValue=false)]
        public Object Headers { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Webhook {\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  Headers: ").Append(Headers).Append("\n");
            
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
            return this.Equals(obj as Webhook);
        }

        /// <summary>
        /// Returns true if Webhook instances are equal
        /// </summary>
        /// <param name="other">Instance of Webhook to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Webhook other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Url == other.Url ||
                    this.Url != null &&
                    this.Url.Equals(other.Url)
                ) && 
                (
                    this.Headers == other.Headers ||
                    this.Headers != null &&
                    this.Headers.Equals(other.Headers)
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
                
                if (this.Url != null)
                    hash = hash * 59 + this.Url.GetHashCode();
                
                if (this.Headers != null)
                    hash = hash * 59 + this.Headers.GetHashCode();
                
                return hash;
            }
        }

    }
}
