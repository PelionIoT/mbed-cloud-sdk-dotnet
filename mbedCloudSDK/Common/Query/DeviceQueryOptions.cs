using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Common.Query
{
    public class DeviceQueryOptions: QueryOptions
    {
        /// <summary>
        /// Get Query String.
        /// </summary>
        public override string QueryString
        {
            get
            {
                string attributes = Attributes != null ?  string.Join("&", Attributes.Select(q => String.Format("{0}={1}", q.Key, q.Value))) : string.Empty;
                if (CustomAttributes != null)
                {
                    return Uri.UnescapeDataString(string.Join("&", attributes, CustomAttributes));
                }
                return attributes;
            }
        }

        /// <summary>
        /// Get or Set custom attributes.
        /// </summary>
        public Dictionary<string, QueryAttribute> CustomAttributes { get; set; }

        public DeviceQueryOptions(int? limit = null, string order = null, string after = null, string include = null, 
            Dictionary<string, QueryAttribute> attributes = null, Dictionary<string, QueryAttribute> customAttributes = null) : 
            base(limit, order, after, include, attributes)
        {
            this.CustomAttributes = customAttributes;
        }
    }
}
