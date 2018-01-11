# Mbed Cloud SDK for .Net

[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://spdx.org/licenses/Apache-2.0.html)
[![CircleCI](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet.svg?style=shield&circle-token=68538baa897f82e3dcc38a48315e9ba24977b183)](https://circleci.com/gh/ARMmbed/mbed-cloud-sdk-dotnet)
[![codecov](https://codecov.io/gh/ARMmbed/mbed-cloud-sdk-dotnet/branch/master/graph/badge.svg?token=r8Bg3F9X7V)](https://codecov.io/gh/ARMmbed/mbed-cloud-sdk-dotnet)

The Mbed Cloud SDK gives developers access to the full Mbed suite using .Net 4.61.

If you want to contribute to creating a SDK for another language the work is
greatly appreciated and you can read more about the process
[here](https://github.com/ARMmbed/mbed-cloud-sdk-codegen/blob/master/docs/create-new-language.md).

## Installation (Windows - Visual Studio)

1. Install Visual Studio Community 2017 from [here](https://www.visualstudio.com/).
2. Open Visual Studio and create a new project.
3. Go to Visual C# -> Windows Classic Desktop and create a new Console App. Make sure the target framework is set to .Net Framework 4.6.1.
4. Go to Tools -> NuGet Package Manager and select the package manager console.
5. Run the following command to install the package.

```
PM> Install-Package Mbed.Cloud.SDK
```

## Installation (Mac - Visual Studio Community)

1. Install Visual Studio Community 2017 from [here](https://www.visualstudio.com/).
2. Open Visual Studio and create a new solution.
3. From the list of templates, select other -> .Net and create a new Console Application (or anything that supports .Net 4.61).
4. Go to project -> Add NuGet Packages.
5. Search for Mbed.Cloud.SDK and install the package.

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
