FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
FROM microsoft/aspnetcore
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
COPY ["PowerLifting.API/PowerLifting.API.csproj", "PowerLifting.API/"]
COPY ["Powerlifting.Repository/Powerlifting.Repository.csproj", "Powerlifting.Repository/"]
COPY ["Powerlifting.Persistence/Powerlifting.Persistence.csproj", "Powerlifting.Persistence/"]
COPY ["PowerLifting.Cypto/PowerLifting.Cypto.csproj", "PowerLifting.Cypto/"]
COPY ["PowerLifting.Services/PowerLifting.Services.csproj", "PowerLifting.Services/"]
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