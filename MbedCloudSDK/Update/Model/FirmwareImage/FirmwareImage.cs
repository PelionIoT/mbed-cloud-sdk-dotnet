// <copyright file="FirmwareImage.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Model.FirmwareImage
{
    using System;
    using System.Text;
    using Mbed.Cloud.Foundation.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using Newtonsoft.Json;

    /// <summary>
    /// Firmware Image from Update API.
    /// </summary>
    public class FirmwareImage : Entity
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
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}
