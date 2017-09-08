using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace mbedCloudSDK.Update.Model.FirmwareManifest
{
    public class ManifestContentsPayload
    {
        /// <summary>
        /// Gets or Sets Format
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ManifestContentsPayloadFormatEnum? PayloadFormat { get; set; }
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
        /// Map to ManifestContentsPayload object.
        /// </summary>
        /// <param name="item"></param>
        public static ManifestContentsPayload Map(update_service.Model.ManifestContentsPayload item)
        {
            var payload = new ManifestContentsPayload();
            payload.PayloadFormat = item.Format._Enum.HasValue ? (ManifestContentsPayloadFormatEnum)item.Format._Enum.Value : default(ManifestContentsPayloadFormatEnum);
            payload.Reference = ManifestContentsPayloadReference.Map(item.Reference);
            payload.StorageIdentifier = item.StorageIdentifier;
            return payload;
        }
    }
}