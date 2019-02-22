// <copyright file="UpdateFilterMapEnum.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Filter.Maps
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Update Filters
    /// </summary>
    public enum UpdateFilterMapEnum
    {
        /// <summary>
        /// Enum FinishedAt for "FinishedAt"
        /// </summary>
        [EnumMember(Value = "finished")]
        FinishedAt,

        /// <summary>
        /// Enum ManifestId for "ManifestId"
        /// </summary>
        [EnumMember(Value = "root_manifest_id")]
        ManifestId,

        /// <summary>
        /// Enum ManifestUrl for "ManifestUrl"
        /// </summary>
        [EnumMember(Value = "root_manifest_url")]
        ManifestUrl,

        /// <summary>
        /// Enum TScheduledAt for "ScheduledAt"
        /// </summary>
        [EnumMember(Value = "when")]
        ScheduledAt
    }
}