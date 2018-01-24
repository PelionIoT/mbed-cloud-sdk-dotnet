# iam.Model.UserUpdateReq
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PhoneNumber** | **string** | Phone number, not longer than 100 characters. | [optional] 
**Username** | **string** | A username containing alphanumerical letters and -,._@+&#x3D; characters. It must be at least 4 but not more than 30 character long. | [optional] 
**IsMarketingAccepted** | **bool?** | A flag indicating that receiving marketing information has been accepted. | [optional] 
**IsGtcAccepted** | **bool?** | A flag indicating that the General Terms and Conditions has been accepted. | [optional] 
**IsTotpEnabled** | **bool?** | A flag indicating whether 2-factor authentication (TOTP) has to be enabled or disabled. | [optional] 
**Status** | **string** | The status of the user. | [optional] 
**FullName** | **string** | The full name of the user, not longer than 100 characters. | [optional] 
**Address** | **string** | Address, not longer than 100 characters. | [optional] 
**Password** | **string** | The password when creating a new user. It will be generated when not present in the request. | [optional] 
**Email** | **string** | The email address, not longer than 254 characters. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

