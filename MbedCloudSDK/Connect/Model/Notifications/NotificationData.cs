// <copyright file="NotificationData.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>
namespace MbedCloudSDK.Connect.Model.Notifications
{
    /// <summary>
    /// NotificationData
    /// </summary>
    public class NotificationData
    {
        /// <summary>
        /// Gets or sets the Path
        /// </summary>
        /// <returns>Path</returns>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the MaxAge
        /// </summary>
        /// <returns>MaxAge</returns>
        public string MaxAge { get; set; }

        /// <summary>
        /// Gets or sets the Payload
        /// </summary>
        /// <returns>Payload</returns>
        public string Payload { get; set; }

        /// <summary>
        /// Gets or sets the DeviceId
        /// </summary>
        /// <returns>DeviceId</returns>
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the ContentType
        /// </summary>
        /// <returns>ContentType</returns>
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
}
}