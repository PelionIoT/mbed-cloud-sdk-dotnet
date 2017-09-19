// <copyright file="Presubscription.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MbedCloudSDK.Connect.Model.Subscription
{
    public class Presubscription
    {
        /// <summary>
        /// Gets or sets the Device ID
        /// </summary>
        /// <value>The Device ID</value>
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets EndpointType
        /// </summary>
        public string EndpointType { get; set; }

        /// <summary>
        /// Gets or sets gets or Sets ResourcePath
        /// </summary>
        public List<string> ResourcePaths { get; set; }

        /// <summary>
        /// Map presubscription object
        /// </summary>
        public static Presubscription Map(mds.Model.Presubscription subscriptionData)
        {
            Presubscription substriction = new Presubscription
            {
                DeviceId = subscriptionData.EndpointName,
                EndpointType = subscriptionData.EndpointType,
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
            sb.Append("  EndpointType: ").Append(EndpointType).Append("\n");
            sb.Append("  ResourcePaths: ").Append(ResourcePaths).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}