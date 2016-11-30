# developer_certificate.Api.DefaultApi

All URIs are relative to *https://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**V3DeveloperCertificateDelete**](DefaultApi.md#v3developercertificatedelete) | **DELETE** /v3/developer-certificate | 
[**V3DeveloperCertificateGet**](DefaultApi.md#v3developercertificateget) | **GET** /v3/developer-certificate | 
[**V3DeveloperCertificatePost**](DefaultApi.md#v3developercertificatepost) | **POST** /v3/developer-certificate | 


<a name="v3developercertificatedelete"></a>
# **V3DeveloperCertificateDelete**
> void V3DeveloperCertificateDelete (string authorization)



Deletes the account's developer certificate (only one per account allowed).

### Example
```csharp
using System;
using System.Diagnostics;
using developer_certificate.Api;
using developer_certificate.Client;
using developer_certificate.Model;

namespace Example
{
    public class V3DeveloperCertificateDeleteExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var authorization = authorization_example;  // string | \"Bearer\" followed by the reference token or API key.

            try
            {
                apiInstance.V3DeveloperCertificateDelete(authorization);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.V3DeveloperCertificateDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**| \&quot;Bearer\&quot; followed by the reference token or API key. | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3developercertificateget"></a>
# **V3DeveloperCertificateGet**
> DeveloperCertificate V3DeveloperCertificateGet (string authorization)



Gets the developer certificate of the account.

### Example
```csharp
using System;
using System.Diagnostics;
using developer_certificate.Api;
using developer_certificate.Client;
using developer_certificate.Model;

namespace Example
{
    public class V3DeveloperCertificateGetExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var authorization = authorization_example;  // string | \"Bearer\" followed by the reference token or API key.

            try
            {
                DeveloperCertificate result = apiInstance.V3DeveloperCertificateGet(authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.V3DeveloperCertificateGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**| \&quot;Bearer\&quot; followed by the reference token or API key. | 

### Return type

[**DeveloperCertificate**](DeveloperCertificate.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3developercertificatepost"></a>
# **V3DeveloperCertificatePost**
> DeveloperCertificate V3DeveloperCertificatePost (string authorization, Body body)



Adds a developer certificate to the account (only one per account allowed).

### Example
```csharp
using System;
using System.Diagnostics;
using developer_certificate.Api;
using developer_certificate.Client;
using developer_certificate.Model;

namespace Example
{
    public class V3DeveloperCertificatePostExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var authorization = authorization_example;  // string | \"Bearer\" followed by the reference token or API key.
            var body = new Body(); // Body | 

            try
            {
                DeveloperCertificate result = apiInstance.V3DeveloperCertificatePost(authorization, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.V3DeveloperCertificatePost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**| \&quot;Bearer\&quot; followed by the reference token or API key. | 
 **body** | [**Body**](Body.md)|  | 

### Return type

[**DeveloperCertificate**](DeveloperCertificate.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

