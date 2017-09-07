using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Connect.Model.Metric
{
    public class Metric
    {
        
        /// <summary>
        /// Number of failed bootstraps account has used.
        /// </summary>
        /// <value>Number of failed bootstraps account has used.</value>
        public long? FailedDeviceRegistrations { get; private set; }
        
        /// <summary>
        /// Number of successful bootstrap certificate delete requests account has used.
        /// </summary>
        /// <value>Number of successful bootstrap certificate delete requests account has used.</value>
        public long? BootstrapCertificateDelete { get; private set; }
        
        /// <summary>
        /// UTC time in RFC3339 format
        /// </summary>
        /// <value>UTC time in RFC3339 format</value>
        public DateTime? Timestamp { get; private set; }
        
        /// <summary>
        /// Number of pending bootstraps account has used.
        /// </summary>
        /// <value>Number of pending bootstraps account has used.</value>
        public long? PendingDeviceRegistrations { get; private set; }
        
        /// <summary>
        /// Number of successful bootstraps account has used.
        /// </summary>
        /// <value>Number of successful bootstraps account has used.</value>
        public long? SuccessfulDeviceRegistrations { get; private set; }

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
        public long? DeviceProxyRequestSuccess { get; set; }
        /// <summary>
        /// The number of failed proxy requests from Mbed Cloud Connect to devices linked to the account. The proxy requests are made from
        /// Mbed Cloud Connect to devices when you try to read or write values to device resources using Connect API endpoints.
        /// </summary>
        /// <value>The number of failed proxy requests from Mbed Cloud Connect to devices linked to the account. The proxy requests are made from
        /// Mbed Cloud Connect to devices when you try to read or write values to device resources using Connect API endpoints.</value>
        public long? DeviceProxyRequestError { get; set; }
        /// <summary>
        /// The number of successful subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.
        /// </summary>
        /// <value>The number of successful subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.</value>
        public long? DeviceSubscriptionRequestSuccess { get; set; }
        /// <summary>
        /// The number of failed subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.
        /// </summary>
        /// <value>The number of failed subscription requests from Mbed Cloud Connect to devices linked to the account. The subscription requests are made from
        /// Mbed Cloud Connect to devices when you try to subscribe to a resource path using Connect API endpoints.</value>
        public long? DeviceSubscriptionRequestError { get; set; }
        /// <summary>
        /// The number of observations received by Mbed Cloud Connect from the devices linked to the account. The observations are pushed from the device to
        /// Mbed Cloud Connect when you have successfully subscribed to the device resources using Connect API endpoints.
        /// </summary>
        /// <value>The number of observations received by Mbed Cloud Connect from the devices linked to the account. The observations are pushed from the device to
        /// Mbed Cloud Connect when you have successfully subscribed to the device resources using Connect API endpoints.</value>
        public long? DeviceObservations { get; set; }

        public static Metric Map(statistics.Model.Metric statisticsData)
        {
            Metric metric = new Metric();
            metric.FailedDeviceRegistrations = statisticsData.BootstrapsFailed;
            metric.Timestamp = statisticsData.Timestamp;
            metric.Transactions = statisticsData.Transactions;
            metric.PendingDeviceRegistrations = statisticsData.BootstrapsPending;
            metric.SuccessfulDeviceRegistrations = statisticsData.BootstrapsSuccessful;
            metric.SuccessfulApiCalls = statisticsData.ConnectRestApiSuccess;
            metric.FailedApiCalls = statisticsData.ConnectRestApiError;
            metric.DeviceProxyRequestSuccess = statisticsData.DeviceProxyRequestSuccess;
            metric.DeviceProxyRequestError = statisticsData.DeviceProxyRequestError;
            metric.DeviceSubscriptionRequestSuccess = statisticsData.DeviceSubscriptionRequestSuccess;
            metric.DeviceSubscriptionRequestError = statisticsData.DeviceSubscriptionRequestError;
            metric.DeviceObservations = statisticsData.DeviceObservations;
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
            sb.Append("  FailedDeviceRegistrations: ").Append(FailedDeviceRegistrations).Append("\n");
            sb.Append("  PendingDeviceRegistrations: ").Append(PendingDeviceRegistrations).Append("\n");
            sb.Append("  SuccessfulDeviceRegistrations: ").Append(SuccessfulDeviceRegistrations).Append("\n");
            sb.Append("  BootstrapCertificateDelete: ").Append(BootstrapCertificateDelete).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  SuccessfulApiCalls: ").Append(SuccessfulApiCalls).Append("\n");
            sb.Append("  FailedApiCalls: ").Append(FailedApiCalls).Append("\n");
            sb.Append("  DeviceProxyRequestSuccess: ").Append(DeviceProxyRequestSuccess).Append("\n");
            sb.Append("  DeviceProxyRequestError: ").Append(DeviceProxyRequestError).Append("\n");
            sb.Append("  DeviceSubscriptionRequestSuccess: ").Append(DeviceSubscriptionRequestSuccess).Append("\n");
            sb.Append("  DeviceSubscriptionRequestError: ").Append(DeviceSubscriptionRequestError).Append("\n");
            sb.Append("  DeviceObservations: ").Append(DeviceObservations).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}