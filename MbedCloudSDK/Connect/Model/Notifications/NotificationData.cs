// <copyright file="NotificationData.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.Notifications
{
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using Newtonsoft.Json;

    /// <summary>
    /// NotificationData
    /// </summary>
    public class NotificationData
    {
        /// <summary>
        /// Gets or sets the Path
        /// </summary>
        /// <returns>Path</returns>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the MaxAge
        /// </summary>
        /// <returns>MaxAge</returns>
        [JsonProperty("max-age")]
        public string MaxAge { get; set; }

        /// <summary>
        /// Gets or sets the Payload
        /// </summary>
        /// <returns>Payload</returns>
        [JsonProperty("payload")]
        public string Payload { get; set; }

        /// <summary>
        /// Gets or sets the DeviceId
        /// </summary>
        /// <returns>DeviceId</returns>
        [JsonProperty("ep")]
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the ContentType
        /// </summary>
        /// <returns>ContentType</returns>
        [JsonProperty("ct")]
        public string ContentType { get; set; }

        /// <summary>
        /// Map Notification Data
        /// </summary>
        /// <param name="data">Mds NotificationData</param>
        /// <returns>The NotificationData</returns>
        public static NotificationData Map(mds.Model.NotificationData data)
        {
            var notificationData = new NotificationData
            {
                Path = data.Path,
                MaxAge = data.MaxAge,
                Payload = data.Payload,
                DeviceId = data.Ep,
                ContentType = data.Ct,
            };

            return notificationData;
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}