// <copyright file="ConnectApi.WebHooks.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System;
    using MbedCloudSDK.Connect.Model.Webhook;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// Connect Api
    /// </summary>
    public partial class ConnectApi
    {
        /// <summary>
        /// Get the current callback URL if it exists.
        /// </summary>
        /// <returns>Webhook</returns>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var webhook = connectApi.GetWebhook();
        ///     return webhook;
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public Webhook GetWebhook()
        {
            try
            {
                return Webhook.Map(defaultApi.V2NotificationCallbackGet());
            }
            catch (mds.Client.ApiException ex)
            {
                if (ex.ErrorCode == 404)
                {
                    // no webhook
                    return null;
                }

                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Register new webhook for incoming subscriptions.
        /// </summary>
        /// <param name="webhook"><see cref="Webhook"/></param>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     var webhook = new Webhook
        ///     {
        ///         Url = "www.exampleurl.com",
        ///     };
        ///     connectApi.UpdateWebhook(webhook);
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public void UpdateWebhook(Webhook webhook)
        {
            try
            {
                if (Config.ForceClear)
                {
                    StopNotifications();
                }

                notificationsApi.V2NotificationCallbackPut(Webhook.MapToApiWebook(webhook));
            }
            catch (mds.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Delete/remove registered webhook.
        /// </summary>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     connectApi.DeleteWebhook();
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public void DeleteWebhook()
        {
            try
            {
                defaultApi.V2NotificationCallbackDelete();
                ResourceSubscribtions.Clear();
            }
            catch (mds.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }
    }
}