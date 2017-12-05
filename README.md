# Mbed Cloud SDK for .Net

[![CircleCI](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet.svg?style=shield&circle-token=68538baa897f82e3dcc38a48315e9ba24977b183)](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet)

[![codecov](https://codecov.io/gh/ARMmbed/mbed-cloud-sdk-dotnet/branch/master/graph/badge.svg?token=r8Bg3F9X7V)](https://codecov.io/gh/ARMmbed/mbed-cloud-sdk-dotnet)

The Mbed Cloud SDK gives developers access to the full Mbed suite using .Net 4.61.

If you want to contribute to creating a SDK for another language the work is
greatly appreciated and you can read more about the process
[here](https://github.com/ARMmbed/mbed-cloud-sdk-codegen/blob/master/docs/create-new-language.md).

## Installation (Windows)

To install in Visual Studio using the package manager console

```
PM> Install-Package Mbed.Cloud.SDK
```

To install from the command line, make sure you have Nuget installed. Instructions are [here](https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference).

```
& nuget update -self
$ nuget install Mbed.Cloud.SDK
```

## Installation (Mac)

1. Install [mono](http://www.mono-project.com/download/)
2. Install nuget using this [brew formulae](http://brewformulas.org/Nuget) 
3. Download package from Nuget

```
& nuget update -self
$ nuget install Mbed.Cloud.SDK
```

## Usage

1. Create API key in the [Mbed Cloud Portal](https://portal.mbedcloud.com/).
2. Create config object:

```csharp
using MbedCloudSDK.Common;

var config = new Config(apiKey);
```
3. Import api and instantiate with a Config object.

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
