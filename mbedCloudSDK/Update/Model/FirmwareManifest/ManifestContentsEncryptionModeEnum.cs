using System.Runtime.Serialization;

namespace mbedCloudSDK.Update.Model.FirmwareManifest
{
    public enum ManifestContentsEncryptionModeEnum
    {
        /// <summary>
        /// Enum noneEccSecp256r1Sha256 for "none-ecc-secp256r1-sha256"
        /// </summary>
        [EnumMember(Value = "none-ecc-secp256r1-sha256")]
        noneEccSecp256r1Sha256 = 1,
        /// <summary>
        /// Enum aes128CtrEccSecp256r1Sha256 for "aes-128-ctr-ecc-secp256r1-sha256"
        /// </summary>
        [EnumMember(Value = "aes-128-ctr-ecc-secp256r1-sha256")]
        aes128CtrEccSecp256r1Sha256 = 2,
        /// <summary>
        /// Enum noneNoneSha256 for "none-none-sha256"
        /// </summary>
        [EnumMember(Value = "none-none-sha256")]
        noneNoneSha256 = 3
    }
}