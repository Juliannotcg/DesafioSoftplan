#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build
WORKDIR /src
COPY ["CalculoJuros/CalculoJuros.Api/CalculoJuros.Api/CalculoJuros.Api.csproj", "CalculoJuros/CalculoJuros.Api/CalculoJuros.Api/"]
COPY ["CalculaJuros.Service/CalculaJuros.Service.csproj", "CalculaJuros.Service/"]
COPY ["CalculaJuros.Domain/CalculaJuros.Domain.csproj", "CalculaJuros.Domain/"]
COPY ["CalculaJuros.Infra/CalculaJuros.Infra.csproj", "CalculaJuros.Infra/"]
RUN dotnet restore "CalculoJuros/CalculoJuros.Api/CalculoJuros.Api/CalculoJuros.Api.csproj"
COPY . .
WORKDIR "/src/CalculoJuros/CalculoJuros.Api/CalculoJuros.Api"
RUN dotnet build "CalculoJuros.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CalculoJuros.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CalculoJuros.Api.dll"]
