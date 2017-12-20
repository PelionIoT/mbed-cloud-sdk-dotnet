// <copyright file="Policy.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Model.Policy
{
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// Policy
    /// </summary>
    public class Policy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Policy"/> class.
        /// Create new instance of API key class.
        /// </summary>
        /// <param name="options">Dictionary containing properties.</param>
        public Policy(IDictionary<string, object> options = null)
        {
            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    var property = GetType().GetProperty(item.Key);
                    if (property != null)
                    {
                        property.SetValue(this, item.Value, null);
                    }
                }
            }
        }

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
            var p = new Policy
            {
                Action = policy.Action,
                Resource = policy.Resource,
                Feature = policy.Feature,
                Allow = policy.Allow
            };
            return p;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FeaturePolicy {\n");
            sb.Append("  Action: ").Append(Action).Append("\n");
            sb.Append("  Resource: ").Append(Resource).Append("\n");
            sb.Append("  Feature: ").Append(Feature).Append("\n");
            sb.Append("  Allow: ").Append(Allow).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
