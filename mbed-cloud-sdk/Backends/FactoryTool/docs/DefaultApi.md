# factory_tool.Api.DefaultApi

All URIs are relative to *https://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DownloadsMbedFactoryProvisioningPackageInfoGet**](DefaultApi.md#downloadsmbedfactoryprovisioningpackageinfoget) | **GET** /downloads/mbed_factory_provisioning_package/info | 
[**DownloadsMbedFactoryProvisioningPackageososGet**](DefaultApi.md#downloadsmbedfactoryprovisioningpackageososget) | **GET** /downloads/mbed_factory_provisioning_package?os&#x3D;{os} | 


<a name="downloadsmbedfactoryprovisioningpackageinfoget"></a>
# **DownloadsMbedFactoryProvisioningPackageInfoGet**
> AListOfDownloadableFactoryToolVersions_ DownloadsMbedFactoryProvisioningPackageInfoGet (string authorization)



Gets a list of downloadable Factory Tool versions. * mbed Cloud user role must be Administrator. * mbed Cloud account must have Factory Tool downloads enabled. 

### Example
```csharp
using System;
using System.Diagnostics;
using factory_tool.Api;
using factory_tool.Client;
using factory_tool.Model;

namespace Example
{
    public class DownloadsMbedFactoryProvisioningPackageInfoGetExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var authorization = authorization_example;  // string | \"Bearer\" followed by a reference token (API key forbidden).

            try
            {
                AListOfDownloadableFactoryToolVersions_ result = apiInstance.DownloadsMbedFactoryProvisioningPackageInfoGet(authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DownloadsMbedFactoryProvisioningPackageInfoGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**| \&quot;Bearer\&quot; followed by a reference token (API key forbidden). | 

### Return type

[**AListOfDownloadableFactoryToolVersions_**](AListOfDownloadableFactoryToolVersions_.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="downloadsmbedfactoryprovisioningpackageososget"></a>
# **DownloadsMbedFactoryProvisioningPackageososGet**
> void DownloadsMbedFactoryProvisioningPackageososGet (string authorization, string os)



Returns a specific Factory Tool package in a ZIP archive. * mbed Cloud user role must be Administrator. * mbed Cloud account must have Factory Tool downloads enabled. 

### Example
```csharp
using System;
using System.Diagnostics;
using factory_tool.Api;
using factory_tool.Client;
using factory_tool.Model;

namespace Example
{
    public class DownloadsMbedFactoryProvisioningPackageososGetExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var authorization = authorization_example;  // string | \"Bearer\" followed by a reference token (API key forbidden).
            var os = os_example;  // string | Requires Factory Tool OS name (Windows or Linux).

            try
            {
                apiInstance.DownloadsMbedFactoryProvisioningPackageososGet(authorization, os);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DownloadsMbedFactoryProvisioningPackageososGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**| \&quot;Bearer\&quot; followed by a reference token (API key forbidden). | 
 **os** | **string**| Requires Factory Tool OS name (Windows or Linux). | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

