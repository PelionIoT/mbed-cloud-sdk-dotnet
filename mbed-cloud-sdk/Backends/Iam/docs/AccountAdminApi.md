# iam.Api.AccountAdminApi

All URIs are relative to *https://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateUser**](AccountAdminApi.md#createuser) | **POST** /v3/users | Create a new user.
[**DeleteUser**](AccountAdminApi.md#deleteuser) | **DELETE** /v3/users/{user-id} | Delete a user.
[**GetAllUsers**](AccountAdminApi.md#getallusers) | **GET** /v3/users | Get the details of all users.
[**GetUser**](AccountAdminApi.md#getuser) | **GET** /v3/users/{user-id} | Details of a user.
[**UpdateMyAccount**](AccountAdminApi.md#updatemyaccount) | **PUT** /v3/accounts/me | Updates attributes of the account.
[**UpdateUser**](AccountAdminApi.md#updateuser) | **PUT** /v3/users/{user-id} | Update user details.


<a name="createuser"></a>
# **CreateUser**
> UserInfoResp CreateUser (UserInfoReq body)

Create a new user.

Endpoint for creating a new user.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class CreateUserExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new AccountAdminApi();
            var body = new UserInfoReq(); // UserInfoReq | A user object with attributes.

            try
            {
                // Create a new user.
                UserInfoResp result = apiInstance.CreateUser(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountAdminApi.CreateUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**UserInfoReq**](UserInfoReq.md)| A user object with attributes. | 

### Return type

[**UserInfoResp**](UserInfoResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteuser"></a>
# **DeleteUser**
> void DeleteUser (string userId)

Delete a user.

Endpoint for deleting a user.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class DeleteUserExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new AccountAdminApi();
            var userId = userId_example;  // string | The ID of the user to be deleted.

            try
            {
                // Delete a user.
                apiInstance.DeleteUser(userId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountAdminApi.DeleteUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **string**| The ID of the user to be deleted. | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getallusers"></a>
# **GetAllUsers**
> UserInfoRespList GetAllUsers ()

Get the details of all users.

Endpoint for retrieving the details of all users.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class GetAllUsersExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new AccountAdminApi();

            try
            {
                // Get the details of all users.
                UserInfoRespList result = apiInstance.GetAllUsers();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountAdminApi.GetAllUsers: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**UserInfoRespList**](UserInfoRespList.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getuser"></a>
# **GetUser**
> UserInfoResp GetUser (string userId)

Details of a user.

Endpoint for retrieving the details of a user.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class GetUserExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new AccountAdminApi();
            var userId = userId_example;  // string | The ID or name of the user whose details are retrieved.

            try
            {
                // Details of a user.
                UserInfoResp result = apiInstance.GetUser(userId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountAdminApi.GetUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **string**| The ID or name of the user whose details are retrieved. | 

### Return type

[**UserInfoResp**](UserInfoResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatemyaccount"></a>
# **UpdateMyAccount**
> UpdatedResponse UpdateMyAccount (AccountUpdateReq body)

Updates attributes of the account.

Endpoint for updating the account.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class UpdateMyAccountExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new AccountAdminApi();
            var body = new AccountUpdateReq(); // AccountUpdateReq | Details of the account to be updated.

            try
            {
                // Updates attributes of the account.
                UpdatedResponse result = apiInstance.UpdateMyAccount(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountAdminApi.UpdateMyAccount: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**AccountUpdateReq**](AccountUpdateReq.md)| Details of the account to be updated. | 

### Return type

[**UpdatedResponse**](UpdatedResponse.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateuser"></a>
# **UpdateUser**
> UserInfoResp UpdateUser (string userId, UserInfoReq body)

Update user details.

Endpoint for updating user details.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class UpdateUserExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new AccountAdminApi();
            var userId = userId_example;  // string | The ID of the user whose details are updated.
            var body = new UserInfoReq(); // UserInfoReq | A user object with attributes.

            try
            {
                // Update user details.
                UserInfoResp result = apiInstance.UpdateUser(userId, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountAdminApi.UpdateUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **string**| The ID of the user whose details are updated. | 
 **body** | [**UserInfoReq**](UserInfoReq.md)| A user object with attributes. | 

### Return type

[**UserInfoResp**](UserInfoResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

