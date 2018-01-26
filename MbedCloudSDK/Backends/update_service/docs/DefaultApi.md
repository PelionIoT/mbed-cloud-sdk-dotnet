# update_service.Api.DefaultApi

All URIs are relative to *https://api.us-east-1.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**FirmwareImageCreate**](DefaultApi.md#firmwareimagecreate) | **POST** /v3/firmware-images/ | 
[**FirmwareImageDestroy**](DefaultApi.md#firmwareimagedestroy) | **DELETE** /v3/firmware-images/{image_id}/ | 
[**FirmwareImageList**](DefaultApi.md#firmwareimagelist) | **GET** /v3/firmware-images/ | 
[**FirmwareImageRetrieve**](DefaultApi.md#firmwareimageretrieve) | **GET** /v3/firmware-images/{image_id}/ | 
[**FirmwareManifestCreate**](DefaultApi.md#firmwaremanifestcreate) | **POST** /v3/firmware-manifests/ | 
[**FirmwareManifestDestroy**](DefaultApi.md#firmwaremanifestdestroy) | **DELETE** /v3/firmware-manifests/{manifest_id}/ | 
[**FirmwareManifestList**](DefaultApi.md#firmwaremanifestlist) | **GET** /v3/firmware-manifests/ | 
[**FirmwareManifestRetrieve**](DefaultApi.md#firmwaremanifestretrieve) | **GET** /v3/firmware-manifests/{manifest_id}/ | 
[**UpdateCampaignCreate**](DefaultApi.md#updatecampaigncreate) | **POST** /v3/update-campaigns/ | 
[**UpdateCampaignDestroy**](DefaultApi.md#updatecampaigndestroy) | **DELETE** /v3/update-campaigns/{campaign_id}/ | 
[**UpdateCampaignList**](DefaultApi.md#updatecampaignlist) | **GET** /v3/update-campaigns/ | 
[**UpdateCampaignPartialUpdate**](DefaultApi.md#updatecampaignpartialupdate) | **PATCH** /v3/update-campaigns/{campaign_id}/ | 
[**UpdateCampaignRetrieve**](DefaultApi.md#updatecampaignretrieve) | **GET** /v3/update-campaigns/{campaign_id}/ | 
[**UpdateCampaignUpdate**](DefaultApi.md#updatecampaignupdate) | **PUT** /v3/update-campaigns/{campaign_id}/ | 
[**V3UpdateCampaignsCampaignIdCampaignDeviceMetadataCampaignDeviceMetadataIdGet**](DefaultApi.md#v3updatecampaignscampaignidcampaigndevicemetadatacampaigndevicemetadataidget) | **GET** /v3/update-campaigns/{campaign_id}/campaign-device-metadata/{campaign_device_metadata_id}/ | 
[**V3UpdateCampaignsCampaignIdCampaignDeviceMetadataGet**](DefaultApi.md#v3updatecampaignscampaignidcampaigndevicemetadataget) | **GET** /v3/update-campaigns/{campaign_id}/campaign-device-metadata/ | 


<a name="firmwareimagecreate"></a>
# **FirmwareImageCreate**
> FirmwareImage FirmwareImageCreate (System.IO.Stream datafile, string name, string description = null)



Create firmware image.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

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
            var datafile = new System.IO.Stream(); // System.IO.Stream | The firmware image file to upload
            var name = name_example;  // string | The name of the firmware image
            var description = description_example;  // string | The description of the firmware image (optional) 

            try
            {
                FirmwareImage result = apiInstance.FirmwareImageCreate(datafile, name, description);
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
 **datafile** | **System.IO.Stream**| The firmware image file to upload | 
 **name** | **string**| The name of the firmware image | 
 **description** | **string**| The description of the firmware image | [optional] 

### Return type

[**FirmwareImage**](FirmwareImage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="firmwareimagedestroy"></a>
# **FirmwareImageDestroy**
> void FirmwareImageDestroy (string imageId)



Delete firmware image.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

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
            var imageId = imageId_example;  // string | The firmware image ID

            try
            {
                apiInstance.FirmwareImageDestroy(imageId);
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
 **imageId** | **string**| The firmware image ID | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="firmwareimagelist"></a>
# **FirmwareImageList**
> FirmwareImagePage FirmwareImageList (int? limit = null, string order = null, string after = null, string filter = null, string include = null)



List all firmware images.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

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
            var limit = 56;  // int? | How many firmware images to retrieve (optional) 
            var order = order_example;  // string | ASC or DESC (optional) 
            var after = after_example;  // string | The ID of the the item after which to retrieve the next page (optional) 
            var filter = filter_example;  // string | URL-encoded query string parameter to filter returned data  `?filter={URL-encoded query string}`  The query string is made up of key-value pairs separated by ampersands. For example, this query: `key1=value1&key2=value2&key3=value3`  would be URL-encoded as: `?filter=key1%3Dvalue1%26key2%3Dvalue2%26key3%3Dvalue3`   **Filtering by properties** `name=myimage`  **Filtering on date-time fields**  Date-time fields should be specified in UTC RFC3339 format, `YYYY-MM-DDThh:mm:ss.msZ`. There are three permitted variations:  * UTC RFC3339 with milliseconds. Example: `2016-11-30T16:25:12.1234Z` * UTC RFC3339 without milliseconds. Example: `2016-11-30T16:25:12Z` * UTC RFC3339 shortened without milliseconds and punctuation. Example: `20161130T162512Z`  Date-time filtering supports three operators:  * equality * greater than or equal to by appending `__gte` to the field name * less than or equal to by appending `__lte` to the field name  `{field name}[|__lte|__gte]={UTC RFC3339 date-time}`  Time ranges may be specified by including both the `__gte` and `__lte` forms in the filter. For example:  `created_at__gte=2016-11-30T16:25:12.1234Z&created_at__lte=2016-12-30T00:00:00Z`  **Filtering on multiple fields**  `name=myimage&created_at__gte=2016-11-30T16:25:12.1234Z&created_at__lte=2016-12-30T00:00:00Z` (optional) 
            var include = include_example;  // string | Comma-separated list of data fields to return. Currently supported: total_count (optional) 

            try
            {
                FirmwareImagePage result = apiInstance.FirmwareImageList(limit, order, after, filter, include);
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
 **limit** | **int?**| How many firmware images to retrieve | [optional] 
 **order** | **string**| ASC or DESC | [optional] 
 **after** | **string**| The ID of the the item after which to retrieve the next page | [optional] 
 **filter** | **string**| URL-encoded query string parameter to filter returned data  &#x60;?filter&#x3D;{URL-encoded query string}&#x60;  The query string is made up of key-value pairs separated by ampersands. For example, this query: &#x60;key1&#x3D;value1&amp;key2&#x3D;value2&amp;key3&#x3D;value3&#x60;  would be URL-encoded as: &#x60;?filter&#x3D;key1%3Dvalue1%26key2%3Dvalue2%26key3%3Dvalue3&#x60;   **Filtering by properties** &#x60;name&#x3D;myimage&#x60;  **Filtering on date-time fields**  Date-time fields should be specified in UTC RFC3339 format, &#x60;YYYY-MM-DDThh:mm:ss.msZ&#x60;. There are three permitted variations:  * UTC RFC3339 with milliseconds. Example: &#x60;2016-11-30T16:25:12.1234Z&#x60; * UTC RFC3339 without milliseconds. Example: &#x60;2016-11-30T16:25:12Z&#x60; * UTC RFC3339 shortened without milliseconds and punctuation. Example: &#x60;20161130T162512Z&#x60;  Date-time filtering supports three operators:  * equality * greater than or equal to by appending &#x60;__gte&#x60; to the field name * less than or equal to by appending &#x60;__lte&#x60; to the field name  &#x60;{field name}[|__lte|__gte]&#x3D;{UTC RFC3339 date-time}&#x60;  Time ranges may be specified by including both the &#x60;__gte&#x60; and &#x60;__lte&#x60; forms in the filter. For example:  &#x60;created_at__gte&#x3D;2016-11-30T16:25:12.1234Z&amp;created_at__lte&#x3D;2016-12-30T00:00:00Z&#x60;  **Filtering on multiple fields**  &#x60;name&#x3D;myimage&amp;created_at__gte&#x3D;2016-11-30T16:25:12.1234Z&amp;created_at__lte&#x3D;2016-12-30T00:00:00Z&#x60; | [optional] 
 **include** | **string**| Comma-separated list of data fields to return. Currently supported: total_count | [optional] 

### Return type

[**FirmwareImagePage**](FirmwareImagePage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="firmwareimageretrieve"></a>
# **FirmwareImageRetrieve**
> FirmwareImage FirmwareImageRetrieve (string imageId)



Retrieve firmware image.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

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
            var imageId = imageId_example;  // string | The firmware image ID

            try
            {
                FirmwareImage result = apiInstance.FirmwareImageRetrieve(imageId);
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
 **imageId** | **string**| The firmware image ID | 

### Return type

[**FirmwareImage**](FirmwareImage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="firmwaremanifestcreate"></a>
# **FirmwareManifestCreate**
> FirmwareManifest FirmwareManifestCreate (System.IO.Stream datafile, string name, string description = null)



Create firmware manifest.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

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
            var datafile = new System.IO.Stream(); // System.IO.Stream | The manifest file to create. The API gateway enforces the account-specific file size.
            var name = name_example;  // string | The name of the firmware manifest
            var description = description_example;  // string | The description of the firmware manifest (optional) 

            try
            {
                FirmwareManifest result = apiInstance.FirmwareManifestCreate(datafile, name, description);
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
 **datafile** | **System.IO.Stream**| The manifest file to create. The API gateway enforces the account-specific file size. | 
 **name** | **string**| The name of the firmware manifest | 
 **description** | **string**| The description of the firmware manifest | [optional] 

### Return type

[**FirmwareManifest**](FirmwareManifest.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="firmwaremanifestdestroy"></a>
# **FirmwareManifestDestroy**
> void FirmwareManifestDestroy (string manifestId)



Delete firmware manifest.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

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
            var manifestId = manifestId_example;  // string | The firmware manifest ID

            try
            {
                apiInstance.FirmwareManifestDestroy(manifestId);
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
 **manifestId** | **string**| The firmware manifest ID | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="firmwaremanifestlist"></a>
# **FirmwareManifestList**
> FirmwareManifestPage FirmwareManifestList (int? limit = null, string order = null, string after = null, string filter = null, string include = null)



List firmware manifests.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

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
            var limit = 56;  // int? | How many firmware manifests to retrieve (optional) 
            var order = order_example;  // string | ASC or DESC (optional) 
            var after = after_example;  // string | The ID of the the item after which to retrieve the next page. (optional) 
            var filter = filter_example;  // string | URL-encoded query string parameter to filter returned data  `?filter={URL-encoded query string}`  The query string is made up of key-value pairs separated by ampersands. For example, this query: `key1=value1&key2=value2&key3=value3`  would be URL-encoded as: `?filter=key1%3Dvalue1%26key2%3Dvalue2%26key3%3Dvalue3`   **Filtering by properties** `name=mymanifest`  **Filtering on date-time fields**  Date-time fields should be specified in UTC RFC3339 format, `YYYY-MM-DDThh:mm:ss.msZ`. There are three permitted variations:  * UTC RFC3339 with milliseconds. Example: `2016-11-30T16:25:12.1234Z` * UTC RFC3339 without milliseconds. Example: `2016-11-30T16:25:12Z` * UTC RFC3339 shortened without milliseconds and punctuation. Example: `20161130T162512Z`  Date-time filtering supports three operators:  * equality * greater than or equal to by appending `__gte` to the field name * less than or equal to by appending `__lte` to the field name  `{field name}[|__lte|__gte]={UTC RFC3339 date-time}`  Time ranges may be specified by including both the `__gte` and `__lte` forms in the filter. For example:  `created_at__gte=2016-11-30T16:25:12.1234Z&created_at__lte=2016-12-30T00:00:00Z`  **Filtering on multiple fields**  `name=mymanifest&created_at__gte=2016-11-30T16:25:12.1234Z&created_at__lte=2016-12-30T00:00:00Z` (optional) 
            var include = include_example;  // string | Comma-separated list of data fields to return. Currently supported: total_count (optional) 

            try
            {
                FirmwareManifestPage result = apiInstance.FirmwareManifestList(limit, order, after, filter, include);
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
 **limit** | **int?**| How many firmware manifests to retrieve | [optional] 
 **order** | **string**| ASC or DESC | [optional] 
 **after** | **string**| The ID of the the item after which to retrieve the next page. | [optional] 
 **filter** | **string**| URL-encoded query string parameter to filter returned data  &#x60;?filter&#x3D;{URL-encoded query string}&#x60;  The query string is made up of key-value pairs separated by ampersands. For example, this query: &#x60;key1&#x3D;value1&amp;key2&#x3D;value2&amp;key3&#x3D;value3&#x60;  would be URL-encoded as: &#x60;?filter&#x3D;key1%3Dvalue1%26key2%3Dvalue2%26key3%3Dvalue3&#x60;   **Filtering by properties** &#x60;name&#x3D;mymanifest&#x60;  **Filtering on date-time fields**  Date-time fields should be specified in UTC RFC3339 format, &#x60;YYYY-MM-DDThh:mm:ss.msZ&#x60;. There are three permitted variations:  * UTC RFC3339 with milliseconds. Example: &#x60;2016-11-30T16:25:12.1234Z&#x60; * UTC RFC3339 without milliseconds. Example: &#x60;2016-11-30T16:25:12Z&#x60; * UTC RFC3339 shortened without milliseconds and punctuation. Example: &#x60;20161130T162512Z&#x60;  Date-time filtering supports three operators:  * equality * greater than or equal to by appending &#x60;__gte&#x60; to the field name * less than or equal to by appending &#x60;__lte&#x60; to the field name  &#x60;{field name}[|__lte|__gte]&#x3D;{UTC RFC3339 date-time}&#x60;  Time ranges may be specified by including both the &#x60;__gte&#x60; and &#x60;__lte&#x60; forms in the filter. For example:  &#x60;created_at__gte&#x3D;2016-11-30T16:25:12.1234Z&amp;created_at__lte&#x3D;2016-12-30T00:00:00Z&#x60;  **Filtering on multiple fields**  &#x60;name&#x3D;mymanifest&amp;created_at__gte&#x3D;2016-11-30T16:25:12.1234Z&amp;created_at__lte&#x3D;2016-12-30T00:00:00Z&#x60; | [optional] 
 **include** | **string**| Comma-separated list of data fields to return. Currently supported: total_count | [optional] 

### Return type

[**FirmwareManifestPage**](FirmwareManifestPage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="firmwaremanifestretrieve"></a>
# **FirmwareManifestRetrieve**
> FirmwareManifest FirmwareManifestRetrieve (string manifestId)



Retrieve firmware manifest.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

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
            var manifestId = manifestId_example;  // string | The firmware manifest ID

            try
            {
                FirmwareManifest result = apiInstance.FirmwareManifestRetrieve(manifestId);
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
 **manifestId** | **string**| The firmware manifest ID | 

### Return type

[**FirmwareManifest**](FirmwareManifest.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatecampaigncreate"></a>
# **UpdateCampaignCreate**
> UpdateCampaign UpdateCampaignCreate (UpdateCampaignPostRequest campaign)



Create an update campaign.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

namespace Example
{
    public class UpdateCampaignCreateExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var campaign = new UpdateCampaignPostRequest(); // UpdateCampaignPostRequest | Update campaign

            try
            {
                UpdateCampaign result = apiInstance.UpdateCampaignCreate(campaign);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.UpdateCampaignCreate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **campaign** | [**UpdateCampaignPostRequest**](UpdateCampaignPostRequest.md)| Update campaign | 

### Return type

[**UpdateCampaign**](UpdateCampaign.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatecampaigndestroy"></a>
# **UpdateCampaignDestroy**
> void UpdateCampaignDestroy (string campaignId)



Delete an update campaign.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

namespace Example
{
    public class UpdateCampaignDestroyExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var campaignId = campaignId_example;  // string | The ID of the update campaign

            try
            {
                apiInstance.UpdateCampaignDestroy(campaignId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.UpdateCampaignDestroy: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **campaignId** | **string**| The ID of the update campaign | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatecampaignlist"></a>
# **UpdateCampaignList**
> UpdateCampaignPage UpdateCampaignList (int? limit = null, string order = null, string after = null, string filter = null, string include = null)



Get update campaigns for devices specified by a filter.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

namespace Example
{
    public class UpdateCampaignListExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var limit = 56;  // int? | How many update campaigns to retrieve (optional) 
            var order = order_example;  // string | The order of the records. Acceptable values: ASC, DESC. Default: ASC (optional) 
            var after = after_example;  // string | The ID of the the item after which to retrieve the next page (optional) 
            var filter = filter_example;  // string | URL-encoded query string parameter to filter returned data  `?filter={URL-encoded query string}`  The query string is made up of key-value pairs separated by ampersands. For example, this query: `key1=value1&key2=value2&key3=value3`  would be URL-encoded as: `?filter=key1%3Dvalue1%26key2%3Dvalue2%26key3%3Dvalue3`   **Filtering by campaign properties** `state=[draft|scheduled|devicefectch|devicecopy|publishing|deploying|deployed|manifestremoved|expired]`  `root_manifest_id=43217771234242e594ddb433816c498a`  **Filtering on date-time fields**  Date-time fields should be specified in UTC RFC3339 format, `YYYY-MM-DDThh:mm:ss.msZ`. There are three permitted variations:  * UTC RFC3339 with milliseconds. Example: `2016-11-30T16:25:12.1234Z` * UTC RFC3339 without milliseconds. Example: `2016-11-30T16:25:12Z` * UTC RFC3339 shortened without milliseconds and punctuation. Example: `20161130T162512Z`  Date-time filtering supports three operators:  * equality * greater than or equal to by appending `__gte` to the field name * less than or equal to by appending `__lte` to the field name  `{field name}[|__lte|__gte]={UTC RFC3339 date-time}`  Time ranges may be specified by including both the `__gte` and `__lte` forms in the filter. For example:  `created_at__gte=2016-11-30T16:25:12.1234Z&created_at__lte=2016-12-30T00:00:00Z`  **Filtering on multiple fields**  `state=deployed&created_at__gte=2016-11-30T16:25:12.1234Z&created_at__lte=2016-12-30T00:00:00Z` (optional) 
            var include = include_example;  // string | Comma-separated list of data fields to return. Currently supported: total_count (optional) 

            try
            {
                UpdateCampaignPage result = apiInstance.UpdateCampaignList(limit, order, after, filter, include);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.UpdateCampaignList: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **limit** | **int?**| How many update campaigns to retrieve | [optional] 
 **order** | **string**| The order of the records. Acceptable values: ASC, DESC. Default: ASC | [optional] 
 **after** | **string**| The ID of the the item after which to retrieve the next page | [optional] 
 **filter** | **string**| URL-encoded query string parameter to filter returned data  &#x60;?filter&#x3D;{URL-encoded query string}&#x60;  The query string is made up of key-value pairs separated by ampersands. For example, this query: &#x60;key1&#x3D;value1&amp;key2&#x3D;value2&amp;key3&#x3D;value3&#x60;  would be URL-encoded as: &#x60;?filter&#x3D;key1%3Dvalue1%26key2%3Dvalue2%26key3%3Dvalue3&#x60;   **Filtering by campaign properties** &#x60;state&#x3D;[draft|scheduled|devicefectch|devicecopy|publishing|deploying|deployed|manifestremoved|expired]&#x60;  &#x60;root_manifest_id&#x3D;43217771234242e594ddb433816c498a&#x60;  **Filtering on date-time fields**  Date-time fields should be specified in UTC RFC3339 format, &#x60;YYYY-MM-DDThh:mm:ss.msZ&#x60;. There are three permitted variations:  * UTC RFC3339 with milliseconds. Example: &#x60;2016-11-30T16:25:12.1234Z&#x60; * UTC RFC3339 without milliseconds. Example: &#x60;2016-11-30T16:25:12Z&#x60; * UTC RFC3339 shortened without milliseconds and punctuation. Example: &#x60;20161130T162512Z&#x60;  Date-time filtering supports three operators:  * equality * greater than or equal to by appending &#x60;__gte&#x60; to the field name * less than or equal to by appending &#x60;__lte&#x60; to the field name  &#x60;{field name}[|__lte|__gte]&#x3D;{UTC RFC3339 date-time}&#x60;  Time ranges may be specified by including both the &#x60;__gte&#x60; and &#x60;__lte&#x60; forms in the filter. For example:  &#x60;created_at__gte&#x3D;2016-11-30T16:25:12.1234Z&amp;created_at__lte&#x3D;2016-12-30T00:00:00Z&#x60;  **Filtering on multiple fields**  &#x60;state&#x3D;deployed&amp;created_at__gte&#x3D;2016-11-30T16:25:12.1234Z&amp;created_at__lte&#x3D;2016-12-30T00:00:00Z&#x60; | [optional] 
 **include** | **string**| Comma-separated list of data fields to return. Currently supported: total_count | [optional] 

### Return type

[**UpdateCampaignPage**](UpdateCampaignPage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatecampaignpartialupdate"></a>
# **UpdateCampaignPartialUpdate**
> UpdateCampaign UpdateCampaignPartialUpdate (string campaignId, UpdateCampaignPatchRequest campaign)



Modify a subset of an update campaign's fields.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

namespace Example
{
    public class UpdateCampaignPartialUpdateExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var campaignId = campaignId_example;  // string | 
            var campaign = new UpdateCampaignPatchRequest(); // UpdateCampaignPatchRequest | Update campaign

            try
            {
                UpdateCampaign result = apiInstance.UpdateCampaignPartialUpdate(campaignId, campaign);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.UpdateCampaignPartialUpdate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **campaignId** | **string**|  | 
 **campaign** | [**UpdateCampaignPatchRequest**](UpdateCampaignPatchRequest.md)| Update campaign | 

### Return type

[**UpdateCampaign**](UpdateCampaign.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatecampaignretrieve"></a>
# **UpdateCampaignRetrieve**
> UpdateCampaign UpdateCampaignRetrieve (string campaignId)



Get an update campaign.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

namespace Example
{
    public class UpdateCampaignRetrieveExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var campaignId = campaignId_example;  // string | The campaign ID

            try
            {
                UpdateCampaign result = apiInstance.UpdateCampaignRetrieve(campaignId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.UpdateCampaignRetrieve: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **campaignId** | **string**| The campaign ID | 

### Return type

[**UpdateCampaign**](UpdateCampaign.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatecampaignupdate"></a>
# **UpdateCampaignUpdate**
> UpdateCampaign UpdateCampaignUpdate (string campaignId, UpdateCampaignPutRequest campaign)



Modify an update campaign.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

namespace Example
{
    public class UpdateCampaignUpdateExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var campaignId = campaignId_example;  // string | 
            var campaign = new UpdateCampaignPutRequest(); // UpdateCampaignPutRequest | Update campaign

            try
            {
                UpdateCampaign result = apiInstance.UpdateCampaignUpdate(campaignId, campaign);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.UpdateCampaignUpdate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **campaignId** | **string**|  | 
 **campaign** | [**UpdateCampaignPutRequest**](UpdateCampaignPutRequest.md)| Update campaign | 

### Return type

[**UpdateCampaign**](UpdateCampaign.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3updatecampaignscampaignidcampaigndevicemetadatacampaigndevicemetadataidget"></a>
# **V3UpdateCampaignsCampaignIdCampaignDeviceMetadataCampaignDeviceMetadataIdGet**
> CampaignDeviceMetadata V3UpdateCampaignsCampaignIdCampaignDeviceMetadataCampaignDeviceMetadataIdGet (string campaignId, string campaignDeviceMetadataId)



Get update campaign metadata.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

namespace Example
{
    public class V3UpdateCampaignsCampaignIdCampaignDeviceMetadataCampaignDeviceMetadataIdGetExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var campaignId = campaignId_example;  // string | The update campaign ID
            var campaignDeviceMetadataId = campaignDeviceMetadataId_example;  // string | The campaign device metadata ID

            try
            {
                CampaignDeviceMetadata result = apiInstance.V3UpdateCampaignsCampaignIdCampaignDeviceMetadataCampaignDeviceMetadataIdGet(campaignId, campaignDeviceMetadataId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.V3UpdateCampaignsCampaignIdCampaignDeviceMetadataCampaignDeviceMetadataIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **campaignId** | **string**| The update campaign ID | 
 **campaignDeviceMetadataId** | **string**| The campaign device metadata ID | 

### Return type

[**CampaignDeviceMetadata**](CampaignDeviceMetadata.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3updatecampaignscampaignidcampaigndevicemetadataget"></a>
# **V3UpdateCampaignsCampaignIdCampaignDeviceMetadataGet**
> CampaignDeviceMetadataPage V3UpdateCampaignsCampaignIdCampaignDeviceMetadataGet (string campaignId, int? limit = null, string order = null, string after = null, string include = null)



Get campaign device metadata.

### Example
```csharp
using System;
using System.Diagnostics;
using update_service.Api;
using update_service.Client;
using update_service.Model;

namespace Example
{
    public class V3UpdateCampaignsCampaignIdCampaignDeviceMetadataGetExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var campaignId = campaignId_example;  // string | The update campaign ID
            var limit = 56;  // int? | How many objects to retrieve in the page (optional) 
            var order = order_example;  // string | ASC or DESC (optional) 
            var after = after_example;  // string | The ID of the the item after which to retrieve the next page (optional) 
            var include = include_example;  // string | Comma-separated list of data fields to return. Currently supported: total_count (optional) 

            try
            {
                CampaignDeviceMetadataPage result = apiInstance.V3UpdateCampaignsCampaignIdCampaignDeviceMetadataGet(campaignId, limit, order, after, include);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.V3UpdateCampaignsCampaignIdCampaignDeviceMetadataGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **campaignId** | **string**| The update campaign ID | 
 **limit** | **int?**| How many objects to retrieve in the page | [optional] 
 **order** | **string**| ASC or DESC | [optional] 
 **after** | **string**| The ID of the the item after which to retrieve the next page | [optional] 
 **include** | **string**| Comma-separated list of data fields to return. Currently supported: total_count | [optional] 

### Return type

[**CampaignDeviceMetadataPage**](CampaignDeviceMetadataPage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

