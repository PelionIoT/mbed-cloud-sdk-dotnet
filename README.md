# Mbed Cloud SDK for .NET

[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://spdx.org/licenses/Apache-2.0.html)
[![CircleCI](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet.svg?style=shield&circle-token=68538baa897f82e3dcc38a48315e9ba24977b183)](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet)
[![Build status](https://ci.appveyor.com/api/projects/status/3u5i6c52i7d2d6e8?svg=true)](https://ci.appveyor.com/project/alexl0gan/mbed-cloud-sdk-dotnet)
[![codecov](https://codecov.io/gh/ARMmbed/mbed-cloud-sdk-dotnet/branch/master/graph/badge.svg?token=r8Bg3F9X7V)](https://codecov.io/gh/ARMmbed/mbed-cloud-sdk-dotnet)

The Mbed Cloud SDK gives developers access to the full Mbed suite using .NET Standard 2.0.

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

4. To use the SDK you'll need an Api Key, which you can get from the [Mbed Cloud Portal](https://portal.mbedcloud.com/).

## Example Usage

The following sample lists the first ten devices in your Device Directory.

```csharp
using System;
using Mbed.Cloud;
using Mbed.Cloud.Foundation;

public class HelloWorldSeparateSdk
{
    public void Main()
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

Mbed Cloud SDK for .NET is open source and we would like your help; there is a
brief guide on how to get started in [CONTRIBUTING.md](CONTRIBUTING.md).

## Licence

Mbed Cloud SDK for .NET is free-to-use and licensed under the **Apache License 2.0**.
Please see [LICENSE](LICENSE) file for more information.
