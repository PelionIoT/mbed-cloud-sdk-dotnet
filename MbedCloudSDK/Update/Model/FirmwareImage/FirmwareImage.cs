// <copyright file="FirmwareImage.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Model.FirmwareImage
{
    using System;
    using System.Text;

    /// <summary>
    /// Firmware Image from Update API.
    /// </summary>
    public class FirmwareImage
    {
        /// <summary>
        /// Gets or sets the path to the firmware image
        /// </summary>
        public string Datafile { get; set; }

        /// <summary>
        /// Gets size in bytes of the uploaded firmware image binary
        /// </summary>
        public long? DatafileSize { get; private set; }

        /// <summary>
        /// Gets or sets the description of the object
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the time the object was created
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the time the object was updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets checksum generated for the datafile
        /// </summary>
        public string DatafileChecksum { get; set; }

        /// <summary>
        /// Gets or sets the ID of the firmware image
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the object
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
            sb.Append("  DatafileSize:  ").Append(DatafileSize).Append("\n");
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
        public static FirmwareImage Map(update_service.Model.FirmwareImage data)
        {
            FirmwareImage image = new FirmwareImage
            {
                CreatedAt = data.CreatedAt,
                Datafile = data.Datafile,
                DatafileSize = data.DatafileSize,
                DatafileChecksum = data.DatafileChecksum,
                Description = data.Description,
                Id = data.Id,
                Name = data.Name,
                UpdatedAt = data.UpdatedAt
            };
            return image;
        }
    }
}
