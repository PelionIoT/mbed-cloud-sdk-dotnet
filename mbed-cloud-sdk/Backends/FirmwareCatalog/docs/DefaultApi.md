# firmware_catalog.Api.DefaultApi

All URIs are relative to *http://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeployInfoGET**](DefaultApi.md#deployinfoget) | **GET** /v3/fc_deploy_info | Reads the deploy_info
[**FirmwareImageCreate**](DefaultApi.md#firmwareimagecreate) | **POST** /v3/firmware/images/ | Create firmware image
[**FirmwareImageDestroy**](DefaultApi.md#firmwareimagedestroy) | **DELETE** /v3/firmware/images/{image_id}/ | Delete firmware image
[**FirmwareImageList**](DefaultApi.md#firmwareimagelist) | **GET** /v3/firmware/images/ | List all firmware images
[**FirmwareImageRetrieve**](DefaultApi.md#firmwareimageretrieve) | **GET** /v3/firmware/images/{image_id}/ | Retrieve firmware image
[**FirmwareManifestCreate**](DefaultApi.md#firmwaremanifestcreate) | **POST** /v3/firmware/manifests/ | Create firmware manifest
[**FirmwareManifestDestroy**](DefaultApi.md#firmwaremanifestdestroy) | **DELETE** /v3/firmware/manifests/{manifest_id}/ | Delete firmware manifest
[**FirmwareManifestList**](DefaultApi.md#firmwaremanifestlist) | **GET** /v3/firmware/manifests/ | List all firmware manifests
[**FirmwareManifestRetrieve**](DefaultApi.md#firmwaremanifestretrieve) | **GET** /v3/firmware/manifests/{manifest_id}/ | Retrieve firmware manifest


<a name="deployinfoget"></a>
# **DeployInfoGET**
> Object DeployInfoGET ()

Reads the deploy_info

<p>Reads the deploy_info.json file and returns the Build and Git ID to the caller.</p> <p>Will return a 500 error if the file is missing, cannot be parsed or the keys are missing.</p>

### Example
```csharp
using System;
using System.Diagnostics;
using firmware_catalog.Api;
using firmware_catalog.Client;
using firmware_catalog.Model;

namespace Example
{
    public class DeployInfoGETExample
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
                // Reads the deploy_info
                Object result = apiInstance.DeployInfoGET();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeployInfoGET: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**Object**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="firmwareimagecreate"></a>
# **FirmwareImageCreate**
> FirmwareImageSerializer FirmwareImageCreate (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null)

Create firmware image

<p>The APIs for creating and manipulating firmware images.  </p> <p>Create firmware image</p><pre>YAMLError:  while scanning a simple key   in \"<unicode string>\", line 16, column 9:             Cannot validate the data used to ...              ^ could not find expected ':'   in \"<unicode string>\", line 17, column 5:         - code: 401         ^</pre>

### Example
```csharp
using System;
using System.Diagnostics;
using firmware_catalog.Api;
using firmware_catalog.Client;
using firmware_catalog.Model;

namespace Example
{
    public class FirmwareImageCreateExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var datafile = datafile_example;  // string | The binary file of firmware image
            var name = name_example;  // string | The name of the object
            var description = description_example;  // string | The description of the object (optional) 
            var updatingRequestId = updatingRequestId_example;  // string |  (optional) 
            var updatingIpAddress = updatingIpAddress_example;  // string |  (optional) 
            var name2 = name_example;  // string |  (optional) 
            var description2 = description_example;  // string |  (optional) 
            var createdAt = createdAt_example;  // string |  (optional) 
            var updatedAt = updatedAt_example;  // string |  (optional) 
            var datafileChecksum = datafileChecksum_example;  // string |  (optional) 
            var etag = etag_example;  // string |  (optional) 
            var imageId = imageId_example;  // string |  (optional) 
            var _object = _object_example;  // string |  (optional) 

            try
            {
                // Create firmware image
                FirmwareImageSerializer result = apiInstance.FirmwareImageCreate(datafile, name, description, updatingRequestId, updatingIpAddress, name2, description2, createdAt, updatedAt, datafileChecksum, etag, imageId, _object);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.FirmwareImageCreate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **datafile** | **string**| The binary file of firmware image | 
 **name** | **string**| The name of the object | 
 **description** | **string**| The description of the object | [optional] 
 **updatingRequestId** | **string**|  | [optional] 
 **updatingIpAddress** | **string**|  | [optional] 
 **name2** | **string**|  | [optional] 
 **description2** | **string**|  | [optional] 
 **createdAt** | **string**|  | [optional] 
 **updatedAt** | **string**|  | [optional] 
 **datafileChecksum** | **string**|  | [optional] 
 **etag** | **string**|  | [optional] 
 **imageId** | **string**|  | [optional] 
 **_object** | **string**|  | [optional] 

### Return type

[**FirmwareImageSerializer**](FirmwareImageSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="firmwareimagedestroy"></a>
# **FirmwareImageDestroy**
> FirmwareImageSerializer FirmwareImageDestroy (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null)

Delete firmware image

<p>The APIs for creating and manipulating firmware images.  </p> <p>Delete firmware image</p>

### Example
```csharp
using System;
using System.Diagnostics;
using firmware_catalog.Api;
using firmware_catalog.Client;
using firmware_catalog.Model;

namespace Example
{
    public class FirmwareImageDestroyExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var imageId = 56;  // int? | The ID of the firmware image
            var updatingRequestId = updatingRequestId_example;  // string |  (optional) 
            var updatingIpAddress = updatingIpAddress_example;  // string |  (optional) 
            var name = name_example;  // string |  (optional) 
            var description = description_example;  // string |  (optional) 
            var createdAt = createdAt_example;  // string |  (optional) 
            var updatedAt = updatedAt_example;  // string |  (optional) 
            var datafileChecksum = datafileChecksum_example;  // string |  (optional) 
            var etag = etag_example;  // string |  (optional) 
            var _object = _object_example;  // string |  (optional) 

            try
            {
                // Delete firmware image
                FirmwareImageSerializer result = apiInstance.FirmwareImageDestroy(imageId, updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, etag, _object);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.FirmwareImageDestroy: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **imageId** | **int?**| The ID of the firmware image | 
 **updatingRequestId** | **string**|  | [optional] 
 **updatingIpAddress** | **string**|  | [optional] 
 **name** | **string**|  | [optional] 
 **description** | **string**|  | [optional] 
 **createdAt** | **string**|  | [optional] 
 **updatedAt** | **string**|  | [optional] 
 **datafileChecksum** | **string**|  | [optional] 
 **etag** | **string**|  | [optional] 
 **_object** | **string**|  | [optional] 

### Return type

[**FirmwareImageSerializer**](FirmwareImageSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="firmwareimagelist"></a>
# **FirmwareImageList**
> List<FirmwareImageSerializer> FirmwareImageList (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null, int? page = null)

List all firmware images

<p>The APIs for creating and manipulating firmware images.  </p> <p>List all firmware images. The result will be paged into pages of 100.</p>

### Example
```csharp
using System;
using System.Diagnostics;
using firmware_catalog.Api;
using firmware_catalog.Client;
using firmware_catalog.Model;

namespace Example
{
    public class FirmwareImageListExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var updatingRequestId = updatingRequestId_example;  // string |  (optional) 
            var updatingIpAddress = updatingIpAddress_example;  // string |  (optional) 
            var name = name_example;  // string |  (optional) 
            var description = description_example;  // string |  (optional) 
            var createdAt = createdAt_example;  // string |  (optional) 
            var updatedAt = updatedAt_example;  // string |  (optional) 
            var datafileChecksum = datafileChecksum_example;  // string |  (optional) 
            var etag = etag_example;  // string |  (optional) 
            var imageId = imageId_example;  // string |  (optional) 
            var _object = _object_example;  // string |  (optional) 
            var page = 56;  // int? | The page number to retrieve. If not given, then defaults to first page.  (optional) 

            try
            {
                // List all firmware images
                List&lt;FirmwareImageSerializer&gt; result = apiInstance.FirmwareImageList(updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, etag, imageId, _object, page);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.FirmwareImageList: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **updatingRequestId** | **string**|  | [optional] 
 **updatingIpAddress** | **string**|  | [optional] 
 **name** | **string**|  | [optional] 
 **description** | **string**|  | [optional] 
 **createdAt** | **string**|  | [optional] 
 **updatedAt** | **string**|  | [optional] 
 **datafileChecksum** | **string**|  | [optional] 
 **etag** | **string**|  | [optional] 
 **imageId** | **string**|  | [optional] 
 **_object** | **string**|  | [optional] 
 **page** | **int?**| The page number to retrieve. If not given, then defaults to first page.  | [optional] 

### Return type

[**List<FirmwareImageSerializer>**](FirmwareImageSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="firmwareimageretrieve"></a>
# **FirmwareImageRetrieve**
> FirmwareImageSerializer FirmwareImageRetrieve (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null)

Retrieve firmware image

<p>The APIs for creating and manipulating firmware images.  </p> <p>Retrieve firmware image</p>

### Example
```csharp
using System;
using System.Diagnostics;
using firmware_catalog.Api;
using firmware_catalog.Client;
using firmware_catalog.Model;

namespace Example
{
    public class FirmwareImageRetrieveExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var imageId = 56;  // int? | The ID of the firmware image
            var updatingRequestId = updatingRequestId_example;  // string |  (optional) 
            var updatingIpAddress = updatingIpAddress_example;  // string |  (optional) 
            var name = name_example;  // string |  (optional) 
            var description = description_example;  // string |  (optional) 
            var createdAt = createdAt_example;  // string |  (optional) 
            var updatedAt = updatedAt_example;  // string |  (optional) 
            var datafileChecksum = datafileChecksum_example;  // string |  (optional) 
            var etag = etag_example;  // string |  (optional) 
            var _object = _object_example;  // string |  (optional) 

            try
            {
                // Retrieve firmware image
                FirmwareImageSerializer result = apiInstance.FirmwareImageRetrieve(imageId, updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, etag, _object);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.FirmwareImageRetrieve: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **imageId** | **int?**| The ID of the firmware image | 
 **updatingRequestId** | **string**|  | [optional] 
 **updatingIpAddress** | **string**|  | [optional] 
 **name** | **string**|  | [optional] 
 **description** | **string**|  | [optional] 
 **createdAt** | **string**|  | [optional] 
 **updatedAt** | **string**|  | [optional] 
 **datafileChecksum** | **string**|  | [optional] 
 **etag** | **string**|  | [optional] 
 **_object** | **string**|  | [optional] 

### Return type

[**FirmwareImageSerializer**](FirmwareImageSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="firmwaremanifestcreate"></a>
# **FirmwareManifestCreate**
> FirmwareManifestSerializer FirmwareManifestCreate (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null)

Create firmware manifest

<p>The APIs for creating and manipulating firmware manifests.  </p> <p>Create firmware manifest</p>

### Example
```csharp
using System;
using System.Diagnostics;
using firmware_catalog.Api;
using firmware_catalog.Client;
using firmware_catalog.Model;

namespace Example
{
    public class FirmwareManifestCreateExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var datafile = datafile_example;  // string | The manifest file to create
            var name = name_example;  // string | The name of the object
            var description = description_example;  // string | The description of the object (optional) 
            var updatingRequestId = updatingRequestId_example;  // string |  (optional) 
            var updatingIpAddress = updatingIpAddress_example;  // string |  (optional) 
            var name2 = name_example;  // string |  (optional) 
            var description2 = description_example;  // string |  (optional) 
            var createdAt = createdAt_example;  // string |  (optional) 
            var updatedAt = updatedAt_example;  // string |  (optional) 
            var datafileChecksum = datafileChecksum_example;  // string |  (optional) 
            var deviceClass = deviceClass_example;  // string |  (optional) 
            var etag = etag_example;  // string |  (optional) 
            var manifestId = manifestId_example;  // string |  (optional) 
            var _object = _object_example;  // string |  (optional) 
            var timestamp = timestamp_example;  // string |  (optional) 

            try
            {
                // Create firmware manifest
                FirmwareManifestSerializer result = apiInstance.FirmwareManifestCreate(datafile, name, description, updatingRequestId, updatingIpAddress, name2, description2, createdAt, updatedAt, datafileChecksum, deviceClass, etag, manifestId, _object, timestamp);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.FirmwareManifestCreate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **datafile** | **string**| The manifest file to create | 
 **name** | **string**| The name of the object | 
 **description** | **string**| The description of the object | [optional] 
 **updatingRequestId** | **string**|  | [optional] 
 **updatingIpAddress** | **string**|  | [optional] 
 **name2** | **string**|  | [optional] 
 **description2** | **string**|  | [optional] 
 **createdAt** | **string**|  | [optional] 
 **updatedAt** | **string**|  | [optional] 
 **datafileChecksum** | **string**|  | [optional] 
 **deviceClass** | **string**|  | [optional] 
 **etag** | **string**|  | [optional] 
 **manifestId** | **string**|  | [optional] 
 **_object** | **string**|  | [optional] 
 **timestamp** | **string**|  | [optional] 

### Return type

[**FirmwareManifestSerializer**](FirmwareManifestSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="firmwaremanifestdestroy"></a>
# **FirmwareManifestDestroy**
> FirmwareManifestSerializer FirmwareManifestDestroy (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null)

Delete firmware manifest

<p>The APIs for creating and manipulating firmware manifests.  </p> <p>Delete firmware manifest</p>

### Example
```csharp
using System;
using System.Diagnostics;
using firmware_catalog.Api;
using firmware_catalog.Client;
using firmware_catalog.Model;

namespace Example
{
    public class FirmwareManifestDestroyExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var manifestId = 56;  // int? | The ID of the firmware manifest
            var updatingRequestId = updatingRequestId_example;  // string |  (optional) 
            var updatingIpAddress = updatingIpAddress_example;  // string |  (optional) 
            var name = name_example;  // string |  (optional) 
            var description = description_example;  // string |  (optional) 
            var createdAt = createdAt_example;  // string |  (optional) 
            var updatedAt = updatedAt_example;  // string |  (optional) 
            var datafileChecksum = datafileChecksum_example;  // string |  (optional) 
            var deviceClass = deviceClass_example;  // string |  (optional) 
            var etag = etag_example;  // string |  (optional) 
            var _object = _object_example;  // string |  (optional) 
            var timestamp = timestamp_example;  // string |  (optional) 

            try
            {
                // Delete firmware manifest
                FirmwareManifestSerializer result = apiInstance.FirmwareManifestDestroy(manifestId, updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, deviceClass, etag, _object, timestamp);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.FirmwareManifestDestroy: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **manifestId** | **int?**| The ID of the firmware manifest | 
 **updatingRequestId** | **string**|  | [optional] 
 **updatingIpAddress** | **string**|  | [optional] 
 **name** | **string**|  | [optional] 
 **description** | **string**|  | [optional] 
 **createdAt** | **string**|  | [optional] 
 **updatedAt** | **string**|  | [optional] 
 **datafileChecksum** | **string**|  | [optional] 
 **deviceClass** | **string**|  | [optional] 
 **etag** | **string**|  | [optional] 
 **_object** | **string**|  | [optional] 
 **timestamp** | **string**|  | [optional] 

### Return type

[**FirmwareManifestSerializer**](FirmwareManifestSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="firmwaremanifestlist"></a>
# **FirmwareManifestList**
> List<FirmwareManifestSerializer> FirmwareManifestList (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null, int? page = null)

List all firmware manifests

<p>The APIs for creating and manipulating firmware manifests.  </p> <p>List all firmware manifests</p>

### Example
```csharp
using System;
using System.Diagnostics;
using firmware_catalog.Api;
using firmware_catalog.Client;
using firmware_catalog.Model;

namespace Example
{
    public class FirmwareManifestListExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var updatingRequestId = updatingRequestId_example;  // string |  (optional) 
            var updatingIpAddress = updatingIpAddress_example;  // string |  (optional) 
            var name = name_example;  // string |  (optional) 
            var description = description_example;  // string |  (optional) 
            var createdAt = createdAt_example;  // string |  (optional) 
            var updatedAt = updatedAt_example;  // string |  (optional) 
            var datafileChecksum = datafileChecksum_example;  // string |  (optional) 
            var deviceClass = deviceClass_example;  // string |  (optional) 
            var etag = etag_example;  // string |  (optional) 
            var manifestId = manifestId_example;  // string |  (optional) 
            var _object = _object_example;  // string |  (optional) 
            var timestamp = timestamp_example;  // string |  (optional) 
            var page = 56;  // int? | The page number to retrieve. If not given, then defaults to first page.  (optional) 

            try
            {
                // List all firmware manifests
                List&lt;FirmwareManifestSerializer&gt; result = apiInstance.FirmwareManifestList(updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, deviceClass, etag, manifestId, _object, timestamp, page);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.FirmwareManifestList: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **updatingRequestId** | **string**|  | [optional] 
 **updatingIpAddress** | **string**|  | [optional] 
 **name** | **string**|  | [optional] 
 **description** | **string**|  | [optional] 
 **createdAt** | **string**|  | [optional] 
 **updatedAt** | **string**|  | [optional] 
 **datafileChecksum** | **string**|  | [optional] 
 **deviceClass** | **string**|  | [optional] 
 **etag** | **string**|  | [optional] 
 **manifestId** | **string**|  | [optional] 
 **_object** | **string**|  | [optional] 
 **timestamp** | **string**|  | [optional] 
 **page** | **int?**| The page number to retrieve. If not given, then defaults to first page.  | [optional] 

### Return type

[**List<FirmwareManifestSerializer>**](FirmwareManifestSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="firmwaremanifestretrieve"></a>
# **FirmwareManifestRetrieve**
> FirmwareManifestSerializer FirmwareManifestRetrieve (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null)

Retrieve firmware manifest

<p>The APIs for creating and manipulating firmware manifests.  </p> <p>Retrieve firmware manifest</p>

### Example
```csharp
using System;
using System.Diagnostics;
using firmware_catalog.Api;
using firmware_catalog.Client;
using firmware_catalog.Model;

namespace Example
{
    public class FirmwareManifestRetrieveExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var manifestId = 56;  // int? | The ID of the firmware manifest
            var updatingRequestId = updatingRequestId_example;  // string |  (optional) 
            var updatingIpAddress = updatingIpAddress_example;  // string |  (optional) 
            var name = name_example;  // string |  (optional) 
            var description = description_example;  // string |  (optional) 
            var createdAt = createdAt_example;  // string |  (optional) 
            var updatedAt = updatedAt_example;  // string |  (optional) 
            var datafileChecksum = datafileChecksum_example;  // string |  (optional) 
            var deviceClass = deviceClass_example;  // string |  (optional) 
            var etag = etag_example;  // string |  (optional) 
            var _object = _object_example;  // string |  (optional) 
            var timestamp = timestamp_example;  // string |  (optional) 

            try
            {
                // Retrieve firmware manifest
                FirmwareManifestSerializer result = apiInstance.FirmwareManifestRetrieve(manifestId, updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, deviceClass, etag, _object, timestamp);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.FirmwareManifestRetrieve: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **manifestId** | **int?**| The ID of the firmware manifest | 
 **updatingRequestId** | **string**|  | [optional] 
 **updatingIpAddress** | **string**|  | [optional] 
 **name** | **string**|  | [optional] 
 **description** | **string**|  | [optional] 
 **createdAt** | **string**|  | [optional] 
 **updatedAt** | **string**|  | [optional] 
 **datafileChecksum** | **string**|  | [optional] 
 **deviceClass** | **string**|  | [optional] 
 **etag** | **string**|  | [optional] 
 **_object** | **string**|  | [optional] 
 **timestamp** | **string**|  | [optional] 

### Return type

[**FirmwareManifestSerializer**](FirmwareManifestSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

