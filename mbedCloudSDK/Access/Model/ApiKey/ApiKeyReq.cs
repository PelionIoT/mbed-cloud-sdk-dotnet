using System;
using System.Collections.Generic;
using System.Text;

namespace mbedCloudSDK.Access.Model.ApiKey
{
    /// <summary>
    /// This object represents an API key in requests towards mbed Cloud.
    /// </summary>
    public class ApiKeyReq: ApiKey
    {
        /// <summary>
        /// A list of group IDs this API key belongs to.
        /// </summary>
        /// <value>A list of group IDs this API key belongs to.</value>
        public List<string> Groups { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Access.Model.ApiKey.ApiKeyReq"/> class.
        /// </summary>
        /// <param name="Owner">The owner of this API key, who is the creator by default..</param>
        /// <param name="Name">The display name for the API key. (required).</param>
        /// <param name="Groups">A list of group IDs this API key belongs to..</param>
        public ApiKeyReq(string Owner = null, string Name = null, List<string> Groups = null): base(Owner, Name)
        {
            this.Groups = Groups;
        }
        
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:mbedCloudSDK.Access.Model.ApiKey.ApiKeyReq"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:mbedCloudSDK.Access.Model.ApiKey.ApiKeyReq"/>.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiKeyInfoReq {\n");
            sb.Append("  Owner: ").Append(Owner).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
