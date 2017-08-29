using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using mbedCloudSDK.Common;
using mbedCloudSDK.Connect.Model.ConnectedDevice;
using mbedCloudSDK.Connect.Model.Resource;
using mds.Api;

namespace mbedCloudSDK.Connect.Api
{
    /// <summary>
    /// Exposing functionality from the following underlying services:
    /// - Connector / mDS
    /// - Device query service
    /// - Device catalog
    /// </summary>
    public partial class ConnectApi : BaseApi
    {

        #region Variables

        private Task notificationTask;
        private CancellationTokenSource cancellationToken;
        private statistics.Api.StatisticsApi statisticsApi;
        private EndpointsApi endpointsApi;
        private statistics.Api.AccountApi accountApi;
        private SubscriptionsApi subscriptionsApi;
        private mds.Api.ResourcesApi resourcesApi;
        private string auth;

        /// <summary>
        /// Resources that are currently subscribed.
        /// </summary>
        public static Dictionary<string, Resource> resourceSubscribtions = new Dictionary<string, Resource>();

        /// <summary>
        /// Responses to async requests.
        /// </summary>
        public static Dictionary<String, AsyncProducerConsumerCollection<String>> asyncResponses = new Dictionary<string, AsyncProducerConsumerCollection<String>>();
        private NotificationsApi notificationsApi;
        private DefaultApi defaultApi;

        #endregion

        #region Contructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.DeviceDirectory.DeviceDirectory"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public ConnectApi(Config config) : base(config)
        {
            cancellationToken = new CancellationTokenSource();
            notificationTask = new Task(new Action(Notifications), cancellationToken.Token, TaskCreationOptions.LongRunning);
            resourceSubscribtions = new Dictionary<string, Resource>();

            this.auth = string.Format("{0} {1}", config.AuthorizationPrefix, config.ApiKey);

            statisticsApi = new statistics.Api.StatisticsApi(config.Host);
            statisticsApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            statisticsApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            subscriptionsApi = new mds.Api.SubscriptionsApi(config.Host);
            subscriptionsApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            subscriptionsApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            resourcesApi =  new mds.Api.ResourcesApi(config.Host);
            resourcesApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            resourcesApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            endpointsApi = new mds.Api.EndpointsApi(config.Host);
            endpointsApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            endpointsApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            accountApi = new statistics.Api.AccountApi(config.Host);
            accountApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            accountApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            notificationsApi = new mds.Api.NotificationsApi(config.Host);
            notificationsApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            notificationsApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            defaultApi = new mds.Api.DefaultApi(config.Host);
            defaultApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            defaultApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

        }

        #endregion

        #region Utils

        private string FixedPath(string path)
        {
            if (path.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Substring(1);
            }
            return path;
        }

        #endregion
    }
}
