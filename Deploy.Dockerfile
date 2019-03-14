FROM mcr.microsoft.com/dotnet/core/sdk:2.2

WORKDIR /sdk

COPY ./build.sh ./build.cake  ./
COPY ./src ./src

RUN ./build.sh --target "_restore_sdk" && ./build.sh --target "_build_sdk" && ./build.sh --target "Create-NuGet-Package"