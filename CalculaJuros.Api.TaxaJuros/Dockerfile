FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["CalculaJuros.Api.TaxaJuros/CalculaJuros.Api.TaxaJuros.csproj", "CalculaJuros.Api.TaxaJuros/"]
RUN dotnet restore "CalculaJuros.Api.TaxaJuros/CalculaJuros.Api.TaxaJuros.csproj"
COPY . .
WORKDIR "/src/CalculaJuros.Api.TaxaJuros"
RUN dotnet build "CalculaJuros.Api.TaxaJuros.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CalculaJuros.Api.TaxaJuros.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CalculaJuros.Api.TaxaJuros.dll"]