using mbedCloudSDK.Connect.Model.ConnectedDevice;
using mbedCloudSDK.Connect.Model.Resource;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
//using mds.Model;

namespace mbedCloudSDK.Connect.Api
{
    public partial class ConnectApi
    {
        /// <summary>
        /// Subscribe to resource updates.
        /// </summary>
        /// <param name="deviceId">Id of device.</param>
        /// <param name="resourcePath">Resource path.</param>
        public Dictionary<string, Resource> AddResourceSubscription(string deviceId, string resourcePath)
        {
            try
            {
                var fixedPath = FixedPath(resourcePath);
                //resourceSubscribtions.Add(deviceId, resourcePath);
                subscriptionsApi.V2SubscriptionsDeviceIdResourcePathPut(deviceId, resourcePath);
                return resourceSubscribtions;
            }
            catch(mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Update pre-subscription data. Pre-subscription data will be removed for empty list.
        /// </summary>
        /// <param name="presubscriptions">Id of device.</param>
        public void UpdatePresubscriptions(mds.Model.Presubscription[] presubscriptions)
        {
            var presubscriptionArray = new mds.Model.PresubscriptionArray();
            foreach(var presubscription in presubscriptions)
            {
                var updatedPresubscription = new mds.Model.Presubscription(presubscription.EndpointName, presubscription.EndpointType, presubscription.ResourcePath);
                presubscriptionArray.Add(updatedPresubscription);
            }
            try
            {
                subscriptionsApi.V2SubscriptionsPut(presubscriptionArray);
            }
            catch (mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Get a list of pre-subscription data.
        /// </summary>
        public mds.Model.PresubscriptionArray ListPresubscriptions()
        {
            try
            {
                return subscriptionsApi.V2SubscriptionsGet();
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
                if(deviceId == null)
                {
                    foreach(var resource in resourceSubscribtions)
                    {
                        subscriptionsApi.V2SubscriptionsDeviceIdResourcePathDelete(resource.Key, resource.Value.Path);
                    }
                }
                else
                {
                    subscriptionsApi.V2SubscriptionsDeviceIdResourcePathDelete(deviceId, resourcePath);
                }
            }
            catch (mds.Client.ApiException ex)
            {
                throw new mds.Client.ApiException(ex.ErrorCode, ex.Message, ex.ErrorContent);
            }
        }

        /// <summary>
        /// Subscribe the specified endpointName and resourcePath.
        /// </summary>
        /// <param name="endpointName">Endpoint name.</param>
        /// <param name="resource">Resource to subscribe.</param>
        public AsyncConsumer<String> Subscribe(String endpointName, Resource resource)
        {
            var fixedPath = FixedPath(resource.Path);
            subscriptionsApi.V2SubscriptionsDeviceIdResourcePathPut(endpointName, fixedPath);
            var subscribePath = endpointName + resource.Path;
            if (!ConnectApi.resourceSubscribtions.ContainsKey(subscribePath))
            {
                ConnectApi.resourceSubscribtions.Add(subscribePath, resource);
            }
            return new AsyncConsumer<String>(resource.Queue);
        }

        /// <summary>
        /// Presubscribe to the resource.
        /// </summary>
        /// <param name="endpointName">Endpoint name.</param>
        /// <param name="resourcePath">Resource path.</param>
        /// <param name="endpointType">Endpoint type.</param>
        public void Presubscribe(String endpointName, String resourcePath, String endpointType = "")
        {
            var presubscription = new mds.Model.Presubscription(endpointName, endpointType);
            var presubscriptionArray = new mds.Model.PresubscriptionArray();
            presubscriptionArray.Add(presubscription);
            subscriptionsApi.V2SubscriptionsPut(presubscriptionArray);
        }

        /// <summary>
        /// Presubscribe to the resource asynchronously.
        /// </summary>
        /// <param name="endpointName">Endpoint name.</param>
        /// <param name="resourcePath">Resource path.</param>
        /// <param name="endpointType">Endpoint type.</param>
        public async Task PresubscribeAsync(String endpointName, String resourcePath, String endpointType = "")
        {
            var presubscription = new mds.Model.Presubscription(endpointName, endpointType);
            var presubscriptionArray = new mds.Model.PresubscriptionArray();
            presubscriptionArray.Add(presubscription);
            await subscriptionsApi.V2SubscriptionsPutAsync(presubscriptionArray);
        }

        

        /// <summary>
        /// Unsubscribe resource.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        /// <param name="resource">Resource to unsubscribe.</param>
        public void Unsubscribe(String deviceName, Resource resource)
        {
            var fixedPath = FixedPath(resource.Path);
            var subscribePath = deviceName + resource.Path;
            subscriptionsApi.V2SubscriptionsDeviceIdResourcePathDelete(deviceName, fixedPath);
            if (resourceSubscribtions.ContainsKey(subscribePath))
            {
                resourceSubscribtions.Remove(subscribePath);
            }
        }

        /// <summary>
        /// Unsubscribe resource asynchronously.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        /// <param name="resource">Resource to unsubscribe.</param>
        public async Task UnsubscribeAsync(String deviceName, Resource resource)
        {
            var fixedPath = FixedPath(resource.Path);
            var subscribePath = deviceName + resource.Path;
            await subscriptionsApi.V2SubscriptionsDeviceIdResourcePathDeleteAsync(deviceName, fixedPath);
            if (resourceSubscribtions.ContainsKey(subscribePath))
            {
                resourceSubscribtions.Remove(subscribePath);
            }
        }
    }
}
