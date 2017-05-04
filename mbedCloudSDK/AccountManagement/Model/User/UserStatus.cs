using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.AccountManagement.Model.User
{
    /// <summary>
    /// The status of the user. INVITED means that the user has not accepted the invitation request. RESET means that the password must be changed immediately.
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// Enum INVITED for "INVITED"
        /// </summary>
        [EnumMember(Value = "INVITED")]
        INVITED,

        /// <summary>
        /// Enum ACTIVE for "ACTIVE"
        /// </summary>
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,

        /// <summary>
        /// Enum RESET for "RESET"
        /// </summary>
        [EnumMember(Value = "RESET")]
        RESET,

        /// <summary>
        /// Enum INACTIVE for "INACTIVE"
        /// </summary>
        [EnumMember(Value = "INACTIVE")]
        INACTIVE
    }
}
