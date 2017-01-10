using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace mbedCloudSDK.Access.Model.ApiKey
{
    /// <summary>
    /// This object represents an API key in requests towards mbed Cloud.
    /// </summary>
    public class ApiKey
    {
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
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Access.Model.ApiKey.ApiKey"/> class.
        /// </summary>
        /// <param name="Owner">The owner of this API key, who is the creator by default..</param>
        /// <param name="Name">The display name for the API key. (required).</param>
        public ApiKey(string Owner = null, string Name = null)
        {
            // to ensure "Name" is required (not null)
            if (Name == null)
            {
                throw new InvalidDataException("Name is a required property for ApiKeyInfoReq and cannot be null");
            }
            else
            {
                this.Name = Name;
            }
            this.Owner = Owner;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiKeyInfoReq {\n");
            sb.Append("  Owner: ").Append(Owner).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
        
        
    }
}
