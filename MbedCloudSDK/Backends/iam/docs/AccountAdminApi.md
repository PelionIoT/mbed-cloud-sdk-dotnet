# iam.Api.AccountAdminApi

All URIs are relative to *https://api.us-east-1.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddCertificate**](AccountAdminApi.md#addcertificate) | **POST** /v3/trusted-certificates | Upload a new trusted certificate.
[**AddSubjectsToGroup**](AccountAdminApi.md#addsubjectstogroup) | **POST** /v3/policy-groups/{groupID} | Add members to a group.
[**CreateUser**](AccountAdminApi.md#createuser) | **POST** /v3/users | Create a new user.
[**DeleteUser**](AccountAdminApi.md#deleteuser) | **DELETE** /v3/users/{user-id} | Delete a user.
[**GetAllUsers**](AccountAdminApi.md#getallusers) | **GET** /v3/users | Get the details of all users.
[**GetUser**](AccountAdminApi.md#getuser) | **GET** /v3/users/{user-id} | Details of a user.
[**GetUsersOfGroup**](AccountAdminApi.md#getusersofgroup) | **GET** /v3/policy-groups/{groupID}/users | Get users of a group.
[**RemoveUsersFromGroup**](AccountAdminApi.md#removeusersfromgroup) | **DELETE** /v3/policy-groups/{groupID}/users | Remove users from a group.
[**UpdateMyAccount**](AccountAdminApi.md#updatemyaccount) | **PUT** /v3/accounts/me | Updates attributes of the account.
[**UpdateUser**](AccountAdminApi.md#updateuser) | **PUT** /v3/users/{user-id} | Update user details.


<a name="addcertificate"></a>
# **AddCertificate**
> TrustedCertificateResp AddCertificate (TrustedCertificateReq body)

Upload a new trusted certificate.

An endpoint for uploading new trusted certificates.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class AddCertificateExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new AccountAdminApi();
            var body = new TrustedCertificateReq(); // TrustedCertificateReq | A trusted certificate object with attributes.

            try
            {
                // Upload a new trusted certificate.
                TrustedCertificateResp result = apiInstance.AddCertificate(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountAdminApi.AddCertificate: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**TrustedCertificateReq**](TrustedCertificateReq.md)| A trusted certificate object with attributes. | 

### Return type

[**TrustedCertificateResp**](TrustedCertificateResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="addsubjectstogroup"></a>
# **AddSubjectsToGroup**
> UpdatedResponse AddSubjectsToGroup (string groupID, SubjectList body)

Add members to a group.

An endpoint for adding users and API keys to groups.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class AddSubjectsToGroupExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new AccountAdminApi();
            var groupID = groupID_example;  // string | The ID of the group to be updated.
            var body = new SubjectList(); // SubjectList | A list of users and API keys to be added to the group.

            try
            {
                // Add members to a group.
                UpdatedResponse result = apiInstance.AddSubjectsToGroup(groupID, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountAdminApi.AddSubjectsToGroup: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **groupID** | **string**| The ID of the group to be updated. | 
 **body** | [**SubjectList**](SubjectList.md)| A list of users and API keys to be added to the group. | 

### Return type

[**UpdatedResponse**](UpdatedResponse.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createuser"></a>
# **CreateUser**
> UserInfoResp CreateUser (UserInfoReq body, string action = null)

Create a new user.

An endpoint for creating or inviting a new user to the account. In case of invitation email address is used only, other attributes are set in the 2nd step.

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
            var action = action_example;  // string | Action, either 'create' or 'invite'. (optional)  (default to create)

            try
            {
                // Create a new user.
                UserInfoResp result = apiInstance.CreateUser(body, action);
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
 **action** | **string**| Action, either &#39;create&#39; or &#39;invite&#39;. | [optional] [default to create]

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

An endpoint for deleting a user.

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
> UserInfoRespList GetAllUsers (int? limit = null, string after = null, string order = null, string include = null, string statusEq = null)

Get the details of all users.

An endpoint for retrieving the details of all users.

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
            var limit = 56;  // int? | The number of results to return (2-1000), default is 50. (optional)  (default to 50)
            var after = after_example;  // string | The entity ID to fetch after the given one. (optional) 
            var order = order_example;  // string | The order of the records based on creation time, ASC or DESC; by default ASC (optional)  (default to ASC)
            var include = include_example;  // string | Comma separated additional data to return. Currently supported: total_count (optional) 
            var statusEq = statusEq_example;  // string | Filter for status, for example active or reset (optional) 

            try
            {
                // Get the details of all users.
                UserInfoRespList result = apiInstance.GetAllUsers(limit, after, order, include, statusEq);
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

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **limit** | **int?**| The number of results to return (2-1000), default is 50. | [optional] [default to 50]
 **after** | **string**| The entity ID to fetch after the given one. | [optional] 
 **order** | **string**| The order of the records based on creation time, ASC or DESC; by default ASC | [optional] [default to ASC]
 **include** | **string**| Comma separated additional data to return. Currently supported: total_count | [optional] 
 **statusEq** | **string**| Filter for status, for example active or reset | [optional] 

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

An endpoint for retrieving the details of a user.

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

<a name="getusersofgroup"></a>
# **GetUsersOfGroup**
> UserInfoRespList GetUsersOfGroup (string groupID, int? limit = null, string after = null, string order = null, string include = null)

Get users of a group.

An endpoint for listing the users of a group with details.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class GetUsersOfGroupExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new AccountAdminApi();
            var groupID = groupID_example;  // string | The ID of the group whose users are retrieved.
            var limit = 56;  // int? | The number of results to return (2-1000), default is 50. (optional)  (default to 50)
            var after = after_example;  // string | The entity ID to fetch after the given one. (optional) 
            var order = order_example;  // string | The order of the records based on creation time, ASC or DESC; by default ASC (optional)  (default to ASC)
            var include = include_example;  // string | Comma separated additional data to return. Currently supported: total_count (optional) 

            try
            {
                // Get users of a group.
                UserInfoRespList result = apiInstance.GetUsersOfGroup(groupID, limit, after, order, include);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountAdminApi.GetUsersOfGroup: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **groupID** | **string**| The ID of the group whose users are retrieved. | 
 **limit** | **int?**| The number of results to return (2-1000), default is 50. | [optional] [default to 50]
 **after** | **string**| The entity ID to fetch after the given one. | [optional] 
 **order** | **string**| The order of the records based on creation time, ASC or DESC; by default ASC | [optional] [default to ASC]
 **include** | **string**| Comma separated additional data to return. Currently supported: total_count | [optional] 

### Return type

[**UserInfoRespList**](UserInfoRespList.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="removeusersfromgroup"></a>
# **RemoveUsersFromGroup**
> UpdatedResponse RemoveUsersFromGroup (string groupID, SubjectList body)

Remove users from a group.

An endpoint for removing users from groups.

### Example
```csharp
using System;
using System.Diagnostics;
using iam.Api;
using iam.Client;
using iam.Model;

namespace Example
{
    public class RemoveUsersFromGroupExample
    {
        public void main()
        {
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new AccountAdminApi();
            var groupID = groupID_example;  // string | The ID of the group whose users are removed.
            var body = new SubjectList(); // SubjectList | A list of users to be removed from the group.

            try
            {
                // Remove users from a group.
                UpdatedResponse result = apiInstance.RemoveUsersFromGroup(groupID, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountAdminApi.RemoveUsersFromGroup: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **groupID** | **string**| The ID of the group whose users are removed. | 
 **body** | [**SubjectList**](SubjectList.md)| A list of users to be removed from the group. | 

### Return type

[**UpdatedResponse**](UpdatedResponse.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updatemyaccount"></a>
# **UpdateMyAccount**
> AccountInfo UpdateMyAccount (AccountUpdateReq body)

Updates attributes of the account.

An endpoint for updating the account.   **Example usage:** `curl -X PUT https://api.us-east-1.mbedcloud.com/v3/accounts/me -d '{\"phone_number\": \"12345678\"}' -H 'content-type: application/json' -H 'Authorization: Bearer API_KEY'`

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
                AccountInfo result = apiInstance.UpdateMyAccount(body);
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

[**AccountInfo**](AccountInfo.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateuser"></a>
# **UpdateUser**
> UserInfoResp UpdateUser (string userId, UserUpdateReq body)

Update user details.

An endpoint for updating user details.

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
            var body = new UserUpdateReq(); // UserUpdateReq | A user object with attributes.

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
 **body** | [**UserUpdateReq**](UserUpdateReq.md)| A user object with attributes. | 

### Return type

[**UserInfoResp**](UserInfoResp.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

