
FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["CalculoJuros/CalculoJuros.Api/CalculoJuros.Api/CalculoJuros.Api.csproj", "CalculoJuros/CalculoJuros.Api/CalculoJuros.Api/"]
COPY ["CalculaJuros.Service/CalculaJuros.Service.csproj", "CalculaJuros.Service/"]
COPY ["CalculaJuros.Domain/CalculaJuros.Domain.csproj", "CalculaJuros.Domain/"]
COPY ["CalculaJuros.Infra/CalculaJuros.Infra.csproj", "CalculaJuros.Infra/"]
RUN dotnet restore "CalculoJuros/CalculoJuros.Api/CalculoJuros.Api/CalculoJuros.Api.csproj"
COPY . .
WORKDIR "/src/CalculoJuros/CalculoJuros.Api/CalculoJuros.Api"
RUN dotnet build "CalculoJuros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculoJuros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculoJuros.Api.dll"]

