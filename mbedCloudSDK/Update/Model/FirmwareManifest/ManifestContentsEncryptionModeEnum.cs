using System.Runtime.Serialization;

namespace mbedCloudSDK.Update.Model.FirmwareManifest
{
    public enum ManifestContentsEncryptionModeEnum
    {
        [EnumMember(Value = "none-ecc-secp256r1-sha256")]
        noneEccSecp256r1Sha256 = 1,
        [EnumMember(Value = "aes-128-ctr-ecc-secp256r1-sha256")]
        aes128CtrEccSecp256r1Sha256 = 2,
        [EnumMember(Value = "none-none-sha256")]
        noneNoneSha256 = 3
    }
}