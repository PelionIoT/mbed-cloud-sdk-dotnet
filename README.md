# Mbed Cloud SDK for .Net

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

### Switch mac project to Visual Studio Code

If Visual Studio for Mac is not to your liking, then you can open the project you just created in Visual Studio Code. To run your project you need to:

1. Make sure you have the latest version of Mono installed

```
$ Mono -v
```
2. Download the latest version of NuGet from [here](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe).
3. Download Visual Studio Code from [here](https://code.visualstudio.com/?wt.mc_id=DX_841432).
4. Open the root of the project in VSCode.
5. Install the Mono Debug extension from the extensions tab.
6. Create a .vscode directory at the root of the project and create a launch.json file.
7. In your launch.json, insert the following:

```
{
    "version": "0.2.0",
    "configurations": [
        {
            "name": "Launch",
            "type": "mono",
            "request": "launch",
            "program": "${workspaceRoot}/Path/To/Your/.exe",
            "cwd": "${workspaceRoot}",
            "args": ["any cmd arguments"]
        },
        {
            "name": "Attach",
            "type": "mono",
            "request": "attach",
            "address": "localhost",
            "port": 5000
        }
    ]
}
```
8. Now create a tasks.json file and insert the following 

```
{
    "version": "2.0.0",
    "tasks": [
        {
            "taskName": "build",
            "type": "process",
            "command": "msbuild",
            "args": [
                "/property:GenerateFullPaths=true",
                "/t:build"
            ],
            "group": "build",
            "presentation": {
                "reveal": "silent"
            },
            "problemMatcher": "$msCompile"
        },
    ]
}
```

9. Now pressing Cmd + Shift + B should run the build task. Verify that it was successful by checking the output in the integrated terminal. 

10. To build from the command line, use msbuild in the root of the project

```
$ msbuild
```

11. After a build has been sucessful, press f5 to lauch debugging, or Shift + f5 to start without debugging. Any output should appear in the debug console tab of the integrated terminal. 

12. Simple! For more information on VSCode tasks, got to the [docs](https://code.visualstudio.com/docs/editor/tasks).

## Example Usage

1. Create API key in the [Mbed Cloud Portal](https://portal.mbedcloud.com/).
2. In your project, follow the sample below.

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

Further examples can be viewed in the Examples folder of this repo.

## Documentation

See full [documentation and API reference here](https://s3-us-west-2.amazonaws.com/mbed-cloud-sdk-dotnet-dist/latest/docs/index.html).
