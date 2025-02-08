# Базовый образ для запуска приложения
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Этап сборки backend
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Копируем файл проекта и выполняем restore
COPY contests-app.API.csproj ./
RUN dotnet restore "contests-app.API.csproj"

# Копируем все файлы и собираем проект
COPY . .
RUN dotnet build "contests-app.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этап сборки frontend
FROM node:20 AS node
WORKDIR /src
COPY VueClientApp/ ./
RUN npm install --no-audit && npm run build

# Этап публикации backend
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "contests-app.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Финальный образ
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=node /src/dist /app/wwwroot/

# Запуск приложения
ENTRYPOINT ["dotnet", "contests-app.API.dll"]
