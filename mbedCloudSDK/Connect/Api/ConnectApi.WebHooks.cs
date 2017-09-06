using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mds.Model;

namespace mbedCloudSDK.Connect.Api
{
    public partial class ConnectApi
    {
        /// <summary>
        /// Get the current callback URL if it exists.
        /// </summary>
        public Webhook GetWebhook()
        {
            try
            {
                return defaultApi.V2NotificationCallbackGet();
            }
            catch(mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Register new webhook for incoming subscriptions.
        /// </summary>
        /// <param name="url">The URL with listening webhook.</param>
        /// <param name="headers">K/V dict with additional headers to send with request</param>
        public void UpdateWebhook(string url, Dictionary<string, string> headers = null)
        {
            try
            {
                var webhook = new Webhook(url, headers);
                notificationsApi.V2NotificationCallbackPut(webhook);
            }
            catch (mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Delete/remove registered webhook.
        /// </summary>
        public void DeleteWebhook()
        {
            try
            {
                defaultApi.V2NotificationCallbackDelete();
                resourceSubscribtions.Clear();
            }
            catch (mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }
    }
}