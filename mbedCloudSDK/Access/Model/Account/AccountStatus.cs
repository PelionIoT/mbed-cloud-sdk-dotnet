using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Access.Model.Account
{
    /// <summary>
    /// The status of the account.
    /// </summary>
    /// <value>The status of the account.</value>
    public enum AccountStatus
    {
        /// <summary>
        /// Enum ENROLLING for "ENROLLING"
        /// </summary>
        [EnumMember(Value = "ENROLLING")]
        ENROLLING,

        /// <summary>
        /// Enum ACTIVE for "ACTIVE"
        /// </summary>
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,

        /// <summary>
        /// Enum SUSPENDED for "SUSPENDED"
        /// </summary>
        [EnumMember(Value = "SUSPENDED")]
        SUSPENDED,

        /// <summary>
        /// Enum DISABLED for "DISABLED"
        /// </summary>
        [EnumMember(Value = "DISABLED")]
        DISABLED
    }
}
