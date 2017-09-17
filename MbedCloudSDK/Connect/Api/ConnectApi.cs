// <copyright file="ConnectApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MbedCloudSDK.Common;
using MbedCloudSDK.Connect.Model.ConnectedDevice;
using MbedCloudSDK.Connect.Model.Resource;
using mds.Api;

namespace MbedCloudSDK.Connect.Api
{
    /// <summary>
    /// Exposing functionality from the following underlying services:
    /// - Connector / mDS
    /// - Device query service
    /// - Device catalog
    /// </summary>
    public partial class ConnectApi : BaseApi
    {
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
        private static Dictionary<string, Resource> resourceSubscribtions = new Dictionary<string, Resource>();

        /// <summary>
        /// Responses to async requests.
        /// </summary>
        private static Dictionary<string, AsyncProducerConsumerCollection<string>> asyncResponses = new Dictionary<string, AsyncProducerConsumerCollection<string>>();
        private NotificationsApi notificationsApi;
        private DefaultApi defaultApi;

        public static Dictionary<string, AsyncProducerConsumerCollection<string>> AsyncResponses { get => asyncResponses; set => asyncResponses = value; }

        public static Dictionary<string, Resource> ResourceSubscribtions { get => resourceSubscribtions; set => resourceSubscribtions = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectApi"/> class.
        /// </summary>
        /// <param name="config">Config.</param>
        public ConnectApi(Config config)
            : base(config)
        {
            cancellationToken = new CancellationTokenSource();
            notificationTask = new Task(new Action(Notifications), cancellationToken.Token, TaskCreationOptions.LongRunning);
            ResourceSubscribtions = new Dictionary<string, Resource>();

            auth = string.Format("{0} {1}", config.AuthorizationPrefix, config.ApiKey);
            statistics.Client.Configuration.Default.ApiClient = new statistics.Client.ApiClient(config.Host);
            statistics.Client.Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            statistics.Client.Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            mds.Client.Configuration.Default.ApiClient = new mds.Client.ApiClient(config.Host);
            mds.Client.Configuration.Default.ApiKey["Authorization"] = config.ApiKey;
            mds.Client.Configuration.Default.ApiKeyPrefix["Authorization"] = config.AuthorizationPrefix;

            statisticsApi = new statistics.Api.StatisticsApi();
            subscriptionsApi = new SubscriptionsApi();
            resourcesApi = new ResourcesApi();
            endpointsApi = new EndpointsApi();
            accountApi = new statistics.Api.AccountApi();
            notificationsApi = new NotificationsApi();
            defaultApi = new DefaultApi();
        }

        /// <summary>
        /// Get meta data for the last Mbed Cloud API call
        /// </summary>
        public ApiMetadata GetLastApiMetadata()
        {
            var lastMds = mds.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault()?.Headers?.Where(m => m.Name == "Date")?.Select(d => DateTime.Parse(d.Value.ToString()))?.FirstOrDefault();
            var lastStats = statistics.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault()?.Headers?.Where(m => m.Name == "Date")?.Select(d => DateTime.Parse(d.Value.ToString()))?.FirstOrDefault();
            if (Nullable.Compare<DateTime>(lastMds, lastStats) > 0)
            {
                return ApiMetadata.Map(mds.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
            }
            else
            {
                return ApiMetadata.Map(statistics.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
            }
        }

        private string FixedPath(string path)
        {
            if (path.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Substring(1);
            }

            return path;
        }
    }
}
