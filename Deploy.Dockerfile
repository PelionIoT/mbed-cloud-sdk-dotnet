FROM pomma89/dotnet-mono

WORKDIR /sdk

COPY ./build.sh ./build.cake  ./
COPY ./src ./src

RUN ./build.sh --target "_restore_sdk" && ./build.sh --target "_build_sdk" && ./build.sh --target "Create-NuGet-Package"