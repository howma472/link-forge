FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LinkForge.Web/LinkForge.Web.csproj", "LinkForge.Web/"]
COPY ["LinkForge.Application/LinkForge.Application.csproj", "LinkForge.Application/"]
COPY ["LinkForge.Domain/LinkForge.Domain.csproj", "LinkForge.Domain/"]
COPY ["LinkForge.Infrastructure/LinkForge.Infrastructure.csproj", "LinkForge.Infrastructure/"]
RUN dotnet restore "LinkForge.Web/LinkForge.Web.csproj"
COPY . .
WORKDIR "/src/LinkForge.Web"
RUN dotnet build "./LinkForge.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LinkForge.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinkForge.Web.dll"]
