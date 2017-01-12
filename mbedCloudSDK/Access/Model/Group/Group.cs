using System;
using System.Text;

namespace mbedCloudSDK.Access.Model.Group
{
    public class Group
    {

        /// <summary>
        /// The name of the group.
        /// </summary>
        /// <value>The name of the group.</value>
        public string Name { get; }
        
        /// <summary>
        /// A timestamp of the latest group update, in milliseconds.
        /// </summary>
        /// <value>A timestamp of the latest group update, in milliseconds.</value>
        public long? LastUpdateTime { get; }
        
        /// <summary>
        /// The number of API keys in this group.
        /// </summary>
        /// <value>The number of API keys in this group.</value>
        public int? ApiKeyCount { get; }
        
        /// <summary>
        /// Creation UTC time RFC3339.
        /// </summary>
        /// <value>Creation UTC time RFC3339.</value>
        public string CreatedAt { get; }
        
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
        public string Id { get; }
        
        /// <summary>
        /// The number of users in this group.
        /// </summary>
        /// <value>The number of users in this group.</value>
        public int? UserCount { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupSummary" /> class.
        /// </summary>
        /// <param name="Name">The name of the group. (required).</param>
        /// <param name="LastUpdateTime">A timestamp of the latest group update, in milliseconds..</param>
        /// <param name="ApiKeyCount">The number of API keys in this group. (required).</param>
        /// <param name="CreatedAt">Creation UTC time RFC3339..</param>
        /// <param name="CreationTime">A timestamp of the group creation in the storage, in milliseconds..</param>
        /// <param name="Etag">API resource entity version. (required).</param>
        /// <param name="CreationTimeMillis">CreationTimeMillis.</param>
        /// <param name="Id">The UUID of the group. (required).</param>
        /// <param name="UserCount">The number of users in this group. (required).</param>
        public Group(string Name = null, long? LastUpdateTime = null, int? ApiKeyCount = null, string CreatedAt = null, long? CreationTime = null, string Etag = null, long? CreationTimeMillis = null, string Id = null, int? UserCount = null)
        {
            this.Name = Name;
            this.ApiKeyCount = ApiKeyCount;
            this.Etag = Etag;
            this.Id = Id;
            this.UserCount = UserCount;
            this.LastUpdateTime = LastUpdateTime;
            this.CreatedAt = CreatedAt;
            this.CreationTime = CreationTime;
            this.CreationTimeMillis = CreationTimeMillis;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GroupSummary {\n");
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

        public static Group Convert(iam.Model.GroupSummary groupInfo)
        {
            return new Group(groupInfo.Name, groupInfo.LastUpdateTime, groupInfo.ApiKeyCount, groupInfo.CreatedAt, groupInfo.CreationTime,
                groupInfo.Etag, groupInfo.CreationTimeMillis, groupInfo.Id, groupInfo.UserCount);
        }

    }
}
