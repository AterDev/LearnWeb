#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Http.API/Http.API.csproj", "src/Http.API/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
COPY ["src/Definition/EntityFramework/EntityFramework.csproj", "src/Definition/EntityFramework/"]
COPY ["src/Definition/Entity/Entity.csproj", "src/Definition/Entity/"]
COPY ["src/Infrastructure/Ater.Web.Core/Ater.Web.Core.csproj", "src/Infrastructure/Ater.Web.Core/"]
COPY ["src/Infrastructure/Ater.Web.Abstraction/Ater.Web.Abstraction.csproj", "src/Infrastructure/Ater.Web.Abstraction/"]
COPY ["src/Definition/Share/Share.csproj", "src/Definition/Share/"]
COPY ["src/Modules/SystemMod/SystemMod.csproj", "src/Modules/SystemMod/"]
RUN dotnet restore "./src/Http.API/Http.API.csproj"
COPY . .
WORKDIR "/src/src/Http.API"
RUN dotnet build "./Http.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Http.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Http.API.dll"]