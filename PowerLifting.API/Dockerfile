#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM microsoft/aspnetcore
EXPOSE 80

COPY ./publish /publish
WORKDIR /publish

ENV ASPNETCORE_URLS="http://*:5000"
ENTRYPOINT ["dotnet", "PowerLifting.API.dll"]