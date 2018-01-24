# connector_ca.Api.ExternalAPIApi

All URIs are relative to *http://api.us-east-1.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**V3DeveloperCertificatesMuuidGet**](ExternalAPIApi.md#v3developercertificatesmuuidget) | **GET** /v3/developer-certificates/{muuid} | Fetch an existing developer certificate to connect to the bootstrap server.
[**V3DeveloperCertificatesPost**](ExternalAPIApi.md#v3developercertificatespost) | **POST** /v3/developer-certificates | Create a new developer certificate to connect to the bootstrap server.
[**V3ServerCredentialsBootstrapGet**](ExternalAPIApi.md#v3servercredentialsbootstrapget) | **GET** /v3/server-credentials/bootstrap | Fetch bootstrap server credentials.
[**V3ServerCredentialsLwm2mGet**](ExternalAPIApi.md#v3servercredentialslwm2mget) | **GET** /v3/server-credentials/lwm2m | Fetch LWM2M server credentials.


<a name="v3developercertificatesmuuidget"></a>
# **V3DeveloperCertificatesMuuidGet**
> DeveloperCertificateResponseData V3DeveloperCertificatesMuuidGet (string muuid, string authorization)

Fetch an existing developer certificate to connect to the bootstrap server.

This REST API is intended to be used by customers to fetch an existing developer certificate (a certificate that can be flashed into multiple devices to connect to bootstrap server). 

### Example
```csharp
using System;
using System.Diagnostics;
using connector_ca.Api;
using connector_ca.Client;
using connector_ca.Model;

namespace Example
{
    public class V3DeveloperCertificatesMuuidGetExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new ExternalAPIApi();
            var muuid = muuid_example;  // string | A unique identifier for the developer certificate. 
            var authorization = authorization_example;  // string | Bearer {Access Token}. 

            try
            {
                // Fetch an existing developer certificate to connect to the bootstrap server.
                DeveloperCertificateResponseData result = apiInstance.V3DeveloperCertificatesMuuidGet(muuid, authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ExternalAPIApi.V3DeveloperCertificatesMuuidGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **muuid** | **string**| A unique identifier for the developer certificate.  | 
 **authorization** | **string**| Bearer {Access Token}.  | 

### Return type

[**DeveloperCertificateResponseData**](DeveloperCertificateResponseData.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3developercertificatespost"></a>
# **V3DeveloperCertificatesPost**
> DeveloperCertificateResponseData V3DeveloperCertificatesPost (string authorization, DeveloperCertificateRequestData body)

Create a new developer certificate to connect to the bootstrap server.

This REST API is intended to be used by customers to get a developer certificate (a certificate that can be flashed into multiple devices to connect to bootstrap server).  Limitations:    - One developer certificate allows up to 100 devices to connect to bootstrap server.   - Only 10 developer certificates are allowed per account. 

### Example
```csharp
using System;
using System.Diagnostics;
using connector_ca.Api;
using connector_ca.Client;
using connector_ca.Model;

namespace Example
{
    public class V3DeveloperCertificatesPostExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new ExternalAPIApi();
            var authorization = authorization_example;  // string | Bearer {Access Token}. 
            var body = new DeveloperCertificateRequestData(); // DeveloperCertificateRequestData | 

            try
            {
                // Create a new developer certificate to connect to the bootstrap server.
                DeveloperCertificateResponseData result = apiInstance.V3DeveloperCertificatesPost(authorization, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ExternalAPIApi.V3DeveloperCertificatesPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**| Bearer {Access Token}.  | 
 **body** | [**DeveloperCertificateRequestData**](DeveloperCertificateRequestData.md)|  | 

### Return type

[**DeveloperCertificateResponseData**](DeveloperCertificateResponseData.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

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

            var apiInstance = new ExternalAPIApi();
            var authorization = authorization_example;  // string | Bearer {Access Token}. 

            try
            {
                // Fetch bootstrap server credentials.
                ServerCredentialsResponseData result = apiInstance.V3ServerCredentialsBootstrapGet(authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ExternalAPIApi.V3ServerCredentialsBootstrapGet: " + e.Message );
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

            var apiInstance = new ExternalAPIApi();
            var authorization = authorization_example;  // string | Bearer {Access Token}. 

            try
            {
                // Fetch LWM2M server credentials.
                ServerCredentialsResponseData result = apiInstance.V3ServerCredentialsLwm2mGet(authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ExternalAPIApi.V3ServerCredentialsLwm2mGet: " + e.Message );
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

