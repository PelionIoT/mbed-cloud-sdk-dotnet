// <copyright file="MultifactorAuthenticationStatusEnum.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Model.Account
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The status of an accounts two facotr authentication
    /// </summary>
    public enum MultifactorAuthenticationStatusEnum
    {
        /// <summary>
        /// Enum Enforced for "enforced"
        /// </summary>
        [EnumMember(Value = "enforced")]
        Enforced,

        /// <summary>
        /// Enum Optional for "optional"
        /// </summary>
        [EnumMember(Value = "optional")]
        Optional
    }
}