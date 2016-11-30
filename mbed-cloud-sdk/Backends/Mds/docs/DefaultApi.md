# mds.Api.DefaultApi

All URIs are relative to *https://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**V2NotificationCallbackDelete**](DefaultApi.md#v2notificationcallbackdelete) | **DELETE** /v2/notification/callback | Delete callback URL
[**V2NotificationCallbackGet**](DefaultApi.md#v2notificationcallbackget) | **GET** /v2/notification/callback | Check callback URL


<a name="v2notificationcallbackdelete"></a>
# **V2NotificationCallbackDelete**
> void V2NotificationCallbackDelete ()

Delete callback URL

Deletes the callback URL.

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2NotificationCallbackDeleteExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();

            try
            {
                // Delete callback URL
                apiInstance.V2NotificationCallbackDelete();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.V2NotificationCallbackDelete: " + e.Message );
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
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2notificationcallbackget"></a>
# **V2NotificationCallbackGet**
> void V2NotificationCallbackGet ()

Check callback URL

Shows the current callback URL if exists.

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2NotificationCallbackGetExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();

            try
            {
                // Check callback URL
                apiInstance.V2NotificationCallbackGet();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.V2NotificationCallbackGet: " + e.Message );
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
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

