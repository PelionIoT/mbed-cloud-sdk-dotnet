// <copyright file="FirmwareManifest.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Model.FirmwareManifest
{
    using System;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using Newtonsoft.Json;

    /// <summary>
    /// Firmware manifest from Update Campaign.
    /// </summary>
    public class FirmwareManifest : BaseModel
    {
        /// <summary>
        /// Gets the URL of the firmware manifest binary.
        /// </summary>
        [JsonProperty]
        public string Url { get; private set; }

        /// <summary>
        /// Gets the size in bytes of the uploaded firmware manifest binary.
        /// </summary>
        /// <value>
        /// The size, in bytes, of the uploaded firmware manifest binary. You can retrieve
        /// the binary file through the URL <see cref="Url"/>.
        /// </value>
        [JsonProperty]
        public long? DatafileSize { get; private set; }

        /// <summary>
        /// Gets or sets the full path of the data file.
        /// </summary>
        /// <value>
        /// The full path of the data file. Default value for this property is <see langword="null"/>
        /// but it is not optional and a valid file path must be specified.
        /// </value>
        public string DataFile { get; set; }

        /// <summary>
        /// Gets the URL of key table of pre-shared keys for devices.
        /// </summary>
        /// <value>The URL of key table of pre-shared keys for devices.</value>
        [JsonProperty]
        public string KeyTableFile { get; private set; }

        /// <summary>
        /// Gets or sets the full path of the key table file.
        /// </summary>
        /// <value>
        /// The full path of the key table file. Default value for this property is <see langword="null"/>,
        /// if left unspecified then no key table is uploaded.
        /// </value>
        public string KeyTableUrl { get; set; }

        /// <summary>
        /// Gets or sets the description of the object.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the version of the firmware manifest (as a timestamp)
        /// </summary>
        [JsonProperty]
        public DateTime? Timestamp { get; private set; }

        /// <summary>
        /// Gets the time the object was created.
        /// </summary>
        [JsonProperty]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Gets the time the object was updated.
        /// </summary>
        [JsonProperty]
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Gets the class of device.
        /// </summary>
        [JsonProperty]
        public string DeviceClass { get; private set; }

        /// <summary>
        /// Gets or sets the name of the object.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the time the object was updated.
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// Map to FirmwareManifest object.
        /// </summary>
        /// <param name="data">Firmware Manifest.</param>
        /// <returns>Firmware Manifest.</returns>
        public static FirmwareManifest Map(update_service.Model.FirmwareManifest data)
        {
            return new FirmwareManifest
            {
                CreatedAt = data.CreatedAt.ToNullableUniversalTime(),
                Url = data.Datafile,
                DatafileSize = data.DatafileSize,
                KeyTableUrl = data.KeyTable,
                Description = data.Description,
                DeviceClass = data.DeviceClass,
                Id = data.Id,
                Name = data.Name,
                Timestamp = data.Timestamp.ToNullableUniversalTime(),
                UpdatedAt = data.UpdatedAt.ToNullableUniversalTime()
            };
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}