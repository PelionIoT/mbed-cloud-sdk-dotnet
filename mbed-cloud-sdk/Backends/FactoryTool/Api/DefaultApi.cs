using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using factory_tool.Client;
using factory_tool.Model;

namespace factory_tool.Api
{
    
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDefaultApi
    {
        #region Synchronous Operations
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a list of downloadable Factory Tool versions.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param>
        /// <returns>InlineResponse200</returns>
        InlineResponse200 DownloadsMbedFactoryProvisioningPackageInfoGet (string authorization);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a list of downloadable Factory Tool versions.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param>
        /// <returns>ApiResponse of InlineResponse200</returns>
        ApiResponse<InlineResponse200> DownloadsMbedFactoryProvisioningPackageInfoGetWithHttpInfo (string authorization);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param>
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param>
        /// <returns></returns>
        void DownloadsMbedFactoryProvisioningPackageososGet (string authorization, string os);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param>
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DownloadsMbedFactoryProvisioningPackageososGetWithHttpInfo (string authorization, string os);
        
        #endregion Synchronous Operations
        
        #region Asynchronous Operations
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a list of downloadable Factory Tool versions.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param>
        /// <returns>Task of InlineResponse200</returns>
        System.Threading.Tasks.Task<InlineResponse200> DownloadsMbedFactoryProvisioningPackageInfoGetAsync (string authorization);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a list of downloadable Factory Tool versions.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param>
        /// <returns>Task of ApiResponse (InlineResponse200)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse200>> DownloadsMbedFactoryProvisioningPackageInfoGetAsyncWithHttpInfo (string authorization);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param>
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DownloadsMbedFactoryProvisioningPackageososGetAsync (string authorization, string os);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param>
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DownloadsMbedFactoryProvisioningPackageososGetAsyncWithHttpInfo (string authorization, string os);
        
        #endregion Asynchronous Operations
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DefaultApi : IDefaultApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DefaultApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public DefaultApi(Configuration configuration = null)
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
        ///  Gets a list of downloadable Factory Tool versions.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </summary>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param> 
        /// <returns>InlineResponse200</returns>
        public InlineResponse200 DownloadsMbedFactoryProvisioningPackageInfoGet (string authorization)
        {
             ApiResponse<InlineResponse200> localVarResponse = DownloadsMbedFactoryProvisioningPackageInfoGetWithHttpInfo(authorization);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  Gets a list of downloadable Factory Tool versions.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </summary>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param> 
        /// <returns>ApiResponse of InlineResponse200</returns>
        public ApiResponse< InlineResponse200 > DownloadsMbedFactoryProvisioningPackageInfoGetWithHttpInfo (string authorization)
        {
            
            // verify the required parameter 'authorization' is set
            if (authorization == null)
                throw new ApiException(400, "Missing required parameter 'authorization' when calling DefaultApi->DownloadsMbedFactoryProvisioningPackageInfoGet");
            
    
            var localVarPath = "/downloads/mbed_factory_provisioning_package/info";
    
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
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            
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
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DownloadsMbedFactoryProvisioningPackageInfoGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DownloadsMbedFactoryProvisioningPackageInfoGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<InlineResponse200>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (InlineResponse200) Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse200)));
            
        }

        
        /// <summary>
        ///  Gets a list of downloadable Factory Tool versions.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </summary>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param>
        /// <returns>Task of InlineResponse200</returns>
        public async System.Threading.Tasks.Task<InlineResponse200> DownloadsMbedFactoryProvisioningPackageInfoGetAsync (string authorization)
        {
             ApiResponse<InlineResponse200> localVarResponse = await DownloadsMbedFactoryProvisioningPackageInfoGetAsyncWithHttpInfo(authorization);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  Gets a list of downloadable Factory Tool versions.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </summary>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param>
        /// <returns>Task of ApiResponse (InlineResponse200)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse200>> DownloadsMbedFactoryProvisioningPackageInfoGetAsyncWithHttpInfo (string authorization)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null) throw new ApiException(400, "Missing required parameter 'authorization' when calling DownloadsMbedFactoryProvisioningPackageInfoGet");
            
    
            var localVarPath = "/downloads/mbed_factory_provisioning_package/info";
    
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
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            
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
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DownloadsMbedFactoryProvisioningPackageInfoGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DownloadsMbedFactoryProvisioningPackageInfoGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<InlineResponse200>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (InlineResponse200) Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse200)));
            
        }
        
        /// <summary>
        ///  Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </summary>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param> 
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param> 
        /// <returns></returns>
        public void DownloadsMbedFactoryProvisioningPackageososGet (string authorization, string os)
        {
             DownloadsMbedFactoryProvisioningPackageososGetWithHttpInfo(authorization, os);
        }

        /// <summary>
        ///  Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </summary>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param> 
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param> 
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> DownloadsMbedFactoryProvisioningPackageososGetWithHttpInfo (string authorization, string os)
        {
            
            // verify the required parameter 'authorization' is set
            if (authorization == null)
                throw new ApiException(400, "Missing required parameter 'authorization' when calling DefaultApi->DownloadsMbedFactoryProvisioningPackageososGet");
            
            // verify the required parameter 'os' is set
            if (os == null)
                throw new ApiException(400, "Missing required parameter 'os' when calling DefaultApi->DownloadsMbedFactoryProvisioningPackageososGet");
            
    
            var localVarPath = "/downloads/mbed_factory_provisioning_package?os={os}";
    
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
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (os != null) localVarPathParams.Add("os", Configuration.ApiClient.ParameterToString(os)); // path parameter
            
            
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
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DownloadsMbedFactoryProvisioningPackageososGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DownloadsMbedFactoryProvisioningPackageososGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        
        /// <summary>
        ///  Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </summary>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param>
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DownloadsMbedFactoryProvisioningPackageososGetAsync (string authorization, string os)
        {
             await DownloadsMbedFactoryProvisioningPackageososGetAsyncWithHttpInfo(authorization, os);

        }

        /// <summary>
        ///  Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </summary>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by a reference token (API key forbidden).</param>
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> DownloadsMbedFactoryProvisioningPackageososGetAsyncWithHttpInfo (string authorization, string os)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null) throw new ApiException(400, "Missing required parameter 'authorization' when calling DownloadsMbedFactoryProvisioningPackageososGet");
            // verify the required parameter 'os' is set
            if (os == null) throw new ApiException(400, "Missing required parameter 'os' when calling DownloadsMbedFactoryProvisioningPackageososGet");
            
    
            var localVarPath = "/downloads/mbed_factory_provisioning_package?os={os}";
    
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
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (os != null) localVarPathParams.Add("os", Configuration.ApiClient.ParameterToString(os)); // path parameter
            
            
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
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DownloadsMbedFactoryProvisioningPackageososGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DownloadsMbedFactoryProvisioningPackageososGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        
    }
    
}
