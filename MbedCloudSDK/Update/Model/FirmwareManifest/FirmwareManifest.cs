using update_service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbedCloudSDK.Update.Model.FirmwareManifest
{
    /// <summary>
    /// Firmware manifest from Update Campaign.
    /// </summary>
    public class FirmwareManifest
    {
        /// <summary>
        /// Gets or Sets Datafile
        /// </summary>
        public string Datafile { get; set; }

        /// <summary>
        /// Checksum generated for the datafile
        /// </summary>
        public string DatafileChecksum { get; private set; }

        /// <summary>
        /// Size in bytes of the uploaded firmware manifest binary
        /// </summary>
        public long? DatafileSize { get; private set; }
        
        /// <summary>
        /// The description of the object
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// The version of the firmware manifest (as a timestamp)
        /// </summary>
        public DateTime? Timestamp { get; set; }
        
        /// <summary>
        /// The time the object was created
        /// </summary>
        public DateTime? CreatedAt { get; set; }
        
        /// <summary>
        /// The time the object was updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary>
        /// The contents of the manifest
        /// </summary>
        public Object ManifestContents { get; set; }
        
        /// <summary>
        /// The class of device
        /// </summary>
        public string DeviceClass { get; set; }
        
        /// <summary>
        /// The ID of the firmware manifest
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// The name of the object
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FirmwareManifestSerializerData {\n");
            sb.Append("  Datafile: ").Append(Datafile).Append("\n");
            sb.Append("  DatafileChecksum  ").Append(DatafileChecksum).Append("\n");
            sb.Append("  DatafileSize  ").Append(DatafileSize).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  ManifestContents: ").Append(ManifestContents).Append("\n");
            sb.Append("  DeviceClass: ").Append(DeviceClass).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Map to FirmwareManifest object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static FirmwareManifest Map(update_service.Model.FirmwareManifest data)
        {
            FirmwareManifest manifest = new FirmwareManifest();
            manifest.CreatedAt = data.CreatedAt;
            manifest.Datafile = data.Datafile;
            manifest.DatafileSize = data.DatafileSize;
            manifest.DatafileChecksum = data.DatafileChecksum;
            manifest.Description = data.Description;
            manifest.DeviceClass = data.DeviceClass;
            manifest.Id = data.Id;
            manifest.ManifestContents = data.ManifestContents;
            manifest.Name = data.Name;
            manifest.Timestamp = data.Timestamp;
            manifest.UpdatedAt = data.UpdatedAt;
            return manifest;
        }

    }
}
