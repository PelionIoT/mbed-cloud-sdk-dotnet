using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using production_line_certificates.Client;
using production_line_certificates.Model;

namespace production_line_certificates.Api
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
        /// Gets the list of production line certificates associated with the account.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>InlineResponse200</returns>
        InlineResponse200 V3ProductionLineCertificatesGet (string authorization);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets the list of production line certificates associated with the account.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>ApiResponse of InlineResponse200</returns>
        ApiResponse<InlineResponse200> V3ProductionLineCertificatesGetWithHttpInfo (string authorization);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Deactivates the production line certificate.\n\nThere is no way to reactivate it.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID</param>
        /// <returns>ProductionLineCertificate</returns>
        ProductionLineCertificate V3ProductionLineCertificatesMUUIDDelete (string authorization, string mUUID);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Deactivates the production line certificate.\n\nThere is no way to reactivate it.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID</param>
        /// <returns>ApiResponse of ProductionLineCertificate</returns>
        ApiResponse<ProductionLineCertificate> V3ProductionLineCertificatesMUUIDDeleteWithHttpInfo (string authorization, string mUUID);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a single production line certificate by its mUUID.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID.</param>
        /// <returns>ProductionLineCertificate</returns>
        ProductionLineCertificate V3ProductionLineCertificatesMUUIDGet (string authorization, string mUUID);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a single production line certificate by its mUUID.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID.</param>
        /// <returns>ApiResponse of ProductionLineCertificate</returns>
        ApiResponse<ProductionLineCertificate> V3ProductionLineCertificatesMUUIDGetWithHttpInfo (string authorization, string mUUID);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Updates the comment on a production line certificate.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID</param>
        /// <param name="body"></param>
        /// <returns>ProductionLineCertificate</returns>
        ProductionLineCertificate V3ProductionLineCertificatesMUUIDPut (string authorization, string mUUID, Body1 body);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Updates the comment on a production line certificate.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID</param>
        /// <param name="body"></param>
        /// <returns>ApiResponse of ProductionLineCertificate</returns>
        ApiResponse<ProductionLineCertificate> V3ProductionLineCertificatesMUUIDPutWithHttpInfo (string authorization, string mUUID, Body1 body);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Adds a new production line certificate to the account.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="body"></param>
        /// <returns>ProductionLineCertificate</returns>
        ProductionLineCertificate V3ProductionLineCertificatesPost (string authorization, Body body);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Adds a new production line certificate to the account.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="body"></param>
        /// <returns>ApiResponse of ProductionLineCertificate</returns>
        ApiResponse<ProductionLineCertificate> V3ProductionLineCertificatesPostWithHttpInfo (string authorization, Body body);
        
        #endregion Synchronous Operations
        
        #region Asynchronous Operations
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets the list of production line certificates associated with the account.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of InlineResponse200</returns>
        System.Threading.Tasks.Task<InlineResponse200> V3ProductionLineCertificatesGetAsync (string authorization);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets the list of production line certificates associated with the account.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of ApiResponse (InlineResponse200)</returns>
        System.Threading.Tasks.Task<ApiResponse<InlineResponse200>> V3ProductionLineCertificatesGetAsyncWithHttpInfo (string authorization);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Deactivates the production line certificate.\n\nThere is no way to reactivate it.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID</param>
        /// <returns>Task of ProductionLineCertificate</returns>
        System.Threading.Tasks.Task<ProductionLineCertificate> V3ProductionLineCertificatesMUUIDDeleteAsync (string authorization, string mUUID);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Deactivates the production line certificate.\n\nThere is no way to reactivate it.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID</param>
        /// <returns>Task of ApiResponse (ProductionLineCertificate)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProductionLineCertificate>> V3ProductionLineCertificatesMUUIDDeleteAsyncWithHttpInfo (string authorization, string mUUID);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a single production line certificate by its mUUID.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID.</param>
        /// <returns>Task of ProductionLineCertificate</returns>
        System.Threading.Tasks.Task<ProductionLineCertificate> V3ProductionLineCertificatesMUUIDGetAsync (string authorization, string mUUID);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a single production line certificate by its mUUID.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID.</param>
        /// <returns>Task of ApiResponse (ProductionLineCertificate)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProductionLineCertificate>> V3ProductionLineCertificatesMUUIDGetAsyncWithHttpInfo (string authorization, string mUUID);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Updates the comment on a production line certificate.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID</param>
        /// <param name="body"></param>
        /// <returns>Task of ProductionLineCertificate</returns>
        System.Threading.Tasks.Task<ProductionLineCertificate> V3ProductionLineCertificatesMUUIDPutAsync (string authorization, string mUUID, Body1 body);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Updates the comment on a production line certificate.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID</param>
        /// <param name="body"></param>
        /// <returns>Task of ApiResponse (ProductionLineCertificate)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProductionLineCertificate>> V3ProductionLineCertificatesMUUIDPutAsyncWithHttpInfo (string authorization, string mUUID, Body1 body);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Adds a new production line certificate to the account.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="body"></param>
        /// <returns>Task of ProductionLineCertificate</returns>
        System.Threading.Tasks.Task<ProductionLineCertificate> V3ProductionLineCertificatesPostAsync (string authorization, Body body);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Adds a new production line certificate to the account.\n
        /// </remarks>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="body"></param>
        /// <returns>Task of ApiResponse (ProductionLineCertificate)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProductionLineCertificate>> V3ProductionLineCertificatesPostAsyncWithHttpInfo (string authorization, Body body);
        
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
        ///  Gets the list of production line certificates associated with the account.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <returns>InlineResponse200</returns>
        public InlineResponse200 V3ProductionLineCertificatesGet (string authorization)
        {
             ApiResponse<InlineResponse200> localVarResponse = V3ProductionLineCertificatesGetWithHttpInfo(authorization);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  Gets the list of production line certificates associated with the account.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <returns>ApiResponse of InlineResponse200</returns>
        public ApiResponse< InlineResponse200 > V3ProductionLineCertificatesGetWithHttpInfo (string authorization)
        {
            
            // verify the required parameter 'authorization' is set
            if (authorization == null)
                throw new ApiException(400, "Missing required parameter 'authorization' when calling DefaultApi->V3ProductionLineCertificatesGet");
            
    
            var localVarPath = "/v3/production-line-certificates";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<InlineResponse200>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (InlineResponse200) Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse200)));
            
        }

        
        /// <summary>
        ///  Gets the list of production line certificates associated with the account.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of InlineResponse200</returns>
        public async System.Threading.Tasks.Task<InlineResponse200> V3ProductionLineCertificatesGetAsync (string authorization)
        {
             ApiResponse<InlineResponse200> localVarResponse = await V3ProductionLineCertificatesGetAsyncWithHttpInfo(authorization);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  Gets the list of production line certificates associated with the account.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of ApiResponse (InlineResponse200)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<InlineResponse200>> V3ProductionLineCertificatesGetAsyncWithHttpInfo (string authorization)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null) throw new ApiException(400, "Missing required parameter 'authorization' when calling V3ProductionLineCertificatesGet");
            
    
            var localVarPath = "/v3/production-line-certificates";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<InlineResponse200>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (InlineResponse200) Configuration.ApiClient.Deserialize(localVarResponse, typeof(InlineResponse200)));
            
        }
        
        /// <summary>
        ///  Deactivates the production line certificate.\n\nThere is no way to reactivate it.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <param name="mUUID">Certificate mUUID</param> 
        /// <returns>ProductionLineCertificate</returns>
        public ProductionLineCertificate V3ProductionLineCertificatesMUUIDDelete (string authorization, string mUUID)
        {
             ApiResponse<ProductionLineCertificate> localVarResponse = V3ProductionLineCertificatesMUUIDDeleteWithHttpInfo(authorization, mUUID);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  Deactivates the production line certificate.\n\nThere is no way to reactivate it.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <param name="mUUID">Certificate mUUID</param> 
        /// <returns>ApiResponse of ProductionLineCertificate</returns>
        public ApiResponse< ProductionLineCertificate > V3ProductionLineCertificatesMUUIDDeleteWithHttpInfo (string authorization, string mUUID)
        {
            
            // verify the required parameter 'authorization' is set
            if (authorization == null)
                throw new ApiException(400, "Missing required parameter 'authorization' when calling DefaultApi->V3ProductionLineCertificatesMUUIDDelete");
            
            // verify the required parameter 'mUUID' is set
            if (mUUID == null)
                throw new ApiException(400, "Missing required parameter 'mUUID' when calling DefaultApi->V3ProductionLineCertificatesMUUIDDelete");
            
    
            var localVarPath = "/v3/production-line-certificates/{mUUID}";
    
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
            if (mUUID != null) localVarPathParams.Add("mUUID", Configuration.ApiClient.ParameterToString(mUUID)); // path parameter
            
            
            if (authorization != null) localVarHeaderParams.Add("Authorization", Configuration.ApiClient.ParameterToString(authorization)); // header parameter
            
            
            

            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesMUUIDDelete: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesMUUIDDelete: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<ProductionLineCertificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProductionLineCertificate) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProductionLineCertificate)));
            
        }

        
        /// <summary>
        ///  Deactivates the production line certificate.\n\nThere is no way to reactivate it.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID</param>
        /// <returns>Task of ProductionLineCertificate</returns>
        public async System.Threading.Tasks.Task<ProductionLineCertificate> V3ProductionLineCertificatesMUUIDDeleteAsync (string authorization, string mUUID)
        {
             ApiResponse<ProductionLineCertificate> localVarResponse = await V3ProductionLineCertificatesMUUIDDeleteAsyncWithHttpInfo(authorization, mUUID);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  Deactivates the production line certificate.\n\nThere is no way to reactivate it.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID</param>
        /// <returns>Task of ApiResponse (ProductionLineCertificate)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ProductionLineCertificate>> V3ProductionLineCertificatesMUUIDDeleteAsyncWithHttpInfo (string authorization, string mUUID)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null) throw new ApiException(400, "Missing required parameter 'authorization' when calling V3ProductionLineCertificatesMUUIDDelete");
            // verify the required parameter 'mUUID' is set
            if (mUUID == null) throw new ApiException(400, "Missing required parameter 'mUUID' when calling V3ProductionLineCertificatesMUUIDDelete");
            
    
            var localVarPath = "/v3/production-line-certificates/{mUUID}";
    
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
            if (mUUID != null) localVarPathParams.Add("mUUID", Configuration.ApiClient.ParameterToString(mUUID)); // path parameter
            
            
            if (authorization != null) localVarHeaderParams.Add("Authorization", Configuration.ApiClient.ParameterToString(authorization)); // header parameter
            
            
            

            
            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesMUUIDDelete: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesMUUIDDelete: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<ProductionLineCertificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProductionLineCertificate) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProductionLineCertificate)));
            
        }
        
        /// <summary>
        ///  Gets a single production line certificate by its mUUID.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <param name="mUUID">Certificate mUUID.</param> 
        /// <returns>ProductionLineCertificate</returns>
        public ProductionLineCertificate V3ProductionLineCertificatesMUUIDGet (string authorization, string mUUID)
        {
             ApiResponse<ProductionLineCertificate> localVarResponse = V3ProductionLineCertificatesMUUIDGetWithHttpInfo(authorization, mUUID);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  Gets a single production line certificate by its mUUID.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <param name="mUUID">Certificate mUUID.</param> 
        /// <returns>ApiResponse of ProductionLineCertificate</returns>
        public ApiResponse< ProductionLineCertificate > V3ProductionLineCertificatesMUUIDGetWithHttpInfo (string authorization, string mUUID)
        {
            
            // verify the required parameter 'authorization' is set
            if (authorization == null)
                throw new ApiException(400, "Missing required parameter 'authorization' when calling DefaultApi->V3ProductionLineCertificatesMUUIDGet");
            
            // verify the required parameter 'mUUID' is set
            if (mUUID == null)
                throw new ApiException(400, "Missing required parameter 'mUUID' when calling DefaultApi->V3ProductionLineCertificatesMUUIDGet");
            
    
            var localVarPath = "/v3/production-line-certificates/{mUUID}";
    
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
            if (mUUID != null) localVarPathParams.Add("mUUID", Configuration.ApiClient.ParameterToString(mUUID)); // path parameter
            
            
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
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesMUUIDGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesMUUIDGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<ProductionLineCertificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProductionLineCertificate) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProductionLineCertificate)));
            
        }

        
        /// <summary>
        ///  Gets a single production line certificate by its mUUID.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID.</param>
        /// <returns>Task of ProductionLineCertificate</returns>
        public async System.Threading.Tasks.Task<ProductionLineCertificate> V3ProductionLineCertificatesMUUIDGetAsync (string authorization, string mUUID)
        {
             ApiResponse<ProductionLineCertificate> localVarResponse = await V3ProductionLineCertificatesMUUIDGetAsyncWithHttpInfo(authorization, mUUID);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  Gets a single production line certificate by its mUUID.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID.</param>
        /// <returns>Task of ApiResponse (ProductionLineCertificate)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ProductionLineCertificate>> V3ProductionLineCertificatesMUUIDGetAsyncWithHttpInfo (string authorization, string mUUID)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null) throw new ApiException(400, "Missing required parameter 'authorization' when calling V3ProductionLineCertificatesMUUIDGet");
            // verify the required parameter 'mUUID' is set
            if (mUUID == null) throw new ApiException(400, "Missing required parameter 'mUUID' when calling V3ProductionLineCertificatesMUUIDGet");
            
    
            var localVarPath = "/v3/production-line-certificates/{mUUID}";
    
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
            if (mUUID != null) localVarPathParams.Add("mUUID", Configuration.ApiClient.ParameterToString(mUUID)); // path parameter
            
            
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
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesMUUIDGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesMUUIDGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<ProductionLineCertificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProductionLineCertificate) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProductionLineCertificate)));
            
        }
        
        /// <summary>
        ///  Updates the comment on a production line certificate.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <param name="mUUID">Certificate mUUID</param> 
        /// <param name="body"></param> 
        /// <returns>ProductionLineCertificate</returns>
        public ProductionLineCertificate V3ProductionLineCertificatesMUUIDPut (string authorization, string mUUID, Body1 body)
        {
             ApiResponse<ProductionLineCertificate> localVarResponse = V3ProductionLineCertificatesMUUIDPutWithHttpInfo(authorization, mUUID, body);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  Updates the comment on a production line certificate.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <param name="mUUID">Certificate mUUID</param> 
        /// <param name="body"></param> 
        /// <returns>ApiResponse of ProductionLineCertificate</returns>
        public ApiResponse< ProductionLineCertificate > V3ProductionLineCertificatesMUUIDPutWithHttpInfo (string authorization, string mUUID, Body1 body)
        {
            
            // verify the required parameter 'authorization' is set
            if (authorization == null)
                throw new ApiException(400, "Missing required parameter 'authorization' when calling DefaultApi->V3ProductionLineCertificatesMUUIDPut");
            
            // verify the required parameter 'mUUID' is set
            if (mUUID == null)
                throw new ApiException(400, "Missing required parameter 'mUUID' when calling DefaultApi->V3ProductionLineCertificatesMUUIDPut");
            
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling DefaultApi->V3ProductionLineCertificatesMUUIDPut");
            
    
            var localVarPath = "/v3/production-line-certificates/{mUUID}";
    
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
            if (mUUID != null) localVarPathParams.Add("mUUID", Configuration.ApiClient.ParameterToString(mUUID)); // path parameter
            
            
            if (authorization != null) localVarHeaderParams.Add("Authorization", Configuration.ApiClient.ParameterToString(authorization)); // header parameter
            
            
            if (body.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }

            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesMUUIDPut: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesMUUIDPut: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<ProductionLineCertificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProductionLineCertificate) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProductionLineCertificate)));
            
        }

        
        /// <summary>
        ///  Updates the comment on a production line certificate.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID</param>
        /// <param name="body"></param>
        /// <returns>Task of ProductionLineCertificate</returns>
        public async System.Threading.Tasks.Task<ProductionLineCertificate> V3ProductionLineCertificatesMUUIDPutAsync (string authorization, string mUUID, Body1 body)
        {
             ApiResponse<ProductionLineCertificate> localVarResponse = await V3ProductionLineCertificatesMUUIDPutAsyncWithHttpInfo(authorization, mUUID, body);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  Updates the comment on a production line certificate.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="mUUID">Certificate mUUID</param>
        /// <param name="body"></param>
        /// <returns>Task of ApiResponse (ProductionLineCertificate)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ProductionLineCertificate>> V3ProductionLineCertificatesMUUIDPutAsyncWithHttpInfo (string authorization, string mUUID, Body1 body)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null) throw new ApiException(400, "Missing required parameter 'authorization' when calling V3ProductionLineCertificatesMUUIDPut");
            // verify the required parameter 'mUUID' is set
            if (mUUID == null) throw new ApiException(400, "Missing required parameter 'mUUID' when calling V3ProductionLineCertificatesMUUIDPut");
            // verify the required parameter 'body' is set
            if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling V3ProductionLineCertificatesMUUIDPut");
            
    
            var localVarPath = "/v3/production-line-certificates/{mUUID}";
    
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
            if (mUUID != null) localVarPathParams.Add("mUUID", Configuration.ApiClient.ParameterToString(mUUID)); // path parameter
            
            
            if (authorization != null) localVarHeaderParams.Add("Authorization", Configuration.ApiClient.ParameterToString(authorization)); // header parameter
            
            
            if (body.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }

            
            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesMUUIDPut: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesMUUIDPut: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<ProductionLineCertificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProductionLineCertificate) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProductionLineCertificate)));
            
        }
        
        /// <summary>
        ///  Adds a new production line certificate to the account.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <param name="body"></param> 
        /// <returns>ProductionLineCertificate</returns>
        public ProductionLineCertificate V3ProductionLineCertificatesPost (string authorization, Body body)
        {
             ApiResponse<ProductionLineCertificate> localVarResponse = V3ProductionLineCertificatesPostWithHttpInfo(authorization, body);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  Adds a new production line certificate to the account.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <param name="body"></param> 
        /// <returns>ApiResponse of ProductionLineCertificate</returns>
        public ApiResponse< ProductionLineCertificate > V3ProductionLineCertificatesPostWithHttpInfo (string authorization, Body body)
        {
            
            // verify the required parameter 'authorization' is set
            if (authorization == null)
                throw new ApiException(400, "Missing required parameter 'authorization' when calling DefaultApi->V3ProductionLineCertificatesPost");
            
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling DefaultApi->V3ProductionLineCertificatesPost");
            
    
            var localVarPath = "/v3/production-line-certificates";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
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
            
            
            if (body.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }

            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesPost: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesPost: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<ProductionLineCertificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProductionLineCertificate) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProductionLineCertificate)));
            
        }

        
        /// <summary>
        ///  Adds a new production line certificate to the account.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="body"></param>
        /// <returns>Task of ProductionLineCertificate</returns>
        public async System.Threading.Tasks.Task<ProductionLineCertificate> V3ProductionLineCertificatesPostAsync (string authorization, Body body)
        {
             ApiResponse<ProductionLineCertificate> localVarResponse = await V3ProductionLineCertificatesPostAsyncWithHttpInfo(authorization, body);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  Adds a new production line certificate to the account.\n
        /// </summary>
        /// <exception cref="production_line_certificates.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="body"></param>
        /// <returns>Task of ApiResponse (ProductionLineCertificate)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ProductionLineCertificate>> V3ProductionLineCertificatesPostAsyncWithHttpInfo (string authorization, Body body)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null) throw new ApiException(400, "Missing required parameter 'authorization' when calling V3ProductionLineCertificatesPost");
            // verify the required parameter 'body' is set
            if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling V3ProductionLineCertificatesPost");
            
    
            var localVarPath = "/v3/production-line-certificates";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
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
            
            
            if (body.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(body); // http body (model) parameter
            }
            else
            {
                localVarPostBody = body; // byte array
            }

            
            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesPost: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3ProductionLineCertificatesPost: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<ProductionLineCertificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProductionLineCertificate) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProductionLineCertificate)));
            
        }
        
    }
    
}
