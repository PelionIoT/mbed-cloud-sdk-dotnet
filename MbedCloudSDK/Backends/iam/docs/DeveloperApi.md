# iam.Api.DeveloperApi

All URIs are relative to *https://api.us-east-1.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateApiKey**](DeveloperApi.md#createapikey) | **POST** /v3/api-keys | Create a new API key.
[**DeleteApiKey**](DeveloperApi.md#deleteapikey) | **DELETE** /v3/api-keys/{apiKey} | Delete API key.
[**DeleteCertificate**](DeveloperApi.md#deletecertificate) | **DELETE** /v3/trusted-certificates/{cert-id} | Delete a trusted certificate by ID.
[**GetAllApiKeys**](DeveloperApi.md#getallapikeys) | **GET** /v3/api-keys | Get all API keys
[**GetAllCertificates**](DeveloperApi.md#getallcertificates) | **GET** /v3/trusted-certificates | Get all trusted certificates.
[**GetAllGroups**](DeveloperApi.md#getallgroups) | **GET** /v3/policy-groups | Get all group information.
[**GetApiKey**](DeveloperApi.md#getapikey) | **GET** /v3/api-keys/{apiKey} | Get API key details.
[**GetApiKeysOfGroup**](DeveloperApi.md#getapikeysofgroup) | **GET** /v3/policy-groups/{groupID}/api-keys | Get the API keys of a group.
[**GetCertificate**](DeveloperApi.md#getcertificate) | **GET** /v3/trusted-certificates/{cert-id} | Get trusted certificate by ID.
[**GetGroupSummary**](DeveloperApi.md#getgroupsummary) | **GET** /v3/policy-groups/{groupID} | Get group information.
[**GetMyAccountInfo**](DeveloperApi.md#getmyaccountinfo) | **GET** /v3/accounts/me | Get account info.
[**GetMyApiKey**](DeveloperApi.md#getmyapikey) | **GET** /v3/api-keys/me | Get API key details.
[**GetMyUser**](DeveloperApi.md#getmyuser) | **GET** /v3/users/me | Details of the current user.
[**RemoveApiKeysFromGroup**](DeveloperApi.md#removeapikeysfromgroup) | **DELETE** /v3/policy-groups/{groupID}/api-keys | Remove API keys from a group.
[**UpdateApiKey**](DeveloperApi.md#updateapikey) | **PUT** /v3/api-keys/{apiKey} | Update API key details.
[**UpdateCertificate**](DeveloperApi.md#updatecertificate) | **PUT** /v3/trusted-certificates/{cert-id} | Update trusted certificate.
[**UpdateMyApiKey**](DeveloperApi.md#updatemyapikey) | **PUT** /v3/api-keys/me | Update API key details.
[**UpdateMyUser**](DeveloperApi.md#updatemyuser) | **PUT** /v3/users/me | Update user details.


<a name="createapikey"></a>
# **CreateApiKey**
> ApiKeyInfoResp CreateApiKey (ApiKeyInfoReq body)

Create a new API key.

An endpoint for creating a new API key.   **Example usage:** `curl -X POST https://api.us-east-1.mbedcloud.com/v3/api-keys -d '{\"name\": \"MyKey1\"}' -H 'content-type: application/json' -H 'Authorization: Bearer API_KEY'`

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

An endpoint for deleting the API key.   **Example usage:** `curl -X DELETE https://api.us-east-1.mbedcloud.com/v3/api-keys/{apikey-id} -H 'Authorization: Bearer API_KEY'`

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

<a name="deletecertificate"></a>
# **DeleteCertificate**
> void DeleteCertificate (string certId)

Delete a trusted certificate by ID.

An endpoint for deleting a trusted certificate.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class DeleteCertificateExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();
            var certId = certId_example;  // string | The ID of the trusted certificate to be deleted.

            try
            {
                // Delete a trusted certificate by ID.
                apiInstance.DeleteCertificate(certId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.DeleteCertificate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **certId** | **string**| The ID of the trusted certificate to be deleted. | 

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
> ApiKeyInfoRespList GetAllApiKeys (int? limit = null, string after = null, string order = null, string include = null, string ownerEq = null)

Get all API keys

An endpoint for retrieving API keys in an array, optionally filtered by the owner.   **Example usage:** `curl https://api.us-east-1.mbedcloud.com/v3/api-keys -H 'Authorization: Bearer API_KEY'`

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
            var limit = 56;  // int? | The number of results to return (2-1000), default is 50. (optional)  (default to 50)
            var after = after_example;  // string | The entity ID to fetch after the given one. (optional) 
            var order = order_example;  // string | The order of the records based on creation time, ASC or DESC; by default ASC (optional)  (default to ASC)
            var include = include_example;  // string | Comma separated additional data to return. Currently supported: total_count (optional) 
            var ownerEq = ownerEq_example;  // string | Owner name filter. (optional) 

            try
            {
                // Get all API keys
                ApiKeyInfoRespList result = apiInstance.GetAllApiKeys(limit, after, order, include, ownerEq);
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
 **limit** | **int?**| The number of results to return (2-1000), default is 50. | [optional] [default to 50]
 **after** | **string**| The entity ID to fetch after the given one. | [optional] 
 **order** | **string**| The order of the records based on creation time, ASC or DESC; by default ASC | [optional] [default to ASC]
 **include** | **string**| Comma separated additional data to return. Currently supported: total_count | [optional] 
 **ownerEq** | **string**| Owner name filter. | [optional] 

### Return type

[**ApiKeyInfoRespList**](ApiKeyInfoRespList.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getallcertificates"></a>
# **GetAllCertificates**
> TrustedCertificateRespList GetAllCertificates (int? limit = null, string after = null, string order = null, string include = null, string serviceEq = null, int? expireEq = null, int? deviceExecutionModeEq = null, string ownerEq = null)

Get all trusted certificates.

An endpoint for retrieving trusted certificates in an array.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class GetAllCertificatesExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();
            var limit = 56;  // int? | The number of results to return (2-1000), default is 50. (optional)  (default to 50)
            var after = after_example;  // string | The entity ID to fetch after the given one. (optional) 
            var order = order_example;  // string | The order of the records based on creation time, ASC or DESC; by default ASC (optional)  (default to ASC)
            var include = include_example;  // string | Comma separated additional data to return. Currently supported: total_count (optional) 
            var serviceEq = serviceEq_example;  // string | Service filter, either lwm2m or bootstrap (optional) 
            var expireEq = 56;  // int? | Expire filter in days (optional) 
            var deviceExecutionModeEq = 56;  // int? | Device execution mode, as 1 for developer certificates or as another natural integer value (optional) 
            var ownerEq = ownerEq_example;  // string | Owner ID filter (optional) 

            try
            {
                // Get all trusted certificates.
                TrustedCertificateRespList result = apiInstance.GetAllCertificates(limit, after, order, include, serviceEq, expireEq, deviceExecutionModeEq, ownerEq);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.GetAllCertificates: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **limit** | **int?**| The number of results to return (2-1000), default is 50. | [optional] [default to 50]
 **after** | **string**| The entity ID to fetch after the given one. | [optional] 
 **order** | **string**| The order of the records based on creation time, ASC or DESC; by default ASC | [optional] [default to ASC]
 **include** | **string**| Comma separated additional data to return. Currently supported: total_count | [optional] 
 **serviceEq** | **string**| Service filter, either lwm2m or bootstrap | [optional] 
 **expireEq** | **int?**| Expire filter in days | [optional] 
 **deviceExecutionModeEq** | **int?**| Device execution mode, as 1 for developer certificates or as another natural integer value | [optional] 
 **ownerEq** | **string**| Owner ID filter | [optional] 

### Return type

[**TrustedCertificateRespList**](TrustedCertificateRespList.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getallgroups"></a>
# **GetAllGroups**
> GroupSummaryList GetAllGroups (int? limit = null, string after = null, string order = null, string include = null)

Get all group information.

An endpoint for retrieving all group information.

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
            var limit = 56;  // int? | The number of results to return (2-1000), default is 50. (optional)  (default to 50)
            var after = after_example;  // string | The entity ID to fetch after the given one. (optional) 
            var order = order_example;  // string | The order of the records based on creation time, ASC or DESC; by default ASC (optional)  (default to ASC)
            var include = include_example;  // string | Comma separated additional data to return. Currently supported: total_count (optional) 

            try
            {
                // Get all group information.
                GroupSummaryList result = apiInstance.GetAllGroups(limit, after, order, include);
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

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **limit** | **int?**| The number of results to return (2-1000), default is 50. | [optional] [default to 50]
 **after** | **string**| The entity ID to fetch after the given one. | [optional] 
 **order** | **string**| The order of the records based on creation time, ASC or DESC; by default ASC | [optional] [default to ASC]
 **include** | **string**| Comma separated additional data to return. Currently supported: total_count | [optional] 

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

An endpoint for retrieving API key details.

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

<a name="getapikeysofgroup"></a>
# **GetApiKeysOfGroup**
> ApiKeyInfoRespList GetApiKeysOfGroup (string groupID, int? limit = null, string after = null, string order = null, string include = null)

Get the API keys of a group.

An endpoint for listing the API keys of the group with details.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class GetApiKeysOfGroupExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();
            var groupID = groupID_example;  // string | The ID of the group whose API keys are retrieved.
            var limit = 56;  // int? | The number of results to return (2-1000), default is 50. (optional)  (default to 50)
            var after = after_example;  // string | The entity ID to fetch after the given one. (optional) 
            var order = order_example;  // string | The order of the records based on creation time, ASC or DESC; by default ASC (optional)  (default to ASC)
            var include = include_example;  // string | Comma separated additional data to return. Currently supported: total_count (optional) 

            try
            {
                // Get the API keys of a group.
                ApiKeyInfoRespList result = apiInstance.GetApiKeysOfGroup(groupID, limit, after, order, include);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.GetApiKeysOfGroup: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **groupID** | **string**| The ID of the group whose API keys are retrieved. | 
 **limit** | **int?**| The number of results to return (2-1000), default is 50. | [optional] [default to 50]
 **after** | **string**| The entity ID to fetch after the given one. | [optional] 
 **order** | **string**| The order of the records based on creation time, ASC or DESC; by default ASC | [optional] [default to ASC]
 **include** | **string**| Comma separated additional data to return. Currently supported: total_count | [optional] 

### Return type

[**ApiKeyInfoRespList**](ApiKeyInfoRespList.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcertificate"></a>
# **GetCertificate**
> TrustedCertificateResp GetCertificate (string certId)

Get trusted certificate by ID.

An endpoint for retrieving a trusted certificate by ID.   **Example usage:** `curl https://api.us-east-1.mbedcloud.com/v3/trusted-certificates/{cert-id} -H 'Authorization: Bearer API_KEY'` 

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class GetCertificateExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();
            var certId = certId_example;  // string | The ID or name of the trusted certificate to be retrieved.

            try
            {
                // Get trusted certificate by ID.
                TrustedCertificateResp result = apiInstance.GetCertificate(certId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.GetCertificate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **certId** | **string**| The ID or name of the trusted certificate to be retrieved. | 

### Return type

[**TrustedCertificateResp**](TrustedCertificateResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getgroupsummary"></a>
# **GetGroupSummary**
> GroupSummary GetGroupSummary (string groupID)

Get group information.

An endpoint for getting general information about the group.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class GetGroupSummaryExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();
            var groupID = groupID_example;  // string | The ID or name of the group to be retrieved.

            try
            {
                // Get group information.
                GroupSummary result = apiInstance.GetGroupSummary(groupID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.GetGroupSummary: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **groupID** | **string**| The ID or name of the group to be retrieved. | 

### Return type

[**GroupSummary**](GroupSummary.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getmyaccountinfo"></a>
# **GetMyAccountInfo**
> AccountInfo GetMyAccountInfo (string include = null)

Get account info.

Returns detailed information about the account.   **Example usage:** `curl https://api.us-east-1.mbedcloud.com/v3/accounts/me?include=policies -H 'Authorization: Bearer API_KEY'` .

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
            var include = include_example;  // string | Comma separated additional data to return. Currently supported: limits, policies, sub_accounts. (optional) 

            try
            {
                // Get account info.
                AccountInfo result = apiInstance.GetMyAccountInfo(include);
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

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **include** | **string**| Comma separated additional data to return. Currently supported: limits, policies, sub_accounts. | [optional] 

### Return type

[**AccountInfo**](AccountInfo.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getmyapikey"></a>
# **GetMyApiKey**
> ApiKeyInfoResp GetMyApiKey ()

Get API key details.

An endpoint for retrieving API key details.   **Example usage:** `curl https://api.us-east-1.mbedcloud.com/v3/api-keys/me -H 'Authorization: Bearer API_KEY'`

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class GetMyApiKeyExample
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
                // Get API key details.
                ApiKeyInfoResp result = apiInstance.GetMyApiKey();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.GetMyApiKey: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**ApiKeyInfoResp**](ApiKeyInfoResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getmyuser"></a>
# **GetMyUser**
> MyUserInfoResp GetMyUser (string scratchCodes = null)

Details of the current user.

An endpoint for retrieving the details of the logged in user.   **Example usage:** `curl https://api.us-east-1.mbedcloud.com/v3/users/me -H 'Authorization: Bearer API_KEY'` 

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
            var scratchCodes = scratchCodes_example;  // string | Request to regenerate new emergency scratch codes. (optional) 

            try
            {
                // Details of the current user.
                MyUserInfoResp result = apiInstance.GetMyUser(scratchCodes);
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

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **scratchCodes** | **string**| Request to regenerate new emergency scratch codes. | [optional] 

### Return type

[**MyUserInfoResp**](MyUserInfoResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="removeapikeysfromgroup"></a>
# **RemoveApiKeysFromGroup**
> UpdatedResponse RemoveApiKeysFromGroup (string groupID, SubjectList body)

Remove API keys from a group.

An endpoint for removing API keys from groups.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class RemoveApiKeysFromGroupExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();
            var groupID = groupID_example;  // string | The ID of the group whose API keys are removed.
            var body = new SubjectList(); // SubjectList | A list of API keys to be removed from the group.

            try
            {
                // Remove API keys from a group.
                UpdatedResponse result = apiInstance.RemoveApiKeysFromGroup(groupID, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.RemoveApiKeysFromGroup: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **groupID** | **string**| The ID of the group whose API keys are removed. | 
 **body** | [**SubjectList**](SubjectList.md)| A list of API keys to be removed from the group. | 

### Return type

[**UpdatedResponse**](UpdatedResponse.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateapikey"></a>
# **UpdateApiKey**
> ApiKeyInfoResp UpdateApiKey (string apiKey, ApiKeyUpdateReq body)

Update API key details.

An endpoint for updating API key details.

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
            var body = new ApiKeyUpdateReq(); // ApiKeyUpdateReq | New API key attributes to be stored.

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
 **body** | [**ApiKeyUpdateReq**](ApiKeyUpdateReq.md)| New API key attributes to be stored. | 

### Return type

[**ApiKeyInfoResp**](ApiKeyInfoResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatecertificate"></a>
# **UpdateCertificate**
> TrustedCertificateResp UpdateCertificate (string certId, TrustedCertificateUpdateReq body)

Update trusted certificate.

An endpoint for updating existing trusted certificates.   **Example usage:** `curl -X PUT https://api.us-east-1.mbedcloud.com/v3/trusted-certificates/{cert-id} -d {\"description\": \"very important cert\"} -H 'content-type: application/json' -H 'Authorization: Bearer API_KEY'` 

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class UpdateCertificateExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();
            var certId = certId_example;  // string | The ID of the trusted certificate to be updated.
            var body = new TrustedCertificateUpdateReq(); // TrustedCertificateUpdateReq | A trusted certificate object with attributes.

            try
            {
                // Update trusted certificate.
                TrustedCertificateResp result = apiInstance.UpdateCertificate(certId, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.UpdateCertificate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **certId** | **string**| The ID of the trusted certificate to be updated. | 
 **body** | [**TrustedCertificateUpdateReq**](TrustedCertificateUpdateReq.md)| A trusted certificate object with attributes. | 

### Return type

[**TrustedCertificateResp**](TrustedCertificateResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatemyapikey"></a>
# **UpdateMyApiKey**
> ApiKeyInfoResp UpdateMyApiKey (ApiKeyUpdateReq body)

Update API key details.

An endpoint for updating API key details.   **Example usage:** `curl -X PUT https://api.us-east-1.mbedcloud.com/v3/api-keys/me -d '{\"name\": \"TestApiKey25\"}' -H 'content-type: application/json' -H 'Authorization: Bearer API_KEY'`

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class UpdateMyApiKeyExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DeveloperApi();
            var body = new ApiKeyUpdateReq(); // ApiKeyUpdateReq | New API key attributes to be stored.

            try
            {
                // Update API key details.
                ApiKeyInfoResp result = apiInstance.UpdateMyApiKey(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DeveloperApi.UpdateMyApiKey: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**ApiKeyUpdateReq**](ApiKeyUpdateReq.md)| New API key attributes to be stored. | 

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
> UserUpdateResp UpdateMyUser (UserUpdateReq body)

Update user details.

An endpoint for updating the details of the logged in user.   **Example usage:** `curl -X PUT https://api.us-east-1.mbedcloud.com/v3/users/me -d '{\"address\": \"1007 Mountain Drive\"}' -H 'content-type: application/json' -H 'Authorization: Bearer API_KEY'` 

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
            var body = new UserUpdateReq(); // UserUpdateReq | New attributes for the logged in user.

            try
            {
                // Update user details.
                UserUpdateResp result = apiInstance.UpdateMyUser(body);
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
 **body** | [**UserUpdateReq**](UserUpdateReq.md)| New attributes for the logged in user. | 

### Return type

[**UserUpdateResp**](UserUpdateResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

