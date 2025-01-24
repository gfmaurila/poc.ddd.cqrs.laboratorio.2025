# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backend/API.Admin.Tests/API.External.Auth.Tests.csproj", "backend/API.Admin.Tests/"]
COPY ["backend/API.Admin/API.External.Auth.csproj", "backend/API.Admin/"]
COPY ["backend/Common.Net8/Common.External.Auth.Net8.csproj", "backend/Common.Net8/"]
RUN dotnet restore "./backend/API.Admin.Tests/API.External.Auth.Tests.csproj"
COPY . .
WORKDIR "/src/backend/API.Admin.Tests"
RUN dotnet build "./API.External.Auth.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.External.Auth.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.External.Auth.Tests.dll"]