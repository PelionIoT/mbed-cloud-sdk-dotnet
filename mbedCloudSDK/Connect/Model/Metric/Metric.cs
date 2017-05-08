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
        public string Timestamp { get; private set; }
        
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

        public static Metric Map(statistics.Model.Metric statisticsData)
        {
            Metric metric = new Metric();
            metric.FailedDeviceRegistrations = statisticsData.BootstrapsFailed;
            metric.Timestamp = statisticsData.Timestamp;
            metric.Transactions = statisticsData.Transactions;
            metric.PendingDeviceRegistrations = statisticsData.BootstrapsPending;
            metric.SuccessfulDeviceRegistrations = statisticsData.BootstrapsSuccessful;
            metric.SuccessfulApiCalls = statisticsData.DeviceServerRestApiSuccess;
            metric.FailedApiCalls = statisticsData.DeviceServerRestApiError;
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
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
