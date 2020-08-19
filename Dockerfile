FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["PowerLifting.API/PowerLifting.API.csproj", "PowerLifting.API/"]
RUN dotnet restore "PowerLifting.API/PowerLifting.API.csproj"
COPY . .
WORKDIR "/src/PowerLifting.API"
RUN dotnet build "PowerLifting.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PowerLifting.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PowerLifting.API.dll"]
