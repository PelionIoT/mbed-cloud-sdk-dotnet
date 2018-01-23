# mds.Model.EndpointData
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Q** | **bool?** | Queue mode (default value is false). | [optional] 
**Ept** | **string** | Endpoint type. | [optional] 
**OriginalEp** | **string** | In case of a self-provided endpoint name that is used to initiate the device registration, Mbed Cloud provides a new Device ID to be used from that point on. The new Mbed-Cloud-provided Device ID is forwarded as the &#39;ep&#39; property and the original self-provided one as the optional &#39;original-ep&#39; property in a registration notification. The name and ID can then be mapped accordingly. Mbed Cloud saves the original endpoint name in Device Directory for future device registrations so there is no need to do the mapping again.   | [optional] 
**Resources** | [**List&lt;ResourcesData&gt;**](ResourcesData.md) |  | [optional] 
**Ep** | **string** | Unique Mbed Cloud Device ID. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

