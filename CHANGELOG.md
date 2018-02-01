# Changelog

## 1.2.4

## Deliverables

The application is hosted on Nuget at https://www.nuget.org/packages/Mbed.Cloud.SDK and can be installed using the dotnet cli:

```
$ dotnet add package Mbed.Cloud.SDK --version 1.2.4
```

### Changes

- Upgraded project to .NET Core 2.0!
- Passing 50 new integration tests
- Various bug fixes 

### Known Issues

- Testing shows that `get_resource_value` will fail
when the cloud service returns a value directly, rather than
through an open notification channel. This affects all previous versions.
- The only known workaround at present is to ensure the cloud cache is not used by:
- Waiting between calls to get_resource_value
- Reducing [the configured TTL](https://cloud.mbed.com/docs/latest/collecting/handle-resources.html#working-with-the-server-cache) on the cloud client image on the device

## 1.2.3

### Deliverables

The application is hosted on Nuget at https://www.nuget.org/packages/Mbed.Cloud.SDK and can be installed using nuget:

```
$ nuget install Mbed.Cloud.SDK
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
