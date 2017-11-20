// <copyright file="UpdateExamples.ListFirmwareManifests.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace ConsoleExamples.Examples.Update
{
    using System;
    using System.Collections.Generic;
    using MbedCloudSDK.Common.Query;
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
        public List<FirmwareManifest> ListManifests()
        {
            var options = new QueryOptions
            {
                Limit = 5,
            };
            var manifests = api.ListFirmwareManifests(options).Data;
            foreach (var item in manifests)
            {
                Console.WriteLine(item);
            }

            return manifests;
        }
    }
}
