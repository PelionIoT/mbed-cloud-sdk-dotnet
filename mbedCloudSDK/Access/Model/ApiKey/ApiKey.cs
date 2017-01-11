using iam.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace mbedCloudSDK.Access.Model.ApiKey
{
    /// <summary>
    /// This object represents an API key in mbed Cloud.
    /// </summary>
    public class ApiKey
    {
        /// <summary>
        /// The status of the API key.
        /// </summary>
        /// <value>The status of the API key.</value>
        public ApiKeyStatus? Status { get; }

        /// <summary>
        /// The display name for the API key.
        /// </summary>
        /// <value>The display name for the API key.</value>
        public string Name { get; set; }

        /// <summary>
        /// The owner of this API key, who is the creator by default.
        /// </summary>
        /// <value>The owner of this API key, who is the creator by default.</value>
        public string Owner { get; set; }

        /// <summary>
        /// The API key.
        /// </summary>
        /// <value>The API key.</value>
        public string Apikey { get; }
        
        /// <summary>
        /// Creation UTC time RFC3339.
        /// </summary>
        /// <value>Creation UTC time RFC3339.</value>
        public string CreatedAt { get; }
        
        /// <summary>
        /// The timestamp of the API key creation in the storage, in milliseconds.
        /// </summary>
        /// <value>The timestamp of the API key creation in the storage, in milliseconds.</value>
        public long? CreationTime { get; }
        
        /// <summary>
        /// Gets or Sets CreationTimeMillis
        /// </summary>
        public long? CreationTimeMillis { get; }
        
        /// <summary>
        /// API resource entity version.
        /// </summary>
        /// <value>API resource entity version.</value>
        public string Etag { get; }
        
        /// <summary>
        /// A list of group IDs this API key belongs to.
        /// </summary>
        /// <value>A list of group IDs this API key belongs to.</value>
        public List<string> Groups { get; }
        
        /// <summary>
        /// API key secret, deprecated and always empty string.
        /// </summary>
        /// <value>API key secret, deprecated and always empty string.</value>
        public string SecretKey { get; }
        
        /// <summary>
        /// The UUID of the API key.
        /// </summary>
        /// <value>The UUID of the API key.</value>
        public string Id { get; }
        
        /// <summary>
        /// The timestamp of the latest API key usage, in milliseconds.
        /// </summary>
        /// <value>The timestamp of the latest API key usage, in milliseconds.</value>
        public long? LastLoginTime { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiKeyInfoResp" /> class.
        /// </summary>
        /// <param name="Status">The status of the API key..</param>
        /// <param name="Apikey">The API key. (required).</param>
        /// <param name="Name">The display name for the API key. (required).</param>
        /// <param name="CreatedAt">Creation UTC time RFC3339..</param>
        /// <param name="CreationTime">The timestamp of the API key creation in the storage, in milliseconds..</param>
        /// <param name="CreationTimeMillis">CreationTimeMillis.</param>
        /// <param name="Etag">API resource entity version. (required).</param>
        /// <param name="Groups">A list of group IDs this API key belongs to..</param>
        /// <param name="Owner">The owner of this API key, who is the creator by default..</param>
        /// <param name="SecretKey">API key secret, deprecated and always empty string..</param>
        /// <param name="Id">The UUID of the API key. (required).</param>
        /// <param name="LastLoginTime">The timestamp of the latest API key usage, in milliseconds..</param>
        public ApiKey(ApiKeyStatus? Status = null, string Apikey = null, string Name = null, string CreatedAt = null, long? CreationTime = null, long? CreationTimeMillis = null, string Etag = null, List<string> Groups = null, string Owner = null, string SecretKey = null, string Id = null, long? LastLoginTime = null)
        {
            this.Owner = Owner;
            this.Name = Name;
            this.Apikey = Apikey;
            this.Etag = Etag;
            this.Id = Id;
            this.Status = Status;
            this.CreatedAt = CreatedAt;
            this.CreationTime = CreationTime;
            this.CreationTimeMillis = CreationTimeMillis;
            this.Groups = Groups;
            this.Owner = Owner;
            this.SecretKey = SecretKey;
            this.LastLoginTime = LastLoginTime;
        }
        
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:mbedCloudSDK.Access.Model.ApiKey.ApiKey"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:mbedCloudSDK.Access.Model.ApiKey.ApiKey"/>.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiKeyInfoResp {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Apikey: ").Append(Apikey).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  CreationTime: ").Append(CreationTime).Append("\n");
            sb.Append("  CreationTimeMillis: ").Append(CreationTimeMillis).Append("\n");
            sb.Append("  Etag: ").Append(Etag).Append("\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
            sb.Append("  Owner: ").Append(Owner).Append("\n");
            sb.Append("  SecretKey: ").Append(SecretKey).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LastLoginTime: ").Append(LastLoginTime).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        public static ApiKey Convert(ApiKeyInfoResp apiKeyInfo)
        {
            ApiKeyStatus apiKeyStatus = (ApiKeyStatus)Enum.Parse(typeof(ApiKeyStatus), apiKeyInfo.Status.ToString());
            return new ApiKey(apiKeyStatus, apiKeyInfo.Apikey, apiKeyInfo.Name, apiKeyInfo.CreatedAt,
                apiKeyInfo.CreationTime, apiKeyInfo.CreationTimeMillis, apiKeyInfo.Etag, apiKeyInfo.Groups,
                apiKeyInfo.Owner, apiKeyInfo.SecretKey, apiKeyInfo.Id, apiKeyInfo.LastLoginTime);
        }
    }
}
