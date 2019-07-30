FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/sampleangular/sampleangular.csproj", "src/sampleangular/"]
RUN dotnet restore "src/sampleangular/sampleangular.csproj"
COPY . .
WORKDIR "/src/src/sampleangular"
RUN dotnet build "sampleangular.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "sampleangular.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "sampleangular.dll"]