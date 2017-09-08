using System.Runtime.Serialization;

namespace mbedCloudSDK.Update.Model.FirmwareManifest
{
    public enum ManifestContentsPayloadFormatEnum
    {
        [EnumMember(Value = "raw-binary")]
        rawBinary = 1,
        [EnumMember(Value = "cbor")]
        cbor = 2,
        [EnumMember(Value = "hex-location-length-data")]
        hexLocationLengthData = 3,
        [EnumMember(Value = "elf")]
        elf = 4
    }
}