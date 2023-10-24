FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR ""
COPY ["src/API/CarAdvertCore.Api/CarAdvertCore.Api.csproj", "src/API/CarAdvertCore.Api/"]
COPY ["src/Core/CarAdvertCore.Application/CarAdvertCore.Application.csproj", "src/Core/CarAdvertCore.Application/"]
COPY ["src/Core/CarAdvertCore.Domain/CarAdvertCore.Domain.csproj", "src/Core/CarAdvertCore.Domain/"]
COPY ["src/Infrastructure/CarAdvertCore.Persistence/CarAdvertCore.Persistence.csproj", "src/Infrastructure/CarAdvertCore.Persistence/"]
RUN dotnet restore "src/API/CarAdvertCore.Api/CarAdvertCore.Api.csproj"
COPY . .
WORKDIR "/src/API/CarAdvertCore.Api"
RUN dotnet build "CarAdvertCore.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarAdvertCore.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarAdvertCore.Api.dll"]