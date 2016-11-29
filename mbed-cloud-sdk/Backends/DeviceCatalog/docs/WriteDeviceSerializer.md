# device_catalog.Model.WriteDeviceSerializer
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**VendorId** | **string** | The device vendor ID | [optional] 
**_Object** | **string** | The API resource entity | [optional] 
**Description** | **string** | The description of the object | [optional] 
**DeployedState** | **string** | The state of the device&#39;s deployment | [optional] 
**AutoUpdate** | **bool?** | Mark this device for auto firmware update | [optional] 
**Name** | **string** | The name of the object | [optional] 
**DeviceClass** | **string** | The device class | [optional] 
**CustomAttributes** | **string** | Up to 5 custom JSON attributes | [optional] 
**Manifest** | **string** | URL for the current device manifest | [optional] 
**TrustClass** | **long?** | The device trust class | [optional] 
**ProvisionKey** | **string** | The key used to provision the device | 
**State** | **string** | The current state of the device | [optional] 
**Mechanism** | **string** | The ID of the channel used to communicate with the device | 
**Deployment** | **string** | The last deployment used on the device | [optional] 
**MechanismUrl** | **string** | The address of the connector to use | [optional] 
**SerialNumber** | **string** | The serial number of the device | [optional] 
**DeviceId** | **string** | DEPRECATED: The ID of the device | [optional] 
**TrustLevel** | **long?** | The device trust level | [optional] 
**AccountId** | **string** | The owning IAM account ID | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

