# mds.Api.SubscriptionsApi

All URIs are relative to *https://api.us-east-1.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**V2SubscriptionsDelete**](SubscriptionsApi.md#v2subscriptionsdelete) | **DELETE** /v2/subscriptions | Remove all subscriptions
[**V2SubscriptionsDeviceIdDelete**](SubscriptionsApi.md#v2subscriptionsdeviceiddelete) | **DELETE** /v2/subscriptions/{device-id} | Delete subscriptions from an endpoint
[**V2SubscriptionsDeviceIdGet**](SubscriptionsApi.md#v2subscriptionsdeviceidget) | **GET** /v2/subscriptions/{device-id} | Read endpoints subscriptions
[**V2SubscriptionsDeviceIdResourcePathDelete**](SubscriptionsApi.md#v2subscriptionsdeviceidresourcepathdelete) | **DELETE** /v2/subscriptions/{device-id}/{resourcePath} | Remove a subscription
[**V2SubscriptionsDeviceIdResourcePathGet**](SubscriptionsApi.md#v2subscriptionsdeviceidresourcepathget) | **GET** /v2/subscriptions/{device-id}/{resourcePath} | Read subscription status
[**V2SubscriptionsDeviceIdResourcePathPut**](SubscriptionsApi.md#v2subscriptionsdeviceidresourcepathput) | **PUT** /v2/subscriptions/{device-id}/{resourcePath} | Subscribe to a resource path
[**V2SubscriptionsGet**](SubscriptionsApi.md#v2subscriptionsget) | **GET** /v2/subscriptions | Get pre-subscriptions
[**V2SubscriptionsPut**](SubscriptionsApi.md#v2subscriptionsput) | **PUT** /v2/subscriptions | Set pre-subscriptions


<a name="v2subscriptionsdelete"></a>
# **V2SubscriptionsDelete**
> void V2SubscriptionsDelete ()

Remove all subscriptions

Removes subscriptions from every endpoint and resource. Note that this does not remove pre-subscriptions.  **Example usage:**      curl -X DELETE https://api.us-east-1.mbedcloud.com/v2/subscriptions -H 'authorization: Bearer {api-key}'      

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2SubscriptionsDeleteExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new SubscriptionsApi();

            try
            {
                // Remove all subscriptions
                apiInstance.V2SubscriptionsDelete();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.V2SubscriptionsDelete: " + e.Message );
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

<a name="v2subscriptionsdeviceiddelete"></a>
# **V2SubscriptionsDeviceIdDelete**
> void V2SubscriptionsDeviceIdDelete (string deviceId)

Delete subscriptions from an endpoint

Deletes all resource subscriptions in a single endpoint.  **Example usage:**      curl -X DELETE \\       https://api.us-east-1.mbedcloud.com/v2/subscriptions/{device-id} \\       -H 'authorization: Bearer {api-key}'        

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2SubscriptionsDeviceIdDeleteExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new SubscriptionsApi();
            var deviceId = deviceId_example;  // string | A unique Mbed Cloud device ID for the endpoint. Note that the ID must be an exact match. You cannot use wildcards here. 

            try
            {
                // Delete subscriptions from an endpoint
                apiInstance.V2SubscriptionsDeviceIdDelete(deviceId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.V2SubscriptionsDeviceIdDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceId** | **string**| A unique Mbed Cloud device ID for the endpoint. Note that the ID must be an exact match. You cannot use wildcards here.  | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2subscriptionsdeviceidget"></a>
# **V2SubscriptionsDeviceIdGet**
> string V2SubscriptionsDeviceIdGet (string deviceId)

Read endpoints subscriptions

Lists all subscribed resources from a single endpoint.  **Example usage:**      curl -X GET \\       https://api.us-east-1.mbedcloud.com/v2/subscriptions/{device-id} \\       -H 'authorization: Bearer {api-key}'        

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2SubscriptionsDeviceIdGetExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new SubscriptionsApi();
            var deviceId = deviceId_example;  // string | A unique Mbed Cloud device ID for the endpoint. Note that ID must be an exact match. You cannot use wildcards here. 

            try
            {
                // Read endpoints subscriptions
                string result = apiInstance.V2SubscriptionsDeviceIdGet(deviceId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.V2SubscriptionsDeviceIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceId** | **string**| A unique Mbed Cloud device ID for the endpoint. Note that ID must be an exact match. You cannot use wildcards here.  | 

### Return type

**string**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/uri-list

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2subscriptionsdeviceidresourcepathdelete"></a>
# **V2SubscriptionsDeviceIdResourcePathDelete**
> void V2SubscriptionsDeviceIdResourcePathDelete (string deviceId, string resourcePath)

Remove a subscription

To remove an existing subscription from a resource path.  **Example usage:**      curl -X DELETE \\       https://api.us-east-1.mbedcloud.com/v2/subscriptions/{device-id}/{resourcePath} \\       -H 'authorization: Bearer {api-key}'        

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2SubscriptionsDeviceIdResourcePathDeleteExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new SubscriptionsApi();
            var deviceId = deviceId_example;  // string | A unique Mbed Cloud device ID for the endpoint. Note that the ID must be an exact match. You cannot use wildcards here. 
            var resourcePath = resourcePath_example;  // string | The URL of the resource. 

            try
            {
                // Remove a subscription
                apiInstance.V2SubscriptionsDeviceIdResourcePathDelete(deviceId, resourcePath);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.V2SubscriptionsDeviceIdResourcePathDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceId** | **string**| A unique Mbed Cloud device ID for the endpoint. Note that the ID must be an exact match. You cannot use wildcards here.  | 
 **resourcePath** | **string**| The URL of the resource.  | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2subscriptionsdeviceidresourcepathget"></a>
# **V2SubscriptionsDeviceIdResourcePathGet**
> void V2SubscriptionsDeviceIdResourcePathGet (string deviceId, string resourcePath)

Read subscription status

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2SubscriptionsDeviceIdResourcePathGetExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new SubscriptionsApi();
            var deviceId = deviceId_example;  // string | A unique Mbed Cloud device ID for the endpoint. Note that the ID must be an exact match. You cannot use wildcards here. 
            var resourcePath = resourcePath_example;  // string | The URL of the resource. 

            try
            {
                // Read subscription status
                apiInstance.V2SubscriptionsDeviceIdResourcePathGet(deviceId, resourcePath);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.V2SubscriptionsDeviceIdResourcePathGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceId** | **string**| A unique Mbed Cloud device ID for the endpoint. Note that the ID must be an exact match. You cannot use wildcards here.  | 
 **resourcePath** | **string**| The URL of the resource.  | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2subscriptionsdeviceidresourcepathput"></a>
# **V2SubscriptionsDeviceIdResourcePathPut**
> void V2SubscriptionsDeviceIdResourcePathPut (string deviceId, string resourcePath)

Subscribe to a resource path

The Mbed Cloud Connect eventing model consists of observable resources.  This means that endpoints can deliver updated resource content, periodically or with a more sophisticated  solution-dependent logic. The OMA LwM2M resource model including objects, object instances,  resources and resource instances is also supported.  Applications can subscribe to objects, object instances or individual resources to make the device  to provide value change notifications to Mbed Cloud Connect service. An application needs to call a `/notification/callback` method to get Mbed Cloud Connect to push notifications of the resource changes.  The manual subscriptions are removed during a full device registration and applications need to  re-subscribe at that point. To avoid this, you can use `/subscriptions` to set a pre-subscription.  **Example usage:**      curl -X PUT \\       https://api.us-east-1.mbedcloud.com/v2/subscriptions/{device-id}/{resourcePath} \\       -H 'authorization: Bearer {api-key}' 

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2SubscriptionsDeviceIdResourcePathPutExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new SubscriptionsApi();
            var deviceId = deviceId_example;  // string | A unique Mbed Cloud device ID for the endpoint. Note that the ID must be an exact match. You cannot use wildcards here. 
            var resourcePath = resourcePath_example;  // string | The URL of the resource. 

            try
            {
                // Subscribe to a resource path
                apiInstance.V2SubscriptionsDeviceIdResourcePathPut(deviceId, resourcePath);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.V2SubscriptionsDeviceIdResourcePathPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceId** | **string**| A unique Mbed Cloud device ID for the endpoint. Note that the ID must be an exact match. You cannot use wildcards here.  | 
 **resourcePath** | **string**| The URL of the resource.  | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2subscriptionsget"></a>
# **V2SubscriptionsGet**
> PresubscriptionArray V2SubscriptionsGet ()

Get pre-subscriptions

You can retrieve the pre-subscription data with the GET operation. The server returns with the same JSON structure  as described above. If there are no pre-subscribed resources, it returns with an empty array.  **Example usage:**      curl -X GET https://api.us-east-1.mbedcloud.com/v2/subscriptions -H 'authorization: Bearer {api-key}'      

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2SubscriptionsGetExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new SubscriptionsApi();

            try
            {
                // Get pre-subscriptions
                PresubscriptionArray result = apiInstance.V2SubscriptionsGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.V2SubscriptionsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**PresubscriptionArray**](PresubscriptionArray.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2subscriptionsput"></a>
# **V2SubscriptionsPut**
> void V2SubscriptionsPut (PresubscriptionArray presubsription)

Set pre-subscriptions

Pre-subscription is a set of rules and patterns put by the application. When an endpoint registers  and its ID, type and registered resources match the pre-subscription data, Mbed Cloud Connect sends  subscription requests to the device automatically. The pattern may include the endpoint ID  (optionally having an `*` character at the end), endpoint type, a list of resources or expressions with an `*` character at the end. Subscriptions based on pre-subscriptions are done when device registers or does register update. To remove the pre-subscription data, put an empty array as a rule.  **Limits**:  - The maximum length of the endpoint name and endpoint type is 64 characters. - The maximum length of the resource path is 128 characters. - You can listen to 256 separate resource paths. - The maximum number of pre-subscription entries is 1024.          **Example request:**  ``` curl -X PUT \\   https://api.us-east-1.mbedcloud.com/v2/subscriptions \\   -H 'authorization: Bearer {api-key}' \\   -H 'content-type: application/json' \\   -d '[          {            \"endpoint-name\": \"node-001\",            \"resource-path\": [\"/dev\"]          },          {            \"endpoint-type\": \"Light\",            \"resource-path\": [\"/sen/_*\"]          },          {            \"endpoint-name\": \"node*\"          },          {            \"endpoint-type\": \"Sensor\"          },          {            \"resource-path\": [\"/dev/temp\",\"/dev/hum\"]          }       ]' ``` 

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2SubscriptionsPutExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new SubscriptionsApi();
            var presubsription = new PresubscriptionArray(); // PresubscriptionArray | Array of pre-subscriptions.

            try
            {
                // Set pre-subscriptions
                apiInstance.V2SubscriptionsPut(presubsription);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.V2SubscriptionsPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **presubsription** | [**PresubscriptionArray**](PresubscriptionArray.md)| Array of pre-subscriptions. | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: text/plain

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

