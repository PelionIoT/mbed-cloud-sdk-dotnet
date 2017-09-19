// <copyright file="Metric.cs" company="Arm">
// Copyright (c) Arm. All rights reserved.
// </copyright>

namespace MbedCloudSDK.Connect.Model.Metric
{
    using System;
    using System.Text;

    /// <summary>
    /// Metric
    /// </summary>
    public class Metric
    {
        /// <summary>
        /// Gets number of failed bootstraps account has used.
        /// </summary>
        /// <value>Number of failed bootstraps account has used.</value>
        public long? FailedBootstraps { get; private set; }

        /// <summary>
        /// Gets the ID of the metric
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets uTC time in RFC3339 format
        /// </summary>
        /// <value>UTC time in RFC3339 format</value>
        public DateTime? Timestamp { get; private set; }

        /// <summary>
        /// Gets the number of successful TLS handshakes the account has performed.
        /// </summary>
        public long? Handshakes { get; private set; }

        /// <summary>
        /// Gets number of pending bootstraps account has used.
        /// </summary>
        /// <value>Number of pending bootstraps account has used.</value>
        public long? PendingBootstraps { get; private set; }

        /// <summary>
        /// Gets the number of full registrations linked to the account.
        /// </summary>
        public long? FullRegistrations { get; private set; }

        /// <summary>
        /// Gets the number of registration updates linked to the account
        /// </summary>
        public long? UpdatedRegistrations { get; private set; }

        /// <summary>
        /// Gets the number of expired registrations linked to the account.
        /// </summary>
        public long? ExpiredRegistrations { get; private set; }

        /// <summary>
        /// Gets the number of deleted registrations(deregistrations) linked to the account.
        /// </summary>
        public long? DeletedRegistrations { get; private set; }

        /// <summary>
        /// Gets number of successful bootstraps account has used.
        /// </summary>
        /// <value>Number of successful bootstraps account has used.</value>
        public long? SuccessfulBootstraps { get; private set; }

        /// <summary>
        /// Gets number of transactions.
        /// </summary>
        /// <value>Number of transactions.</value>
        public long? Transactions { get; private set; }

        /// <summary>
        /// Gets or sets number of successful device server REST API requests the account has used.
        /// </summary>
        /// <value>Number of successful device server REST API requests the account has used.</value>
        public long? SuccessfulApiCalls { get; set; }

        /// <summary>
        /// Gets or sets number of failed device server REST API requests the account has used.
        /// </summary>
        /// <value>Number of failed device server REST API requests the account has used.</value>
        public long? FailedApiCalls { get; set; }

        /// <summary>
        /// Gets or sets the number of successful proxy requests from Mbed Cloud Connect to devices linked to the account. The proxy requests are made from
        /// Mbed Cloud Connect to devices when you try to read or write values to device resources using Connect API endpoints.
        /// </summary>
        /// <value>The number of successful proxy requests from Mbed Cloud Connect to devices linked to the account. The proxy requests are made from
        /// Mbed Cloud Connect to devices when you try to read or write values to device resources using Connect API endpoints.</value>
        public long? SuccessfulProxyRequests { get; set; }

        /// <summary>
        /// Gets or sets the number of failed proxy requests from Mbed Cloud Connect to devices linked to the account. The proxy requests are made from
        /// Mbed Cloud Connect to devices when you try to read or write values to device resources using Connect API endpoints.
        /// </summary>
        /// <value>The number of failed proxy requests from Mbed Cloud Connect to devices linked to the account. The proxy requests are made from
        /// Mbed Cloud Connect to devices when you try to read or write values to device resources using Connect API endpoints.</value>
        public long? FailedProxyRequests { get; set; }

        /// <summary>
        /// Gets or sets the number of successful subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.
        /// </summary>
        /// <value>The number of successful subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.</value>
        public long? SuccessfulSubscriptionRequests { get; set; }

        /// <summary>
        /// Gets or sets the number of failed subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.
        /// </summary>
        /// <value>The number of failed subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.</value>
        public long? FailedSubscriptionRequests { get; set; }

        /// <summary>
        /// Gets or sets the number of observations received by Mbed Cloud Connect from the devices linked to the account. The observations are pushed from the device to
        /// Mbed Cloud Connect when you have successfully subscribed to the device resources using Connect API endpoints.
        /// </summary>
        /// <value>The number of observations received by Mbed Cloud Connect from the devices linked to the account. The observations are pushed from the device to
        /// Mbed Cloud Connect when you have successfully subscribed to the device resources using Connect API endpoints.</value>
        public long? Observations { get; set; }

        /// <summary>
        /// Map
        /// </summary>
        /// <param name="statisticsData">Statistics Metric</param>
        /// <returns>Metric</returns>
        public static Metric Map(statistics.Model.Metric statisticsData)
        {
            Metric metric = new Metric
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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Metric {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  Handshakes: ").Append(Handshakes).Append("\n");
            sb.Append("  Transactions: ").Append(Transactions).Append("\n");
            sb.Append("  Observations: ").Append(Observations).Append("\n");
            sb.Append("  SuccessfulApiCalls: ").Append(SuccessfulApiCalls).Append("\n");
            sb.Append("  FailedApiCalls: ").Append(FailedApiCalls).Append("\n");
            sb.Append("  SuccessfulProxyRequests: ").Append(SuccessfulProxyRequests).Append("\n");
            sb.Append("  FailedProxyRequests: ").Append(FailedProxyRequests).Append("\n");
            sb.Append("  SuccessfulSubscriptionRequests: ").Append(SuccessfulSubscriptionRequests).Append("\n");
            sb.Append("  FailedSubscriptionRequests: ").Append(FailedSubscriptionRequests).Append("\n");
            sb.Append("  SuccessfulBootstraps: ").Append(SuccessfulBootstraps).Append("\n");
            sb.Append("  FailedBootstraps: ").Append(FailedBootstraps).Append("\n");
            sb.Append("  PendingBootstraps: ").Append(PendingBootstraps).Append("\n");
            sb.Append("  FullRegistrations: ").Append(FullRegistrations).Append("\n");
            sb.Append("  UpdatedRegistrations: ").Append(UpdatedRegistrations).Append("\n");
            sb.Append("  ExpiredRegistrations: ").Append(ExpiredRegistrations).Append("\n");
            sb.Append("  DeletedRegistrations: ").Append(DeletedRegistrations).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}