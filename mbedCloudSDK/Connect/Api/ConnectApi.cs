using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using mbedCloudSDK.Common;
using mbedCloudSDK.Connect.Model.ConnectedDevice;
using mbedCloudSDK.Connect.Model.Resource;

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

        private Task longPollingTask;
        private CancellationTokenSource cancellationToken;
        private statistics.Api.StatisticsApi statisticsApi;
        private statistics.Api.AccountApi accountApi;
        private string auth;

        /// <summary>
        /// Resources that are currently subscribed.
        /// </summary>
        public static Dictionary<String, Resource> resourceSubscribtions = new Dictionary<string, Resource>();

        /// <summary>
        /// Responses to async requests.
        /// </summary>
        public static Dictionary<String, AsyncProducerConsumerCollection<String>> asyncResponses = new Dictionary<string, AsyncProducerConsumerCollection<String>>();

        #endregion

        #region Contructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:mbedCloudSDK.DeviceDirectory.DeviceDirectory"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public ConnectApi(Config config) : base(config)
        {
            cancellationToken = new CancellationTokenSource();
            longPollingTask = new Task(new Action(LongPolling), cancellationToken.Token, TaskCreationOptions.LongRunning);
            resourceSubscribtions = new Dictionary<string, Resource>();

            this.auth = string.Format("{0} {1}", config.AuthorizationPrefix, config.ApiKey);

            statisticsApi = new statistics.Api.StatisticsApi(config.Host);
            statisticsApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            statisticsApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            accountApi = new statistics.Api.AccountApi(config.Host);
            accountApi.Configuration.ApiKey["Authorization"] = config.ApiKey;
            accountApi.Configuration.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;
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
