# mds.Api.NotificationsApi

All URIs are relative to *https://api.us-east-1.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**V2NotificationCallbackPut**](NotificationsApi.md#v2notificationcallbackput) | **PUT** /v2/notification/callback | Register a callback URL
[**V2NotificationPullDelete**](NotificationsApi.md#v2notificationpulldelete) | **DELETE** /v2/notification/pull | Delete notification Long Poll channel
[**V2NotificationPullGet**](NotificationsApi.md#v2notificationpullget) | **GET** /v2/notification/pull | Get notifications using Long Poll


<a name="v2notificationcallbackput"></a>
# **V2NotificationCallbackPut**
> void V2NotificationCallbackPut (Webhook webhook)

Register a callback URL

Register a URL to which the server should deliver notifications of the subscribed resource changes. To get notifications pushed you need to also place the subscriptions.  The maximum length of URL, header keys and values, all combined, is 400 characters.  Notifications are delivered as PUT messages to the HTTP server defined by the client with a subscription server message.  The given URL should be accessible and respond to the PUT request with response code of 200 or 204. Mbed Cloud Connect  tests the callback URL with an empty payload when the URL is registered. For more information on callback notification, see [NotificationMessage](/docs/v1.2/service-api-references/connect-api.html#notificationmessage).  **Optional headers in a callback message:**  You can set optional headers to a callback in a [Webhook](/docs/v1.2/service-api-references/connect-api.html#v2-notification-callback) object. The Mbed Cloud Connect will include the header and key pairs to the notification messages send to callback URL. As the callback URL's are API key specific also the headers are.   One possible use for the additional headers is to check the origin of a PUT request and also distinguish the application (API key) to which the notification belongs to.  **Note**: Only one callback URL per an API key can be active. If you register a new URL while another one is already active,  it replaces the active one. There can be only one notification channel at a time. If the Long Poll notification is already present  you need to delete it before setting the callback URL.  **Expiration of a callback URL:**   A callback can expire when Mbed DS cannot deliver a notification due to a connection timeout or  error response (4xx or 5xx). After each delivery failure, mbed DS sets an exponential back off time and makes a retry attempt  after that. The first retry delay is 1 second, then 2s, 4s, 8s, ..., 2min, 2min. The maximum retry delay is 2 minutes.  The callback URL will be removed if all retries fail withing 24 hours. More about [notification sending logic](/docs/v1.2/connecting/event-notification.html).  **Example usage:**  This example command shows how to set your callback URL and API key. It also sets an optional header authorization. When Mbed Cloud Connect calls your callback URL, the call contains the authorization header with the defined value.          curl -X PUT \\       https://api.us-east-1.mbedcloud.com/v2/notification/callback \\       -H 'authorization: Bearer {api-key}' \\       -H 'content-type: application/json' \\       -d '{       \"url\": \"{callback-url}\",       \"headers\": {\"authorization\" : \"f4b93d6e-4652-4874-82e4-41a3ced0cd56\"}       }' 

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
            var webhook = new Webhook(); // Webhook | A json object that contains the optional headers and the URL to which the notifications need to be sent. 

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
 **webhook** | [**Webhook**](Webhook.md)| A json object that contains the optional headers and the URL to which the notifications need to be sent.  | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2notificationpulldelete"></a>
# **V2NotificationPullDelete**
> void V2NotificationPullDelete ()

Delete notification Long Poll channel

To delete a notification Long Poll channel. This is required to change the channel from Long Poll to a callback.  **Example usage:**      curl -X DELETE https://api.us-east-1.mbedcloud.com/v2/notification/pull -H 'authorization: Bearer {api-key}'      

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2NotificationPullDeleteExample
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
                // Delete notification Long Poll channel
                apiInstance.V2NotificationPullDelete();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling NotificationsApi.V2NotificationPullDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2notificationpullget"></a>
# **V2NotificationPullGet**
> NotificationMessage V2NotificationPullGet ()

Get notifications using Long Poll

In this case, notifications are delivered through HTTP long poll requests. The HTTP request is kept open until an event notification or a batch of event notifications are delivered to the client or the request times out  (response code 204). In both cases, the client should open a new polling connection after the previous one closes. Only a single long polling connection per API key can be ongoing at any given time. You must have a persistent connection (Connection keep-alive header in the request) to avoid excess  TLS handshakes.  **Note:** If it is not possible to have a public facing callback URL, for example when developing on your local machine, you can use long polling to check for new messages. However, long polling is deprecated and will likely be replaced in future. It is meant only for experimentation and not for commercial usage. The proper method to receive notifications is via [Notification Callback](/docs/v1.2/service-api-references/connect-api.html#v2-notification-callback). Only a single notification channel per API key can exist in Mbed Cloud Connect at a time. If a callback notification channel already exists, you need to delete it before creating a long poll notification channel, and vice-versa.  **Example usage:**      curl -X GET https://api.us-east-1.mbedcloud.com/v2/notification/pull -H 'authorization: Bearer {api-key}' 

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

