# production_line_certificates.Api.DefaultApi

All URIs are relative to *https://api.mbedcloud.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**V3ProductionLineCertificatesGet**](DefaultApi.md#v3productionlinecertificatesget) | **GET** /v3/production-line-certificates | 
[**V3ProductionLineCertificatesMUUIDDelete**](DefaultApi.md#v3productionlinecertificatesmuuiddelete) | **DELETE** /v3/production-line-certificates/{mUUID} | 
[**V3ProductionLineCertificatesMUUIDGet**](DefaultApi.md#v3productionlinecertificatesmuuidget) | **GET** /v3/production-line-certificates/{mUUID} | 
[**V3ProductionLineCertificatesMUUIDPut**](DefaultApi.md#v3productionlinecertificatesmuuidput) | **PUT** /v3/production-line-certificates/{mUUID} | 
[**V3ProductionLineCertificatesPost**](DefaultApi.md#v3productionlinecertificatespost) | **POST** /v3/production-line-certificates | 


<a name="v3productionlinecertificatesget"></a>
# **V3ProductionLineCertificatesGet**
> AListOfProductionLineCertificates_ V3ProductionLineCertificatesGet (string authorization)



Gets the list of production line certificates associated with the account. 

### Example
```csharp
using System;
using System.Diagnostics;
using production_line_certificates.Api;
using production_line_certificates.Client;
using production_line_certificates.Model;

namespace Example
{
    public class V3ProductionLineCertificatesGetExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var authorization = authorization_example;  // string | \"Bearer\" followed by the reference token or API key.

            try
            {
                AListOfProductionLineCertificates_ result = apiInstance.V3ProductionLineCertificatesGet(authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.V3ProductionLineCertificatesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**| \&quot;Bearer\&quot; followed by the reference token or API key. | 

### Return type

[**AListOfProductionLineCertificates_**](AListOfProductionLineCertificates_.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3productionlinecertificatesmuuiddelete"></a>
# **V3ProductionLineCertificatesMUUIDDelete**
> ProductionLineCertificate V3ProductionLineCertificatesMUUIDDelete (string authorization, string mUUID)



Deactivates the production line certificate.  There is no way to reactivate it. 

### Example
```csharp
using System;
using System.Diagnostics;
using production_line_certificates.Api;
using production_line_certificates.Client;
using production_line_certificates.Model;

namespace Example
{
    public class V3ProductionLineCertificatesMUUIDDeleteExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var authorization = authorization_example;  // string | \"Bearer\" followed by the reference token or API key.
            var mUUID = mUUID_example;  // string | Certificate mUUID

            try
            {
                ProductionLineCertificate result = apiInstance.V3ProductionLineCertificatesMUUIDDelete(authorization, mUUID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.V3ProductionLineCertificatesMUUIDDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**| \&quot;Bearer\&quot; followed by the reference token or API key. | 
 **mUUID** | **string**| Certificate mUUID | 

### Return type

[**ProductionLineCertificate**](ProductionLineCertificate.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3productionlinecertificatesmuuidget"></a>
# **V3ProductionLineCertificatesMUUIDGet**
> ProductionLineCertificate V3ProductionLineCertificatesMUUIDGet (string authorization, string mUUID)



Gets a single production line certificate by its mUUID. 

### Example
```csharp
using System;
using System.Diagnostics;
using production_line_certificates.Api;
using production_line_certificates.Client;
using production_line_certificates.Model;

namespace Example
{
    public class V3ProductionLineCertificatesMUUIDGetExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var authorization = authorization_example;  // string | \"Bearer\" followed by the reference token or API key.
            var mUUID = mUUID_example;  // string | Certificate mUUID.

            try
            {
                ProductionLineCertificate result = apiInstance.V3ProductionLineCertificatesMUUIDGet(authorization, mUUID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.V3ProductionLineCertificatesMUUIDGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**| \&quot;Bearer\&quot; followed by the reference token or API key. | 
 **mUUID** | **string**| Certificate mUUID. | 

### Return type

[**ProductionLineCertificate**](ProductionLineCertificate.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3productionlinecertificatesmuuidput"></a>
# **V3ProductionLineCertificatesMUUIDPut**
> ProductionLineCertificate V3ProductionLineCertificatesMUUIDPut (string authorization, string mUUID, Body1 body)



Updates the comment on a production line certificate. 

### Example
```csharp
using System;
using System.Diagnostics;
using production_line_certificates.Api;
using production_line_certificates.Client;
using production_line_certificates.Model;

namespace Example
{
    public class V3ProductionLineCertificatesMUUIDPutExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var authorization = authorization_example;  // string | \"Bearer\" followed by the reference token or API key.
            var mUUID = mUUID_example;  // string | Certificate mUUID
            var body = new Body1(); // Body1 | 

            try
            {
                ProductionLineCertificate result = apiInstance.V3ProductionLineCertificatesMUUIDPut(authorization, mUUID, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.V3ProductionLineCertificatesMUUIDPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**| \&quot;Bearer\&quot; followed by the reference token or API key. | 
 **mUUID** | **string**| Certificate mUUID | 
 **body** | [**Body1**](Body1.md)|  | 

### Return type

[**ProductionLineCertificate**](ProductionLineCertificate.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="v3productionlinecertificatespost"></a>
# **V3ProductionLineCertificatesPost**
> ProductionLineCertificate V3ProductionLineCertificatesPost (string authorization, Body body)



Adds a new production line certificate to the account. 

### Example
```csharp
using System;
using System.Diagnostics;
using production_line_certificates.Api;
using production_line_certificates.Client;
using production_line_certificates.Model;

namespace Example
{
    public class V3ProductionLineCertificatesPostExample
    {
        public void main()
        {
            
            // Configure API key authorization: Bearer
            Configuration.Default.ApiKey.Add("Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("Authorization", "Bearer");

            var apiInstance = new DefaultApi();
            var authorization = authorization_example;  // string | \"Bearer\" followed by the reference token or API key.
            var body = new Body(); // Body | 

            try
            {
                ProductionLineCertificate result = apiInstance.V3ProductionLineCertificatesPost(authorization, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling DefaultApi.V3ProductionLineCertificatesPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**| \&quot;Bearer\&quot; followed by the reference token or API key. | 
 **body** | [**Body**](Body.md)|  | 

### Return type

[**ProductionLineCertificate**](ProductionLineCertificate.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

