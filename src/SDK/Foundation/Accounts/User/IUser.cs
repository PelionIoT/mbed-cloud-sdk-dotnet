// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="IUser.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using System.Collections.Generic;
    using Mbed.Cloud.Foundation;
    using System;
    using Mbed.Cloud.Foundation.Enums;

    /// <summary>
    /// User
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// account_id
        /// </summary>
        string AccountId
        {
            get;
        }

        /// <summary>
        /// active_sessions
        /// </summary>
        List<ActiveSession> ActiveSessions
        {
            get;
        }

        /// <summary>
        /// address
        /// </summary>
        string Address
        {
            get;
            set;
        }

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
        /// custom_fields
        /// </summary>
        Dictionary<string, string> CustomFields
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

        /// <summary>
        /// email_verified
        /// </summary>
        bool? EmailVerified
        {
            get;
        }

        /// <summary>
        /// full_name
        /// </summary>
        string FullName
        {
            get;
            set;
        }

        /// <summary>
        /// last_login_time
        /// </summary>
        long? LastLoginTime
        {
            get;
        }

        /// <summary>
        /// login_history
        /// </summary>
        List<LoginHistory> LoginHistory
        {
            get;
        }

        /// <summary>
        /// login_profiles
        /// </summary>
        List<LoginProfile> LoginProfiles
        {
            get;
            set;
        }

        /// <summary>
        /// marketing_accepted
        /// </summary>
        bool? MarketingAccepted
        {
            get;
            set;
        }

        /// <summary>
        /// password
        /// </summary>
        string Password
        {
            get;
            set;
        }

        /// <summary>
        /// password_changed_time
        /// </summary>
        long? PasswordChangedTime
        {
            get;
        }

        /// <summary>
        /// phone_number
        /// </summary>
        string PhoneNumber
        {
            get;
            set;
        }

        /// <summary>
        /// status
        /// </summary>
        UserStatus? Status
        {
            get;
            set;
        }

        /// <summary>
        /// terms_accepted
        /// </summary>
        bool? TermsAccepted
        {
            get;
            set;
        }

        /// <summary>
        /// totp_scratch_codes
        /// </summary>
        List<string> TotpScratchCodes
        {
            get;
        }

        /// <summary>
        /// two_factor_authentication
        /// </summary>
        bool? TwoFactorAuthentication
        {
            get;
            set;
        }

        /// <summary>
        /// updated_at
        /// </summary>
        DateTime? UpdatedAt
        {
            get;
        }

        /// <summary>
        /// username
        /// </summary>
        string Username
        {
            get;
            set;
        }
    }
}