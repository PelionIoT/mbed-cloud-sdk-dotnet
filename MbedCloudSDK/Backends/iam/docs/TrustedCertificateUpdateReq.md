# iam.Model.TrustedCertificateUpdateReq
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Status** | **string** | Status of the certificate. | [optional] 
**Certificate** | **string** | X509.v3 trusted certificate in PEM format. | [optional] 
**Name** | **string** | Certificate name, not longer than 100 characters. | [optional] 
**Service** | **string** | Service name where the certificate must be used. | [optional] 
**Signature** | **string** | Base64 encoded signature of the account ID signed by the certificate whose data to be updated. Signature must be hashed with SHA256. | [optional] 
**Description** | **string** | Human readable description of this certificate, not longer than 500 characters. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

