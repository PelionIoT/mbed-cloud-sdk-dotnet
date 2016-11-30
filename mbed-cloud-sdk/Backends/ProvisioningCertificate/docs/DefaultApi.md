# provisioning_certificate.Api.DefaultApi

All URIs are relative to *https://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**V3ProvisioningCertificateGet**](DefaultApi.md#v3provisioningcertificateget) | **GET** /v3/provisioning-certificate | 


<a name="v3provisioningcertificateget"></a>
# **V3ProvisioningCertificateGet**
> ProvisioningCertificate V3ProvisioningCertificateGet (string authorization)



Gets the account's provisioning certificate.

### Example
```csharp
using System;
using System.Diagnostics;
using provisioning_certificate.Api;
using provisioning_certificate.Client;
using provisioning_certificate.Model;

namespace Example
{
    public class V3ProvisioningCertificateGetExample
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
                ProvisioningCertificate result = apiInstance.V3ProvisioningCertificateGet(authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.V3ProvisioningCertificateGet: " + e.Message );
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

[**ProvisioningCertificate**](ProvisioningCertificate.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

