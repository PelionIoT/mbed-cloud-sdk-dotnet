# iam.Model.AccountUpdateReq
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AddressLine2** | **string** | Postal address line 2, not longer than 100 characters. | [optional] 
**City** | **string** | The city part of the postal address, not longer than 100 characters. Required for commercial accounts only. | [optional] 
**AddressLine1** | **string** | Postal address line 1, not longer than 100 characters. Required for commercial accounts only. | [optional] 
**DisplayName** | **string** | The display name for the account, not longer than 100 characters. | [optional] 
**Country** | **string** | The country part of the postal address, not longer than 100 characters. Required for commercial accounts only. | [optional] 
**Company** | **string** | The name of the company, not longer than 100 characters. Required for commercial accounts only. | [optional] 
**IdleTimeout** | **string** | The reference token expiration time in minutes for this account. Between 1 and 120 minutes. | [optional] 
**State** | **string** | The state part of the postal address, not longer than 100 characters. | [optional] 
**Contact** | **string** | The name of the contact person for this account, not longer than 100 characters. Required for commercial accounts only. | [optional] 
**PostalCode** | **string** | The postal code part of the postal address, not longer than 100 characters. | [optional] 
**PasswordPolicy** | [**PasswordPolicy**](PasswordPolicy.md) | Password policy for this account. | [optional] 
**EndMarket** | **string** | The end market for this account, not longer than 100 characters. | [optional] 
**PhoneNumber** | **string** | The phone number of a representative of the company, not longer than 100 characters. | [optional] 
**Email** | **string** | The company email address for this account, not longer than 254 characters. Required for commercial accounts only. | [optional] 
**Aliases** | **List&lt;string&gt;** | An array of aliases, not more than 10. An alias is not shorter than 8 and not longer than 100 characters. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

