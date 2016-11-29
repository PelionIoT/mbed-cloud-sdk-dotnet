# iam.Model.UserInfoReq
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Username** | **string** | A username containing alphanumerical letters and -,._@+&#x3D; characters. | 
**PhoneNumber** | **string** | Phone number. | [optional] 
**Groups** | **List&lt;string&gt;** | A list of IDs of the groups this user belongs to. | [optional] 
**IsGtcAccepted** | **bool?** | A flag indicating that the General Terms and Conditions has been accepted. | [optional] [default to false]
**IsMarketingAccepted** | **bool?** | A flag indicating that receiving marketing information has been accepted. | [optional] [default to false]
**FullName** | **string** | The full name of the user. | [optional] 
**Address** | **string** | Address. | [optional] 
**Password** | **string** | The password when creating a new user. It will will generated when not present in the request. | [optional] 
**Email** | **string** | Email address. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

