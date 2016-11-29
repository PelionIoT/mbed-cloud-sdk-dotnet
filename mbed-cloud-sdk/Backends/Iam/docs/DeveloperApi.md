# iam.Api.DeveloperApi

All URIs are relative to *https://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateApiKey**](DeveloperApi.md#createapikey) | **POST** /v3/api-keys | Create a new API key.
[**DeleteApiKey**](DeveloperApi.md#deleteapikey) | **DELETE** /v3/api-keys/{apiKey} | Delete API key.
[**GetAllApiKeys**](DeveloperApi.md#getallapikeys) | **GET** /v3/api-keys | Get all API keys
[**GetAllGroups**](DeveloperApi.md#getallgroups) | **GET** /v3/policy-groups | Get all group information.
[**GetApiKey**](DeveloperApi.md#getapikey) | **GET** /v3/api-keys/{apiKey} | Get API key details.
[**GetMyAccountInfo**](DeveloperApi.md#getmyaccountinfo) | **GET** /v3/accounts/me | Get account info.
[**GetMyUser**](DeveloperApi.md#getmyuser) | **GET** /v3/users/me | Details of the current user.
[**UpdateApiKey**](DeveloperApi.md#updateapikey) | **PUT** /v3/api-keys/{apiKey} | Update API key details.
[**UpdateMyUser**](DeveloperApi.md#updatemyuser) | **PUT** /v3/users/me | Update user details.


<a name="createapikey"></a>
# **CreateApiKey**
> ApiKeyInfoResp CreateApiKey (ApiKeyInfoReq body)

Create a new API key.

Endpoint for creating the new API key.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class CreateApiKeyExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();
            var body = new ApiKeyInfoReq(); // ApiKeyInfoReq | The details of the API key to be created.

            try
            {
                // Create a new API key.
                ApiKeyInfoResp result = apiInstance.CreateApiKey(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.CreateApiKey: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**ApiKeyInfoReq**](ApiKeyInfoReq.md)| The details of the API key to be created. | 

### Return type

[**ApiKeyInfoResp**](ApiKeyInfoResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteapikey"></a>
# **DeleteApiKey**
> void DeleteApiKey (string apiKey)

Delete API key.

Endpoint for deleting the API key.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class DeleteApiKeyExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();
            var apiKey = apiKey_example;  // string | The ID of the API key to be deleted.

            try
            {
                // Delete API key.
                apiInstance.DeleteApiKey(apiKey);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.DeleteApiKey: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **apiKey** | **string**| The ID of the API key to be deleted. | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getallapikeys"></a>
# **GetAllApiKeys**
> ApiKeyInfoRespList GetAllApiKeys (string owner = null)

Get all API keys

Endpoint for retrieving API keys in an array, optionally filtered by the owner.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class GetAllApiKeysExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();
            var owner = owner_example;  // string | Owner name filter. (optional) 

            try
            {
                // Get all API keys
                ApiKeyInfoRespList result = apiInstance.GetAllApiKeys(owner);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.GetAllApiKeys: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **owner** | **string**| Owner name filter. | [optional] 

### Return type

[**ApiKeyInfoRespList**](ApiKeyInfoRespList.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getallgroups"></a>
# **GetAllGroups**
> GroupSummaryList GetAllGroups ()

Get all group information.

Endpoint for retrieving all group information.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class GetAllGroupsExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();

            try
            {
                // Get all group information.
                GroupSummaryList result = apiInstance.GetAllGroups();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.GetAllGroups: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**GroupSummaryList**](GroupSummaryList.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getapikey"></a>
# **GetApiKey**
> ApiKeyInfoResp GetApiKey (string apiKey)

Get API key details.

Endpoint for retrieving API key details.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class GetApiKeyExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();
            var apiKey = apiKey_example;  // string | The ID of the API key to be retrieved.

            try
            {
                // Get API key details.
                ApiKeyInfoResp result = apiInstance.GetApiKey(apiKey);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.GetApiKey: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **apiKey** | **string**| The ID of the API key to be retrieved. | 

### Return type

[**ApiKeyInfoResp**](ApiKeyInfoResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getmyaccountinfo"></a>
# **GetMyAccountInfo**
> AccountInfo GetMyAccountInfo ()

Get account info.

Returns detailed information about the account.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class GetMyAccountInfoExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();

            try
            {
                // Get account info.
                AccountInfo result = apiInstance.GetMyAccountInfo();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.GetMyAccountInfo: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**AccountInfo**](AccountInfo.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getmyuser"></a>
# **GetMyUser**
> UserInfoResp GetMyUser ()

Details of the current user.

Endpoint for retrieving the details of the logged in user.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class GetMyUserExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();

            try
            {
                // Details of the current user.
                UserInfoResp result = apiInstance.GetMyUser();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.GetMyUser: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**UserInfoResp**](UserInfoResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateapikey"></a>
# **UpdateApiKey**
> ApiKeyInfoResp UpdateApiKey (string apiKey, ApiKeyInfoReq body)

Update API key details.

Endpoint for updating API key details.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class UpdateApiKeyExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();
            var apiKey = apiKey_example;  // string | The ID of the API key to be updated.
            var body = new ApiKeyInfoReq(); // ApiKeyInfoReq | New API key attributes to be stored.

            try
            {
                // Update API key details.
                ApiKeyInfoResp result = apiInstance.UpdateApiKey(apiKey, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.UpdateApiKey: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **apiKey** | **string**| The ID of the API key to be updated. | 
 **body** | [**ApiKeyInfoReq**](ApiKeyInfoReq.md)| New API key attributes to be stored. | 

### Return type

[**ApiKeyInfoResp**](ApiKeyInfoResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatemyuser"></a>
# **UpdateMyUser**
> UserInfoResp UpdateMyUser (UserInfoReq body)

Update user details.

Endpoint for updating the details of the logged in user.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class UpdateMyUserExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();
            var body = new UserInfoReq(); // UserInfoReq | New attributes for the logged in user.

            try
            {
                // Update user details.
                UserInfoResp result = apiInstance.UpdateMyUser(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.UpdateMyUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**UserInfoReq**](UserInfoReq.md)| New attributes for the logged in user. | 

### Return type

[**UserInfoResp**](UserInfoResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

