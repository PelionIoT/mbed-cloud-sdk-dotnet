# Development

## Using the dotnet cli
Simple tasks, like building and running tests can be done using the dotnet cli.

### Building

To build the project, from the home directory run:

```bash
$ dotnet build
```
*This will perform a dotnet restore implicitly, and for all projects in the solution*

### Testing

To run the project unit tests:

```bash
$ dotnet test ./Tests/MbedCloudSDK.UnitTests
```

## Using cake
Cake (C# Make) is a cross-platform task runner for C#. More information can be found [here](https://cakebuild.net/).

There is nothing to install with cake, just run the following from the home directory:

```bash
$ ./build.sh
```

or

```powershell
> build.ps1
```

This will run the default task, identical to doing a `dotnet build`.

### Available cake tasks

The following cake tasks are provided:

Task | purpose
--- | ---
Build | Restore and build the whole solution
Run-Unit-Tests | Build and Run unit tests
CI | Run build on constrained number of projects, used in CI
Publish_Integration | Runs `dotnet publish` on integration test folder
Create-Nuget-Package | Runs `dotnet pack` over SDK project, producing a `.nupgk` file
