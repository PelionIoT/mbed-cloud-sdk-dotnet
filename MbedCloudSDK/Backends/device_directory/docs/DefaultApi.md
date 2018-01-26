# device_directory.Api.DefaultApi

All URIs are relative to *https://api.us-east-1.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeviceCreate**](DefaultApi.md#devicecreate) | **POST** /v3/devices/ | 
[**DeviceDestroy**](DefaultApi.md#devicedestroy) | **DELETE** /v3/devices/{id}/ | 
[**DeviceEventList**](DefaultApi.md#deviceeventlist) | **GET** /v3/device-events/ | 
[**DeviceEventRetrieve**](DefaultApi.md#deviceeventretrieve) | **GET** /v3/device-events/{device_event_id}/ | 
[**DeviceList**](DefaultApi.md#devicelist) | **GET** /v3/devices/ | 
[**DeviceLogList**](DefaultApi.md#deviceloglist) | **GET** /v3/devicelog/ | 
[**DeviceLogRetrieve**](DefaultApi.md#devicelogretrieve) | **GET** /v3/devicelog/{device_event_id}/ | 
[**DevicePartialUpdate**](DefaultApi.md#devicepartialupdate) | **PATCH** /v3/devices/{id}/ | 
[**DeviceQueryCreate**](DefaultApi.md#devicequerycreate) | **POST** /v3/device-queries/ | 
[**DeviceQueryDestroy**](DefaultApi.md#devicequerydestroy) | **DELETE** /v3/device-queries/{query_id}/ | 
[**DeviceQueryList**](DefaultApi.md#devicequerylist) | **GET** /v3/device-queries/ | 
[**DeviceQueryPartialUpdate**](DefaultApi.md#devicequerypartialupdate) | **PATCH** /v3/device-queries/{query_id}/ | 
[**DeviceQueryRetrieve**](DefaultApi.md#devicequeryretrieve) | **GET** /v3/device-queries/{query_id}/ | 
[**DeviceQueryUpdate**](DefaultApi.md#devicequeryupdate) | **PUT** /v3/device-queries/{query_id}/ | 
[**DeviceRetrieve**](DefaultApi.md#deviceretrieve) | **GET** /v3/devices/{id}/ | 
[**DeviceUpdate**](DefaultApi.md#deviceupdate) | **PUT** /v3/devices/{id}/ | 


<a name="devicecreate"></a>
# **DeviceCreate**
> DeviceData DeviceCreate (DeviceDataPostRequest device)



Create device.

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

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
            var device = new DeviceDataPostRequest(); // DeviceDataPostRequest | 

            try
            {
                DeviceData result = apiInstance.DeviceCreate(device);
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

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **device** | [**DeviceDataPostRequest**](DeviceDataPostRequest.md)|  | 

### Return type

[**DeviceData**](DeviceData.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicedestroy"></a>
# **DeviceDestroy**
> void DeviceDestroy (string id)



Delete device. Only available for devices with a developer certificate. Attempts to delete a device with a production certicate will return a 400 response.

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

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
            var id = id_example;  // string | 

            try
            {
                apiInstance.DeviceDestroy(id);
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
 **id** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deviceeventlist"></a>
# **DeviceEventList**
> DeviceEventPage DeviceEventList (int? limit = null, string order = null, string after = null, string filter = null, string include = null)



List all device events.

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

namespace Example
{
    public class DeviceEventListExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var limit = 56;  // int? | How many objects to retrieve in the page. (optional) 
            var order = order_example;  // string | The order of the records based on creation time, `ASC` or `DESC`; by default `ASC`. (optional) 
            var after = after_example;  // string | The ID of The item after which to retrieve the next page. (optional) 
            var filter = filter_example;  // string | URL encoded query string parameter to filter returned data.  ##### Filtering ```?filter={URL encoded query string}```  The query string is made up of key/value pairs separated by ampersands. So for a query of ```key1=value1&key2=value2&key3=value3``` this would be encoded as follows: ```?filter=key1%3Dvalue1%26key2%3Dvalue2%26key3%3Dvalue3``` The examples below show the queries in *unencoded* form.  ###### By id: ```id={id}```  ###### By state change: ```state_change=[True|False]```  ###### By event type: ```event_type={value}```  ###### On date-time fields: Date-time fields should be specified in UTC RFC3339 format ```YYYY-MM-DDThh:mm:ss.msZ```. There are three permitted variations:  * UTC RFC3339 with milliseconds e.g. 2016-11-30T16:25:12.1234Z * UTC RFC3339 without milliseconds e.g. 2016-11-30T16:25:12Z * UTC RFC3339 shortened - without milliseconds and punctuation e.g. 20161130T162512Z  Date-time filtering supports three operators:  * equality * greater than or equal to &ndash; field name suffixed with ```__gte``` * less than or equal to &ndash; field name suffixed with ```__lte```  Lower and upper limits to a date-time range may be specified by including both the ```__gte``` and ```__lte``` forms in the filter.  ```{field name}[|__lte|__gte]={UTC RFC3339 date-time}```  ##### Multi-field example  ```id=0158d38771f70000000000010010038c&state_change=True&date_time__gte=2016-11-30T16:25:12.1234Z```  Encoded:  ```?filter=id%3D0158d38771f70000000000010010038c%26state_change%3DTrue%26date_time__gte%3D2016-11-30T16%3A25%3A12.1234Z``` (optional) 
            var include = include_example;  // string | Comma-separated list of data fields to return. Currently supported: `total_count` (optional) 

            try
            {
                DeviceEventPage result = apiInstance.DeviceEventList(limit, order, after, filter, include);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceEventList: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **limit** | **int?**| How many objects to retrieve in the page. | [optional] 
 **order** | **string**| The order of the records based on creation time, &#x60;ASC&#x60; or &#x60;DESC&#x60;; by default &#x60;ASC&#x60;. | [optional] 
 **after** | **string**| The ID of The item after which to retrieve the next page. | [optional] 
 **filter** | **string**| URL encoded query string parameter to filter returned data.  ##### Filtering &#x60;&#x60;&#x60;?filter&#x3D;{URL encoded query string}&#x60;&#x60;&#x60;  The query string is made up of key/value pairs separated by ampersands. So for a query of &#x60;&#x60;&#x60;key1&#x3D;value1&amp;key2&#x3D;value2&amp;key3&#x3D;value3&#x60;&#x60;&#x60; this would be encoded as follows: &#x60;&#x60;&#x60;?filter&#x3D;key1%3Dvalue1%26key2%3Dvalue2%26key3%3Dvalue3&#x60;&#x60;&#x60; The examples below show the queries in *unencoded* form.  ###### By id: &#x60;&#x60;&#x60;id&#x3D;{id}&#x60;&#x60;&#x60;  ###### By state change: &#x60;&#x60;&#x60;state_change&#x3D;[True|False]&#x60;&#x60;&#x60;  ###### By event type: &#x60;&#x60;&#x60;event_type&#x3D;{value}&#x60;&#x60;&#x60;  ###### On date-time fields: Date-time fields should be specified in UTC RFC3339 format &#x60;&#x60;&#x60;YYYY-MM-DDThh:mm:ss.msZ&#x60;&#x60;&#x60;. There are three permitted variations:  * UTC RFC3339 with milliseconds e.g. 2016-11-30T16:25:12.1234Z * UTC RFC3339 without milliseconds e.g. 2016-11-30T16:25:12Z * UTC RFC3339 shortened - without milliseconds and punctuation e.g. 20161130T162512Z  Date-time filtering supports three operators:  * equality * greater than or equal to &amp;ndash; field name suffixed with &#x60;&#x60;&#x60;__gte&#x60;&#x60;&#x60; * less than or equal to &amp;ndash; field name suffixed with &#x60;&#x60;&#x60;__lte&#x60;&#x60;&#x60;  Lower and upper limits to a date-time range may be specified by including both the &#x60;&#x60;&#x60;__gte&#x60;&#x60;&#x60; and &#x60;&#x60;&#x60;__lte&#x60;&#x60;&#x60; forms in the filter.  &#x60;&#x60;&#x60;{field name}[|__lte|__gte]&#x3D;{UTC RFC3339 date-time}&#x60;&#x60;&#x60;  ##### Multi-field example  &#x60;&#x60;&#x60;id&#x3D;0158d38771f70000000000010010038c&amp;state_change&#x3D;True&amp;date_time__gte&#x3D;2016-11-30T16:25:12.1234Z&#x60;&#x60;&#x60;  Encoded:  &#x60;&#x60;&#x60;?filter&#x3D;id%3D0158d38771f70000000000010010038c%26state_change%3DTrue%26date_time__gte%3D2016-11-30T16%3A25%3A12.1234Z&#x60;&#x60;&#x60; | [optional] 
 **include** | **string**| Comma-separated list of data fields to return. Currently supported: &#x60;total_count&#x60; | [optional] 

### Return type

[**DeviceEventPage**](DeviceEventPage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deviceeventretrieve"></a>
# **DeviceEventRetrieve**
> DeviceEventData DeviceEventRetrieve (string deviceEventId)



Retrieve device event.

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

namespace Example
{
    public class DeviceEventRetrieveExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var deviceEventId = deviceEventId_example;  // string | 

            try
            {
                DeviceEventData result = apiInstance.DeviceEventRetrieve(deviceEventId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceEventRetrieve: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceEventId** | **string**|  | 

### Return type

[**DeviceEventData**](DeviceEventData.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicelist"></a>
# **DeviceList**
> DevicePage DeviceList (int? limit = null, string order = null, string after = null, string filter = null, string include = null)



List all devices.

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

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
            var limit = 56;  // int? | How many objects to retrieve in the page. (optional) 
            var order = order_example;  // string | The order of the records based on creation time, `ASC` or `DESC`; by default `ASC`. (optional) 
            var after = after_example;  // string | The ID of The item after which to retrieve the next page. (optional) 
            var filter = filter_example;  // string | URL encoded query string parameter to filter returned data.  ##### Filtering ```?filter={URL encoded query string}```  The query string is made up of key/value pairs separated by ampersands. So for a query of ```key1=value1&key2=value2&key3=value3``` this would be encoded as follows: ```?filter=key1%3Dvalue1%26key2%3Dvalue2%26key3%3Dvalue3``` The examples below show the queries in *unencoded* form.  ###### By device properties (all properties are filterable): ```state=[unenrolled|cloud_enrolling|bootstrapped|registered]```  ```device_class={value}```  ###### On date-time fields: Date-time fields should be specified in UTC RFC3339 format ```YYYY-MM-DDThh:mm:ss.msZ```. There are three permitted variations:  * UTC RFC3339 with milliseconds e.g. 2016-11-30T16:25:12.1234Z * UTC RFC3339 without milliseconds e.g. 2016-11-30T16:25:12Z * UTC RFC3339 shortened - without milliseconds and punctuation e.g. 20161130T162512Z  Date-time filtering supports three operators:  * equality * greater than or equal to &ndash; field name suffixed with ```__gte``` * less than or equal to &ndash; field name suffixed with ```__lte```  Lower and upper limits to a date-time range may be specified by including both the ```__gte``` and ```__lte``` forms in the filter.  ```{field name}[|__lte|__gte]={UTC RFC3339 date-time}```  ###### On device custom attributes:  ```custom_attributes__{param}={value}``` ```custom_attributes__tag=TAG1```  ##### Multi-field example  ```state=bootstrapped&created_at__gte=2016-11-30T16:25:12.1234Z&created_at__lte=2016-12-30T00:00:00Z```  Encoded:  ```?filter=state%3Dbootstrapped%26created_at__gte%3D2016-11-30T16%3A25%3A12.1234Z%26created_at__lte%3D2016-11-30T00%3A00%3A00Z``` (optional) 
            var include = include_example;  // string | Comma-separated list of data fields to return. Currently supported: `total_count`. (optional) 

            try
            {
                DevicePage result = apiInstance.DeviceList(limit, order, after, filter, include);
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
 **limit** | **int?**| How many objects to retrieve in the page. | [optional] 
 **order** | **string**| The order of the records based on creation time, &#x60;ASC&#x60; or &#x60;DESC&#x60;; by default &#x60;ASC&#x60;. | [optional] 
 **after** | **string**| The ID of The item after which to retrieve the next page. | [optional] 
 **filter** | **string**| URL encoded query string parameter to filter returned data.  ##### Filtering &#x60;&#x60;&#x60;?filter&#x3D;{URL encoded query string}&#x60;&#x60;&#x60;  The query string is made up of key/value pairs separated by ampersands. So for a query of &#x60;&#x60;&#x60;key1&#x3D;value1&amp;key2&#x3D;value2&amp;key3&#x3D;value3&#x60;&#x60;&#x60; this would be encoded as follows: &#x60;&#x60;&#x60;?filter&#x3D;key1%3Dvalue1%26key2%3Dvalue2%26key3%3Dvalue3&#x60;&#x60;&#x60; The examples below show the queries in *unencoded* form.  ###### By device properties (all properties are filterable): &#x60;&#x60;&#x60;state&#x3D;[unenrolled|cloud_enrolling|bootstrapped|registered]&#x60;&#x60;&#x60;  &#x60;&#x60;&#x60;device_class&#x3D;{value}&#x60;&#x60;&#x60;  ###### On date-time fields: Date-time fields should be specified in UTC RFC3339 format &#x60;&#x60;&#x60;YYYY-MM-DDThh:mm:ss.msZ&#x60;&#x60;&#x60;. There are three permitted variations:  * UTC RFC3339 with milliseconds e.g. 2016-11-30T16:25:12.1234Z * UTC RFC3339 without milliseconds e.g. 2016-11-30T16:25:12Z * UTC RFC3339 shortened - without milliseconds and punctuation e.g. 20161130T162512Z  Date-time filtering supports three operators:  * equality * greater than or equal to &amp;ndash; field name suffixed with &#x60;&#x60;&#x60;__gte&#x60;&#x60;&#x60; * less than or equal to &amp;ndash; field name suffixed with &#x60;&#x60;&#x60;__lte&#x60;&#x60;&#x60;  Lower and upper limits to a date-time range may be specified by including both the &#x60;&#x60;&#x60;__gte&#x60;&#x60;&#x60; and &#x60;&#x60;&#x60;__lte&#x60;&#x60;&#x60; forms in the filter.  &#x60;&#x60;&#x60;{field name}[|__lte|__gte]&#x3D;{UTC RFC3339 date-time}&#x60;&#x60;&#x60;  ###### On device custom attributes:  &#x60;&#x60;&#x60;custom_attributes__{param}&#x3D;{value}&#x60;&#x60;&#x60; &#x60;&#x60;&#x60;custom_attributes__tag&#x3D;TAG1&#x60;&#x60;&#x60;  ##### Multi-field example  &#x60;&#x60;&#x60;state&#x3D;bootstrapped&amp;created_at__gte&#x3D;2016-11-30T16:25:12.1234Z&amp;created_at__lte&#x3D;2016-12-30T00:00:00Z&#x60;&#x60;&#x60;  Encoded:  &#x60;&#x60;&#x60;?filter&#x3D;state%3Dbootstrapped%26created_at__gte%3D2016-11-30T16%3A25%3A12.1234Z%26created_at__lte%3D2016-11-30T00%3A00%3A00Z&#x60;&#x60;&#x60; | [optional] 
 **include** | **string**| Comma-separated list of data fields to return. Currently supported: &#x60;total_count&#x60;. | [optional] 

### Return type

[**DevicePage**](DevicePage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deviceloglist"></a>
# **DeviceLogList**
> DeviceEventPage DeviceLogList (int? limit = null, string order = null, string after = null, string filter = null, string include = null)



DEPRECATED: List all device events. Use `/v3/device-events/` instead.

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

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
            var limit = 56;  // int? | How many objects to retrieve in the page. (optional) 
            var order = order_example;  // string | The order of the records based on creation time, `ASC` or `DESC`; by default `ASC`. (optional) 
            var after = after_example;  // string | The ID of The item after which to retrieve the next page. (optional) 
            var filter = filter_example;  // string | URL encoded query string parameter to filter returned data.  ##### Filtering ```?filter={URL encoded query string}```  The query string is made up of key/value pairs separated by ampersands. So for a query of ```key1=value1&key2=value2&key3=value3``` this would be encoded as follows: ```?filter=key1%3Dvalue1%26key2%3Dvalue2%26key3%3Dvalue3``` The examples below show the queries in *unencoded* form.  ###### By id: ```id={id}```  ###### By state change: ```state_change=[True|False]```  ###### By event type: ```event_type={value}```  ###### On date-time fields: Date-time fields should be specified in UTC RFC3339 format ```YYYY-MM-DDThh:mm:ss.msZ```. There are three permitted variations:  * UTC RFC3339 with milliseconds e.g. 2016-11-30T16:25:12.1234Z * UTC RFC3339 without milliseconds e.g. 2016-11-30T16:25:12Z * UTC RFC3339 shortened - without milliseconds and punctuation e.g. 20161130T162512Z  Date-time filtering supports three operators:  * equality * greater than or equal to &ndash; field name suffixed with ```__gte``` * less than or equal to &ndash; field name suffixed with ```__lte```  Lower and upper limits to a date-time range may be specified by including both the ```__gte``` and ```__lte``` forms in the filter.  ```{field name}[|__lte|__gte]={UTC RFC3339 date-time}```  ##### Multi-field example  ```id=0158d38771f70000000000010010038c&state_change=True&date_time__gte=2016-11-30T16:25:12.1234Z```  Encoded:  ```?filter=id%3D0158d38771f70000000000010010038c%26state_change%3DTrue%26date_time__gte%3D2016-11-30T16%3A25%3A12.1234Z``` (optional) 
            var include = include_example;  // string | Comma-separated list of data fields to return. Currently supported: `total_count`. (optional) 

            try
            {
                DeviceEventPage result = apiInstance.DeviceLogList(limit, order, after, filter, include);
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
 **limit** | **int?**| How many objects to retrieve in the page. | [optional] 
 **order** | **string**| The order of the records based on creation time, &#x60;ASC&#x60; or &#x60;DESC&#x60;; by default &#x60;ASC&#x60;. | [optional] 
 **after** | **string**| The ID of The item after which to retrieve the next page. | [optional] 
 **filter** | **string**| URL encoded query string parameter to filter returned data.  ##### Filtering &#x60;&#x60;&#x60;?filter&#x3D;{URL encoded query string}&#x60;&#x60;&#x60;  The query string is made up of key/value pairs separated by ampersands. So for a query of &#x60;&#x60;&#x60;key1&#x3D;value1&amp;key2&#x3D;value2&amp;key3&#x3D;value3&#x60;&#x60;&#x60; this would be encoded as follows: &#x60;&#x60;&#x60;?filter&#x3D;key1%3Dvalue1%26key2%3Dvalue2%26key3%3Dvalue3&#x60;&#x60;&#x60; The examples below show the queries in *unencoded* form.  ###### By id: &#x60;&#x60;&#x60;id&#x3D;{id}&#x60;&#x60;&#x60;  ###### By state change: &#x60;&#x60;&#x60;state_change&#x3D;[True|False]&#x60;&#x60;&#x60;  ###### By event type: &#x60;&#x60;&#x60;event_type&#x3D;{value}&#x60;&#x60;&#x60;  ###### On date-time fields: Date-time fields should be specified in UTC RFC3339 format &#x60;&#x60;&#x60;YYYY-MM-DDThh:mm:ss.msZ&#x60;&#x60;&#x60;. There are three permitted variations:  * UTC RFC3339 with milliseconds e.g. 2016-11-30T16:25:12.1234Z * UTC RFC3339 without milliseconds e.g. 2016-11-30T16:25:12Z * UTC RFC3339 shortened - without milliseconds and punctuation e.g. 20161130T162512Z  Date-time filtering supports three operators:  * equality * greater than or equal to &amp;ndash; field name suffixed with &#x60;&#x60;&#x60;__gte&#x60;&#x60;&#x60; * less than or equal to &amp;ndash; field name suffixed with &#x60;&#x60;&#x60;__lte&#x60;&#x60;&#x60;  Lower and upper limits to a date-time range may be specified by including both the &#x60;&#x60;&#x60;__gte&#x60;&#x60;&#x60; and &#x60;&#x60;&#x60;__lte&#x60;&#x60;&#x60; forms in the filter.  &#x60;&#x60;&#x60;{field name}[|__lte|__gte]&#x3D;{UTC RFC3339 date-time}&#x60;&#x60;&#x60;  ##### Multi-field example  &#x60;&#x60;&#x60;id&#x3D;0158d38771f70000000000010010038c&amp;state_change&#x3D;True&amp;date_time__gte&#x3D;2016-11-30T16:25:12.1234Z&#x60;&#x60;&#x60;  Encoded:  &#x60;&#x60;&#x60;?filter&#x3D;id%3D0158d38771f70000000000010010038c%26state_change%3DTrue%26date_time__gte%3D2016-11-30T16%3A25%3A12.1234Z&#x60;&#x60;&#x60; | [optional] 
 **include** | **string**| Comma-separated list of data fields to return. Currently supported: &#x60;total_count&#x60;. | [optional] 

### Return type

[**DeviceEventPage**](DeviceEventPage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicelogretrieve"></a>
# **DeviceLogRetrieve**
> DeviceEventData DeviceLogRetrieve (string deviceEventId)



Retrieve device event (deprecated, use /v3/device-events/{device_event_id}/ instead)

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

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
            var deviceEventId = deviceEventId_example;  // string | 

            try
            {
                DeviceEventData result = apiInstance.DeviceLogRetrieve(deviceEventId);
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
 **deviceEventId** | **string**|  | 

### Return type

[**DeviceEventData**](DeviceEventData.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicepartialupdate"></a>
# **DevicePartialUpdate**
> DeviceData DevicePartialUpdate (string id, DeviceDataPatchRequest device)



Update device fields.

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

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
            var id = id_example;  // string | The ID of the device.
            var device = new DeviceDataPatchRequest(); // DeviceDataPatchRequest | 

            try
            {
                DeviceData result = apiInstance.DevicePartialUpdate(id, device);
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
 **id** | **string**| The ID of the device. | 
 **device** | [**DeviceDataPatchRequest**](DeviceDataPatchRequest.md)|  | 

### Return type

[**DeviceData**](DeviceData.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicequerycreate"></a>
# **DeviceQueryCreate**
> DeviceQuery DeviceQueryCreate (DeviceQueryPostPutRequest device)



Create device query.

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

namespace Example
{
    public class DeviceQueryCreateExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var device = new DeviceQueryPostPutRequest(); // DeviceQueryPostPutRequest | 

            try
            {
                DeviceQuery result = apiInstance.DeviceQueryCreate(device);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceQueryCreate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **device** | [**DeviceQueryPostPutRequest**](DeviceQueryPostPutRequest.md)|  | 

### Return type

[**DeviceQuery**](DeviceQuery.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicequerydestroy"></a>
# **DeviceQueryDestroy**
> void DeviceQueryDestroy (string queryId)



Delete device query.

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

namespace Example
{
    public class DeviceQueryDestroyExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var queryId = queryId_example;  // string | 

            try
            {
                apiInstance.DeviceQueryDestroy(queryId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceQueryDestroy: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **queryId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicequerylist"></a>
# **DeviceQueryList**
> DeviceQueryPage DeviceQueryList (int? limit = null, string order = null, string after = null, string filter = null, string include = null)



List all device queries. The result will be paged into pages of 100.

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

namespace Example
{
    public class DeviceQueryListExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var limit = 56;  // int? | How many objects to retrieve in the page. (optional) 
            var order = order_example;  // string | The order of the records based on creation time, `ASC` or `DESC`; by default `ASC`. (optional) 
            var after = after_example;  // string | The ID of The item after which to retrieve the next page. (optional) 
            var filter = filter_example;  // string | URL encoded query string parameter to filter returned data.  ##### Filtering ```?filter={URL encoded query string}```  The query string is made up of key/value pairs separated by ampersands. So for a query of ```key1=value1&key2=value2&key3=value3``` this would be encoded as follows: ```?filter=key1%3Dvalue1%26key2%3Dvalue2%26key3%3Dvalue3``` The examples below show the queries in *unencoded* form.  ###### By device query properties (all properties are filterable): For example: ```description={value}```  ###### On date-time fields: Date-time fields should be specified in UTC RFC3339 format ```YYYY-MM-DDThh:mm:ss.msZ```. There are three permitted variations:  * UTC RFC3339 with milliseconds e.g. 2016-11-30T16:25:12.1234Z * UTC RFC3339 without milliseconds e.g. 2016-11-30T16:25:12Z * UTC RFC3339 shortened - without milliseconds and punctuation e.g. 20161130T162512Z  Date-time filtering supports three operators:  * equality * greater than or equal to &ndash; field name suffixed with ```__gte``` * less than or equal to &ndash; field name suffixed with ```__lte```  Lower and upper limits to a date-time range may be specified by including both the ```__gte``` and ```__lte``` forms in the filter.  ```{field name}[|__lte|__gte]={UTC RFC3339 date-time}```  ##### Multi-field example  ```query_id=0158d38771f70000000000010010038c&created_at__gte=2016-11-30T16:25:12.1234Z&created_at__lte=2016-12-30T00:00:00Z```  Encoded:  ```filter=query_id%3D0158d38771f70000000000010010038c%26created_at__gte%3D2016-11-30T16%3A25%3A12.1234Z%26created_at__lte%3D2016-11-30T00%3A00%3A00Z``` (optional) 
            var include = include_example;  // string | Comma-separated list of data fields to return. Currently supported: `total_count`. (optional) 

            try
            {
                DeviceQueryPage result = apiInstance.DeviceQueryList(limit, order, after, filter, include);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceQueryList: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **limit** | **int?**| How many objects to retrieve in the page. | [optional] 
 **order** | **string**| The order of the records based on creation time, &#x60;ASC&#x60; or &#x60;DESC&#x60;; by default &#x60;ASC&#x60;. | [optional] 
 **after** | **string**| The ID of The item after which to retrieve the next page. | [optional] 
 **filter** | **string**| URL encoded query string parameter to filter returned data.  ##### Filtering &#x60;&#x60;&#x60;?filter&#x3D;{URL encoded query string}&#x60;&#x60;&#x60;  The query string is made up of key/value pairs separated by ampersands. So for a query of &#x60;&#x60;&#x60;key1&#x3D;value1&amp;key2&#x3D;value2&amp;key3&#x3D;value3&#x60;&#x60;&#x60; this would be encoded as follows: &#x60;&#x60;&#x60;?filter&#x3D;key1%3Dvalue1%26key2%3Dvalue2%26key3%3Dvalue3&#x60;&#x60;&#x60; The examples below show the queries in *unencoded* form.  ###### By device query properties (all properties are filterable): For example: &#x60;&#x60;&#x60;description&#x3D;{value}&#x60;&#x60;&#x60;  ###### On date-time fields: Date-time fields should be specified in UTC RFC3339 format &#x60;&#x60;&#x60;YYYY-MM-DDThh:mm:ss.msZ&#x60;&#x60;&#x60;. There are three permitted variations:  * UTC RFC3339 with milliseconds e.g. 2016-11-30T16:25:12.1234Z * UTC RFC3339 without milliseconds e.g. 2016-11-30T16:25:12Z * UTC RFC3339 shortened - without milliseconds and punctuation e.g. 20161130T162512Z  Date-time filtering supports three operators:  * equality * greater than or equal to &amp;ndash; field name suffixed with &#x60;&#x60;&#x60;__gte&#x60;&#x60;&#x60; * less than or equal to &amp;ndash; field name suffixed with &#x60;&#x60;&#x60;__lte&#x60;&#x60;&#x60;  Lower and upper limits to a date-time range may be specified by including both the &#x60;&#x60;&#x60;__gte&#x60;&#x60;&#x60; and &#x60;&#x60;&#x60;__lte&#x60;&#x60;&#x60; forms in the filter.  &#x60;&#x60;&#x60;{field name}[|__lte|__gte]&#x3D;{UTC RFC3339 date-time}&#x60;&#x60;&#x60;  ##### Multi-field example  &#x60;&#x60;&#x60;query_id&#x3D;0158d38771f70000000000010010038c&amp;created_at__gte&#x3D;2016-11-30T16:25:12.1234Z&amp;created_at__lte&#x3D;2016-12-30T00:00:00Z&#x60;&#x60;&#x60;  Encoded:  &#x60;&#x60;&#x60;filter&#x3D;query_id%3D0158d38771f70000000000010010038c%26created_at__gte%3D2016-11-30T16%3A25%3A12.1234Z%26created_at__lte%3D2016-11-30T00%3A00%3A00Z&#x60;&#x60;&#x60; | [optional] 
 **include** | **string**| Comma-separated list of data fields to return. Currently supported: &#x60;total_count&#x60;. | [optional] 

### Return type

[**DeviceQueryPage**](DeviceQueryPage.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicequerypartialupdate"></a>
# **DeviceQueryPartialUpdate**
> DeviceQuery DeviceQueryPartialUpdate (string queryId, DeviceQueryPatchRequest deviceQuery)



Update device query fields.

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

namespace Example
{
    public class DeviceQueryPartialUpdateExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var queryId = queryId_example;  // string | 
            var deviceQuery = new DeviceQueryPatchRequest(); // DeviceQueryPatchRequest | 

            try
            {
                DeviceQuery result = apiInstance.DeviceQueryPartialUpdate(queryId, deviceQuery);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceQueryPartialUpdate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **queryId** | **string**|  | 
 **deviceQuery** | [**DeviceQueryPatchRequest**](DeviceQueryPatchRequest.md)|  | 

### Return type

[**DeviceQuery**](DeviceQuery.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicequeryretrieve"></a>
# **DeviceQueryRetrieve**
> DeviceQuery DeviceQueryRetrieve (string queryId)



Retrieve device query.

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

namespace Example
{
    public class DeviceQueryRetrieveExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var queryId = queryId_example;  // string | 

            try
            {
                DeviceQuery result = apiInstance.DeviceQueryRetrieve(queryId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceQueryRetrieve: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **queryId** | **string**|  | 

### Return type

[**DeviceQuery**](DeviceQuery.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicequeryupdate"></a>
# **DeviceQueryUpdate**
> DeviceQuery DeviceQueryUpdate (string queryId, DeviceQueryPostPutRequest body)



Update device query.

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

namespace Example
{
    public class DeviceQueryUpdateExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var queryId = queryId_example;  // string | 
            var body = new DeviceQueryPostPutRequest(); // DeviceQueryPostPutRequest | Device query update object.

            try
            {
                DeviceQuery result = apiInstance.DeviceQueryUpdate(queryId, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.DeviceQueryUpdate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **queryId** | **string**|  | 
 **body** | [**DeviceQueryPostPutRequest**](DeviceQueryPostPutRequest.md)| Device query update object. | 

### Return type

[**DeviceQuery**](DeviceQuery.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deviceretrieve"></a>
# **DeviceRetrieve**
> DeviceData DeviceRetrieve (string id)



Retrieve device.

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

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
            var id = id_example;  // string | 

            try
            {
                DeviceData result = apiInstance.DeviceRetrieve(id);
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
 **id** | **string**|  | 

### Return type

[**DeviceData**](DeviceData.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deviceupdate"></a>
# **DeviceUpdate**
> DeviceData DeviceUpdate (string id, DeviceDataPutRequest device)



Update device.

### Example
```csharp
using System;
using System.Diagnostics;
using device_directory.Api;
using device_directory.Client;
using device_directory.Model;

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
            var id = id_example;  // string | The ID of the device.
            var device = new DeviceDataPutRequest(); // DeviceDataPutRequest | 

            try
            {
                DeviceData result = apiInstance.DeviceUpdate(id, device);
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
 **id** | **string**| The ID of the device. | 
 **device** | [**DeviceDataPutRequest**](DeviceDataPutRequest.md)|  | 

### Return type

[**DeviceData**](DeviceData.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

