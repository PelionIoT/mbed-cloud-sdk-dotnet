# mds.Api.ResourcesApi

All URIs are relative to *https://api.us-east-1.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**V2EndpointsDeviceIdResourcePathDelete**](ResourcesApi.md#v2endpointsdeviceidresourcepathdelete) | **DELETE** /v2/endpoints/{device-id}/{resourcePath} | Delete a resource
[**V2EndpointsDeviceIdResourcePathGet**](ResourcesApi.md#v2endpointsdeviceidresourcepathget) | **GET** /v2/endpoints/{device-id}/{resourcePath} | Read from a resource
[**V2EndpointsDeviceIdResourcePathPost**](ResourcesApi.md#v2endpointsdeviceidresourcepathpost) | **POST** /v2/endpoints/{device-id}/{resourcePath} | Execute a function on a resource
[**V2EndpointsDeviceIdResourcePathPut**](ResourcesApi.md#v2endpointsdeviceidresourcepathput) | **PUT** /v2/endpoints/{device-id}/{resourcePath} | Write to a resource


<a name="v2endpointsdeviceidresourcepathdelete"></a>
# **V2EndpointsDeviceIdResourcePathDelete**
> AsyncID V2EndpointsDeviceIdResourcePathDelete (string deviceId, string resourcePath, bool? noResp = null)

Delete a resource

A request to delete a resource must be handled by both Mbed Cloud Client and Mbed Cloud Connect. The resource is not deleted from Mbed Cloud Connect until the request is handled by Mbed Cloud Client.  All resource APIs are asynchronous. These APIs respond only if the device is turned on and connected to Mbed Cloud Connect and there is an active notification channel.  **Example usage:**      curl -X DELETE \\       https://api.us-east-1.mbedcloud.com/v2/endpoints/{device-id}/{resourcePath} \\       -H 'authorization: Bearer {api-key}' 

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2EndpointsDeviceIdResourcePathDeleteExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new ResourcesApi();
            var deviceId = deviceId_example;  // string | A unique Mbed Cloud device ID for the endpoint. Note that the ID must be an exact match. You cannot use wildcards here. 
            var resourcePath = resourcePath_example;  // string | The URL of the resource. 
            var noResp = true;  // bool? | <br/><br/><b>Non-confirmable requests</b><br/>  All resource APIs have the parameter noResp. If you make a request with `noResp=true`, Mbed Cloud Connect makes a CoAP non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.  If calls with this parameter enabled succeed, they return with the status code `204 No Content`. If the underlying protocol does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code `409 Conflict`.  (optional) 

            try
            {
                // Delete a resource
                AsyncID result = apiInstance.V2EndpointsDeviceIdResourcePathDelete(deviceId, resourcePath, noResp);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ResourcesApi.V2EndpointsDeviceIdResourcePathDelete: " + e.Message );
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
 **noResp** | **bool?**| &lt;br/&gt;&lt;br/&gt;&lt;b&gt;Non-confirmable requests&lt;/b&gt;&lt;br/&gt;  All resource APIs have the parameter noResp. If you make a request with &#x60;noResp&#x3D;true&#x60;, Mbed Cloud Connect makes a CoAP non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.  If calls with this parameter enabled succeed, they return with the status code &#x60;204 No Content&#x60;. If the underlying protocol does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code &#x60;409 Conflict&#x60;.  | [optional] 

### Return type

[**AsyncID**](AsyncID.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2endpointsdeviceidresourcepathget"></a>
# **V2EndpointsDeviceIdResourcePathGet**
> AsyncID V2EndpointsDeviceIdResourcePathGet (string deviceId, string resourcePath, bool? cacheOnly = null, bool? noResp = null)

Read from a resource

Requests the resource value and when the response is available, an `AsyncIDResponse` json object is received in the notification channel. The preferred way to get resource values is to use [subscribe](/docs/v1.2/service-api-references/connect-api.html#v2-notification-callback) and [callback](/docs/v1.2/service-api-references/connect-api.html#v2-notification-callback) methods.  All resource APIs are asynchronous. These APIs only respond if the device is turned on and connected to Mbed Cloud Connect.  **Example usage:**      curl -X GET \\       https://api.us-east-1.mbedcloud.com/v2/endpoints/{device-id}/{resourcePath} \\       -H 'authorization: Bearer {api-key}'        

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2EndpointsDeviceIdResourcePathGetExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new ResourcesApi();
            var deviceId = deviceId_example;  // string | Unique Mbed Cloud device ID for the endpoint. Note that the ID needs to be an exact match. You cannot use wildcards here. 
            var resourcePath = resourcePath_example;  // string | The URL of the resource. 
            var cacheOnly = true;  // bool? | If true, the response comes only from the cache. Default: false. Mbed Cloud Connect caches the received resource values for the time of [max_age](/docs/v1.2/collecting/handle-resources.html#working-with-the-server-cache) defined in the client side.  (optional) 
            var noResp = true;  // bool? | <br/><br/><b>Non-confirmable requests</b><br/>  All resource APIs have the parameter `noResp`. If a request is made with `noResp=true`, Mbed Cloud Connect makes a CoAP  non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back  an async-response-id.  If calls with this parameter enabled succeed, they return with the status code `204 No Content`. If the underlying protocol  does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code  `409 Conflict`.  (optional) 

            try
            {
                // Read from a resource
                AsyncID result = apiInstance.V2EndpointsDeviceIdResourcePathGet(deviceId, resourcePath, cacheOnly, noResp);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ResourcesApi.V2EndpointsDeviceIdResourcePathGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceId** | **string**| Unique Mbed Cloud device ID for the endpoint. Note that the ID needs to be an exact match. You cannot use wildcards here.  | 
 **resourcePath** | **string**| The URL of the resource.  | 
 **cacheOnly** | **bool?**| If true, the response comes only from the cache. Default: false. Mbed Cloud Connect caches the received resource values for the time of [max_age](/docs/v1.2/collecting/handle-resources.html#working-with-the-server-cache) defined in the client side.  | [optional] 
 **noResp** | **bool?**| &lt;br/&gt;&lt;br/&gt;&lt;b&gt;Non-confirmable requests&lt;/b&gt;&lt;br/&gt;  All resource APIs have the parameter &#x60;noResp&#x60;. If a request is made with &#x60;noResp&#x3D;true&#x60;, Mbed Cloud Connect makes a CoAP  non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back  an async-response-id.  If calls with this parameter enabled succeed, they return with the status code &#x60;204 No Content&#x60;. If the underlying protocol  does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code  &#x60;409 Conflict&#x60;.  | [optional] 

### Return type

[**AsyncID**](AsyncID.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2endpointsdeviceidresourcepathpost"></a>
# **V2EndpointsDeviceIdResourcePathPost**
> AsyncID V2EndpointsDeviceIdResourcePathPost (string deviceId, string resourcePath, string resourceFunction = null, bool? noResp = null)

Execute a function on a resource

With this API, you can execute a function on an existing resource.  All resource APIs are asynchronous. These APIs respond only if the device is turned on and connected to Mbed Cloud Connect and there is an active notification channel.  **Example usage:**  This example resets the min and max values of the [temperature sensor](http://www.openmobilealliance.org/tech/profiles/lwm2m/3303.xml) instance 0 by executing the Resource 5605 'Reset Min and Max Measured Values'.          curl -X POST \\       https://api.us-east-1.mbedcloud.com/v2/endpoints/{device-id}/3303/0/5605 \\       -H 'authorization: Bearer {api-key}' 

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2EndpointsDeviceIdResourcePathPostExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new ResourcesApi();
            var deviceId = deviceId_example;  // string | A unique Mbed Cloud device ID for the endpoint. Note that the ID must be an exact match. You cannot use wildcards here. 
            var resourcePath = resourcePath_example;  // string | The URL of the resource.
            var resourceFunction = resourceFunction_example;  // string | This value is not needed. Most of the time resources do not accept a function but they have their own functions predefined. You can use this to trigger them.  If a function is included, the body of this request is passed as a char* to the function in Mbed Cloud Client.  (optional) 
            var noResp = true;  // bool? | <br/><br/><b>Non-confirmable requests</b><br/>  All resource APIs have the parameter noResp. If you make a request with `noResp=true`, Mbed Cloud Connect makes a CoAP non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.  If calls with this parameter enabled succeed, they return with the status code `204 No Content`. If the underlying protocol does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code `409 Conflict`.  (optional) 

            try
            {
                // Execute a function on a resource
                AsyncID result = apiInstance.V2EndpointsDeviceIdResourcePathPost(deviceId, resourcePath, resourceFunction, noResp);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ResourcesApi.V2EndpointsDeviceIdResourcePathPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceId** | **string**| A unique Mbed Cloud device ID for the endpoint. Note that the ID must be an exact match. You cannot use wildcards here.  | 
 **resourcePath** | **string**| The URL of the resource. | 
 **resourceFunction** | **string**| This value is not needed. Most of the time resources do not accept a function but they have their own functions predefined. You can use this to trigger them.  If a function is included, the body of this request is passed as a char* to the function in Mbed Cloud Client.  | [optional] 
 **noResp** | **bool?**| &lt;br/&gt;&lt;br/&gt;&lt;b&gt;Non-confirmable requests&lt;/b&gt;&lt;br/&gt;  All resource APIs have the parameter noResp. If you make a request with &#x60;noResp&#x3D;true&#x60;, Mbed Cloud Connect makes a CoAP non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.  If calls with this parameter enabled succeed, they return with the status code &#x60;204 No Content&#x60;. If the underlying protocol does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code &#x60;409 Conflict&#x60;.  | [optional] 

### Return type

[**AsyncID**](AsyncID.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: text/plain, application/xml, application/octet-stream, application/exi, application/json, application/link-format, application/senml+json, application/nanoservice-tlv, application/vnd.oma.lwm2m+text, application/vnd.oma.lwm2m+opaq, application/vnd.oma.lwm2m+tlv, application/vnd.oma.lwm2m+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2endpointsdeviceidresourcepathput"></a>
# **V2EndpointsDeviceIdResourcePathPut**
> AsyncID V2EndpointsDeviceIdResourcePathPut (string deviceId, string resourcePath, string resourceValue, bool? noResp = null)

Write to a resource

With this API, you can write new values to existing resources, or create new  resources on the device. The resource-path does not have to exist - it can be  created by the call. The maximum length of resource-path is 255 characters.  This API can also be used to transfer files to the device. Mbed Cloud Connect LwM2M server implements the Option 1 from RFC7959. The maximum block size is 1024 bytes. The block size versus transferred file size is something to note in low quality networks. The customer application needs to know what type of file is transferred (for example txt) and the payload can be encrypted by the customer. The maximum size of payload is 1048576 bytes.  All resource APIs are asynchronous. These APIs respond only if the device is turned on and connected to Mbed Cloud Connect and there is an active notification channel.  **Example usage:**  This example sets the alarm on a buzzer. The command writes the [Buzzer](http://www.openmobilealliance.org/tech/profiles/lwm2m/3338.xml) instance 0, \"On/Off\" boolean resource to '1'.          curl -X PUT \\       https://api.us-east-1.mbedcloud.com/v2/endpoints/{device-id}/3338/0/5850 \\       -H 'authorization: Bearer {api-key}' -d '1' 

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2EndpointsDeviceIdResourcePathPutExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new ResourcesApi();
            var deviceId = deviceId_example;  // string | A unique Mbed Cloud device ID for the endpoint. Note that the ID must be an exact match. You cannot use wildcards here. 
            var resourcePath = resourcePath_example;  // string | Resource URL.
            var resourceValue = resourceValue_example;  // string | The value to be set to the resource. 
            var noResp = true;  // bool? | <br/><br/><b>Non-confirmable requests</b><br/>  All resource APIs have the parameter noResp. If you make a request with `noResp=true`, Mbed Cloud Connect makes a CoAP non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.  If calls with this parameter enabled succeed, they return with the status code `204 No Content`. If the underlying protocol does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code `409 Conflict`.  (optional) 

            try
            {
                // Write to a resource
                AsyncID result = apiInstance.V2EndpointsDeviceIdResourcePathPut(deviceId, resourcePath, resourceValue, noResp);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ResourcesApi.V2EndpointsDeviceIdResourcePathPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceId** | **string**| A unique Mbed Cloud device ID for the endpoint. Note that the ID must be an exact match. You cannot use wildcards here.  | 
 **resourcePath** | **string**| Resource URL. | 
 **resourceValue** | **string**| The value to be set to the resource.  | 
 **noResp** | **bool?**| &lt;br/&gt;&lt;br/&gt;&lt;b&gt;Non-confirmable requests&lt;/b&gt;&lt;br/&gt;  All resource APIs have the parameter noResp. If you make a request with &#x60;noResp&#x3D;true&#x60;, Mbed Cloud Connect makes a CoAP non-confirmable request to the device. Such requests are not guaranteed to arrive in the device, and you do not get back an async-response-id.  If calls with this parameter enabled succeed, they return with the status code &#x60;204 No Content&#x60;. If the underlying protocol does not support non-confirmable requests, or if the endpoint is registered in queue mode, the response is status code &#x60;409 Conflict&#x60;.  | [optional] 

### Return type

[**AsyncID**](AsyncID.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: text/plain, application/xml, application/octet-stream, application/exi, application/json, application/link-format, application/senml+json, application/nanoservice-tlv, application/vnd.oma.lwm2m+text, application/vnd.oma.lwm2m+opaq, application/vnd.oma.lwm2m+tlv, application/vnd.oma.lwm2m+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

