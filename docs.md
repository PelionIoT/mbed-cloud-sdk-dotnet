# .Net mbed Cloud SDK

The mbed Cloud SDK gives developers access to the full mbed suite using .Net 4.5.

If you want to contribute to creating a SDK for another language the work is
greatly appreciated and you can read more about the process
[here](https://github.com/ARMmbed/mbed-cloud-sdk-codegen/blob/master/docs/create-new-language.md).

## Installation

The application is installed using nuget:

```
$ nuget install Mbed.Cloud.SDK
```

## Usage

1. Create API key in the [Mbed Cloud Portal](https://portal.mbedcloud.com/).
2. Create config object:

```csharp
using MbedCloudSDK.Common;

var config = new Config(apiKey, "https://api.mbedcloud.com");
```
3. Import api and you are ready to go.

```csharp
using MbedCloudSDK.Common;
using MbedCloudSDK.Common.Query;
using MbedCloudSDK.DeviceDirectory.Api;
using System;

var deviceApi = new DeviceDirectoryApi(config);
var options = new QueryOptions();
options.Limit = 10;
var devices = deviceApi.ListDevices(options);
foreach (var device in devices)
{
    Console.WriteLine(device.ToString());
}
```
