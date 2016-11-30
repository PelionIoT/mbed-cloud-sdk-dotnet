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

namespace firmware_catalog.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class WriteFirmwareImageSerializer :  IEquatable<WriteFirmwareImageSerializer>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="WriteFirmwareImageSerializer" /> class.
        /// Initializes a new instance of the <see cref="WriteFirmwareImageSerializer" />class.
        /// </summary>
        /// <param name="Datafile">The binary file of firmware image (required).</param>
        /// <param name="Description">The description of the object.</param>
        /// <param name="Name">The name of the object (required).</param>

        public WriteFirmwareImageSerializer(string Datafile = null, string Description = null, string Name = null)
        {
            // to ensure "Datafile" is required (not null)
            if (Datafile == null)
            {
                throw new InvalidDataException("Datafile is a required property for WriteFirmwareImageSerializer and cannot be null");
            }
            else
            {
                this.Datafile = Datafile;
            }
            // to ensure "Name" is required (not null)
            if (Name == null)
            {
                throw new InvalidDataException("Name is a required property for WriteFirmwareImageSerializer and cannot be null");
            }
            else
            {
                this.Name = Name;
            }
            this.Description = Description;
            
        }
        
    
        /// <summary>
        /// The binary file of firmware image
        /// </summary>
        /// <value>The binary file of firmware image</value>
        [DataMember(Name="datafile", EmitDefaultValue=false)]
        public string Datafile { get; set; }
    
        /// <summary>
        /// The description of the object
        /// </summary>
        /// <value>The description of the object</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
    
        /// <summary>
        /// The name of the object
        /// </summary>
        /// <value>The name of the object</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WriteFirmwareImageSerializer {\n");
            sb.Append("  Datafile: ").Append(Datafile).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return this.Equals(obj as WriteFirmwareImageSerializer);
        }

        /// <summary>
        /// Returns true if WriteFirmwareImageSerializer instances are equal
        /// </summary>
        /// <param name="other">Instance of WriteFirmwareImageSerializer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WriteFirmwareImageSerializer other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Datafile == other.Datafile ||
                    this.Datafile != null &&
                    this.Datafile.Equals(other.Datafile)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
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
                
                if (this.Datafile != null)
                    hash = hash * 59 + this.Datafile.GetHashCode();
                
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                
                return hash;
            }
        }

    }
}
