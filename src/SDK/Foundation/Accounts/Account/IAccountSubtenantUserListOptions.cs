// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="IAccountSubtenantUserListOptions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using Mbed.Cloud.Common.Filters;
    using Mbed.Cloud.Foundation.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// AccountSubtenantUserListOptions
    /// </summary>
    public interface IAccountSubtenantUserListOptions : IQueryOptions
    {
        /// <summary>
        /// Filter object
        /// </summary>
        Filter Filter
        {
            get;
            set;
        }

        AccountSubtenantUserListOptions EmailEqualTo(string value);
        AccountSubtenantUserListOptions StatusEqualTo(AccountStatus value);
        AccountSubtenantUserListOptions StatusIn(params AccountStatus[] value);
        AccountSubtenantUserListOptions StatusNotIn(params AccountStatus[] value);
        AccountSubtenantUserListOptions LoginProfilesEqualTo(string value);
    }
}