# build

FROM mcr.microsoft.com/dotnet/sdk:9.0 as build
WORKDIR /src

COPY . .
RUN dotnet publish -f net9.0 -c release -o out

# launch

FROM mcr.microsoft.com/dotnet/runtime:9.0
WORKDIR /app

COPY --from=build /src/out /app
CMD dotnet MyProject.Scheduler.dll
