# mds.Api.SubscriptionsApi

All URIs are relative to *https://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**V2SubscriptionsDelete**](SubscriptionsApi.md#v2subscriptionsdelete) | **DELETE** /v2/subscriptions | Remove all subscriptions
[**V2SubscriptionsEndpointNameDelete**](SubscriptionsApi.md#v2subscriptionsendpointnamedelete) | **DELETE** /v2/subscriptions/{endpointName} | Delete subscriptions from an endpoint
[**V2SubscriptionsEndpointNameGet**](SubscriptionsApi.md#v2subscriptionsendpointnameget) | **GET** /v2/subscriptions/{endpointName} | Read endpoints subscriptions
[**V2SubscriptionsEndpointNameResourcePathDelete**](SubscriptionsApi.md#v2subscriptionsendpointnameresourcepathdelete) | **DELETE** /v2/subscriptions/{endpointName}/{resourcePath} | Remove a subscription
[**V2SubscriptionsEndpointNameResourcePathGet**](SubscriptionsApi.md#v2subscriptionsendpointnameresourcepathget) | **GET** /v2/subscriptions/{endpointName}/{resourcePath} | Read subscription status
[**V2SubscriptionsEndpointNameResourcePathPut**](SubscriptionsApi.md#v2subscriptionsendpointnameresourcepathput) | **PUT** /v2/subscriptions/{endpointName}/{resourcePath} | Subscribe to a resource path
[**V2SubscriptionsGet**](SubscriptionsApi.md#v2subscriptionsget) | **GET** /v2/subscriptions | Get pre-subscriptions
[**V2SubscriptionsPut**](SubscriptionsApi.md#v2subscriptionsput) | **PUT** /v2/subscriptions | Set pre-subscriptions


<a name="v2subscriptionsdelete"></a>
# **V2SubscriptionsDelete**
> void V2SubscriptionsDelete ()

Remove all subscriptions

Removes subscriptions from every endpoint and resource. Note that this does not remove pre-subscriptions.

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
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2subscriptionsendpointnamedelete"></a>
# **V2SubscriptionsEndpointNameDelete**
> void V2SubscriptionsEndpointNameDelete (string endpointName)

Delete subscriptions from an endpoint

Deletes all resource subscriptions in a single endpoint.

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2SubscriptionsEndpointNameDeleteExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new SubscriptionsApi();
            var endpointName = endpointName_example;  // string | A unique identifier for the endpoint. Note that the endpoint name must be an exact match. You cannot use wildcards here. 

            try
            {
                // Delete subscriptions from an endpoint
                apiInstance.V2SubscriptionsEndpointNameDelete(endpointName);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.V2SubscriptionsEndpointNameDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **endpointName** | **string**| A unique identifier for the endpoint. Note that the endpoint name must be an exact match. You cannot use wildcards here.  | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2subscriptionsendpointnameget"></a>
# **V2SubscriptionsEndpointNameGet**
> void V2SubscriptionsEndpointNameGet (string endpointName)

Read endpoints subscriptions

Lists all subscribed resources from a single endpoint.

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2SubscriptionsEndpointNameGetExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new SubscriptionsApi();
            var endpointName = endpointName_example;  // string | A unique identifier for the endpoint. Note that endpoint name must be an exact match. You cannot use wildcards here. 

            try
            {
                // Read endpoints subscriptions
                apiInstance.V2SubscriptionsEndpointNameGet(endpointName);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.V2SubscriptionsEndpointNameGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **endpointName** | **string**| A unique identifier for the endpoint. Note that endpoint name must be an exact match. You cannot use wildcards here.  | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/uri-list

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2subscriptionsendpointnameresourcepathdelete"></a>
# **V2SubscriptionsEndpointNameResourcePathDelete**
> void V2SubscriptionsEndpointNameResourcePathDelete (string endpointName, string resourcePath)

Remove a subscription

To remove an existing subscription from a resource path. 

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2SubscriptionsEndpointNameResourcePathDeleteExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new SubscriptionsApi();
            var endpointName = endpointName_example;  // string | A unique identifier for the endpoint. Note that the endpoint name must be an exact match. You cannot use wildcards here. 
            var resourcePath = resourcePath_example;  // string | Resource's url. 

            try
            {
                // Remove a subscription
                apiInstance.V2SubscriptionsEndpointNameResourcePathDelete(endpointName, resourcePath);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.V2SubscriptionsEndpointNameResourcePathDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **endpointName** | **string**| A unique identifier for the endpoint. Note that the endpoint name must be an exact match. You cannot use wildcards here.  | 
 **resourcePath** | **string**| Resource&#39;s url.  | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2subscriptionsendpointnameresourcepathget"></a>
# **V2SubscriptionsEndpointNameResourcePathGet**
> void V2SubscriptionsEndpointNameResourcePathGet (string endpointName, string resourcePath)

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
    public class V2SubscriptionsEndpointNameResourcePathGetExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new SubscriptionsApi();
            var endpointName = endpointName_example;  // string | A unique identifier for the endpoint. Note that the endpoint name must be an exact match. You cannot use wildcards here. 
            var resourcePath = resourcePath_example;  // string | Resource's url. 

            try
            {
                // Read subscription status
                apiInstance.V2SubscriptionsEndpointNameResourcePathGet(endpointName, resourcePath);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.V2SubscriptionsEndpointNameResourcePathGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **endpointName** | **string**| A unique identifier for the endpoint. Note that the endpoint name must be an exact match. You cannot use wildcards here.  | 
 **resourcePath** | **string**| Resource&#39;s url.  | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2subscriptionsendpointnameresourcepathput"></a>
# **V2SubscriptionsEndpointNameResourcePathPut**
> void V2SubscriptionsEndpointNameResourcePathPut (string endpointName, string resourcePath)

Subscribe to a resource path

The mbed Cloud Connect eventing model consists of observable resources.  This means that endpoints can deliver updated resource content, periodically or with a more sophisticated solution-dependent logic. The OMA LWM2M resource model including objects, object instances, resources and resource instances is also supported.  Applications can subscribe to objects, object instances or individual resources to make the device to provide value change notifications to mbed Cloud Connect service. An application needs to call a /notification/callback method to get mbed Cloud Connect to push a notification of the resource changes. You can also use /subscriptions to set a pre-subscription. 

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2SubscriptionsEndpointNameResourcePathPutExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new SubscriptionsApi();
            var endpointName = endpointName_example;  // string | A unique identifier for the endpoint. Note that the endpoint name must be an exact match. You cannot use wildcards here. 
            var resourcePath = resourcePath_example;  // string | Resource's URL. 

            try
            {
                // Subscribe to a resource path
                apiInstance.V2SubscriptionsEndpointNameResourcePathPut(endpointName, resourcePath);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.V2SubscriptionsEndpointNameResourcePathPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **endpointName** | **string**| A unique identifier for the endpoint. Note that the endpoint name must be an exact match. You cannot use wildcards here.  | 
 **resourcePath** | **string**| Resource&#39;s URL.  | 

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
> void V2SubscriptionsGet ()

Get pre-subscriptions

You can retrieve the pre-subscription data by using a GET operation. The server returns with the same JSON structure as described above. If there are no pre-subscribed resources, it returns with an empty array. 

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
                apiInstance.V2SubscriptionsGet();
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

void (empty response body)

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

Pre-subscription is a set of rules and patterns put by the application. When an endpoint registers and its name, type and registered resources match the pre-subscription data, mbed Cloud Connect sends subscription requests to the device automatically. The pattern may include the endpoint name (optionally having an \\* character at the end), endpoint type, a list of resources or expressions with an \\* character at the end. The pre-subscription concerns all the endpoints that are already registered and the server sends subscription requests to the devices immediately when the patterns are set. There is only one pre-subscribe array, so changing the pre-subscription data removes all the previous subscriptions. To remove the pre-subscription data, put an empty array as a rule. 

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

