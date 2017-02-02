# .Net mbed Cloud SDK

[![CircleCI](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet.svg?style=shield&circle-token=68538baa897f82e3dcc38a48315e9ba24977b183)](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet)

The mbed Cloud SDK gives developers access to the full mbed suite using .Net 4.5.

If you want to contribute to creating a SDK for another language the work is
greatly appreciated and you can read more about the process
[here](https://github.com/ARMmbed/mbed-cloud-sdk-codegen/blob/master/docs/create-new-language.md).

## Installation

1. Download mbedCloudSDK library dll from [here](https://github.com/ARMmbed/mbed-cloud-sdk-dotnet/releases/tag/v1.1.0.0).
2. Download Newtonsoft.Json from [here](http://www.newtonsoft.com/json) or install it with NuGet : `Install-Package Newtonsoft.Json`
3. Download RestSharp from [here](https://github.com/restsharp/RestSharp/downloads) or install it with NuGet : `Install-Package RestSharp`
4. Reference downloaded dlls in your project.

## Usage

1. Create API key in the [mbed Cloud Portal](https://portal.mbedcloud.com/).
2. Create config object:

```csharp
using mbedCloudSDK.Common;

Config config = new Config(apiKey);
config.Host = "https://api.mbedcloud.com";
```
3. Import api and you are ready to go.

```csharp
using mbedCloudSDK.Common;
using mbedCloudSDK.Common.Query;
using mbedCloudSDK.Devices.Api;
using System;

DevicesApi devices = new DevicesApi(config);
DeviceQueryOptions options = new DeviceQueryOptions();
options.Limit = 10;
foreach (var device in devices.ListDevices(options))
{
    Console.WriteLine(device.ToString());
}
```

## Documentation

See full [documentation and API reference here](https://s3-us-west-2.amazonaws.com/mbed-cloud-sdk-dotnet/index.html).
