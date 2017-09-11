using System.Runtime.Serialization;

namespace MbedCloudSDK.Update.Model.FirmwareManifest
{
    public enum ManifestContentsPayloadFormatEnum
    {
        /// <summary>
        /// Enum rawBinary for "raw-binary"
        /// </summary>
        [EnumMember(Value = "raw-binary")]
        rawBinary = 1,
        /// <summary>
        /// Enum cbor for "cbor"
        /// </summary>
        [EnumMember(Value = "cbor")]
        cbor = 2,
        /// <summary>
        /// Enum hexLocationLengthData for "hex-location-length-data"
        /// </summary>
        [EnumMember(Value = "hex-location-length-data")]
        hexLocationLengthData = 3,
        /// <summary>
        /// Enum elf for "elf"
        /// </summary>
        [EnumMember(Value = "elf")]
        elf = 4
    }
}