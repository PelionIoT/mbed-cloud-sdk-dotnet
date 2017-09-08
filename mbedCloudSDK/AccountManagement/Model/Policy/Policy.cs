using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbedCloudSDK.AccountManagement.Model.Policy
{
    public class Policy
    {
        /// <summary>
        /// Create new instance of api key class.
        /// </summary>
        /// <param name="options">Dictionary containing properties.</param>
        public Policy(IDictionary<string, object> options = null)
        {
            if (options != null)
            {
                foreach (KeyValuePair<string, object> item in options)
                {
                    var property = this.GetType().GetProperty(item.Key);
                    if (property != null)
                    {
                        property.SetValue(this, item.Value, null);
                    }
                }
            }
        }

        /// <summary>
        /// Map to Policy object.
        /// </summary>
        /// <param name="policy"></param>
        /// <returns></returns>
        public static Policy Map(iam.Model.FeaturePolicy policy)
        {
            Policy p = new Policy();
            p.Action = policy.Action;
            p.Resource = policy.Resource;
            p.Feature = policy.Feature;
            p.Allow = policy.Allow;
            return p;
        }

        /// <summary>
        /// Comma separated list of actions, empty string represents all actions.
        /// </summary>
        /// <value>Comma separated list of actions, empty string represents all actions.</value>
        public string Action { get; set; }
        
        /// <summary>
        /// Resource that is protected by this policy.
        /// </summary>
        /// <value>Resource that is protected by this policy.</value>
        public string Resource { get; set; }
        
        /// <summary>
        /// Feature name corresponding to this policy.
        /// </summary>
        /// <value>Feature name corresponding to this policy.</value>
        public string Feature { get; set; }
        
        /// <summary>
        /// True or false controlling whether an action is allowed or not.
        /// </summary>
        /// <value>True or false controlling whether an action is allowed or not.</value>
        public bool? Allow { get; set; }
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
