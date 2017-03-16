using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Statistics.Model
{
    class StatisticsData
    {
        /// <summary>
        /// Number of successful bootstrap certificate create requests account has used.
        /// </summary>
        /// <value>Number of successful bootstrap certificate create requests account has used.</value>
        public long? BootstrapCertificateCreate { get; set; }
        
        /// <summary>
        /// Number of suuccessful connector rest API requests account has used.
        /// </summary>
        /// <value>Number of suuccessful connector rest API requests account has used.</value>
        public long? ConnectorCaRestApiCount { get; set; }
        
        /// <summary>
        /// Number of failed bootstraps account has used.
        /// </summary>
        /// <value>Number of failed bootstraps account has used.</value>
        public long? BootstrapsFailed { get; set; }
        
        /// <summary>
        /// Number of failed connector rest API requests account has used.
        /// </summary>
        /// <value>Number of failed connector rest API requests account has used.</value>
        public long? ConnectorCaRestApiErrorCount { get; set; }
        
        /// <summary>
        /// Number of successful connector full credentials get requests account has used.
        /// </summary>
        /// <value>Number of successful connector full credentials get requests account has used.</value>
        public long? ConnectorFullCredentialsGet { get; set; }
        
        /// <summary>
        /// Number of successful bootstrap certificate delete requests account has used.
        /// </summary>
        /// <value>Number of successful bootstrap certificate delete requests account has used.</value>
        public long? BootstrapCertificateDelete { get; set; }
        
        /// <summary>
        /// UTC time in RFC3339 format
        /// </summary>
        /// <value>UTC time in RFC3339 format</value>
        public string Timestamp { get; set; }
        
        /// <summary>
        /// Number of pending bootstraps account has used.
        /// </summary>
        /// <value>Number of pending bootstraps account has used.</value>
        public long? BootstrapsPending { get; set; }
        
        /// <summary>
        /// Number of successful connector certificate create requests account has used.
        /// </summary>
        /// <value>Number of successful connector certificate create requests account has used.</value>
        public long? ConnectorCertificateCreate { get; set; }
        
        /// <summary>
        /// Number of successful bootstrap full credentials get requests account has used.
        /// </summary>
        /// <value>Number of successful bootstrap full credentials get requests account has used.</value>
        public long? BootstrapFullCredentialsGet { get; set; }
        /// <summary>
        /// Number of successful connector certificate create requests account has used.
        /// </summary>
        /// <value>Number of successful connector certificate create requests account has used.</value>

        public long? ConnectorCertificateDelete { get; set; }
        /// <summary>
        /// Number of successful connector credentials get requests account has used.
        /// </summary>
        /// <value>Number of successful connector credentials get requests account has used.</value>

        public long? ConnectorCredentialsGet { get; set; }
        /// <summary>
        /// Number of successful bootstrap credentials get requests account has used.
        /// </summary>
        /// <value>Number of successful bootstrap credentials get requests account has used.</value>

        public long? BootstrapCredentialsGet { get; set; }
        /// <summary>
        /// Number of successful bootstraps account has used.
        /// </summary>
        /// <value>Number of successful bootstraps account has used.</value>
        public long? BootstrapsSuccessful { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Data {\n");
            sb.Append("  BootstrapCertificateCreate: ").Append(BootstrapCertificateCreate).Append("\n");
            sb.Append("  ConnectorCaRestApiCount: ").Append(ConnectorCaRestApiCount).Append("\n");
            sb.Append("  BootstrapsFailed: ").Append(BootstrapsFailed).Append("\n");
            sb.Append("  ConnectorCaRestApiErrorCount: ").Append(ConnectorCaRestApiErrorCount).Append("\n");
            sb.Append("  ConnectorFullCredentialsGet: ").Append(ConnectorFullCredentialsGet).Append("\n");
            sb.Append("  BootstrapCertificateDelete: ").Append(BootstrapCertificateDelete).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("  BootstrapsPending: ").Append(BootstrapsPending).Append("\n");
            sb.Append("  ConnectorCertificateCreate: ").Append(ConnectorCertificateCreate).Append("\n");
            sb.Append("  BootstrapFullCredentialsGet: ").Append(BootstrapFullCredentialsGet).Append("\n");
            sb.Append("  ConnectorCertificateDelete: ").Append(ConnectorCertificateDelete).Append("\n");
            sb.Append("  ConnectorCredentialsGet: ").Append(ConnectorCredentialsGet).Append("\n");
            sb.Append("  BootstrapCredentialsGet: ").Append(BootstrapCredentialsGet).Append("\n");
            sb.Append("  BootstrapsSuccessful: ").Append(BootstrapsSuccessful).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
