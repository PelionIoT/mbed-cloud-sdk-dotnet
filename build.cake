#addin "Cake.Docker"
#addin "Cake.FileHelpers"

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PARAMETERS
//////////////////////////////////////////////////////////////////////
var ciBuildProjects = new string[]{"./src/MbedCloudSDK.csproj", "./Tests/MbedCloudSDK.UnitTests/MbedCloudSDK.UnitTests.csproj"};
var distDirectory = MakeAbsolute(new DirectoryPath("./dist")).FullPath;

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////
Setup(context =>
{
   Information("Setup...");
});

Teardown(ctx =>
{
   Information("Starting Teardown...");

   Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////


// default sulution tasks

var restore_solution = Task("_restore_solution")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./MbedCloudSDK.sln"));
        DotNetCoreRestore(path.FullPath, new DotNetCoreRestoreSettings
        {
            Verbosity = DotNetCoreVerbosity.Minimal
        });
    });

var build_solution = Task("_build_solution")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./MbedCloudSDK.sln"));
        DotNetCoreBuild(path.FullPath, new DotNetCoreBuildSettings
        {
            NoRestore = true,
            Configuration = configuration,
        });
    });

var run_unit_tests = Task("_run_unit_tests")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("Tests/MbedCloudSDK.UnitTests"));
        DotNetCoreTest(path.FullPath, new DotNetCoreTestSettings
        {
            NoBuild = true,
            NoRestore = true,
            Configuration = configuration,
        });
    });

var Build = Task("Build")
    .IsDependentOn(restore_solution)
    .IsDependentOn(build_solution);

var Run_Unit_Tests = Task("Run-Unit-Tests")
    .IsDependentOn(Build)
    .IsDependentOn(run_unit_tests);

var Default = Task("Default")
    .IsDependentOn(Build);

// CI Tasks
var restore_ci =  Task("_restore_ci")
    .Does(() => {
        foreach(var project in ciBuildProjects)
        {
            var path = MakeAbsolute(new DirectoryPath(project));
            DotNetCoreRestore(path.FullPath, new DotNetCoreRestoreSettings
            {
                Verbosity = DotNetCoreVerbosity.Minimal
            });
        }
    });

var build_ci = Task("_build_ci")
    .Does(() => {
        foreach(var project in ciBuildProjects)
        {
            var path = MakeAbsolute(new DirectoryPath(project));
            DotNetCoreBuild(path.FullPath, new DotNetCoreBuildSettings
            {
                NoRestore = true,
                Configuration = configuration,
            });
        }
    });

var CI = Task("CI")
    .IsDependentOn(restore_ci)
    .IsDependentOn(build_ci);

// Integration Tests Tasks

var clean_integration = Task("_clean_integration")
    .Does(() =>
    {
        CleanDirectory(distDirectory);
    });

var restore_integration = Task("_restore_integration")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./Tests/MbedCloudSDK.IntegrationTests/MbedCloudSDK.IntegrationTests.csproj"));
        DotNetCoreRestore(path.FullPath, new DotNetCoreRestoreSettings
        {
            Verbosity = DotNetCoreVerbosity.Minimal
        });
    });

var build_integration = Task("_build_integration")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./Tests/MbedCloudSDK.IntegrationTests/MbedCloudSDK.IntegrationTests.csproj"));
        DotNetCoreBuild(path.FullPath, new DotNetCoreBuildSettings
        {
            NoRestore = true,
            Configuration = configuration,
        });
    });

var publish_integration = Task("_publish_integration")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./Tests/MbedCloudSDK.IntegrationTests/MbedCloudSDK.IntegrationTests.csproj"));
        DotNetCorePublish(path.FullPath, new DotNetCorePublishSettings
        {
            Configuration = configuration,
            OutputDirectory = distDirectory,
            NoRestore = true,
        });
    });

var Publish_integration = Task("Publish_Integration")
    .IsDependentOn(clean_integration)
    .IsDependentOn(restore_integration)
    .IsDependentOn(build_integration)
    .IsDependentOn(publish_integration);

// SDK Only Tasks

var restore_sdk = Task("_restore_sdk")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./src/MbedCloudSDK.csproj"));
        DotNetCoreRestore(path.FullPath, new DotNetCoreRestoreSettings
        {
            Verbosity = DotNetCoreVerbosity.Minimal
        });
    });

var build_sdk = Task("_build_sdk")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./src/MbedCloudSDK.csproj"));
        DotNetCoreBuild(path.FullPath, new DotNetCoreBuildSettings
        {
            NoRestore = true,
            Configuration = configuration,
        });
    });


var Create_Nuget_Package = Task("Create-NuGet-Package")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./src/MbedCloudSDK.csproj"));
        DotNetCorePack(path.FullPath, new DotNetCorePackSettings
        {
            Configuration = configuration,
            NoBuild = true,
            NoRestore = true,
        });
    });

var publish = Task("_publish")
    .Does(() => {
        var nugetApiKey = Argument("nuget_api_key", EnvironmentVariable("NUGET_KEY"));
        var source = Argument("nuget_source", "https://api.nuget.org/v3/index.json");
        var packages = GetFiles("./src/bin/Release/*.nupkg");
        foreach(var file in packages)
        {
            Information(file);
            Information(nugetApiKey);
            Information(source);
            NuGetPush(file, new NuGetPushSettings
            {
                ApiKey = nugetApiKey,
                Source = source,
            });
        }
    });

var clean_generator = Task("_clean_generation")
    .Does(() => {
        CleanDirectory("./src/SDK/Foundation");
    });

var move_custom_files = Task("_move_custom_files")
    .Does(() => {
        CreateDirectory("./tmp");
        MoveDirectory("./src/SDK/Common/CustomFunctions", "./tmp/CustomFunctions");
    });

var restore_generator = Task("_restore_generator")
    .Does(() => {
        DotNetCoreRestore("./Manhasset/Manhasset.Runner", new DotNetCoreRestoreSettings {
            Verbosity = DotNetCoreVerbosity.Minimal,
        });
    });

var build_generator = Task("_build_generator")
    .Does(() => {
        DotNetCoreBuild("./Manhasset/Manhasset.Runner", new DotNetCoreBuildSettings {
            NoRestore = true,
            Configuration = configuration,
        });
    });

var generate_and_compile = Task("_generate_and_compile")
    .Does(() => {
        DotNetCoreRun("./Manhasset/Manhasset.Runner", null,
            new DotNetCoreRunSettings {
                NoBuild = true,
                NoRestore = true,
                Configuration = configuration,
            });
    });

var move_Files_back = Task("_move_files_back")
    .Does(() => {
        MoveDirectory("./tmp/CustomFunctions", "./src/SDK/Common/CustomFunctions");
        DeleteDirectory("./tmp");
    });

var generate = Task("generate")
    .IsDependentOn(clean_generator)
    .IsDependentOn(move_custom_files)
    .IsDependentOn(restore_generator)
    .IsDependentOn(build_generator)
    .IsDependentOn(generate_and_compile)
    .IsDependentOn(move_Files_back)
    .IsDependentOn(restore_solution)
    .IsDependentOn(build_solution);

var Build_Pack_Publish = Task("Build-Pack-Publish")
    .IsDependentOn(restore_sdk)
    .IsDependentOn(build_sdk)
    .IsDependentOn(Create_Nuget_Package)
    .IsDependentOn(publish);

var Pack_And_Publish = Task("Pack-And-Publish")
    .IsDependentOn(Create_Nuget_Package)
    .IsDependentOn(publish);


RunTarget(target);