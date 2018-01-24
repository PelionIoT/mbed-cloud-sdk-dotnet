# connector_ca.Model.DeveloperCertificateResponseData
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**SecurityFileContent** | **string** | The content of the &#x60;security.c&#x60; file that is flashed into the device to provide the security credentials | [optional] 
**Description** | **string** | Description for the developer certificate. | [optional] 
**Name** | **string** | The name of the developer certificate. | [optional] 
**DeveloperCertificate** | **string** | The PEM format X.509 developer certificate. | [optional] 
**ServerUri** | **string** | The URI to which the client needs to connect to. | [optional] 
**CreatedAt** | **string** | Creation UTC time RFC3339. | [optional] 
**_Object** | **string** | Entity name, always &#x60;trusted-cert&#x60;. | [optional] 
**DeveloperPrivateKey** | **string** | The PEM format developer private key associated to the certificate. | [optional] 
**ServerCertificate** | **string** | The PEM format X.509 server certificate that is used to validate the server certificate that is received during the TLS/DTLS handshake. | [optional] 
**Etag** | **string** | API resource entity version. | [optional] 
**Id** | **string** | The mUUID that uniquely identifies the developer certificate. | [optional] 
**AccountId** | **string** | The account to which the developer certificate belongs. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

