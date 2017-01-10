using System;
using System.Collections.Generic;
using System.Text;

namespace mbedCloudSDK.Access.Model.ApiKey
{
    /// <summary>
    /// This object represents an API key in mbed Cloud.
    /// </summary>
    public class ApiKeyResp: ApiKey
    {
        /// <summary>
        /// The status of the API key.
        /// </summary>
        /// <value>The status of the API key.</value>
        public StatusEnum? Status { get; set; }
        
        /// <summary>
        /// The API key.
        /// </summary>
        /// <value>The API key.</value>
        public string Apikey { get; set; }
        
        /// <summary>
        /// Creation UTC time RFC3339.
        /// </summary>
        /// <value>Creation UTC time RFC3339.</value>
        public string CreatedAt { get; set; }
        
        /// <summary>
        /// The timestamp of the API key creation in the storage, in milliseconds.
        /// </summary>
        /// <value>The timestamp of the API key creation in the storage, in milliseconds.</value>
        public long? CreationTime { get; set; }
        
        /// <summary>
        /// Gets or Sets CreationTimeMillis
        /// </summary>
        public long? CreationTimeMillis { get; set; }
        
        /// <summary>
        /// API resource entity version.
        /// </summary>
        /// <value>API resource entity version.</value>
        public string Etag { get; set; }
        
        /// <summary>
        /// A list of group IDs this API key belongs to.
        /// </summary>
        /// <value>A list of group IDs this API key belongs to.</value>
        public List<string> Groups { get; set; }
        
        /// <summary>
        /// API key secret, deprecated and always empty string.
        /// </summary>
        /// <value>API key secret, deprecated and always empty string.</value>
        public string SecretKey { get; set; }
        
        /// <summary>
        /// The UUID of the API key.
        /// </summary>
        /// <value>The UUID of the API key.</value>
        public string Id { get; set; }
        
        /// <summary>
        /// The timestamp of the latest API key usage, in milliseconds.
        /// </summary>
        /// <value>The timestamp of the latest API key usage, in milliseconds.</value>
        public long? LastLoginTime { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Access.Model.ApiKey.ApiKeyResp"/> class.
        /// </summary>
        /// <param name="Status">Status.</param>
        /// <param name="Apikey">Apikey.</param>
        /// <param name="Name">Name.</param>
        /// <param name="CreatedAt">Created at.</param>
        /// <param name="CreationTime">Creation time.</param>
        /// <param name="CreationTimeMillis">Creation time millis.</param>
        /// <param name="Etag">Etag.</param>
        /// <param name="Groups">Groups.</param>
        /// <param name="Owner">Owner.</param>
        /// <param name="SecretKey">Secret key.</param>
        /// <param name="Id">Identifier.</param>
        /// <param name="LastLoginTime">Last login time.</param>
        public ApiKeyResp(StatusEnum? Status = null, string Apikey = null, string Name = null, string CreatedAt = null, long? CreationTime = null, long? CreationTimeMillis = null, string Etag = null, List<string> Groups = null, string Owner = null, string SecretKey = null, string Id = null, long? LastLoginTime = null): base(Owner, Name)
        {
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
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:mbedCloudSDK.Access.Model.ApiKey.ApiKeyResp"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:mbedCloudSDK.Access.Model.ApiKey.ApiKeyResp"/>.</returns>
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
    }
}
