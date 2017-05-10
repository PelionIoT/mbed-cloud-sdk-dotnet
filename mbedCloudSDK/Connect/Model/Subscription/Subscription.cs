using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Connect.Model.Subscription
{
    class Subscription
    {
        /// <summary>
        /// The Device ID
        /// </summary>
        /// <value>The Device ID</value>
        public string EndpointName { get; set; }
        
        /// <summary>
        /// Gets or Sets EndpointType
        /// </summary>
        public string EndpointType { get; set; }
        
        /// <summary>
        /// Gets or Sets ResourcePath
        /// </summary>
        public List<String> ResourcePaths { get; set; }

        public static Subscription Map(mds.Model.Presubscription subscriptionData)
        {
            Subscription substriction = new Subscription();
            substriction.EndpointName = subscriptionData.EndpointName;
            substriction.EndpointType = subscriptionData.EndpointType;
            substriction.ResourcePaths = subscriptionData.ResourcePath.Select((s) => { return s.ToString(); }).ToList();
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
            sb.Append("  EndpointName: ").Append(EndpointName).Append("\n");
            sb.Append("  EndpointType: ").Append(EndpointType).Append("\n");
            sb.Append("  ResourcePaths: ").Append(ResourcePaths).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
