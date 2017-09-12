using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbedCloudSDK.Connect.Model.Metric
{
    /// <summary>
    /// Metric
    /// </summary>
    public class Metric
    {
        
        /// <summary>
        /// Number of failed bootstraps account has used.
        /// </summary>
        /// <value>Number of failed bootstraps account has used.</value>
        public long? FailedBootstraps { get; private set; }
        
        /// <summary>
        /// Number of successful bootstrap certificate delete requests account has used.
        /// </summary>
        /// <value>Number of successful bootstrap certificate delete requests account has used.</value>
        public long? BootstrapCertificateDelete { get; private set; }

        /// <summary>
        /// The ID of the metric
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// UTC time in RFC3339 format
        /// </summary>
        /// <value>UTC time in RFC3339 format</value>
        public DateTime? Timestamp { get; private set; }

        /// <summary>
        /// The number of successful TLS handshakes the account has performed.
        /// </summary>
        public long? Handshakes { get; private set; }

        /// <summary>
        /// Number of pending bootstraps account has used.
        /// </summary>
        /// <value>Number of pending bootstraps account has used.</value>
        public long? PendingBootstraps { get; private set; }

        /// <summary>
        /// The number of full registrations linked to the account.
        /// </summary>
        public long? FullRegistrations { get; private set; }

        /// <summary>
        /// The number of registration updates linked to the account
        /// </summary>
        public long? UpdatedRegistrations { get; private set; }

        /// <summary>
        /// The number of expired registrations linked to the account.
        /// </summary>
        public long? ExpiredRegistrations { get; private set; }

        /// <summary>
        /// The number of deleted registrations(deregistrations) linked to the account.
        /// </summary>
        public long? DeletedRegistrations { get; private set; }

        /// <summary>
        /// Number of successful bootstraps account has used.
        /// </summary>
        /// <value>Number of successful bootstraps account has used.</value>
        public long? SuccessfulBootstraps { get; private set; }

        /// <summary>
        /// Number of transactions.
        /// </summary>
        /// <value>Number of transactions.</value>
        public long? Transactions { get; private set; }

        /// <summary>
        /// Number of successful device server REST API requests the account has used.
        /// </summary>
        /// <value>Number of successful device server REST API requests the account has used.</value>
        public long? SuccessfulApiCalls { get; set; }

        /// <summary>
        /// Number of failed device server REST API requests the account has used.
        /// </summary>
        /// <value>Number of failed device server REST API requests the account has used.</value>
        public long? FailedApiCalls { get; set; }

        /// <summary>
        /// The number of successful proxy requests from Mbed Cloud Connect to devices linked to the account. The proxy requests are made from
        /// Mbed Cloud Connect to devices when you try to read or write values to device resources using Connect API endpoints.
        /// </summary>
        /// <value>The number of successful proxy requests from Mbed Cloud Connect to devices linked to the account. The proxy requests are made from
        /// Mbed Cloud Connect to devices when you try to read or write values to device resources using Connect API endpoints.</value>
        public long? SuccessfulProxyRequests { get; set; }

        /// <summary>
        /// The number of failed proxy requests from Mbed Cloud Connect to devices linked to the account. The proxy requests are made from
        /// Mbed Cloud Connect to devices when you try to read or write values to device resources using Connect API endpoints.
        /// </summary>
        /// <value>The number of failed proxy requests from Mbed Cloud Connect to devices linked to the account. The proxy requests are made from
        /// Mbed Cloud Connect to devices when you try to read or write values to device resources using Connect API endpoints.</value>
        public long? FailedProxyRequests { get; set; }

        /// <summary>
        /// The number of successful subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.
        /// </summary>
        /// <value>The number of successful subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.</value>
        public long? SuccessfulSubscriptionRequests { get; set; }

        /// <summary>
        /// The number of failed subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.
        /// </summary>
        /// <value>The number of failed subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.</value>
        public long? FailedSubscriptionRequests { get; set; }

        /// <summary>
        /// The number of observations received by Mbed Cloud Connect from the devices linked to the account. The observations are pushed from the device to
        /// Mbed Cloud Connect when you have successfully subscribed to the device resources using Connect API endpoints.
        /// </summary>
        /// <value>The number of observations received by Mbed Cloud Connect from the devices linked to the account. The observations are pushed from the device to
        /// Mbed Cloud Connect when you have successfully subscribed to the device resources using Connect API endpoints.</value>
        public long? Observations { get; set; }

        public static Metric Map(statistics.Model.Metric statisticsData)
        {
            Metric metric = new Metric();
            metric.Id = statisticsData.Id;
            metric.Timestamp = statisticsData.Timestamp;
            metric.Handshakes = statisticsData.HandshakesSuccessful;
            metric.Transactions = statisticsData.Transactions;
            metric.Observations = statisticsData.DeviceObservations;
            metric.SuccessfulApiCalls = statisticsData.ConnectRestApiSuccess;
            metric.FailedApiCalls = statisticsData.ConnectRestApiError;
            metric.SuccessfulProxyRequests = statisticsData.DeviceProxyRequestSuccess;
            metric.FailedProxyRequests = statisticsData.DeviceProxyRequestError;
            metric.SuccessfulSubscriptionRequests = statisticsData.DeviceSubscriptionRequestSuccess;
            metric.FailedSubscriptionRequests = statisticsData.DeviceSubscriptionRequestError;
            metric.SuccessfulBootstraps = statisticsData.BootstrapsSuccessful;
            metric.FailedBootstraps = statisticsData.BootstrapsFailed;
            metric.PendingBootstraps = statisticsData.BootstrapsPending;
            metric.FullRegistrations = statisticsData.FullRegistrations;
            metric.UpdatedRegistrations = statisticsData.RegistrationUpdates;
            metric.ExpiredRegistrations = statisticsData.ExpiredRegistrations;
            metric.DeletedRegistrations = statisticsData.DeletedRegistrations;
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