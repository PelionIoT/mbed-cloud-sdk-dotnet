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
var ciBuildProjects = new string[]{"./MbedCloudSDK/MbedCloudSDK.csproj", "./Tests/MbedCloudSDK.UnitTests/MbedCloudSDK.UnitTests.csproj"};
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

Task("_restore_solution")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./MbedCloudSDK.sln"));
        DotNetCoreRestore(path.FullPath, new DotNetCoreRestoreSettings
        {
            Verbosity = DotNetCoreVerbosity.Minimal
        });
    });

Task("_build_solution")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./MbedCloudSDK.sln"));
        DotNetCoreBuild(path.FullPath, new DotNetCoreBuildSettings
        {
            NoRestore = true,
            Configuration = configuration,
        });
    });

Task("_run_unit_tests")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("Tests/MbedCloudSDK.UnitTests"));
        DotNetCoreTest(path.FullPath, new DotNetCoreTestSettings
        {
            NoBuild = true,
            NoRestore = true,
            Configuration = configuration,
            // ArgumentCustomization = args => args.Append("/p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CopyLocalLockFileAssemblies=true"),
        });
    });

Task("Build")
    .IsDependentOn("_restore_solution")
    .IsDependentOn("_build_solution");

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .IsDependentOn("_run_unit_tests");

Task("Default")
    .IsDependentOn("Build");

// CI Tasks
Task("_restore_ci")
    .Does(() => {
        if(FileExists("NuGet.Config"))
        {
            DeleteFile("NuGet.Config");
        }

        CreateDirectory("packages");
        FileAppendLines("NuGet.Config", new string[] {
            "<?xml version=\"1.0\" encoding=\"utf-8\"?>",
            "<configuration>",
            "  <config>",
            "    <add key=\"globalPackagesFolder\" value=\"packages\" />",
            "  </config>",
            "</configuration>"
        });

        foreach(var project in ciBuildProjects)
        {
            var path = MakeAbsolute(new DirectoryPath(project));
            DotNetCoreRestore(path.FullPath, new DotNetCoreRestoreSettings
            {
                Verbosity = DotNetCoreVerbosity.Minimal
            });
        }
    });

Task("_build_ci")
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

Task("CI")
    .IsDependentOn("_restore_ci")
    .IsDependentOn("_build_ci");

// Integration Tests Tasks

Task("_clean_integration")
    .Does(() =>
    {
        CleanDirectory(distDirectory);
    });

Task("_restore_integration")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./Tests/MbedCloudSDK.IntegrationTests/MbedCloudSDK.IntegrationTests.csproj"));
        DotNetCoreRestore(path.FullPath, new DotNetCoreRestoreSettings
        {
            Verbosity = DotNetCoreVerbosity.Minimal
        });
    });

Task("_build_integration")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./Tests/MbedCloudSDK.IntegrationTests/MbedCloudSDK.IntegrationTests.csproj"));
        DotNetCoreBuild(path.FullPath, new DotNetCoreBuildSettings
        {
            NoRestore = true,
            Configuration = configuration,
        });
    });

Task("_publish_integration")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./Tests/MbedCloudSDK.IntegrationTests/MbedCloudSDK.IntegrationTests.csproj"));
        DotNetCorePublish(path.FullPath, new DotNetCorePublishSettings
        {
            Configuration = configuration,
            OutputDirectory = distDirectory,
            NoRestore = true,
        });
    });

Task("Publish_Integration")
    .IsDependentOn("_clean_integration")
    .IsDependentOn("_restore_integration")
    .IsDependentOn("_build_integration")
    .IsDependentOn("_publish_integration");

// SDK Only Tasks

Task("_restore_sdk")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./MbedCloudSDK/MbedCloudSDK.csproj"));
        DotNetCoreRestore(path.FullPath, new DotNetCoreRestoreSettings
        {
            Verbosity = DotNetCoreVerbosity.Minimal
        });
    });

Task("_build_sdk")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./MbedCloudSDK/MbedCloudSDK.csproj"));
        DotNetCoreBuild(path.FullPath, new DotNetCoreBuildSettings
        {
            NoRestore = true,
            Configuration = configuration,
        });
    });


Task("Create-NuGet-Package")
    .Does(() => {
        var path = MakeAbsolute(new DirectoryPath("./MbedCloudSDK/MbedCloudSDK.csproj"));
        DotNetCorePack(path.FullPath, new DotNetCorePackSettings
        {
            Configuration = configuration,
            NoBuild = true,
            NoRestore = true,
        });
    });

Task("_publish")
    .Does(() => {
        var nugetApiKey = Argument("nuget_api_key", EnvironmentVariable("NUGET_KEY"));
        var source = Argument("nuget_source", "https://api.nuget.org/v3/index.json");
        var packages = GetFiles("./MbedCloudSDK/bin/Release/*.nupkg");
        // foreach(var file in packages)
        // {
        //     Information(file);
        //     Information(nugetApiKey);
        //     Information(source);
        //     NuGetPush(file, new NuGetPushSettings
        //     {
        //         ApiKey = nugetApiKey,
        //         Source = source,
        //     });
        // }
    });

Task("_clean_generation")
    .Does(() => {
        CleanDirectory("./MbedCloudSDK/Generated");
        CleanDirectory("./Manhasset.Generation.Temp");
    });

Task("_create empty_project")
    .Does(() => {
        StartProcess("./scripts/generation_setup.sh");
    });

Task("_restore_empty_project")
    .Does(() => {
        DotNetCoreRestore("./Manhasset.Generation.Temp", new DotNetCoreRestoreSettings {
            Verbosity = DotNetCoreVerbosity.Minimal,
        });
    });

Task("_restore_generator")
    .Does(() => {
        DotNetCoreRestore("./Manhasset/Manhasset.Runner", new DotNetCoreRestoreSettings {
            Verbosity = DotNetCoreVerbosity.Minimal,
        });
    });

Task("_build_generator")
    .Does(() => {
        DotNetCoreBuild("./Manhasset/Manhasset.Runner", new DotNetCoreBuildSettings {
            NoRestore = true,
            Configuration = configuration,
        });
    });

Task("_generate_and_compile")
    .Does(() => {
        DotNetCoreRun("./Manhasset/Manhasset.Runner", new ProcessArgumentBuilder()
            .Append("/Users/alelog01/git/mbed-cloud-api-contract/out/sdk_generation_cache.yaml")
            //.Append("./Pelion.Generation.Temp/Pelion.Generation.Temp.csproj")
            .Append("Manhasset.Generation.Temp")
            .Append("/Users/alelog01/git/mbed-cloud-sdk-dotnet/"),
            new DotNetCoreRunSettings {
                NoBuild = true,
                NoRestore = true,
                Configuration = configuration,
            });
    });

Task("_write_files")
    .Does(() => {
        CopyDirectory("./Manhasset.Generation.Temp/src", "./MbedCloudSDK/Generated");
    });

Task("generation_debug")
    .IsDependentOn("_clean_generation")
    .IsDependentOn("_create empty_project")
    .IsDependentOn("_restore_empty_project")
    .IsDependentOn("_restore_generator")
    .IsDependentOn("_build_generator")
    .IsDependentOn("_generate_and_compile")
    .IsDependentOn("_write_files")
    .IsDependentOn("_restore_solution")
    .IsDependentOn("_build_solution");

Task("Build-Pack-Publish")
    .IsDependentOn("_restore_sdk")
    .IsDependentOn("_build_sdk")
    .IsDependentOn("Create-NuGet-Package")
    .IsDependentOn("_publish");

Task("Pack-And-Publish")
    .IsDependentOn("Create-NuGet-Package")
    .IsDependentOn("_publish");


RunTarget(target);