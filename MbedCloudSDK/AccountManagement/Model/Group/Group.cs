// <copyright file="Group.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Model.Group
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MbedCloudSDK.Common;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents group from IAM.
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Group" /> class.
        /// </summary>
        /// <param name="options">Dictionary containing properties.</param>
        public Group(IDictionary<string, object> options = null)
        {
            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    var property = GetType().GetProperty(item.Key);
                    if (property != null)
                    {
                        property.SetValue(this, item.Value, null);
                    }
                }
            }
        }

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
        /// Gets a timestamp of the latest group update, in milliseconds.
        /// </summary>
        [JsonProperty]
        public long? LastUpdateTime { get; private set; }

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
        /// Gets or sets a timestamp of the group creation in the storage, in milliseconds.
        /// </summary>
        [JsonProperty]
        public long? CreationTime { get; set; }

        /// <summary>
        /// Gets the UUID of the group.
        /// </summary>
        [JsonProperty]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the number of users in this group.
        /// </summary>
        [JsonProperty]
        public int? UserCount { get; private set; }

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
                LastUpdateTime = groupInfo.LastUpdateTime,
                ApiKeyCount = groupInfo.ApikeyCount,
                CreatedAt = groupInfo.CreatedAt.ToNullableUniversalTime(),
                CreationTime = groupInfo.CreationTime,
                AccountId = groupInfo.AccountId,
                Id = groupInfo.Id,
                UserCount = groupInfo.UserCount
            };
            return group;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Group {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  LastUpdateTime: ").Append(LastUpdateTime).Append("\n");
            sb.Append("  ApiKeyCount: ").Append(ApiKeyCount).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  CreationTime: ").Append(CreationTime).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  UserCount: ").Append(UserCount).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
