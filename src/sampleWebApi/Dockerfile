FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["sampleWebApi/sampleWebApi.csproj", "sampleWebApi/"]
RUN dotnet restore "sampleWebApi/sampleWebApi.csproj"
COPY . .
WORKDIR /src/sampleWebApi
RUN dotnet build "sampleWebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "sampleWebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "sampleWebApi.dll"]
