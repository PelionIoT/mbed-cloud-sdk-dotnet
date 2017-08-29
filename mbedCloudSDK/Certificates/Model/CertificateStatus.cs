using System.Runtime.Serialization;

namespace mbedCloudSDK.Certificates.Model
{
    public enum CertificateStatus
    {
        /// <summary>
        /// Enum Bootstrap for "active"
        /// </summary>
        [EnumMember(Value = "active")]
        Active,
        /// <summary>
        /// Enum Bootstrap for "inactive"
        /// </summary>
        [EnumMember(Value = "inactive")]
        Inactive
    }
}