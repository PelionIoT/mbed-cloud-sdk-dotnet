# Changelog

The application is hosted on Nuget at https://www.nuget.org/packages/Mbed.Cloud.SDK and can be installed using the dotnet cli:

```
$ dotnet add package Mbed.Cloud.SDK
```

This news file contains a log of notable changes to the SDK. Please see [nuget history for mbed-cloud-sdk](https://www.nuget.org/packages/Mbed.Cloud.SDK/) for 
a list of versions that have been released.

[//]: # (begin_release_notes)

2.0.0 (2018-08-06)
==================

### Features

- circle 2 (#1111)

- Configuration can now be set using a .env file (#927)


1.2.12 (2018-07-06)
===================

### Features

- Add support for billing endpoints GetReportOverview, GetServicePackages,
  GetQuotaHistory and GetQuotaRemaining. (#1210)
  
### Bugfixes

- ApiClient no longer double serializes a string. (#gh-192)

1.2.11 (2018-06-26)
===================

### Features

- Remove 'CustomProperties' from Account and User. (#1362)

- Support List Pre Shared Keys endpoint. (#631)

1.2.10 (2018-06-01)
=============

### Features

- PaginatedResponse objects used in API list endpoints now takes `MaxResults`
  and `PageSize` to remove the ambiguity of the `limit` parameter. Data
  property in PaginatedResponse has been removed. Please use the iterator
  instead. (#1296)

### Bug Fixes

- Generate TPIP report as part of build. (#1014)

- Update online documentation and fix links to GitHub. (#1097)

- When creating subsequent observers, the SDK nolonger resets subscriptions for all observers. (#1284)

- Remove old value from mfaStatues enum. (#918)

1.2.9 (2018-05-22)
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


1.2.8 (2018-04-13)
=============

### Features

- Add ability to subscribe to devicve events using the Subscribe interface. See
  Examples folder for usage. (#722)


1.2.7 (2018-04-06)
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
