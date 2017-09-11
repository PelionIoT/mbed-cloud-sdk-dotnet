namespace MbedCloudSDK.Update.Model.FirmwareManifest
{
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

        /// <summary>
        /// Map to ManifestContentsPayloadReference object.
        /// </summary>
        /// <param name="item"></param>
        public static ManifestContentsPayloadReference Map(update_service.Model.ManifestContentsPayloadReference item)
        {
            var payloadRef = new ManifestContentsPayloadReference();
            payloadRef.Hash = item.Hash;
            payloadRef.Uri = item.Uri;
            payloadRef.PayloadSize = item.Size;
            return payloadRef;
        }
    }
}