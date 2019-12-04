#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build
WORKDIR /src
COPY ["TaxaJuros/TaxaJuros.Api/TaxaJuros.Api.csproj", "TaxaJuros/TaxaJuros.Api/"]
COPY ["TaxaJuros.Domain/TaxaJuros.Domain.csproj", "TaxaJuros.Domain/"]
COPY ["TaxaJuros.Infra/TaxaJuros.Infra.csproj", "TaxaJuros.Infra/"]
RUN dotnet restore "TaxaJuros/TaxaJuros.Api/TaxaJuros.Api.csproj"
COPY . .
WORKDIR "/src/TaxaJuros/TaxaJuros.Api"
RUN dotnet build "TaxaJuros.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TaxaJuros.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TaxaJuros.Api.dll"]