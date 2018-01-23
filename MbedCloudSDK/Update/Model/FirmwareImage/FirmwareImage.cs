// <copyright file="FirmwareImage.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Model.FirmwareImage
{
    using System;
    using System.Text;
    using MbedCloudSDK.Common;
    using Newtonsoft.Json;

    /// <summary>
    /// Firmware Image from Update API.
    /// </summary>
    public class FirmwareImage
    {
        /// <summary>
        /// Gets the path to the firmware image
        /// </summary>
        [JsonProperty]
        public string Url { get; private set; }

        /// <summary>
        /// Gets size in bytes of the uploaded firmware image binary
        /// </summary>
        [JsonProperty]
        public long? DatafileSize { get; private set; }

        /// <summary>
        /// Gets or sets the description of the object
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the time the object was created
        /// </summary>
        [JsonProperty]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Gets the time the object was updated
        /// </summary>
        [JsonProperty]
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Gets checksum generated for the datafile
        /// </summary>
        [JsonProperty]
        public string DatafileChecksum { get; private set; }

        /// <summary>
        /// Gets the ID of the firmware image
        /// </summary>
        [JsonProperty]
        public string Id { get; private set; }

        /// <summary>
        /// Gets or sets the name of the object
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Map to FirmwareImage object.
        /// </summary>
        /// <param name="data">Firmwae image</param>
        /// <returns>Firmware image</returns>
        public static FirmwareImage Map(update_service.Model.FirmwareImage data)
        {
            var image = new FirmwareImage
            {
                CreatedAt = data.CreatedAt.ToNullableUniversalTime(),
                Url = data.Datafile,
                DatafileSize = data.DatafileSize,
                DatafileChecksum = data.DatafileChecksum,
                Description = data.Description,
                Id = data.Id,
                Name = data.Name,
                UpdatedAt = data.UpdatedAt.ToNullableUniversalTime()
            };
            return image;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FirmwareImageSerializerData {\n");
            sb.Append("  Datafile: ").Append(Url).Append("\n");
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
    }
}
