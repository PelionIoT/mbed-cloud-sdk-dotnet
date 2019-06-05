// <auto-generated>
//
// Generated by
//                     _                        _
//   /\/\   __ _ _ __ | |__   __ _ ___ ___  ___| |_
//  /    \ / _` | '_ \| '_ \ / _` / __/ __|/ _ \ __|
// / /\/\ \ (_| | | | | | | | (_| \__ \__ \  __/ |_
// \/    \/\__,_|_| |_|_| |_|\__,_|___/___/\___|\__| v 2.0.0
//
// <copyright file="UserInvitationUserInvitationListOptions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
// </auto-generated>

namespace Mbed.Cloud.Foundation
{
    using Mbed.Cloud.Common;
    using Mbed.Cloud.Common.Filters;
    using System.Collections.Generic;

    /// <summary>
    /// UserInvitationUserInvitationListOptions
    /// </summary>
    public class UserInvitationUserInvitationListOptions : QueryOptions, IUserInvitationUserInvitationListOptions
    {
        public UserInvitationUserInvitationListOptions()
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

        public UserInvitationUserInvitationListOptions LoginProfilesEqualTo(List<LoginProfile> value)
        {
            this.Filter.AddFilterItem("login_profiles", new FilterItem(value, FilterOperator.Equals));
            return this;
        }
    }
}