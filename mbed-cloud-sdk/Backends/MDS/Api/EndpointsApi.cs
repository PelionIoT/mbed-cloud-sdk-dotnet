using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using mds.Client;
using mds.Model;

namespace mds.Api
{
    
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IEndpointsApi
    {
        #region Synchronous Operations
        
        /// <summary>
        /// List the resources on an endpoint
        /// </summary>
        /// <remarks>
        /// The list of resources is cached by mbed Cloud Connect, so this call does \nnot create a message to the device.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for an endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param>
        /// <returns>List&lt;Resource&gt;</returns>
        List<Resource> V2EndpointsEndpointNameGet (string endpointName);
  
        /// <summary>
        /// List the resources on an endpoint
        /// </summary>
        /// <remarks>
        /// The list of resources is cached by mbed Cloud Connect, so this call does \nnot create a message to the device.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for an endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param>
        /// <returns>ApiResponse of List&lt;Resource&gt;</returns>
        ApiResponse<List<Resource>> V2EndpointsEndpointNameGetWithHttpInfo (string endpointName);
        
        /// <summary>
        /// List all endpoints
        /// </summary>
        /// <remarks>
        /// Endpoints are physical devices running mbed Cloud Client.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="type">Filter endpoints by endpoint-type. (optional)</param>
        /// <returns>List&lt;Endpoint&gt;</returns>
        List<Endpoint> V2EndpointsGet (string type = null);
  
        /// <summary>
        /// List all endpoints
        /// </summary>
        /// <remarks>
        /// Endpoints are physical devices running mbed Cloud Client.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="type">Filter endpoints by endpoint-type. (optional)</param>
        /// <returns>ApiResponse of List&lt;Endpoint&gt;</returns>
        ApiResponse<List<Endpoint>> V2EndpointsGetWithHttpInfo (string type = null);
        
        #endregion Synchronous Operations
        
        #region Asynchronous Operations
        
        /// <summary>
        /// List the resources on an endpoint
        /// </summary>
        /// <remarks>
        /// The list of resources is cached by mbed Cloud Connect, so this call does \nnot create a message to the device.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for an endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param>
        /// <returns>Task of List&lt;Resource&gt;</returns>
        System.Threading.Tasks.Task<List<Resource>> V2EndpointsEndpointNameGetAsync (string endpointName);

        /// <summary>
        /// List the resources on an endpoint
        /// </summary>
        /// <remarks>
        /// The list of resources is cached by mbed Cloud Connect, so this call does \nnot create a message to the device.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for an endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param>
        /// <returns>Task of ApiResponse (List&lt;Resource&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Resource>>> V2EndpointsEndpointNameGetAsyncWithHttpInfo (string endpointName);
        
        /// <summary>
        /// List all endpoints
        /// </summary>
        /// <remarks>
        /// Endpoints are physical devices running mbed Cloud Client.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="type">Filter endpoints by endpoint-type. (optional)</param>
        /// <returns>Task of List&lt;Endpoint&gt;</returns>
        System.Threading.Tasks.Task<List<Endpoint>> V2EndpointsGetAsync (string type = null);

        /// <summary>
        /// List all endpoints
        /// </summary>
        /// <remarks>
        /// Endpoints are physical devices running mbed Cloud Client.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="type">Filter endpoints by endpoint-type. (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;Endpoint&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Endpoint>>> V2EndpointsGetAsyncWithHttpInfo (string type = null);
        
        #endregion Asynchronous Operations
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class EndpointsApi : IEndpointsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public EndpointsApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public EndpointsApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default; 
            else
                this.Configuration = configuration;

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
        [Obsolete("SetBasePath is deprecated, please do 'Configuraiton.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
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
        /// List the resources on an endpoint The list of resources is cached by mbed Cloud Connect, so this call does \nnot create a message to the device.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for an endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <returns>List&lt;Resource&gt;</returns>
        public List<Resource> V2EndpointsEndpointNameGet (string endpointName)
        {
             ApiResponse<List<Resource>> localVarResponse = V2EndpointsEndpointNameGetWithHttpInfo(endpointName);
             return localVarResponse.Data;
        }

        /// <summary>
        /// List the resources on an endpoint The list of resources is cached by mbed Cloud Connect, so this call does \nnot create a message to the device.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for an endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <returns>ApiResponse of List&lt;Resource&gt;</returns>
        public ApiResponse< List<Resource> > V2EndpointsEndpointNameGetWithHttpInfo (string endpointName)
        {
            
            // verify the required parameter 'endpointName' is set
            if (endpointName == null)
                throw new ApiException(400, "Missing required parameter 'endpointName' when calling EndpointsApi->V2EndpointsEndpointNameGet");
            
    
            var localVarPath = "/v2/endpoints/{endpointName}";
    
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
                "application/json", "application/link-format"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (endpointName != null) localVarPathParams.Add("endpointName", Configuration.ApiClient.ParameterToString(endpointName)); // path parameter
            
            
            
            
            

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
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<List<Resource>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Resource>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Resource>)));
            
        }

        
        /// <summary>
        /// List the resources on an endpoint The list of resources is cached by mbed Cloud Connect, so this call does \nnot create a message to the device.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for an endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param>
        /// <returns>Task of List&lt;Resource&gt;</returns>
        public async System.Threading.Tasks.Task<List<Resource>> V2EndpointsEndpointNameGetAsync (string endpointName)
        {
             ApiResponse<List<Resource>> localVarResponse = await V2EndpointsEndpointNameGetAsyncWithHttpInfo(endpointName);
             return localVarResponse.Data;

        }

        /// <summary>
        /// List the resources on an endpoint The list of resources is cached by mbed Cloud Connect, so this call does \nnot create a message to the device.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for an endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param>
        /// <returns>Task of ApiResponse (List&lt;Resource&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Resource>>> V2EndpointsEndpointNameGetAsyncWithHttpInfo (string endpointName)
        {
            // verify the required parameter 'endpointName' is set
            if (endpointName == null) throw new ApiException(400, "Missing required parameter 'endpointName' when calling V2EndpointsEndpointNameGet");
            
    
            var localVarPath = "/v2/endpoints/{endpointName}";
    
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
                "application/json", "application/link-format"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (endpointName != null) localVarPathParams.Add("endpointName", Configuration.ApiClient.ParameterToString(endpointName)); // path parameter
            
            
            
            
            

            
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
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<Resource>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Resource>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Resource>)));
            
        }
        
        /// <summary>
        /// List all endpoints Endpoints are physical devices running mbed Cloud Client.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="type">Filter endpoints by endpoint-type. (optional)</param> 
        /// <returns>List&lt;Endpoint&gt;</returns>
        public List<Endpoint> V2EndpointsGet (string type = null)
        {
             ApiResponse<List<Endpoint>> localVarResponse = V2EndpointsGetWithHttpInfo(type);
             return localVarResponse.Data;
        }

        /// <summary>
        /// List all endpoints Endpoints are physical devices running mbed Cloud Client.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="type">Filter endpoints by endpoint-type. (optional)</param> 
        /// <returns>ApiResponse of List&lt;Endpoint&gt;</returns>
        public ApiResponse< List<Endpoint> > V2EndpointsGetWithHttpInfo (string type = null)
        {
            
    
            var localVarPath = "/v2/endpoints";
    
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
                "application/json", "application/link-format"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            if (type != null) localVarQueryParams.Add("type", Configuration.ApiClient.ParameterToString(type)); // query parameter
            
            
            
            

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
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<List<Endpoint>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Endpoint>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Endpoint>)));
            
        }

        
        /// <summary>
        /// List all endpoints Endpoints are physical devices running mbed Cloud Client.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="type">Filter endpoints by endpoint-type. (optional)</param>
        /// <returns>Task of List&lt;Endpoint&gt;</returns>
        public async System.Threading.Tasks.Task<List<Endpoint>> V2EndpointsGetAsync (string type = null)
        {
             ApiResponse<List<Endpoint>> localVarResponse = await V2EndpointsGetAsyncWithHttpInfo(type);
             return localVarResponse.Data;

        }

        /// <summary>
        /// List all endpoints Endpoints are physical devices running mbed Cloud Client.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="type">Filter endpoints by endpoint-type. (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;Endpoint&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Endpoint>>> V2EndpointsGetAsyncWithHttpInfo (string type = null)
        {
            
    
            var localVarPath = "/v2/endpoints";
    
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
                "application/json", "application/link-format"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            if (type != null) localVarQueryParams.Add("type", Configuration.ApiClient.ParameterToString(type)); // query parameter
            
            
            
            

            
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
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<Endpoint>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Endpoint>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Endpoint>)));
            
        }
        
    }
    
}
