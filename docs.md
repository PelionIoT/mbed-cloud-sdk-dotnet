# Mbed Cloud SDK for .NET

The Mbed Cloud SDK gives developers access to the full Mbed suite using .NET Core 2.0.

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

4. To use the SDK you'll need an Api Key, which you can get from the [Mbed Cloud Portal](https://portal.mbedcloud.com/).

## Example Usage

The following sample lists the first five devices in your Device Directory.

\code{.cs}
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
            var connectedDevices = connect.ListConnectedDevices().Data;

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
\endcode

Further examples can be found in the [Examples](https://github.com/ARMmbed/mbed-cloud-sdk-dotnet/tree/master/Examples) folder of the GitHub repository.

## Contributing

Mbed Cloud SDK for .NET is open source and we would like your help; there is a
brief guide on how to get started in [CONTRIBUTING](https://github.com/ARMmbed/mbed-cloud-sdk-dotnet/blob/master/CONTRIBUTING.md/).

## Licence

Mbed Cloud SDK for .NET is free-to-use and licensed under the **Apache License 2.0**.
Please See [LICENSE](https://github.com/ARMmbed/mbed-cloud-sdk-dotnet/blob/master/LICENSE) file for more information.
