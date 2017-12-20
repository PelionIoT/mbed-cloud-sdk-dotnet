# Changelog

## 1.2.3

### Deliverables

The application is primarily hosted on pypi at https://pypi.org/project/mbed-cloud-sdk and can be installed using pip:

```
$ pip install mbed-cloud-sdk
```

### Changes

- Added webhook notification handler
- Added callbacks to resource subscriptions
- Various bugfixes

### Known Issues

- Testing shows that `get_resource_value` will fail
when the cloud service returns a value directly, rather than
through an open notification channel. This affects all previous versions.
- The only known workaround at present is to ensure the cloud cache is not used by:
- Waiting between calls to get_resource_value
- Reducing [the configured TTL](https://cloud.mbed.com/docs/latest/collecting/handle-resources.html#working-with-the-server-cache) on the cloud client image on the device

## 1.2.2

### Deliverables

The application is hosted on GitHub at https://github.com/ARMmbed/mbed-cloud-sdk-dotnet and can be installed using nuget:

```
$ nuget install Mbed.Cloud.SDK
```

### Changes

- Initial release tracking Mbed Cloud 1.2 APIs
- APIs supported:
  - Account Management
  - Certificates
  - Connect
  - Device Diectory
  - Update
- Environments supported:
  - .Net 4.61
