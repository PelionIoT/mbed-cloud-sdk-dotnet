// <copyright file="FirmwareManifestInfo.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Update.Model.FirmwareManifest
{
    using MbedCloudSDK.Update.Api;

    /// <summary>
    /// Specifies the properties that are used to create a new <see cref="FirmwareManifest"/>
    /// using <see cref="UpdateApi.AddFirmwareManifest(FirmwareManifestInfo)"/> methods.
    /// </summary>
    public sealed class FirmwareManifestInfo
    {
        /// <summary>
        /// Gets or sets the full path of the data file.
        /// </summary>
        /// <value>
        /// The full path of the data file. Default value for this property is <see langword="null"/>
        /// but it is not optional and a valid file path must be specified.
        /// </value>
        public string DataFile { get; set; }

        /// <summary>
        /// Gets or sets the full path of the key table file.
        /// </summary>
        /// <value>
        /// The full path of the key table file. Default value for this property is <see langword="null"/>,
        /// if left unspecified then no key table is uploaded.
        /// </value>
        public string KeyTable { get; set; }

        /// <summary>
        /// Gets or sets the name of the firmware manifest to create.
        /// </summary>
        /// <value>
        /// The full path of the data file. Default value for this property is <see langword="null"/>
        /// but it is not optional and a valid name must be specified.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the firmware manifest to create.
        /// </summary>
        /// <value>
        /// The full path of the data file. Default value for this property is <see langword="null"/>.
        /// </value>
        public string Description { get; set; }
    }
}