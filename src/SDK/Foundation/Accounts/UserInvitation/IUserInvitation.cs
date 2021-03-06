// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="IUserInvitation.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using Mbed.Cloud.Foundation;

    /// <summary>
    /// UserInvitation
    /// </summary>
    public interface IUserInvitation
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
        /// email
        /// </summary>
        string Email
        {
            get;
            set;
        }
        [JsonConverter(typeof(CustomDateConverter), "yyyy-MM-dd'T'HH:mm:ss.fffZ")]
        /// <summary>
        /// expiration
        /// </summary>
        DateTime? Expiration
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
        /// login_profiles
        /// </summary>
        List<LoginProfile> LoginProfiles
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

        /// <summary>
        /// user_id
        /// </summary>
        string UserId
        {
            get;
        }
    }
}