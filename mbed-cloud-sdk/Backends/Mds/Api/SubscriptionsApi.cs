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
    public interface ISubscriptionsApi
    {
        #region Synchronous Operations
        
        /// <summary>
        /// Remove all subscriptions
        /// </summary>
        /// <remarks>
        /// Removes subscriptions from every endpoint and resource. Note that this does not remove pre-subscriptions.
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        void V2SubscriptionsDelete ();
  
        /// <summary>
        /// Remove all subscriptions
        /// </summary>
        /// <remarks>
        /// Removes subscriptions from every endpoint and resource. Note that this does not remove pre-subscriptions.
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> V2SubscriptionsDeleteWithHttpInfo ();
        
        /// <summary>
        /// Delete subscriptions from an endpoint
        /// </summary>
        /// <remarks>
        /// Deletes all resource subscriptions in a single endpoint.
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an exact match.\nYou cannot use wildcards here.\n</param>
        /// <returns></returns>
        void V2SubscriptionsEndpointNameDelete (string endpointName);
  
        /// <summary>
        /// Delete subscriptions from an endpoint
        /// </summary>
        /// <remarks>
        /// Deletes all resource subscriptions in a single endpoint.
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an exact match.\nYou cannot use wildcards here.\n</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> V2SubscriptionsEndpointNameDeleteWithHttpInfo (string endpointName);
        
        /// <summary>
        /// Read endpoints subscriptions
        /// </summary>
        /// <remarks>
        /// Lists all subscribed resources from a single endpoint.
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <returns></returns>
        void V2SubscriptionsEndpointNameGet (string endpointName);
  
        /// <summary>
        /// Read endpoints subscriptions
        /// </summary>
        /// <remarks>
        /// Lists all subscribed resources from a single endpoint.
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> V2SubscriptionsEndpointNameGetWithHttpInfo (string endpointName);
        
        /// <summary>
        /// Remove a subscription
        /// </summary>
        /// <remarks>
        /// To remove an existing subscription from a resource path.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <returns></returns>
        void V2SubscriptionsEndpointNameResourcePathDelete (string endpointName, string resourcePath);
  
        /// <summary>
        /// Remove a subscription
        /// </summary>
        /// <remarks>
        /// To remove an existing subscription from a resource path.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> V2SubscriptionsEndpointNameResourcePathDeleteWithHttpInfo (string endpointName, string resourcePath);
        
        /// <summary>
        /// Read subscription status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <returns></returns>
        void V2SubscriptionsEndpointNameResourcePathGet (string endpointName, string resourcePath);
  
        /// <summary>
        /// Read subscription status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> V2SubscriptionsEndpointNameResourcePathGetWithHttpInfo (string endpointName, string resourcePath);
        
        /// <summary>
        /// Subscribe to a resource path
        /// </summary>
        /// <remarks>
        /// The mbed Cloud Connect eventing model consists of observable resources.\n\nThis means that endpoints can deliver updated resource content, periodically or with a more sophisticated\nsolution-dependent logic. The OMA LWM2M resource model including objects, object instances,\nresources and resource instances is also supported.\n\nApplications can subscribe to objects, object instances or individual resources to make the device\nto provide value change notifications to mbed Cloud Connect service. An application needs to call a\n/notification/callback method to get mbed Cloud Connect to push a notification of the resource changes.\nYou can also use /subscriptions to set a pre-subscription.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s URL.\n</param>
        /// <returns></returns>
        void V2SubscriptionsEndpointNameResourcePathPut (string endpointName, string resourcePath);
  
        /// <summary>
        /// Subscribe to a resource path
        /// </summary>
        /// <remarks>
        /// The mbed Cloud Connect eventing model consists of observable resources.\n\nThis means that endpoints can deliver updated resource content, periodically or with a more sophisticated\nsolution-dependent logic. The OMA LWM2M resource model including objects, object instances,\nresources and resource instances is also supported.\n\nApplications can subscribe to objects, object instances or individual resources to make the device\nto provide value change notifications to mbed Cloud Connect service. An application needs to call a\n/notification/callback method to get mbed Cloud Connect to push a notification of the resource changes.\nYou can also use /subscriptions to set a pre-subscription.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s URL.\n</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> V2SubscriptionsEndpointNameResourcePathPutWithHttpInfo (string endpointName, string resourcePath);
        
        /// <summary>
        /// Get pre-subscriptions
        /// </summary>
        /// <remarks>
        /// You can retrieve the pre-subscription data by using a GET operation. The server returns with the same JSON structure\nas described above. If there are no pre-subscribed resources, it returns with an empty array.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        void V2SubscriptionsGet ();
  
        /// <summary>
        /// Get pre-subscriptions
        /// </summary>
        /// <remarks>
        /// You can retrieve the pre-subscription data by using a GET operation. The server returns with the same JSON structure\nas described above. If there are no pre-subscribed resources, it returns with an empty array.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> V2SubscriptionsGetWithHttpInfo ();
        
        /// <summary>
        /// Set pre-subscriptions
        /// </summary>
        /// <remarks>
        /// Pre-subscription is a set of rules and patterns put by the application. When an endpoint registers\nand its name, type and registered resources match the pre-subscription data, mbed Cloud Connect sends\nsubscription requests to the device automatically. The pattern may include the endpoint name\n(optionally having an \\* character at the end), endpoint type, a list of resources or expressions\nwith an \\* character at the end. The pre-subscription concerns all the endpoints that are already\nregistered and the server sends subscription requests to the devices immediately when the patterns are set.\nThere is only one pre-subscribe array, so changing the pre-subscription data removes all the previous subscriptions.\nTo remove the pre-subscription data, put an empty array as a rule.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="presubsription">Array of pre-subscriptions.</param>
        /// <returns></returns>
        void V2SubscriptionsPut (PresubscriptionArray presubsription);
  
        /// <summary>
        /// Set pre-subscriptions
        /// </summary>
        /// <remarks>
        /// Pre-subscription is a set of rules and patterns put by the application. When an endpoint registers\nand its name, type and registered resources match the pre-subscription data, mbed Cloud Connect sends\nsubscription requests to the device automatically. The pattern may include the endpoint name\n(optionally having an \\* character at the end), endpoint type, a list of resources or expressions\nwith an \\* character at the end. The pre-subscription concerns all the endpoints that are already\nregistered and the server sends subscription requests to the devices immediately when the patterns are set.\nThere is only one pre-subscribe array, so changing the pre-subscription data removes all the previous subscriptions.\nTo remove the pre-subscription data, put an empty array as a rule.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="presubsription">Array of pre-subscriptions.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> V2SubscriptionsPutWithHttpInfo (PresubscriptionArray presubsription);
        
        #endregion Synchronous Operations
        
        #region Asynchronous Operations
        
        /// <summary>
        /// Remove all subscriptions
        /// </summary>
        /// <remarks>
        /// Removes subscriptions from every endpoint and resource. Note that this does not remove pre-subscriptions.
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task V2SubscriptionsDeleteAsync ();

        /// <summary>
        /// Remove all subscriptions
        /// </summary>
        /// <remarks>
        /// Removes subscriptions from every endpoint and resource. Note that this does not remove pre-subscriptions.
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsDeleteAsyncWithHttpInfo ();
        
        /// <summary>
        /// Delete subscriptions from an endpoint
        /// </summary>
        /// <remarks>
        /// Deletes all resource subscriptions in a single endpoint.
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an exact match.\nYou cannot use wildcards here.\n</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task V2SubscriptionsEndpointNameDeleteAsync (string endpointName);

        /// <summary>
        /// Delete subscriptions from an endpoint
        /// </summary>
        /// <remarks>
        /// Deletes all resource subscriptions in a single endpoint.
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an exact match.\nYou cannot use wildcards here.\n</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsEndpointNameDeleteAsyncWithHttpInfo (string endpointName);
        
        /// <summary>
        /// Read endpoints subscriptions
        /// </summary>
        /// <remarks>
        /// Lists all subscribed resources from a single endpoint.
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task V2SubscriptionsEndpointNameGetAsync (string endpointName);

        /// <summary>
        /// Read endpoints subscriptions
        /// </summary>
        /// <remarks>
        /// Lists all subscribed resources from a single endpoint.
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsEndpointNameGetAsyncWithHttpInfo (string endpointName);
        
        /// <summary>
        /// Remove a subscription
        /// </summary>
        /// <remarks>
        /// To remove an existing subscription from a resource path.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task V2SubscriptionsEndpointNameResourcePathDeleteAsync (string endpointName, string resourcePath);

        /// <summary>
        /// Remove a subscription
        /// </summary>
        /// <remarks>
        /// To remove an existing subscription from a resource path.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsEndpointNameResourcePathDeleteAsyncWithHttpInfo (string endpointName, string resourcePath);
        
        /// <summary>
        /// Read subscription status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task V2SubscriptionsEndpointNameResourcePathGetAsync (string endpointName, string resourcePath);

        /// <summary>
        /// Read subscription status
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsEndpointNameResourcePathGetAsyncWithHttpInfo (string endpointName, string resourcePath);
        
        /// <summary>
        /// Subscribe to a resource path
        /// </summary>
        /// <remarks>
        /// The mbed Cloud Connect eventing model consists of observable resources.\n\nThis means that endpoints can deliver updated resource content, periodically or with a more sophisticated\nsolution-dependent logic. The OMA LWM2M resource model including objects, object instances,\nresources and resource instances is also supported.\n\nApplications can subscribe to objects, object instances or individual resources to make the device\nto provide value change notifications to mbed Cloud Connect service. An application needs to call a\n/notification/callback method to get mbed Cloud Connect to push a notification of the resource changes.\nYou can also use /subscriptions to set a pre-subscription.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s URL.\n</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task V2SubscriptionsEndpointNameResourcePathPutAsync (string endpointName, string resourcePath);

        /// <summary>
        /// Subscribe to a resource path
        /// </summary>
        /// <remarks>
        /// The mbed Cloud Connect eventing model consists of observable resources.\n\nThis means that endpoints can deliver updated resource content, periodically or with a more sophisticated\nsolution-dependent logic. The OMA LWM2M resource model including objects, object instances,\nresources and resource instances is also supported.\n\nApplications can subscribe to objects, object instances or individual resources to make the device\nto provide value change notifications to mbed Cloud Connect service. An application needs to call a\n/notification/callback method to get mbed Cloud Connect to push a notification of the resource changes.\nYou can also use /subscriptions to set a pre-subscription.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s URL.\n</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsEndpointNameResourcePathPutAsyncWithHttpInfo (string endpointName, string resourcePath);
        
        /// <summary>
        /// Get pre-subscriptions
        /// </summary>
        /// <remarks>
        /// You can retrieve the pre-subscription data by using a GET operation. The server returns with the same JSON structure\nas described above. If there are no pre-subscribed resources, it returns with an empty array.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task V2SubscriptionsGetAsync ();

        /// <summary>
        /// Get pre-subscriptions
        /// </summary>
        /// <remarks>
        /// You can retrieve the pre-subscription data by using a GET operation. The server returns with the same JSON structure\nas described above. If there are no pre-subscribed resources, it returns with an empty array.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsGetAsyncWithHttpInfo ();
        
        /// <summary>
        /// Set pre-subscriptions
        /// </summary>
        /// <remarks>
        /// Pre-subscription is a set of rules and patterns put by the application. When an endpoint registers\nand its name, type and registered resources match the pre-subscription data, mbed Cloud Connect sends\nsubscription requests to the device automatically. The pattern may include the endpoint name\n(optionally having an \\* character at the end), endpoint type, a list of resources or expressions\nwith an \\* character at the end. The pre-subscription concerns all the endpoints that are already\nregistered and the server sends subscription requests to the devices immediately when the patterns are set.\nThere is only one pre-subscribe array, so changing the pre-subscription data removes all the previous subscriptions.\nTo remove the pre-subscription data, put an empty array as a rule.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="presubsription">Array of pre-subscriptions.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task V2SubscriptionsPutAsync (PresubscriptionArray presubsription);

        /// <summary>
        /// Set pre-subscriptions
        /// </summary>
        /// <remarks>
        /// Pre-subscription is a set of rules and patterns put by the application. When an endpoint registers\nand its name, type and registered resources match the pre-subscription data, mbed Cloud Connect sends\nsubscription requests to the device automatically. The pattern may include the endpoint name\n(optionally having an \\* character at the end), endpoint type, a list of resources or expressions\nwith an \\* character at the end. The pre-subscription concerns all the endpoints that are already\nregistered and the server sends subscription requests to the devices immediately when the patterns are set.\nThere is only one pre-subscribe array, so changing the pre-subscription data removes all the previous subscriptions.\nTo remove the pre-subscription data, put an empty array as a rule.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="presubsription">Array of pre-subscriptions.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsPutAsyncWithHttpInfo (PresubscriptionArray presubsription);
        
        #endregion Asynchronous Operations
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class SubscriptionsApi : ISubscriptionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SubscriptionsApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public SubscriptionsApi(Configuration configuration = null)
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
        /// Remove all subscriptions Removes subscriptions from every endpoint and resource. Note that this does not remove pre-subscriptions.
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        public void V2SubscriptionsDelete ()
        {
             V2SubscriptionsDeleteWithHttpInfo();
        }

        /// <summary>
        /// Remove all subscriptions Removes subscriptions from every endpoint and resource. Note that this does not remove pre-subscriptions.
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> V2SubscriptionsDeleteWithHttpInfo ()
        {
            
    
            var localVarPath = "/v2/subscriptions";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsDelete: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsDelete: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        
        /// <summary>
        /// Remove all subscriptions Removes subscriptions from every endpoint and resource. Note that this does not remove pre-subscriptions.
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task V2SubscriptionsDeleteAsync ()
        {
             await V2SubscriptionsDeleteAsyncWithHttpInfo();

        }

        /// <summary>
        /// Remove all subscriptions Removes subscriptions from every endpoint and resource. Note that this does not remove pre-subscriptions.
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsDeleteAsyncWithHttpInfo ()
        {
            
    
            var localVarPath = "/v2/subscriptions";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsDelete: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsDelete: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        
        /// <summary>
        /// Delete subscriptions from an endpoint Deletes all resource subscriptions in a single endpoint.
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an exact match.\nYou cannot use wildcards here.\n</param> 
        /// <returns></returns>
        public void V2SubscriptionsEndpointNameDelete (string endpointName)
        {
             V2SubscriptionsEndpointNameDeleteWithHttpInfo(endpointName);
        }

        /// <summary>
        /// Delete subscriptions from an endpoint Deletes all resource subscriptions in a single endpoint.
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an exact match.\nYou cannot use wildcards here.\n</param> 
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> V2SubscriptionsEndpointNameDeleteWithHttpInfo (string endpointName)
        {
            
            // verify the required parameter 'endpointName' is set
            if (endpointName == null)
                throw new ApiException(400, "Missing required parameter 'endpointName' when calling SubscriptionsApi->V2SubscriptionsEndpointNameDelete");
            
    
            var localVarPath = "/v2/subscriptions/{endpointName}";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameDelete: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameDelete: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        
        /// <summary>
        /// Delete subscriptions from an endpoint Deletes all resource subscriptions in a single endpoint.
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an exact match.\nYou cannot use wildcards here.\n</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task V2SubscriptionsEndpointNameDeleteAsync (string endpointName)
        {
             await V2SubscriptionsEndpointNameDeleteAsyncWithHttpInfo(endpointName);

        }

        /// <summary>
        /// Delete subscriptions from an endpoint Deletes all resource subscriptions in a single endpoint.
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an exact match.\nYou cannot use wildcards here.\n</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsEndpointNameDeleteAsyncWithHttpInfo (string endpointName)
        {
            // verify the required parameter 'endpointName' is set
            if (endpointName == null) throw new ApiException(400, "Missing required parameter 'endpointName' when calling V2SubscriptionsEndpointNameDelete");
            
    
            var localVarPath = "/v2/subscriptions/{endpointName}";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameDelete: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameDelete: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        
        /// <summary>
        /// Read endpoints subscriptions Lists all subscribed resources from a single endpoint.
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that endpoint name must be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <returns></returns>
        public void V2SubscriptionsEndpointNameGet (string endpointName)
        {
             V2SubscriptionsEndpointNameGetWithHttpInfo(endpointName);
        }

        /// <summary>
        /// Read endpoints subscriptions Lists all subscribed resources from a single endpoint.
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that endpoint name must be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> V2SubscriptionsEndpointNameGetWithHttpInfo (string endpointName)
        {
            
            // verify the required parameter 'endpointName' is set
            if (endpointName == null)
                throw new ApiException(400, "Missing required parameter 'endpointName' when calling SubscriptionsApi->V2SubscriptionsEndpointNameGet");
            
    
            var localVarPath = "/v2/subscriptions/{endpointName}";
    
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
                "text/uri-list"
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        
        /// <summary>
        /// Read endpoints subscriptions Lists all subscribed resources from a single endpoint.
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task V2SubscriptionsEndpointNameGetAsync (string endpointName)
        {
             await V2SubscriptionsEndpointNameGetAsyncWithHttpInfo(endpointName);

        }

        /// <summary>
        /// Read endpoints subscriptions Lists all subscribed resources from a single endpoint.
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsEndpointNameGetAsyncWithHttpInfo (string endpointName)
        {
            // verify the required parameter 'endpointName' is set
            if (endpointName == null) throw new ApiException(400, "Missing required parameter 'endpointName' when calling V2SubscriptionsEndpointNameGet");
            
    
            var localVarPath = "/v2/subscriptions/{endpointName}";
    
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
                "text/uri-list"
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        
        /// <summary>
        /// Remove a subscription To remove an existing subscription from a resource path.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <param name="resourcePath">Resource&#39;s url.\n</param> 
        /// <returns></returns>
        public void V2SubscriptionsEndpointNameResourcePathDelete (string endpointName, string resourcePath)
        {
             V2SubscriptionsEndpointNameResourcePathDeleteWithHttpInfo(endpointName, resourcePath);
        }

        /// <summary>
        /// Remove a subscription To remove an existing subscription from a resource path.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <param name="resourcePath">Resource&#39;s url.\n</param> 
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> V2SubscriptionsEndpointNameResourcePathDeleteWithHttpInfo (string endpointName, string resourcePath)
        {
            
            // verify the required parameter 'endpointName' is set
            if (endpointName == null)
                throw new ApiException(400, "Missing required parameter 'endpointName' when calling SubscriptionsApi->V2SubscriptionsEndpointNameResourcePathDelete");
            
            // verify the required parameter 'resourcePath' is set
            if (resourcePath == null)
                throw new ApiException(400, "Missing required parameter 'resourcePath' when calling SubscriptionsApi->V2SubscriptionsEndpointNameResourcePathDelete");
            
    
            var localVarPath = "/v2/subscriptions/{endpointName}/{resourcePath}";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameResourcePathDelete: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameResourcePathDelete: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        
        /// <summary>
        /// Remove a subscription To remove an existing subscription from a resource path.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task V2SubscriptionsEndpointNameResourcePathDeleteAsync (string endpointName, string resourcePath)
        {
             await V2SubscriptionsEndpointNameResourcePathDeleteAsyncWithHttpInfo(endpointName, resourcePath);

        }

        /// <summary>
        /// Remove a subscription To remove an existing subscription from a resource path.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsEndpointNameResourcePathDeleteAsyncWithHttpInfo (string endpointName, string resourcePath)
        {
            // verify the required parameter 'endpointName' is set
            if (endpointName == null) throw new ApiException(400, "Missing required parameter 'endpointName' when calling V2SubscriptionsEndpointNameResourcePathDelete");
            // verify the required parameter 'resourcePath' is set
            if (resourcePath == null) throw new ApiException(400, "Missing required parameter 'resourcePath' when calling V2SubscriptionsEndpointNameResourcePathDelete");
            
    
            var localVarPath = "/v2/subscriptions/{endpointName}/{resourcePath}";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameResourcePathDelete: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameResourcePathDelete: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        
        /// <summary>
        /// Read subscription status 
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <param name="resourcePath">Resource&#39;s url.\n</param> 
        /// <returns></returns>
        public void V2SubscriptionsEndpointNameResourcePathGet (string endpointName, string resourcePath)
        {
             V2SubscriptionsEndpointNameResourcePathGetWithHttpInfo(endpointName, resourcePath);
        }

        /// <summary>
        /// Read subscription status 
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <param name="resourcePath">Resource&#39;s url.\n</param> 
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> V2SubscriptionsEndpointNameResourcePathGetWithHttpInfo (string endpointName, string resourcePath)
        {
            
            // verify the required parameter 'endpointName' is set
            if (endpointName == null)
                throw new ApiException(400, "Missing required parameter 'endpointName' when calling SubscriptionsApi->V2SubscriptionsEndpointNameResourcePathGet");
            
            // verify the required parameter 'resourcePath' is set
            if (resourcePath == null)
                throw new ApiException(400, "Missing required parameter 'resourcePath' when calling SubscriptionsApi->V2SubscriptionsEndpointNameResourcePathGet");
            
    
            var localVarPath = "/v2/subscriptions/{endpointName}/{resourcePath}";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameResourcePathGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameResourcePathGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        
        /// <summary>
        /// Read subscription status 
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task V2SubscriptionsEndpointNameResourcePathGetAsync (string endpointName, string resourcePath)
        {
             await V2SubscriptionsEndpointNameResourcePathGetAsyncWithHttpInfo(endpointName, resourcePath);

        }

        /// <summary>
        /// Read subscription status 
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s url.\n</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsEndpointNameResourcePathGetAsyncWithHttpInfo (string endpointName, string resourcePath)
        {
            // verify the required parameter 'endpointName' is set
            if (endpointName == null) throw new ApiException(400, "Missing required parameter 'endpointName' when calling V2SubscriptionsEndpointNameResourcePathGet");
            // verify the required parameter 'resourcePath' is set
            if (resourcePath == null) throw new ApiException(400, "Missing required parameter 'resourcePath' when calling V2SubscriptionsEndpointNameResourcePathGet");
            
    
            var localVarPath = "/v2/subscriptions/{endpointName}/{resourcePath}";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameResourcePathGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameResourcePathGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        
        /// <summary>
        /// Subscribe to a resource path The mbed Cloud Connect eventing model consists of observable resources.\n\nThis means that endpoints can deliver updated resource content, periodically or with a more sophisticated\nsolution-dependent logic. The OMA LWM2M resource model including objects, object instances,\nresources and resource instances is also supported.\n\nApplications can subscribe to objects, object instances or individual resources to make the device\nto provide value change notifications to mbed Cloud Connect service. An application needs to call a\n/notification/callback method to get mbed Cloud Connect to push a notification of the resource changes.\nYou can also use /subscriptions to set a pre-subscription.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <param name="resourcePath">Resource&#39;s URL.\n</param> 
        /// <returns></returns>
        public void V2SubscriptionsEndpointNameResourcePathPut (string endpointName, string resourcePath)
        {
             V2SubscriptionsEndpointNameResourcePathPutWithHttpInfo(endpointName, resourcePath);
        }

        /// <summary>
        /// Subscribe to a resource path The mbed Cloud Connect eventing model consists of observable resources.\n\nThis means that endpoints can deliver updated resource content, periodically or with a more sophisticated\nsolution-dependent logic. The OMA LWM2M resource model including objects, object instances,\nresources and resource instances is also supported.\n\nApplications can subscribe to objects, object instances or individual resources to make the device\nto provide value change notifications to mbed Cloud Connect service. An application needs to call a\n/notification/callback method to get mbed Cloud Connect to push a notification of the resource changes.\nYou can also use /subscriptions to set a pre-subscription.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param> 
        /// <param name="resourcePath">Resource&#39;s URL.\n</param> 
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> V2SubscriptionsEndpointNameResourcePathPutWithHttpInfo (string endpointName, string resourcePath)
        {
            
            // verify the required parameter 'endpointName' is set
            if (endpointName == null)
                throw new ApiException(400, "Missing required parameter 'endpointName' when calling SubscriptionsApi->V2SubscriptionsEndpointNameResourcePathPut");
            
            // verify the required parameter 'resourcePath' is set
            if (resourcePath == null)
                throw new ApiException(400, "Missing required parameter 'resourcePath' when calling SubscriptionsApi->V2SubscriptionsEndpointNameResourcePathPut");
            
    
            var localVarPath = "/v2/subscriptions/{endpointName}/{resourcePath}";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameResourcePathPut: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameResourcePathPut: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        
        /// <summary>
        /// Subscribe to a resource path The mbed Cloud Connect eventing model consists of observable resources.\n\nThis means that endpoints can deliver updated resource content, periodically or with a more sophisticated\nsolution-dependent logic. The OMA LWM2M resource model including objects, object instances,\nresources and resource instances is also supported.\n\nApplications can subscribe to objects, object instances or individual resources to make the device\nto provide value change notifications to mbed Cloud Connect service. An application needs to call a\n/notification/callback method to get mbed Cloud Connect to push a notification of the resource changes.\nYou can also use /subscriptions to set a pre-subscription.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s URL.\n</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task V2SubscriptionsEndpointNameResourcePathPutAsync (string endpointName, string resourcePath)
        {
             await V2SubscriptionsEndpointNameResourcePathPutAsyncWithHttpInfo(endpointName, resourcePath);

        }

        /// <summary>
        /// Subscribe to a resource path The mbed Cloud Connect eventing model consists of observable resources.\n\nThis means that endpoints can deliver updated resource content, periodically or with a more sophisticated\nsolution-dependent logic. The OMA LWM2M resource model including objects, object instances,\nresources and resource instances is also supported.\n\nApplications can subscribe to objects, object instances or individual resources to make the device\nto provide value change notifications to mbed Cloud Connect service. An application needs to call a\n/notification/callback method to get mbed Cloud Connect to push a notification of the resource changes.\nYou can also use /subscriptions to set a pre-subscription.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="endpointName">A unique identifier for the endpoint. Note that the endpoint name must be an\nexact match. You cannot use wildcards here.\n</param>
        /// <param name="resourcePath">Resource&#39;s URL.\n</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsEndpointNameResourcePathPutAsyncWithHttpInfo (string endpointName, string resourcePath)
        {
            // verify the required parameter 'endpointName' is set
            if (endpointName == null) throw new ApiException(400, "Missing required parameter 'endpointName' when calling V2SubscriptionsEndpointNameResourcePathPut");
            // verify the required parameter 'resourcePath' is set
            if (resourcePath == null) throw new ApiException(400, "Missing required parameter 'resourcePath' when calling V2SubscriptionsEndpointNameResourcePathPut");
            
    
            var localVarPath = "/v2/subscriptions/{endpointName}/{resourcePath}";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameResourcePathPut: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsEndpointNameResourcePathPut: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        
        /// <summary>
        /// Get pre-subscriptions You can retrieve the pre-subscription data by using a GET operation. The server returns with the same JSON structure\nas described above. If there are no pre-subscribed resources, it returns with an empty array.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns></returns>
        public void V2SubscriptionsGet ()
        {
             V2SubscriptionsGetWithHttpInfo();
        }

        /// <summary>
        /// Get pre-subscriptions You can retrieve the pre-subscription data by using a GET operation. The server returns with the same JSON structure\nas described above. If there are no pre-subscribed resources, it returns with an empty array.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> V2SubscriptionsGetWithHttpInfo ()
        {
            
    
            var localVarPath = "/v2/subscriptions";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        
        /// <summary>
        /// Get pre-subscriptions You can retrieve the pre-subscription data by using a GET operation. The server returns with the same JSON structure\nas described above. If there are no pre-subscribed resources, it returns with an empty array.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task V2SubscriptionsGetAsync ()
        {
             await V2SubscriptionsGetAsyncWithHttpInfo();

        }

        /// <summary>
        /// Get pre-subscriptions You can retrieve the pre-subscription data by using a GET operation. The server returns with the same JSON structure\nas described above. If there are no pre-subscribed resources, it returns with an empty array.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsGetAsyncWithHttpInfo ()
        {
            
    
            var localVarPath = "/v2/subscriptions";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        
        /// <summary>
        /// Set pre-subscriptions Pre-subscription is a set of rules and patterns put by the application. When an endpoint registers\nand its name, type and registered resources match the pre-subscription data, mbed Cloud Connect sends\nsubscription requests to the device automatically. The pattern may include the endpoint name\n(optionally having an \\* character at the end), endpoint type, a list of resources or expressions\nwith an \\* character at the end. The pre-subscription concerns all the endpoints that are already\nregistered and the server sends subscription requests to the devices immediately when the patterns are set.\nThere is only one pre-subscribe array, so changing the pre-subscription data removes all the previous subscriptions.\nTo remove the pre-subscription data, put an empty array as a rule.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="presubsription">Array of pre-subscriptions.</param> 
        /// <returns></returns>
        public void V2SubscriptionsPut (PresubscriptionArray presubsription)
        {
             V2SubscriptionsPutWithHttpInfo(presubsription);
        }

        /// <summary>
        /// Set pre-subscriptions Pre-subscription is a set of rules and patterns put by the application. When an endpoint registers\nand its name, type and registered resources match the pre-subscription data, mbed Cloud Connect sends\nsubscription requests to the device automatically. The pattern may include the endpoint name\n(optionally having an \\* character at the end), endpoint type, a list of resources or expressions\nwith an \\* character at the end. The pre-subscription concerns all the endpoints that are already\nregistered and the server sends subscription requests to the devices immediately when the patterns are set.\nThere is only one pre-subscribe array, so changing the pre-subscription data removes all the previous subscriptions.\nTo remove the pre-subscription data, put an empty array as a rule.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="presubsription">Array of pre-subscriptions.</param> 
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> V2SubscriptionsPutWithHttpInfo (PresubscriptionArray presubsription)
        {
            
            // verify the required parameter 'presubsription' is set
            if (presubsription == null)
                throw new ApiException(400, "Missing required parameter 'presubsription' when calling SubscriptionsApi->V2SubscriptionsPut");
            
    
            var localVarPath = "/v2/subscriptions";
    
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
                "text/plain"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            
            
            
            if (presubsription.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(presubsription); // http body (model) parameter
            }
            else
            {
                localVarPostBody = presubsription; // byte array
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsPut: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsPut: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        
        /// <summary>
        /// Set pre-subscriptions Pre-subscription is a set of rules and patterns put by the application. When an endpoint registers\nand its name, type and registered resources match the pre-subscription data, mbed Cloud Connect sends\nsubscription requests to the device automatically. The pattern may include the endpoint name\n(optionally having an \\* character at the end), endpoint type, a list of resources or expressions\nwith an \\* character at the end. The pre-subscription concerns all the endpoints that are already\nregistered and the server sends subscription requests to the devices immediately when the patterns are set.\nThere is only one pre-subscribe array, so changing the pre-subscription data removes all the previous subscriptions.\nTo remove the pre-subscription data, put an empty array as a rule.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="presubsription">Array of pre-subscriptions.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task V2SubscriptionsPutAsync (PresubscriptionArray presubsription)
        {
             await V2SubscriptionsPutAsyncWithHttpInfo(presubsription);

        }

        /// <summary>
        /// Set pre-subscriptions Pre-subscription is a set of rules and patterns put by the application. When an endpoint registers\nand its name, type and registered resources match the pre-subscription data, mbed Cloud Connect sends\nsubscription requests to the device automatically. The pattern may include the endpoint name\n(optionally having an \\* character at the end), endpoint type, a list of resources or expressions\nwith an \\* character at the end. The pre-subscription concerns all the endpoints that are already\nregistered and the server sends subscription requests to the devices immediately when the patterns are set.\nThere is only one pre-subscribe array, so changing the pre-subscription data removes all the previous subscriptions.\nTo remove the pre-subscription data, put an empty array as a rule.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="presubsription">Array of pre-subscriptions.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> V2SubscriptionsPutAsyncWithHttpInfo (PresubscriptionArray presubsription)
        {
            // verify the required parameter 'presubsription' is set
            if (presubsription == null) throw new ApiException(400, "Missing required parameter 'presubsription' when calling V2SubscriptionsPut");
            
    
            var localVarPath = "/v2/subscriptions";
    
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
                "text/plain"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            
            
            
            if (presubsription.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(presubsription); // http body (model) parameter
            }
            else
            {
                localVarPostBody = presubsription; // byte array
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
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsPut: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2SubscriptionsPut: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        
    }
    
}
