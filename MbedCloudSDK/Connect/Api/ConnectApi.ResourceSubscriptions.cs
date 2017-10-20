// <copyright file="ConnectApi.ResourceSubscriptions.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using MbedCloudSDK.Connect.Model.ConnectedDevice;
    using MbedCloudSDK.Connect.Model.Resource;

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
        public AsyncConsumer<string> AddResourceSubscription(string deviceId, string resourcePath)
        {
            try
            {
                var fixedPath = FixedPath(resourcePath);
                subscriptionsApi.V2SubscriptionsDeviceIdResourcePathPut(deviceId, fixedPath);
                var subscribePath = deviceId + resourcePath;
                var resource = new Resource(deviceId)
                {
                    Queue = new AsyncProducerConsumerCollection<string>()
                };
                if (!ResourceSubscribtions.ContainsKey(subscribePath))
                {
                    ResourceSubscribtions.Add(subscribePath, resource);
                }

                return new AsyncConsumer<string>(subscribePath, resource.Queue);
            }
            catch (mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Get an update from the resource subscription
        /// </summary>
        /// <param name="deviceId">Id of device.</param>
        /// <param name="resourcePath">Resource path.</param>
        public void GetResourceSubscription(string deviceId, string resourcePath)
        {
            try
            {
                var fixedPath = FixedPath(resourcePath);
                subscriptionsApi.V2SubscriptionsDeviceIdResourcePathGet(deviceId, fixedPath);
            }
            catch (mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Unsubscribe from device and/or resource_path updates.
        /// </summary>
        /// <param name="deviceId">device to unsubscribe events from. If not provided, all registered devices will be unsubscribed</param>
        /// <param name="resourcePath">resource_path to unsubscribe events from. If not provided, all resource paths will be unsubscribed.</param>
        public void DeleteResourceSubscription(string deviceId = null, string resourcePath = null)
        {
            try
            {
                if (deviceId == null)
                {
                    foreach (var resource in ResourceSubscribtions)
                    {
                        subscriptionsApi.V2SubscriptionsDeviceIdResourcePathDelete(resource.Key, resource.Value.Path);
                        ResourceSubscribtions.Clear();
                    }
                }
                else
                {
                    subscriptionsApi.V2SubscriptionsDeviceIdResourcePathDelete(deviceId, resourcePath);
                    var subscribePath = deviceId + resourcePath;
                    ResourceSubscribtions.Remove(subscribePath);
                }
            }
            catch (mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }
    }
}