// <copyright file="UserStatus.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Model.User
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The status of the user. INVITED means that the user has not accepted the invitation request. RESET means that the password must be changed immediately.
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// Enum INVITED for "INVITED"
        /// </summary>
        [EnumMember(Value = nameof(INVITED))]
        INVITED,

        /// <summary>
        /// Enum ACTIVE for "ACTIVE"
        /// </summary>
        [EnumMember(Value = nameof(ACTIVE))]
        ACTIVE,

        /// <summary>
        /// Enum RESET for "RESET"
        /// </summary>
        [EnumMember(Value = nameof(RESET))]
        RESET,

        /// <summary>
        /// Enum INACTIVE for "INACTIVE"
        /// </summary>
        [EnumMember(Value = nameof(INACTIVE))]
        INACTIVE
    }
}
