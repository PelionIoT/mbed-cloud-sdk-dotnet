# factory_tool.Api.DefaultApi

All URIs are relative to *https://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DownloadsMbedFactoryProvisioningPackageGet**](DefaultApi.md#downloadsmbedfactoryprovisioningpackageget) | **GET** /downloads/mbed_factory_provisioning_package | 
[**DownloadsMbedFactoryProvisioningPackageInfoGet**](DefaultApi.md#downloadsmbedfactoryprovisioningpackageinfoget) | **GET** /downloads/mbed_factory_provisioning_package/info | 


<a name="downloadsmbedfactoryprovisioningpackageget"></a>
# **DownloadsMbedFactoryProvisioningPackageGet**
> byte[] DownloadsMbedFactoryProvisioningPackageGet (string os)



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
    public class DownloadsMbedFactoryProvisioningPackageGetExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var os = os_example;  // string | Requires Factory Tool OS name (Windows or Linux).

            try
            {
                byte[] result = apiInstance.DownloadsMbedFactoryProvisioningPackageGet(os);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DownloadsMbedFactoryProvisioningPackageGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **os** | **string**| Requires Factory Tool OS name (Windows or Linux). | 

### Return type

**byte[]**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="downloadsmbedfactoryprovisioningpackageinfoget"></a>
# **DownloadsMbedFactoryProvisioningPackageInfoGet**
> AListOfDownloadableFactoryToolVersions_ DownloadsMbedFactoryProvisioningPackageInfoGet ()



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

            try
            {
                AListOfDownloadableFactoryToolVersions_ result = apiInstance.DownloadsMbedFactoryProvisioningPackageInfoGet();
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
This endpoint does not need any parameter.

### Return type

[**AListOfDownloadableFactoryToolVersions_**](AListOfDownloadableFactoryToolVersions_.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

