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
    public interface IResourcesApi
    {
        #region Synchronous Operations
        
        /// <summary>
        /// Delete a resource
        /// </summary>
        /// <remarks>
        /// A request to delete a resource must be handled by both mbed Cloud Client and mbed Cloud\nConnect. The resource is not deleted from mbed Cloud Connect until the delete\nis handled by mbed Cloud Client.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>AsyncID</returns>
        AsyncID V2EndpointsEndpointNameResourcePathDelete (string endpointName, string resourcePath, bool? noResp = null);
  
        /// <summary>
        /// Delete a resource
        /// </summary>
        /// <remarks>
        /// A request to delete a resource must be handled by both mbed Cloud Client and mbed Cloud\nConnect. The resource is not deleted from mbed Cloud Connect until the delete\nis handled by mbed Cloud Client.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>ApiResponse of AsyncID</returns>
        ApiResponse<AsyncID> V2EndpointsEndpointNameResourcePathDeleteWithHttpInfo (string endpointName, string resourcePath, bool? noResp = null);
        
        /// <summary>
        /// Read from a resource
        /// </summary>
        /// <remarks>
        /// Requests the resource value and when the response is available, a json AsycResponse\nobject (AsyncIDResponse object) is received in the notification channel. Note that you can also\nreceive notifications when a resource changes. The preferred way to get resource values is to use subscribe\nand callback methods.\n\nAll resource APIs are asynchronous. Note that these APIs will only respond\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">Unique identifier for the endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <param name="cacheOnly">If true, the response comes only from the cache. Default: false.\n (optional)</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If a request is made with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>AsyncID</returns>
        AsyncID V2EndpointsEndpointNameResourcePathGet (string endpointName, string resourcePath, bool? cacheOnly = null, bool? noResp = null);
  
        /// <summary>
        /// Read from a resource
        /// </summary>
        /// <remarks>
        /// Requests the resource value and when the response is available, a json AsycResponse\nobject (AsyncIDResponse object) is received in the notification channel. Note that you can also\nreceive notifications when a resource changes. The preferred way to get resource values is to use subscribe\nand callback methods.\n\nAll resource APIs are asynchronous. Note that these APIs will only respond\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">Unique identifier for the endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <param name="cacheOnly">If true, the response comes only from the cache. Default: false.\n (optional)</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If a request is made with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>ApiResponse of AsyncID</returns>
        ApiResponse<AsyncID> V2EndpointsEndpointNameResourcePathGetWithHttpInfo (string endpointName, string resourcePath, bool? cacheOnly = null, bool? noResp = null);
        
        /// <summary>
        /// Execute a function on a resource
        /// </summary>
        /// <remarks>
        /// With this API, you can execute a function on an existing resource.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.</param>
        /// <param name="resourceFunction">This value is not needed. Most of the time resources do not accept a function\nbut they have their own functions predefined. You can use this to trigger them.\n\nIf a function is included, the body of this request is passed as a char* to\nthe function in mbed Cloud Client.\n (optional)</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>AsyncID</returns>
        AsyncID V2EndpointsEndpointNameResourcePathPost (string endpointName, string resourcePath, string resourceFunction = null, bool? noResp = null);
  
        /// <summary>
        /// Execute a function on a resource
        /// </summary>
        /// <remarks>
        /// With this API, you can execute a function on an existing resource.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.</param>
        /// <param name="resourceFunction">This value is not needed. Most of the time resources do not accept a function\nbut they have their own functions predefined. You can use this to trigger them.\n\nIf a function is included, the body of this request is passed as a char* to\nthe function in mbed Cloud Client.\n (optional)</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>ApiResponse of AsyncID</returns>
        ApiResponse<AsyncID> V2EndpointsEndpointNameResourcePathPostWithHttpInfo (string endpointName, string resourcePath, string resourceFunction = null, bool? noResp = null);
        
        /// <summary>
        /// Write to a resource
        /// </summary>
        /// <remarks>
        /// With this API, you can write new values to existing resources, or create new\nresources on the device. The resource-path does not have to exist - it can be\ncreated by the call.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.</param>
        /// <param name="resourceValue">Value to be set to the resource. (Check accceptable content-types)\n</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>AsyncID</returns>
        AsyncID V2EndpointsEndpointNameResourcePathPut (string endpointName, string resourcePath, string resourceValue, bool? noResp = null);
  
        /// <summary>
        /// Write to a resource
        /// </summary>
        /// <remarks>
        /// With this API, you can write new values to existing resources, or create new\nresources on the device. The resource-path does not have to exist - it can be\ncreated by the call.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.</param>
        /// <param name="resourceValue">Value to be set to the resource. (Check accceptable content-types)\n</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>ApiResponse of AsyncID</returns>
        ApiResponse<AsyncID> V2EndpointsEndpointNameResourcePathPutWithHttpInfo (string endpointName, string resourcePath, string resourceValue, bool? noResp = null);
        
        #endregion Synchronous Operations
        
        #region Asynchronous Operations
        
        /// <summary>
        /// Delete a resource
        /// </summary>
        /// <remarks>
        /// A request to delete a resource must be handled by both mbed Cloud Client and mbed Cloud\nConnect. The resource is not deleted from mbed Cloud Connect until the delete\nis handled by mbed Cloud Client.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of AsyncID</returns>
        System.Threading.Tasks.Task<AsyncID> V2EndpointsEndpointNameResourcePathDeleteAsync (string endpointName, string resourcePath, bool? noResp = null);

        /// <summary>
        /// Delete a resource
        /// </summary>
        /// <remarks>
        /// A request to delete a resource must be handled by both mbed Cloud Client and mbed Cloud\nConnect. The resource is not deleted from mbed Cloud Connect until the delete\nis handled by mbed Cloud Client.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of ApiResponse (AsyncID)</returns>
        System.Threading.Tasks.Task<ApiResponse<AsyncID>> V2EndpointsEndpointNameResourcePathDeleteAsyncWithHttpInfo (string endpointName, string resourcePath, bool? noResp = null);
        
        /// <summary>
        /// Read from a resource
        /// </summary>
        /// <remarks>
        /// Requests the resource value and when the response is available, a json AsycResponse\nobject (AsyncIDResponse object) is received in the notification channel. Note that you can also\nreceive notifications when a resource changes. The preferred way to get resource values is to use subscribe\nand callback methods.\n\nAll resource APIs are asynchronous. Note that these APIs will only respond\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">Unique identifier for the endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <param name="cacheOnly">If true, the response comes only from the cache. Default: false.\n (optional)</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If a request is made with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of AsyncID</returns>
        System.Threading.Tasks.Task<AsyncID> V2EndpointsEndpointNameResourcePathGetAsync (string endpointName, string resourcePath, bool? cacheOnly = null, bool? noResp = null);

        /// <summary>
        /// Read from a resource
        /// </summary>
        /// <remarks>
        /// Requests the resource value and when the response is available, a json AsycResponse\nobject (AsyncIDResponse object) is received in the notification channel. Note that you can also\nreceive notifications when a resource changes. The preferred way to get resource values is to use subscribe\nand callback methods.\n\nAll resource APIs are asynchronous. Note that these APIs will only respond\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">Unique identifier for the endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <param name="cacheOnly">If true, the response comes only from the cache. Default: false.\n (optional)</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If a request is made with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of ApiResponse (AsyncID)</returns>
        System.Threading.Tasks.Task<ApiResponse<AsyncID>> V2EndpointsEndpointNameResourcePathGetAsyncWithHttpInfo (string endpointName, string resourcePath, bool? cacheOnly = null, bool? noResp = null);
        
        /// <summary>
        /// Execute a function on a resource
        /// </summary>
        /// <remarks>
        /// With this API, you can execute a function on an existing resource.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.</param>
        /// <param name="resourceFunction">This value is not needed. Most of the time resources do not accept a function\nbut they have their own functions predefined. You can use this to trigger them.\n\nIf a function is included, the body of this request is passed as a char* to\nthe function in mbed Cloud Client.\n (optional)</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of AsyncID</returns>
        System.Threading.Tasks.Task<AsyncID> V2EndpointsEndpointNameResourcePathPostAsync (string endpointName, string resourcePath, string resourceFunction = null, bool? noResp = null);

        /// <summary>
        /// Execute a function on a resource
        /// </summary>
        /// <remarks>
        /// With this API, you can execute a function on an existing resource.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.</param>
        /// <param name="resourceFunction">This value is not needed. Most of the time resources do not accept a function\nbut they have their own functions predefined. You can use this to trigger them.\n\nIf a function is included, the body of this request is passed as a char* to\nthe function in mbed Cloud Client.\n (optional)</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of ApiResponse (AsyncID)</returns>
        System.Threading.Tasks.Task<ApiResponse<AsyncID>> V2EndpointsEndpointNameResourcePathPostAsyncWithHttpInfo (string endpointName, string resourcePath, string resourceFunction = null, bool? noResp = null);
        
        /// <summary>
        /// Write to a resource
        /// </summary>
        /// <remarks>
        /// With this API, you can write new values to existing resources, or create new\nresources on the device. The resource-path does not have to exist - it can be\ncreated by the call.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.</param>
        /// <param name="resourceValue">Value to be set to the resource. (Check accceptable content-types)\n</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of AsyncID</returns>
        System.Threading.Tasks.Task<AsyncID> V2EndpointsEndpointNameResourcePathPutAsync (string endpointName, string resourcePath, string resourceValue, bool? noResp = null);

        /// <summary>
        /// Write to a resource
        /// </summary>
        /// <remarks>
        /// With this API, you can write new values to existing resources, or create new\nresources on the device. The resource-path does not have to exist - it can be\ncreated by the call.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.</param>
        /// <param name="resourceValue">Value to be set to the resource. (Check accceptable content-types)\n</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of ApiResponse (AsyncID)</returns>
        System.Threading.Tasks.Task<ApiResponse<AsyncID>> V2EndpointsEndpointNameResourcePathPutAsyncWithHttpInfo (string endpointName, string resourcePath, string resourceValue, bool? noResp = null);
        
        #endregion Asynchronous Operations
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ResourcesApi : IResourcesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ResourcesApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ResourcesApi(Configuration configuration = null)
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
        /// Delete a resource A request to delete a resource must be handled by both mbed Cloud Client and mbed Cloud\nConnect. The resource is not deleted from mbed Cloud Connect until the delete\nis handled by mbed Cloud Client.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <param name="resourcePath">Resource&#39;s url.\n</param> 
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param> 
        /// <returns>AsyncID</returns>
        public AsyncID V2EndpointsEndpointNameResourcePathDelete (string endpointName, string resourcePath, bool? noResp = null)
        {
             ApiResponse<AsyncID> localVarResponse = V2EndpointsEndpointNameResourcePathDeleteWithHttpInfo(endpointName, resourcePath, noResp);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete a resource A request to delete a resource must be handled by both mbed Cloud Client and mbed Cloud\nConnect. The resource is not deleted from mbed Cloud Connect until the delete\nis handled by mbed Cloud Client.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <param name="resourcePath">Resource&#39;s url.\n</param> 
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param> 
        /// <returns>ApiResponse of AsyncID</returns>
        public ApiResponse< AsyncID > V2EndpointsEndpointNameResourcePathDeleteWithHttpInfo (string endpointName, string resourcePath, bool? noResp = null)
        {
            
            // verify the required parameter 'endpointName' is set
            if (endpointName == null)
                throw new ApiException(400, "Missing required parameter 'endpointName' when calling ResourcesApi->V2EndpointsEndpointNameResourcePathDelete");
            
            // verify the required parameter 'resourcePath' is set
            if (resourcePath == null)
                throw new ApiException(400, "Missing required parameter 'resourcePath' when calling ResourcesApi->V2EndpointsEndpointNameResourcePathDelete");
            
    
            var localVarPath = "/v2/endpoints/{endpointName}/{resourcePath}";
    
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
            if (endpointName != null) localVarPathParams.Add("endpointName", Configuration.ApiClient.ParameterToString(endpointName)); // path parameter
            if (resourcePath != null) localVarPathParams.Add("resourcePath", Configuration.ApiClient.ParameterToString(resourcePath)); // path parameter
            
            if (noResp != null) localVarQueryParams.Add("noResp", Configuration.ApiClient.ParameterToString(noResp)); // query parameter
            
            
            
            

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
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathDelete: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathDelete: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<AsyncID>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AsyncID) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AsyncID)));
            
        }

        
        /// <summary>
        /// Delete a resource A request to delete a resource must be handled by both mbed Cloud Client and mbed Cloud\nConnect. The resource is not deleted from mbed Cloud Connect until the delete\nis handled by mbed Cloud Client.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of AsyncID</returns>
        public async System.Threading.Tasks.Task<AsyncID> V2EndpointsEndpointNameResourcePathDeleteAsync (string endpointName, string resourcePath, bool? noResp = null)
        {
             ApiResponse<AsyncID> localVarResponse = await V2EndpointsEndpointNameResourcePathDeleteAsyncWithHttpInfo(endpointName, resourcePath, noResp);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete a resource A request to delete a resource must be handled by both mbed Cloud Client and mbed Cloud\nConnect. The resource is not deleted from mbed Cloud Connect until the delete\nis handled by mbed Cloud Client.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of ApiResponse (AsyncID)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AsyncID>> V2EndpointsEndpointNameResourcePathDeleteAsyncWithHttpInfo (string endpointName, string resourcePath, bool? noResp = null)
        {
            // verify the required parameter 'endpointName' is set
            if (endpointName == null) throw new ApiException(400, "Missing required parameter 'endpointName' when calling V2EndpointsEndpointNameResourcePathDelete");
            // verify the required parameter 'resourcePath' is set
            if (resourcePath == null) throw new ApiException(400, "Missing required parameter 'resourcePath' when calling V2EndpointsEndpointNameResourcePathDelete");
            
    
            var localVarPath = "/v2/endpoints/{endpointName}/{resourcePath}";
    
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
            if (endpointName != null) localVarPathParams.Add("endpointName", Configuration.ApiClient.ParameterToString(endpointName)); // path parameter
            if (resourcePath != null) localVarPathParams.Add("resourcePath", Configuration.ApiClient.ParameterToString(resourcePath)); // path parameter
            
            if (noResp != null) localVarQueryParams.Add("noResp", Configuration.ApiClient.ParameterToString(noResp)); // query parameter
            
            
            
            

            
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
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathDelete: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathDelete: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<AsyncID>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AsyncID) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AsyncID)));
            
        }
        
        /// <summary>
        /// Read from a resource Requests the resource value and when the response is available, a json AsycResponse\nobject (AsyncIDResponse object) is received in the notification channel. Note that you can also\nreceive notifications when a resource changes. The preferred way to get resource values is to use subscribe\nand callback methods.\n\nAll resource APIs are asynchronous. Note that these APIs will only respond\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">Unique identifier for the endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <param name="resourcePath">Resource&#39;s url.\n</param> 
        /// <param name="cacheOnly">If true, the response comes only from the cache. Default: false.\n (optional)</param> 
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If a request is made with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param> 
        /// <returns>AsyncID</returns>
        public AsyncID V2EndpointsEndpointNameResourcePathGet (string endpointName, string resourcePath, bool? cacheOnly = null, bool? noResp = null)
        {
             ApiResponse<AsyncID> localVarResponse = V2EndpointsEndpointNameResourcePathGetWithHttpInfo(endpointName, resourcePath, cacheOnly, noResp);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Read from a resource Requests the resource value and when the response is available, a json AsycResponse\nobject (AsyncIDResponse object) is received in the notification channel. Note that you can also\nreceive notifications when a resource changes. The preferred way to get resource values is to use subscribe\nand callback methods.\n\nAll resource APIs are asynchronous. Note that these APIs will only respond\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">Unique identifier for the endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <param name="resourcePath">Resource&#39;s url.\n</param> 
        /// <param name="cacheOnly">If true, the response comes only from the cache. Default: false.\n (optional)</param> 
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If a request is made with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param> 
        /// <returns>ApiResponse of AsyncID</returns>
        public ApiResponse< AsyncID > V2EndpointsEndpointNameResourcePathGetWithHttpInfo (string endpointName, string resourcePath, bool? cacheOnly = null, bool? noResp = null)
        {
            
            // verify the required parameter 'endpointName' is set
            if (endpointName == null)
                throw new ApiException(400, "Missing required parameter 'endpointName' when calling ResourcesApi->V2EndpointsEndpointNameResourcePathGet");
            
            // verify the required parameter 'resourcePath' is set
            if (resourcePath == null)
                throw new ApiException(400, "Missing required parameter 'resourcePath' when calling ResourcesApi->V2EndpointsEndpointNameResourcePathGet");
            
    
            var localVarPath = "/v2/endpoints/{endpointName}/{resourcePath}";
    
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
            if (endpointName != null) localVarPathParams.Add("endpointName", Configuration.ApiClient.ParameterToString(endpointName)); // path parameter
            if (resourcePath != null) localVarPathParams.Add("resourcePath", Configuration.ApiClient.ParameterToString(resourcePath)); // path parameter
            
            if (cacheOnly != null) localVarQueryParams.Add("cacheOnly", Configuration.ApiClient.ParameterToString(cacheOnly)); // query parameter
            if (noResp != null) localVarQueryParams.Add("noResp", Configuration.ApiClient.ParameterToString(noResp)); // query parameter
            
            
            
            

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
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<AsyncID>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AsyncID) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AsyncID)));
            
        }

        
        /// <summary>
        /// Read from a resource Requests the resource value and when the response is available, a json AsycResponse\nobject (AsyncIDResponse object) is received in the notification channel. Note that you can also\nreceive notifications when a resource changes. The preferred way to get resource values is to use subscribe\nand callback methods.\n\nAll resource APIs are asynchronous. Note that these APIs will only respond\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">Unique identifier for the endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <param name="cacheOnly">If true, the response comes only from the cache. Default: false.\n (optional)</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If a request is made with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of AsyncID</returns>
        public async System.Threading.Tasks.Task<AsyncID> V2EndpointsEndpointNameResourcePathGetAsync (string endpointName, string resourcePath, bool? cacheOnly = null, bool? noResp = null)
        {
             ApiResponse<AsyncID> localVarResponse = await V2EndpointsEndpointNameResourcePathGetAsyncWithHttpInfo(endpointName, resourcePath, cacheOnly, noResp);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Read from a resource Requests the resource value and when the response is available, a json AsycResponse\nobject (AsyncIDResponse object) is received in the notification channel. Note that you can also\nreceive notifications when a resource changes. The preferred way to get resource values is to use subscribe\nand callback methods.\n\nAll resource APIs are asynchronous. Note that these APIs will only respond\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">Unique identifier for the endpoint. Note that the endpoint name needs to be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <param name="cacheOnly">If true, the response comes only from the cache. Default: false.\n (optional)</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If a request is made with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of ApiResponse (AsyncID)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AsyncID>> V2EndpointsEndpointNameResourcePathGetAsyncWithHttpInfo (string endpointName, string resourcePath, bool? cacheOnly = null, bool? noResp = null)
        {
            // verify the required parameter 'endpointName' is set
            if (endpointName == null) throw new ApiException(400, "Missing required parameter 'endpointName' when calling V2EndpointsEndpointNameResourcePathGet");
            // verify the required parameter 'resourcePath' is set
            if (resourcePath == null) throw new ApiException(400, "Missing required parameter 'resourcePath' when calling V2EndpointsEndpointNameResourcePathGet");
            
    
            var localVarPath = "/v2/endpoints/{endpointName}/{resourcePath}";
    
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
            if (endpointName != null) localVarPathParams.Add("endpointName", Configuration.ApiClient.ParameterToString(endpointName)); // path parameter
            if (resourcePath != null) localVarPathParams.Add("resourcePath", Configuration.ApiClient.ParameterToString(resourcePath)); // path parameter
            
            if (cacheOnly != null) localVarQueryParams.Add("cacheOnly", Configuration.ApiClient.ParameterToString(cacheOnly)); // query parameter
            if (noResp != null) localVarQueryParams.Add("noResp", Configuration.ApiClient.ParameterToString(noResp)); // query parameter
            
            
            
            

            
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
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<AsyncID>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AsyncID) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AsyncID)));
            
        }
        
        /// <summary>
        /// Execute a function on a resource With this API, you can execute a function on an existing resource.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <param name="resourcePath">Resource&#39;s url.</param> 
        /// <param name="resourceFunction">This value is not needed. Most of the time resources do not accept a function\nbut they have their own functions predefined. You can use this to trigger them.\n\nIf a function is included, the body of this request is passed as a char* to\nthe function in mbed Cloud Client.\n (optional)</param> 
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param> 
        /// <returns>AsyncID</returns>
        public AsyncID V2EndpointsEndpointNameResourcePathPost (string endpointName, string resourcePath, string resourceFunction = null, bool? noResp = null)
        {
             ApiResponse<AsyncID> localVarResponse = V2EndpointsEndpointNameResourcePathPostWithHttpInfo(endpointName, resourcePath, resourceFunction, noResp);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Execute a function on a resource With this API, you can execute a function on an existing resource.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <param name="resourcePath">Resource&#39;s url.</param> 
        /// <param name="resourceFunction">This value is not needed. Most of the time resources do not accept a function\nbut they have their own functions predefined. You can use this to trigger them.\n\nIf a function is included, the body of this request is passed as a char* to\nthe function in mbed Cloud Client.\n (optional)</param> 
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param> 
        /// <returns>ApiResponse of AsyncID</returns>
        public ApiResponse< AsyncID > V2EndpointsEndpointNameResourcePathPostWithHttpInfo (string endpointName, string resourcePath, string resourceFunction = null, bool? noResp = null)
        {
            
            // verify the required parameter 'endpointName' is set
            if (endpointName == null)
                throw new ApiException(400, "Missing required parameter 'endpointName' when calling ResourcesApi->V2EndpointsEndpointNameResourcePathPost");
            
            // verify the required parameter 'resourcePath' is set
            if (resourcePath == null)
                throw new ApiException(400, "Missing required parameter 'resourcePath' when calling ResourcesApi->V2EndpointsEndpointNameResourcePathPost");
            
    
            var localVarPath = "/v2/endpoints/{endpointName}/{resourcePath}";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "text/plain", "application/xml", "application/octet-stream", "application/exi", "application/json", "application/link-format", "application/senml+json", "application/nanoservice-tlv", "application/vnd.oma.lwm2m+text", "application/vnd.oma.lwm2m+opaq", "application/vnd.oma.lwm2m+tlv", "application/vnd.oma.lwm2m+json"
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
            if (endpointName != null) localVarPathParams.Add("endpointName", Configuration.ApiClient.ParameterToString(endpointName)); // path parameter
            if (resourcePath != null) localVarPathParams.Add("resourcePath", Configuration.ApiClient.ParameterToString(resourcePath)); // path parameter
            
            if (noResp != null) localVarQueryParams.Add("noResp", Configuration.ApiClient.ParameterToString(noResp)); // query parameter
            
            
            
            if (resourceFunction.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(resourceFunction); // http body (model) parameter
            }
            else
            {
                localVarPostBody = resourceFunction; // byte array
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
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathPost: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathPost: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<AsyncID>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AsyncID) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AsyncID)));
            
        }

        
        /// <summary>
        /// Execute a function on a resource With this API, you can execute a function on an existing resource.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.</param>
        /// <param name="resourceFunction">This value is not needed. Most of the time resources do not accept a function\nbut they have their own functions predefined. You can use this to trigger them.\n\nIf a function is included, the body of this request is passed as a char* to\nthe function in mbed Cloud Client.\n (optional)</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of AsyncID</returns>
        public async System.Threading.Tasks.Task<AsyncID> V2EndpointsEndpointNameResourcePathPostAsync (string endpointName, string resourcePath, string resourceFunction = null, bool? noResp = null)
        {
             ApiResponse<AsyncID> localVarResponse = await V2EndpointsEndpointNameResourcePathPostAsyncWithHttpInfo(endpointName, resourcePath, resourceFunction, noResp);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Execute a function on a resource With this API, you can execute a function on an existing resource.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint-name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.</param>
        /// <param name="resourceFunction">This value is not needed. Most of the time resources do not accept a function\nbut they have their own functions predefined. You can use this to trigger them.\n\nIf a function is included, the body of this request is passed as a char* to\nthe function in mbed Cloud Client.\n (optional)</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of ApiResponse (AsyncID)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AsyncID>> V2EndpointsEndpointNameResourcePathPostAsyncWithHttpInfo (string endpointName, string resourcePath, string resourceFunction = null, bool? noResp = null)
        {
            // verify the required parameter 'endpointName' is set
            if (endpointName == null) throw new ApiException(400, "Missing required parameter 'endpointName' when calling V2EndpointsEndpointNameResourcePathPost");
            // verify the required parameter 'resourcePath' is set
            if (resourcePath == null) throw new ApiException(400, "Missing required parameter 'resourcePath' when calling V2EndpointsEndpointNameResourcePathPost");
            
    
            var localVarPath = "/v2/endpoints/{endpointName}/{resourcePath}";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "text/plain", "application/xml", "application/octet-stream", "application/exi", "application/json", "application/link-format", "application/senml+json", "application/nanoservice-tlv", "application/vnd.oma.lwm2m+text", "application/vnd.oma.lwm2m+opaq", "application/vnd.oma.lwm2m+tlv", "application/vnd.oma.lwm2m+json"
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
            if (endpointName != null) localVarPathParams.Add("endpointName", Configuration.ApiClient.ParameterToString(endpointName)); // path parameter
            if (resourcePath != null) localVarPathParams.Add("resourcePath", Configuration.ApiClient.ParameterToString(resourcePath)); // path parameter
            
            if (noResp != null) localVarQueryParams.Add("noResp", Configuration.ApiClient.ParameterToString(noResp)); // query parameter
            
            
            
            if (resourceFunction.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(resourceFunction); // http body (model) parameter
            }
            else
            {
                localVarPostBody = resourceFunction; // byte array
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
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathPost: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathPost: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<AsyncID>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AsyncID) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AsyncID)));
            
        }
        
        /// <summary>
        /// Write to a resource With this API, you can write new values to existing resources, or create new\nresources on the device. The resource-path does not have to exist - it can be\ncreated by the call.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <param name="resourcePath">Resource&#39;s url.</param> 
        /// <param name="resourceValue">Value to be set to the resource. (Check accceptable content-types)\n</param> 
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param> 
        /// <returns>AsyncID</returns>
        public AsyncID V2EndpointsEndpointNameResourcePathPut (string endpointName, string resourcePath, string resourceValue, bool? noResp = null)
        {
             ApiResponse<AsyncID> localVarResponse = V2EndpointsEndpointNameResourcePathPutWithHttpInfo(endpointName, resourcePath, resourceValue, noResp);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Write to a resource With this API, you can write new values to existing resources, or create new\nresources on the device. The resource-path does not have to exist - it can be\ncreated by the call.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <param name="resourcePath">Resource&#39;s url.</param> 
        /// <param name="resourceValue">Value to be set to the resource. (Check accceptable content-types)\n</param> 
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param> 
        /// <returns>ApiResponse of AsyncID</returns>
        public ApiResponse< AsyncID > V2EndpointsEndpointNameResourcePathPutWithHttpInfo (string endpointName, string resourcePath, string resourceValue, bool? noResp = null)
        {
            
            // verify the required parameter 'endpointName' is set
            if (endpointName == null)
                throw new ApiException(400, "Missing required parameter 'endpointName' when calling ResourcesApi->V2EndpointsEndpointNameResourcePathPut");
            
            // verify the required parameter 'resourcePath' is set
            if (resourcePath == null)
                throw new ApiException(400, "Missing required parameter 'resourcePath' when calling ResourcesApi->V2EndpointsEndpointNameResourcePathPut");
            
            // verify the required parameter 'resourceValue' is set
            if (resourceValue == null)
                throw new ApiException(400, "Missing required parameter 'resourceValue' when calling ResourcesApi->V2EndpointsEndpointNameResourcePathPut");
            
    
            var localVarPath = "/v2/endpoints/{endpointName}/{resourcePath}";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "text/plain", "application/xml", "application/octet-stream", "application/exi", "application/json", "application/link-format", "application/senml+json", "application/nanoservice-tlv", "application/vnd.oma.lwm2m+text", "application/vnd.oma.lwm2m+opaq", "application/vnd.oma.lwm2m+tlv", "application/vnd.oma.lwm2m+json"
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
            if (endpointName != null) localVarPathParams.Add("endpointName", Configuration.ApiClient.ParameterToString(endpointName)); // path parameter
            if (resourcePath != null) localVarPathParams.Add("resourcePath", Configuration.ApiClient.ParameterToString(resourcePath)); // path parameter
            
            if (noResp != null) localVarQueryParams.Add("noResp", Configuration.ApiClient.ParameterToString(noResp)); // query parameter
            
            
            
            if (resourceValue.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(resourceValue); // http body (model) parameter
            }
            else
            {
                localVarPostBody = resourceValue; // byte array
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
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathPut: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathPut: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<AsyncID>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AsyncID) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AsyncID)));
            
        }

        
        /// <summary>
        /// Write to a resource With this API, you can write new values to existing resources, or create new\nresources on the device. The resource-path does not have to exist - it can be\ncreated by the call.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.</param>
        /// <param name="resourceValue">Value to be set to the resource. (Check accceptable content-types)\n</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of AsyncID</returns>
        public async System.Threading.Tasks.Task<AsyncID> V2EndpointsEndpointNameResourcePathPutAsync (string endpointName, string resourcePath, string resourceValue, bool? noResp = null)
        {
             ApiResponse<AsyncID> localVarResponse = await V2EndpointsEndpointNameResourcePathPutAsyncWithHttpInfo(endpointName, resourcePath, resourceValue, noResp);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Write to a resource With this API, you can write new values to existing resources, or create new\nresources on the device. The resource-path does not have to exist - it can be\ncreated by the call.\n\nAll resource APIs are asynchronous. Note that these APIs respond only\nif the device is turned on and connected to mbed Cloud Connect.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.</param>
        /// <param name="resourceValue">Value to be set to the resource. (Check accceptable content-types)\n</param>
        /// <param name="noResp">**Non-confirmable requests**\n\nAll resource APIs have the parameter noResp. If you make a request with noResp=true,\nmbed Cloud Connect makes a CoAP non-confirmable request to the device.\nSuch requests are not guaranteed to arrive in the device,\nand you do not get back an async-response-id.\n\nIf calls with this parameter enabled succeed, they return with the status code\n204 No Content. If the underlying protocol does not support non-confirmable requests,\nor if the endpoint is registered in queue mode, the response is status code 409 Conflict.\n (optional)</param>
        /// <returns>Task of ApiResponse (AsyncID)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AsyncID>> V2EndpointsEndpointNameResourcePathPutAsyncWithHttpInfo (string endpointName, string resourcePath, string resourceValue, bool? noResp = null)
        {
            // verify the required parameter 'endpointName' is set
            if (endpointName == null) throw new ApiException(400, "Missing required parameter 'endpointName' when calling V2EndpointsEndpointNameResourcePathPut");
            // verify the required parameter 'resourcePath' is set
            if (resourcePath == null) throw new ApiException(400, "Missing required parameter 'resourcePath' when calling V2EndpointsEndpointNameResourcePathPut");
            // verify the required parameter 'resourceValue' is set
            if (resourceValue == null) throw new ApiException(400, "Missing required parameter 'resourceValue' when calling V2EndpointsEndpointNameResourcePathPut");
            
    
            var localVarPath = "/v2/endpoints/{endpointName}/{resourcePath}";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "text/plain", "application/xml", "application/octet-stream", "application/exi", "application/json", "application/link-format", "application/senml+json", "application/nanoservice-tlv", "application/vnd.oma.lwm2m+text", "application/vnd.oma.lwm2m+opaq", "application/vnd.oma.lwm2m+tlv", "application/vnd.oma.lwm2m+json"
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
            if (endpointName != null) localVarPathParams.Add("endpointName", Configuration.ApiClient.ParameterToString(endpointName)); // path parameter
            if (resourcePath != null) localVarPathParams.Add("resourcePath", Configuration.ApiClient.ParameterToString(resourcePath)); // path parameter
            
            if (noResp != null) localVarQueryParams.Add("noResp", Configuration.ApiClient.ParameterToString(noResp)); // query parameter
            
            
            
            if (resourceValue.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(resourceValue); // http body (model) parameter
            }
            else
            {
                localVarPostBody = resourceValue; // byte array
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
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathPut: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2EndpointsEndpointNameResourcePathPut: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<AsyncID>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AsyncID) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AsyncID)));
            
        }
        
    }
    
}
