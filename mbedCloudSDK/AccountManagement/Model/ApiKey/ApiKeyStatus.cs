using System;
using System.Runtime.Serialization;

namespace mbedCloudSDK.AccountManagement.Model.ApiKey
{
    /// <summary>
    /// The status of the API key.
    /// </summary>
    public enum ApiKeyStatus
    {
        /// <summary>
        /// Enum ACTIVE for "ACTIVE"
        /// </summary>
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,
         
        /// <summary>
        /// Enum INACTIVE for "INACTIVE"
        /// </summary>
        [EnumMember(Value = "INACTIVE")]
        INACTIVE
    }
}
