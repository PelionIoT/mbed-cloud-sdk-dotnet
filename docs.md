# Pelion Device Management SDK for .NET

The Pelion Device Management SDK gives developers access to the full Pelion Device Management suite using .NET Core 2.0.

If you want to contribute to creating a SDK for another language the work is
greatly appreciated and you can read more about the process
[here](https://github.com/ARMmbed/mbed-cloud-sdk-codegen/blob/master/docs/create-new-language.md/).

## Installation

1. Download the .NET Core SDK from [here](https://www.microsoft.com/net/download). There are installers for Windows, Linux and Mac.
2. Create a new console application

\code{.sh}
dotnet new console -o myApp
cd myApp
\endcode

3. Install the MbedCloudSDK in your project

\code{.sh}
dotnet add package Mbed.Cloud.SDK
dotnet build
\endcode

4. To use the SDK you'll need an Api Key, which you can get from the [Pelion Device Management Portal](https://portal.mbedcloud.com/).

## Example Usage

The following sample lists the first ten devices in your Device Directory.

\code{.cs}
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
\endcode

## Contributing

Pelion Device Management SDK for .NET is open source and we would like your help; there is a
brief guide on how to get started in [CONTRIBUTING](https://github.com/ARMmbed/mbed-cloud-sdk-dotnet/blob/master/CONTRIBUTING.md/).

## Licence

Pelion Device Management SDK for .NET is free-to-use and licensed under the **Apache License 2.0**.
Please See [LICENSE](https://github.com/ARMmbed/mbed-cloud-sdk-dotnet/blob/master/LICENSE) file for more information.
