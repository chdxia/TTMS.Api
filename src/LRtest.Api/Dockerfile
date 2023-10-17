#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LRtest.Api/LRtest.Api.csproj", "LRtest.Api/"]
COPY ["LRtest.Service/LRtest.Service.csproj", "LRtest.Service/"]
COPY ["LRtest.Repositorys/LRtest.Repository.csproj", "LRtest.Repositorys/"]
COPY ["LRtest.DTO/LRtest.DTO.csproj", "LRtest.DTO/"]
COPY ["LRtest.Domain/LRtest.Domain.csproj", "LRtest.Domain/"]
COPY ["LRtest.Enums/LRtest.Enums.csproj", "LRtest.Enums/"]
RUN dotnet restore "LRtest.Api/LRtest.Api.csproj"
COPY . .
WORKDIR "/src/LRtest.Api"
RUN dotnet build "LRtest.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LRtest.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LRtest.Api.dll"]