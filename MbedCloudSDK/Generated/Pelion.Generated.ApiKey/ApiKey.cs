// <copyright file="AccountManagementApi.Account.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
namespace Pelion.Generated.ApiKey
{
    using MbedCloudSDK.Common;
    using System;
    using System.Collections.Generic;
    using MbedCloudSDK.Common.Extensions;

    /// <summary>
    /// ApiKey
    /// </summary>
    public abstract class ApiKey : BaseModel
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
        /// The API key.
        /// </summary>
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// The display name for the API key.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// A list of group IDs this API key belongs to.
        /// </summary>
        public List<string> Groups
        {
            get;
            set;
        }

        /// <summary>
        /// The owner of this API key, who is the creator by default.
        /// </summary>
        public string Owner
        {
            get;
            set;
        }

        /// <summary>
        /// The status of the API key.
        /// </summary>
        public string Status
        {
            get;
            set;
        }

        /// <summary>
        /// The timestamp of the API key creation in the storage, in milliseconds.
        /// </summary>
        public int CreationTime
        {
            get;
            set;
        }

        /// <summary>
        /// The timestamp of the latest API key usage, in milliseconds.
        /// </summary>
        public int LastLoginTime
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