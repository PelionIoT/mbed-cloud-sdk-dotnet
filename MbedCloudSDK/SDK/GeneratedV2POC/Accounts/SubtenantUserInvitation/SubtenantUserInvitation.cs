// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 1.0.0
//
// <copyright file="SubtenantUserInvitation.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace MbedCloud.SDK.Entities
{
    using MbedCloud.SDK.Common;
    using System;
    using MbedCloud.SDK.Entities;
    using System.Collections.Generic;

    /// <summary>
    /// SubtenantUserInvitation
    /// </summary>
    public class SubtenantUserInvitation : Entity
    {
        /// <summary>
        /// account_id
        /// </summary>
        public string AccountId
        {
            get;
            set;
        }

        /// <summary>
        /// created_at
        /// </summary>
        public DateTime? CreatedAt
        {
            get;
            internal set;
        }

        /// <summary>
        /// email
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// expiration
        /// </summary>
        public DateTime? Expiration
        {
            get;
            internal set;
        }

        /// <summary>
        /// login_profiles
        /// </summary>
        public List<LoginProfile> LoginProfiles
        {
            get;
            set;
        }

        /// <summary>
        /// updated_at
        /// </summary>
        public DateTime? UpdatedAt
        {
            get;
            internal set;
        }

        /// <summary>
        /// user_id
        /// </summary>
        public string UserId
        {
            get;
            internal set;
        }
    }
}