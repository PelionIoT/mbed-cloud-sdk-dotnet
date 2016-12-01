using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Common
{
    public class Config
    {
        private string host;
        private string apiKey;
        private string authorizationPrefix = "Bearer";

        public Config(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        public string ApiKey
        {
            get { return apiKey; }
        }

        public string AuthorizationPrefix
        {
            get { return authorizationPrefix; }
            set { authorizationPrefix = value; }
        }

    }
}
