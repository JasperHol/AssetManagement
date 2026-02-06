FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/AssetManagement.Api/AssetManagement.Api.csproj", "src/AssetManagement.Api/"]
COPY ["src/AssetManagement.Application/AssetManagement.Application.csproj", "src/AssetManagement.Application/"]
COPY ["src/AssetManagement.Domain/AssetManagement.Domain.csproj", "src/AssetManagement.Domain/"]
COPY ["src/AssetManagement.Infrastructure/AssetManagement.Infrastructure.csproj", "src/AssetManagement.Infrastructure/"]
RUN dotnet restore "./src/AssetManagement.Api/./AssetManagement.Api.csproj"
COPY . .
WORKDIR "/src/src/AssetManagement.Api"
RUN dotnet build "./AssetManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AssetManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AssetManagement.Api.dll"]