# iam.Model.UserInfoResp
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Status** | **string** | The status of the user. INVITED means that the user has not accepted the invitation request. RESET means that the password must be changed immediately. | 
**Username** | **string** | A username containing alphanumerical letters and -,._@+&#x3D; characters. | 
**EmailVerified** | **bool?** | A flag indicating whether the user&#39;s email address has been verified or not. | [optional] [default to false]
**AccountId** | **string** | The UUID of the account. | 
**PasswordChangedTime** | **long?** | A timestamp of the latest change of the user password, in milliseconds. | [optional] 
**Groups** | **List&lt;string&gt;** | A list of IDs of the groups this user belongs to. | [optional] 
**CreatedAt** | **string** | Creation UTC time RFC3339. | [optional] 
**_Object** | **string** | entity name: always &#39;user&#39; | 
**IsGtcAccepted** | **bool?** | A flag indicating that the General Terms and Conditions has been accepted. | [optional] [default to false]
**Email** | **string** | Email address. | 
**IsMarketingAccepted** | **bool?** | A flag indicating that receiving marketing information has been accepted. | [optional] [default to false]
**Etag** | **string** | API resource entity version. | 
**FullName** | **string** | The full name of the user. | [optional] 
**Address** | **string** | Address. | [optional] 
**CreationTime** | **long?** | A timestamp of the user creation in the storage, in milliseconds. | [optional] 
**Password** | **string** | The password when creating a new user. It will will generated when not present in the request. | [optional] 
**PhoneNumber** | **string** | Phone number. | [optional] 
**Id** | **string** | The UUID of the user. | 
**LastLoginTime** | **long?** | A timestamp of the latest login of the user, in milliseconds. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

