using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using provisioning_certificate.Client;
using provisioning_certificate.Model;

namespace provisioning_certificate.Api
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
        /// Gets the account&#39;s provisioning certificate.
        /// </remarks>
        /// <exception cref="provisioning_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>ProvisioningCertificate</returns>
        ProvisioningCertificate V3ProvisioningCertificateGet (string authorization);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets the account&#39;s provisioning certificate.
        /// </remarks>
        /// <exception cref="provisioning_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>ApiResponse of ProvisioningCertificate</returns>
        ApiResponse<ProvisioningCertificate> V3ProvisioningCertificateGetWithHttpInfo (string authorization);
        
        #endregion Synchronous Operations
        
        #region Asynchronous Operations
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets the account&#39;s provisioning certificate.
        /// </remarks>
        /// <exception cref="provisioning_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of ProvisioningCertificate</returns>
        System.Threading.Tasks.Task<ProvisioningCertificate> V3ProvisioningCertificateGetAsync (string authorization);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets the account&#39;s provisioning certificate.
        /// </remarks>
        /// <exception cref="provisioning_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of ApiResponse (ProvisioningCertificate)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProvisioningCertificate>> V3ProvisioningCertificateGetAsyncWithHttpInfo (string authorization);
        
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
        ///  Gets the account&#39;s provisioning certificate.
        /// </summary>
        /// <exception cref="provisioning_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <returns>ProvisioningCertificate</returns>
        public ProvisioningCertificate V3ProvisioningCertificateGet (string authorization)
        {
             ApiResponse<ProvisioningCertificate> localVarResponse = V3ProvisioningCertificateGetWithHttpInfo(authorization);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  Gets the account&#39;s provisioning certificate.
        /// </summary>
        /// <exception cref="provisioning_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <returns>ApiResponse of ProvisioningCertificate</returns>
        public ApiResponse< ProvisioningCertificate > V3ProvisioningCertificateGetWithHttpInfo (string authorization)
        {
            
            // verify the required parameter 'authorization' is set
            if (authorization == null)
                throw new ApiException(400, "Missing required parameter 'authorization' when calling DefaultApi->V3ProvisioningCertificateGet");
            
    
            var localVarPath = "/v3/provisioning-certificate";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V3ProvisioningCertificateGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3ProvisioningCertificateGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<ProvisioningCertificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProvisioningCertificate) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProvisioningCertificate)));
            
        }

        
        /// <summary>
        ///  Gets the account&#39;s provisioning certificate.
        /// </summary>
        /// <exception cref="provisioning_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of ProvisioningCertificate</returns>
        public async System.Threading.Tasks.Task<ProvisioningCertificate> V3ProvisioningCertificateGetAsync (string authorization)
        {
             ApiResponse<ProvisioningCertificate> localVarResponse = await V3ProvisioningCertificateGetAsyncWithHttpInfo(authorization);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  Gets the account&#39;s provisioning certificate.
        /// </summary>
        /// <exception cref="provisioning_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of ApiResponse (ProvisioningCertificate)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ProvisioningCertificate>> V3ProvisioningCertificateGetAsyncWithHttpInfo (string authorization)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null) throw new ApiException(400, "Missing required parameter 'authorization' when calling V3ProvisioningCertificateGet");
            
    
            var localVarPath = "/v3/provisioning-certificate";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V3ProvisioningCertificateGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3ProvisioningCertificateGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<ProvisioningCertificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProvisioningCertificate) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProvisioningCertificate)));
            
        }
        
    }
    
}
