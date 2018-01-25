# Mbed Cloud SDK for .Net

[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://spdx.org/licenses/Apache-2.0.html)
[![CircleCI](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet.svg?style=shield&circle-token=68538baa897f82e3dcc38a48315e9ba24977b183)](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet)
[![codecov](https://codecov.io/gh/ARMmbed/mbed-cloud-sdk-dotnet/branch/master/graph/badge.svg?token=r8Bg3F9X7V)](https://codecov.io/gh/ARMmbed/mbed-cloud-sdk-dotnet)

The Mbed Cloud SDK gives developers access to the full Mbed suite using .NET Core 2.0.

If you want to contribute to creating a SDK for another language the work is
greatly appreciated and you can read more about the process
[here](https://github.com/ARMmbed/mbed-cloud-sdk-codegen/blob/master/docs/create-new-language.md).

## Installation

1. Download the .NET Core SDK from [here](https://www.microsoft.com/net/download). There are installers for Windows, Linux and Mac.
2. In your project, run

```
dotnet add package Mbed.Cloud.SDK
```

## Example Usage

1. Create API key in the [Mbed Cloud Portal](https://portal.mbedcloud.com/).
2. In your project, follow the sample below:

    ```csharp
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
    ```

Further examples can be viewed in the ConsoleExamples folder of this repo.

## Documentation

See full [documentation and API reference here](https://cloud.mbed.com/docs/v1.2/mbed-cloud-sdk-dotnet/index.html).

## Contributing

Mbed Cloud SDK for .Net is open source and we would like your help; there is a
brief guide on how to get started in [CONTRIBUTING.md](CONTRIBUTING.md).

## Licence

Mbed Cloud SDK for .Net is free-to-use and licensed under the **Apache License
2.0**. See [LICENSE](LICENSE) file for more information.
