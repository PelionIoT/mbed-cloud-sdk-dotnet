FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS builder

WORKDIR /sln

COPY ./build.sh ./build.cake  ./

RUN ./build.sh --target "_clean_integration"

COPY ./Tests/MbedCloudSDK.IntegrationTests ./Tests/MbedCloudSDK.IntegrationTests
COPY ./src ./src

RUN ./build.sh --target "_restore_integration" && ./build.sh --target "_build_integration" && ./build.sh --target "_publish_integration"

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /testserver
ENV ASPNETCORE_ENVIRONMENT Production
ENTRYPOINT ["dotnet", "MbedCloudSDK.IntegrationTests.dll"]
COPY --from=builder ./sln/dist ./