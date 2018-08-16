// <copyright file="AccountManagementApi.Account.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
namespace MbedCloudSDK.TestTag.User
{
    using MbedCloudSDK.Common;
    using System;
    using System.Collections.Generic;
    using MbedCloudSDK.Common.Extensions;

    /// <summary>
    /// User
    /// </summary>
    public partial class User : BaseModel
    {
        /// <summary>
        /// Creation UTC time RFC3339.
        /// </summary>
        public DateTime CreatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// Last update UTC time RFC3339.
        /// </summary>
        public DateTime UpdatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// A username containing alphanumerical letters and -,._@+= characters.
        /// </summary>
        public string Username
        {
            get;
            set;
        }

        /// <summary>
        /// The password when creating a new user. It will be generated when not present in the request.
        /// </summary>
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// The full name of the user.
        /// </summary>
        public string FullName
        {
            get;
            set;
        }

        /// <summary>
        /// Address.
        /// </summary>
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Phone number.
        /// </summary>
        public string PhoneNumber
        {
            get;
            set;
        }

        /// <summary>
        /// A list of IDs of the groups this user belongs to.
        /// </summary>
        public List<string> Groups
        {
            get;
            set;
        }

        /// <summary>
        /// A flag indicating that the General Terms and Conditions has been accepted.
        /// </summary>
        public bool IsGtcAccepted
        {
            get;
            set;
        }

        /// <summary>
        /// A flag indicating that receiving marketing information has been accepted.
        /// </summary>
        public bool IsMarketingAccepted
        {
            get;
            set;
        }

        /// <summary>
        /// A flag indicating whether the user's email address has been verified or not.
        /// </summary>
        public bool EmailVerified
        {
            get;
            set;
        }

        /// <summary>
        /// A timestamp of the user creation in the storage, in milliseconds.
        /// </summary>
        public int CreationTime
        {
            get;
            set;
        }

        /// <summary>
        /// A timestamp of the latest login of the user, in milliseconds.
        /// </summary>
        public int LastLoginTime
        {
            get;
            set;
        }

        /// <summary>
        /// A timestamp of the latest change of the user password, in milliseconds.
        /// </summary>
        public int PasswordChangedTime
        {
            get;
            set;
        }

        /// <summary>
        /// The UUID of the account.
        /// </summary>
        public string AccountId
        {
            get;
            set;
        }

        /// <summary>
        /// Timestamps, succeedings, IP addresses and user agent information of the last five logins of the user, with timestamps in RFC3339 format.
        /// </summary>
        public List<string> LoginHistory
        {
            get;
            set;
        }

        /// <summary>
        /// Get human readable string of this object
        /// </summary>
        /// <returns>Serialized string of object</returns>
        public override string ToString() => this.DebugDump();
    }
}