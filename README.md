# Pelion Device Management SDK for .NET

[![No Maintenance Intended](http://unmaintained.tech/badge.svg)](http://unmaintained.tech/)

----
> Due to a redirected focus onto future development of the Pelion Device Management APIs, this SDK Is no longer actively supported and there is no commitment for future maintenance releases.
>
> The open source project and corresponding packages for this SDK remain publicly available. 
>
>Existing applications developed using the SDK will continue to operate against existing Pelion Device Management REST APIs (assuming that those APIs are not subject to the deprecation process for commercial customers). New APIs supported by Pelion Device Management will only be available through the REST APIs. 
>
>It is recommended that for ongoing development, applications which previously used the SDK should be migrated over time to access the Pelion Device Management REST APIs directly. 
>
>Please see this [page](https://www.pelion.com/docs/device-management/current/mbed-cloud-sdk-references/moving-from-the-pelion-device-management-sdks-to-the-apis.html), which provides additional information on using the REST APIs. By following this guide, you will learn how to build a web application using the REST APIs directly.

----

[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://spdx.org/licenses/Apache-2.0.html)
[![CircleCI](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet.svg?style=shield&circle-token=68538baa897f82e3dcc38a48315e9ba24977b183)](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet)
[![Build status](https://ci.appveyor.com/api/projects/status/3u5i6c52i7d2d6e8?svg=true)](https://ci.appveyor.com/project/alexl0gan/mbed-cloud-sdk-dotnet)
[![codecov](https://codecov.io/gh/ARMmbed/mbed-cloud-sdk-dotnet/branch/master/graph/badge.svg?token=r8Bg3F9X7V)](https://codecov.io/gh/ARMmbed/mbed-cloud-sdk-dotnet)

The Pelion Device Management SDK gives developers access to the full Pelion Device Management suite using .NET Standard 2.0.

## Installation

1. Download the .NET Core SDK from [here](https://www.microsoft.com/net/download). There are installers for Windows, Linux and Mac.
2. Create a new console application

```
dotnet new console -o myApp
cd myApp
```

3. Install the MbedCloudSDK in your project

```
dotnet add package Mbed.Cloud.SDK
dotnet build
```

4. To use the SDK you'll need an Api Key, which you can get from the [Pelion Device Management Portal](https://portal.mbedcloud.com/).

## Example Usage

The following sample lists the first ten devices in your Device Directory.

```csharp
using System;
using Mbed.Cloud;
using Mbed.Cloud.Foundation;

public class HelloWorldSeparateSdk
{
    public static void Main()
    {
        // Create an instance of the Pelion Device Management SDK
        var sdk = new SDK();

        var options = new DeviceListOptions
        {
            MaxResults = 10     // Limit to ten devices
        };

        // List the first ten devices on your Pelion Device Management account
        foreach (var device in sdk.Foundation().DeviceRepository().List(options))
        {
            Console.WriteLine("Hello device " + device.Name);
        }
    }
}
```

## Documentation

See full [documentation and API reference here](https://cloud.mbed.com/docs/latest/mbed-cloud-sdk-dotnet/index.html).

## Contributing

Pelion Device Management SDK for .NET is open source and we would like your help; there is a
brief guide on how to get started in [CONTRIBUTING.md](CONTRIBUTING.md).

## Licence

Pelion Device Management Cloud SDK for .NET is free-to-use and licensed under the **Apache License 2.0**.
Please see [LICENSE](LICENSE) file for more information.
