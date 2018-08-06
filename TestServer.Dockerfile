FROM andrewlock/dotnet-mono AS builder

WORKDIR /sln

COPY ./build.sh ./build.cake  ./

RUN ./build.sh -Target=_clean_integration

COPY ./Tests/MbedCloudSDK.IntegrationTests ./Tests/MbedCloudSDK.IntegrationTests
COPY ./MbedCloudSDK ./MbedCloudSDK

RUN ./build.sh -Target=_restore_integration && ./build.sh -Target=_build_integration && ./build.sh -Target=_publish_integration

FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT Production
ENTRYPOINT ["dotnet", "MbedCloudSDK.IntegrationTests.dll"]
COPY --from=builder ./sln/dist ./