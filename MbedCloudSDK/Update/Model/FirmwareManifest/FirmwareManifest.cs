// <copyright file="FirmwareManifest.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Model.FirmwareManifest
{
    using System;
    using MbedCloudSDK.Common;
    using Newtonsoft.Json;

    /// <summary>
    /// Firmware manifest from Update Campaign.
    /// </summary>
    public class FirmwareManifest
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
        /// Gets the URL of key table of pre-shared keys for devices.
        /// </summary>
        /// <value>The URL of key table of pre-shared keys for devices.</value>
        [JsonProperty]
        public string KeyTable { get; private set; }

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
        /// Gets the ID of the firmware manifest.
        /// </summary>
        [JsonProperty]
        public string Id { get; private set; }

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
                KeyTable = data.KeyTable,
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