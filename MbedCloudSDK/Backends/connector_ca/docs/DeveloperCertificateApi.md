# connector_ca.Api.DeveloperCertificateApi

All URIs are relative to *http://api.us-east-1.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**V3DeveloperCertificatesMuuidGet**](DeveloperCertificateApi.md#v3developercertificatesmuuidget) | **GET** /v3/developer-certificates/{muuid} | Fetch an existing developer certificate to connect to the bootstrap server.
[**V3DeveloperCertificatesPost**](DeveloperCertificateApi.md#v3developercertificatespost) | **POST** /v3/developer-certificates | Create a new developer certificate to connect to the bootstrap server.


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

            var apiInstance = new DeveloperCertificateApi();
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
                Debug.Print("Exception when calling DeveloperCertificateApi.V3DeveloperCertificatesMuuidGet: " + e.Message );
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

            var apiInstance = new DeveloperCertificateApi();
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
                Debug.Print("Exception when calling DeveloperCertificateApi.V3DeveloperCertificatesPost: " + e.Message );
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

