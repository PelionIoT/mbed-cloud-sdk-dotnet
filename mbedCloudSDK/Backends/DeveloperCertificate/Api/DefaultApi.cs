using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using developer_certificate.Client;
using developer_certificate.Model;

namespace developer_certificate.Api
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
        /// Deletes the account&#39;s developer certificate (only one per account allowed).
        /// </remarks>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns></returns>
        void V3DeveloperCertificateDelete (string authorization);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Deletes the account&#39;s developer certificate (only one per account allowed).
        /// </remarks>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> V3DeveloperCertificateDeleteWithHttpInfo (string authorization);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets the developer certificate of the account.
        /// </remarks>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>DeveloperCertificate</returns>
        DeveloperCertificate V3DeveloperCertificateGet (string authorization);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets the developer certificate of the account.
        /// </remarks>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>ApiResponse of DeveloperCertificate</returns>
        ApiResponse<DeveloperCertificate> V3DeveloperCertificateGetWithHttpInfo (string authorization);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Adds a developer certificate to the account (only one per account allowed).
        /// </remarks>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="body"></param>
        /// <returns>DeveloperCertificate</returns>
        DeveloperCertificate V3DeveloperCertificatePost (string authorization, Body body);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Adds a developer certificate to the account (only one per account allowed).
        /// </remarks>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="body"></param>
        /// <returns>ApiResponse of DeveloperCertificate</returns>
        ApiResponse<DeveloperCertificate> V3DeveloperCertificatePostWithHttpInfo (string authorization, Body body);
        
        #endregion Synchronous Operations
        
        #region Asynchronous Operations
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Deletes the account&#39;s developer certificate (only one per account allowed).
        /// </remarks>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task V3DeveloperCertificateDeleteAsync (string authorization);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Deletes the account&#39;s developer certificate (only one per account allowed).
        /// </remarks>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> V3DeveloperCertificateDeleteAsyncWithHttpInfo (string authorization);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets the developer certificate of the account.
        /// </remarks>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of DeveloperCertificate</returns>
        System.Threading.Tasks.Task<DeveloperCertificate> V3DeveloperCertificateGetAsync (string authorization);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets the developer certificate of the account.
        /// </remarks>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of ApiResponse (DeveloperCertificate)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeveloperCertificate>> V3DeveloperCertificateGetAsyncWithHttpInfo (string authorization);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Adds a developer certificate to the account (only one per account allowed).
        /// </remarks>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="body"></param>
        /// <returns>Task of DeveloperCertificate</returns>
        System.Threading.Tasks.Task<DeveloperCertificate> V3DeveloperCertificatePostAsync (string authorization, Body body);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Adds a developer certificate to the account (only one per account allowed).
        /// </remarks>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="body"></param>
        /// <returns>Task of ApiResponse (DeveloperCertificate)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeveloperCertificate>> V3DeveloperCertificatePostAsyncWithHttpInfo (string authorization, Body body);
        
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
        ///  Deletes the account&#39;s developer certificate (only one per account allowed).
        /// </summary>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <returns></returns>
        public void V3DeveloperCertificateDelete (string authorization)
        {
             V3DeveloperCertificateDeleteWithHttpInfo(authorization);
        }

        /// <summary>
        ///  Deletes the account&#39;s developer certificate (only one per account allowed).
        /// </summary>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> V3DeveloperCertificateDeleteWithHttpInfo (string authorization)
        {
            
            // verify the required parameter 'authorization' is set
            if (authorization == null)
                throw new ApiException(400, "Missing required parameter 'authorization' when calling DefaultApi->V3DeveloperCertificateDelete");
            
    
            var localVarPath = "/v3/developer-certificate";
    
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
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling V3DeveloperCertificateDelete: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3DeveloperCertificateDelete: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        
        /// <summary>
        ///  Deletes the account&#39;s developer certificate (only one per account allowed).
        /// </summary>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task V3DeveloperCertificateDeleteAsync (string authorization)
        {
             await V3DeveloperCertificateDeleteAsyncWithHttpInfo(authorization);

        }

        /// <summary>
        ///  Deletes the account&#39;s developer certificate (only one per account allowed).
        /// </summary>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> V3DeveloperCertificateDeleteAsyncWithHttpInfo (string authorization)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null) throw new ApiException(400, "Missing required parameter 'authorization' when calling V3DeveloperCertificateDelete");
            
    
            var localVarPath = "/v3/developer-certificate";
    
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
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling V3DeveloperCertificateDelete: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3DeveloperCertificateDelete: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        
        /// <summary>
        ///  Gets the developer certificate of the account.
        /// </summary>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <returns>DeveloperCertificate</returns>
        public DeveloperCertificate V3DeveloperCertificateGet (string authorization)
        {
             ApiResponse<DeveloperCertificate> localVarResponse = V3DeveloperCertificateGetWithHttpInfo(authorization);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  Gets the developer certificate of the account.
        /// </summary>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <returns>ApiResponse of DeveloperCertificate</returns>
        public ApiResponse< DeveloperCertificate > V3DeveloperCertificateGetWithHttpInfo (string authorization)
        {
            
            // verify the required parameter 'authorization' is set
            if (authorization == null)
                throw new ApiException(400, "Missing required parameter 'authorization' when calling DefaultApi->V3DeveloperCertificateGet");
            
    
            var localVarPath = "/v3/developer-certificate";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V3DeveloperCertificateGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3DeveloperCertificateGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<DeveloperCertificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeveloperCertificate) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeveloperCertificate)));
            
        }

        
        /// <summary>
        ///  Gets the developer certificate of the account.
        /// </summary>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of DeveloperCertificate</returns>
        public async System.Threading.Tasks.Task<DeveloperCertificate> V3DeveloperCertificateGetAsync (string authorization)
        {
             ApiResponse<DeveloperCertificate> localVarResponse = await V3DeveloperCertificateGetAsyncWithHttpInfo(authorization);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  Gets the developer certificate of the account.
        /// </summary>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <returns>Task of ApiResponse (DeveloperCertificate)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DeveloperCertificate>> V3DeveloperCertificateGetAsyncWithHttpInfo (string authorization)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null) throw new ApiException(400, "Missing required parameter 'authorization' when calling V3DeveloperCertificateGet");
            
    
            var localVarPath = "/v3/developer-certificate";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V3DeveloperCertificateGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3DeveloperCertificateGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<DeveloperCertificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeveloperCertificate) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeveloperCertificate)));
            
        }
        
        /// <summary>
        ///  Adds a developer certificate to the account (only one per account allowed).
        /// </summary>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <param name="body"></param> 
        /// <returns>DeveloperCertificate</returns>
        public DeveloperCertificate V3DeveloperCertificatePost (string authorization, Body body)
        {
             ApiResponse<DeveloperCertificate> localVarResponse = V3DeveloperCertificatePostWithHttpInfo(authorization, body);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  Adds a developer certificate to the account (only one per account allowed).
        /// </summary>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param> 
        /// <param name="body"></param> 
        /// <returns>ApiResponse of DeveloperCertificate</returns>
        public ApiResponse< DeveloperCertificate > V3DeveloperCertificatePostWithHttpInfo (string authorization, Body body)
        {
            
            // verify the required parameter 'authorization' is set
            if (authorization == null)
                throw new ApiException(400, "Missing required parameter 'authorization' when calling DefaultApi->V3DeveloperCertificatePost");
            
            // verify the required parameter 'body' is set
            if (body == null)
                throw new ApiException(400, "Missing required parameter 'body' when calling DefaultApi->V3DeveloperCertificatePost");
            
    
            var localVarPath = "/v3/developer-certificate";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V3DeveloperCertificatePost: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3DeveloperCertificatePost: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<DeveloperCertificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeveloperCertificate) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeveloperCertificate)));
            
        }

        
        /// <summary>
        ///  Adds a developer certificate to the account (only one per account allowed).
        /// </summary>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="body"></param>
        /// <returns>Task of DeveloperCertificate</returns>
        public async System.Threading.Tasks.Task<DeveloperCertificate> V3DeveloperCertificatePostAsync (string authorization, Body body)
        {
             ApiResponse<DeveloperCertificate> localVarResponse = await V3DeveloperCertificatePostAsyncWithHttpInfo(authorization, body);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  Adds a developer certificate to the account (only one per account allowed).
        /// </summary>
        /// <exception cref="developer_certificate.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">\&quot;Bearer\&quot; followed by the reference token or API key.</param>
        /// <param name="body"></param>
        /// <returns>Task of ApiResponse (DeveloperCertificate)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DeveloperCertificate>> V3DeveloperCertificatePostAsyncWithHttpInfo (string authorization, Body body)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null) throw new ApiException(400, "Missing required parameter 'authorization' when calling V3DeveloperCertificatePost");
            // verify the required parameter 'body' is set
            if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling V3DeveloperCertificatePost");
            
    
            var localVarPath = "/v3/developer-certificate";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V3DeveloperCertificatePost: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V3DeveloperCertificatePost: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<DeveloperCertificate>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeveloperCertificate) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeveloperCertificate)));
            
        }
        
    }
    
}
