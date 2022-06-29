FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine AS base

ENV \
    # Set the default console formatter to JSON
    Logging__Console__FormatterName=Json \
    # Enable detection of running in a container
    DOTNET_RUNNING_IN_CONTAINER=true \
    # Opt out from Microsoft telemetry
    DOTNET_CLI_TELEMETRY_OPTOUT=1 \
    # Prevent hosting startup
    ASPNETCORE_PREVENTHOSTINGSTARTUP=true \
    # Use port set in manifest json file
    ASPNETCORE_URLS=http://*:80 \
    # Set environment inside docker
    ASPNETCORE_ENVIRONMENT=Production

WORKDIR /app
COPY . .
ENTRYPOINT [ "/app/RocheChallenge" ]
