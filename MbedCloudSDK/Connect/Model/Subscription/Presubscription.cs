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
    public class Presubscription : IEquatable<Presubscription>
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
                DeviceId = subscriptionData.EndpointName,
                DeviceType = subscriptionData.EndpointType,
                ResourcePaths = subscriptionData.ResourcePath.Select((s) => { return s.ToString(); }).ToList()
            };
            return substriction;
        }

        public bool Equals(Presubscription other)
        {
            return DeviceId == other.DeviceId && DeviceType == other.DeviceType && ResourcePaths.SequenceEqual(other.ResourcePaths);
        }

        public override int GetHashCode()
        {
            var hashCode = 1311603952;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DeviceId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DeviceType);
            ResourcePaths.ToList().ForEach(r => hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(r));
            return hashCode;
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
    }

    public class PresubscriptionComparer : IEqualityComparer<Presubscription>
    {
        public bool Equals(Presubscription x, Presubscription y)
        {
            return x.DeviceId == y.DeviceId && x.ResourcePaths.SequenceEqual(y.ResourcePaths);
        }

        public int GetHashCode(Presubscription obj)
        {
            Console.WriteLine(obj.GetHashCode());
            return obj.GetHashCode();
        }
    }
}