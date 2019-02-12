// <copyright file="ConnectApi.WebHooks.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Mbed.Cloud.Foundation.Common;
    using MbedCloudSDK.Connect.Model.Webhook;
    using NotificationDeliveryMethod = MbedCloudSDK.Connect.Model.Enums;
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
                return Webhook.Map(NotificationsApi.GetWebhook());
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
        public async Task UpdateWebhookAsync(Webhook webhook)
        {
            if (DeliveryMethod == null)
            {
                DeliveryMethod = NotificationDeliveryMethod.DeliveryMethod.SERVER_INITIATED;
            }

            if (DeliveryMethod == NotificationDeliveryMethod.DeliveryMethod.CLIENT_INITIATED)
            {
                throw new CloudApiException(400, "cannot update webhook when delivery method is Client Initiated");
            }

            try
            {
                if (forceClear)
                {
                    await StopNotificationsAsync();
                }

                var currentWebhook = GetWebhook();

                if (currentWebhook.Url != webhook.Url)
                {
                    await NotificationsApi.RegisterWebhookAsync(Webhook.MapToApiWebook(webhook));
                }
            }
            catch (mds.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>Obsolote, do not use.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Please us async version AddResourceSubscriptionAsync")]
        public void UpdateWebhook(Webhook webhook)
        {
            AsyncHelper.RunSync(() => UpdateWebhookAsync(webhook));
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
                NotificationsApi.DeregisterWebhook();
                ResourceSubscribtions.Clear();
            }
            catch (mds.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }
    }
}