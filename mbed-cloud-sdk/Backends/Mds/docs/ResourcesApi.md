# mds.Api.ResourcesApi

All URIs are relative to *https://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**V2EndpointsEndpointNameResourcePathDelete**](ResourcesApi.md#v2endpointsendpointnameresourcepathdelete) | **DELETE** /v2/endpoints/{endpointName}/{resourcePath} | Delete a resource
[**V2EndpointsEndpointNameResourcePathGet**](ResourcesApi.md#v2endpointsendpointnameresourcepathget) | **GET** /v2/endpoints/{endpointName}/{resourcePath} | Read from a resource
[**V2EndpointsEndpointNameResourcePathPost**](ResourcesApi.md#v2endpointsendpointnameresourcepathpost) | **POST** /v2/endpoints/{endpointName}/{resourcePath} | Execute a function on a resource
[**V2EndpointsEndpointNameResourcePathPut**](ResourcesApi.md#v2endpointsendpointnameresourcepathput) | **PUT** /v2/endpoints/{endpointName}/{resourcePath} | Write to a resource


<a name="v2endpointsendpointnameresourcepathdelete"></a>
# **V2EndpointsEndpointNameResourcePathDelete**
> AsyncID V2EndpointsEndpointNameResourcePathDelete (string endpointName, string resourcePath, bool? noResp = null)

Delete a resource

A request to delete a resource must be handled by both mbed Cloud Client and mbed Cloud Connect. The resource is not deleted from mbed Cloud Connect until the delete is handled by mbed Cloud Client.  All resource APIs are asynchronous. Note that these APIs respond only if the device is turned on and connected to mbed Cloud Connect. 

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2EndpointsEndpointNameResourcePathDeleteExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new ResourcesApi();
            var endpointName = endpointName_example;  // string | A unique identifier for the endpoint. Note that the endpoint-name must be an exact match. You cannot use wildcards here. 
            var resourcePath = resourcePath_example;  // string | Resource's url. 
            var noResp = true;  // bool? | **Non-confirmable requests**  All resource APIs have the parameter noResp. If you make a request with noResp=true, mbed Cloud Connect makes a CoAP non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.  If calls with this parameter enabled succeed, they return with the status code 204 No Content. If the underlying protocol does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code 409 Conflict.  (optional) 

            try
            {
                // Delete a resource
                AsyncID result = apiInstance.V2EndpointsEndpointNameResourcePathDelete(endpointName, resourcePath, noResp);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ResourcesApi.V2EndpointsEndpointNameResourcePathDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **endpointName** | **string**| A unique identifier for the endpoint. Note that the endpoint-name must be an exact match. You cannot use wildcards here.  | 
 **resourcePath** | **string**| Resource&#39;s url.  | 
 **noResp** | **bool?**| **Non-confirmable requests**  All resource APIs have the parameter noResp. If you make a request with noResp&#x3D;true, mbed Cloud Connect makes a CoAP non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.  If calls with this parameter enabled succeed, they return with the status code 204 No Content. If the underlying protocol does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code 409 Conflict.  | [optional] 

### Return type

[**AsyncID**](AsyncID.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2endpointsendpointnameresourcepathget"></a>
# **V2EndpointsEndpointNameResourcePathGet**
> AsyncID V2EndpointsEndpointNameResourcePathGet (string endpointName, string resourcePath, bool? cacheOnly = null, bool? noResp = null)

Read from a resource

Requests the resource value and when the response is available, a json AsycResponse object (AsyncIDResponse object) is received in the notification channel. Note that you can also receive notifications when a resource changes. The preferred way to get resource values is to use subscribe and callback methods.  All resource APIs are asynchronous. Note that these APIs will only respond if the device is turned on and connected to mbed Cloud Connect. 

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2EndpointsEndpointNameResourcePathGetExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new ResourcesApi();
            var endpointName = endpointName_example;  // string | Unique identifier for the endpoint. Note that the endpoint name needs to be an exact match. You cannot use wildcards here. 
            var resourcePath = resourcePath_example;  // string | Resource's url. 
            var cacheOnly = true;  // bool? | If true, the response comes only from the cache. Default: false.  (optional) 
            var noResp = true;  // bool? | **Non-confirmable requests**  All resource APIs have the parameter noResp. If a request is made with noResp=true, mbed Cloud Connect makes a CoAP non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.  If calls with this parameter enabled succeed, they return with the status code 204 No Content. If the underlying protocol does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code 409 Conflict.  (optional) 

            try
            {
                // Read from a resource
                AsyncID result = apiInstance.V2EndpointsEndpointNameResourcePathGet(endpointName, resourcePath, cacheOnly, noResp);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ResourcesApi.V2EndpointsEndpointNameResourcePathGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **endpointName** | **string**| Unique identifier for the endpoint. Note that the endpoint name needs to be an exact match. You cannot use wildcards here.  | 
 **resourcePath** | **string**| Resource&#39;s url.  | 
 **cacheOnly** | **bool?**| If true, the response comes only from the cache. Default: false.  | [optional] 
 **noResp** | **bool?**| **Non-confirmable requests**  All resource APIs have the parameter noResp. If a request is made with noResp&#x3D;true, mbed Cloud Connect makes a CoAP non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.  If calls with this parameter enabled succeed, they return with the status code 204 No Content. If the underlying protocol does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code 409 Conflict.  | [optional] 

### Return type

[**AsyncID**](AsyncID.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2endpointsendpointnameresourcepathpost"></a>
# **V2EndpointsEndpointNameResourcePathPost**
> AsyncID V2EndpointsEndpointNameResourcePathPost (string endpointName, string resourcePath, string resourceFunction = null, bool? noResp = null)

Execute a function on a resource

With this API, you can execute a function on an existing resource.  All resource APIs are asynchronous. Note that these APIs respond only if the device is turned on and connected to mbed Cloud Connect. 

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2EndpointsEndpointNameResourcePathPostExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new ResourcesApi();
            var endpointName = endpointName_example;  // string | A unique identifier for the endpoint. Note that the endpoint-name must be an exact match. You cannot use wildcards here. 
            var resourcePath = resourcePath_example;  // string | Resource's url.
            var resourceFunction = resourceFunction_example;  // string | This value is not needed. Most of the time resources do not accept a function but they have their own functions predefined. You can use this to trigger them.  If a function is included, the body of this request is passed as a char* to the function in mbed Cloud Client.  (optional) 
            var noResp = true;  // bool? | **Non-confirmable requests**  All resource APIs have the parameter noResp. If you make a request with noResp=true, mbed Cloud Connect makes a CoAP non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.  If calls with this parameter enabled succeed, they return with the status code 204 No Content. If the underlying protocol does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code 409 Conflict.  (optional) 

            try
            {
                // Execute a function on a resource
                AsyncID result = apiInstance.V2EndpointsEndpointNameResourcePathPost(endpointName, resourcePath, resourceFunction, noResp);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ResourcesApi.V2EndpointsEndpointNameResourcePathPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **endpointName** | **string**| A unique identifier for the endpoint. Note that the endpoint-name must be an exact match. You cannot use wildcards here.  | 
 **resourcePath** | **string**| Resource&#39;s url. | 
 **resourceFunction** | **string**| This value is not needed. Most of the time resources do not accept a function but they have their own functions predefined. You can use this to trigger them.  If a function is included, the body of this request is passed as a char* to the function in mbed Cloud Client.  | [optional] 
 **noResp** | **bool?**| **Non-confirmable requests**  All resource APIs have the parameter noResp. If you make a request with noResp&#x3D;true, mbed Cloud Connect makes a CoAP non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.  If calls with this parameter enabled succeed, they return with the status code 204 No Content. If the underlying protocol does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code 409 Conflict.  | [optional] 

### Return type

[**AsyncID**](AsyncID.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: text/plain, application/xml, application/octet-stream, application/exi, application/json, application/link-format, application/senml+json, application/nanoservice-tlv, application/vnd.oma.lwm2m+text, application/vnd.oma.lwm2m+opaq, application/vnd.oma.lwm2m+tlv, application/vnd.oma.lwm2m+json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2endpointsendpointnameresourcepathput"></a>
# **V2EndpointsEndpointNameResourcePathPut**
> AsyncID V2EndpointsEndpointNameResourcePathPut (string endpointName, string resourcePath, string resourceValue, bool? noResp = null)

Write to a resource

With this API, you can write new values to existing resources, or create new resources on the device. The resource-path does not have to exist - it can be created by the call.  All resource APIs are asynchronous. Note that these APIs respond only if the device is turned on and connected to mbed Cloud Connect. 

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2EndpointsEndpointNameResourcePathPutExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new ResourcesApi();
            var endpointName = endpointName_example;  // string | A unique identifier for the endpoint. Note that the endpoint name must be an exact match. You cannot use wildcards here. 
            var resourcePath = resourcePath_example;  // string | Resource's url.
            var resourceValue = resourceValue_example;  // string | Value to be set to the resource. (Check accceptable content-types) 
            var noResp = true;  // bool? | **Non-confirmable requests**  All resource APIs have the parameter noResp. If you make a request with noResp=true, mbed Cloud Connect makes a CoAP non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.  If calls with this parameter enabled succeed, they return with the status code 204 No Content. If the underlying protocol does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code 409 Conflict.  (optional) 

            try
            {
                // Write to a resource
                AsyncID result = apiInstance.V2EndpointsEndpointNameResourcePathPut(endpointName, resourcePath, resourceValue, noResp);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ResourcesApi.V2EndpointsEndpointNameResourcePathPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **endpointName** | **string**| A unique identifier for the endpoint. Note that the endpoint name must be an exact match. You cannot use wildcards here.  | 
 **resourcePath** | **string**| Resource&#39;s url. | 
 **resourceValue** | **string**| Value to be set to the resource. (Check accceptable content-types)  | 
 **noResp** | **bool?**| **Non-confirmable requests**  All resource APIs have the parameter noResp. If you make a request with noResp&#x3D;true, mbed Cloud Connect makes a CoAP non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.  If calls with this parameter enabled succeed, they return with the status code 204 No Content. If the underlying protocol does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code 409 Conflict.  | [optional] 

### Return type

[**AsyncID**](AsyncID.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: text/plain, application/xml, application/octet-stream, application/exi, application/json, application/link-format, application/senml+json, application/nanoservice-tlv, application/vnd.oma.lwm2m+text, application/vnd.oma.lwm2m+opaq, application/vnd.oma.lwm2m+tlv, application/vnd.oma.lwm2m+json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

