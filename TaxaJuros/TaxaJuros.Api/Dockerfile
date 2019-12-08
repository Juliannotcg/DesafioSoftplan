#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["TaxaJuros/TaxaJuros.Api/TaxaJuros.Api.csproj", "TaxaJuros/TaxaJuros.Api/"]
COPY ["TaxaJuros/TaxaJuros.Infra/TaxaJuros.Infra.csproj", "TaxaJuros/TaxaJuros.Infra/"]
COPY ["TaxaJuros/TaxaJuros.Domain/TaxaJuros.Domain.csproj", "TaxaJuros/TaxaJuros.Domain/"]
RUN dotnet restore "TaxaJuros/TaxaJuros.Api/TaxaJuros.Api.csproj"
COPY . .


WORKDIR "/src/TaxaJuros/TaxaJuros.Api"
RUN dotnet build "TaxaJuros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaxaJuros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaxaJuros.Api.dll"]