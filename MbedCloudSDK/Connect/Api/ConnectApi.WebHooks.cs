using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MbedCloudSDK.Connect.Model.Webhook;
//using mds.Model;

namespace MbedCloudSDK.Connect.Api
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
                return Webhook.Map(defaultApi.V2NotificationCallbackGet());
            }
            catch(mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Register new webhook for incoming subscriptions.
        /// </summary>
        /// <param name="webhook">The webhook object</param>
        public void UpdateWebhook(Webhook webhook)
        {
            try
            {
                notificationsApi.V2NotificationCallbackPut(Webhook.MapToApiWebook(webhook));
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