#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
# cd lrtest-api/src
# docker build -t lrtest -f /LRtest.Api/Dockerfile .
# docker run --rm -d -p 8082:80 --name lrtest lrtest 本项目暂由容器的80端口映射到主机的8082端口，再由nginx做反向代理

# base阶段
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base # mcr.microsoft.com/dotnet/aspnet:6.0 用于运行程序
WORKDIR /app # 工作目录
EXPOSE 80 # 监听http端口
EXPOSE 443 # 监听https端口

# build阶段
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build # mcr.microsoft.com/dotnet/sdk:6.0 用于构建程序
WORKDIR /src # 工作目录
COPY ["LRtest.Api/LRtest.Api.csproj", "LRtest.Api/"] # 将/src/LRtest.Api/LRtest.Api.csproj复制到容器的/src/LRtest.Api目录下
COPY ["LRtest.Service/LRtest.Service.csproj", "LRtest.Service/"]
COPY ["LRtest.Repositorys/LRtest.Repository.csproj", "LRtest.Repositorys/"]
COPY ["LRtest.DTO/LRtest.DTO.csproj", "LRtest.DTO/"]
COPY ["LRtest.Domain/LRtest.Domain.csproj", "LRtest.Domain/"]
COPY ["LRtest.Enums/LRtest.Enums.csproj", "LRtest.Enums/"]
RUN dotnet restore "LRtest.Api/LRtest.Api.csproj" # 还原项目的NuGet依赖项
COPY . . # 将当前目录下的所有文件复制到容器内的当前目录(src目录下)
WORKDIR "/src/LRtest.Api" # 切换工作目录
RUN dotnet build "LRtest.Api.csproj" -c Release -o /app/build # 在容器内构建Release版本并放到/app/build目录下

# publish阶段
FROM build AS publish
RUN dotnet publish "LRtest.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false # 在容器内发布Release版本并放到/app/publish目录下

# final阶段
FROM base AS final
WORKDIR /app # 工作目录
COPY --from=publish /app/publish . # 从publish阶段的镜像中/app/publish目录下的文件复制到当前目录下
ENTRYPOINT ["dotnet", "LRtest.Api.dll"] # 容器启动时运行程序
