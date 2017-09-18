// <copyright file="FirmwareManifest.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Model.FirmwareManifest
{
    using System;
    using System.Text;

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
        /// Gets checksum generated for the datafile
        /// </summary>
        public string DatafileChecksum { get; private set; }

        /// <summary>
        /// Gets size in bytes of the uploaded firmware manifest binary
        /// </summary>
        public long? DatafileSize { get; private set; }

        /// <summary>
        /// Gets or sets the description of the object
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the version of the firmware manifest (as a timestamp)
        /// </summary>
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the time the object was created
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the time the object was updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the class of device
        /// </summary>
        public string DeviceClass { get; set; }

        /// <summary>
        /// Gets or sets the ID of the firmware manifest
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
            sb.Append("class FirmwareManifestSerializerData {\n");
            sb.Append("  Datafile: ").Append(Datafile).Append("\n");
            sb.Append("  DatafileChecksum  ").Append(DatafileChecksum).Append("\n");
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

        /// <summary>
        /// Map to FirmwareManifest object.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static FirmwareManifest Map(update_service.Model.FirmwareManifest data)
        {
            FirmwareManifest manifest = new FirmwareManifest
            {
                CreatedAt = data.CreatedAt,
                Datafile = data.Datafile,
                DatafileSize = data.DatafileSize,
                DatafileChecksum = data.DatafileChecksum,
                Description = data.Description,
                DeviceClass = data.DeviceClass,
                Id = data.Id,
                Name = data.Name,
                Timestamp = data.Timestamp,
                UpdatedAt = data.UpdatedAt
            };
            return manifest;
        }
    }
}