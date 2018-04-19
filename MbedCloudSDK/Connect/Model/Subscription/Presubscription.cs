// <copyright file="Presubscription.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.Subscription
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Connect.Model.Notifications;

    /// <summary>
    /// Presubscription
    /// </summary>
    public class Presubscription : IEquatable<NotificationData>
    {
        /// <summary>
        /// Gets or sets the Device ID
        /// </summary>
        /// <value>The Device ID</value>
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets EndpointType
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets ResourcePath
        /// </summary>
        public List<string> ResourcePaths { get; set; } = new List<string>();

        /// <summary>
        /// Map presubscription object
        /// </summary>
        /// <param name="subscriptionData">Subscription data</param>
        /// <returns>Presubscription</returns>
        public static Presubscription Map(mds.Model.Presubscription subscriptionData)
        {
            var substriction = new Presubscription
            {
                DeviceId = subscriptionData.EndpointName,
                DeviceType = subscriptionData.EndpointType,
                ResourcePaths = subscriptionData.ResourcePath.Select((s) => { return s.ToString(); }).ToList()
            };
            return substriction;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Presubscription {\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
            sb.Append("  DeviceType: ").Append(DeviceType).Append("\n");
            sb.Append("  ResourcePaths: ").Append(string.Join(", ", ResourcePaths?.Select(r => { return Convert.ToString(r); }))).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        public bool Equals(NotificationData other)
        {
            return (DeviceId.MatchWithWildcard(other.DeviceId)) && (ResourcePaths.Any() ? ResourcePaths.Any(r => r.MatchWithWildcard(other.Path)) : true);
        }
    }
}