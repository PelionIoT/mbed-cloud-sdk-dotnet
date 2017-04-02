/* 
 * Connect API
 *
 * mbed Cloud Connect API allows web applications to communicate with devices. You can subscribe to device resources and read/write values to them. mbed Cloud Connect makes connectivity to devices easy by queuing requests and caching resource values.
 *
 * OpenAPI spec version: 2
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

namespace mds.Model
{
    /// <summary>
    /// EndpointData
    /// </summary>
    [DataContract]
    public partial class EndpointData :  IEquatable<EndpointData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointData" /> class.
        /// </summary>
        /// <param name="Q">Queue mode (default value is false)..</param>
        /// <param name="Ept">Endpoint type..</param>
        /// <param name="OriginalEp">In case of a self-provided endpoint name that is used to initiate the device registration, mbed Cloud provides a new device name to be used from that point on. The new mbed-Cloud-provided name is forwarded as the &#39;ep&#39; property and the original self-provided one as the optional &#39;original-ep&#39; property in a registration notification. The names can then be mapped accordingly. mbed Cloud saves the original endpoint name for future device registrations so there is no need to do the mapping again. .</param>
        /// <param name="Resources">Resources.</param>
        /// <param name="Ep">Endpoint name..</param>
        public EndpointData(bool? Q = default(bool?), string Ept = default(string), string OriginalEp = default(string), List<ResourcesData> Resources = default(List<ResourcesData>), string Ep = default(string))
        {
            this.Q = Q;
            this.Ept = Ept;
            this.OriginalEp = OriginalEp;
            this.Resources = Resources;
            this.Ep = Ep;
        }
        
        /// <summary>
        /// Queue mode (default value is false).
        /// </summary>
        /// <value>Queue mode (default value is false).</value>
        [DataMember(Name="q", EmitDefaultValue=false)]
        public bool? Q { get; set; }
        /// <summary>
        /// Endpoint type.
        /// </summary>
        /// <value>Endpoint type.</value>
        [DataMember(Name="ept", EmitDefaultValue=false)]
        public string Ept { get; set; }
        /// <summary>
        /// In case of a self-provided endpoint name that is used to initiate the device registration, mbed Cloud provides a new device name to be used from that point on. The new mbed-Cloud-provided name is forwarded as the &#39;ep&#39; property and the original self-provided one as the optional &#39;original-ep&#39; property in a registration notification. The names can then be mapped accordingly. mbed Cloud saves the original endpoint name for future device registrations so there is no need to do the mapping again. 
        /// </summary>
        /// <value>In case of a self-provided endpoint name that is used to initiate the device registration, mbed Cloud provides a new device name to be used from that point on. The new mbed-Cloud-provided name is forwarded as the &#39;ep&#39; property and the original self-provided one as the optional &#39;original-ep&#39; property in a registration notification. The names can then be mapped accordingly. mbed Cloud saves the original endpoint name for future device registrations so there is no need to do the mapping again. </value>
        [DataMember(Name="original-ep", EmitDefaultValue=false)]
        public string OriginalEp { get; set; }
        /// <summary>
        /// Gets or Sets Resources
        /// </summary>
        [DataMember(Name="resources", EmitDefaultValue=false)]
        public List<ResourcesData> Resources { get; set; }
        /// <summary>
        /// Endpoint name.
        /// </summary>
        /// <value>Endpoint name.</value>
        [DataMember(Name="ep", EmitDefaultValue=false)]
        public string Ep { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EndpointData {\n");
            sb.Append("  Q: ").Append(Q).Append("\n");
            sb.Append("  Ept: ").Append(Ept).Append("\n");
            sb.Append("  OriginalEp: ").Append(OriginalEp).Append("\n");
            sb.Append("  Resources: ").Append(Resources).Append("\n");
            sb.Append("  Ep: ").Append(Ep).Append("\n");
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
            return this.Equals(obj as EndpointData);
        }

        /// <summary>
        /// Returns true if EndpointData instances are equal
        /// </summary>
        /// <param name="other">Instance of EndpointData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EndpointData other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Q == other.Q ||
                    this.Q != null &&
                    this.Q.Equals(other.Q)
                ) && 
                (
                    this.Ept == other.Ept ||
                    this.Ept != null &&
                    this.Ept.Equals(other.Ept)
                ) && 
                (
                    this.OriginalEp == other.OriginalEp ||
                    this.OriginalEp != null &&
                    this.OriginalEp.Equals(other.OriginalEp)
                ) && 
                (
                    this.Resources == other.Resources ||
                    this.Resources != null &&
                    this.Resources.SequenceEqual(other.Resources)
                ) && 
                (
                    this.Ep == other.Ep ||
                    this.Ep != null &&
                    this.Ep.Equals(other.Ep)
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
                if (this.Q != null)
                    hash = hash * 59 + this.Q.GetHashCode();
                if (this.Ept != null)
                    hash = hash * 59 + this.Ept.GetHashCode();
                if (this.OriginalEp != null)
                    hash = hash * 59 + this.OriginalEp.GetHashCode();
                if (this.Resources != null)
                    hash = hash * 59 + this.Resources.GetHashCode();
                if (this.Ep != null)
                    hash = hash * 59 + this.Ep.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
