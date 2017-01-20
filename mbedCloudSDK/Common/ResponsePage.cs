using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Common
{
    public class ResponsePage<T>
    {
        /// <summary>
        /// Whether there are more results to display
        /// </summary>
        /// <value>Whether there are more results to display</value>
        public bool? HasMore { get; set; }
        
        /// <summary>
        /// Total number of records
        /// </summary>
        /// <value>Total number of records</value>
        public int? TotalCount { get; set; }
        
        /// <summary>
        /// Entity id for fetch after it
        /// </summary>
        /// <value>Entity id for fetch after it</value>
        public string After { get; set; }
        
        /// <summary>
        /// The number of results to return
        /// </summary>
        /// <value>The number of results to return</value>
        public int? Limit { get; set; }
        
        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        public List<T> Data { get; set; }
        
        /// <summary>
        /// Order of returned records
        /// </summary>
        /// <value>Order of returned records</value>
        public string Order { get; set; }

        public ResponsePage()
        {
            Data = new List<T>();
        }
    }
}
