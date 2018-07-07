FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
RUN dotnet restore TransitHub.WebApi.csproj
RUN dotnet build TransitHub.WebApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TransitHub.WebApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TransitHub.WebApi.dll"]
