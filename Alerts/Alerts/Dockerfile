#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1809 AS build
WORKDIR /src
COPY ["Alerts.csproj", ""]
COPY ["../Alerts.Domain/Alerts.Domain.csproj", "../Alerts.Domain/"]
COPY ["../Core.System/Core.System.csproj", "../Core.System/"]
COPY ["../Alerts.Models/Alerts.Models.csproj", "../Alerts.Models/"]
COPY ["../Alerts.Domain.Contracts/Alerts.Domain.Contracts.csproj", "../Alerts.Domain.Contracts/"]
COPY ["../Alerts.Repository.Contracts/Alerts.Repository.Contracts.csproj", "../Alerts.Repository.Contracts/"]
COPY ["../Alerts.Repository/Alerts.Repository.csproj", "../Alerts.Repository/"]
RUN dotnet restore "./Alerts.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Alerts.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Alerts.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Alerts.dll"]