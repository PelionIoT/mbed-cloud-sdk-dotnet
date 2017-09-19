// <copyright file="Policy.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.AccountManagement.Model.Policy
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Policy
    /// </summary>
    public class Policy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Policy"/> class.
        /// Create new instance of api key class.
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
        /// Gets or sets comma separated list of actions, empty string represents all actions.
        /// </summary>
        /// <value>Comma separated list of actions, empty string represents all actions.</value>
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets resource that is protected by this policy.
        /// </summary>
        /// <value>Resource that is protected by this policy.</value>
        public string Resource { get; set; }

        /// <summary>
        /// Gets or sets feature name corresponding to this policy.
        /// </summary>
        /// <value>Feature name corresponding to this policy.</value>
        public string Feature { get; set; }

        /// <summary>
        /// Gets or sets true or false controlling whether an action is allowed or not.
        /// </summary>
        /// <value>True or false controlling whether an action is allowed or not.</value>
        public bool? Allow { get; set; }

        /// <summary>
        /// Map to Policy object.
        /// </summary>
        /// <param name="policy">Iam Policy object</param>
        /// <returns>Policy object</returns>
        public static Policy Map(iam.Model.FeaturePolicy policy)
        {
            Policy p = new Policy
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
