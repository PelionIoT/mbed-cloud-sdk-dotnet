FROM andrewlock/dotnet-mono

WORKDIR /sdk

COPY ./build.sh ./build.cake  ./
COPY ./MbedCloudSDK ./MbedCloudSDK

RUN ./build.sh -Target=_restore_sdk && ./build.sh -Target=_build_sdk && ./build.sh -Target=Create-NuGet-Package