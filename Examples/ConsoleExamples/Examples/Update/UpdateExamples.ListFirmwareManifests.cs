// <copyright file="UpdateExamples.ListFirmwareManifests.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.Update
{
    using System;
    using System.Collections.Generic;
    using Mbed.Cloud.Foundation.Common;
    using MbedCloudSDK.Update.Model.FirmwareManifest;

    /// <summary>
    /// Update examples
    /// </summary>
    public partial class UpdateExamples
    {
        /// <summary>
        /// List the first 5 firmware manifests
        /// </summary>
        /// <returns>list of firmware manifests</returns>
        public IEnumerable<FirmwareManifest> ListManifests()
        {
            var options = new QueryOptions
            {
                Limit = 5,
            };
            var manifests = api.ListFirmwareManifests(options);
            foreach (var item in manifests)
            {
                Console.WriteLine(item);
            }

            return manifests;
        }

        /// <summary>
        /// Add a firmware image
        /// </summary>
        /// <returns>The firmware image</returns>
        public FirmwareManifest AddFirmwareManifest()
        {
            var firmwareImage = api.AddFirmwareManifest("./ConsoleExamples/images/firmware_manifest.bin", "new firmware manifest");
            Console.WriteLine(firmwareImage);
            api.DeleteFirmwareManifest(firmwareImage.Id);
            return firmwareImage;
        }
    }
}
