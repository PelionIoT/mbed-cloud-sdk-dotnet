using System;
using System.Collections.Generic;
using System.Text;

namespace mbedCloudSDK.Access.Model.Group
{
    /// <summary>
    /// Represents group from IAM.
    /// </summary>
    public class Group
    {

        /// <summary>
        /// The name of the group.
        /// </summary>
        /// <value>The name of the group.</value>
        public string Name { get; private set; }
        
        /// <summary>
        /// A timestamp of the latest group update, in milliseconds.
        /// </summary>
        /// <value>A timestamp of the latest group update, in milliseconds.</value>
        public long? LastUpdateTime { get; private set; }
        
        /// <summary>
        /// The number of API keys in this group.
        /// </summary>
        /// <value>The number of API keys in this group.</value>
        public int? ApiKeyCount { get; private set; }
        
        /// <summary>
        /// Creation UTC time RFC3339.
        /// </summary>
        /// <value>Creation UTC time RFC3339.</value>
        public string CreatedAt { get; private set; }
        
        /// <summary>
        /// A timestamp of the group creation in the storage, in milliseconds.
        /// </summary>
        /// <value>A timestamp of the group creation in the storage, in milliseconds.</value>
        public long? CreationTime { get; set; }
        
        /// <summary>
        /// API resource entity version.
        /// </summary>
        /// <value>API resource entity version.</value>
        public string Etag { get; set; }
        
        /// <summary>
        /// Gets or Sets CreationTimeMillis
        /// </summary>
        public long? CreationTimeMillis { get; set; }
        
        /// <summary>
        /// The UUID of the group.
        /// </summary>
        /// <value>The UUID of the group.</value>
        public string Id { get; private set; }
        
        /// <summary>
        /// The number of users in this group.
        /// </summary>
        /// <value>The number of users in this group.</value>
        public int? UserCount { get; private set; }

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
                    var property = this.GetType().GetProperty(item.Key);
                    if (property != null)
                    {
                        property.SetValue(this, item.Value, null);
                    }
                }
            }
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
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("  CreationTimeMillis: ").Append(CreationTimeMillis).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  UserCount: ").Append(UserCount).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Map to Group object
        /// </summary>
        /// <param name="groupInfo"></param>
        /// <returns></returns>
        public static Group Map(iam.Model.GroupSummary groupInfo)
        {
            var group = new Group();
            group.Name = groupInfo.Name;
            group.LastUpdateTime = groupInfo.LastUpdateTime;
            group.ApiKeyCount = groupInfo.ApiKeyCount;
            group.CreatedAt = groupInfo.CreatedAt;
            group.CreationTime = groupInfo.CreationTime;
            group.Etag = groupInfo.Etag;
            group.CreationTimeMillis = groupInfo.CreationTimeMillis;
            group.Id = groupInfo.Id;
            group.UserCount = groupInfo.UserCount;
            return group;
        }

    }
}
