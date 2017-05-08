using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Connect.Api
{
    public partial class ConnectApi
    {
        /// <summary>
        /// Registers the webhook.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="headers">Headers.</param>
        public void RegisterWebhook(string url, object headers = null)
        {
            var api = new mds.Api.NotificationsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            mds.Model.Webhook webhook = new mds.Model.Webhook(url, headers);
            api.V2NotificationCallbackPut(webhook);
        }

        /// <summary>
        /// Deregisters all webhooks. If no webhook is registered, an exception (404) will be raised.
        /// </summary>
        public void DeregisterWebhooks()
        {
            var api = new mds.Api.DefaultApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            api.V2NotificationCallbackDelete();
        }
    }
}
