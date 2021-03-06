// <copyright file="ConnectApi.ResourceSubscriptions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Mbed.Cloud.Common;
    using MbedCloudSDK.Connect.Model.ConnectedDevice;
    using MbedCloudSDK.Connect.Model.Resource;
    using MbedCloudSDK.Exceptions;

    /// <summary>
    /// Connect Api
    /// </summary>
    public partial class ConnectApi
    {
        /// <summary>
        /// Subscribe to resource updates.
        /// </summary>
        /// <param name="deviceId">Id of device.</param>
        /// <param name="resourcePath">Resource path.</param>
        /// <returns>Async Consumer with String</returns>
        /// <example>
        /// <code>
        /// var consumer = await api.AddResourceSubscriptionAsync("015bb66a92a30000000000010010006d", "3200/0/5500");
        /// var counter = 0;
        /// while (true)
        /// {
        ///     var t = consumer.GetValue();
        ///     Console.WriteLine(t.Result);
        ///     counter++;
        ///     if (counter >= 2)
        ///     {
        ///     break;
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public async Task<Resource> AddResourceSubscriptionAsync(string deviceId, string resourcePath)
        {
            Log.Info($"adding subscription for {deviceId} at path {resourcePath}");
            try
            {
                await StartNotificationsAsync();
                var fixedPath = RemoveLeadingSlash(resourcePath);
                await SubscriptionsApi.AddResourceSubscriptionAsync(deviceId, fixedPath);
                var subscribePath = deviceId + resourcePath;
                var resource = new Resource(deviceId, this);
                ResourceSubscribtions.AddOrUpdate(subscribePath, resource, (key, _) => resource);

                return resource;
            }
            catch (mds.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>Obsolote, do not use.</summary>
        /// <param name="deviceId">todo: describe deviceId parameter on AddResourceSubscription</param>
        /// <param name="resourcePath">todo: describe resourcePath parameter on AddResourceSubscription</param>
        /// <returns>Resource</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Please us async version AddResourceSubscriptionAsync")]
        public Resource AddResourceSubscription(string deviceId, string resourcePath)
        {
            return AsyncHelper.RunSync<Resource>(() => AddResourceSubscriptionAsync(deviceId, resourcePath));
        }

        /// <summary>
        /// Gets the status of a resource's subscription. True if ok, false if not.
        /// </summary>
        /// <param name="deviceId">Id of device.</param>
        /// <param name="resourcePath">Resource path.</param>
        /// <returns>True if subscribed, false if not.</returns>
        /// <example>
        /// <code>
        /// var status = connectApi.GetResourceSubscription("015bb66a92a30000000000010010006d", "3200/0/5500");
        /// </code>
        /// </example>
        public bool GetResourceSubscription(string deviceId, string resourcePath)
        {
            try
            {
                var fixedPath = RemoveLeadingSlash(resourcePath);
                SubscriptionsApi.CheckResourceSubscription(deviceId, fixedPath);
                return true;
            }
            catch (mds.Client.ApiException)
            {
                return false;
            }
        }

        /// <summary>
        /// Unsubscribe from device and/or resource_path updates.
        /// </summary>
        /// <param name="deviceId">device to unsubscribe events from.</param>
        /// <param name="resourcePath">resource_path to unsubscribe events from.</param>
        /// <example>
        /// <code>
        /// try
        /// {
        ///     connectApi.DeleteResourceSubscription("015bb66a92a30000000000010010006d", "3200/0/5500");
        /// }
        /// catch (CloudApiException)
        /// {
        ///     throw;
        /// }
        /// </code>
        /// </example>
        /// <exception cref="CloudApiException">CloudApiException</exception>
        public void DeleteResourceSubscription(string deviceId, string resourcePath)
        {
            try
            {
                var fixedPath = RemoveLeadingSlash(resourcePath);
                SubscriptionsApi.DeleteResourceSubscription(deviceId, fixedPath);
                var subscribePath = deviceId + resourcePath;
                ResourceSubscribtions.TryRemove(subscribePath, out var removedItem);
            }
            catch (mds.Client.ApiException ex)
            {
                throw new CloudApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }
    }
}