using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mds.Api;
using mds.Client;
using mds.Model;

namespace mbed_cloud_sdk.Devices
{
    public class Connector: BaseAPI
    {
        public Connector(Config config) : base(config)
        {
            if (config.Host != string.Empty)
            {
                Configuration.Default.ApiClient = new ApiClient(config.Host);
            }
            Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
        }

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
