# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and all projects
COPY ../../*.sln ./
COPY ../../src/FlightBookingSystem.Domain/ ./FlightBookingSystem.Domain/
COPY ../../src/FlightBookingSystem.Application/ ./FlightBookingSystem.Application/
COPY ../../src/FlightBookingSystem.Infrastructure/ ./FlightBookingSystem.Infrastructure/
COPY ../../src/FlightBookingSystem.App/ ./FlightBookingSystem.App/

WORKDIR /src/FlightBookingSystem.App
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/publish .

VOLUME ["/app/Data"]

ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "FlightBookingSystem.App.dll"]