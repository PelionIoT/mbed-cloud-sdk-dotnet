using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbedCloudSDK.Connect.Model.Metric
{
    public class MetricQueryOptions
    {
        /// <summary>
        /// Comma-separated list of requested metrics.Supported values are bootstraps_successful, bootstraps_failed, bootstraps_pending, bootstrap_certificate_create, bootstrap_certificate_delete, connector_certificate_create, connector_certificate_delete, bootstrap_credentials_get, bootstrap_full_credentials_get, connector_credentials_get, connector_full_credentials_get, connector_ca_rest_api_count, connector_ca_rest_api_error_count
        /// </summary>
        public string Include { get; set; }

        /// <summary>
        /// UTC time/year/date in RFC3339 format. Fetch data with timestamp greater than or equal to this value. Sample values: 20170207T092056990Z / 2017-02-07T09:20:56.990Z / 2017 / 20170207. The parameter is not mandatory, if period specified.
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// UTC time / year / date in RFC3339 format. Fetch data with timestamp less than this value.Sample values: 20170207T092056990Z / 2017-02-07T09:20:56.990Z / 2017 / 20170207.The parameter is not mandatory, if period specified. 
        /// </summary>
        public string End { get; set; }

        /// <summary>
        /// Period. Fetch data for the period in days, weeks, hours or minutes. Sample values: 2h, 3w, 4d, 5m. The parameter is not mandatory, if start and end time are specified. 
        /// </summary>
        public string Period { get; set; }

        /// <summary>
        /// Group data by this interval in days, weeks, hours or minutes. Sample values: 2h, 3w, 4d, 5m. 
        /// </summary>
        public string Interval { get; set; }

        public MetricQueryOptions()
        {
            this.Include = "transactions, bootstraps_successful, bootstraps_pending, bootstraps_failed, device_server_rest_api_success, device_server_rest_api_error";
            this.Interval = "1d";
            this.Period = "1m";
        }
    }
}
