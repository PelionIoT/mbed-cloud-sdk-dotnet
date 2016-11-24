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
    public interface INotificationsApi
    {
        #region Synchronous Operations
        
        /// <summary>
        /// Register a callback URL
        /// </summary>
        /// <remarks>
        /// Register a URL to which the server should deliver notifications of the subscribed resource changes. To get notifications\npushed you need to also place the subscriptions.\n\nNotifications are delivered as PUT messages to the HTTP server defined by the client with a subscription server message. \nThe given URL should be accessible and respond to the PUT request with response code of 200 or 204. mbed Cloud Connect \ntests the callback URL with empty payload when the URL is registered. For more information on callback notification, see \nNotificationData.\n\n**Note**: Only one callback URL per access-key can be active. If you register a new URL \nwhen another one is already active, the old URL is replaced by the new.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="webhook">A json object that contains the URL to which notifications need to \nbe sent, and the optional headers.\n</param>
        /// <returns></returns>
        void V2NotificationCallbackPut (Webhook webhook);
  
        /// <summary>
        /// Register a callback URL
        /// </summary>
        /// <remarks>
        /// Register a URL to which the server should deliver notifications of the subscribed resource changes. To get notifications\npushed you need to also place the subscriptions.\n\nNotifications are delivered as PUT messages to the HTTP server defined by the client with a subscription server message. \nThe given URL should be accessible and respond to the PUT request with response code of 200 or 204. mbed Cloud Connect \ntests the callback URL with empty payload when the URL is registered. For more information on callback notification, see \nNotificationData.\n\n**Note**: Only one callback URL per access-key can be active. If you register a new URL \nwhen another one is already active, the old URL is replaced by the new.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="webhook">A json object that contains the URL to which notifications need to \nbe sent, and the optional headers.\n</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> V2NotificationCallbackPutWithHttpInfo (Webhook webhook);
        
        /// <summary>
        /// Get notifications using Long Poll
        /// </summary>
        /// <remarks>
        /// In this case, notifications are delivered through HTTP long-poll requests. The HTTP request is kept open \nuntil an event notification or a batch of event notifications are delivered to the client or the request times out \n(response code 204). In both cases, the client should open a new polling connection after the previous one closes. \nYou must have a persistent connection (Connection keep-alive header in the request) to avoid excess \nTLS handshakes.\n\n**Note:** If it is not possible to have a public facing callback URL, for example when developing on your local machine, \nyou can use long polling to check for new messages. However, to reduce network traffic and to increase performance \nwe recommend that you use callback URLs (webhooks) whenever possible.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>NotificationMessage</returns>
        NotificationMessage V2NotificationPullGet ();
  
        /// <summary>
        /// Get notifications using Long Poll
        /// </summary>
        /// <remarks>
        /// In this case, notifications are delivered through HTTP long-poll requests. The HTTP request is kept open \nuntil an event notification or a batch of event notifications are delivered to the client or the request times out \n(response code 204). In both cases, the client should open a new polling connection after the previous one closes. \nYou must have a persistent connection (Connection keep-alive header in the request) to avoid excess \nTLS handshakes.\n\n**Note:** If it is not possible to have a public facing callback URL, for example when developing on your local machine, \nyou can use long polling to check for new messages. However, to reduce network traffic and to increase performance \nwe recommend that you use callback URLs (webhooks) whenever possible.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of NotificationMessage</returns>
        ApiResponse<NotificationMessage> V2NotificationPullGetWithHttpInfo ();
        
        #endregion Synchronous Operations
        
        #region Asynchronous Operations
        
        /// <summary>
        /// Register a callback URL
        /// </summary>
        /// <remarks>
        /// Register a URL to which the server should deliver notifications of the subscribed resource changes. To get notifications\npushed you need to also place the subscriptions.\n\nNotifications are delivered as PUT messages to the HTTP server defined by the client with a subscription server message. \nThe given URL should be accessible and respond to the PUT request with response code of 200 or 204. mbed Cloud Connect \ntests the callback URL with empty payload when the URL is registered. For more information on callback notification, see \nNotificationData.\n\n**Note**: Only one callback URL per access-key can be active. If you register a new URL \nwhen another one is already active, the old URL is replaced by the new.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="webhook">A json object that contains the URL to which notifications need to \nbe sent, and the optional headers.\n</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task V2NotificationCallbackPutAsync (Webhook webhook);

        /// <summary>
        /// Register a callback URL
        /// </summary>
        /// <remarks>
        /// Register a URL to which the server should deliver notifications of the subscribed resource changes. To get notifications\npushed you need to also place the subscriptions.\n\nNotifications are delivered as PUT messages to the HTTP server defined by the client with a subscription server message. \nThe given URL should be accessible and respond to the PUT request with response code of 200 or 204. mbed Cloud Connect \ntests the callback URL with empty payload when the URL is registered. For more information on callback notification, see \nNotificationData.\n\n**Note**: Only one callback URL per access-key can be active. If you register a new URL \nwhen another one is already active, the old URL is replaced by the new.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="webhook">A json object that contains the URL to which notifications need to \nbe sent, and the optional headers.\n</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> V2NotificationCallbackPutAsyncWithHttpInfo (Webhook webhook);
        
        /// <summary>
        /// Get notifications using Long Poll
        /// </summary>
        /// <remarks>
        /// In this case, notifications are delivered through HTTP long-poll requests. The HTTP request is kept open \nuntil an event notification or a batch of event notifications are delivered to the client or the request times out \n(response code 204). In both cases, the client should open a new polling connection after the previous one closes. \nYou must have a persistent connection (Connection keep-alive header in the request) to avoid excess \nTLS handshakes.\n\n**Note:** If it is not possible to have a public facing callback URL, for example when developing on your local machine, \nyou can use long polling to check for new messages. However, to reduce network traffic and to increase performance \nwe recommend that you use callback URLs (webhooks) whenever possible.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of NotificationMessage</returns>
        System.Threading.Tasks.Task<NotificationMessage> V2NotificationPullGetAsync ();

        /// <summary>
        /// Get notifications using Long Poll
        /// </summary>
        /// <remarks>
        /// In this case, notifications are delivered through HTTP long-poll requests. The HTTP request is kept open \nuntil an event notification or a batch of event notifications are delivered to the client or the request times out \n(response code 204). In both cases, the client should open a new polling connection after the previous one closes. \nYou must have a persistent connection (Connection keep-alive header in the request) to avoid excess \nTLS handshakes.\n\n**Note:** If it is not possible to have a public facing callback URL, for example when developing on your local machine, \nyou can use long polling to check for new messages. However, to reduce network traffic and to increase performance \nwe recommend that you use callback URLs (webhooks) whenever possible.\n
        /// </remarks>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (NotificationMessage)</returns>
        System.Threading.Tasks.Task<ApiResponse<NotificationMessage>> V2NotificationPullGetAsyncWithHttpInfo ();
        
        #endregion Asynchronous Operations
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class NotificationsApi : INotificationsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public NotificationsApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public NotificationsApi(Configuration configuration = null)
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
        /// Register a callback URL Register a URL to which the server should deliver notifications of the subscribed resource changes. To get notifications\npushed you need to also place the subscriptions.\n\nNotifications are delivered as PUT messages to the HTTP server defined by the client with a subscription server message. \nThe given URL should be accessible and respond to the PUT request with response code of 200 or 204. mbed Cloud Connect \ntests the callback URL with empty payload when the URL is registered. For more information on callback notification, see \nNotificationData.\n\n**Note**: Only one callback URL per access-key can be active. If you register a new URL \nwhen another one is already active, the old URL is replaced by the new.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="webhook">A json object that contains the URL to which notifications need to \nbe sent, and the optional headers.\n</param> 
        /// <returns></returns>
        public void V2NotificationCallbackPut (Webhook webhook)
        {
             V2NotificationCallbackPutWithHttpInfo(webhook);
        }

        /// <summary>
        /// Register a callback URL Register a URL to which the server should deliver notifications of the subscribed resource changes. To get notifications\npushed you need to also place the subscriptions.\n\nNotifications are delivered as PUT messages to the HTTP server defined by the client with a subscription server message. \nThe given URL should be accessible and respond to the PUT request with response code of 200 or 204. mbed Cloud Connect \ntests the callback URL with empty payload when the URL is registered. For more information on callback notification, see \nNotificationData.\n\n**Note**: Only one callback URL per access-key can be active. If you register a new URL \nwhen another one is already active, the old URL is replaced by the new.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="webhook">A json object that contains the URL to which notifications need to \nbe sent, and the optional headers.\n</param> 
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> V2NotificationCallbackPutWithHttpInfo (Webhook webhook)
        {
            
            // verify the required parameter 'webhook' is set
            if (webhook == null)
                throw new ApiException(400, "Missing required parameter 'webhook' when calling NotificationsApi->V2NotificationCallbackPut");
            
    
            var localVarPath = "/v2/notification/callback";
    
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
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            
            
            
            if (webhook.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(webhook); // http body (model) parameter
            }
            else
            {
                localVarPostBody = webhook; // byte array
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
                throw new ApiException (localVarStatusCode, "Error calling V2NotificationCallbackPut: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2NotificationCallbackPut: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        
        /// <summary>
        /// Register a callback URL Register a URL to which the server should deliver notifications of the subscribed resource changes. To get notifications\npushed you need to also place the subscriptions.\n\nNotifications are delivered as PUT messages to the HTTP server defined by the client with a subscription server message. \nThe given URL should be accessible and respond to the PUT request with response code of 200 or 204. mbed Cloud Connect \ntests the callback URL with empty payload when the URL is registered. For more information on callback notification, see \nNotificationData.\n\n**Note**: Only one callback URL per access-key can be active. If you register a new URL \nwhen another one is already active, the old URL is replaced by the new.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="webhook">A json object that contains the URL to which notifications need to \nbe sent, and the optional headers.\n</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task V2NotificationCallbackPutAsync (Webhook webhook)
        {
             await V2NotificationCallbackPutAsyncWithHttpInfo(webhook);

        }

        /// <summary>
        /// Register a callback URL Register a URL to which the server should deliver notifications of the subscribed resource changes. To get notifications\npushed you need to also place the subscriptions.\n\nNotifications are delivered as PUT messages to the HTTP server defined by the client with a subscription server message. \nThe given URL should be accessible and respond to the PUT request with response code of 200 or 204. mbed Cloud Connect \ntests the callback URL with empty payload when the URL is registered. For more information on callback notification, see \nNotificationData.\n\n**Note**: Only one callback URL per access-key can be active. If you register a new URL \nwhen another one is already active, the old URL is replaced by the new.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="webhook">A json object that contains the URL to which notifications need to \nbe sent, and the optional headers.\n</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> V2NotificationCallbackPutAsyncWithHttpInfo (Webhook webhook)
        {
            // verify the required parameter 'webhook' is set
            if (webhook == null) throw new ApiException(400, "Missing required parameter 'webhook' when calling V2NotificationCallbackPut");
            
    
            var localVarPath = "/v2/notification/callback";
    
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
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            
            
            
            if (webhook.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(webhook); // http body (model) parameter
            }
            else
            {
                localVarPostBody = webhook; // byte array
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
                throw new ApiException (localVarStatusCode, "Error calling V2NotificationCallbackPut: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2NotificationCallbackPut: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        
        /// <summary>
        /// Get notifications using Long Poll In this case, notifications are delivered through HTTP long-poll requests. The HTTP request is kept open \nuntil an event notification or a batch of event notifications are delivered to the client or the request times out \n(response code 204). In both cases, the client should open a new polling connection after the previous one closes. \nYou must have a persistent connection (Connection keep-alive header in the request) to avoid excess \nTLS handshakes.\n\n**Note:** If it is not possible to have a public facing callback URL, for example when developing on your local machine, \nyou can use long polling to check for new messages. However, to reduce network traffic and to increase performance \nwe recommend that you use callback URLs (webhooks) whenever possible.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>NotificationMessage</returns>
        public NotificationMessage V2NotificationPullGet ()
        {
             ApiResponse<NotificationMessage> localVarResponse = V2NotificationPullGetWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get notifications using Long Poll In this case, notifications are delivered through HTTP long-poll requests. The HTTP request is kept open \nuntil an event notification or a batch of event notifications are delivered to the client or the request times out \n(response code 204). In both cases, the client should open a new polling connection after the previous one closes. \nYou must have a persistent connection (Connection keep-alive header in the request) to avoid excess \nTLS handshakes.\n\n**Note:** If it is not possible to have a public facing callback URL, for example when developing on your local machine, \nyou can use long polling to check for new messages. However, to reduce network traffic and to increase performance \nwe recommend that you use callback URLs (webhooks) whenever possible.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of NotificationMessage</returns>
        public ApiResponse< NotificationMessage > V2NotificationPullGetWithHttpInfo ()
        {
            
    
            var localVarPath = "/v2/notification/pull";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V2NotificationPullGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2NotificationPullGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<NotificationMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (NotificationMessage) Configuration.ApiClient.Deserialize(localVarResponse, typeof(NotificationMessage)));
            
        }

        
        /// <summary>
        /// Get notifications using Long Poll In this case, notifications are delivered through HTTP long-poll requests. The HTTP request is kept open \nuntil an event notification or a batch of event notifications are delivered to the client or the request times out \n(response code 204). In both cases, the client should open a new polling connection after the previous one closes. \nYou must have a persistent connection (Connection keep-alive header in the request) to avoid excess \nTLS handshakes.\n\n**Note:** If it is not possible to have a public facing callback URL, for example when developing on your local machine, \nyou can use long polling to check for new messages. However, to reduce network traffic and to increase performance \nwe recommend that you use callback URLs (webhooks) whenever possible.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of NotificationMessage</returns>
        public async System.Threading.Tasks.Task<NotificationMessage> V2NotificationPullGetAsync ()
        {
             ApiResponse<NotificationMessage> localVarResponse = await V2NotificationPullGetAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get notifications using Long Poll In this case, notifications are delivered through HTTP long-poll requests. The HTTP request is kept open \nuntil an event notification or a batch of event notifications are delivered to the client or the request times out \n(response code 204). In both cases, the client should open a new polling connection after the previous one closes. \nYou must have a persistent connection (Connection keep-alive header in the request) to avoid excess \nTLS handshakes.\n\n**Note:** If it is not possible to have a public facing callback URL, for example when developing on your local machine, \nyou can use long polling to check for new messages. However, to reduce network traffic and to increase performance \nwe recommend that you use callback URLs (webhooks) whenever possible.\n
        /// </summary>
        /// <exception cref="mds.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (NotificationMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<NotificationMessage>> V2NotificationPullGetAsyncWithHttpInfo ()
        {
            
    
            var localVarPath = "/v2/notification/pull";
    
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
                throw new ApiException (localVarStatusCode, "Error calling V2NotificationPullGet: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling V2NotificationPullGet: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<NotificationMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (NotificationMessage) Configuration.ApiClient.Deserialize(localVarResponse, typeof(NotificationMessage)));
            
        }
        
    }
    
}
