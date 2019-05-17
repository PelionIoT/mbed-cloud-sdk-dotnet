// <copyright file="Presubscription.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.Subscription
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Mbed.Cloud.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using MbedCloudSDK.Connect.Model.Notifications;

    /// <summary>
    /// Presubscription
    /// </summary>
    public class Presubscription : Entity, IEquatable<Presubscription>
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
        public IEnumerable<string> ResourcePaths { get; set; } = new List<string>();

        /// <summary>
        /// Map presubscription object
        /// </summary>
        /// <param name="subscriptionData">Subscription data</param>
        /// <returns>Presubscription</returns>
        public static Presubscription Map(mds.Model.Presubscription subscriptionData)
        {
            var substriction = new Presubscription
            {
                DeviceId = subscriptionData?.EndpointName,
                DeviceType = subscriptionData?.EndpointType,
                ResourcePaths = subscriptionData?.ResourcePath?.ToList() ?? new List<string>()
            };
            return substriction;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Presubscription other)
        {
            return DeviceId == other.DeviceId && DeviceType == other.DeviceType && ResourcePaths.SequenceEqual(other.ResourcePaths);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            var hashCode = 1311603952;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(DeviceId);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(DeviceType);
            ResourcePaths.ToList().ForEach(r => hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(r));
            return hashCode;
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}