FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /app/Landscape/src
COPY ["Landscape.API/Landscape.API.csproj", "Landscape.API/"]
RUN dotnet restore "Landscape.API/Landscape.API.csproj"
COPY . .
WORKDIR "/app/Landscape/src/Landscape.API"
RUN dotnet build "Landscape.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Landscape.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Landscape.API.dll"]
