// <copyright file="Policy.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Model.Policy
{
    using System.Collections.Generic;
    using System.Text;
    using MbedCloudSDK.Common;
    using Newtonsoft.Json;

    /// <summary>
    /// Policy
    /// </summary>
    public class Policy
    {
        /// <summary>
        /// Gets comma separated list of actions, empty string represents all actions.
        /// </summary>
        /// <value>Comma separated list of actions, empty string represents all actions.</value>
        [JsonProperty]
        public string Action { get; private set; }

        /// <summary>
        /// Gets resource that is protected by this policy.
        /// </summary>
        /// <value>Resource that is protected by this policy.</value>
        [JsonProperty]
        public string Resource { get; private set; }

        /// <summary>
        /// Gets feature name corresponding to this policy.
        /// </summary>
        /// <value>Feature name corresponding to this policy.</value>
        [JsonProperty]
        public string Feature { get; private set; }

        /// <summary>
        /// Gets true or false controlling whether an action is allowed or not.
        /// </summary>
        /// <value>True or false controlling whether an action is allowed or not.</value>
        [JsonProperty]
        public bool? Allow { get; private set; }

        /// <summary>
        /// Map to Policy object.
        /// </summary>
        /// <param name="policy">Iam Policy object</param>
        /// <returns>Policy object</returns>
        public static Policy Map(iam.Model.FeaturePolicy policy)
        {
            var mappedPolicy = new Policy
            {
                Action = policy.Action,
                Resource = policy.Resource,
                Feature = policy.Feature,
                Allow = policy.Allow
            };
            return mappedPolicy;
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}
