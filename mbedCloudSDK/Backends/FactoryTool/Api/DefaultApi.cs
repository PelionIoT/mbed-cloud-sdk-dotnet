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
        /// Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param>
        /// <returns>byte[]</returns>
        byte[] DownloadsMbedFactoryProvisioningPackageGet (string os);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param>
        /// <returns>ApiResponse of byte[]</returns>
        ApiResponse<byte[]> DownloadsMbedFactoryProvisioningPackageGetWithHttpInfo (string os);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a list of downloadable Factory Tool versions.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>InlineResponse200</returns>
        InlineResponse200 DownloadsMbedFactoryProvisioningPackageInfoGet ();
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a list of downloadable Factory Tool versions.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of InlineResponse200</returns>
        ApiResponse<InlineResponse200> DownloadsMbedFactoryProvisioningPackageInfoGetWithHttpInfo ();
        
        #endregion Synchronous Operations
        
        #region Asynchronous Operations
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param>
        /// <returns>Task of byte[]</returns>
        System.Threading.Tasks.Task<byte[]> DownloadsMbedFactoryProvisioningPackageGetAsync (string os);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param>
        /// <returns>Task of ApiResponse (byte[])</returns>
        System.Threading.Tasks.Task<ApiResponse<byte[]>> DownloadsMbedFactoryProvisioningPackageGetAsyncWithHttpInfo (string os);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a list of downloadable Factory Tool versions.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of InlineResponse200</returns>
        System.Threading.Tasks.Task<InlineResponse200> DownloadsMbedFactoryProvisioningPackageInfoGetAsync ();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a list of downloadable Factory Tool versions.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </remarks>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (InlineResponse200)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse200>> DownloadsMbedFactoryProvisioningPackageInfoGetAsyncWithHttpInfo ();
        
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
        ///  Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </summary>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param> 
        /// <returns>byte[]</returns>
        public byte[] DownloadsMbedFactoryProvisioningPackageGet (string os)
        {
             ApiResponse<byte[]> localVarResponse = DownloadsMbedFactoryProvisioningPackageGetWithHttpInfo(os);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </summary>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param> 
        /// <returns>ApiResponse of byte[]</returns>
        public ApiResponse< byte[] > DownloadsMbedFactoryProvisioningPackageGetWithHttpInfo (string os)
        {
            
            // verify the required parameter 'os' is set
            if (os == null)
                throw new ApiException(400, "Missing required parameter 'os' when calling DefaultApi->DownloadsMbedFactoryProvisioningPackageGet");
            
    
            var localVarPath = "/downloads/mbed_factory_provisioning_package";
    
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
            
            if (os != null) localVarQueryParams.Add("os", Configuration.ApiClient.ParameterToString(os)); // query parameter
            
            
            
            

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
                throw new ApiException (localVarStatusCode, "Error calling DownloadsMbedFactoryProvisioningPackageGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DownloadsMbedFactoryProvisioningPackageGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<byte[]>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (byte[]) Configuration.ApiClient.Deserialize(localVarResponse, typeof(byte[])));
            
        }

        
        /// <summary>
        ///  Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </summary>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param>
        /// <returns>Task of byte[]</returns>
        public async System.Threading.Tasks.Task<byte[]> DownloadsMbedFactoryProvisioningPackageGetAsync (string os)
        {
             ApiResponse<byte[]> localVarResponse = await DownloadsMbedFactoryProvisioningPackageGetAsyncWithHttpInfo(os);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  Returns a specific Factory Tool package in a ZIP archive.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </summary>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="os">Requires Factory Tool OS name (Windows or Linux).</param>
        /// <returns>Task of ApiResponse (byte[])</returns>
        public async System.Threading.Tasks.Task<ApiResponse<byte[]>> DownloadsMbedFactoryProvisioningPackageGetAsyncWithHttpInfo (string os)
        {
            // verify the required parameter 'os' is set
            if (os == null) throw new ApiException(400, "Missing required parameter 'os' when calling DownloadsMbedFactoryProvisioningPackageGet");
            
    
            var localVarPath = "/downloads/mbed_factory_provisioning_package";
    
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
            
            if (os != null) localVarQueryParams.Add("os", Configuration.ApiClient.ParameterToString(os)); // query parameter
            
            
            
            

            
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
                throw new ApiException (localVarStatusCode, "Error calling DownloadsMbedFactoryProvisioningPackageGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DownloadsMbedFactoryProvisioningPackageGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<byte[]>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (byte[]) Configuration.ApiClient.Deserialize(localVarResponse, typeof(byte[])));
            
        }
        
        /// <summary>
        ///  Gets a list of downloadable Factory Tool versions.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </summary>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>InlineResponse200</returns>
        public InlineResponse200 DownloadsMbedFactoryProvisioningPackageInfoGet ()
        {
             ApiResponse<InlineResponse200> localVarResponse = DownloadsMbedFactoryProvisioningPackageInfoGetWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        ///  Gets a list of downloadable Factory Tool versions.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </summary>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of InlineResponse200</returns>
        public ApiResponse< InlineResponse200 > DownloadsMbedFactoryProvisioningPackageInfoGetWithHttpInfo ()
        {
            
    
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
        /// <returns>Task of InlineResponse200</returns>
        public async System.Threading.Tasks.Task<InlineResponse200> DownloadsMbedFactoryProvisioningPackageInfoGetAsync ()
        {
             ApiResponse<InlineResponse200> localVarResponse = await DownloadsMbedFactoryProvisioningPackageInfoGetAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        ///  Gets a list of downloadable Factory Tool versions.\n* mbed Cloud user role must be Administrator.\n* mbed Cloud account must have Factory Tool downloads enabled.\n
        /// </summary>
        /// <exception cref="factory_tool.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (InlineResponse200)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse200>> DownloadsMbedFactoryProvisioningPackageInfoGetAsyncWithHttpInfo ()
        {
            
    
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
        
    }
    
}
