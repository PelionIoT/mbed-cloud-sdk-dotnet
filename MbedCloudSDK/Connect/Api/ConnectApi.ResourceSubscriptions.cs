using MbedCloudSDK.Connect.Model.ConnectedDevice;
using MbedCloudSDK.Connect.Model.Resource;

namespace MbedCloudSDK.Connect.Api
{
    public partial class ConnectApi
    {
        /// <summary>
        /// Subscribe to resource updates.
        /// </summary>
        /// <param name="deviceId">Id of device.</param>
        /// <param name="resourcePath">Resource path.</param>
        public AsyncConsumer<string> AddResourceSubscription(string deviceId, string resourcePath)
        {
            try
            {
                var fixedPath = FixedPath(resourcePath);
                subscriptionsApi.V2SubscriptionsDeviceIdResourcePathPut(deviceId, fixedPath);
                var subscribePath = deviceId + resourcePath;
                var resource = new Resource(deviceId);
                resource.Queue = new AsyncProducerConsumerCollection<string>();
                if (!ConnectApi.resourceSubscribtions.ContainsKey(subscribePath))
                {
                    ConnectApi.resourceSubscribtions.Add(subscribePath, resource);
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
                    foreach (var resource in resourceSubscribtions)
                    {
                        subscriptionsApi.V2SubscriptionsDeviceIdResourcePathDelete(resource.Key, resource.Value.Path);
                        resourceSubscribtions.Clear();
                    }
                }
                else
                {
                    subscriptionsApi.V2SubscriptionsDeviceIdResourcePathDelete(deviceId, resourcePath);
                    var subscribePath = deviceId + resourcePath;
                    resourceSubscribtions.Remove(subscribePath);
                }
            }
            catch (mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }
    }
}