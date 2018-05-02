using System;
using System.Collections.Generic;
using System.Linq;
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Extensions;
using MbedCloudSDK.Connect.Model.Notifications;
using MbedCloudSDK.Connect.Model.Subscription;

namespace MbedCloudSDK.Connect.Api.Subscribe.Models
{
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

        public bool Equals(NotificationData other)
        {
            return (DeviceId.MatchWithWildcard(other.DeviceId)) && (ResourcePaths.Any() ? ResourcePaths.Any(r => r.MatchWithWildcard(other.Path)) : true);
        }

        public static Presubscription Map(ResourceValuesFilter presub)
        {
            return new Presubscription
            {
                DeviceId = presub.DeviceId,
                ResourcePaths = presub.ResourcePaths,
            };
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();

        public bool Equals(ResourceValuesFilter other)
        {
            return this.DeviceId == other.DeviceId && this.ResourcePaths.SequenceEqual(other.ResourcePaths);
        }
    }
}