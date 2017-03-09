using firmware_catalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Update.Model.FirmwareImage
{
    /// <summary>
    /// Firmware Image from Update API. 
    /// </summary>
    public class FirmwareImage
    {
        /// <summary>
        /// The binary file of firmware image
        /// </summary>
        public string Datafile { get; set; }
        
        /// <summary>
        /// The description of the object
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// The time the object was created
        /// </summary>
        public DateTime? CreatedAt { get; set; }
        
        /// <summary>
        /// The time the object was updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary>
        /// Checksum generated for the datafile
        /// </summary>
        public string DatafileChecksum { get; set; }
        
        /// <summary>
        /// The ID of the firmware image
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

        /// <summary>
        /// Map to FirmwareImage object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static FirmwareImage Map(FirmwareImage data)
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
