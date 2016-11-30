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
    public partial class Endpoint :  IEquatable<Endpoint>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="Endpoint" /> class.
        /// Initializes a new instance of the <see cref="Endpoint" />class.
        /// </summary>
        /// <param name="Status">Possible values ACTIVE, STALE..</param>
        /// <param name="Q">Determines whether the device is in queue mode.\n&lt;br/&gt;&lt;br/&gt;&lt;b&gt;Queue mode&lt;/b&gt;&lt;br/&gt;\nWhen an endpoint is in queue mode, messages sent to the endpoint do not wake up the physical device.\nThe messages are queued and delivered when the device wakes up and connects to mbed Cloud Connect\nitself. You can also use the Queue mode when the device is behind a NAT and cannot be reached directly by\nmbed Cloud Connect.\n.</param>
        /// <param name="Type">Type of endpoint. (Free text).</param>
        /// <param name="Name">Unique identifier representing the endpoint..</param>

        public Endpoint(string Status = null, bool? Q = null, string Type = null, string Name = null)
        {
            this.Status = Status;
            this.Q = Q;
            this.Type = Type;
            this.Name = Name;
            
        }
        
    
        /// <summary>
        /// Possible values ACTIVE, STALE.
        /// </summary>
        /// <value>Possible values ACTIVE, STALE.</value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }
    
        /// <summary>
        /// Determines whether the device is in queue mode.\n&lt;br/&gt;&lt;br/&gt;&lt;b&gt;Queue mode&lt;/b&gt;&lt;br/&gt;\nWhen an endpoint is in queue mode, messages sent to the endpoint do not wake up the physical device.\nThe messages are queued and delivered when the device wakes up and connects to mbed Cloud Connect\nitself. You can also use the Queue mode when the device is behind a NAT and cannot be reached directly by\nmbed Cloud Connect.\n
        /// </summary>
        /// <value>Determines whether the device is in queue mode.\n&lt;br/&gt;&lt;br/&gt;&lt;b&gt;Queue mode&lt;/b&gt;&lt;br/&gt;\nWhen an endpoint is in queue mode, messages sent to the endpoint do not wake up the physical device.\nThe messages are queued and delivered when the device wakes up and connects to mbed Cloud Connect\nitself. You can also use the Queue mode when the device is behind a NAT and cannot be reached directly by\nmbed Cloud Connect.\n</value>
        [DataMember(Name="q", EmitDefaultValue=false)]
        public bool? Q { get; set; }
    
        /// <summary>
        /// Type of endpoint. (Free text)
        /// </summary>
        /// <value>Type of endpoint. (Free text)</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }
    
        /// <summary>
        /// Unique identifier representing the endpoint.
        /// </summary>
        /// <value>Unique identifier representing the endpoint.</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Endpoint {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Q: ").Append(Q).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            
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
            return this.Equals(obj as Endpoint);
        }

        /// <summary>
        /// Returns true if Endpoint instances are equal
        /// </summary>
        /// <param name="other">Instance of Endpoint to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Endpoint other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.Q == other.Q ||
                    this.Q != null &&
                    this.Q.Equals(other.Q)
                ) && 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
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
                
                if (this.Status != null)
                    hash = hash * 59 + this.Status.GetHashCode();
                
                if (this.Q != null)
                    hash = hash * 59 + this.Q.GetHashCode();
                
                if (this.Type != null)
                    hash = hash * 59 + this.Type.GetHashCode();
                
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                
                return hash;
            }
        }

    }
}
