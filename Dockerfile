FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy project files
COPY Server/Server.csproj Server/
COPY Bl/BL.csproj Bl/
COPY Dal/Dal.csproj Dal/

# Restore dependencies
RUN dotnet restore Server/Server.csproj

# Copy source code
COPY . .

# Build application
WORKDIR /src/Server
RUN dotnet build Server.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Server.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Server.dll"]