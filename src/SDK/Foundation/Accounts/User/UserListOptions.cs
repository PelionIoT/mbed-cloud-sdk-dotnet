// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="UserListOptions.cs" company="Arm">
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
    /// UserListOptions
    /// </summary>
    public class UserListOptions : QueryOptions, IUserListOptions
    {
        public UserListOptions()
        {
            Filter = new Filter();
        }

        /// <summary>
        /// Filter object
        /// </summary>
        public Filter Filter
        {
            get;
            set;
        }

        public UserListOptions EmailEqualTo(string value)
        {
            this.Filter.AddFilterItem("email", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public UserListOptions StatusEqualTo(UserStatus value)
        {
            this.Filter.AddFilterItem("status", new FilterItem(value, FilterOperator.Equals));
            return this;
        }

        public UserListOptions StatusIn(params UserStatus[] value)
        {
            this.Filter.AddFilterItem("status", new FilterItem(value, FilterOperator.In));
            return this;
        }

        public UserListOptions StatusNotIn(params UserStatus[] value)
        {
            this.Filter.AddFilterItem("status", new FilterItem(value, FilterOperator.NotIn));
            return this;
        }

        public UserListOptions LoginProfileEqualTo(string value)
        {
            this.Filter.AddFilterItem("login_profile", new FilterItem(value, FilterOperator.Equals));
            return this;
        }
    }
}