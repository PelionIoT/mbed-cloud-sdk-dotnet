// <copyright file="Group.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Model.Group
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Mbed.Cloud.Foundation.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents group from IAM.
    /// </summary>
    public class Group : Entity
    {
        /// <summary>
        /// Gets the ID of the account.
        /// </summary>
        [JsonProperty]
        public string AccountId { get; private set; }

        /// <summary>
        /// Gets the name of the group.
        /// </summary>
        [JsonProperty]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the number of API keys in this group.
        /// </summary>
        [JsonProperty]
        public int? ApiKeyCount { get; private set; }

        /// <summary>
        /// Gets creation UTC time RFC3339.
        /// </summary>
        [JsonProperty]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// Gets the number of users in this group.
        /// </summary>
        [JsonProperty]
        public int? UserCount { get; private set; }

        /// <summary>
        /// Gets the last updated UTC time
        /// </summary>
        [JsonProperty]
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Map to Group object
        /// </summary>
        /// <param name="groupInfo">Identity and Access Management (IAM) group summary</param>
        /// <returns>Group</returns>
        public static Group Map(iam.Model.GroupSummary groupInfo)
        {
            var group = new Group
            {
                Name = groupInfo.Name,
                ApiKeyCount = groupInfo.ApikeyCount,
                CreatedAt = groupInfo.CreatedAt.ToNullableUniversalTime(),
                AccountId = groupInfo.AccountId,
                Id = groupInfo.Id,
                UserCount = groupInfo.UserCount,
                UpdatedAt = groupInfo.UpdatedAt
            };
            return group;
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}
