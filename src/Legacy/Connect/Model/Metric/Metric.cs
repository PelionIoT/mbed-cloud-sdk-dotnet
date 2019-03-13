// <copyright file="Metric.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.Metric
{
    using System;
    using System.Text;
    using Mbed.Cloud.Common;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Extensions;
    using Newtonsoft.Json;

    /// <summary>
    /// Metric
    /// </summary>
    public class Metric : Entity
    {
        /// <summary>
        /// Gets number of failed bootstraps account has used.
        /// </summary>
        /// <value>Number of failed bootstraps account has used.</value>
        [JsonProperty]
        public long? FailedBootstraps { get; private set; }

        /// <summary>
        /// Gets UTC time in RFC3339 format
        /// </summary>
        /// <value>UTC time in RFC3339 format</value>
        [JsonProperty]
        public DateTime? Timestamp { get; private set; }

        /// <summary>
        /// Gets the number of successful TLS handshakes the account has performed.
        /// </summary>
        [JsonProperty]
        public long? Handshakes { get; private set; }

        /// <summary>
        /// Gets number of pending bootstraps account has used.
        /// </summary>
        /// <value>Number of pending bootstraps account has used.</value>
        [JsonProperty]
        public long? PendingBootstraps { get; private set; }

        /// <summary>
        /// Gets the number of full registrations linked to the account.
        /// </summary>
        [JsonProperty]
        public long? FullRegistrations { get; private set; }

        /// <summary>
        /// Gets the number of registration updates linked to the account
        /// </summary>
        [JsonProperty]
        public long? UpdatedRegistrations { get; private set; }

        /// <summary>
        /// Gets the number of expired registrations linked to the account.
        /// </summary>
        [JsonProperty]
        public long? ExpiredRegistrations { get; private set; }

        /// <summary>
        /// Gets the number of deleted registrations(deregistrations) linked to the account.
        /// </summary>
        [JsonProperty]
        public long? DeletedRegistrations { get; private set; }

        /// <summary>
        /// Gets number of successful bootstraps account has used.
        /// </summary>
        /// <value>Number of successful bootstraps account has used.</value>
        [JsonProperty]
        public long? SuccessfulBootstraps { get; private set; }

        /// <summary>
        /// Gets number of transactions.
        /// </summary>
        /// <value>Number of transactions.</value>
        [JsonProperty]
        public long? Transactions { get; private set; }

        /// <summary>
        /// Gets number of successful device server REST API requests the account has used.
        /// </summary>
        /// <value>Number of successful device server REST API requests the account has used.</value>
        [JsonProperty]
        public long? SuccessfulApiCalls { get; private set; }

        /// <summary>
        /// Gets number of failed device server REST API requests the account has used.
        /// </summary>
        /// <value>Number of failed device server REST API requests the account has used.</value>
        [JsonProperty]
        public long? FailedApiCalls { get; private set; }

        /// <summary>
        /// Gets the number of successful proxy requests from Mbed Cloud Connect to devices linked to the account. The proxy requests are made from
        /// Mbed Cloud Connect to devices when you try to read or write values to device resources using Connect API endpoints.
        /// </summary>
        /// <value>The number of successful proxy requests from Mbed Cloud Connect to devices linked to the account. The proxy requests are made from
        /// Mbed Cloud Connect to devices when you try to read or write values to device resources using Connect API endpoints.</value>
        [JsonProperty]
        public long? SuccessfulProxyRequests { get; private set; }

        /// <summary>
        /// Gets the number of failed proxy requests from Mbed Cloud Connect to devices linked to the account. The proxy requests are made from
        /// Mbed Cloud Connect to devices when you try to read or write values to device resources using Connect API endpoints.
        /// </summary>
        /// <value>The number of failed proxy requests from Mbed Cloud Connect to devices linked to the account. The proxy requests are made from
        /// Mbed Cloud Connect to devices when you try to read or write values to device resources using Connect API endpoints.</value>
        [JsonProperty]
        public long? FailedProxyRequests { get; private set; }

        /// <summary>
        /// Gets the number of successful subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.
        /// </summary>
        /// <value>The number of successful subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.</value>
        [JsonProperty]
        public long? SuccessfulSubscriptionRequests { get; private set; }

        /// <summary>
        /// Gets the number of failed subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.
        /// </summary>
        /// <value>The number of failed subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.</value>
        [JsonProperty]
        public long? FailedSubscriptionRequests { get; private set; }

        /// <summary>
        /// Gets the number of observations received by Mbed Cloud Connect from the devices linked to the account. The observations are pushed from the device to
        /// Mbed Cloud Connect when you have successfully subscribed to the device resources using Connect API endpoints.
        /// </summary>
        /// <value>The number of observations received by Mbed Cloud Connect from the devices linked to the account. The observations are pushed from the device to
        /// Mbed Cloud Connect when you have successfully subscribed to the device resources using Connect API endpoints.</value>
        [JsonProperty]
        public long? Observations { get; private set; }

        /// <summary>
        /// Map
        /// </summary>
        /// <param name="statisticsData">Statistics Metric</param>
        /// <returns>Metric</returns>
        public static Metric Map(statistics.Model.Metric statisticsData)
        {
            var metric = new Metric
            {
                Id = statisticsData.Id,
                Timestamp = statisticsData.Timestamp,
                Handshakes = statisticsData.HandshakesSuccessful,
                Transactions = statisticsData.Transactions,
                Observations = statisticsData.DeviceObservations,
                SuccessfulApiCalls = statisticsData.ConnectRestApiSuccess,
                FailedApiCalls = statisticsData.ConnectRestApiError,
                SuccessfulProxyRequests = statisticsData.DeviceProxyRequestSuccess,
                FailedProxyRequests = statisticsData.DeviceProxyRequestError,
                SuccessfulSubscriptionRequests = statisticsData.DeviceSubscriptionRequestSuccess,
                FailedSubscriptionRequests = statisticsData.DeviceSubscriptionRequestError,
                SuccessfulBootstraps = statisticsData.BootstrapsSuccessful,
                FailedBootstraps = statisticsData.BootstrapsFailed,
                PendingBootstraps = statisticsData.BootstrapsPending,
                FullRegistrations = statisticsData.FullRegistrations,
                UpdatedRegistrations = statisticsData.RegistrationUpdates,
                ExpiredRegistrations = statisticsData.ExpiredRegistrations,
                DeletedRegistrations = statisticsData.DeletedRegistrations
            };
            return metric;
        }

        /// <summary>
        /// Returns the string presentation of the object.
        /// </summary>
        /// <returns>String presentation of the object.</returns>
        public override string ToString()
            => this.DebugDump();
    }
}
