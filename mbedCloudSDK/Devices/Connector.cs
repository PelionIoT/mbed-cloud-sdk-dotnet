using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mbedCloudSDK.Common;
using mds.Api;
using mds.Client;
using mds.Model;

namespace mbedCloudSDK.Devices
{
    /// <summary>
    /// Connector.
    /// </summary>
	public class Connector: BaseAPI
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.Devices.Connector"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
		public Connector(Config config) : base(config)
        {
            if (config.Host != string.Empty)
            {
                Configuration.Default.ApiClient = new ApiClient(config.Host);
            }
            Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
        }

		/// <summary>
		/// Lists the endpoints.
		/// </summary>
		/// <returns>The endpoints.</returns>
        public List<Endpoint> listEndpoints()
        {
            var api = new EndpointsApi();
            try
            {
                return api.V2EndpointsGet();
            }
            catch(ApiException e)
            {
                Console.Error.WriteLine(e);
            }
            return null;
        }

    }
}
