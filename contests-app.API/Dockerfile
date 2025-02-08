FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY contests-app.API/contests-app.API.csproj contests-app.API/
RUN dotnet restore "contests-app.API/contests-app.API.csproj"

COPY . .
WORKDIR /src/contests-app.API
RUN dotnet build "contests-app.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM node:20 AS node
WORKDIR /src
COPY contests-app.API/VueClientApp/ ./
RUN npm install --no-audit && npm run build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "contests-app.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=node /src/dist /app/wwwroot/

ENTRYPOINT ["dotnet", "contests-app.API.dll"]
