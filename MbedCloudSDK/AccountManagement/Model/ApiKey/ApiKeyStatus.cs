// <copyright file="ApiKeyStatus.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Model.ApiKey
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The status of the API key.
    /// </summary>
    public enum ApiKeyStatus
    {
        /// <summary>
        /// Enum ACTIVE for "ACTIVE"
        /// </summary>
        [EnumMember(Value = nameof(ACTIVE))]
        ACTIVE,

        /// <summary>
        /// Enum INACTIVE for "INACTIVE"
        /// </summary>
        [EnumMember(Value = nameof(INACTIVE))]
        INACTIVE
    }
}
