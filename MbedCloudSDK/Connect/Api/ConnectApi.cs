// <copyright file="ConnectApi.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using device_directory.Client;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Connect.Model.ConnectedDevice;
    using MbedCloudSDK.Connect.Model.Resource;
    using mds.Api;

    /// <summary>
    /// Connect Api
    /// <example>
    /// This API is intialized with a <see cref="Config"/> object.
    /// <code>
    /// using MbedCloudSDK.Common;
    /// var config = new config(apiKey);
    /// var connectApi = new ConnectApi(config);
    /// </code>
    /// </example>
    /// <example>
    /// Some methods require a notification channel to be set up before they will work.
    /// <code>
    /// connectApi.StartNotifications();
    /// var resource = connectApi.GetResourceValue("", "5001/0/1");
    /// connectApi.StopNotifications();
    /// </code>
    /// </example>
    /// </summary>
    public partial class ConnectApi : BaseApi, IDisposable
    {
        /// <summary>
        /// Resources that are currently subscribed.
        /// </summary>
        private static Dictionary<string, Resource> resourceSubscribtions = new Dictionary<string, Resource>();

        /// <summary>
        /// Responses to async requests.
        /// </summary>
        private static Dictionary<string, AsyncProducerConsumerCollection<string>> asyncResponses = new Dictionary<string, AsyncProducerConsumerCollection<string>>();

        private Task notificationTask;
        private CancellationTokenSource cancellationToken;
        private device_directory.Api.DefaultApi deviceDirectoryApi;
        private statistics.Api.StatisticsApi statisticsApi;
        private EndpointsApi endpointsApi;
        private statistics.Api.AccountApi accountApi;
        private SubscriptionsApi subscriptionsApi;
        private ResourcesApi resourcesApi;
        private string auth;
        private NotificationsApi notificationsApi;
        private DeviceRequestsApi deviceRequestsApi;
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectApi"/> class.
        /// </summary>
        /// <param name="config"><see cref="Config"/></param>
        public ConnectApi(Config config)
            : base(config)
        {
            ResourceSubscribtions = new Dictionary<string, Resource>();

            var dateFormat = "yyyy-MM-dd'T'HH:mm:ss.fffZ";
            auth = string.Format("{0} {1}", config.AuthorizationPrefix, config.ApiKey);

            var statsConfig = new statistics.Client.Configuration
            {
                BasePath = config.Host,
                DateTimeFormat = dateFormat,
            };
            statsConfig.AddApiKey("Authorization", config.ApiKey);
            statsConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
            statsConfig.CreateApiClient();

            var mdsConfig = new mds.Client.Configuration
            {
                BasePath = config.Host,
                DateTimeFormat = dateFormat,
            };
            mdsConfig.AddApiKey("Authorization", config.ApiKey);
            mdsConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
            mdsConfig.CreateApiClient();

            var deviceConfig = new device_directory.Client.Configuration
            {
                BasePath = config.Host,
                DateTimeFormat = dateFormat,
            };
            deviceConfig.AddApiKey("Authorization", config.ApiKey);
            deviceConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
            deviceConfig.CreateApiClient();

            deviceDirectoryApi = new device_directory.Api.DefaultApi(deviceConfig);
            statisticsApi = new statistics.Api.StatisticsApi(statsConfig);
            subscriptionsApi = new SubscriptionsApi(mdsConfig);
            resourcesApi = new ResourcesApi(mdsConfig);
            endpointsApi = new EndpointsApi(mdsConfig);
            accountApi = new statistics.Api.AccountApi(statsConfig);
            notificationsApi = new NotificationsApi(mdsConfig);
            deviceRequestsApi = new DeviceRequestsApi(mdsConfig);
        }

        /// <summary>
        /// Gets or sets async responses
        /// </summary>
        public static Dictionary<string, AsyncProducerConsumerCollection<string>> AsyncResponses { get => asyncResponses; set => asyncResponses = value; }

        /// <summary>
        /// Gets or sets resource Subscriptions
        /// </summary>
        public static Dictionary<string, Resource> ResourceSubscribtions { get => resourceSubscribtions; set => resourceSubscribtions = value; }

        /// <summary>
        /// Get meta data for the last Mbed Cloud API call
        /// </summary>
        /// <returns><see cref="ApiMetadata"/></returns>
        public static ApiMetadata GetLastApiMetadata()
        {
            var lastMds = mds.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault()?.Headers?.Where(m => m.Name == "Date")?.Select(d => DateTime.Parse(d.Value.ToString()))?.FirstOrDefault();
            var lastStats = statistics.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault()?.Headers?.Where(m => m.Name == "Date")?.Select(d => DateTime.Parse(d.Value.ToString()))?.FirstOrDefault();
            if (Nullable.Compare(lastMds, lastStats) > 0)
            {
                return ApiMetadata.Map(mds.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
            }
            else
            {
                return ApiMetadata.Map(statistics.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Virtual dispose
        /// </summary>
        /// <param name="disposing">dispose</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            disposed = true;
            if (disposing)
            {
                cancellationToken?.Dispose();
            }
        }

        /// <summary>
        /// Throw if disposed
        /// </summary>
        protected virtual void ThrowIfDisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        private static string FixedPath(string path)
        {
            if (!path.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = $"/{path}";
            }

            return path;
        }
    }
}
