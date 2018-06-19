# Mbed Cloud SDK for .NET

[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://spdx.org/licenses/Apache-2.0.html)
[![CircleCI](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet.svg?style=shield&circle-token=68538baa897f82e3dcc38a48315e9ba24977b183)](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet)
[![codecov](https://codecov.io/gh/ARMmbed/mbed-cloud-sdk-dotnet/branch/master/graph/badge.svg?token=r8Bg3F9X7V)](https://codecov.io/gh/ARMmbed/mbed-cloud-sdk-dotnet)

The Mbed Cloud SDK gives developers access to the full Mbed suite using .NET Core 2.0.

If you want to contribute to creating a SDK for another language the work is
greatly appreciated and you can read more about the process
[here](https://github.com/ARMmbed/mbed-cloud-sdk-codegen/blob/master/docs/create-new-language.md).

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

The following sample lists the first five devices in your Device Directory.

```csharp
namespace demo
{
    using System;
    using System.Linq;
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Connect.Api;

    class Program
    {
        static void Main(string[] args)
        {
            // create new configuration object. When autostartNotifications is true, you don't need to open a notification channel manually
            var config = new Config(apiKey: "<your api key>", autostartNotifications: true);
            var connect = new ConnectApi(config);

            // lists the first 50 connectedDevices
            var connectedDevices = connect.ListConnectedDevices();

            // get the first connected device
            var val = connectedDevices.FirstOrDefault()
                                        // list the resources
                                        ?.ListResources()
                                        // get the first resource that matches the path /3201/0/5853
                                        ?.FirstOrDefault(d => d.Path == "/3201/0/5853")
                                        // get the value of the resource
                                        ?.GetResourceValue();

            Console.WriteLine(val);
        }
    }
}
```

Further examples can be found in the [Examples](Examples) folder of this repository.

## Documentation

See full [documentation and API reference here](https://cloud.mbed.com/docs/latest/mbed-cloud-sdk-dotnet/index.html).

## Contributing

Mbed Cloud SDK for .NET is open source and we would like your help; there is a
brief guide on how to get started in [CONTRIBUTING.md](CONTRIBUTING.md).

## Licence

Mbed Cloud SDK for .NET is free-to-use and licensed under the **Apache License 2.0**.
Please see [LICENSE](LICENSE) file for more information.
