#!/bin/bash

mkdir -p ./Pelion.Generation.Temp
cd ./Pelion.Generation.Temp && dotnet new classlib && dotnet add reference ../MbedCloudSDK/MbedCloudSDK.csproj && dotnet add package Newtonsoft.Json --version 11.0.2