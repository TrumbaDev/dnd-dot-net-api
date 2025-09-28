FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копируем файл проекта
COPY dnd-dot-net-api.csproj .
RUN dotnet restore

# Копируем весь код
COPY . .
RUN dotnet publish -c Release -o /app

# Финальный образ
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .

EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["dotnet", "dnd-dot-net-api.dll"]