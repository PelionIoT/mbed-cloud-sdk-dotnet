using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using developer_certificate.Api;
using developer_certificate.Client;
using developer_certificate.Model;
using mbedCloudSDK.Common;

namespace mbedCloudSDK.Development
{
    public class Certificate: BaseAPI
    {
        private string auth;
        public Certificate(Config config): base(config)
        {
            if (config.Host != string.Empty)
            {
                Configuration.Default.ApiClient = new ApiClient(config.Host);
            }
            Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            this.auth = string.Format("{0} {1}", config.AuthorizationPrefix, config.ApiKey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificateId"></param>
        public DeveloperCertificate getCertificate(string certificateId)
        {
            var api = new DefaultApi();
            try
            {
                return api.V3DeveloperCertificateGet(certificateId);
            }
            catch(ApiException e) {
                Console.Error.WriteLine(e);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificateId"></param>
        /// <returns></returns>
        public bool RevokeCertificate(string certificateId)
        {
            var api = new DefaultApi();
            bool success = false;
            try
            {
                api.V3DeveloperCertificateDelete(certificateId);
                success = true;
            }
            catch(ApiException e)
            {
                Console.Error.WriteLine(e);
            }
            return success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public DeveloperCertificate CreateCertificate(string publicKey)
        {
            var api = new DefaultApi();
            var body = new Body();
            body.PubKey = publicKey;
            try
            {
                return api.V3DeveloperCertificatePost(this.auth, body);
            }
            catch(ApiException e)
            {
                Console.Error.WriteLine(e);
            }
            return null;
        }
    }
}
