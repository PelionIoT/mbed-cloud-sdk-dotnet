# mds.Api.NotificationsApi

All URIs are relative to *https://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**V2NotificationCallbackPut**](NotificationsApi.md#v2notificationcallbackput) | **PUT** /v2/notification/callback | Register a callback URL
[**V2NotificationPullGet**](NotificationsApi.md#v2notificationpullget) | **GET** /v2/notification/pull | Get notifications using Long Poll


<a name="v2notificationcallbackput"></a>
# **V2NotificationCallbackPut**
> void V2NotificationCallbackPut (Webhook webhook)

Register a callback URL

Register a URL to which the server should deliver notifications of the subscribed resource changes. To get notifications pushed you need to also place the subscriptions.  Notifications are delivered as PUT messages to the HTTP server defined by the client with a subscription server message. The given URL should be accessible and respond to the PUT request with response code of 200 or 204. mbed Cloud Connect tests the callback URL with empty payload when the URL is registered. For more information on callback notification, see NotificationData.  **Note**: Only one callback URL per access-key can be active. If you register a new URL when another one is already active, the old URL is replaced by the new. 

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2NotificationCallbackPutExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new NotificationsApi();
            var webhook = new Webhook(); // Webhook | A json object that contains the URL to which notifications need to be sent, and the optional headers. 

            try
            {
                // Register a callback URL
                apiInstance.V2NotificationCallbackPut(webhook);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling NotificationsApi.V2NotificationCallbackPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **webhook** | [**Webhook**](Webhook.md)| A json object that contains the URL to which notifications need to be sent, and the optional headers.  | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2notificationpullget"></a>
# **V2NotificationPullGet**
> NotificationMessage V2NotificationPullGet ()

Get notifications using Long Poll

In this case, notifications are delivered through HTTP long-poll requests. The HTTP request is kept open until an event notification or a batch of event notifications are delivered to the client or the request times out (response code 204). In both cases, the client should open a new polling connection after the previous one closes. You must have a persistent connection (Connection keep-alive header in the request) to avoid excess TLS handshakes.  **Note:** If it is not possible to have a public facing callback URL, for example when developing on your local machine, you can use long polling to check for new messages. However, to reduce network traffic and to increase performance we recommend that you use callback URLs (webhooks) whenever possible. 

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2NotificationPullGetExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new NotificationsApi();

            try
            {
                // Get notifications using Long Poll
                NotificationMessage result = apiInstance.V2NotificationPullGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling NotificationsApi.V2NotificationPullGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NotificationMessage**](NotificationMessage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

