// <copyright file="FirmwareManifest.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Model.FirmwareManifest
{
    using System;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// Firmware manifest from Update Campaign.
    /// </summary>
    public class FirmwareManifest
    {
        /// <summary>
        /// Gets or sets gets or Sets Datafile
        /// </summary>
        public string Datafile { get; set; }

        /// <summary>
        /// Gets size in bytes of the uploaded firmware manifest binary
        /// </summary>
        [JsonProperty]
        public long? DatafileSize { get; private set; }

        /// <summary>
        /// Gets or sets the description of the object
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the version of the firmware manifest (as a timestamp)
        /// </summary>
        [JsonProperty]
        public DateTime? Timestamp { get; private set; }

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
        /// Gets the class of device
        /// </summary>
        [JsonProperty]
        public string DeviceClass { get; private set; }

        /// <summary>
        /// Gets the ID of the firmware manifest
        /// </summary>
        [JsonProperty]
        public string Id { get; private set; }

        /// <summary>
        /// Gets or sets the name of the object
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Map to FirmwareManifest object.
        /// </summary>
        /// <param name="data">Firmware Manifest</param>
        /// <returns>Firmware Manifest</returns>
        public static FirmwareManifest Map(update_service.Model.FirmwareManifest data)
        {
            var manifest = new FirmwareManifest
            {
                CreatedAt = data.CreatedAt,
                Datafile = data.Datafile,
                DatafileSize = data.DatafileSize,
                Description = data.Description,
                DeviceClass = data.DeviceClass,
                Id = data.Id,
                Name = data.Name,
                Timestamp = data.Timestamp,
                UpdatedAt = data.UpdatedAt
            };
            return manifest;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FirmwareManifestSerializerData {\n");
            sb.Append("  Datafile: ").Append(Datafile).Append("\n");
            sb.Append("  DatafileSize  ").Append(DatafileSize).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  DeviceClass: ").Append(DeviceClass).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}