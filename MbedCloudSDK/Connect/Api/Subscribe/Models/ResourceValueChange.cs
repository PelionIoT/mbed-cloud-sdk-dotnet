// <copyright file="ResourceValueChange.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Models
{
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Connect.Model.Notifications;

    /// <summary>
    /// ResourceValueChange
    /// </summary>
    public class ResourceValueChange
    {
        /// <summary>
        /// Gets the device identifier.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        public string DeviceId { get; private set; }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path { get; private set; }

        /// <summary>
        /// Gets the payload.
        /// </summary>
        /// <value>
        /// The payload.
        /// </value>
        public string Payload { get; private set; }

        /// <summary>
        /// Maps the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>ResourceValueChange</returns>
        public static ResourceValueChange Map(NotificationData data)
        {
            return new ResourceValueChange
            {
                DeviceId = data.DeviceId,
                Path = data.Path,
                Payload = data.Payload,
            };
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}