using System;
using System.Runtime.Serialization;
using mbedCloudSDK.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace mbedCloudSDK.Update.Model.FirmwareManifest
{
    public class FirmwareManifestContents
    {
        /// <summary>
        /// The device class&#39;s 128-bit RFC4122 GUID as a hexidecimal digit string
        /// </summary>
        /// <value>The device class&#39;s 128-bit RFC4122 GUID as a hexidecimal digit string</value>
        public string ClassId { get; set; }
        /// <summary>
        /// The vendor&#39;s 128-bit RFC4122 GUID as a hexidecimal digit string
        /// </summary>
        /// <value>The vendor&#39;s 128-bit RFC4122 GUID as a hexidecimal digit string</value>
        public string VendorId { get; set; }
        /// <summary>
        /// The manifest format version
        /// </summary>
        /// <value>The manifest format version</value>
        public int? ManifestVersion { get; set; }
        /// <summary>
        /// A short description of the update
        /// </summary>
        /// <value>A short description of the update</value>
        public string Description { get; set; }
        /// <summary>
        /// A 128-bit random field. This is provided by the manifest tool to ensure that the signing algorithm is safe from timing side-channel attacks.
        /// </summary>
        /// <value>A 128-bit random field. This is provided by the manifest tool to ensure that the signing algorithm is safe from timing side-channel attacks.</value>
        public string Nonce { get; set; }
        /// <summary>
        /// The time the manifest was created. The timestamp is stored as Unix time.
        /// </summary>
        /// <value>The time the manifest was created. The timestamp is stored as Unix time.</value>
        public int? Timestamp { get; set; }
        /// <summary>
        /// Gets or Sets EncryptionMode
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ManifestContentsEncryptionModeEnum EncryptionMode { get; set; }
        /// <summary>
        /// A flag that indicates whether the update described by the manifest should be applied as soon as possible
        /// </summary>
        /// <value>A flag that indicates whether the update described by the manifest should be applied as soon as possible</value>
        public bool? ApplyImmediately { get; set; }
        /// <summary>
        /// The device&#39;s 128-bit RFC4122 GUID as a hexidecimal digit string. Each device has a single, unique device ID.
        /// </summary>
        /// <value>The device&#39;s 128-bit RFC4122 GUID as a hexidecimal digit string. Each device has a single, unique device ID.</value>
        public string DeviceId { get; set; }
        /// <summary>
        /// Gets or Sets Format
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ManifestContentsPayloadFormatEnum PayloadFormat { get; set; }
        /// <summary>
        /// Gets or Sets Reference
        /// </summary>
        public ManifestContentsPayloadReference Reference { get; set; }
        /// <summary>
        /// An payload storage destination identifier. The identifier specifies where to place the firmware image on the device. For example, when an IoT device has multiple microcontrollers (MCUs), the identifier determines which MCU receives the image.
        /// </summary>
        /// <value>An payload storage destination identifier. The identifier specifies where to place the firmware image on the device. For example, when an IoT device has multiple microcontrollers (MCUs), the identifier determines which MCU receives the image.</value>
        public string StorageIdentifier { get; set; }
        /// <summary>
        /// Size of the payload in bytes
        /// </summary>
        /// <value>Size of the payload in bytes</value>
        public int? PayloadSize { get; set; }

        public static FirmwareManifestContents Map(update_service.Model.ManifestContents item)
        {
            var contents = new FirmwareManifestContents();
            contents.ClassId = item.ClassId;
            contents.VendorId = item.VendorId;
            contents.ManifestVersion = item.ManifestVersion;
            contents.Description = item.Description;
            contents.Nonce = item.Nonce;
            contents.Timestamp = item.Timestamp;
            contents.EncryptionMode = (ManifestContentsEncryptionModeEnum)item.EncryptionMode._Enum.Value;
            contents.ApplyImmediately = item.ApplyImmediately;
            contents.DeviceId = item.DeviceId;
            var manifestContentsPayload = ManifestContentsPayload.Map(item.Payload);
            contents.PayloadFormat = manifestContentsPayload.PayloadFormat;
            contents.Reference = manifestContentsPayload.Reference;
            contents.StorageIdentifier = manifestContentsPayload.StorageIdentifier;
            contents.PayloadSize = contents.Reference.PayloadSize;
            return contents;
        }
    }

    public enum ManifestContentsEncryptionModeEnum 
    {
        [EnumMember(Value="none-ecc-secp256r1-sha256")]
        noneEccSecp256r1Sha256 = 1,
        [EnumMember(Value = "aes-128-ctr-ecc-secp256r1-sha256")]
        aes128CtrEccSecp256r1Sha256 = 2,
        [EnumMember(Value = "none-none-sha256")]
        noneNoneSha256 = 3
    }

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

    public class ManifestContentsPayloadReference
    {
        /// <summary>
        /// Hex representation of the SHA-256 hash of the payload
        /// </summary>
        /// <value>Hex representation of the SHA-256 hash of the payload</value>
        public string Hash { get; set; }
        /// <summary>
        /// The payload URI
        /// </summary>
        /// <value>The payload URI</value>
        public string Uri { get; set; }
        /// <summary>
        /// Size of the payload in bytes
        /// </summary>
        /// <value>Size of the payload in bytes</value>
        public int? PayloadSize { get; set; }

        public static ManifestContentsPayloadReference Map(update_service.Model.ManifestContentsPayloadReference item)
        {
            var payloadRef = new ManifestContentsPayloadReference();
            payloadRef.Hash = item.Hash;
            payloadRef.Uri = item.Uri;
            payloadRef.PayloadSize = item.Size;
            return payloadRef;
        }
    }

    public class ManifestContentsPayload
    {
        /// <summary>
        /// Gets or Sets Format
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ManifestContentsPayloadFormatEnum PayloadFormat { get; set; }
        /// <summary>
        /// Gets or Sets Reference
        /// </summary>
        public ManifestContentsPayloadReference Reference { get; set; }
        /// <summary>
        /// An payload storage destination identifier. The identifier specifies where to place the firmware image on the device. For example, when an IoT device has multiple microcontrollers (MCUs), the identifier determines which MCU receives the image.
        /// </summary>
        /// <value>An payload storage destination identifier. The identifier specifies where to place the firmware image on the device. For example, when an IoT device has multiple microcontrollers (MCUs), the identifier determines which MCU receives the image.</value>
        public string StorageIdentifier { get; set; }

        public static ManifestContentsPayload Map(update_service.Model.ManifestContentsPayload item)
        {
            var payload = new ManifestContentsPayload();
            payload.PayloadFormat = (ManifestContentsPayloadFormatEnum)item.Format._Enum.Value;
            payload.Reference = ManifestContentsPayloadReference.Map(item.Reference);
            payload.StorageIdentifier = item.StorageIdentifier;
            return payload;
        }
    }
}