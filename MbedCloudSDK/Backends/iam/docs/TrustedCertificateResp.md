# iam.Model.TrustedCertificateResp
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Service** | **string** | Service name where the certificate is to be used. | 
**Status** | **string** | Status of the certificate. | [optional] 
**Description** | **string** | Human readable description of this certificate. | [optional] 
**Certificate** | **string** | X509.v3 trusted certificate in PEM format. | 
**Issuer** | **string** | Issuer of the certificate. | 
**DeviceExecutionMode** | **int?** | Device execution mode where 1 means a developer certificate. | [optional] 
**CreatedAt** | **DateTime?** | Creation UTC time RFC3339. | [optional] 
**_Object** | **string** | Entity name: always &#39;trusted-cert&#39; | 
**Subject** | **string** | Subject of the certificate. | 
**AccountId** | **string** | The UUID of the account. | 
**Etag** | **string** | API resource entity version. | 
**Validity** | **DateTime?** | Expiration time in UTC formatted as RFC3339. | 
**OwnerId** | **string** | The UUID of the owner. | [optional] 
**Id** | **string** | Entity ID. | 
**Name** | **string** | Certificate name. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

