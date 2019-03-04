// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="IActiveSession.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using System;

    /// <summary>
    /// ActiveSession
    /// </summary>
    public interface IActiveSession
    {
        /// <summary>
        /// account_id
        /// </summary>
        string AccountId
        {
            get;
        }

        /// <summary>
        /// ip_address
        /// </summary>
        string IpAddress
        {
            get;
        }

        /// <summary>
        /// login_time
        /// </summary>
        DateTime? LoginTime
        {
            get;
        }

        /// <summary>
        /// reference_token
        /// </summary>
        string ReferenceToken
        {
            get;
        }

        /// <summary>
        /// user_agent
        /// </summary>
        string UserAgent
        {
            get;
        }
    }
}