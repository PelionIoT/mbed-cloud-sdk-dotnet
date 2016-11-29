# iam.Model.ApiKeyInfoResp
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Status** | **string** | The status of the API key. | [optional] 
**Apikey** | **string** | API key. | 
**Name** | **string** | The display name for the API key. | 
**CreatedAt** | **string** | Creation UTC time RFC3339. | [optional] 
**_Object** | **string** | entity name: always &#39;apikey&#39; | 
**CreationTime** | **long?** | The timestamp of the API key creation in the storage, in milliseconds. | [optional] 
**Etag** | **string** | API resource entity version. | 
**Groups** | **List&lt;string&gt;** | A list of group IDs this API key belongs to. | [optional] 
**Owner** | **string** | The owner of this API key, who is the creator by default. | [optional] 
**SecretKey** | **string** | API key secret. | [optional] 
**Id** | **string** | UUID of the API key. | 
**LastLoginTime** | **long?** | The timestamp of the latest API key usage, in milliseconds. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

