FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS base
WORKDIR /app
EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT Production

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["PowerBuddy.API/PowerBuddy.API.csproj", "PowerBuddy.API/"]
RUN dotnet restore "PowerBuddy.API/PowerBuddy.API.csproj"
COPY . .
WORKDIR "/src/PowerBuddy.API"
RUN dotnet build "PowerBuddy.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PowerBuddy.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PowerBuddy.API.dll"]
