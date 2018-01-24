# iam.Model.AccountInfo
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EndMarket** | **string** | Account end market. | 
**Status** | **string** | The status of the account. | 
**PasswordPolicy** | [**PasswordPolicy**](PasswordPolicy.md) | The password policy for this account. | [optional] 
**PostalCode** | **string** | The postal code part of the postal address. | [optional] 
**Id** | **string** | Account ID. | 
**Aliases** | **List&lt;string&gt;** | An array of aliases. | 
**AddressLine2** | **string** | Postal address line 2. | [optional] 
**City** | **string** | The city part of the postal address. | [optional] 
**AddressLine1** | **string** | Postal address line 1. | [optional] 
**DisplayName** | **string** | The display name for the account. | [optional] 
**ParentId** | **string** | The ID of the parent account, if it has any. | [optional] 
**State** | **string** | The state part of the postal address. | [optional] 
**Etag** | **string** | API resource entity version. | 
**IsProvisioningAllowed** | **bool?** | Flag (true/false) indicating whether Factory Tool is allowed to download or not. | 
**Email** | **string** | The company email address for this account. | [optional] 
**PhoneNumber** | **string** | The phone number of a representative of the company. | [optional] 
**Company** | **string** | The name of the company. | [optional] 
**_Object** | **string** | Entity name: always &#39;account&#39; | 
**Reason** | **string** | A reason note for updating the status of the account | [optional] 
**UpgradedAt** | **DateTime?** | Time when upgraded to commercial account in UTC format RFC3339. | [optional] 
**Tier** | **string** | The tier level of the account; &#39;0&#39;: free tier, &#39;1&#39;: commercial account, &#39;2&#39;: partner tier. Other values are reserved for the future. | 
**SubAccounts** | [**List&lt;AccountInfo&gt;**](AccountInfo.md) | List of sub accounts. | [optional] 
**Limits** | **Dictionary&lt;string, string&gt;** | List of limits as key-value pairs if requested. | [optional] 
**Country** | **string** | The country part of the postal address. | [optional] 
**CreatedAt** | **DateTime?** | Creation UTC time RFC3339. | [optional] 
**IdleTimeout** | **string** | The reference token expiration time in minutes for this account. | [optional] 
**Contact** | **string** | The name of the contact person for this account. | [optional] 
**Policies** | [**List&lt;FeaturePolicy&gt;**](FeaturePolicy.md) | List of policies if requested. | [optional] 
**TemplateId** | **string** | Account template ID. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

