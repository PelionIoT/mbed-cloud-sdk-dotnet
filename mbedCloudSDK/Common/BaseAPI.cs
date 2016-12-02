using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Common
{
    /// <summary>
    /// Base API.
    /// </summary>
	public class BaseAPI
    {
        protected Config config;
        
		/// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Common.BaseAPI"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
		public BaseAPI(Config config)
        {
            this.config = config;
        }
    }
}
