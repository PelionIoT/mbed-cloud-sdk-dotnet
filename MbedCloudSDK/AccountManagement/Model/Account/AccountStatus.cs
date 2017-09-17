// <copyright file="AccountStatus.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

namespace MbedCloudSDK.AccountManagement.Model.Account
{
    /// <summary>
    /// The status of the account.
    /// </summary>
    public enum AccountStatus
    {
        /// <summary>
        /// Enum ENROLLING for "ENROLLING"
        /// </summary>
        [EnumMember(Value = "ENROLLING")]
        ENROLLING,

        /// <summary>
        /// Enum ACTIVE for "ACTIVE"
        /// </summary>
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,

        /// <summary>
        /// Enum SUSPENDED for "SUSPENDED"
        /// </summary>
        [EnumMember(Value = "SUSPENDED")]
        SUSPENDED,

        /// <summary>
        /// Enum DISABLED for "DISABLED"
        /// </summary>
        [EnumMember(Value = "DISABLED")]
        DISABLED
    }
}
