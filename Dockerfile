

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY src/SalesManagement.sln ./
COPY src/Api/Api.csproj ./Api/
COPY src/Application/Application.csproj ./Application/
COPY src/Domain/Domain.csproj ./Domain/
COPY src/Infrastructure/Infrastructure.csproj ./Infrastructure/

RUN dotnet restore Api/Api.csproj

COPY src/ ./

RUN dotnet build Api/Api.csproj -c $BUILD_CONFIGURATION -o /app/build

# ============================================
# Stage 3: Publish
# ============================================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish Api/Api.csproj \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false \
    --no-restore

# ============================================
# Stage 4: Final runtime image
# ============================================
FROM base AS final
WORKDIR /app

# Copiar archivos publicados desde stage de publish
COPY --from=publish /app/publish .

# Punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "Api.dll"]
