# Mbed cloud SDK for .NET - Examples

This project provides a set of examples of how the SDK can be used to interact with Mbed Cloud.

## Prerequisites
* An Mbed Cloud api key

## Prerequisites (Windows)
* Visual Studio (Free community edition can be found [here](https://www.visualstudio.com/vs/))

## Prerequisites (Mac)
* Mono (Latest version can be downloaded from [here](http://www.mono-project.com/download/))
* Nuget (Exectuable can be found [here](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe))

## Building Examples (Windows)
1. Clone the reposotory.
2. Open the solution (.sln) file in Visual Studio.
3. Right click on the ConsoleExamples project and set as startup project.
4. Click 'Start Debugging' to launch the application. This will build and restore dependencies automaticaly. 

## Building Examples (Mac)
1. Clone the repository.
2. At the root, run `nuget restore ConsoleExamples/packages.config -PackagesDirectory packages` to restore the dependencies.
3. In the ConsoleExamples directory, run `msbuild` to build the project.
4. Now run `mono bin/Debug/ConsoleExamples.exe <apiKey>` to run the examples project. 

## Using the examples 
After running, you will be presented with the following menu:

```
Select Example
---Account management---
1. Get account details
2. Get account details async
3. Update account details
4. Update account details async
5. List Api keys
6. List Api keys asynchronously
7. Get Api Key
8. Get Api Key asynchronously
9. Add Api key
10. Add Api key async
11. List Groups
12. List Users
13. Add User
14. Add User async
---Certificates---
15. Create Certificate
16. List Certificates
---Connect---
17. List Connected Devices
18. List filtered connected devices
19. List metrics from last 30 days
20. List metrics from last 2 days in 3 hour intervals
21. List metrics from 1 March 2017 to 1 April 2017
22. Create presubscription
23. Get resource value
24. Set resource value example
25. Subscribe to a resource
26. Subscribe to a resource with a callback
27. Create a webhook for a resource
---Device Directory---
28. Create Devices
29. List Devices
30. Add device query
31. List device logs
32. List device events
---Update---
33. Create update campaign
34. List firmware images
35. List firmware manifests
36. List update campaigns
37. Add firmware image
38. Add firmware manifest
---Press any other key to exit---
```

Enter the number of example you which to run or press any key to exit. 
