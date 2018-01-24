# update_service.Model.CampaignDeviceMetadataPage
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**After** | **string** | The entity ID to fetch after the given one | [optional] 
**HasMore** | **bool?** | Flag indicating whether there are more results | [optional] 
**TotalCount** | **int?** | The total number or records, if requested. It might be returned also for small lists. | [optional] 
**_Object** | **string** | Entity name: always &#39;list&#39; | [optional] 
**Limit** | **int?** | The number of results to return, (range: 2-1000), or equals to total_count | [optional] 
**Data** | [**List&lt;CampaignDeviceMetadata&gt;**](CampaignDeviceMetadata.md) | A list of entities | [optional] 
**Order** | **string** | The order of the records to return. Acceptable values: ASC, DESC. Default: ASC | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

