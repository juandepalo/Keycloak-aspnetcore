ARG NODE_IMAGE=node:10-alpine
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS dotnet-build
WORKDIR /src

FROM ${NODE_IMAGE} as node-build
WORKDIR /web
COPY sampleangular/ClientApp .
RUN npm install
RUN npm run build
# RUN npm run build:prod

FROM dotnet-build as publish
WORKDIR /src/src/Web/WebSPA/wwwroot
COPY --from=node-build /web/wwwroot .
WORKDIR /src
COPY . .
WORKDIR /src/sampleangular
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "sampleangular.dll"]

# COPY ["sampleangular/sampleangular.csproj", "sampleangular/"]
# RUN dotnet restore "sampleangular/sampleangular.csproj"
# COPY . .
# WORKDIR "/src/sampleangular"
# RUN dotnet build "sampleangular.csproj" -c Release -o /app

# FROM build AS publish
# RUN dotnet publish "sampleangular.csproj" -c Release -o /app

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app .
# ENTRYPOINT ["dotnet", "sampleangular.dll"]