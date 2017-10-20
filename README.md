# Mbed Cloud SDK for .Net

[![CircleCI](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet.svg?style=shield&circle-token=68538baa897f82e3dcc38a48315e9ba24977b183)](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet)

The Mbed Cloud SDK gives developers access to the full Mbed suite using .Net 4.61.

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

var config = new Config(apiKey, "https://api.us-east-1.mbedcloud.com");
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

## Documentation

See full [documentation and API reference here](https://s3-us-west-2.amazonaws.com/mbed-cloud-sdk-dotnet-dist/latest/docs/index.html).
