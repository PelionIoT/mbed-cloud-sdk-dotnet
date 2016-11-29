# device_catalog.Api.DefaultApi

All URIs are relative to *http://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeviceCreate**](DefaultApi.md#devicecreate) | **POST** /v3/devices/ | Create device
[**DeviceDestroy**](DefaultApi.md#devicedestroy) | **DELETE** /v3/devices/{device_id}/ | Delete device
[**DeviceList**](DefaultApi.md#devicelist) | **GET** /v3/devices/ | List all update devices
[**DeviceLogCreate**](DefaultApi.md#devicelogcreate) | **POST** /v3/devicelog/ | The APIs for creating and manipulating devices
[**DeviceLogDestroy**](DefaultApi.md#devicelogdestroy) | **DELETE** /v3/devicelog/{device_log_id}/ | The APIs for creating and manipulating devices
[**DeviceLogList**](DefaultApi.md#deviceloglist) | **GET** /v3/devicelog/ | List all device logs
[**DeviceLogPartialUpdate**](DefaultApi.md#devicelogpartialupdate) | **PATCH** /v3/devicelog/{device_log_id}/ | The APIs for creating and manipulating devices
[**DeviceLogRetrieve**](DefaultApi.md#devicelogretrieve) | **GET** /v3/devicelog/{device_log_id}/ | Retrieve device log
[**DeviceLogUpdate**](DefaultApi.md#devicelogupdate) | **PUT** /v3/devicelog/{device_log_id}/ | The APIs for creating and manipulating devices
[**DevicePartialUpdate**](DefaultApi.md#devicepartialupdate) | **PATCH** /v3/devices/{device_id}/ | Update device fields
[**DeviceRetrieve**](DefaultApi.md#deviceretrieve) | **GET** /v3/devices/{device_id}/ | Retrieve device
[**DeviceUpdate**](DefaultApi.md#deviceupdate) | **PUT** /v3/devices/{device_id}/ | Update device


<a name="devicecreate"></a>
# **DeviceCreate**
> DeviceSerializer DeviceCreate ()

Create device

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
                // Create device
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

Delete device

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
                // Delete device
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
> List<DeviceSerializer> DeviceList (string createdAt = null, string updatedAt = null, string autoUpdate = null, string bootstrappedTimestamp = null, string deployedState = null, string deployment = null, string description = null, string deviceClass = null, string deviceId = null, string etag = null, string manifest = null, string mechanism = null, string mechanismUrl = null, string name = null, string _object = null, string provisionKey = null, string serialNumber = null, string state = null, string trustClass = null, string trustLevel = null, string vendorId = null)

List all update devices

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
            var createdAt = createdAt_example;  // string |  (optional) 
            var updatedAt = updatedAt_example;  // string |  (optional) 
            var autoUpdate = autoUpdate_example;  // string |  (optional) 
            var bootstrappedTimestamp = bootstrappedTimestamp_example;  // string |  (optional) 
            var deployedState = deployedState_example;  // string |  (optional) 
            var deployment = deployment_example;  // string |  (optional) 
            var description = description_example;  // string |  (optional) 
            var deviceClass = deviceClass_example;  // string |  (optional) 
            var deviceId = deviceId_example;  // string |  (optional) 
            var etag = etag_example;  // string |  (optional) 
            var manifest = manifest_example;  // string |  (optional) 
            var mechanism = mechanism_example;  // string |  (optional) 
            var mechanismUrl = mechanismUrl_example;  // string |  (optional) 
            var name = name_example;  // string |  (optional) 
            var _object = _object_example;  // string |  (optional) 
            var provisionKey = provisionKey_example;  // string |  (optional) 
            var serialNumber = serialNumber_example;  // string |  (optional) 
            var state = state_example;  // string |  (optional) 
            var trustClass = trustClass_example;  // string |  (optional) 
            var trustLevel = trustLevel_example;  // string |  (optional) 
            var vendorId = vendorId_example;  // string |  (optional) 

            try
            {
                // List all update devices
                List&lt;DeviceSerializer&gt; result = apiInstance.DeviceList(createdAt, updatedAt, autoUpdate, bootstrappedTimestamp, deployedState, deployment, description, deviceClass, deviceId, etag, manifest, mechanism, mechanismUrl, name, _object, provisionKey, serialNumber, state, trustClass, trustLevel, vendorId);
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
 **createdAt** | **string**|  | [optional] 
 **updatedAt** | **string**|  | [optional] 
 **autoUpdate** | **string**|  | [optional] 
 **bootstrappedTimestamp** | **string**|  | [optional] 
 **deployedState** | **string**|  | [optional] 
 **deployment** | **string**|  | [optional] 
 **description** | **string**|  | [optional] 
 **deviceClass** | **string**|  | [optional] 
 **deviceId** | **string**|  | [optional] 
 **etag** | **string**|  | [optional] 
 **manifest** | **string**|  | [optional] 
 **mechanism** | **string**|  | [optional] 
 **mechanismUrl** | **string**|  | [optional] 
 **name** | **string**|  | [optional] 
 **_object** | **string**|  | [optional] 
 **provisionKey** | **string**|  | [optional] 
 **serialNumber** | **string**|  | [optional] 
 **state** | **string**|  | [optional] 
 **trustClass** | **string**|  | [optional] 
 **trustLevel** | **string**|  | [optional] 
 **vendorId** | **string**|  | [optional] 

### Return type

[**List<DeviceSerializer>**](DeviceSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicelogcreate"></a>
# **DeviceLogCreate**
> DeviceLogSerializer DeviceLogCreate (DateTime? dateTime, string deviceLogId = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId2 = null, string eventType2 = null, string stateChange2 = null)

The APIs for creating and manipulating devices

<p>The APIs for creating and manipulating devices.</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_catalog.Api;
using device_catalog.Client;
using device_catalog.Model;

namespace Example
{
    public class DeviceLogCreateExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var dateTime = 2013-10-20T19:20:30+01:00;  // DateTime? | 
            var deviceLogId = deviceLogId_example;  // string |  (optional) 
            var eventType = eventType_example;  // string |  (optional) 
            var stateChange = true;  // bool? |  (optional) 
            var dateTime2 = dateTime_example;  // string |  (optional) 
            var deviceId = deviceId_example;  // string |  (optional) 
            var deviceLogId2 = deviceLogId_example;  // string |  (optional) 
            var eventType2 = eventType_example;  // string |  (optional) 
            var stateChange2 = stateChange_example;  // string |  (optional) 

            try
            {
                // The APIs for creating and manipulating devices
                DeviceLogSerializer result = apiInstance.DeviceLogCreate(dateTime, deviceLogId, eventType, stateChange, dateTime2, deviceId, deviceLogId2, eventType2, stateChange2);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceLogCreate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **dateTime** | **DateTime?**|  | 
 **deviceLogId** | **string**|  | [optional] 
 **eventType** | **string**|  | [optional] 
 **stateChange** | **bool?**|  | [optional] 
 **dateTime2** | **string**|  | [optional] 
 **deviceId** | **string**|  | [optional] 
 **deviceLogId2** | **string**|  | [optional] 
 **eventType2** | **string**|  | [optional] 
 **stateChange2** | **string**|  | [optional] 

### Return type

[**DeviceLogSerializer**](DeviceLogSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicelogdestroy"></a>
# **DeviceLogDestroy**
> DeviceLogSerializer DeviceLogDestroy (string deviceLogId, string dateTime = null, string deviceId = null, string deviceLogId2 = null, string eventType = null, string stateChange = null)

The APIs for creating and manipulating devices

<p>The APIs for creating and manipulating devices.</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_catalog.Api;
using device_catalog.Client;
using device_catalog.Model;

namespace Example
{
    public class DeviceLogDestroyExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var deviceLogId = deviceLogId_example;  // string | 
            var dateTime = dateTime_example;  // string |  (optional) 
            var deviceId = deviceId_example;  // string |  (optional) 
            var deviceLogId2 = deviceLogId_example;  // string |  (optional) 
            var eventType = eventType_example;  // string |  (optional) 
            var stateChange = stateChange_example;  // string |  (optional) 

            try
            {
                // The APIs for creating and manipulating devices
                DeviceLogSerializer result = apiInstance.DeviceLogDestroy(deviceLogId, dateTime, deviceId, deviceLogId2, eventType, stateChange);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceLogDestroy: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceLogId** | **string**|  | 
 **dateTime** | **string**|  | [optional] 
 **deviceId** | **string**|  | [optional] 
 **deviceLogId2** | **string**|  | [optional] 
 **eventType** | **string**|  | [optional] 
 **stateChange** | **string**|  | [optional] 

### Return type

[**DeviceLogSerializer**](DeviceLogSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deviceloglist"></a>
# **DeviceLogList**
> List<DeviceLogSerializer> DeviceLogList (string dateTime = null, string deviceId = null, string deviceLogId = null, string eventType = null, string stateChange = null)

List all device logs

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
            var dateTime = dateTime_example;  // string |  (optional) 
            var deviceId = deviceId_example;  // string |  (optional) 
            var deviceLogId = deviceLogId_example;  // string |  (optional) 
            var eventType = eventType_example;  // string |  (optional) 
            var stateChange = stateChange_example;  // string |  (optional) 

            try
            {
                // List all device logs
                List&lt;DeviceLogSerializer&gt; result = apiInstance.DeviceLogList(dateTime, deviceId, deviceLogId, eventType, stateChange);
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
 **dateTime** | **string**|  | [optional] 
 **deviceId** | **string**|  | [optional] 
 **deviceLogId** | **string**|  | [optional] 
 **eventType** | **string**|  | [optional] 
 **stateChange** | **string**|  | [optional] 

### Return type

[**List<DeviceLogSerializer>**](DeviceLogSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicelogpartialupdate"></a>
# **DeviceLogPartialUpdate**
> DeviceLogSerializer DeviceLogPartialUpdate (string deviceLogId, DateTime? dateTime = null, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null)

The APIs for creating and manipulating devices

<p>The APIs for creating and manipulating devices.</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_catalog.Api;
using device_catalog.Client;
using device_catalog.Model;

namespace Example
{
    public class DeviceLogPartialUpdateExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var deviceLogId = deviceLogId_example;  // string | 
            var dateTime = 2013-10-20T19:20:30+01:00;  // DateTime? |  (optional) 
            var deviceLogId2 = deviceLogId_example;  // string |  (optional) 
            var eventType = eventType_example;  // string |  (optional) 
            var stateChange = true;  // bool? |  (optional) 
            var dateTime2 = dateTime_example;  // string |  (optional) 
            var deviceId = deviceId_example;  // string |  (optional) 
            var deviceLogId3 = deviceLogId_example;  // string |  (optional) 
            var eventType2 = eventType_example;  // string |  (optional) 
            var stateChange2 = stateChange_example;  // string |  (optional) 

            try
            {
                // The APIs for creating and manipulating devices
                DeviceLogSerializer result = apiInstance.DeviceLogPartialUpdate(deviceLogId, dateTime, deviceLogId2, eventType, stateChange, dateTime2, deviceId, deviceLogId3, eventType2, stateChange2);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceLogPartialUpdate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceLogId** | **string**|  | 
 **dateTime** | **DateTime?**|  | [optional] 
 **deviceLogId2** | **string**|  | [optional] 
 **eventType** | **string**|  | [optional] 
 **stateChange** | **bool?**|  | [optional] 
 **dateTime2** | **string**|  | [optional] 
 **deviceId** | **string**|  | [optional] 
 **deviceLogId3** | **string**|  | [optional] 
 **eventType2** | **string**|  | [optional] 
 **stateChange2** | **string**|  | [optional] 

### Return type

[**DeviceLogSerializer**](DeviceLogSerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicelogretrieve"></a>
# **DeviceLogRetrieve**
> DeviceLogSerializer DeviceLogRetrieve (string deviceLogId)

Retrieve device log

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
                // Retrieve device log
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

<a name="devicelogupdate"></a>
# **DeviceLogUpdate**
> DeviceLogSerializer DeviceLogUpdate (string deviceLogId, DateTime? dateTime, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null)

The APIs for creating and manipulating devices

<p>The APIs for creating and manipulating devices.</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_catalog.Api;
using device_catalog.Client;
using device_catalog.Model;

namespace Example
{
    public class DeviceLogUpdateExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var deviceLogId = deviceLogId_example;  // string | 
            var dateTime = 2013-10-20T19:20:30+01:00;  // DateTime? | 
            var deviceLogId2 = deviceLogId_example;  // string |  (optional) 
            var eventType = eventType_example;  // string |  (optional) 
            var stateChange = true;  // bool? |  (optional) 
            var dateTime2 = dateTime_example;  // string |  (optional) 
            var deviceId = deviceId_example;  // string |  (optional) 
            var deviceLogId3 = deviceLogId_example;  // string |  (optional) 
            var eventType2 = eventType_example;  // string |  (optional) 
            var stateChange2 = stateChange_example;  // string |  (optional) 

            try
            {
                // The APIs for creating and manipulating devices
                DeviceLogSerializer result = apiInstance.DeviceLogUpdate(deviceLogId, dateTime, deviceLogId2, eventType, stateChange, dateTime2, deviceId, deviceLogId3, eventType2, stateChange2);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceLogUpdate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceLogId** | **string**|  | 
 **dateTime** | **DateTime?**|  | 
 **deviceLogId2** | **string**|  | [optional] 
 **eventType** | **string**|  | [optional] 
 **stateChange** | **bool?**|  | [optional] 
 **dateTime2** | **string**|  | [optional] 
 **deviceId** | **string**|  | [optional] 
 **deviceLogId3** | **string**|  | [optional] 
 **eventType2** | **string**|  | [optional] 
 **stateChange2** | **string**|  | [optional] 

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

Update device fields

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
                // Update device fields
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

Retrieve device

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
                // Retrieve device
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

Update device

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
                // Update device
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

