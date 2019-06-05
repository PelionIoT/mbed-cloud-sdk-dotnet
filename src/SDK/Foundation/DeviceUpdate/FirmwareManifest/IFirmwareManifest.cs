// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="IFirmwareManifest.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// FirmwareManifest
    /// </summary>
    public interface IFirmwareManifest
    {
        [JsonConverter(typeof(CustomDateConverter), "yyyy-MM-dd'T'HH:mm:ss.fffZ")]
        /// <summary>
        /// created_at
        /// </summary>
        DateTime? CreatedAt
        {
            get;
        }

        /// <summary>
        /// datafile_size
        /// </summary>
        long? DatafileSize
        {
            get;
        }

        /// <summary>
        /// datafile_url
        /// </summary>
        string DatafileUrl
        {
            get;
        }

        /// <summary>
        /// description
        /// </summary>
        string Description
        {
            get;
            set;
        }

        /// <summary>
        /// device_class
        /// </summary>
        string DeviceClass
        {
            get;
        }

        /// <summary>
        /// key_table_url
        /// </summary>
        string KeyTableUrl
        {
            get;
        }

        /// <summary>
        /// name
        /// </summary>
        string Name
        {
            get;
            set;
        }
        [JsonConverter(typeof(CustomDateConverter), "yyyy-MM-dd'T'HH:mm:ss.fffZ")]
        /// <summary>
        /// timestamp
        /// </summary>
        DateTime? Timestamp
        {
            get;
        }
        [JsonConverter(typeof(CustomDateConverter), "yyyy-MM-dd'T'HH:mm:ss.fffZ")]
        /// <summary>
        /// updated_at
        /// </summary>
        DateTime? UpdatedAt
        {
            get;
        }
    }
}