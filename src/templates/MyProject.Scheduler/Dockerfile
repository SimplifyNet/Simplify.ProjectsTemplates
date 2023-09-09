# build

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /src

COPY . .
RUN dotnet publish -f net7.0 -c release -o out

# launch

FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app

COPY --from=build /src/out /app
CMD dotnet MyProject.Scheduler.dll
