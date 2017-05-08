using mbedCloudSDK.Connect.Model.ConnectedDevice;
using mbedCloudSDK.Connect.Model.Resource;
using System;
using System.Threading.Tasks;

namespace mbedCloudSDK.Connect.Api
{
    public partial class ConnectApi
    {
        /// <summary>
        /// Subscribe the specified endpointName and resourcePath.
        /// </summary>
        /// <param name="endpointName">Endpoint name.</param>
        /// <param name="resource">Resource to subscribe.</param>
        public AsyncConsumer<String> Subscribe(String endpointName, Resource resource)
        {
            string fixedPath = FixedPath(resource.Uri);
            var api = new mds.Api.SubscriptionsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            api.V2SubscriptionsDeviceIdResourcePathPut(endpointName, fixedPath);
            string subscribePath = endpointName + resource.Uri;
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
            var api = new mds.Api.SubscriptionsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            mds.Model.Presubscription presubscription = new mds.Model.Presubscription(endpointName, endpointType);
            mds.Model.PresubscriptionArray presubscriptionArray = new mds.Model.PresubscriptionArray();
            presubscriptionArray.Add(presubscription);
            api.V2SubscriptionsPut(presubscriptionArray);
        }

        /// <summary>
        /// Presubscribe to the resource asynchronously.
        /// </summary>
        /// <param name="endpointName">Endpoint name.</param>
        /// <param name="resourcePath">Resource path.</param>
        /// <param name="endpointType">Endpoint type.</param>
        public async Task PresubscribeAsync(String endpointName, String resourcePath, String endpointType = "")
        {
            var api = new mds.Api.SubscriptionsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            mds.Model.Presubscription presubscription = new mds.Model.Presubscription(endpointName, endpointType);
            mds.Model.PresubscriptionArray presubscriptionArray = new mds.Model.PresubscriptionArray();
            presubscriptionArray.Add(presubscription);
            await api.V2SubscriptionsPutAsync(presubscriptionArray);
        }

        /// <summary>
        /// Unsubscribe resource.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        /// <param name="resource">Resource to unsubscribe.</param>
        public void Unsubscribe(String deviceName, Resource resource)
        {
            string fixedPath = FixedPath(resource.Uri);
            var api = new mds.Api.SubscriptionsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            string subscribePath = deviceName + resource.Uri;
            api.V2SubscriptionsDeviceIdResourcePathDelete(deviceName, fixedPath);
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
            string fixedPath = FixedPath(resource.Uri);
            var api = new mds.Api.SubscriptionsApi(config.Host);
            api.Configuration.ApiKey["Authorization"] = config.ApiKey;
            api.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
            string subscribePath = deviceName + resource.Uri;
            await api.V2SubscriptionsDeviceIdResourcePathDeleteAsync(deviceName, fixedPath);
            if (resourceSubscribtions.ContainsKey(subscribePath))
            {
                resourceSubscribtions.Remove(subscribePath);
            }
        }
    }
}
