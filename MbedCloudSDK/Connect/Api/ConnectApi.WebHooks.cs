// <copyright file="ConnectApi.WebHooks.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using MbedCloudSDK.Connect.Model.Webhook;

namespace MbedCloudSDK.Connect.Api
{
    /// <summary>
    /// Connect Api
    /// </summary>
    public partial class ConnectApi
    {
        /// <summary>
        /// Get the current callback URL if it exists.
        /// </summary>
        /// <returns>Webhook</returns>
        public Webhook GetWebhook()
        {
            try
            {
                return Webhook.Map(defaultApi.V2NotificationCallbackGet());
            }
            catch (mds.Client.ApiException ex)
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
                ResourceSubscribtions.Clear();
            }
            catch (mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }
    }
}