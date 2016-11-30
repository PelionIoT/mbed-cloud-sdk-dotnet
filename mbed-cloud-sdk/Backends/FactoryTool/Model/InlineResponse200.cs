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

namespace factory_tool.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class InlineResponse200 :  IEquatable<InlineResponse200>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineResponse200" /> class.
        /// Initializes a new instance of the <see cref="InlineResponse200" />class.
        /// </summary>
        /// <param name="LinArchiveInfo">LinArchiveInfo.</param>
        /// <param name="WinArchiveInfo">WinArchiveInfo.</param>

        public InlineResponse200(FactoryToolDownload LinArchiveInfo = null, FactoryToolDownload WinArchiveInfo = null)
        {
            this.LinArchiveInfo = LinArchiveInfo;
            this.WinArchiveInfo = WinArchiveInfo;
            
        }
        
    
        /// <summary>
        /// Gets or Sets LinArchiveInfo
        /// </summary>
        [DataMember(Name="linArchiveInfo", EmitDefaultValue=false)]
        public FactoryToolDownload LinArchiveInfo { get; set; }
    
        /// <summary>
        /// Gets or Sets WinArchiveInfo
        /// </summary>
        [DataMember(Name="winArchiveInfo", EmitDefaultValue=false)]
        public FactoryToolDownload WinArchiveInfo { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse200 {\n");
            sb.Append("  LinArchiveInfo: ").Append(LinArchiveInfo).Append("\n");
            sb.Append("  WinArchiveInfo: ").Append(WinArchiveInfo).Append("\n");
            
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
            return this.Equals(obj as InlineResponse200);
        }

        /// <summary>
        /// Returns true if InlineResponse200 instances are equal
        /// </summary>
        /// <param name="other">Instance of InlineResponse200 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse200 other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.LinArchiveInfo == other.LinArchiveInfo ||
                    this.LinArchiveInfo != null &&
                    this.LinArchiveInfo.Equals(other.LinArchiveInfo)
                ) && 
                (
                    this.WinArchiveInfo == other.WinArchiveInfo ||
                    this.WinArchiveInfo != null &&
                    this.WinArchiveInfo.Equals(other.WinArchiveInfo)
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
                
                if (this.LinArchiveInfo != null)
                    hash = hash * 59 + this.LinArchiveInfo.GetHashCode();
                
                if (this.WinArchiveInfo != null)
                    hash = hash * 59 + this.WinArchiveInfo.GetHashCode();
                
                return hash;
            }
        }

    }
}
