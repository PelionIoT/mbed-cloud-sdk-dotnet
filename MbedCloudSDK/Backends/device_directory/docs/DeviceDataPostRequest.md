# device_directory.Model.DeviceDataPostRequest
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BootstrapExpirationDate** | **DateTime?** | The expiration date of the certificate used to connect to bootstrap server. | [optional] 
**BootstrappedTimestamp** | **DateTime?** | The timestamp of the device&#39;s most recent bootstrap process. | [optional] 
**ConnectorExpirationDate** | **DateTime?** | The expiration date of the certificate used to connect to the LWM2M server. | [optional] 
**Mechanism** | **string** | The ID of the channel used to communicate with the device. | [optional] 
**DeviceClass** | **string** | An ID representing the model and hardware revision of the device. | [optional] 
**EndpointName** | **string** | The endpoint name given to the device. | [optional] 
**AutoUpdate** | **bool?** | DEPRECATED: Mark this device for automatic firmware update. | [optional] 
**HostGateway** | **string** | The &#x60;endpoint_name&#x60; of the host gateway, if appropriate. | [optional] 
**DeviceExecutionMode** | **int?** | The execution mode from the certificate of the device. Permitted values:   - 0 - unspecified execution mode (default)   - 1 - development devices   - 5 - production devices | [optional] 
**CustomAttributes** | **Dictionary&lt;string, string&gt;** | Up to five custom key-value attributes. Note that keys cannot start with a number. | [optional] 
**State** | **string** | The current state of the device. | [optional] 
**SerialNumber** | **string** | The serial number of the device. | [optional] 
**FirmwareChecksum** | **string** | The SHA256 checksum of the current firmware image. | [optional] 
**_Object** | **string** | The API resource entity. | [optional] 
**Description** | **string** | The description of the device. | [optional] 
**VendorId** | **string** | The device vendor ID. | [optional] 
**EndpointType** | **string** | The endpoint type of the device. For example, the device is a gateway. | [optional] 
**Deployment** | **string** | DEPRECATED: The last deployment used on the device. | [optional] 
**MechanismUrl** | **string** | The address of the connector to use. | [optional] 
**Name** | **string** | The name of the device. | [optional] 
**DeviceKey** | **string** | The fingerprint of the device certificate. | [optional] 
**EnrolmentListTimestamp** | **DateTime?** | The claim date/time. | [optional] 
**Manifest** | **string** | DEPRECATED: The URL for the current device manifest. | [optional] 
**CaId** | **string** | The certificate issuer&#39;s ID. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

