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
    using device_directory.Api;
    using device_directory.Client;
    using Mbed.Cloud.Foundation.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Connect.Model;
    using MbedCloudSDK.Connect.Model.ConnectedDevice;
    using NotificationDeliveryMethod = MbedCloudSDK.Connect.Model.Enums;
    using MbedCloudSDK.Connect.Model.Notifications;
    using MbedCloudSDK.Connect.Model.Resource;
    using mds.Api;
    using statistics.Api;
    using System.Collections.Concurrent;
    using Nito.AsyncEx;

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
    public partial class ConnectApi : Api, IDisposable
    {
        private bool disposed;

        private static string websocketUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectApi"/> class.
        /// </summary>
        /// <param name="config"><see cref="Config"/></param>
        public ConnectApi(ConnectApiConfig config)
            : this(config as Config)
        {
            skipCleanup = config.SkipCleanup;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectApi"/> class.
        /// </summary>
        /// <param name="config"><see cref="Config"/></param>
        public ConnectApi(Config config)
            : base(config)
        {
            SetUpApi(config);
            Subscribe = new Subscribe.Subscribe(this);
            websocketUrl = $"wss://{config.Host.Replace("https://", "")}/v2/notification/websocket-connect";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectApi" /> class.
        /// </summary>
        /// <param name="config"><see cref="Config" /></param>
        /// <param name="statsConfig">The stats configuration.</param>
        /// <param name="mdsConfig">The MDS configuration.</param>
        /// <param name="deviceConfig">The device configuration.</param>
        internal ConnectApi(Config config, statistics.Client.Configuration statsConfig = null, mds.Client.Configuration mdsConfig = null, device_directory.Client.Configuration deviceConfig = null)
            : base(config)
        {
            forceClear = config.ForceClear == true;
            autostartNotifications = config.AutostartNotifications != false;
            if (this.autostartNotifications == true)
            {
                DeliveryMethod = NotificationDeliveryMethod.DeliveryMethod.CLIENT_INITIATED;
            }
            ResourceSubscribtions = new ConcurrentDictionary<string, Resource>();
            SetUpApi(config, statsConfig, mdsConfig, deviceConfig);
        }

        /// <summary>
        /// Gets async responses
        /// </summary>
        public ConcurrentDictionary<string, AsyncCollection<string>> AsyncResponses { get; } = new ConcurrentDictionary<string, AsyncCollection<string>>();

        /// <summary>
        /// Gets NotificationQueue
        /// </summary>
        public ConcurrentDictionary<string, AsyncCollection<string>> NotificationQueue { get; } = new ConcurrentDictionary<string, AsyncCollection<string>>();

        /// <summary>
        /// Gets resource Subscriptions
        /// </summary>
        public ConcurrentDictionary<string, Resource> ResourceSubscribtions { get; } = new ConcurrentDictionary<string, Resource>();

        /// <summary>
        /// Gets or sets the SubscribeManager
        /// </summary>
        public MbedCloudSDK.Connect.Api.Subscribe.Subscribe Subscribe { get; set; }

        public NotificationDeliveryMethod.DeliveryMethod? DeliveryMethod { get; private set; }

        private readonly bool forceClear;
        private readonly bool autostartNotifications;
        private readonly bool skipCleanup;

        /// <summary>
        /// Gets or sets the account API.
        /// </summary>
        /// <value>
        /// The account API.
        /// </value>
        internal AccountApi AccountApi { get; set; }

        /// <summary>
        /// Gets or sets the device directory API.
        /// </summary>
        /// <value>
        /// The device directory API.
        /// </value>
        internal DefaultApi DeviceDirectoryApi { get; set; }

        /// <summary>
        /// Gets or sets the device requests API.
        /// </summary>
        /// <value>
        /// The device requests API.
        /// </value>
        internal DeviceRequestsApi DeviceRequestsApi { get; set; }

        /// <summary>
        /// Gets or sets the endpoints API.
        /// </summary>
        /// <value>
        /// The endpoints API.
        /// </value>
        internal EndpointsApi EndpointsApi { get; set; }

        /// <summary>
        /// Gets or sets the notifications API.
        /// </summary>
        /// <value>
        /// The notifications API.
        /// </value>
        internal NotificationsApi NotificationsApi { get; set; }

        /// <summary>
        /// Gets or sets the resources API.
        /// </summary>
        /// <value>
        /// The resources API.
        /// </value>
        internal ResourcesApi ResourcesApi { get; set; }

        /// <summary>
        /// Gets or sets the statistics API.
        /// </summary>
        /// <value>
        /// The statistics API.
        /// </value>
        internal StatisticsApi StatisticsApi { get; set; }

        /// <summary>
        /// Gets or sets the subscriptions API.
        /// </summary>
        /// <value>
        /// The subscriptions API.
        /// </value>
        internal SubscriptionsApi SubscriptionsApi { get; set; }

        /// <summary>
        /// Get meta data for the last Mbed Cloud API call
        /// </summary>
        /// <returns><see cref="ApiMetadata"/></returns>
        public static ApiMetadata GetLastApiMetadata()
        {
            var lastMds = mds.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault()?.Headers?.Where(m => m.Name == "Date")?.Select(d => DateTime.Parse(d.Value.ToString()))?.FirstOrDefault();
            var lastStats = statistics.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault()?.Headers?.Where(m => m.Name == "Date")?.Select(d => DateTime.Parse(d.Value.ToString()))?.FirstOrDefault();
            return Nullable.Compare(lastMds, lastStats) > 0 ? ApiMetadata.Map(mds.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault()) : ApiMetadata.Map(statistics.Client.Configuration.Default.ApiClient.LastApiResponse.LastOrDefault());
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
                StopNotifications();
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

        private static string AddLeadingSlash(string path)
        {
            if (!path.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = $"/{path}";
            }

            return path;
        }

        private static string RemoveLeadingSlash(string path)
        {
            if (path.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Substring(1);
            }

            return path;
        }

        private void SetUpApi(Config config, statistics.Client.Configuration statsConfig = null, mds.Client.Configuration mdsConfig = null, Configuration deviceConfig = null)
        {
            const string dateFormat = "yyyy-MM-dd'T'HH:mm:ss.fffZ";
            var auth = $"{config.AuthorizationPrefix} {config.ApiKey}";

            if (statsConfig == null)
            {
                statsConfig = new statistics.Client.Configuration
                {
                    BasePath = config.Host,
                    DateTimeFormat = dateFormat,
                    UserAgent = UserAgent,
                };
                statsConfig.AddApiKey("Authorization", config.ApiKey);
                statsConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
                statsConfig.CreateApiClient();
            }

            if (mdsConfig == null)
            {
                mdsConfig = new mds.Client.Configuration
                {
                    BasePath = config.Host,
                    DateTimeFormat = dateFormat,
                    UserAgent = UserAgent,
                };
                mdsConfig.AddApiKey("Authorization", config.ApiKey);
                mdsConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
                mdsConfig.CreateApiClient();
            }

            if (deviceConfig == null)
            {
                deviceConfig = new device_directory.Client.Configuration
                {
                    BasePath = config.Host,
                    DateTimeFormat = dateFormat,
                    UserAgent = UserAgent,
                };
                deviceConfig.AddApiKey("Authorization", config.ApiKey);
                deviceConfig.AddApiKeyPrefix("Authorization", config.AuthorizationPrefix);
                deviceConfig.CreateApiClient();
            }

            DeviceDirectoryApi = new device_directory.Api.DefaultApi(deviceConfig);
            StatisticsApi = new statistics.Api.StatisticsApi(statsConfig);
            SubscriptionsApi = new SubscriptionsApi(mdsConfig);
            ResourcesApi = new ResourcesApi(mdsConfig);
            EndpointsApi = new EndpointsApi(mdsConfig);
            AccountApi = new statistics.Api.AccountApi(statsConfig);
            NotificationsApi = new NotificationsApi(mdsConfig);
            DeviceRequestsApi = new DeviceRequestsApi(mdsConfig);
        }
    }
}
