# iam.Model.UserInfoReq
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PhoneNumber** | **string** | Phone number, not longer than 100 characters. | [optional] 
**Username** | **string** | A username containing alphanumerical letters and -,._@+&#x3D; characters. It must be at least 4 but not more than 30 character long. | [optional] 
**Groups** | **List&lt;string&gt;** | A list of IDs of the groups this user belongs to. | [optional] 
**IsGtcAccepted** | **bool?** | A flag indicating that the General Terms and Conditions has been accepted. | [optional] 
**FullName** | **string** | The full name of the user, not longer than 100 characters. | [optional] 
**IsMarketingAccepted** | **bool?** | A flag indicating that receiving marketing information has been accepted. | [optional] 
**Address** | **string** | Address, not longer than 100 characters. | [optional] 
**Password** | **string** | The password when creating a new user. It will be generated when not present in the request. | [optional] 
**Email** | **string** | The email address, not longer than 254 characters. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

