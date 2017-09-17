// <copyright file="CertificateType.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

namespace MbedCloudSDK.Certificates.Model
{
    /// <summary>
    /// Type of Trusted Certificate
    /// </summary>
    public enum CertificateType
    {
        /// <summary>
        /// Enum Bootstrap for "bootstrap"
        /// </summary>
        [EnumMember(Value = "developer")]
        Developer,

        /// <summary>
        /// Enum Lwm2m for "lwm2m"
        /// </summary>
        [EnumMember(Value = "lwm2m")]
        Lwm2m,

        /// <summary>
        /// Enum Bootstrap for "bootstrap"
        /// </summary>
        [EnumMember(Value = "bootstrap")]
        Bootstrap
    }
}
