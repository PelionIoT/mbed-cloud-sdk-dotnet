// <copyright file="DeviceFilterMapEnum.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Common.Filter.Maps
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Device Filter Enums
    /// </summary>
    public enum DeviceFilterMapEnum
    {
        /// <summary>
        /// Enum Alias for "Alias"
        /// </summary>
        [EnumMember(Value = "endpoint_name")]
        Alias,

        /// <summary>
        /// Enum BootstrapCertificateExpiration for "BootstrapCertificateExpiration"
        /// </summary>
        [EnumMember(Value = "bootstrap_expiration_date")]
        BootstrapCertificateExpiration,

        /// <summary>
        /// Enum CertificateFingerprint for "CertificateFingerprint"
        /// </summary>
        [EnumMember(Value = "device_key")]
        CertificateFingerprint,

        /// <summary>
        /// Enum CertificateIssuerId for "CertificateIssuerId"
        /// </summary>
        [EnumMember(Value = "ca_id")]
        CertificateIssuerId,

        /// <summary>
        /// Enum ConnectorCertificateExpiration for "ConnectorCertificateExpiration"
        /// </summary>
        [EnumMember(Value = "connector_expiration_date")]
        ConnectorCertificateExpiration,

        /// <summary>
        /// Enum DeviceType for "DeviceType"
        /// </summary>
        [EnumMember(Value = "endpoint_type")]
        DeviceType,

        /// <summary>
        /// Enum EventDate for "EventDate"
        /// </summary>
        [EnumMember(Value = "date_time")]
        EventDate,

        /// <summary>
        /// Enum Type for "Type"
        /// </summary>
        [EnumMember(Value = "event_type")]
        Type
    }
}