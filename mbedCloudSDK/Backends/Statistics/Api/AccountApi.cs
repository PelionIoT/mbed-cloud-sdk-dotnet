/* 
 * Connect Statistics API
 *
 * mbed Cloud Connect Statistics API provides statistics about other cloud services through defined counters.
 *
 * OpenAPI spec version: 3
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using statistics.Client;
using statistics.Model;

namespace statistics.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAccountApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Provides account-specific statistics for other cloud services.
        /// </summary>
        /// <remarks>
        /// This REST API is used to get account-specific statistics.
        /// </remarks>
        /// <exception cref="statistics.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="include">A comma-separated list of requested metrics. Supported values are:  - &#x60;transactions&#x60; - &#x60;bootstraps_successful&#x60; - &#x60;bootstraps_failed&#x60; - &#x60;bootstraps_pending&#x60; - &#x60;device_server_rest_api_success&#x60; - &#x60;device_server_rest_api_error&#x60; </param>
        /// <param name="start">UTC time/year/date in RFC3339 format. Fetch the data with timestamp greater than or equal to this value. Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207. The parameter is not mandatory, if the period is specified. </param>
        /// <param name="end">UTC time/year/date in RFC3339 format. Fetch the data with timestamp less than this value.Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207.The parameter is not mandatory, if the period is specified. </param>
        /// <param name="period">Period. Fetch the data for the period in days, weeks or hours. Sample values: 2h, 3w, 4d. The parameter is not mandatory, if the start and end time are specified. </param>
        /// <param name="interval">Group data by this interval in days, weeks or hours. Sample values: 2h, 3w, 4d. </param>
        /// <param name="authorization">Bearer {Access Token}. A valid API Gateway access token. The token is validated and the associated account identifier is used to retrieve account-specific statistics. </param>
        /// <returns>SuccessfulResponse</returns>
        SuccessfulResponse V3MetricsGet (string include, string start, string end, string period, string interval, string authorization);

        /// <summary>
        /// Provides account-specific statistics for other cloud services.
        /// </summary>
        /// <remarks>
        /// This REST API is used to get account-specific statistics.
        /// </remarks>
        /// <exception cref="statistics.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="include">A comma-separated list of requested metrics. Supported values are:  - &#x60;transactions&#x60; - &#x60;bootstraps_successful&#x60; - &#x60;bootstraps_failed&#x60; - &#x60;bootstraps_pending&#x60; - &#x60;device_server_rest_api_success&#x60; - &#x60;device_server_rest_api_error&#x60; </param>
        /// <param name="start">UTC time/year/date in RFC3339 format. Fetch the data with timestamp greater than or equal to this value. Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207. The parameter is not mandatory, if the period is specified. </param>
        /// <param name="end">UTC time/year/date in RFC3339 format. Fetch the data with timestamp less than this value.Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207.The parameter is not mandatory, if the period is specified. </param>
        /// <param name="period">Period. Fetch the data for the period in days, weeks or hours. Sample values: 2h, 3w, 4d. The parameter is not mandatory, if the start and end time are specified. </param>
        /// <param name="interval">Group data by this interval in days, weeks or hours. Sample values: 2h, 3w, 4d. </param>
        /// <param name="authorization">Bearer {Access Token}. A valid API Gateway access token. The token is validated and the associated account identifier is used to retrieve account-specific statistics. </param>
        /// <returns>ApiResponse of SuccessfulResponse</returns>
        ApiResponse<SuccessfulResponse> V3MetricsGetWithHttpInfo (string include, string start, string end, string period, string interval, string authorization);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Provides account-specific statistics for other cloud services.
        /// </summary>
        /// <remarks>
        /// This REST API is used to get account-specific statistics.
        /// </remarks>
        /// <exception cref="statistics.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="include">A comma-separated list of requested metrics. Supported values are:  - &#x60;transactions&#x60; - &#x60;bootstraps_successful&#x60; - &#x60;bootstraps_failed&#x60; - &#x60;bootstraps_pending&#x60; - &#x60;device_server_rest_api_success&#x60; - &#x60;device_server_rest_api_error&#x60; </param>
        /// <param name="start">UTC time/year/date in RFC3339 format. Fetch the data with timestamp greater than or equal to this value. Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207. The parameter is not mandatory, if the period is specified. </param>
        /// <param name="end">UTC time/year/date in RFC3339 format. Fetch the data with timestamp less than this value.Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207.The parameter is not mandatory, if the period is specified. </param>
        /// <param name="period">Period. Fetch the data for the period in days, weeks or hours. Sample values: 2h, 3w, 4d. The parameter is not mandatory, if the start and end time are specified. </param>
        /// <param name="interval">Group data by this interval in days, weeks or hours. Sample values: 2h, 3w, 4d. </param>
        /// <param name="authorization">Bearer {Access Token}. A valid API Gateway access token. The token is validated and the associated account identifier is used to retrieve account-specific statistics. </param>
        /// <returns>Task of SuccessfulResponse</returns>
        System.Threading.Tasks.Task<SuccessfulResponse> V3MetricsGetAsync (string include, string start, string end, string period, string interval, string authorization);

        /// <summary>
        /// Provides account-specific statistics for other cloud services.
        /// </summary>
        /// <remarks>
        /// This REST API is used to get account-specific statistics.
        /// </remarks>
        /// <exception cref="statistics.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="include">A comma-separated list of requested metrics. Supported values are:  - &#x60;transactions&#x60; - &#x60;bootstraps_successful&#x60; - &#x60;bootstraps_failed&#x60; - &#x60;bootstraps_pending&#x60; - &#x60;device_server_rest_api_success&#x60; - &#x60;device_server_rest_api_error&#x60; </param>
        /// <param name="start">UTC time/year/date in RFC3339 format. Fetch the data with timestamp greater than or equal to this value. Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207. The parameter is not mandatory, if the period is specified. </param>
        /// <param name="end">UTC time/year/date in RFC3339 format. Fetch the data with timestamp less than this value.Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207.The parameter is not mandatory, if the period is specified. </param>
        /// <param name="period">Period. Fetch the data for the period in days, weeks or hours. Sample values: 2h, 3w, 4d. The parameter is not mandatory, if the start and end time are specified. </param>
        /// <param name="interval">Group data by this interval in days, weeks or hours. Sample values: 2h, 3w, 4d. </param>
        /// <param name="authorization">Bearer {Access Token}. A valid API Gateway access token. The token is validated and the associated account identifier is used to retrieve account-specific statistics. </param>
        /// <returns>Task of ApiResponse (SuccessfulResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<SuccessfulResponse>> V3MetricsGetAsyncWithHttpInfo (string include, string start, string end, string period, string interval, string authorization);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class AccountApi : IAccountApi
    {
        private statistics.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AccountApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            ExceptionFactory = statistics.Client.Configuration.DefaultExceptionFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public AccountApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = statistics.Client.Configuration.DefaultExceptionFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public statistics.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public Dictionary<String, String> DefaultHeader()
        {
            return this.Configuration.DefaultHeader;
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Provides account-specific statistics for other cloud services. This REST API is used to get account-specific statistics.
        /// </summary>
        /// <exception cref="statistics.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="include">A comma-separated list of requested metrics. Supported values are:  - &#x60;transactions&#x60; - &#x60;bootstraps_successful&#x60; - &#x60;bootstraps_failed&#x60; - &#x60;bootstraps_pending&#x60; - &#x60;device_server_rest_api_success&#x60; - &#x60;device_server_rest_api_error&#x60; </param>
        /// <param name="start">UTC time/year/date in RFC3339 format. Fetch the data with timestamp greater than or equal to this value. Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207. The parameter is not mandatory, if the period is specified. </param>
        /// <param name="end">UTC time/year/date in RFC3339 format. Fetch the data with timestamp less than this value.Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207.The parameter is not mandatory, if the period is specified. </param>
        /// <param name="period">Period. Fetch the data for the period in days, weeks or hours. Sample values: 2h, 3w, 4d. The parameter is not mandatory, if the start and end time are specified. </param>
        /// <param name="interval">Group data by this interval in days, weeks or hours. Sample values: 2h, 3w, 4d. </param>
        /// <param name="authorization">Bearer {Access Token}. A valid API Gateway access token. The token is validated and the associated account identifier is used to retrieve account-specific statistics. </param>
        /// <returns>SuccessfulResponse</returns>
        public SuccessfulResponse V3MetricsGet (string include, string start, string end, string period, string interval, string authorization)
        {
             ApiResponse<SuccessfulResponse> localVarResponse = V3MetricsGetWithHttpInfo(include, start, end, period, interval, authorization);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Provides account-specific statistics for other cloud services. This REST API is used to get account-specific statistics.
        /// </summary>
        /// <exception cref="statistics.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="include">A comma-separated list of requested metrics. Supported values are:  - &#x60;transactions&#x60; - &#x60;bootstraps_successful&#x60; - &#x60;bootstraps_failed&#x60; - &#x60;bootstraps_pending&#x60; - &#x60;device_server_rest_api_success&#x60; - &#x60;device_server_rest_api_error&#x60; </param>
        /// <param name="start">UTC time/year/date in RFC3339 format. Fetch the data with timestamp greater than or equal to this value. Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207. The parameter is not mandatory, if the period is specified. </param>
        /// <param name="end">UTC time/year/date in RFC3339 format. Fetch the data with timestamp less than this value.Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207.The parameter is not mandatory, if the period is specified. </param>
        /// <param name="period">Period. Fetch the data for the period in days, weeks or hours. Sample values: 2h, 3w, 4d. The parameter is not mandatory, if the start and end time are specified. </param>
        /// <param name="interval">Group data by this interval in days, weeks or hours. Sample values: 2h, 3w, 4d. </param>
        /// <param name="authorization">Bearer {Access Token}. A valid API Gateway access token. The token is validated and the associated account identifier is used to retrieve account-specific statistics. </param>
        /// <returns>ApiResponse of SuccessfulResponse</returns>
        public ApiResponse< SuccessfulResponse > V3MetricsGetWithHttpInfo (string include, string start, string end, string period, string interval, string authorization)
        {
            // verify the required parameter 'include' is set
            if (include == null)
                throw new ApiException(400, "Missing required parameter 'include' when calling AccountApi->V3MetricsGet");
            // verify the required parameter 'start' is set
            if (start == null)
                throw new ApiException(400, "Missing required parameter 'start' when calling AccountApi->V3MetricsGet");
            // verify the required parameter 'end' is set
            if (end == null)
                throw new ApiException(400, "Missing required parameter 'end' when calling AccountApi->V3MetricsGet");
            // verify the required parameter 'period' is set
            if (period == null)
                throw new ApiException(400, "Missing required parameter 'period' when calling AccountApi->V3MetricsGet");
            // verify the required parameter 'interval' is set
            if (interval == null)
                throw new ApiException(400, "Missing required parameter 'interval' when calling AccountApi->V3MetricsGet");
            // verify the required parameter 'authorization' is set
            if (authorization == null)
                throw new ApiException(400, "Missing required parameter 'authorization' when calling AccountApi->V3MetricsGet");

            var localVarPath = "/v3/metrics";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (include != null) localVarQueryParams.Add("include", Configuration.ApiClient.ParameterToString(include)); // query parameter
            if (start != null) localVarQueryParams.Add("start", Configuration.ApiClient.ParameterToString(start)); // query parameter
            if (end != null) localVarQueryParams.Add("end", Configuration.ApiClient.ParameterToString(end)); // query parameter
            if (period != null) localVarQueryParams.Add("period", Configuration.ApiClient.ParameterToString(period)); // query parameter
            if (interval != null) localVarQueryParams.Add("interval", Configuration.ApiClient.ParameterToString(interval)); // query parameter
            if (authorization != null) localVarHeaderParams.Add("Authorization", Configuration.ApiClient.ParameterToString(authorization)); // header parameter

            // authentication (Bearer) required
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("V3MetricsGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<SuccessfulResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (SuccessfulResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(SuccessfulResponse)));
            
        }

        /// <summary>
        /// Provides account-specific statistics for other cloud services. This REST API is used to get account-specific statistics.
        /// </summary>
        /// <exception cref="statistics.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="include">A comma-separated list of requested metrics. Supported values are:  - &#x60;transactions&#x60; - &#x60;bootstraps_successful&#x60; - &#x60;bootstraps_failed&#x60; - &#x60;bootstraps_pending&#x60; - &#x60;device_server_rest_api_success&#x60; - &#x60;device_server_rest_api_error&#x60; </param>
        /// <param name="start">UTC time/year/date in RFC3339 format. Fetch the data with timestamp greater than or equal to this value. Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207. The parameter is not mandatory, if the period is specified. </param>
        /// <param name="end">UTC time/year/date in RFC3339 format. Fetch the data with timestamp less than this value.Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207.The parameter is not mandatory, if the period is specified. </param>
        /// <param name="period">Period. Fetch the data for the period in days, weeks or hours. Sample values: 2h, 3w, 4d. The parameter is not mandatory, if the start and end time are specified. </param>
        /// <param name="interval">Group data by this interval in days, weeks or hours. Sample values: 2h, 3w, 4d. </param>
        /// <param name="authorization">Bearer {Access Token}. A valid API Gateway access token. The token is validated and the associated account identifier is used to retrieve account-specific statistics. </param>
        /// <returns>Task of SuccessfulResponse</returns>
        public async System.Threading.Tasks.Task<SuccessfulResponse> V3MetricsGetAsync (string include, string start, string end, string period, string interval, string authorization)
        {
             ApiResponse<SuccessfulResponse> localVarResponse = await V3MetricsGetAsyncWithHttpInfo(include, start, end, period, interval, authorization);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Provides account-specific statistics for other cloud services. This REST API is used to get account-specific statistics.
        /// </summary>
        /// <exception cref="statistics.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="include">A comma-separated list of requested metrics. Supported values are:  - &#x60;transactions&#x60; - &#x60;bootstraps_successful&#x60; - &#x60;bootstraps_failed&#x60; - &#x60;bootstraps_pending&#x60; - &#x60;device_server_rest_api_success&#x60; - &#x60;device_server_rest_api_error&#x60; </param>
        /// <param name="start">UTC time/year/date in RFC3339 format. Fetch the data with timestamp greater than or equal to this value. Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207. The parameter is not mandatory, if the period is specified. </param>
        /// <param name="end">UTC time/year/date in RFC3339 format. Fetch the data with timestamp less than this value.Sample values: 20170207T092056990Z/2017-02-07T09:20:56.990Z/2017/20170207.The parameter is not mandatory, if the period is specified. </param>
        /// <param name="period">Period. Fetch the data for the period in days, weeks or hours. Sample values: 2h, 3w, 4d. The parameter is not mandatory, if the start and end time are specified. </param>
        /// <param name="interval">Group data by this interval in days, weeks or hours. Sample values: 2h, 3w, 4d. </param>
        /// <param name="authorization">Bearer {Access Token}. A valid API Gateway access token. The token is validated and the associated account identifier is used to retrieve account-specific statistics. </param>
        /// <returns>Task of ApiResponse (SuccessfulResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<SuccessfulResponse>> V3MetricsGetAsyncWithHttpInfo (string include, string start, string end, string period, string interval, string authorization)
        {
            // verify the required parameter 'include' is set
            if (include == null)
                throw new ApiException(400, "Missing required parameter 'include' when calling AccountApi->V3MetricsGet");
            // verify the required parameter 'start' is set
            if (start == null)
                throw new ApiException(400, "Missing required parameter 'start' when calling AccountApi->V3MetricsGet");
            // verify the required parameter 'end' is set
            if (end == null)
                throw new ApiException(400, "Missing required parameter 'end' when calling AccountApi->V3MetricsGet");
            // verify the required parameter 'period' is set
            if (period == null)
                throw new ApiException(400, "Missing required parameter 'period' when calling AccountApi->V3MetricsGet");
            // verify the required parameter 'interval' is set
            if (interval == null)
                throw new ApiException(400, "Missing required parameter 'interval' when calling AccountApi->V3MetricsGet");
            // verify the required parameter 'authorization' is set
            if (authorization == null)
                throw new ApiException(400, "Missing required parameter 'authorization' when calling AccountApi->V3MetricsGet");

            var localVarPath = "/v3/metrics";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (include != null) localVarQueryParams.Add("include", Configuration.ApiClient.ParameterToString(include)); // query parameter
            if (start != null) localVarQueryParams.Add("start", Configuration.ApiClient.ParameterToString(start)); // query parameter
            if (end != null) localVarQueryParams.Add("end", Configuration.ApiClient.ParameterToString(end)); // query parameter
            if (period != null) localVarQueryParams.Add("period", Configuration.ApiClient.ParameterToString(period)); // query parameter
            if (interval != null) localVarQueryParams.Add("interval", Configuration.ApiClient.ParameterToString(interval)); // query parameter
            if (authorization != null) localVarHeaderParams.Add("Authorization", Configuration.ApiClient.ParameterToString(authorization)); // header parameter

            // authentication (Bearer) required
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("V3MetricsGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<SuccessfulResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (SuccessfulResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(SuccessfulResponse)));
            
        }

    }
}
