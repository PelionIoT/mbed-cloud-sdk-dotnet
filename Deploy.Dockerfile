FROM pomma89/dotnet-mono

WORKDIR /sdk

COPY ./build.sh ./build.cake  ./
COPY ./src ./src

RUN ./build.sh -Target=_restore_sdk && ./build.sh -Target=_build_sdk && ./build.sh -Target=Create-NuGet-Package