using firmware_catalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Update.Model.FirmwareImage
{
    public class FirmwareImage
    {
        /// <summary>
        /// The binary file of firmware image
        /// </summary>
        /// <value>The binary file of firmware image</value>
        public string Datafile { get; set; }
        
        /// <summary>
        /// The description of the object
        /// </summary>
        /// <value>The description of the object</value>
        public string Description { get; set; }
        
        /// <summary>
        /// The time the object was created
        /// </summary>
        /// <value>The time the object was created</value>
        public DateTime? CreatedAt { get; set; }
        
        /// <summary>
        /// The time the object was updated
        /// </summary>
        /// <value>The time the object was updated</value>
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary>
        /// Checksum generated for the datafile
        /// </summary>
        /// <value>Checksum generated for the datafile</value>
        public string DatafileChecksum { get; set; }
        
        /// <summary>
        /// The ID of the firmware image
        /// </summary>
        /// <value>The ID of the firmware image</value>
        public string Id { get; set; }
        
        /// <summary>
        /// The name of the object
        /// </summary>
        /// <value>The name of the object</value>
        public string Name { get; set; }
        
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FirmwareImageSerializerData {\n");
            sb.Append("  Datafile: ").Append(Datafile).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  DatafileChecksum: ").Append(DatafileChecksum).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        public static FirmwareImage Map(FirmwareImageSerializerData data)
        {
            FirmwareImage image = new FirmwareImage();
            image.CreatedAt = data.CreatedAt;
            image.Datafile = data.Datafile;
            image.DatafileChecksum = data.DatafileChecksum;
            image.Description = data.Description;
            image.Id = data.Id;
            image.Name = data.Name;
            image.UpdatedAt = data.UpdatedAt;
            return image;
        }
    }
}
