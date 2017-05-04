using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Certificates.Model
{
    /// <summary>
    /// Type of Trusted Certificate
    /// </summary>
    public enum CertificateType
    {
        /// <summary>
        /// Enum Bootstrap for "bootstrap"
        /// </summary>
        [EnumMember(Value = "developer")]
        Developer,

        /// <summary>
        /// Enum Lwm2m for "lwm2m"
        /// </summary>
        [EnumMember(Value = "lwm2m")]
        Lwm2m,

        /// <summary>
        /// Enum Bootstrap for "bootstrap"
        /// </summary>
        [EnumMember(Value = "bootstrap")]
        Bootstrap
    }
}
