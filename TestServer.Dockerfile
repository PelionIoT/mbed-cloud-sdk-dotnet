FROM pomma89/dotnet-mono AS builder

WORKDIR /sln

COPY ./build.sh ./build.cake  ./
COPY ./tools ./tools

RUN ./build.sh -Target=_clean_integration

COPY ./Tests/MbedCloudSDK.IntegrationTests ./Tests/MbedCloudSDK.IntegrationTests
COPY ./src ./src

RUN ./build.sh -Target=_restore_integration && ./build.sh -Target=_build_integration && ./build.sh -Target=_publish_integration

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT Production
ENTRYPOINT ["dotnet", "MbedCloudSDK.IntegrationTests.dll"]
COPY --from=builder ./sln/dist ./