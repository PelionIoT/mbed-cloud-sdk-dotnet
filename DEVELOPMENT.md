# Mbed Cloud SDK for .NET

## Prerequisites
* An Mbed Cloud api key

## Prerequisites (Windows)
* Visual Studio (Free community edition can be found [here](https://www.visualstudio.com/vs/))

## Prerequisites (Mac)
* Mono (Latest version can be downloaded from [here](http://www.mono-project.com/download/))
* Nuget (Executable can be found [here](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe))

## Building Examples (Windows)
1. Clone the reposotory.
2. Open the solution (.sln) file in Visual Studio.
3. Right click on solution and select `Build Solution`

## Building Examples (Mac)
1. Clone the repository.
2. At the root, run the following commands to restore the dependencies.
```
nuget restore MbedCloudSDK/packages.config -PackagesDirectory packages
nuget restore TestServer/packages.config -PackagesDirectory packages
nuget restore MbedCloudSDK.Test/packages.config -PackagesDirectory packages
nuget restore ConsoleExamples/packages.config -PackagesDirectory packages
```
3. In the root, run `msbuild` to build the project.
 
## Running Tests (Windows)
1. In the toolbar, go to `Test` then `Run all tests`.
2. The passing tests should now appear in the Test Runner Explorer
3. For some of the tests, an api key is a required parameter. This parameter is referred to as "mbed_cloud_api_key". See the NUnit documentation [here](https://github.com/nunit/docs/wiki/NUnit-Documentation) to see how to add this.

## Running Tests (Mac)
1. From the console, run the following command
```
mono packages/NUnit.ConsoleRunner.3.7.0/tools/nunit3-console.exe --noh --inprocess MbedCloudSDK.Test/MbedCloudSDK.Test.csproj --params=mbed_cloud_sdk_api_key=<api key>
```
2. The test results will appear in the terminal

## Setting up a Mac development environment in Visual Studio Code
1. Open the root of the project in VSCode.
2. Install the Mono Debug extension from the extensions tab.
3. Create a .vscode directory at the root of the project and create a launch.json file.
4. In your launch.json, insert the following:

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
5. Now create a tasks.json file and insert the following:

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
6. Now pressing Cmd + Shift + B should run the build task. Verify that it was successful by checking the output in the integrated terminal.

7. After a build has been successful, press f5 to launch debugging, or Shift + f5 to start without debugging. Any output should appear in the debug console tab of the integrated terminal.

8. To run tests, add the following configuration to your tasks.json

```
        {
            "taskName": "test",
            "type": "process",
            "command": "mono",
            "args": [
                "--debug",
                "packages/NUnit.ConsoleRunner.3.7.0/tools/nunit3-console.exe",
                "MbedCloudSDK.Test/MbedCloudSDK.Test.csproj",
                "--labels=All",
                "--params=mbed_cloud_sdk_api_key=<ApiKey>"
            ],
            "group": "test",
            "presentation": {
                "echo": true,
                "reveal": "always",
                "focus": false,
                "panel": "shared"
            },
            "problemMatcher": "$msCompile"
        }
```
