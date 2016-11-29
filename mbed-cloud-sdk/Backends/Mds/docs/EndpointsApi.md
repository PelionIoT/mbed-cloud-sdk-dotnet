# mds.Api.EndpointsApi

All URIs are relative to *https://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**V2EndpointsEndpointNameGet**](EndpointsApi.md#v2endpointsendpointnameget) | **GET** /v2/endpoints/{endpointName} | List the resources on an endpoint
[**V2EndpointsGet**](EndpointsApi.md#v2endpointsget) | **GET** /v2/endpoints | List all endpoints


<a name="v2endpointsendpointnameget"></a>
# **V2EndpointsEndpointNameGet**
> List<Resource> V2EndpointsEndpointNameGet (string endpointName)

List the resources on an endpoint

The list of resources is cached by mbed Cloud Connect, so this call does not create a message to the device. 

### Example
```csharp
using System;
using System.Diagnostics;
using mds.Api;
using mds.Client;
using mds.Model;

namespace Example
{
    public class V2EndpointsEndpointNameGetExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new EndpointsApi();
            var endpointName = endpointName_example;  // string | A unique identifier for an endpoint. Note that the endpoint name needs to be an exact match. You cannot use wildcards here. 

            try
            {
                // List the resources on an endpoint
                List&lt;Resource&gt; result = apiInstance.V2EndpointsEndpointNameGet(endpointName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling EndpointsApi.V2EndpointsEndpointNameGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **endpointName** | **string**| A unique identifier for an endpoint. Note that the endpoint name needs to be an exact match. You cannot use wildcards here.  | 

### Return type

[**List<Resource>**](Resource.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/link-format

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v2endpointsget"></a>
# **V2EndpointsGet**
> List<Endpoint> V2EndpointsGet (string type = null)

List all endpoints

Endpoints are physical devices running mbed Cloud Client. 

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
                // List all endpoints
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
 - **Accept**: application/json, application/link-format

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

