 (2018-05-22)
=============

### Features

- PaginatedResponse objects used in API list endpoints now takes `MaxResults`
  and `PageSize` to remove the ambiguity of the `limit` parameter. (#1296)


# Changelog

The application is hosted on Nuget at https://www.nuget.org/packages/Mbed.Cloud.SDK and can be installed using the dotnet cli:

```
$ dotnet add package Mbed.Cloud.SDK
```

This news file contains a log of notable changes to the SDK. Please see [nuget history for mbed-cloud-sdk](https://www.nuget.org/packages/Mbed.Cloud.SDK/) for 
a list of versions that have been released.

[//]: # (begin_release_notes)

 (2018-05-22)
=============

### Features

- Add device bootstrap API. This provides the ability to set Pre-Shared Keys
  for device bring-up. (#1075, #1099)

- Added resource values to subscribe module. See examples folder for usage.
  (#1101)

- New API updates for IAM. (#1225)

- New API updates for MDS. (#1235)

- Manifest upload supports upload of keytable file (#522)

### Improved Documentation

- Add security recommendations to PSK documentation. (#742)


(2018-04-13)
=============

### Features

- Add ability to subscribe to devicve events using the Subscribe interface. See
  Examples folder for usage. (#722)


(2018-04-06)
=============

### Features

- The HTTP header User-Agent is now configured by to contain SDK version
  information, which is passed to the Mbed Cloud. (#634)

- Add ability to subscribe to devicve events using the Subscribe interface. See
  Examples folder for usage. (#722)

# Older Releases:

## 1.2.6

## Deliverables

The application is hosted on Nuget at https://www.nuget.org/packages/Mbed.Cloud.SDK and can be installed using the dotnet cli:

```
$ dotnet add package Mbed.Cloud.SDK --version 1.2.6
```

## Changes

Support Connector Enrollment Service API in SDK
Features supported

- Upload a DeviceId to claim
- View status of claimed devices

### Update

- Uploaded images now have the correct filename on the server

### AccountManagement

- Add new fields to Account 
    - ContractNumber
    - CustomerNumber
    - ExpiryWarning
    - MultifactorAuthenticationStatus
    - NotificationEmails
    - ReferenceNote
    - UpdatedAt
    - CustomProperties
    - SalesContactEmail

- remove following fields from Group
    - LastUpdateTime
    - CreationTime

- Add following fields to Group
    - UpdatedAt

- Add following fields to User
    - CustomProperties

- Following fields on User can be UpdatedAt
    - Password,
    - CustomProperties
    - TwoFactorAuthentication
    - Status
    - Groups

### Certificates

- Add EnrollmentMode field

### ConnectApi

- DeleteSubscriptions now deletes subscribtions by iterating over connected devices.
- Use a different backend api in GetResourceValue to fix the issue with getting a value from cache.

### All modules

- All get and delete methods now return null if not found, instead of throwing an exception

## 1.2.5

### Changes

- Added 'ClaimedAt' field to Device
- Various other minor bug fixes

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

- New API updates for MDS. (#1235)

- Manifest upload supports upload of keytable file (#522)

### Improved Documentation

- Add security recommendations to PSK documentation. (#742)


(2018-04-13)
=============

### Features

- Add ability to subscribe to devicve events using the Subscribe interface. See
  Examples folder for usage. (#722)


(2018-04-06)
=============

### Features

- The HTTP header User-Agent is now configured by to contain SDK version
  information, which is passed to the Mbed Cloud. (#634)

- Add ability to subscribe to devicve events using the Subscribe interface. See
  Examples folder for usage. (#722)


# Changelog
 
The application is hosted on Nuget at https://www.nuget.org/packages/Mbed.Cloud.SDK and can be installed using the dotnet cli:

```
$ dotnet add package Mbed.Cloud.SDK
```
 
This news file contains a log of notable changes to the SDK. Please see [nuget history for mbed-cloud-sdk](https://www.nuget.org/packages/Mbed.Cloud.SDK/) for 
a list of versions that have been released. 
 
[//]: # (begin_release_notes) 
 
# Older Releases: 

## 1.2.6

## Deliverables

The application is hosted on Nuget at https://www.nuget.org/packages/Mbed.Cloud.SDK and can be installed using the dotnet cli:

```
$ dotnet add package Mbed.Cloud.SDK --version 1.2.6
```

## Changes

Support Connector Enrollment Service API in SDK
Features supported

- Upload a DeviceId to claim
- View status of claimed devices

### Update

- Uploaded images now have the correct filename on the server

### AccountManagement

- Add new fields to Account 
    - ContractNumber
    - CustomerNumber
    - ExpiryWarning
    - MultifactorAuthenticationStatus
    - NotificationEmails
    - ReferenceNote
    - UpdatedAt
    - CustomProperties
    - SalesContactEmail

- remove following fields from Group
    - LastUpdateTime
    - CreationTime

- Add following fields to Group
    - UpdatedAt

- Add following fields to User
    - CustomProperties

- Following fields on User can be UpdatedAt
    - Password,
    - CustomProperties
    - TwoFactorAuthentication
    - Status
    - Groups

### Certificates

- Add EnrollmentMode field

### ConnectApi

- DeleteSubscriptions now deletes subscribtions by iterating over connected devices.
- Use a different backend api in GetResourceValue to fix the issue with getting a value from cache.

### All modules

- All get and delete methods now return null if not found, instead of throwing an exception

## 1.2.5

### Changes

- Added 'ClaimedAt' field to Device
- Various other minor bug fixes

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

# Changelog

The application is hosted on Nuget at https://www.nuget.org/packages/Mbed.Cloud.SDK and can be installed using the dotnet cli:

```
$ dotnet add package Mbed.Cloud.SDK
```

This news file contains a log of notable changes to the SDK. Please see [nuget history for mbed-cloud-sdk](https://www.nuget.org/packages/Mbed.Cloud.SDK/) for 
a list of versions that have been released.

[//]: # (begin_release_notes)

 (2018-05-22)
=============
- New API updates for MDS. (#1235)

- Manifest upload supports upload of keytable file (#522)

### Improved Documentation

- Add security recommendations to PSK documentation. (#742)


(2018-04-13)
=============

### Features

- Add ability to subscribe to devicve events using the Subscribe interface. See
  Examples folder for usage. (#722)


(2018-04-06)
=============

### Features

- The HTTP header User-Agent is now configured by to contain SDK version
  information, which is passed to the Mbed Cloud. (#634)

- Add ability to subscribe to devicve events using the Subscribe interface. See
  Examples folder for usage. (#722)

# Older Releases:

## 1.2.6

## Deliverables

The application is hosted on Nuget at https://www.nuget.org/packages/Mbed.Cloud.SDK and can be installed using the dotnet cli:

```
$ dotnet add package Mbed.Cloud.SDK --version 1.2.6
```

## Changes

Support Connector Enrollment Service API in SDK
Features supported

- Upload a DeviceId to claim
- View status of claimed devices

### Update

- Uploaded images now have the correct filename on the server

### AccountManagement

- Add new fields to Account 
    - ContractNumber
    - CustomerNumber
    - ExpiryWarning
    - MultifactorAuthenticationStatus
    - NotificationEmails
    - ReferenceNote
    - UpdatedAt
    - CustomProperties
    - SalesContactEmail

- remove following fields from Group
    - LastUpdateTime
    - CreationTime

- Add following fields to Group
    - UpdatedAt

- Add following fields to User
    - CustomProperties

- Following fields on User can be UpdatedAt
    - Password,
    - CustomProperties
    - TwoFactorAuthentication
    - Status
    - Groups

### Certificates

- Add EnrollmentMode field

### ConnectApi

- DeleteSubscriptions now deletes subscribtions by iterating over connected devices.
- Use a different backend api in GetResourceValue to fix the issue with getting a value from cache.

### All modules

- All get and delete methods now return null if not found, instead of throwing an exception

## 1.2.5

### Changes

- Added 'ClaimedAt' field to Device
- Various other minor bug fixes

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
