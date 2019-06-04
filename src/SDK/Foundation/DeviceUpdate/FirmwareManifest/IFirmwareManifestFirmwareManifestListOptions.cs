// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="IFirmwareManifestFirmwareManifestListOptions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using Mbed.Cloud.Common.Filters;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// FirmwareManifestFirmwareManifestListOptions
    /// </summary>
    public interface IFirmwareManifestFirmwareManifestListOptions : IQueryOptions
    {
        /// <summary>
        /// Filter object
        /// </summary>
        Filter Filter
        {
            get;
            set;
        }

        FirmwareManifestFirmwareManifestListOptions CreatedAtIn(params DateTime[] value);
        FirmwareManifestFirmwareManifestListOptions CreatedAtNotIn(params DateTime[] value);
        FirmwareManifestFirmwareManifestListOptions CreatedAtLessThan(DateTime value);
        FirmwareManifestFirmwareManifestListOptions CreatedAtGreaterThan(DateTime value);
        FirmwareManifestFirmwareManifestListOptions DatafileUrlEqualTo(string value);
        FirmwareManifestFirmwareManifestListOptions DatafileUrlNotEqualTo(string value);
        FirmwareManifestFirmwareManifestListOptions DatafileUrlIn(params string[] value);
        FirmwareManifestFirmwareManifestListOptions DatafileUrlNotIn(params string[] value);
        FirmwareManifestFirmwareManifestListOptions DatafileSizeEqualTo(long value);
        FirmwareManifestFirmwareManifestListOptions DatafileSizeNotEqualTo(long value);
        FirmwareManifestFirmwareManifestListOptions DatafileSizeIn(params long[] value);
        FirmwareManifestFirmwareManifestListOptions DatafileSizeNotIn(params long[] value);
        FirmwareManifestFirmwareManifestListOptions DescriptionEqualTo(string value);
        FirmwareManifestFirmwareManifestListOptions DescriptionNotEqualTo(string value);
        FirmwareManifestFirmwareManifestListOptions DescriptionIn(params string[] value);
        FirmwareManifestFirmwareManifestListOptions DescriptionNotIn(params string[] value);
        FirmwareManifestFirmwareManifestListOptions DeviceClassEqualTo(string value);
        FirmwareManifestFirmwareManifestListOptions DeviceClassNotEqualTo(string value);
        FirmwareManifestFirmwareManifestListOptions DeviceClassIn(params string[] value);
        FirmwareManifestFirmwareManifestListOptions DeviceClassNotIn(params string[] value);
        FirmwareManifestFirmwareManifestListOptions IdEqualTo(string value);
        FirmwareManifestFirmwareManifestListOptions IdNotEqualTo(string value);
        FirmwareManifestFirmwareManifestListOptions IdIn(params string[] value);
        FirmwareManifestFirmwareManifestListOptions IdNotIn(params string[] value);
        FirmwareManifestFirmwareManifestListOptions NameEqualTo(string value);
        FirmwareManifestFirmwareManifestListOptions NameNotEqualTo(string value);
        FirmwareManifestFirmwareManifestListOptions NameIn(params string[] value);
        FirmwareManifestFirmwareManifestListOptions NameNotIn(params string[] value);
        FirmwareManifestFirmwareManifestListOptions TimestampIn(params DateTime[] value);
        FirmwareManifestFirmwareManifestListOptions TimestampNotIn(params DateTime[] value);
        FirmwareManifestFirmwareManifestListOptions TimestampLessThan(DateTime value);
        FirmwareManifestFirmwareManifestListOptions TimestampGreaterThan(DateTime value);
        FirmwareManifestFirmwareManifestListOptions UpdatedAtIn(params DateTime[] value);
        FirmwareManifestFirmwareManifestListOptions UpdatedAtNotIn(params DateTime[] value);
        FirmwareManifestFirmwareManifestListOptions UpdatedAtLessThan(DateTime value);
        FirmwareManifestFirmwareManifestListOptions UpdatedAtGreaterThan(DateTime value);
    }
}