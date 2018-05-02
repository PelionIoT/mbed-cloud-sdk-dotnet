// <copyright file="ResourceValuesFilter.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api.Subscribe.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Connect.Model.Notifications;
    using MbedCloudSDK.Connect.Model.Subscription;

    /// <summary>
    /// ResourceValueFilter
    /// </summary>
    /// <seealso cref="System.IEquatable{Model.Notifications.NotificationData}" />
    /// <seealso cref="System.IEquatable{Models.ResourceValuesFilter}" />
    public class ResourceValuesFilter : IEquatable<NotificationData>, IEquatable<ResourceValuesFilter>
    {
        /// <summary>
        /// Gets or sets the Device ID
        /// </summary>
        /// <value>The Device ID</value>
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets ResourcePath
        /// </summary>
        public List<string> ResourcePaths { get; set; } = new List<string>();

        /// <summary>
        /// Maps the specified presub.
        /// </summary>
        /// <param name="presub">The presub.</param>
        /// <returns>Presubscription</returns>
        public static Presubscription Map(ResourceValuesFilter presub)
        {
            return new Presubscription
            {
                DeviceId = presub.DeviceId,
                ResourcePaths = presub.ResourcePaths,
            };
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.
        /// </returns>
        public bool Equals(NotificationData other)
        {
            return DeviceId.MatchWithWildcard(other.DeviceId) && (ResourcePaths.Any() ? ResourcePaths.Any(r => r.MatchWithWildcard(other.Path)) : true);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.
        /// </returns>
        public bool Equals(ResourceValuesFilter other)
        {
            return DeviceId == other.DeviceId && ResourcePaths.SequenceEqual(other.ResourcePaths);
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}