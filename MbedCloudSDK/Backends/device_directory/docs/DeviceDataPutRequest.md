# device_directory.Model.DeviceDataPutRequest
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Description** | **string** | The description of the device. | [optional] 
**EndpointName** | **string** | The endpoint name given to the device. | [optional] 
**AutoUpdate** | **bool?** | DEPRECATED: Mark this device for automatic firmware update. | [optional] 
**HostGateway** | **string** | The &#x60;endpoint_name&#x60; of the host gateway, if appropriate. | [optional] 
**EnrolmentListTimestamp** | **DateTime?** | The claim date/time. | [optional] 
**_Object** | **string** | The API resource entity. | [optional] 
**CustomAttributes** | **Dictionary&lt;string, string&gt;** | Up to five custom key-value attributes. Note that keys cannot start with a number. | [optional] 
**DeviceKey** | **string** | The fingerprint of the device certificate. | [optional] 
**EndpointType** | **string** | The endpoint type of the device. For example, the device is a gateway. | [optional] 
**CaId** | **string** | The certificate issuer&#39;s ID. | [optional] 
**Name** | **string** | The name of the device. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

