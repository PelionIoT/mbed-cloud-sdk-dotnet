# device_query_service.Api.DefaultApi

All URIs are relative to *http://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**DeviceQueryCreate**](DefaultApi.md#devicequerycreate) | **POST** /v3/device-queries/ | 
[**DeviceQueryDestroy**](DefaultApi.md#devicequerydestroy) | **DELETE** /v3/device-queries/{query_id}/ | 
[**DeviceQueryList**](DefaultApi.md#devicequerylist) | **GET** /v3/device-queries/ | 
[**DeviceQueryPartialUpdate**](DefaultApi.md#devicequerypartialupdate) | **PATCH** /v3/device-queries/{query_id}/ | 
[**DeviceQueryRetrieve**](DefaultApi.md#devicequeryretrieve) | **GET** /v3/device-queries/{query_id}/ | 
[**DeviceQueryUpdate**](DefaultApi.md#devicequeryupdate) | **PUT** /v3/device-queries/{query_id}/ | 


<a name="devicequerycreate"></a>
# **DeviceQueryCreate**
> DeviceQuerySerializer DeviceQueryCreate (string name, string query, string description = null, string _object = null, string queryId = null)



<p>The APIs for creating and manipulating device queries.  </p> <p>Create device query</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_query_service.Api;
using device_query_service.Client;
using device_query_service.Model;

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
            var name = name_example;  // string | The name of the query
            var query = query_example;  // string | The device query
            var description = description_example;  // string | The description of the object (optional) 
            var _object = _object_example;  // string | The API resource entity (optional) 
            var queryId = queryId_example;  // string | DEPRECATED: The ID of the query (optional) 

            try
            {
                DeviceQuerySerializer result = apiInstance.DeviceQueryCreate(name, query, description, _object, queryId);
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
 **name** | **string**| The name of the query | 
 **query** | **string**| The device query | 
 **description** | **string**| The description of the object | [optional] 
 **_object** | **string**| The API resource entity | [optional] 
 **queryId** | **string**| DEPRECATED: The ID of the query | [optional] 

### Return type

[**DeviceQuerySerializer**](DeviceQuerySerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicequerydestroy"></a>
# **DeviceQueryDestroy**
> DeviceQuerySerializer DeviceQueryDestroy (string queryId)



<p>The APIs for creating and manipulating device queries.  </p> <p>Delete device query</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_query_service.Api;
using device_query_service.Client;
using device_query_service.Model;

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
                DeviceQuerySerializer result = apiInstance.DeviceQueryDestroy(queryId);
                Debug.WriteLine(result);
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

[**DeviceQuerySerializer**](DeviceQuerySerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicequerylist"></a>
# **DeviceQueryList**
> List<DeviceQuerySerializer> DeviceQueryList (string description = null, string createdAt = null, string updatedAt = null, string etag = null, string name = null, string _object = null, string query = null, string queryId = null)



<p>The APIs for creating and manipulating device queries.  </p> <p>List all device queries. The result will be paged into pages of 100.</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_query_service.Api;
using device_query_service.Client;
using device_query_service.Model;

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
            var description = description_example;  // string |  (optional) 
            var createdAt = createdAt_example;  // string |  (optional) 
            var updatedAt = updatedAt_example;  // string |  (optional) 
            var etag = etag_example;  // string |  (optional) 
            var name = name_example;  // string |  (optional) 
            var _object = _object_example;  // string |  (optional) 
            var query = query_example;  // string |  (optional) 
            var queryId = queryId_example;  // string |  (optional) 

            try
            {
                List&lt;DeviceQuerySerializer&gt; result = apiInstance.DeviceQueryList(description, createdAt, updatedAt, etag, name, _object, query, queryId);
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
 **description** | **string**|  | [optional] 
 **createdAt** | **string**|  | [optional] 
 **updatedAt** | **string**|  | [optional] 
 **etag** | **string**|  | [optional] 
 **name** | **string**|  | [optional] 
 **_object** | **string**|  | [optional] 
 **query** | **string**|  | [optional] 
 **queryId** | **string**|  | [optional] 

### Return type

[**List<DeviceQuerySerializer>**](DeviceQuerySerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicequerypartialupdate"></a>
# **DeviceQueryPartialUpdate**
> DeviceQuerySerializer DeviceQueryPartialUpdate (string queryId, string description = null, string name = null, string _object = null, string query = null, string queryId2 = null)



<p>The APIs for creating and manipulating device queries.  </p> <p>Update device query fields</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_query_service.Api;
using device_query_service.Client;
using device_query_service.Model;

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
            var description = description_example;  // string | The description of the object (optional) 
            var name = name_example;  // string | The name of the query (optional) 
            var _object = _object_example;  // string | The API resource entity (optional) 
            var query = query_example;  // string | The device query (optional) 
            var queryId2 = queryId_example;  // string | DEPRECATED: The ID of the query (optional) 

            try
            {
                DeviceQuerySerializer result = apiInstance.DeviceQueryPartialUpdate(queryId, description, name, _object, query, queryId2);
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
 **description** | **string**| The description of the object | [optional] 
 **name** | **string**| The name of the query | [optional] 
 **_object** | **string**| The API resource entity | [optional] 
 **query** | **string**| The device query | [optional] 
 **queryId2** | **string**| DEPRECATED: The ID of the query | [optional] 

### Return type

[**DeviceQuerySerializer**](DeviceQuerySerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicequeryretrieve"></a>
# **DeviceQueryRetrieve**
> DeviceQuerySerializer DeviceQueryRetrieve (string queryId)



<p>The APIs for creating and manipulating device queries.  </p> <p>Retrieve device query.</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_query_service.Api;
using device_query_service.Client;
using device_query_service.Model;

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
                DeviceQuerySerializer result = apiInstance.DeviceQueryRetrieve(queryId);
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

[**DeviceQuerySerializer**](DeviceQuerySerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="devicequeryupdate"></a>
# **DeviceQueryUpdate**
> DeviceQuerySerializer DeviceQueryUpdate (string queryId, string name, string query, string description = null, string _object = null, string queryId2 = null)



<p>The APIs for creating and manipulating device queries.  </p> <p>Update device query.</p>

### Example
```csharp
using System;
using System.Diagnostics;
using device_query_service.Api;
using device_query_service.Client;
using device_query_service.Model;

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
            var name = name_example;  // string | The name of the query
            var query = query_example;  // string | The device query
            var description = description_example;  // string | The description of the object (optional) 
            var _object = _object_example;  // string | The API resource entity (optional) 
            var queryId2 = queryId_example;  // string | DEPRECATED: The ID of the query (optional) 

            try
            {
                DeviceQuerySerializer result = apiInstance.DeviceQueryUpdate(queryId, name, query, description, _object, queryId2);
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
 **name** | **string**| The name of the query | 
 **query** | **string**| The device query | 
 **description** | **string**| The description of the object | [optional] 
 **_object** | **string**| The API resource entity | [optional] 
 **queryId2** | **string**| DEPRECATED: The ID of the query | [optional] 

### Return type

[**DeviceQuerySerializer**](DeviceQuerySerializer.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

