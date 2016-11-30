# device_catalog.Api.DefaultApi

All URIs are relative to *http://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeviceCreate**](DefaultApi.md#devicecreate) | **POST** /v3/devices{var} | 
[**DeviceDestroy**](DefaultApi.md#devicedestroy) | **DELETE** /v3/devices/{device_id}{var} | 
[**DeviceList**](DefaultApi.md#devicelist) | **GET** /v3/devices{var} | 
[**DeviceLogList**](DefaultApi.md#deviceloglist) | **GET** /v3/devicelog{var} | 
[**DeviceLogRetrieve**](DefaultApi.md#devicelogretrieve) | **GET** /v3/devicelog/{device_log_id}{var} | 
[**DevicePartialUpdate**](DefaultApi.md#devicepartialupdate) | **PATCH** /v3/devices/{device_id}{var} | 
[**DeviceRetrieve**](DefaultApi.md#deviceretrieve) | **GET** /v3/devices/{device_id}{var} | 
[**DeviceUpdate**](DefaultApi.md#deviceupdate) | **PUT** /v3/devices/{device_id}{var} | 


<a name="devicecreate"></a>
# **DeviceCreate**
> DeviceSerializer DeviceCreate ()



<p>The APIs for creating and manipulating devices.  </p> <p>Create device</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_catalog.Api;
using device_catalog.Client;
using device_catalog.Model;

namespace Example
{
    public class DeviceCreateExample
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
                DeviceSerializer result = apiInstance.DeviceCreate();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceCreate: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**DeviceSerializer**](DeviceSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicedestroy"></a>
# **DeviceDestroy**
> DeviceSerializer DeviceDestroy (string deviceId)



<p>The APIs for creating and manipulating devices.  </p> <p>Delete device</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_catalog.Api;
using device_catalog.Client;
using device_catalog.Model;

namespace Example
{
    public class DeviceDestroyExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var deviceId = deviceId_example;  // string | 

            try
            {
                DeviceSerializer result = apiInstance.DeviceDestroy(deviceId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceDestroy: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceId** | **string**|  | 

### Return type

[**DeviceSerializer**](DeviceSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicelist"></a>
# **DeviceList**
> List<DeviceSerializer> DeviceList (string _object = null, int? limit = null, bool? hasMore = null, List<string> data = null, string order = null, string after = null, int? totalCount = null)



<p>The APIs for creating and manipulating devices.  </p> <p>List all update devices. The result is paged into pages of 100.</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_catalog.Api;
using device_catalog.Client;
using device_catalog.Model;

namespace Example
{
    public class DeviceListExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var _object = _object_example;  // string |  (optional) 
            var limit = 56;  // int? |  (optional) 
            var hasMore = true;  // bool? |  (optional) 
            var data = new List<string>(); // List<string> |  (optional) 
            var order = order_example;  // string |  (optional) 
            var after = after_example;  // string |  (optional) 
            var totalCount = 56;  // int? |  (optional) 

            try
            {
                List&lt;DeviceSerializer&gt; result = apiInstance.DeviceList(_object, limit, hasMore, data, order, after, totalCount);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceList: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **_object** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] 
 **hasMore** | **bool?**|  | [optional] 
 **data** | [**List<string>**](string.md)|  | [optional] 
 **order** | **string**|  | [optional] 
 **after** | **string**|  | [optional] 
 **totalCount** | **int?**|  | [optional] 

### Return type

[**List<DeviceSerializer>**](DeviceSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deviceloglist"></a>
# **DeviceLogList**
> List<DeviceLogSerializer> DeviceLogList (string _object = null, int? limit = null, bool? hasMore = null, List<string> data = null, string order = null, string after = null, int? totalCount = null)



<p>The APIs for creating and manipulating devices.  </p> <p>List all device logs.</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_catalog.Api;
using device_catalog.Client;
using device_catalog.Model;

namespace Example
{
    public class DeviceLogListExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var _object = _object_example;  // string |  (optional) 
            var limit = 56;  // int? |  (optional) 
            var hasMore = true;  // bool? |  (optional) 
            var data = new List<string>(); // List<string> |  (optional) 
            var order = order_example;  // string |  (optional) 
            var after = after_example;  // string |  (optional) 
            var totalCount = 56;  // int? |  (optional) 

            try
            {
                List&lt;DeviceLogSerializer&gt; result = apiInstance.DeviceLogList(_object, limit, hasMore, data, order, after, totalCount);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceLogList: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **_object** | **string**|  | [optional] 
 **limit** | **int?**|  | [optional] 
 **hasMore** | **bool?**|  | [optional] 
 **data** | [**List<string>**](string.md)|  | [optional] 
 **order** | **string**|  | [optional] 
 **after** | **string**|  | [optional] 
 **totalCount** | **int?**|  | [optional] 

### Return type

[**List<DeviceLogSerializer>**](DeviceLogSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicelogretrieve"></a>
# **DeviceLogRetrieve**
> DeviceLogSerializer DeviceLogRetrieve (string deviceLogId)



<p>The APIs for creating and manipulating devices.  </p> <p>Retrieve device log.</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_catalog.Api;
using device_catalog.Client;
using device_catalog.Model;

namespace Example
{
    public class DeviceLogRetrieveExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var deviceLogId = deviceLogId_example;  // string | 

            try
            {
                DeviceLogSerializer result = apiInstance.DeviceLogRetrieve(deviceLogId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceLogRetrieve: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceLogId** | **string**|  | 

### Return type

[**DeviceLogSerializer**](DeviceLogSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicepartialupdate"></a>
# **DevicePartialUpdate**
> DeviceSerializer DevicePartialUpdate (string deviceId)



<p>The APIs for creating and manipulating devices.  </p> <p>Update device fields</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_catalog.Api;
using device_catalog.Client;
using device_catalog.Model;

namespace Example
{
    public class DevicePartialUpdateExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var deviceId = deviceId_example;  // string | The ID of the device

            try
            {
                DeviceSerializer result = apiInstance.DevicePartialUpdate(deviceId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DevicePartialUpdate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceId** | **string**| The ID of the device | 

### Return type

[**DeviceSerializer**](DeviceSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deviceretrieve"></a>
# **DeviceRetrieve**
> DeviceSerializer DeviceRetrieve (string deviceId)



<p>The APIs for creating and manipulating devices.  </p> <p>Retrieve device.</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_catalog.Api;
using device_catalog.Client;
using device_catalog.Model;

namespace Example
{
    public class DeviceRetrieveExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var deviceId = deviceId_example;  // string | 

            try
            {
                DeviceSerializer result = apiInstance.DeviceRetrieve(deviceId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceRetrieve: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceId** | **string**|  | 

### Return type

[**DeviceSerializer**](DeviceSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deviceupdate"></a>
# **DeviceUpdate**
> DeviceSerializer DeviceUpdate (string deviceId)



<p>The APIs for creating and manipulating devices.  </p> <p>Update device.</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_catalog.Api;
using device_catalog.Client;
using device_catalog.Model;

namespace Example
{
    public class DeviceUpdateExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var deviceId = deviceId_example;  // string | The ID of the device

            try
            {
                DeviceSerializer result = apiInstance.DeviceUpdate(deviceId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceUpdate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceId** | **string**| The ID of the device | 

### Return type

[**DeviceSerializer**](DeviceSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

