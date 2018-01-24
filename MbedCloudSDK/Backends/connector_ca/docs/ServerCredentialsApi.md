# connector_ca.Api.ServerCredentialsApi

All URIs are relative to *http://api.us-east-1.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**V3ServerCredentialsBootstrapGet**](ServerCredentialsApi.md#v3servercredentialsbootstrapget) | **GET** /v3/server-credentials/bootstrap | Fetch bootstrap server credentials.
[**V3ServerCredentialsLwm2mGet**](ServerCredentialsApi.md#v3servercredentialslwm2mget) | **GET** /v3/server-credentials/lwm2m | Fetch LWM2M server credentials.


<a name="v3servercredentialsbootstrapget"></a>
# **V3ServerCredentialsBootstrapGet**
> ServerCredentialsResponseData V3ServerCredentialsBootstrapGet (string authorization)

Fetch bootstrap server credentials.

This REST API is intended to be used by customers to fetch bootstrap server credentials that they need to use with their clients to connect to bootstrap server. 

### Example
```csharp
using System;
using System.Diagnostics;
using connector_ca.Api;
using connector_ca.Client;
using connector_ca.Model;

namespace Example
{
    public class V3ServerCredentialsBootstrapGetExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new ServerCredentialsApi();
            var authorization = authorization_example;  // string | Bearer {Access Token}. 

            try
            {
                // Fetch bootstrap server credentials.
                ServerCredentialsResponseData result = apiInstance.V3ServerCredentialsBootstrapGet(authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ServerCredentialsApi.V3ServerCredentialsBootstrapGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**| Bearer {Access Token}.  | 

### Return type

[**ServerCredentialsResponseData**](ServerCredentialsResponseData.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3servercredentialslwm2mget"></a>
# **V3ServerCredentialsLwm2mGet**
> ServerCredentialsResponseData V3ServerCredentialsLwm2mGet (string authorization)

Fetch LWM2M server credentials.

This REST API is intended to be used by customers to fetch LWM2M server credentials that they need to use with their clients to connect to LWM2M server. 

### Example
```csharp
using System;
using System.Diagnostics;
using connector_ca.Api;
using connector_ca.Client;
using connector_ca.Model;

namespace Example
{
    public class V3ServerCredentialsLwm2mGetExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new ServerCredentialsApi();
            var authorization = authorization_example;  // string | Bearer {Access Token}. 

            try
            {
                // Fetch LWM2M server credentials.
                ServerCredentialsResponseData result = apiInstance.V3ServerCredentialsLwm2mGet(authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ServerCredentialsApi.V3ServerCredentialsLwm2mGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**| Bearer {Access Token}.  | 

### Return type

[**ServerCredentialsResponseData**](ServerCredentialsResponseData.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

