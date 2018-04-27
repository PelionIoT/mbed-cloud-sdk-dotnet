# Mbed Cloud SDK for .Net

The Mbed Cloud SDK gives developers access to the full Mbed suite using .NET Core 2.0.

If you want to contribute to creating a SDK for another language the work is
greatly appreciated and you can read more about the process
[here](https://github.com/ARMmbed/mbed-cloud-sdk-codegen/blob/master/docs/create-new-language.md).

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
    using MbedCloudSDK.Common;
    using MbedCloudSDK.Common.Query;
    using MbedCloudSDK.DeviceDirectory.Api;

    var apiKey = "<your Mbed Cloud api key>";
    // create a config object with your api key
    var config = new Config(apiKey);
    // Instantiate the Device Directory Api
    var deviceApi = new DeviceDirectoryApi(config);

    // Options for the query. The Limit defines the number of results returned
    var options = new QueryOptions()
    {
        Limit = 5,
    };

    // List devices from the Device Directory
    var devices = deviceApi.ListDevices(options).Data;
    foreach (var device in devices)
    {
        // Use the device object here
    }
    \endcode

Further examples can be viewed in the Examples/ConsoleExamples folder of this repo.

## Documentation

See full [documentation and API reference here](https://cloud.mbed.com/docs/v1.2/mbed-cloud-sdk-dotnet/index.html).

## Contributing

Mbed Cloud SDK for .Net is open source and we would like your help; there is a
brief guide on how to get started in [CONTRIBUTING.md](CONTRIBUTING.md).

## Licence

Mbed Cloud SDK for .Net is free-to-use and licensed under the **Apache License
2.0**. See [LICENSE](https://github.com/ARMmbed/mbed-cloud-sdk-dotnet-private/blob/master/LICENSE) file for more information.
