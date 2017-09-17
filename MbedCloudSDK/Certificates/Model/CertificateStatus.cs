// <copyright file="CertificateStatus.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

namespace MbedCloudSDK.Certificates.Model
{
    public enum CertificateStatus
    {
        /// <summary>
        /// Enum Bootstrap for "active"
        /// </summary>
        [EnumMember(Value = "active")]
        Active,

        /// <summary>
        /// Enum Bootstrap for "inactive"
        /// </summary>
        [EnumMember(Value = "inactive")]
        Inactive
    }
}