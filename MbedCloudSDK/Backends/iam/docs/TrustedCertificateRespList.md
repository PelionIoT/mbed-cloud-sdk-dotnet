# iam.Model.TrustedCertificateRespList
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**After** | **string** | The entity ID to fetch after the given one. | [optional] 
**HasMore** | **bool?** | Flag indicating whether there is more results. | 
**TotalCount** | **int?** | The total number or records, if requested. It might be returned also for small lists. | 
**_Object** | **string** | Entity name: always &#39;list&#39; | 
**Limit** | **int?** | The number of results to return, (range: 2-1000), or equals to &#x60;total_count&#x60; | 
**Data** | [**List&lt;TrustedCertificateResp&gt;**](TrustedCertificateResp.md) | A list of entities. | 
**Order** | **string** | The order of the records to return based on creation time. Available values: ASC, DESC; by default ASC. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

