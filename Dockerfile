FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
FROM microsoft/aspnetcore
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
COPY ["PowerLifting.API/PowerLifting.API.csproj", "PowerLifting.API/"]
COPY ["Powerlifting.Repository/Powerlifting.Repository.csproj", "PowerLifting.Repository/"]
COPY ["Powerlifting.Persistence/Powerlifting.Persistence.csproj", "PowerLifting.Persistence/"]
COPY ["PowerLifting.Service/PowerLifting.Service.csproj", "PowerLifting.Service/"]
COPY ["PowerLifting.LoggerService/PowerLifting.LoggerService.csproj", "PowerLifting.LoggerService/"]
COPY ["PowerLifting.UnitTests/PowerLifting.UnitTests.csproj", "PowerLifting.UnitTests/"]
RUN dotnet restore "PowerLifting.API/PowerLifting.API.csproj"
COPY . .
RUN dotnet build "PowerLifting.API/PowerLifting.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PowerLifting.API/PowerLifting.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PowerLifting.API.dll"]
