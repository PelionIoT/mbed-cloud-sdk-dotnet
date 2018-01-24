# mds.Api.EndpointsApi

All URIs are relative to *https://api.us-east-1.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**V2EndpointsDeviceIdGet**](EndpointsApi.md#v2endpointsdeviceidget) | **GET** /v2/endpoints/{device-id} | List the resources on an endpoint
[**V2EndpointsGet**](EndpointsApi.md#v2endpointsget) | **GET** /v2/endpoints | (DEPRECATED) List registered endpoints. The number of returned endpoints is currently limited to 200.


<a name="v2endpointsdeviceidget"></a>
# **V2EndpointsDeviceIdGet**
> List<Resource> V2EndpointsDeviceIdGet (string deviceId)

List the resources on an endpoint

The list of resources is cached by Mbed Cloud Connect, so this call does not create a message to the device.  **Example usage:**      curl -X GET https://api.us-east-1.mbedcloud.com/v2/endpoints/{device-id} -H 'authorization: Bearer {api-key}'      

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2EndpointsDeviceIdGetExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new EndpointsApi();
            var deviceId = deviceId_example;  // string | A unique Mbed Cloud device ID for an endpoint. Note that the ID needs to be an exact match. You cannot use wildcards here. 

            try
            {
                // List the resources on an endpoint
                List&lt;Resource&gt; result = apiInstance.V2EndpointsDeviceIdGet(deviceId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EndpointsApi.V2EndpointsDeviceIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceId** | **string**| A unique Mbed Cloud device ID for an endpoint. Note that the ID needs to be an exact match. You cannot use wildcards here.  | 

### Return type

[**List<Resource>**](Resource.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2endpointsget"></a>
# **V2EndpointsGet**
> List<Endpoint> V2EndpointsGet (string type = null)

(DEPRECATED) List registered endpoints. The number of returned endpoints is currently limited to 200.

Endpoints are physical devices having valid registration to Mbed Cloud Connect. All devices regardless of registration status can be requested from Device Directory API ['/v3/devices/`](/docs/v1.2/service-api-references/device-directory-api.html#v3-devices).  **Note:** This endpoint is deprecated and will be removed 1Q/18. You should use the Device Directory API [`/v3/devices/`](/docs/v1.2/service-api-references/device-directory-api.html#v3-devices). To list only the registered devices, use filter `/v3/devices/?filter=state%3Dregistered`.  **Example usage:**      curl -X GET https://api.us-east-1.mbedcloud.com/v2/endpoints -H 'authorization: Bearer {api-key}'      

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2EndpointsGetExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new EndpointsApi();
            var type = type_example;  // string | Filter endpoints by endpoint-type. (optional) 

            try
            {
                // (DEPRECATED) List registered endpoints. The number of returned endpoints is currently limited to 200.
                List&lt;Endpoint&gt; result = apiInstance.V2EndpointsGet(type);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EndpointsApi.V2EndpointsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **type** | **string**| Filter endpoints by endpoint-type. | [optional] 

### Return type

[**List<Endpoint>**](Endpoint.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

