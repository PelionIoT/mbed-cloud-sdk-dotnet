// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="IAccountAccountListOptions.cs" company="Arm">
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
    /// AccountAccountListOptions
    /// </summary>
    public interface IAccountAccountListOptions : IQueryOptions
    {
        /// <summary>
        /// 
        /// </summary>
        string Format
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        string Properties
        {
            get;
            set;
        }

        /// <summary>
        /// Filter object
        /// </summary>
        Filter Filter
        {
            get;
            set;
        }

        AccountAccountListOptions StatusEqualTo(AccountStatus value);
        AccountAccountListOptions StatusIn(params AccountStatus[] value);
        AccountAccountListOptions StatusNotIn(params AccountStatus[] value);
        AccountAccountListOptions TierEqualTo(string value);
        AccountAccountListOptions ParentEqualTo(string value);
        AccountAccountListOptions EndMarketEqualTo(string value);
        AccountAccountListOptions CountryLike(string value);
    }
}