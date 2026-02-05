FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar todo el código
COPY src ./src

# Restaurar proyecto API
RUN dotnet restore src/Api/Api.csproj

# Compilar
RUN dotnet build src/Api/Api.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish src/Api/Api.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Api.dll"]

