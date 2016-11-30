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
    public partial class FactoryToolDownload :  IEquatable<FactoryToolDownload>
    { 
    
        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryToolDownload" /> class.
        /// Initializes a new instance of the <see cref="FactoryToolDownload" />class.
        /// </summary>
        /// <param name="DownloadPath">Download URL path for the specific archive..</param>
        /// <param name="Os">Supported operating system..</param>
        /// <param name="Filename">The archive filename..</param>
        /// <param name="Version">Factory Tool version..</param>
        /// <param name="Sha256">Generated SHA256 value of the archive file..</param>
        /// <param name="ClientVersions">Supported client versions for the tool..</param>
        /// <param name="Size">Size of archive file (MB)..</param>

        public FactoryToolDownload(string DownloadPath = null, string Os = null, string Filename = null, string Version = null, string Sha256 = null, string ClientVersions = null, string Size = null)
        {
            this.DownloadPath = DownloadPath;
            this.Os = Os;
            this.Filename = Filename;
            this.Version = Version;
            this.Sha256 = Sha256;
            this.ClientVersions = ClientVersions;
            this.Size = Size;
            
        }
        
    
        /// <summary>
        /// Download URL path for the specific archive.
        /// </summary>
        /// <value>Download URL path for the specific archive.</value>
        [DataMember(Name="downloadPath", EmitDefaultValue=false)]
        public string DownloadPath { get; set; }
    
        /// <summary>
        /// Supported operating system.
        /// </summary>
        /// <value>Supported operating system.</value>
        [DataMember(Name="os", EmitDefaultValue=false)]
        public string Os { get; set; }
    
        /// <summary>
        /// The archive filename.
        /// </summary>
        /// <value>The archive filename.</value>
        [DataMember(Name="filename", EmitDefaultValue=false)]
        public string Filename { get; set; }
    
        /// <summary>
        /// Factory Tool version.
        /// </summary>
        /// <value>Factory Tool version.</value>
        [DataMember(Name="version", EmitDefaultValue=false)]
        public string Version { get; set; }
    
        /// <summary>
        /// Generated SHA256 value of the archive file.
        /// </summary>
        /// <value>Generated SHA256 value of the archive file.</value>
        [DataMember(Name="Sha256", EmitDefaultValue=false)]
        public string Sha256 { get; set; }
    
        /// <summary>
        /// Supported client versions for the tool.
        /// </summary>
        /// <value>Supported client versions for the tool.</value>
        [DataMember(Name="clientVersions", EmitDefaultValue=false)]
        public string ClientVersions { get; set; }
    
        /// <summary>
        /// Size of archive file (MB).
        /// </summary>
        /// <value>Size of archive file (MB).</value>
        [DataMember(Name="size", EmitDefaultValue=false)]
        public string Size { get; set; }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FactoryToolDownload {\n");
            sb.Append("  DownloadPath: ").Append(DownloadPath).Append("\n");
            sb.Append("  Os: ").Append(Os).Append("\n");
            sb.Append("  Filename: ").Append(Filename).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  Sha256: ").Append(Sha256).Append("\n");
            sb.Append("  ClientVersions: ").Append(ClientVersions).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
            
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
            return this.Equals(obj as FactoryToolDownload);
        }

        /// <summary>
        /// Returns true if FactoryToolDownload instances are equal
        /// </summary>
        /// <param name="other">Instance of FactoryToolDownload to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FactoryToolDownload other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.DownloadPath == other.DownloadPath ||
                    this.DownloadPath != null &&
                    this.DownloadPath.Equals(other.DownloadPath)
                ) && 
                (
                    this.Os == other.Os ||
                    this.Os != null &&
                    this.Os.Equals(other.Os)
                ) && 
                (
                    this.Filename == other.Filename ||
                    this.Filename != null &&
                    this.Filename.Equals(other.Filename)
                ) && 
                (
                    this.Version == other.Version ||
                    this.Version != null &&
                    this.Version.Equals(other.Version)
                ) && 
                (
                    this.Sha256 == other.Sha256 ||
                    this.Sha256 != null &&
                    this.Sha256.Equals(other.Sha256)
                ) && 
                (
                    this.ClientVersions == other.ClientVersions ||
                    this.ClientVersions != null &&
                    this.ClientVersions.Equals(other.ClientVersions)
                ) && 
                (
                    this.Size == other.Size ||
                    this.Size != null &&
                    this.Size.Equals(other.Size)
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
                
                if (this.DownloadPath != null)
                    hash = hash * 59 + this.DownloadPath.GetHashCode();
                
                if (this.Os != null)
                    hash = hash * 59 + this.Os.GetHashCode();
                
                if (this.Filename != null)
                    hash = hash * 59 + this.Filename.GetHashCode();
                
                if (this.Version != null)
                    hash = hash * 59 + this.Version.GetHashCode();
                
                if (this.Sha256 != null)
                    hash = hash * 59 + this.Sha256.GetHashCode();
                
                if (this.ClientVersions != null)
                    hash = hash * 59 + this.ClientVersions.GetHashCode();
                
                if (this.Size != null)
                    hash = hash * 59 + this.Size.GetHashCode();
                
                return hash;
            }
        }

    }
}
