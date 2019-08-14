// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="IApiKey.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using Mbed.Cloud.Foundation.Enums;

    /// <summary>
    /// ApiKey
    /// </summary>
    public interface IApiKey
    {
        /// <summary>
        /// account_id
        /// </summary>
        string AccountId
        {
            get;
        }
        [JsonConverter(typeof(CustomDateConverter), "yyyy-MM-dd'T'HH:mm:ss.fffZ")]
        /// <summary>
        /// created_at
        /// </summary>
        DateTime? CreatedAt
        {
            get;
        }

        /// <summary>
        /// creation_time
        /// </summary>
        long? CreationTime
        {
            get;
        }

        /// <summary>
        /// groups
        /// </summary>
        List<string> Groups
        {
            get;
            set;
        }

        /// <summary>
        /// key
        /// </summary>
        string Key
        {
            get;
        }

        /// <summary>
        /// last_login_time
        /// </summary>
        long? LastLoginTime
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

        /// <summary>
        /// owner
        /// </summary>
        string Owner
        {
            get;
            set;
        }

        /// <summary>
        /// status
        /// </summary>
        ApiKeyStatus? Status
        {
            get;
            set;
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